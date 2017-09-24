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
        List<Volunteer> allVolunteer = new List<Volunteer>();
        List<Company> allCompany = new List<Models.Company>();
        Company selectedCompany = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            FormClear();
            init();
        }
        private void init()
        {
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
                studentsPredictedNum.Text = CompanyWorkshop.WorkShop_Number_Of_StudentPredicted.ToString();
                schoolComments.Text = CompanyWorkshop.WorkShop_School_Comment.Equals("") ? "" : CompanyWorkshop.WorkShop_School_Comment;
                companyName.Text = WorkshopToView.Company_Name;
                selectedCompany = allCompany.Find(x => x.Company_ID == CompanyWorkshop.CompanyID);
                address.Text = selectedCompany.Company_Address;
                possibleStudentsNum.Text = CompanyWorkshop.WorkShop_Number_Of_StudentPredicted.ToString();
                companyComments.Text = CompanyWorkshop.CompanyWorkShopComments;
                dateTime.Text = CompanyWorkshop.CompanyWorkShopDate;


                WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();



                WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                WorkShopDate.Text = WorkshopToView.WorkShop_Date.ToString();

                int status = CompanyWorkshop.CompanyWorkShopStatus;
                Volunteer v = new Volunteer();

                if(CompanyWorkshop.CompanyWorkShopVolunteerID1!=0)
                {
                    v = allVolunteer.Find(x => x.Volunteer_ID == CompanyWorkshop.CompanyWorkShopVolunteerID1);
                    VolunteerName1.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                }
                if (CompanyWorkshop.CompanyWorkShopVolunteerID2 != 0)
                {
                    v = allVolunteer.Find(x => x.Volunteer_ID == CompanyWorkshop.CompanyWorkShopVolunteerID2);
                    VolunteerName2.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                }
                if (CompanyWorkshop.CompanyWorkShopVolunteerID3 != 0)
                {
                    v = allVolunteer.Find(x => x.Volunteer_ID == CompanyWorkshop.CompanyWorkShopVolunteerID3);
                    VolunteerName3.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                }


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
                    break;
                case 10:
                    break;
            }
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
            EmailHelper Email = new EmailHelper();
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
                    if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 8)) ErrorMsg(1);
                    Response.Redirect(Request.RawUrl);
                    break;
                case 5:
                    if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 9)) ErrorMsg(1);
                    Response.Redirect(Request.RawUrl);
                    break;
            }
                    //    case 2:
                    //        //לשיבוץ מתנדבות
                    //        // בדיקה שתאריך נבחר
                    //        int dateSelected = dateselector.SelectedIndex;
                    //        if (dateSelected == 0)
                    //            ErrorMsg(3);
                    //        else
                    //        {
                    //            List<Volunteer> allVolunteer = db.GetAllVolunteers();
                    //            List<School> allSchool = db.GetAllSchools();
                    //            School school = allSchool.Find(x => x.School_ID == schoolWorkshop.WorkShop_School_ID);
                    //            allVolunteer = allVolunteer.FindAll(x => x.Volunteer_Area_Activity.Contains(school.School_Area));

                    //            if (!db.SchoolWorkShopUpdateDate(schoolWorkshop.SchoolWorkShopID, dateSelected)) ErrorMsg(1);
                    //            if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 1)) ErrorMsg(1);
                    //            if (!Email.SendInivetsToVolunteers(allVolunteer, school.School_Area, dateselector.SelectedItem.Text))
                    //            {
                    //                ErrorMsg(2);
                    //            }
                    //            else
                    //            {
                    //                Response.Write("<script>alert('איימילים נשלחו למתנדבות באזור'); window.location.href = '';</script>");
                    //            }

                    //            Response.Redirect(Request.RawUrl);
                    //        }
                    //        break;
                    //    case 3:
                    //        // שיבוץ הושלם
                    //        int count = 0;
                    //        if (schoolWorkshop.SchoolWorkShopVolunteerID1 != 0) count++;
                    //        if (schoolWorkshop.SchoolWorkShopVolunteerID2 != 0) count++;
                    //        if (schoolWorkshop.SchoolWorkShopVolunteerID3 != 0) count++;

                    //        if (count != 3)
                    //        {
                    //            volunteerfinishedlabel.Visible = true;
                    //            yesToVolunteerFinished.Visible = true;
                    //            noToVolunteerFinished.Visible = true;
                    //        }


                    //        else
                    //        {

                    //            if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 3)) ErrorMsg(1);
                    //            else if (!Email.SendAssignComplete(schoolWorkshop)) ErrorMsg(2);
                    //            else
                    //            {
                    //                Response.Write("<script>alert('איימילים נשלחו לבית הספר והמתנדבות הרשומות'); window.location.href = ''; </script>");
                    //                SetStatusBar(5);
                    //            }
                    //        }
                    //        break;
                    //    case 4:
                    //        //להכנה
                    //        db.InsertNewPrePare(ID);
                    //        if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 6))
                    //            ErrorMsg(1);
                    //        else if (!Email.PrepareMail(schoolWorkshop))
                    //            ErrorMsg(2);
                    //        else
                    //        {
                    //            PrepareFormCreate.Visible = true;
                    //            Response.Write("<script>alert('נשלח אימייל לבית ספר');  window.location.href = '';</script>");
                    //            SetStatusBar(6);
                    //        }
                    //        break;
                    //    case 5:
                    //        //לביצוע
                    //        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 7);
                    //        SetStatusBar(7);

                    //        break;
                    //    case 6:
                    //        //למישוב
                    //        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 8);
                    //        SetStatusBar(8);
                    //        break;
                    //    case 7:
                    //        //לסגור
                    //        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 9);
                    //        SetStatusBar(9);
                    //        break;

                    //}

                    //WorkshopToView = db.GetJoinWorkShopByID(ID);
                    //WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
            }



        protected void yesToVolunteerFinished_Click(object sender, EventArgs e)
        {
            if (!db.CompanyWorkshopUpdateStatus(CompanyWorkshop.CompanyWorkShopID, 3)) ErrorMsg(1);
            Response.Redirect(Request.RawUrl);
        }

        private void VolunteerInviteEmail() // בקשה להשתבצות מתנדבות
        {
            int volunteerCount = 0;
            List<Volunteer> allVolunteers = db.GetAllVolunteersWithTraining(true);

            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_GENERAL[EmailTemplate.GeneralByType.VolunteerInvite]);

            foreach (Volunteer currentVolunteer in allVolunteers)
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

            }

        }

    }
}