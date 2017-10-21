using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class NewSchoolForm : System.Web.UI.Page
    {
        List<School> Schools = new List<School>();
        List<ListItem> Areas;

        DB db;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Schools = db.GetAllSchools();
            Areas = db.GetAllAreas();
            InitializeForm();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InitializeForm()
        {
            if (SchoolArea.Items.Count < 1)
            {
                SchoolArea.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < Areas.Count; i++)
                {
                    SchoolArea.Items.Add(new ListItem(Areas[i].Text, (i + 1).ToString()));
                }

            }
        }

        protected void Buttonsend_Click(object sender, EventArgs e)
        {
            if (!IsEmptyFields())
            {
                // school data
                int SchoolSymbol = Convert.ToInt32(schoolSymbol.Text.ToString());
                string SchoolName = schoolname.Text.ToString();
                string SchoolAddress = schooladdress.Text.ToString();
                string SchoolCity = city.Text.ToString();
                int SchoolAreaValue = SchoolArea.SelectedIndex;

                //computer contact
                string ContantComputer = computercontact.Text.ToString();
                string ContantComputerPhone = computercontactphone.Text.ToString();

                // contact data
                string ContactName = contactname.Text.ToString();
                string ContactPhone = contactphone.Text.ToString();
                string ContactEmail = contactemail.Text.ToString();

                School newSchool = new School(0, SchoolSymbol, SchoolName, SchoolAddress, SchoolAreaValue, SchoolCity, ContactName, ContactPhone, ContactEmail, ContantComputer, ContantComputerPhone, "");


                if (db.InsetNewSchool(newSchool))
                {

                    Response.Write("<script>alert('בית ספר חדש נוסף בהצלחה');</script>");
                    Response.Redirect("../Documents/SuccessForm.aspx", false);

                }
                else
                {
                    Response.Write("<script>alert('שגיאה בהכנסה למאגר');</script>");
                }

            }

        }

        protected bool IsEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(schoolSymbol.Text) ||
                 string.IsNullOrWhiteSpace(schoolname.Text) ||
                 string.IsNullOrWhiteSpace(schooladdress.Text) ||
                 string.IsNullOrWhiteSpace(city.Text) ||
                 string.IsNullOrWhiteSpace(contactname.Text) ||
                 string.IsNullOrWhiteSpace(contactphone.Text) ||
                 string.IsNullOrWhiteSpace(contactemail.Text) ||
                 string.IsNullOrWhiteSpace(computercontact.Text) ||
                 string.IsNullOrWhiteSpace(computercontactphone.Text) ||
                 string.IsNullOrWhiteSpace(computercontactphone.Text))
            {
                Response.Write("<script>alert('נא למלא את כל השדות');</script>");
                return true;
            }

            if (SchoolArea.SelectedValue == "")
            {
                Response.Write("<script>alert('נא לבחור אזור');</script>");
                return true;
            }

            return false;
        }



    }
}
