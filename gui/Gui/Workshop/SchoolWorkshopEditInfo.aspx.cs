using Google.Maps;
using Google.Maps.StaticMaps;
using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class SchoolWorkshopEditInfo : System.Web.UI.Page
    {
        // TODO get the school area

        DB db;
        WorkshopJoin WorkshopToView = new WorkshopJoin();
        SchoolWorkShop schoolWorkshop = new SchoolWorkShop();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            FormClear();
            if(!Page.IsPostBack)
                init();
        }
        private void init()
        {
            if (Session["IsCompany"] != null && Session["WorkshopID"] != null)
            {
                volunteerfinishedlabel.Visible = false;
                yesToVolunteerFinished.Visible = false;
                noToVolunteerFinished.Visible = false;
                PrepareFormCreate.Visible = false;

                int ID = int.Parse(Session["WorkshopID"].ToString());
                WorkshopToView = db.GetJoinWorkShopByID(ID);
                schoolWorkshop = db.GetSchoolWorkshopByID(ID);
                schoolname.Text = WorkshopToView.School_Name;
                numberofcumputers.Text = schoolWorkshop.SchoolWorkShopComputerCount.ToString();
                studentpredict.Text = schoolWorkshop.SchoolWorkShopStudentCount.ToString();
                comments.Text = schoolWorkshop.SchoolWorkShopComments.ToString();


                if (schoolWorkshop.WorkShop_For_AMT_students)
                    scientificWorkshop.SelectedIndex = 0;
                else
                    scientificWorkshop.SelectedIndex = 1;

                WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();

                WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();

                date1.Text = schoolWorkshop.SchoolWorkShopDate1.ToString();
                date2.Text = schoolWorkshop.SchoolWorkShopDate2.ToString();
                date3.Text = schoolWorkshop.SchoolWorkShopDate3.ToString();

                VolunteerName1.Text = WorkshopToView.Volunteer1_Name;
                VolunteerName2.Text = WorkshopToView.Volunteer2_Name;
                VolunteerName3.Text = WorkshopToView.Volunteer3_Name;
                /* --- volunteer count --*/
                int count = 0;
                if (schoolWorkshop.SchoolWorkShopVolunteerID1 !=0) count++;
                if (schoolWorkshop.SchoolWorkShopVolunteerID2 != 0) count++;
                if (schoolWorkshop.SchoolWorkShopVolunteerID3 != 0) count++;
                volunteercount.Text = count.ToString();
               // volnteercount2.Text = count.ToString();
                /* ---------------------*/

                int status = schoolWorkshop.SchoolWorkShopStatus;
                SetStatusBar(status);
                int dateIndex = int.Parse(schoolWorkshop.SchoolWorkShopSelectedDate.ToString());
                    switch (dateIndex)
                    {
                        case 0:
                            WorkShopDate.Text = "--";
                            break;
                        case 1:
                            WorkShopDate.Text = schoolWorkshop.SchoolWorkShopDate1.ToString();
                        break;
                        case 2:
                            WorkShopDate.Text = schoolWorkshop.SchoolWorkShopDate2.ToString();
                        break;
                        case 3:
                            WorkShopDate.Text = schoolWorkshop.SchoolWorkShopDate3.ToString();
                        break;
                    }

                switch (status)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:

                        break;
                    case 5:
                        /*  לבדיקת תאריכים*/
                        dateselecting.Visible = true;
                        dateselector.Visible = true;
                        dateselector.Items[1].Text = schoolWorkshop.SchoolWorkShopDate1.ToString();
                        dateselector.Items[2].Text = schoolWorkshop.SchoolWorkShopDate2.ToString();
                        dateselector.Items[3].Text = schoolWorkshop.SchoolWorkShopDate3.ToString();

                        break;
                    case 6:
                        /*  להכנה*/ 
                        PrepareForm pf = db.getPrePareFormByWorkshopID(Convert.ToInt32(WorkShopID.Text));
                        finalParticipants.Text = pf.WorkShop_Number_Of_Final_Student.ToString();
                        RadioButtonListProjectOrControl.SelectedValue = pf.WorkShop_Is_Projector.ToString();
                        //WorkShop_Is_Seniors_Coming = pf.WorkShop_Is_Seniors_Coming;
                        //WorkShop_Did_Preparation = pf.WorkShop_Did_Preparation;
                        //WorkShop_Teacher_Name = pf.WorkShop_Teacher_Name;
                        //WorkShop_Teacher_Email = pf.WorkShop_Teacher_Email;
                        //WorkShop_Teacher_phone = pf.WorkShop_Teacher_phone;
                        //WorkShop_Comments = pf.WorkShop_Comments
                        //WorkShop_Is_Video_possible = pf.WorkShop_Is_Video_possible;
                        numOfCompWithEmulator.Text = pf.WorkShop_Number_Of_emulator_Computer.ToString();
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;

                }

            }
        }

        private void SetStatusBar(int status)
        {
            switch(status)
            {
                case 1:
                    selectpicker.SelectedIndex = 2;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "active";
                    bar4.Attributes["class"] = "next";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    bar8.Attributes["class"] = "next";
                    break;
                case 2:
                    break;
                case 3:
                    selectpicker.SelectedIndex = 3;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "active";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    bar8.Attributes["class"] = "next";
                    break;
                case 4:
                    //שיבוץ הושלם
                    selectpicker.SelectedIndex =   3;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "active";
                    bar5.Attributes["class"] = "next";
                    bar6.Attributes["class"] = "next";
                    bar7.Attributes["class"] = "next";
                    bar8.Attributes["class"] = "next";

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
                    bar8.Attributes["class"] = "next";
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
                    bar8.Attributes["class"] = "next";
                    break;
                case 7:
                    selectpicker.SelectedIndex = 5;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "previous visited";
                    bar6.Attributes["class"] = "active";
                    bar7.Attributes["class"] = "next";
                    bar8.Attributes["class"] = "next";
                    break;
                case 8:
                    selectpicker.SelectedIndex = 6;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "previous visited";
                    bar6.Attributes["class"] = "previous visited";
                    bar7.Attributes["class"] = "active";
                    bar8.Attributes["class"] = "next";
                    break;
                case 9:
                    selectpicker.SelectedIndex = 6;
                    bar1.Attributes["class"] = "previous visited";
                    bar2.Attributes["class"] = "previous visited";
                    bar3.Attributes["class"] = "previous visited";
                    bar4.Attributes["class"] = "previous visited";
                    bar5.Attributes["class"] = "previous visited";
                    bar6.Attributes["class"] = "previous visited";
                    bar7.Attributes["class"] = "previous visited";
                    bar8.Attributes["class"] = "active visited ";
                    break;
                case 10:
                    break;
            }
        }

        private void FormClear()
        {
            dateselecting.Visible = false;
            dateselector.Visible = false;
            schoolname.Text = "";
        }


        protected void updateStatus_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Session["WorkshopID"].ToString());
            WorkshopToView = db.GetJoinWorkShopByID(ID);
            schoolWorkshop = db.GetSchoolWorkshopByID(ID);
            int status = int.Parse(selectpicker.SelectedValue);
            switch (status)
            {
                case 1:
                    // לבדיקת תאריך
                    string str1 = "על מנת לעבור סטטוס יש לבחור סטטוס רצוי";
                    Response.Write("<script>alert('" + str1 + "'); window.location.href = ''; </script>");

                    break;
                case 2:
                    //לשיבוץ מתנדבות
                    // בדיקה שתאריך נבחר
                    int dateSelected = dateselector.SelectedIndex;
                    if (dateSelected == 0)
                    {
                        string str = "על מנת לעבור סטטוס לשיבוץ מתנדבות,צריך לבחור תאריך";
                        Response.Write("<script>alert('" + str + "'); window.location.href = ''; </script>");
                    }
                    else
                    {
                        db.SchoolWorkShopUpdateDate(schoolWorkshop.SchoolWorkShopID, dateSelected);
                        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 1);
                        Response.Redirect(Request.RawUrl);
                    }                    
                    break;
                case 3:
                    // שיבוץ הושלם
                    int count = 0;
                    if (schoolWorkshop.SchoolWorkShopVolunteerID1 != 0) count++;
                    if (schoolWorkshop.SchoolWorkShopVolunteerID2 != 0) count++;
                    if (schoolWorkshop.SchoolWorkShopVolunteerID3 != 0) count++;

                    if(count!=3)
                    {
                        volunteerfinishedlabel.Visible = true;
                        yesToVolunteerFinished.Visible = true;
                        noToVolunteerFinished.Visible = true;
                    }
                    else
                    {
                        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 3);
                        Response.Write("<script> window.location.href = ''; </script>");
                    }
                    break;
                case 4:
                    //להכנה
                    db.InsertNewPrePare(ID);
                    db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 6);
                    PrepareFormCreate.Visible = true;
                    Response.Write("<script> window.location.href = ''; </script>");
                    break;
                case 5:
                    //לביצוע
                    db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 7);
                    SetStatusBar(7);
                    break;
                case 6:
                    //למישוב
                    db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 8);
                    SetStatusBar(8);
                    break;
                case 7:
                    //לסגור
                    db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 9);
                    SetStatusBar(9);
                    break;

            }
        }

        protected void prepareForm_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Session["WorkshopID"].ToString());
            string url =string.Format( @"../Workshop/WorkShopPrepareForm.aspx?" + "workshopID={0}&IsCompany={1}", ID, 0);
            Response.Write("<script> window.open('" + url + "','_blank'); </script>");


        }

        protected void yesToVolunteerFinished_Click(object sender, EventArgs e)
        {
            db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 4);
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

        private static string GetStaticMap(string address)
        {
            var map = new StaticMapRequest();
            MapMarkersCollection markers = new MapMarkersCollection();
            //markers.Add(new Location("1600 Amphitheatre Parkway Mountain View, CA 94043"));
            //markers.Add(new Location("בית ספר אלייאנס תל אביב"));
            markers.Add(new Location(address));
            markers[0].Color = System.Drawing.Color.Blue;

            map.Markers = markers;
            map.Size = new System.Drawing.Size(300, 300);
            map.Zoom = 17;
            map.Sensor = false;
            map.Format = GMapsImageFormats.JPG;

            var imgTagSrc = map.ToUri();
            System.Diagnostics.Debug.WriteLine("the URL is : " + imgTagSrc.ToString());
            return imgTagSrc.ToString();
        }



    }
}