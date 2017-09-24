using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerEditInfo : System.Web.UI.Page
    {
        DB db;
        int VolunteerID;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();

            if (Page.IsPostBack)
            {
                string str = "test";
                update_Click();
            }
                

            if (Session["SelectedVolunteer"] !=null)
            {
                string key = Session["SelectedVolunteer"].ToString();
                try
                {
                    if(key.EndsWith("s"))
                    {
                        key = key.Remove(key.Length - 1);
                        VolunteerID = int.Parse(key);
                        FillForm(VolunteerID);
                    }
                    else
                    {
                        VolunteerID = int.Parse(key);
                        FillForm(VolunteerID);
                        DisableForm(Page.Controls);
                    }
                    
                }
                catch(Exception exp)
                {

                }
            }
            
        }

        public void DisableForm(ControlCollection ctrls)
        {
            CheckBoxListAreas.Enabled = false;
            update.Visible = false;
            statuschange.Visible = false;
            statuschangeLabel.Visible = false;
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
                else if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).Enabled = false;
                }
                    
                
                DisableForm(ctrl.Controls);
            }
        }
        public void FillForm(int ID)
        {
            try
            {
                List<Volunteer> allVolunteer = new List<Volunteer>();
                allVolunteer = db.GetAllVolunteers();
                Volunteer selectVolunteer = allVolunteer.Find(x => x.Volunteer_ID == ID);
                List<ListItem> Areas = db.GetAllAreas();
                List<string> statuses = db.getallStatus();

                // Fill information
                Firstname.Text = selectVolunteer.Volunteer_First_Name.ToString();
                Lastname.Text = selectVolunteer.Volunteer_Last_Name.ToString();
                Firstnameeng.Text = selectVolunteer.Volunteer_First_Name_Eng.ToString();
                Lastnameeng.Text = selectVolunteer.Volunteer_Last_Name_Eng.ToString();
                Email.Text = selectVolunteer.Volunteer_Email.ToString();
                Phone.Text = selectVolunteer.Volunteer_phone.ToString();
                DropDownListOccupation.SelectedValue = selectVolunteer.Volunteer_Occupation;
                Employer.Text = selectVolunteer.Volunteer_Employer.ToString();
                DropDownListReference.SelectedValue = selectVolunteer.Volunteer_Reference;
                Status.Text = statuses[selectVolunteer.Volunteer_Practice-1].ToString();
                doneWorkshops.Text = selectVolunteer.Volunteer_Number_Of_Activities.ToString();
                CheckBoxListAreas.Items.Clear();
                DropDownListTraining.Items.Clear();
                for (int i=0;i<Areas.Count;i++)
                {
                    CheckBoxListAreas.Items.Add(Areas[i]);

                    DropDownListTraining.Items.Add(new ListItem( Areas[i].Text,i.ToString()));

                    if (selectVolunteer.Volunteer_Area_Activity.Contains(i+1))
                        CheckBoxListAreas.Items[i].Selected = true;
                    if (selectVolunteer.Volunteer_prefer_traning_area == i)
                       DropDownListTraining.SelectedIndex = i-1;
                }
                statuschange.Items.Clear();
                foreach ( string status in statuses)
                {
                    statuschange.Items.Add(new ListItem(status));
                }
                statuschange.SelectedIndex = selectVolunteer.Volunteer_Practice-1;


            }
            catch (Exception exp)
            {
                return;
            }



        }

        protected void update_Click()
        {
            if (Session["SelectedVolunteer"] != null)
            {
                string key = Session["SelectedVolunteer"].ToString();
                int VolunteerID;
                try
                {
                    if (key.EndsWith("s"))
                    {
                        key = key.Remove(key.Length - 1);
                        VolunteerID = int.Parse(key);
                    }
                    else
                    {
                        VolunteerID = int.Parse(key);
                    }
                    List<Volunteer> allVolunteer = new List<Volunteer>();
                    allVolunteer = db.GetAllVolunteers();
                    Volunteer selectVolunteer = allVolunteer.Find(x => x.Volunteer_ID == VolunteerID);
                    List<ListItem> Areas = db.GetAllAreas();
                    List<string> statuses = db.getallStatus();

                    selectVolunteer.Volunteer_First_Name = Firstname.Text;
                    selectVolunteer.Volunteer_First_Name_Eng = Firstnameeng.Text;
                    selectVolunteer.Volunteer_Last_Name = Lastname.Text;
                    selectVolunteer.Volunteer_Last_Name_Eng = Lastnameeng.Text;
                    selectVolunteer.Volunteer_Email = Email.Text;
                    selectVolunteer.Volunteer_phone = Phone.Text;
                    selectVolunteer.Volunteer_Occupation = DropDownListOccupation.SelectedValue;
                    selectVolunteer.Volunteer_Employer = Employer.Text;
                    selectVolunteer.Volunteer_Reference = DropDownListReference.SelectedValue;
                    selectVolunteer.Volunteer_Area_Activity.Clear();
                    for (int i=0;i< CheckBoxListAreas.Items.Count;i++)
                    {
                        if (CheckBoxListAreas.Items[i].Selected)
                        {
                            selectVolunteer.Volunteer_Area_Activity.Add(i+1);
                        }
                            
                    }
                    selectVolunteer.Volunteer_prefer_traning_area = DropDownListTraining.SelectedIndex+1;
                    selectVolunteer.Volunteer_Practice = statuschange.SelectedIndex+1;

                    if(!db.UpdateVolunteer(selectVolunteer))
                        Response.Write("<script>alert('שגיאה ברישום למסד נתונים'); window.location.href = ''; </script>");
                    if(!db.clearAndUpdateVoulnteerAreaActivity(selectVolunteer))
                        Response.Write("<script>alert('שגיאה ברישום למסד נתונים'); window.location.href = ''; </script>");
                    Response.Write("<script>alert('העדכון התבצע בהצלחה'); window.location.href = ''; </script>");



                }
                catch (Exception exp)
                {

                }
            }
        }
    }
}