using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerView : System.Web.UI.Page
    {
     
        List<Volunteer> Volunteers = new List<Volunteer>();
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

            Areas = db.GetAreaActivity();
            ListStatus = db.GetVolunteerStatus();
            InsertToVolunterTable();
            FillFilterDropdowns();
        }

        private void InsertToVolunterTable()
        {
            Volunteers = db.GetAllVolunteers();
            foreach (Volunteer volunteer in Volunteers)
            {
                TableCell id = new TableCell();
                id.Text = volunteer.Volunteer_ID.ToString();

                TableCell Name = new TableCell();
                Name.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;

                TableCell Status = new TableCell();
                Status.Text = ListStatus[volunteer.Volunteer_Practice];
             
                TableCell Occupation = new TableCell();
                Occupation.Text = volunteer.Volunteer_Occupation;

                TableCell Email = new TableCell();
                Email.Text = volunteer.Volunteer_Email;

                TableCell Phone = new TableCell();
                Phone.Text = volunteer.Volunteer_phone;

                // Activity Area
                string activityAreas = string.Empty;
                DropDownList DropListAreas = new DropDownList();
                foreach (int VolunterrArea in volunteer.Volunteer_Area_Activity)
                {
                    activityAreas = activityAreas + new ListItem(Areas[VolunterrArea]);
                    activityAreas = activityAreas + ",";
                    DropListAreas.Items.Add(new ListItem(Areas[VolunterrArea]));
                }

                TableCell Area = new TableCell();
             
                //Area.Controls.Add(DropListAreas);
                Area.Text = activityAreas;
                // Area.Text = Areas[volunteer.Volunteer_Area_Activity];

                TableCell ActiviesNumber = new TableCell();
               
                ActiviesNumber.Text = volunteer.Volunteer_Number_Of_Activities.ToString();

                TableCell Edit = new TableCell();
              
                Button Editbtn = new Button();
                Editbtn.ID = volunteer.Volunteer_ID.ToString();
                Editbtn.Click += new EventHandler(Edit_Click);
                Buttons.Add(Editbtn);
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Edit.Controls.Add(Editbtn);

                TableRow TableRow = new TableRow();
             
                TableRow.Cells.Add(id);
                TableRow.Cells.Add(Name);
                TableRow.Cells.Add(Status);
                TableRow.Cells.Add(Occupation);
                TableRow.Cells.Add(Email);
                TableRow.Cells.Add(Phone);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(ActiviesNumber);
                TableRow.Cells.Add(Edit);

                volunteerTable.Rows.Add(TableRow);
            }
        }

        public void FillFilterDropdowns()
        {
            // practice status 
            DropDownListStatus.Items.Add("ללא הכשרה");
            DropDownListStatus.Items.Add("רגילה");
            DropDownListStatus.Items.Add("ותיקה");

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

            EditMode = !EditMode;
            int btnID = int.Parse(((Button)sender).ID);
            Volunteer SelectedVolunteer = Volunteers.Find(x => x.Volunteer_ID == btnID);
            Session["SelectedVolunteer"] = btnID;
            Response.Redirect("VolunteerViewInformation.aspx", false);

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('חיפוש');</script>");
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('פילטר');</script>");
        }

        protected void Approve_Click(object sender, EventArgs e)
        {
            //רק אחרי סינון למתנדבות ללא הכשרה
        }
    }
}