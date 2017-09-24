using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace gui.Gui.Workshop
{
    public partial class SchoolWorkshopEditInfo : System.Web.UI.Page
    {

        DB db;
        WorkshopJoin WorkshopToView = new WorkshopJoin();
        SchoolWorkShop schoolWorkshop = new SchoolWorkShop();
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
                PrepareFormCreate.Visible = false;

                finalParticipants.Text = "";
                numOfCompWithEmulator.Text = "";

                //PrePare Form
                RadioButtonListDidPrepareLabel.Visible = false;
                RadioButtonListDidPrepare.Visible = false;
                RadioButtonListProjectOrControlLabel.Visible = false;
                RadioButtonListProjectOrControl.Visible = false;
                RadioButtonListSeniorsLabel.Visible = false;
                RadioButtonListSeniors.Visible = false;
                RadioButtonListShowVideoLabel.Visible = false;
                RadioButtonListShowVideo.Visible = false;
                prepareComments.Text = "";
                PrepareFormReadey.Text = "טופס הכנה עוד לא קיים";

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
                PrepareForm pf = db.getPrePareFormByWorkshopID(int.Parse(WorkShopID.Text));
                if (pf != null && pf.WorkShop_Number_Of_Final_Student!=0)
                {
                    RadioButtonListDidPrepareLabel.Visible = true;
                    RadioButtonListDidPrepare.Visible = true;
                    RadioButtonListProjectOrControlLabel.Visible = true;
                    RadioButtonListProjectOrControl.Visible = true;
                    RadioButtonListSeniorsLabel.Visible = true;
                    RadioButtonListSeniors.Visible = true;
                    RadioButtonListShowVideoLabel.Visible = true;
                    RadioButtonListShowVideo.Visible = true;
                    PrepareFormReadey.Text = "";

                    finalParticipants.Text = pf.WorkShop_Number_Of_Final_Student.ToString();
                    RadioButtonListProjectOrControl.SelectedValue = pf.WorkShop_Is_Projector.ToString();
                    RadioButtonListSeniors.Text = pf.WorkShop_Is_Seniors_Coming.ToString();
                    RadioButtonListDidPrepare.SelectedValue = pf.WorkShop_Did_Preparation.ToString();
                    RadioButtonListShowVideo.Text = pf.WorkShop_Is_Video_possible.ToString();
                    numOfCompWithEmulator.Text = pf.WorkShop_Number_Of_emulator_Computer.ToString();
                    teacherName.Text = pf.WorkShop_Teacher_Name;
                    teacherEmail.Text = pf.WorkShop_Teacher_Email;
                    teacherPhone.Text = pf.WorkShop_Teacher_phone;
                    prepareComments.Text = pf.WorkShop_Comments;
                    WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                }




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
                            date1.Font.Bold = true;
                        break;
                        case 2:
                            WorkShopDate.Text = schoolWorkshop.SchoolWorkShopDate2.ToString();
                           date2.Font.Bold = true;
                        break;
                        case 3:
                            WorkShopDate.Text = schoolWorkshop.SchoolWorkShopDate3.ToString();
                            date3.Font.Bold = true;
                        break;
                    }

                switch (status) // in page_load
                {
                    case 1:
                        WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                        break;
                    case 2:
                        WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                        break;
                    case 3:
                        WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                        break;
                    case 4:
                        WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                        break;
                    case 5:
                        /*  לבדיקת תאריכים*/
                        dateselecting.Visible = true;
                        dateselector.Visible = true;
                        dateselector.CssClass = "select-control";
                        dateselector.Items[1].Text = schoolWorkshop.SchoolWorkShopDate1.ToString();
                        dateselector.Items[2].Text = schoolWorkshop.SchoolWorkShopDate2.ToString();
                        dateselector.Items[3].Text = schoolWorkshop.SchoolWorkShopDate3.ToString();
                        WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
                        break;
                    case 6:
                        /*  להכנה*/ 
                      
                  
                       
                    case 7:
                        WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();
                        break;
                    case 8:
                        WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();
                        break;
                    case 9:
                        WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();
                        break;
                    case 10:
                        WorkShopID.Text = WorkshopToView.WorkShop_ID.ToString();
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
            
        }


        protected void updateStatus_Click(object sender, EventArgs e)
        {
           
            int ID = int.Parse(Session["WorkshopID"].ToString());
            schoolWorkshop = db.GetSchoolWorkshopByID(ID);
            EmailHelper Email = new EmailHelper();
            int status = int.Parse(selectpicker.SelectedValue);
            
            switch (status)
            {
                case 1:
                    // לבדיקת תאריך
                    ErrorMsg(4);


                    break;
                case 2:
                    //לשיבוץ מתנדבות
                    // בדיקה שתאריך נבחר
                    int dateSelected = dateselector.SelectedIndex;
                    if (dateSelected == 0)
                        ErrorMsg(3);
                    else
                    {
                        List<Volunteer> allVolunteer = db.GetAllVolunteers();
                        List<School> allSchool = db.GetAllSchools();
                        School school = allSchool.Find(x => x.School_ID == schoolWorkshop.WorkShop_School_ID) ;
                        allVolunteer=allVolunteer.FindAll(x => x.Volunteer_Area_Activity.Contains(school.School_Area));

                        if (!db.SchoolWorkShopUpdateDate(schoolWorkshop.SchoolWorkShopID, dateSelected)) ErrorMsg(1);
                        if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 1)) ErrorMsg(1);
                        if (!Email.SendInivetsToVolunteers(allVolunteer, school.School_Area, dateselector.SelectedItem.Text))
                        {
                            ErrorMsg(2);
                        }
                        else
                        {
                            Response.Write("<script>alert('איימילים נשלחו למתנדבות באזור'); window.location.href = '';</script>");
                        }

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
                       
                        if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 3)) ErrorMsg(1);
                        else if (!Email.SendAssignComplete(schoolWorkshop)) ErrorMsg(2);
                        else
                        {
                            Response.Write("<script>alert('איימילים נשלחו לבית הספר והמתנדבות הרשומות'); window.location.href = ''; </script>");
                            SetStatusBar(5);
                        }
                    }
                    break;
                case 4:
                    //להכנה
                    db.InsertNewPrePare(ID);
                    if(!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 6)) 
                        ErrorMsg(1);
                    else if(!Email.PrepareMail(schoolWorkshop)) 
                        ErrorMsg(2);
                    else
                    {
                        PrepareFormCreate.Visible = true;
                        Response.Write("<script>alert('נשלח אימייל לבית ספר');  window.location.href = '';</script>");
                        SetStatusBar(6);
                    }
                    break;
                case 5:
                    //לביצוע

                    PrepareForm pf = db.getPrePareFormByWorkshopID(int.Parse(WorkShopID.Text));
                    if (pf != null && pf.WorkShop_Number_Of_Final_Student != 0)
                    {
                        db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 7);
                        SetStatusBar(7);
                    }
                    else
                        ErrorMsg(5);

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

            WorkshopToView = db.GetJoinWorkShopByID(ID);
            WorkShopStatus.Text = WorkshopToView.Status_Description.ToString();
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
            Response.Redirect(Request.RawUrl);
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
                    string str = "על מנת לעבור סטטוס לשיבוץ מתנדבות,צריך לבחור תאריך";
                    Response.Write("<script>alert('" + str + "'); window.location.href = ''; </script>");
                    break;
                case 4:
                    string str1 = "על מנת לעבור סטטוס יש לבחור סטטוס רצוי";
                    Response.Write("<script>alert('" + str1 + "'); window.location.href = ''; </script>");
                    break;
                case 5:
                    string str2 = "על מנת לעבור לסטטוס לביצוע, יש למלא טופס הכנה";
                    Response.Write("<script>alert('" + str2 + "'); window.location.href = ''; </script>");
                    break;

            }

        }

    }
}