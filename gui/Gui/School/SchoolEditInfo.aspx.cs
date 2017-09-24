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

            if (Session["SchoolID"] != null)
            {
                School school = db.GetSchoolByID(int.Parse(Session["SchoolID"].ToString()));
                Areas = db.GetAreaActivity();


                id.Text = school.School_ID.ToString();
                schoolSymbol.Text = school.School_Serial_Number.ToString() ;
                schoolName.Text =school.School_Name;
                schooladdress.Text = school.School_Address;
                schoolCity.Text =school.School_City ;
                schoolArea.Text = Areas[school.School_Area];
                parking.Text = school.School_Parking_Info;
                computercontact.Text = school.School_Supervisor_Name;
                computercontactphone.Text = school.School_Supervisor_Phone;
                contactname.Text = school.School_Contact_Name;
                contactphone.Text = school.Scool_Contact_Phone ;
                contactemail.Text =school.School_Contact_Email;
                

            }

        }




        public void DisableForm(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = false;
                    ((TextBox)ctrl).CssClass = "form-control disabled";
                }

                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).Enabled = false;
                    ((DropDownList)ctrl).CssClass = "form-control disabled";
                }
                //else if (ctrl is CheckBox)
                //{
                //    ((CheckBox)ctrl).Enabled = false;
                //    ((CheckBox)ctrl).CssClass = "form-control disabled";
                //}

                else if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).Enabled = false;
                }


                DisableForm(ctrl.Controls);
            }
        }



    }
}