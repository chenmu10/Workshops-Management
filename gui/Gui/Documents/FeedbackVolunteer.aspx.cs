using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Documents
{


        public partial class FeedbackVolunteer : System.Web.UI.Page
        {
            DB db;
            DateTime LastPostRequest;

            override protected void OnInit(EventArgs e)
            {
                LastPostRequest = DateTime.Now;
                this.Load += new System.EventHandler(this.Page_Load);
                db = new DB();
                db.IsConnect();
                if (IsKeysValid())
                    FillWorkshopData();
        }

            protected void Page_Load(object sender, EventArgs e)
            {



                if (Page.IsPostBack && IsFormValid())
                {
                    LastPostRequest = DateTime.Now;

                }


            }

            private void FillWorkshopData()
            {
            string workshopID = Request.QueryString["workshopID"];
            string IsCompany = Request.QueryString["IsCompany"];
            string PersonID = Request.QueryString["UserID"];

            int _workshopID = int.Parse(workshopID);
            bool _IsCompany= bool.Parse(IsCompany);
            int _PersonID =int.Parse(PersonID);

            Volunteer v = db.GetVolunteerByID(_PersonID);
            CompanyWorkshop workshop = db.getCompanyWorkshopByID(_workshopID);
            SchoolWorkShop Sworkshop = db.GetSchoolWorkshopByID(_workshopID);
            if (!(workshop.CompanyWorkShopVolunteerID1 == _PersonID || workshop.CompanyWorkShopVolunteerID2 == _PersonID || workshop.CompanyWorkShopVolunteerID3 == _PersonID ||
                Sworkshop.SchoolWorkShopVolunteerID1 == _PersonID || Sworkshop.SchoolWorkShopVolunteerID2 == _PersonID || Sworkshop.SchoolWorkShopVolunteerID3 == _PersonID
                ))
            {
                ErrorMsg(1);
            }
            List<FeedBack> allfeedBack = db.GetAllFeedBackByWorkshopID(_workshopID, _IsCompany);
            if(_IsCompany)
            {               
                School school = db.GetSchoolByID(workshop.CompanySchoolID);
                Company company = db.getCompanyByID(workshop.CompanyID);
                workshopIDLabel.Text = _workshopID.ToString();                
                schoolNameLabel.Text = school.School_Name;
                companyNameLabel.Text = company.Company_Name;
                addressLabel.Text = school.School_Address;
                dateLabel.Text = workshop.CompanyWorkShopDate;
                if (v != null)
                    volNameLabel.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
            }
            else
            {
                
                School school = db.GetSchoolByID(Sworkshop.WorkShop_School_ID);
                workshopIDLabel.Text = _workshopID.ToString();
                schoolNameLabel.Text = school.School_Name;
                companyNameLabel.Text = "-";
                addressLabel.Text = school.School_Address;
                dateLabel.Text = workshop.CompanyWorkShopDate;
                if (v != null)
                    volNameLabel.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
            }
            FeedBack selected = allfeedBack.Find(x => (x.WorkShop_ID == _workshopID) && (x.WorkShop_Is_Company == _IsCompany) && (x.WorkShop_Person == _PersonID));
            if(selected!=null) // Load FeedBack From DB
            {
                if(selected.WorkShop_Is_Volunteer==true)
                {
                    
                    RadioButtonListteachePresent.SelectedIndex = selected.WorkShop_Is_Teacher_present-1;
                    teacherPresentOther.Text = selected.WorkShop_Is_Teacher_present_Comment;
                    RadioButtonListlistenLevel.SelectedIndex = selected.WorkShop_Level_Of_Listening-1;
                    difficulties.Text = selected.WorkShop_Main_Issues_Difficulties;
                    techProblems.Text = selected.WorkShop_Technical_Faults;
                    comments.Text = selected.WorkShop_General_Comments;

                }

            }
            else // New FeedBack
            {

            }

        }

            private bool IsFormValid()
            {
                if (RadioButtonListteachePresent.SelectedIndex == -1 ||
                    RadioButtonListlistenLevel.SelectedIndex == -1 ||
                    String.IsNullOrWhiteSpace(difficulties.Text) ||
                    String.IsNullOrWhiteSpace(techProblems.Text) ||
                    String.IsNullOrWhiteSpace(comments.Text))
                {
                    msg.Text = "שדות ריקים בטופס";
                    return false;
                }
                else
                {
                    return true;
                }

            }
            

            private void ClearForm()
            {
                difficulties.Text = String.Empty;
                techProblems.Text = String.Empty;
                comments.Text = String.Empty;
                RadioButtonListlistenLevel.SelectedIndex = -1;
                RadioButtonListteachePresent.SelectedIndex = -1;

            }
            private bool IsKeysValid()
        {

            string workshopID = Request.QueryString["workshopID"];
            string IsCompany = Request.QueryString["IsCompany"];
            string PersonID = Request.QueryString["UserID"];
            try
            {
                int.Parse(workshopID);
                bool.Parse(IsCompany);
                int.Parse(PersonID);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        public void ErrorMsg(int type)
        {
            string str;
            switch (type)
            {
               
                case 1:
                    str = "שגיאה במציאת מתנדבת";
                    //Response.Write("<script>alert('"+ str + "'); window.location.href = ''; </script>");
                    Response.Write("<script>alert('" + str + "'); </script>");
                    break;
                case 2:
                    str = "המשוב התקבל בהצלחה";
                    //Response.Write("<script>alert('"+ str + "'); window.location.href = ''; </script>");
                    Response.Write("<script>alert('" + str + "'); </script>");
                    break;

                case 3:
                    str = "שגיאה בהזנת המשוב";
                    //Response.Write("<script>alert('"+ str + "'); window.location.href = ''; </script>");
                    Response.Write("<script>alert('" + str + "'); </script>");
                    break;



            }

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            string workshopID = Request.QueryString["workshopID"];
            string IsCompany = Request.QueryString["IsCompany"];
            string PersonID = Request.QueryString["UserID"];

            if (!IsKeysValid()) return;
            FeedBack f = new FeedBack();
            f.WorkShop_ID = int.Parse(workshopID);
            f.WorkShop_Is_Company = bool.Parse(IsCompany);
            f.WorkShop_Is_Volunteer = true;
            f.WorkShop_Person = int.Parse(PersonID);

            int TeachPresent = RadioButtonListteachePresent.SelectedIndex +1;
            string TeacherPresetCom = teacherPresentOther.Text;
            int Level = RadioButtonListlistenLevel.SelectedIndex+1;
            string MainIsseDiff= difficulties.Text;
            string Technical_Faults = techProblems.Text;
            string General_Comments = comments.Text ;

            f.WorkShop_Is_Teacher_present = TeachPresent;
            f.WorkShop_Is_Teacher_present_Comment = TeacherPresetCom;
            f.WorkShop_Level_Of_Listening = Level;
            f.WorkShop_Main_Issues_Difficulties = MainIsseDiff;
            f.WorkShop_Technical_Faults = Technical_Faults;
            f.WorkShop_General_Comments = General_Comments;
            if (db.UpdateFeedBack(f))
            {
                ErrorMsg(2);
                ClearForm();
            }
                
            else
                ErrorMsg(3);

        }
    }

    }
