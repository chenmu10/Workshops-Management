using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class SchoolWorkshopEditInfo : System.Web.UI.Page
    {

        DB db;
        WorkshopJoin WorkshopToView = new WorkshopJoin();
        SchoolWorkShop schoolWorkshop = new SchoolWorkShop();
        List<Volunteer> allVolunteer = new List<Volunteer>();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            if (Page.IsPostBack )
            {
                if(Session["viewmode"]!=null)
                {
                    if (Session["viewmode"].ToString().Equals("1"))
                        MultiView1.ActiveViewIndex = 1;
                }
               
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
                RadioButtonListAnswer_PerWorkshop.Visible = false;
                RadioButtonListStudent_Gmail.Visible = false;
                prepareComments.Text = "";
                PrepareFormReadey.Text = "עוד לא מילאו טופס הכנה";

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



                //***************************************************** change
                setVolunteer();
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
                    RadioButtonListAnswer_PerWorkshop.Visible = true;
                    RadioButtonListStudent_Gmail.Visible = true;
                    PrepareFormReadey.Text = "";

                    finalParticipants.Text = pf.WorkShop_Number_Of_Final_Student.ToString();
                    RadioButtonListProjectOrControl.SelectedValue = pf.WorkShop_Is_Projector.ToString();
                    RadioButtonListSeniors.Text = pf.WorkShop_Is_Seniors_Coming.ToString();
                    RadioButtonListDidPrepare.SelectedValue = pf.WorkShop_Did_Preparation.ToString();
                    RadioButtonListAnswer_PerWorkshop.SelectedValue = pf.Workshop_Is_All_Student_Answer_PerWorkshop.ToString() ;
                    RadioButtonListStudent_Gmail.SelectedValue = pf.Workshop_Is_All_Student_Gmail.ToString();
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

                
              
                if(status!=5)
                {
                    ShowSelectedDate();
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

        private void ShowSelectedDate()
        {
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
                    UpdateWorkshopDate.Visible = true;
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
                    disableForm();
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
                    if(schoolWorkshop.SchoolWorkShopStatus>=7)
                    {
                        ErrorMsg(6);                        
                    }
                    else
                    {
                        resetWorkshop();
                        ErrorMsg(4);
                    }
                        

                    break;
                case 2:

                    status2AssignVolunteers();

                 
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
                    ErrorMsg(7);
                    break;
                case 7:
                    //לסגור
                    db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 9);
                    SetStatusBar(9);
                    break;
                case 9:
                    disableForm();
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
        public void status2AssignVolunteers()
        {
            EmailHelper Email = new EmailHelper();
            //לשיבוץ מתנדבות
            List<Volunteer> allVolunteer = db.GetAllVolunteers();
            List<School> allSchool = db.GetAllSchools();
            School school = allSchool.Find(x => x.School_ID == schoolWorkshop.WorkShop_School_ID);
            allVolunteer = allVolunteer.FindAll(x => x.Volunteer_Area_Activity.Contains(school.School_Area));

            int dateSelected = dateselector.SelectedIndex;

            if (dateSelected == 0)
            {
                ErrorMsg(3);
                return;
            }

            if (!db.SchoolWorkShopUpdatestatus(schoolWorkshop.SchoolWorkShopID, 1)) ErrorMsg(1);
            if (Email.SendInivetsToVolunteers(allVolunteer, school.School_Area, dateselector.SelectedItem.Text))
            {
                //Response.Write("<script>alert('איימילים נשלחו למתנדבות באזור'); window.location.href = '';</script>");

            }
            if (db.SchoolWorkShopUpdateDate(schoolWorkshop.SchoolWorkShopID, dateSelected))
            {
                ShowSelectedDate();
            }
            else
            {
                ErrorMsg(2);
            }


        }
        public void disableForm()
        {
            cancelWorkshop.Visible = false;
            selectpicker.Enabled = false;
            updateStatus.Visible = false;
        }
        public void setVolunteer()
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            allVolunteer = db.GetAllVolunteers();
            List<FeedBack> allFeedBack = db.GetAllFeedBackByWorkshopID(workshopId, false);
            Volunteer v1 = new Volunteer();
            Volunteer v2 = new Volunteer();
            Volunteer v3 = new Volunteer();
            Voluntter1DropDownList.Items.Clear();
            Voluntter2DropDownList.Items.Clear();
            Voluntter3DropDownList.Items.Clear();
            Voluntter1DropDownList.Items.Add(new ListItem("בחרי", "0"));
            Voluntter2DropDownList.Items.Add(new ListItem("בחרי", "0"));
            Voluntter3DropDownList.Items.Add(new ListItem("בחרי", "0"));
            foreach (Volunteer v in allVolunteer)
            {
                Voluntter1DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
                Voluntter2DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
                Voluntter3DropDownList.Items.Add(new ListItem(v.Volunteer_Email, v.Volunteer_ID.ToString()));
            }
            if (schoolWorkshop.SchoolWorkShopVolunteerID1 != 0)
            {
                v1 = allVolunteer.Find(x => x.Volunteer_ID == schoolWorkshop.SchoolWorkShopVolunteerID1);
                Voluntter1DropDownList.Items.FindByValue(v1.Volunteer_ID.ToString()).Selected = true;
                volunteerName1.Text = v1.Volunteer_First_Name + " " + v1.Volunteer_Last_Name;
                string Ride1 = db.getVolunteerSchoolRide(v1.Volunteer_ID, workshopId);
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
            if (schoolWorkshop.SchoolWorkShopVolunteerID2 != 0)
            {
                v2 = allVolunteer.Find(x => x.Volunteer_ID == schoolWorkshop.SchoolWorkShopVolunteerID2);
                Voluntter2DropDownList.Items.FindByValue(v2.Volunteer_ID.ToString()).Selected = true;
                volunteerName2.Text = v2.Volunteer_First_Name + " " + v2.Volunteer_Last_Name;
                volunteer2Ride.Text = db.getVolunteerSchoolRide(v2.Volunteer_ID, workshopId);
                Name2FeedBack.Text = v2.Volunteer_First_Name + " " + v2.Volunteer_Last_Name;
                FeedBack FeedBackTemp = allFeedBack.Find(x => x.WorkShop_Person == v2.Volunteer_ID);
                if (FeedBackTemp != null)
                {
                    if (FeedBackTemp.WorkShop_Is_Teacher_present != 0)
                    {
                        FeedBack2.Font.Bold = true;
                    }
                }
            }
            if (schoolWorkshop.SchoolWorkShopVolunteerID3 != 0)
            {
                v3 = allVolunteer.Find(x => x.Volunteer_ID == schoolWorkshop.SchoolWorkShopVolunteerID3);
                Voluntter3DropDownList.Items.FindByValue(v3.Volunteer_ID.ToString()).Selected = true;
                volunteerName3.Text = v3.Volunteer_First_Name + " " + v3.Volunteer_Last_Name;
                volunteer3Ride.Text = db.getVolunteerSchoolRide(v3.Volunteer_ID, workshopId);
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
            if(schoolWorkshop.WorkShop_AMT_Contact_Name!=null)
            {
                Name4FeedBack.Text = schoolWorkshop.WorkShop_AMT_Contact_Name;
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
                    string str = "על מנת לעבור סטטוס לשיבוץ מתנדבות,צריך לבחור תאריך";
                    Response.Write("<script>alert('" + str + "'); window.location.href = ''; </script>");
                    break;
                case 4:
                    string str1 = "הסדנא אופסה בהצלחה";
                    Response.Write("<script>alert('" + str1 + "'); window.location.href = ''; </script>");
                    break;
                case 5:
                    string str2 = "על מנת לעבור לסטטוס לביצוע, יש למלא טופס הכנה";
                    Response.Write("<script>alert('" + str2 + "'); window.location.href = ''; </script>");
                    break;
                case 6:
                    string str3 = "לא ניתן לאפס סדנא במצב זה";
                    Response.Write("<script>alert('" + str3 + "'); window.location.href = ''; </script>");
                    break;
                case 7:
                    string str4 = "מיילים עם משוב נשלחו למתנדבות ולמורה בבית הספר";
                    Response.Write("<script>alert('" + str4 + "'); window.location.href = ''; </script>");
                    break;
            }

        }
        protected void DateButton_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Session["WorkshopID"].ToString());
            schoolWorkshop = db.GetSchoolWorkshopByID(ID);
            status2AssignVolunteers();
        }
        protected void UpdateWorkshopDate_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Session["WorkshopID"].ToString());
            schoolWorkshop = db.GetSchoolWorkshopByID(ID);

            int dateSelected = dateselector.SelectedIndex;

            if (dateSelected == 0) 
            {
                ErrorMsg(3); 
            }
               
            if (db.SchoolWorkShopUpdateDate(schoolWorkshop.SchoolWorkShopID, dateSelected))
            {
                ShowSelectedDate();
            }
            else
            {
                ErrorMsg(1);
            }
           
        }
        protected void VolunteerClick(object sender, EventArgs e)
        {
            string str = "texo";
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
            Session["viewmode"] = "0";
        }

        protected void Voluntter1DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Volunteer v;
            volunteer1Ride.Text = "";
            allVolunteer = db.GetAllVolunteers();
            volunteerName1.Text = "";
            int ID = Voluntter1DropDownList.SelectedIndex;
            if(ID!=0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                volunteerName1.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
            }
            
        }

        protected void Voluntter2DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Volunteer v;
            allVolunteer = db.GetAllVolunteers();
            volunteerName2.Text = "";
            int ID = Voluntter2DropDownList.SelectedIndex;
            if (ID != 0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                volunteerName2.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                volunteer2Ride.Text = db.getVolunteerSchoolRide(v.Volunteer_ID, workshopId);
            }
        }

        protected void Voluntter3DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["viewmode"] = "1";
            Volunteer v;
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            allVolunteer = db.GetAllVolunteers();
            volunteerName3.Text = "";
            int ID = Voluntter1DropDownList.SelectedIndex;
            if (ID != 0)
            {
                v = allVolunteer.Find(x => x.Volunteer_ID == ID);
                volunteerName3.Text = v.Volunteer_First_Name + " " + v.Volunteer_Last_Name;
                volunteer3Ride.Text = db.getVolunteerSchoolRide(v.Volunteer_ID, workshopId);
            }
        }

        protected void submitVolnteers(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            Volunteer v1, v2, v3;
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

            if (db.updateSchoolWorkshopVolunteer(workshopId, ID1, ID2, ID3, Ride1, Ride2, Ride3))
            {
                updateVolunteerLabel.Visible = true;
            }
        }
        public void resetWorkshop()
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            SchoolWorkShop Workshop = db.GetSchoolWorkshopByID(workshopId);
            db.SchoolWorkShopUpdatestatus(workshopId, 5);
            db.updateSchoolWorkshopVolunteer(workshopId, 0, 0, 0, "", "", "");
            PrepareForm p = new PrepareForm(Workshop.WorkShop_School_ID, workshopId);
            db.UpdatePrepare(p);
        }
        protected void cancelWorkshop_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            // Delete Workshop
            if (db.DeleteSchoolWoshop(workshopId))
                Response.Redirect("../Workshop/WorkshopsView.aspx", false);
            else
                ErrorMsg(1);
        }

        protected void goToSchool_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            schoolWorkshop = db.GetSchoolWorkshopByID(workshopId);
            Session["SchoolID"] = schoolWorkshop.WorkShop_School_ID;
            Response.Redirect("../School/SchoolEditInfo.aspx", false);
        }

        protected void FeedBack4_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            SchoolWorkShop select = db.GetSchoolWorkshopByID(workshopId);
            string url = String.Format("../Documents/FeedbackTeacher.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, false, 0);
            Response.Write("<script>window.open('" + url + "','_blank');</script>");
        }
        protected void FeedBack1_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            SchoolWorkShop select = db.GetSchoolWorkshopByID(workshopId);
            if (select.SchoolWorkShopVolunteerID1 != 0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, false, select.SchoolWorkShopVolunteerID1);
                Response.Write("<script>window.open('" + url + "','_blank');</script>");
            }
        }
        protected void FeedBack2_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            SchoolWorkShop select = db.GetSchoolWorkshopByID(workshopId);
            if (select.SchoolWorkShopVolunteerID2 != 0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, false, select.SchoolWorkShopVolunteerID2);
                Response.Write("<script>window.open('" + url + "','_blank');</script>");
            }
        }

        protected void FeedBack3_Click(object sender, EventArgs e)
        {
            int workshopId = int.Parse(Session["WorkshopID"].ToString());
            SchoolWorkShop select = db.GetSchoolWorkshopByID(workshopId);
            if (select.SchoolWorkShopVolunteerID3 != 0)
            {
                string url = String.Format("../Documents/FeedbackVolunteer.aspx?workshopID={0}&IsCompany={1}&UserID={2}", workshopId, false, select.SchoolWorkShopVolunteerID3);
                Response.Write("<script>window.open('" + url + "','_blank');</script>");
            }
        }
    }
}