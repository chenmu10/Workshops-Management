using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class SchoolEditInfo : System.Web.UI.Page
    {
        DB db;
        Dictionary<int, string> Areas = new Dictionary<int, string>();

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();           
            FillSchoolInfo();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void FillSchoolInfo()
        {

            if (Session["SelectedSchool"] != null)
            {
                School school = db.GetSchoolByID(int.Parse(Session["SelectedSchool"].ToString()));
                Areas = db.GetAreaActivity();
                schoolidText.Text = school.School_ID.ToString();
                schoolSymbolText.Text = school.School_Serial_Number.ToString() ;
                schoolNameText.Text =school.School_Name;
                schooladdressText.Text = school.School_Address;
                schoolCityText.Text =school.School_City ;
                schoolArea.Text = Areas[school.School_Area];
                parkingText.Text = school.School_Parking_Info;
                computercontactText.Text = school.School_Supervisor_Name;
                computercontactphoneText.Text = school.School_Supervisor_Phone;
                contactnameText.Text = school.School_Contact_Name;
                contactphoneText.Text = school.Scool_Contact_Phone ;
                contactemailText.Text =school.School_Contact_Email;               
            }

            if (db.IsManager(Session["Manager"]))
                DisableForm(true);
            else
                DisableForm(false);

        }
        private void DisableForm(bool mode)
        {
            schoolidText.Enabled = mode;
            schoolSymbolText.Enabled = mode;
            schoolNameText.Enabled = mode;
            schooladdressText.Enabled = mode;
            schoolCityText.Enabled = mode;
            parkingText.Enabled = mode;
            computercontactText.Enabled = mode;
            computercontactphoneText.Enabled = mode;
            contactnameText.Enabled = mode;
            contactphoneText.Enabled = mode;
            contactemailText.Enabled = mode;
            UpdateSchoolBtn.Visible = mode;
            DeleteBtn.Visible = mode;
        }

        protected void UpdateSchool_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}