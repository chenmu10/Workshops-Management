using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{

    public partial class CompanyWorkshopEditInfo : System.Web.UI.Page
    {
        DB db;
        WorkshopJoin WorkshopToView = new WorkshopJoin();
        CompanyWorkshop CompanyWorkshop = new CompanyWorkshop();
        List<Models.Volunteer> allVolunteer = new List<Models.Volunteer>();
        List<Models.Company> allCompany = new List<Models.Company>();
        Models.Company selectedCompany = new Models.Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            if (Page.IsPostBack)
            {
                if (Session["viewmode"].ToString().Equals("1"))
                    MultiView1.ActiveViewIndex = 2;
            }
            else
            {
                FormClear();
                init();
            }
        }
        private void init()
        {
            Session["viewmode"] = "0";
            if (Session["IsCompany"] != null && Session["WorkshopID"] != null)
            {


                volunteerfinishedlabel.Visible = false;
                yesToVolunteerFinished.Visible = false;
                noToVolunteerFinished.Visible = false;
                int ID = int.Parse(Session["WorkshopID"].ToString());

                WorkshopToView = db.GetJoinWorkShopByID(ID,1);
                CompanyWorkshop = db.getCompanyWorkshopByID(ID);
                allVolunteer = db.GetAllVolunteers();
                allCompany = db.GetAllComapny();

                schoolname.Text = WorkshopToView.School_Name;
                schoolComments.Text = CompanyWorkshop.WorkShop_School_Comment.Equals("") ? "" : CompanyWorkshop.WorkShop_School_Comment;
                FinalStudentsNum.Text = CompanyWorkshop.WorkShop_Number_Of_Final_Student.Equals(0) ? "" : CompanyWorkshop.WorkShop_Number_Of_Final_Student.ToString();
                

                companyName.Text = WorkshopToView.Company_Name;
                selectedCompany = allCompany.Find(x => x.Company_ID == CompanyWorkshop.CompanyID);
                address.Text = selectedCompany.Company_Address;
                companyComments.Text = CompanyWorkshop.CompanyWorkShopComments;
                dateTime.Text = CompanyWorkshop.CompanyWorkShopDate;
                studentsPredictedNum.Text = CompanyWorkshop.WorkShop_Number_Of_StudentPredicted.ToString();
                WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();



                WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                WorkShopDate.Text = WorkshopToView.WorkShop_Date.ToString();

                int status = CompanyWorkshop.CompanyWorkShopStatus;
                setVolunteer();


                SetStatusBar(status);


            }
        }

        private void SetStatusBar(int status)
        {
            switch (status)
            {
                case 1:
                    selectpicker.SelectedIndex = 1;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "active";
                    bar4.Attributes["class"] = "next";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 2:
                    bar1.Attributes["class"] = "active";
                    bar2.Attributes["class"] = "next";
                    bar3.Attributes["class"] = "next";
                    bar4.Attributes["class"] = "next";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 3:
                    selectpicker.SelectedIndex = 2;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "active";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 4:
                    //שיבוץ הושלם
                    //selectpicker.SelectedIndex = 3;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "active";
                    bar3.Attributes["class"] = "next";
                    bar4.Attributes["class"] = "next";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";

                    break;
                case 5:
                    selectpicker.SelectedIndex = 1;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "active";
                    bar3.Attributes["class"] = "next";
                    bar4.Attributes["class"] = "next";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 6:
                    selectpicker.SelectedIndex = 4;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "active";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 7:
                    selectpicker.SelectedIndex = 3;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "active";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    break;
                case 8:
                    selectpicker.SelectedIndex = 4;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "previous visited";
                    bar6.Attributes["class"] = "active";
                    bar7.Attributes["class"] = "next";
                    break;
                case 9:
                    selectpicker.SelectedIndex = 4;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "previous visited";
                    bar6.Attributes["class"] = "previous visited";
                    bar7.Attributes["class"] = "previous visited";
                    disableForm();
                    break;
                case 10:
                    break;
            }
        }

        private void disableForm()
        {
            selectpicker.Enabled = false;
            Button2.Visible = false;
            backToSchoolAssign.Visible = false;
            cancelWorkshop.Visible = false;
        }

        private void FormClear()
        {
            //dateselecting.Visible = false;
            //dateselector.Visible = false;

        }


        protected void updateStatus_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop = db.getCompanyWorkshopByID(ID);
            int status = int.Parse(selectpicker.SelectedValue);

            switch (status)
            {
                case 1:
                    // לשיבוץ מתנדבות

                    //בדיקה כי קיים כבר בית ספר
                    if(CompanyWorkshop.CompanyWorkShopStatus == 4)
                    {
                        if(!db.CompanyWorkshopUpdateStatus(ID,1)) ErrorMsg(1);
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                        ErrorMsg(3);

                    break;
                case 2:
                    //למתנדבות שובצו

                    int count = 0;
                    if (CompanyWorkshop.CompanyWorkShopVolunteerID1 != 0) count++;
                    if (CompanyWorkshop.CompanyWorkShopVolunteerID2 != 0) count++;
                    if (CompanyWorkshop.CompanyWorkShopVolunteerID3 != 0) count++;

                    if (count != 3)
                    {
                        volunteerfinishedlabel.Visible = true;
                        yesToVolunteerFinished.Visible = true;
                        noToVolunteerFinished.Visible = true;
                        
                    }
                    else
                    {
                        if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 3)) ErrorMsg(1);
                        Response.Redirect(Request.RawUrl);
                        // else if (!Email.SendAssignComplete(CompanyWorkshop)) ErrorMsg(2);
                        //else
                        //{
                        //    Response.Write("<script>alert('איימילים נשלחו לבית הספר והמתנדבות הרשומות'); window.location.href = ''; </script>");
                        //    SetStatusBar(5);
                        //}
                    }
                    break;

                case 3:
                    // לביצוע
                    if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 7)) ErrorMsg(1);
                    Response.Redirect(Request.RawUrl);
                    break;
                case 4:
                    //למישוב
                    if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 8)) ErrorMsg(1);
                    ErrorMsg(5);
                    break;
                case 5:
                    if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 9)) ErrorMsg(1);
                    Response.Redirect(Request.RawUrl);
                    break;
            }
                   
            }



        protected void yesToVolunteerFinished_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            if (!db.CompanyWorkshopUpdateStatus(workshopId, 3)) ErrorMsg(1);
            Response.Redirect(Request.RawUrl);
        }

        private void VolunteerInviteEmail() // בקשה להשתבצות מתנדבות
        {
            int volunteerCount = 0;
            List<Models.Volunteer> allVolunteers = db.GetAllVolunteersWithTraining(true);

            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_GENERAL[EmailTemplate.GeneralByType.VolunteerInvite]);

            foreach (Models.Volunteer currentVolunteer in allVolunteers)
            {
                // TODO get the school area
                //if (currentVolunteer.Volunteer_Area_Activity == selectedSchool.school_activity_area)
                //    {
                //        string volunteerEmail = currentVolunteer.Volunteer_Email;
                //        string volunteertName = currentVolunteer.Volunteer_First_Name;
                //        mail.Send(volunteerEmail, volunteertName, "http://MMT.co.il/volunteerAssign.aspx?area=" , getStaticMap(schoolAddress));
                //        volunteerCount++;
                //    }
                //}

                //Msg.Text = "נשלחו בקשות אל " + volunteerCount + "מתנדבות";

            }
        }

        private void AssignCompleteEmail() // הודעת שיבוץ הושלם
        {
            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_GENERAL[EmailTemplate.GeneralByType.AssignComplete]);
            // צריך לשלוח את הנתונים הבאים לפונקצית המייל:
            //mail.Send(volunteer1Email, volunteer1tName);
            //mail.Send(volunteer2Email, volunteer2tName);
            //mail.Send(volunteer3Email, volunteer3tName);
            //mail.Send(schoolContactEmail, schoolContactName);
        }

        private void PrepareEmail() // להכנה
        {
            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_SCHOOL[EmailTemplate.SchoolByType.SchoolPrepare]);
            //mail.Send(schoolContactEmail, schoolContactName, more..);
        }

        private void ExecuteEmail() // יומיים לפני קיום הסדנא
        {
            EmailTemplate mailToSchool = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_SCHOOL[EmailTemplate.SchoolByType.executeSchool]);
            //mail.Send(schoolContactEmail, schoolContactName, more..);

            EmailTemplate mailToVolunteer = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_SCHOOL[EmailTemplate.SchoolByType.executeVolunteers]);
            //mail.Send(volunteer1Email, volunteer1tName, more..);
        }

        private void FeedBackEmail()
        {
            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_GENERAL[EmailTemplate.GeneralByType.FeedBack]);
            //mail.Send(volunteer1Email, volunteer1tName, more..);
            //mail.Send(volunteer2Email, volunteer2tName, more..);
            //mail.Send(volunteer3Email, volunteer3tName, more..);
            //mail.Send(teacherEmail, teacherName, more..);

        }


        private void CancelWorkshopEmail()
        {
            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_GENERAL[EmailTemplate.GeneralByType.CancelWorkshop]);
            //mail.Send(volunteer1Email, volunteer1tName, workshopDate);
            //mail.Send(volunteer2Email, volunteer2tName, workshopDate);
            //mail.Send(volunteer3Email, volunteer3tName, workshopDate);
            //mail.Send(schoolContactEmail, schoolContactName, workshopDate);

        }
        protected void Voluntter1DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Models.Volunteer v;
            volunteer1Ride.Text = "";
            allVolunteer = db.GetAllVolunteers();
            VolunteerName1.Text = "";
            int ID = Voluntter1DropDownList.SelectedIndex;
            if (ID != 0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                VolunteerName1.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
            }

        }

        protected void Voluntter2DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Models.Volunteer v;
            allVolunteer = db.GetAllVolunteers();
            VolunteerName2.Text = "";
            int ID = Voluntter2DropDownList.SelectedIndex;
            if (ID != 0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                VolunteerName2.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                volunteer2Ride.Text = db.getVolunteerSchoolRide(v.Volunteer_ID, workshopId);
            }
        }

        protected void Voluntter3DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            Models.Volunteer v;
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            allVolunteer = db.GetAllVolunteers();
            VolunteerName3.Text = "";
            int ID = Voluntter3DropDownList.SelectedIndex;
            if (ID != 0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                VolunteerName3.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                volunteer3Ride.Text = db.getVolunteerSchoolRide(v.Volunteer_ID, workshopId);
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }
        protected void submitVolnteers(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Models.Volunteer v1, v2, v3;
            string Ride1 = "", Ride2 = "", Ride3 = "";
            allVolunteer = db.GetAllVolunteers();
            int ID1 = Voluntter1DropDownList.SelectedIndex;
            int ID2 = Voluntter2DropDownList.SelectedIndex;
            int ID3 = Voluntter3DropDownList.SelectedIndex;
            if (ID1 != 0)
            {
                v1 = allVolunteer.Find(x => x.Volunteer_ID == ID1);
                Ride1 = volunteer1Ride.Text;
            }
            if (ID2 != 0)
            {
                v2 = allVolunteer.Find(x => x.Volunteer_ID == ID2);
                Ride2 = volunteer2Ride.Text;
            }
            if (ID3 != 0)
            {
                v3 = allVolunteer.Find(x => x.Volunteer_ID == ID3);
                Ride3 = volunteer3Ride.Text;
            }

            if (db.updateCompanyWorkshopVolunteer(workshopId, ID1, ID2, ID3, Ride1, Ride2, Ride3))
            {
                updateVolunteerLabel.Visible = true;
            }
        }
        public void setVolunteer()
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop selectedWorkshop = db.getCompanyWorkshopByID(workshopId);
            allVolunteer = db.GetAllVolunteers();
            List<FeedBack> allFeedBack = db.GetAllFeedBackByWorkshopID(workshopId,true);
            Models.Volunteer v1 = new Models.Volunteer();
            Models.Volunteer v2 = new Models.Volunteer();
            Models.Volunteer v3 = new Models.Volunteer();
            Voluntter1DropDownList.Items.Clear();
            Voluntter2DropDownList.Items.Clear();
            Voluntter3DropDownList.Items.Clear();
            Voluntter1DropDownList.Items.Add(new ListItem("בחרי", "0"));
            Voluntter2DropDownList.Items.Add(new ListItem("בחרי", "0"));
            Voluntter3DropDownList.Items.Add(new ListItem("בחרי", "0"));
            foreach (Models.Volunteer v in allVolunteer)
            {
                Voluntter1DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
                Voluntter2DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
                Voluntter3DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
            }
            if (selectedWorkshop.CompanyWorkShopVolunteerID1 != 0)
            {
                v1 = allVolunteer.Find(x => x.Volunteer_ID == selectedWorkshop.CompanyWorkShopVolunteerID1);
                Voluntter1DropDownList.Items.FindByValue(v1.Volunteer_ID.ToString()).Selected = true;
                VolunteerName1.Text = v1.Volunteer_First_Name + " " + v1.Volunteer_Last_Name;
                string Ride1 = db.getVolunteerCompanyRide(v1.Volunteer_ID, workshopId);
                volunteer1Ride.Text = Ride1;
                Name1FeedBack.Text = v1.Volunteer_First_Name + " " + v1.Volunteer_Last_Name;
                FeedBack FeedBackTemp = allFeedBack.Find(x => x.WorkShop_Person == v1.Volunteer_ID);
                if (FeedBackTemp != null)
                {
                    if (FeedBackTemp.WorkShop_Is_Teacher_present != 0)
                    {
                        FeedBack1.Font.Bold = true;
                    }
                }
            }
            if (selectedWorkshop.CompanyWorkShopVolunteerID2 != 0)
            {
                v2 = allVolunteer.Find(x => x.Volunteer_ID == selectedWorkshop.CompanyWorkShopVolunteerID2);
                Voluntter2DropDownList.Items.FindByValue(v2.Volunteer_ID.ToString()).Selected = true;
                VolunteerName2.Text = v2.Volunteer_First_Name + " " + v2.Volunteer_Last_Name;
                volunteer2Ride.Text = db.getVolunteerCompanyRide(v2.Volunteer_ID, workshopId);
                Name2FeedBack.Text = v2.Volunteer_First_Name + " " + v2.Volunteer_Last_Name;
                FeedBack FeedBackTemp = allFeedBack.Find(x => x.WorkShop_Person == v2.Volunteer_ID);
                if(FeedBackTemp!=null)
                {
                    if (FeedBackTemp.WorkShop_Is_Teacher_present != 0)
                    {
                        FeedBack2.Font.Bold = true;
                    }
                }
                

            }
            if (selectedWorkshop.CompanyWorkShopVolunteerID3 != 0)
            {
                v3 = allVolunteer.Find(x => x.Volunteer_ID == selectedWorkshop.CompanyWorkShopVolunteerID3);
                Voluntter3DropDownList.Items.FindByValue(v3.Volunteer_ID.ToString()).Selected = true;
                VolunteerName3.Text = v3.Volunteer_First_Name + " " + v3.Volunteer_Last_Name;
                volunteer3Ride.Text = db.getVolunteerCompanyRide(v3.Volunteer_ID, workshopId);
                Name3FeedBack.Text = v3.Volunteer_First_Name + " " + v3.Volunteer_Last_Name;
                FeedBack FeedBackTemp = allFeedBack.Find(x => x.WorkShop_Person == v3.Volunteer_ID);
                if (FeedBackTemp != null)
                {
                    if (FeedBackTemp.WorkShop_Is_Teacher_present != 0)
                    {
                        FeedBack3.Font.Bold = true;
                    }
                }
            }

        }

        public void ErrorMsg(int type)
        {
            switch (type)
            {
                case 1:
                    Response.Write("<script>alert('שגיאה ברישום למסד נתונים'); window.location.href = ''; </script>");
                    break;
                case 2:
                    Response.Write("<script>alert('שגיאה בשליחת איימיל'); window.location.href = ''; </script>");
                    break;
                case 3:
                    string str = "על מנת לעבור סטטוס לשיבוץ מתנדבות,יש לחכות לשיבוץ בית ספר";
                    Response.Write("<script>alert('" + str + "'); window.location.href = ''; </script>");
                    break;
                case 4:
                    string str1 = "על מנת לעבור סטטוס יש לבחור סטטוס רצוי";
                    Response.Write("<script>alert('" + str1 + "'); window.location.href = ''; </script>");
                    break;
                case 5:
                    string str2 = "מיילים עם משוב נשלחו למתנדבות ולמורה בבית הספר";
                    Response.Write("<script>alert('" + str2 + "'); window.location.href = ''; </script>");
                    break;

            }

        }

        protected void cancelWorkshop_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            // Delete Workshop
            if (db.DeleteCompanyWorkshop(workshopId))
                Response.Redirect("../Workshop/WorkshopsView.aspx", false);
            else
                ErrorMsg(1);
        }

        protected void backToSchoolAssign_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            if(db.resetCompany(workshopId))
                Response.Redirect("../Workshop/WorkshopsView.aspx", false);
            else
                ErrorMsg(1);
        }

        protected void goToSchool_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop = db.getCompanyWorkshopByID(workshopId); 
            Session["SchoolID"] = CompanyWorkshop.CompanySchoolID;
            Response.Redirect("../School/SchoolEditInfo.aspx", false);
        }

        protected void FeedBack1_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop select = db.getCompanyWorkshopByID(workshopId);
            if(select.CompanyWorkShopVolunteerID1!=0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, true, select.CompanyWorkShopVolunteerID1);
                Response.Write("<script>window.open('"+ url + "','_blank');</script>");
            }
               
        }
        protected void FeedBack2_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop select = db.getCompanyWorkshopByID(workshopId);
            if (select.CompanyWorkShopVolunteerID2 != 0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, true, select.CompanyWorkShopVolunteerID2);
                Response.Write("<script>window.open('" + url + "','_blank');</script>");
            }
        }

        protected void FeedBack3_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            CompanyWorkshop select = db.getCompanyWorkshopByID(workshopId);
            if (select.CompanyWorkShopVolunteerID3 != 0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, true, select.CompanyWorkShopVolunteerID3);
                Response.Write("<script>window.open('" + url + "','_blank');</script>");
            }
        }
    }
}