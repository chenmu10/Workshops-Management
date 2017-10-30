using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerView : System.Web.UI.Page
    {
        List<Models.Volunteer> Volunteers = new List<Models.Volunteer>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        Dictionary<int, string> ListStatus = new Dictionary<int, string>();
        List<Button> Buttons = new List<Button>();
        bool EditMode = false;
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Volunteers = db.GetAllVolunteers();
            Areas = db.GetAreaActivity();
            ListStatus = db.GetVolunteerStatus();
            InsertToVolunterTable(Volunteers);
            FillFilterDropdowns();
        }

        private void InsertToVolunterTable(List<Models.Volunteer> Volunteers)
        {
            bool managerOk = false;
            if (db.IsManager(Session["Manager"]))
            {
                managerOk = true;
                expot.Visible = true;
                approve.Visible = true;
            }

            foreach (Models.Volunteer volunteer in Volunteers)
            {
                TableCell Name = new TableCell();
                Name.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
                TableCell Status = new TableCell();
                Status.Text = ListStatus[volunteer.Volunteer_Practice];
                Status.Width = 120;
                TableCell Occupation = new TableCell();
                Occupation.Text = volunteer.Volunteer_Occupation;
                TableCell Email = new TableCell();
                Email.Text = volunteer.Volunteer_Email;
                Email.Width = 150;
                TableCell Phone = new TableCell();
                Phone.Text = volunteer.Volunteer_phone;
                Phone.Width = 120;
                string activityAreas = string.Empty;
                DropDownList DropListAreas = new DropDownList();
                foreach (int VolunterrArea in volunteer.Volunteer_Area_Activity)
                {
                    activityAreas = activityAreas + new ListItem(Areas[VolunterrArea]);
                    activityAreas = activityAreas + ",";
                    DropListAreas.Items.Add(new ListItem(Areas[VolunterrArea]));
                }

                TableCell Area = new TableCell();
                Area.Text = activityAreas;

                TableCell traning = new TableCell();
                traning.Text = Areas[volunteer.Volunteer_prefer_traning_area];

                // Area.Text = Areas[volunteer.Volunteer_Area_Activity];
                TableCell ActiviesNumber = new TableCell();
                ActiviesNumber.Text = volunteer.Volunteer_Number_Of_Activities.ToString();

                TableCell Edit = new TableCell();
                Edit.Width = 200;
                Button Editbtn = new Button();
                Editbtn.ID = volunteer.Volunteer_ID.ToString();
                Editbtn.Click += new EventHandler(Edit_Click);
                Buttons.Add(Editbtn);
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Edit.Controls.Add(Editbtn);

                if (managerOk)
                {
                    Button EditbtnManager = new Button();
                    EditbtnManager.ID = volunteer.Volunteer_ID.ToString() + "s";
                    EditbtnManager.Click += new EventHandler(Edit_Click);
                    EditbtnManager.Text = "עריכה";
                    EditbtnManager.CssClass = "btn btn-default";
                    Edit.Controls.Add(EditbtnManager);
                }
                
                TableRow TableRow = new TableRow();
                TableRow.HorizontalAlign = HorizontalAlign.Right;
                TableRow.Cells.Add(Name);
                TableRow.Cells.Add(Status);
                TableRow.Cells.Add(Occupation);
                TableRow.Cells.Add(Email);
                TableRow.Cells.Add(Phone);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(traning);
                TableRow.Cells.Add(ActiviesNumber);
                TableRow.Cells.Add(Edit);

                volunteerTable.Rows.Add(TableRow);
            }
            Sum.Text = "";
            Sum.Text = "כמות : ";
            Sum.Text += string.Format("{0}", Volunteers.Count().ToString());
        }
        public void FillFilterDropdowns()
        {
            // practice status 
            DropDownListStatus.Items.Add("ללא הכשרה");
            DropDownListStatus.Items.Add("מתנדבת חדשה");
            DropDownListStatus.Items.Add("מתנדבת ותיקה");

            // training and activity area
            List<ListItem> Areas = db.GetAllAreas();
            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListAreas.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
                DropDownListTraining.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string key = ((Button)sender).ID.ToString();
            Session["SelectedVolunteer"] = key;
            Response.Redirect("VolunteerEditInfo.aspx", false);           

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Volunteers = db.GetAllVolunteers();
            TableRow t = volunteerTable.Rows[0];
            volunteerTable.Rows.Clear();
            volunteerTable.Rows.Add(t);
            string name = nameText.Text.ToString();
            string email = emailText.Text.ToString();

            if (!name.Equals(""))
                Volunteers = Volunteers.Where(x => x.Volunteer_First_Name.ToUpper().Contains(name.ToUpper()) || x.Volunteer_First_Name_Eng.ToUpper().Contains(name.ToUpper()) ||
                  x.Volunteer_Last_Name.ToUpper().Contains(name.ToUpper()) || x.Volunteer_Last_Name_Eng.ToUpper().Contains(name.ToUpper())).ToList();
            if (!email.Equals(""))
                Volunteers = Volunteers.Where(x => x.Volunteer_Email.ToUpper().Contains(email.ToUpper())).ToList();
            InsertToVolunterTable(Volunteers);
        }

        protected void Filter_Click(object sender, EventArgs e)
        {

            InsertToVolunterTable(SortByFilterFunc());
        }
        public List<Models.Volunteer> SortByFilterFunc()
        {
            List<Models.Volunteer> result = new List<Models.Volunteer>();
            Volunteers = db.GetAllVolunteers();
            TableRow t = volunteerTable.Rows[0];
            volunteerTable.Rows.Clear();
            volunteerTable.Rows.Add(t);
            int status = DropDownListStatus.SelectedIndex;
            int area = DropDownListAreas.SelectedIndex;
            int traning = DropDownListTraining.SelectedIndex;
            result = Volunteers;
            if (status != 0)
                result = result.FindAll(x => x.Volunteer_Practice == status);
            if (area != 0)
                result = result.FindAll(x => x.Volunteer_Area_Activity.Contains(area));
            if (traning != 0)
                result = result.FindAll(x => x.Volunteer_prefer_traning_area == traning);

            return result;
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Volunteer/ApproveNewVolunteerForm.aspx", false);      
        }

        protected void NameSort(object sender, EventArgs e)
        {
            List<TableRow> rows = new List<TableRow>();
            TableRow t = volunteerTable.Rows[0];
            List<Models.Volunteer> volunteers = SortByFilterFunc();
            volunteers = volunteers.OrderBy(x => x.Volunteer_First_Name.ToString()).ToList();
            volunteerTable.Rows.Clear();
            volunteerTable.Rows.Add(t);

            InsertToVolunterTable(volunteers);
        }
        protected void StatusSort(object sender, EventArgs e)
        {
            List<TableRow> rows = new List<TableRow>();
            TableRow t = volunteerTable.Rows[0];
            List<Models.Volunteer> volunteers = SortByFilterFunc();
            volunteers = volunteers.OrderBy(x => x.Volunteer_Practice).ToList();
            volunteerTable.Rows.Clear();
            volunteerTable.Rows.Add(t);

            InsertToVolunterTable(volunteers);
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();

            string path = Server.MapPath("..\\..\\Content\\Report.csv");
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                using (System.IO.StreamWriter filewriter = new System.IO.StreamWriter(path, true, Encoding.UTF8))
                {
                    filewriter.WriteLine("Volunteer Name, Status, Occupation, Email, Phone, Activity Areas, Traning Area, Activity Numner");
                    List<Models.Volunteer> Data = new List<Models.Volunteer>();
                    int status = DropDownListStatus.SelectedIndex;
                    int area = DropDownListAreas.SelectedIndex;
                    int traning = DropDownListTraining.SelectedIndex;
                    string name = nameText.Text.ToString();
                    string email = emailText.Text.ToString();

                    if (status != 0 || area!=0 || traning!=0)
                    {
                        Data = SortByFilterFunc();

                    } // if
                    else if (!name.Equals("") || !email.Equals(""))
                    {
                        if (!name.Equals(""))
                            Data = Volunteers.Where(x => x.Volunteer_First_Name.Contains(name) || x.Volunteer_First_Name_Eng.Contains(name) ||
                              x.Volunteer_Last_Name.Contains(name) || x.Volunteer_Last_Name_Eng.Contains(name)).ToList();
                        if (!email.Equals(""))
                            Data = Volunteers.Where(x => x.Volunteer_Email.Contains(email)).ToList();
                    }
                    else
                    {
                        Data = db.GetAllVolunteers();
                    }

                    foreach (Models.Volunteer com in Data)
                    {
                        name = (com.Volunteer_First_Name+" "+com.Volunteer_Last_Name).Replace(',', ' ');
                        string Vstatus = ListStatus[com.Volunteer_Practice];
                        string Occupation = com.Volunteer_Occupation.Replace(',', ' ');
                        string VEmail = com.Volunteer_Email.Replace(',', ' ');
                        string Vphone = com.Volunteer_phone.Replace(',', ' ');
                        string activityAreas = string.Empty;
                        string Traning = Areas[com.Volunteer_prefer_traning_area].ToString().Replace(',', ' ');
                        string ActivityNum = com.Volunteer_Number_Of_Activities.ToString();
                        foreach (int VolunterrArea in com.Volunteer_Area_Activity)
                        {
                            activityAreas = activityAreas + Areas[VolunterrArea].ToString().Replace(',', ' '); ;
                            activityAreas = activityAreas + " וגם ";
                        }
                       
                        string str =
                            String.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                            name,
                            Vstatus,
                            Occupation,
                            VEmail,
                            Vphone,
                            activityAreas,
                            Traning,
                            ActivityNum);

                        filewriter.WriteLine(str);
                    }
                }
                System.IO.FileInfo file = new System.IO.FileInfo(path); //get file object as FileInfo
                if (file.Exists) //-- if the file exists on the server
                {
                    Response.Clear(); //set appropriate headers
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/....";
                    Response.WriteFile(file.FullName);
                    Response.End(); //if file does not exist
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
            catch (Exception exp)
            {
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href = ''; </script>");
        }

        //protected void OccupationSort(object sender, EventArgs e)
        //{
        //    List<TableRow> rows = new List<TableRow>();
        //    TableRow t = volunteerTable.Rows[0];
        //    List<Volunteer> volunteers = SortByFilterFunc();
        //    volunteers = volunteers.OrderBy(x => x.Volunteer_Occupation.ToString()).ToList();
        //    volunteerTable.Rows.Clear();
        //    volunteerTable.Rows.Add(t);

        //    InsertToVolunterTable(volunteers);
        //}
    }
}