using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class ApproveNewVolunteerForm : System.Web.UI.Page
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
            Volunteers = Volunteers.Where(x => x.Volunteer_Practice == 1).ToList();
            InsertToVolunterTable(Volunteers);
            FillFilterDropdowns();
        }

        private void InsertToVolunterTable(List<Models.Volunteer> Volunteers)
        {
            bool managerOk = false;
            if (db.IsManager(Session["Manager"]))
            {
                managerOk = true;
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

                TableCell Check = new TableCell();
                CheckBox box = new CheckBox();
                Check.Controls.Add(box);

                TableRow TableRow = new TableRow();
                TableRow.HorizontalAlign = HorizontalAlign.Right;
                TableRow.Cells.Add(Check);
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
        }
        public void FillFilterDropdowns()
        {
          

            // training and activity area
            List<ListItem> Areas = db.GetAllAreas();
            for (int i = 0; i < Areas.Count; i++)
            {
             
                DropDownListTraining.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string key = ((Button)sender).ID.ToString(); ;
            Session["SelectedVolunteer"] = key;
            Response.Redirect("VolunteerEditInfo.aspx", false);
        }
        protected void pass_one(object sender, EventArgs e)
        {
            //string key = ((Button)sender).ID.ToString(); ;
            //Session["SelectedVolunteer"] = key;
            //Response.Redirect("VolunteerEditInfo.aspx", false);
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
                Volunteers = Volunteers.Where(x => x.Volunteer_First_Name.Contains(name) || x.Volunteer_First_Name_Eng.Contains(name) ||
                  x.Volunteer_Last_Name.Contains(name) || x.Volunteer_Last_Name_Eng.Contains(name)).ToList();
            if (!email.Equals(""))
                Volunteers = Volunteers.Where(x => x.Volunteer_Email.Contains(email)).ToList();
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
           
            int traning = DropDownListTraining.SelectedIndex;
            result = Volunteers;
           
            if (traning != 0)
                result = result.FindAll(x => x.Volunteer_prefer_traning_area == traning);

            return result;
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            //רק אחרי סינון למתנדבות ללא הכשרה
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

        protected void pass_all_Click(object sender, EventArgs e)
        {
            List<Models.Volunteer> all_volunteer = db.GetAllVolunteers();
            for( int i=1;i<volunteerTable.Rows.Count;i++)
            {
                TableCell cellCheck = volunteerTable.Rows[i].Cells[0];
                try
                {
                    CheckBox Check = (CheckBox)cellCheck.Controls[0];
                    if(Check.Checked)
                    {
                        TableCell Email = volunteerTable.Rows[i].Cells[4];
                        string VEmail = Email.Text;
                        Models.Volunteer selectedVolunteer = all_volunteer.Find(x => x.Volunteer_Email == VEmail);
                        if(!db.UpdateVolunteerTraning(selectedVolunteer, 2))
                            Response.Write("<script>alert('שגיאה ברישום למסד נתונים'); window.location.href = ''; </script>");
                    }
                }catch(Exception exp)
                {
                    Response.Write("<script>alert('שגיאה ברישום למסד נתונים'); window.location.href = ''; </script>");
                }
              
            }
            Response.Write("<script>alert('העדכון התבצעה בהצלחה'); window.location.href = ''; </script>");
        }
    }
}