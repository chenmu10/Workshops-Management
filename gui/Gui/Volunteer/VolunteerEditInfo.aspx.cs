using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gui.Models;

namespace gui.Gui
{
    // BUG not showing activity area

    public partial class VolunteerEditInfo : System.Web.UI.Page
    {
        List<Volunteer> Volunteers = new List<Volunteer>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        Dictionary<int, string> ListStatus = new Dictionary<int, string>();
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Volunteers = db.GetAllVolunteers();
            Areas = db.GetAreaActivity();
            ListStatus = db.GetVolunteerStatus();
            DisableForm(Page.Controls);
            FillVolInfo();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void FillVolInfo()
        {
          
            if (Session["VolunteerID"] != null)
            {
                Volunteer vol = new Volunteer();
                int ID = int.Parse(Session["VolunteerID"].ToString());
                vol = db.GetVolunteerByID(ID);

                id.Text =vol.Volunteer_ID.ToString();
                status.Text = ListStatus[vol.Volunteer_Practice];
                Firstname.Text =vol.Volunteer_First_Name;
                Lastname.Text = vol.Volunteer_Last_Name;
                Firstnameeng.Text = vol.Volunteer_First_Name_Eng;
                Lastnameeng.Text = vol.Volunteer_Last_Name_Eng;
                Email.Text = vol.Volunteer_Email;
                Phone.Text = vol.Volunteer_phone;
                Employer.Text = vol.Volunteer_Employer;
                DropDownListReference.SelectedValue = vol.Volunteer_Reference; 
                otherRef.Text = vol.Volunteer_Reference;
                DropDownListOccupation.SelectedValue = vol.Volunteer_Occupation; 
                doneWorkshops.Text = vol.Volunteer_Number_Of_Activities.ToString();
                //DropDownListTraining.SelectedValue = Areas[vol.Volunteer_prefer_traning_area];
                Training.Text= Areas[vol.Volunteer_prefer_traning_area]; ;
                // get areas
                string activityAreas = string.Empty;
               
                //List<int> a= vol.Volunteer_Area_Activity;

                //foreach (int VolunteerArea in vol.Volunteer_Area_Activity)
                //{
                //    activityAreas = activityAreas + new ListItem(Areas[VolunteerArea]);
                //    activityAreas = activityAreas + ",";

                //}

                //areasBox.Text = activityAreas;


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

        protected void UpdateStatus_Click(object sender, EventArgs e)
        {
            Volunteer vol = new Volunteer();
            int ID = int.Parse(Session["VolunteerID"].ToString());
            vol = db.GetVolunteerByID(ID);

            if (vol.Volunteer_Practice==1)
            {

                if(db.UpdateVolunteerTraning(vol, 2))
                {
                    status.Text = ListStatus[vol.Volunteer_Practice];
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('נכשל');;</script>");
                }


            }
            else if (vol.Volunteer_Practice == 2)
            {
                if (db.UpdateVolunteerTraning(vol, 3))
                {
                    status.Text = ListStatus[vol.Volunteer_Practice];
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write("<script>alert('נכשל');;</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('סטטוס אחרון');;</script>");

            }

        }
    }
}