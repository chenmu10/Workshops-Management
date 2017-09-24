using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class SchoolsView : System.Web.UI.Page
    {
        List<School> Schools = new List<School>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        Dictionary<int, string> ListStatus = new Dictionary<int, string>();
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            DB db = new DB();
            db.IsConnect();
            Schools = db.GetAllSchools();
            Areas = db.GetAreaActivity();
            ListStatus = db.GetVolunteerStatus();
            foreach (School School in Schools)
            {
                TableCell id = new TableCell();
                id.Text = School.School_ID.ToString();
               

                TableCell Name = new TableCell();
                Name.Text = School.School_Name;

                //TableCell Symbol = new TableCell();
                //Symbol.Text = School.School_Serial_Number.ToString(); ;

                TableCell Area = new TableCell();
                Area.Text = Areas[School.School_Area];

                TableCell Address = new TableCell();
                Address.Text = School.School_Address;

                TableCell ContectName = new TableCell();
                ContectName.Text = School.School_Contact_Name;

                TableCell ContectEmail = new TableCell();
                ContectEmail.Text = School.School_Contact_Email;

                TableCell ContectPhone = new TableCell();
                ContectPhone.Text = School.Scool_Contact_Phone;

                TableCell Edit = new TableCell();
                Button Editbtn = new Button();
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Editbtn.Attributes.Add("SchoolID", School.School_ID.ToString());
         
                Editbtn.Click += new EventHandler(MoreInfo_button);
                Edit.Controls.Add(Editbtn);

                TableRow TableRow = new TableRow();
          
                TableRow.Cells.Add(id);
                TableRow.Cells.Add(Name);
                //TableRow.Cells.Add(Symbol);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(Address);
                TableRow.Cells.Add(ContectName);
                TableRow.Cells.Add(ContectPhone);
                TableRow.Cells.Add(ContectEmail);

                TableRow.Cells.Add(Edit);

                ScoolsTable.Rows.Add(TableRow);
            }
        }

        protected void MoreInfo_button(object sender, EventArgs e)
        {
            
            //int btnID = int.Parse(((Button)sender).ID);
            //School SelectedSchool = Schools.Find(x => x.School_ID == btnID);
            //Session["SelectedSchool"] = btnID;
            //Response.Redirect("SchoolEditInfo.aspx", false);


            Button selectedButton = (Button)sender;
            string SelectedSchool = selectedButton.Attributes["SchoolID"].ToString();
            Session["SchoolID"] = SelectedSchool;
            Response.Redirect("SchoolEditInfo.aspx", false);
        }

     


        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
    }
}