using Google.Maps;
using Google.Maps.StaticMaps;
using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.Threading;
using System.Net;

namespace gui.Gui.Workshop
{
    public partial class newCompanyWorkshop : System.Web.UI.Page
    {

        // TODO fix db.insert - problem with dateTime type
        // TODO area activity shows number instead of string when choosing company

        List<Company> Companies = new List<Company>();
        DB db;
        int companyArea;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Companies = db.GetAllComapny();
            GetAllCompaniesToList();
        }

        private void GetAllCompaniesToList()
        {
            if (dropDownCompanyName.Items.Count < 1)
            {
                dropDownCompanyName.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < Companies.Count; i++)
                {
                    dropDownCompanyName.Items.Add(new ListItem(Companies[i].Company_Name, (i + 1).ToString()));
                }

            }
        }

        protected void FillCompanyDetails(object sender, EventArgs e)
        {
            Company selectedComp = Companies[((DropDownList)sender).SelectedIndex - 1];
            companyID.Text = selectedComp.Company_ID.ToString();
            address.Text = selectedComp.Company_Address;
            area.Text = selectedComp.Company_Area_Activity.ToString();
            companyArea = selectedComp.Company_Area_Activity; // needed for email function


        }


        protected void AddWorkshop(object sender, EventArgs e)
        {
            //MakeAppointment();
            if (!IsEmptyFields())
            {
                CompanyWorkshop newcw = new CompanyWorkshop();
                newcw.CompanyWorkShopComments = comments.Text.ToString();
                newcw.CompanyWorkShopDate = calendar.SelectedDate.ToString();
                newcw.WorkShop_Number_Of_StudentPredicted = Convert.ToInt32(PredictedStudentsNum.Text);
                newcw.CompanyID = Convert.ToInt32(companyID.Text);

                // insert not working - problem with dateTime type
                if (db.InsertNewCompanyWorkShop(newcw))
                {
                    Response.Write("<script>alert('הסדנא נוספה בהצלחה. ניתן להוסיף עוד סדנאות עבור החברה הנבחרת');</script>");
                    SendInvitesToSchools();

                    ClearWorkshopDetails();
                }
                else
                {
                    Response.Write("<script>alert('שגיאה ביצירת סדנא');</script>");
                }

            }
        }



        protected void SendInvitesToSchools()
        {
            int countSchools = 0;
            List<School> allSchools = db.GetAllSchools();

            EmailTemplate mail = new EmailTemplate(EmailTemplate.PREDEFINED_TEMPLATES_COMPANY[EmailTemplate.CompanyByType.SchoolInvite]);
            Company selectedComp = Companies[dropDownCompanyName.SelectedIndex - 1];
            companyArea = selectedComp.Company_Area_Activity;

            foreach (School currentSchool in allSchools)
            {
                if (currentSchool.School_Area == companyArea)
                {
                    string schoolEmail = currentSchool.School_Contact_Email;
                    string schoolContactName = currentSchool.School_Contact_Name;
                    string schoolAddress = currentSchool.School_Address + " " + currentSchool.School_City;
                    mail.Send("karinaves1991@gmail.com", schoolContactName, "http://MMT.co.il/schoolAssign.aspx?area=" + companyArea);
                    countSchools++;
                }
            }

            Response.Write("<script>alert('נשלחו מיילים');</script>");
            Msg.Text = "נשלחו מיילים אל " + countSchools + "בתי ספר";

        }

        private void MakeAppointment()
        {
            //NetworkCredential credentials = new NetworkCredential(fromAddress, fromPassword);
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "664988269501-vbi6h41b6gdj9rs9c1ua74th8e26sfub.apps.googleusercontent.com",
                    ClientSecret = "LdNA4Vz16JO5fUkZJyW2G3gh",
                },
                new[] { CalendarService.Scope.Calendar },
                "user",
                CancellationToken.None).Result;

            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                //HttpClientInitializer = credential,
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });


            Event myEvent = new Event
            {
                Summary = "Appointment",
                Location = "Somewhere",
                Start = new EventDateTime()
                {
                    DateTime = new DateTime(2017, 9, 18, 12, 0, 0),
                    TimeZone = "America/Los_Angeles"
                },
                End = new EventDateTime()
                {
                    DateTime = new DateTime(2017, 9, 18, 12, 30, 0),
                    TimeZone = "America/Los_Angeles"
                },
                Recurrence = new String[] {
                    "RRULE:FREQ=WEEKLY;BYDAY=MO"
                },
                GuestsCanInviteOthers = false,
                Attendees = new List<EventAttendee>()
      {
        new EventAttendee() { Email = "karinaves1991@gmail.com"}
      }
            };
            service.Events.Insert(myEvent, "primary").SendNotifications = true;
            Event recurringEvent = service.Events.Insert(myEvent, "primary").Execute();
        }

        private bool IsEmptyFields()
        {
            if (dropDownCompanyName.SelectedIndex == 0)
            {
                Response.Write("<script>alert('לא נבחרה חברה');</script>");
                return true;
            }
            else if (PredictedStudentsNum.Text.Equals("") || hour.Text.Equals("") || minutes.Text.Equals(""))
            {
                Response.Write("<script>alert('שדות חובה חסרים');</script>");
                return true;
            }
            else if (calendar.SelectedDate.Date.ToString().Equals("01/01/0001 00:00:00") || calendar.SelectedDate == null || calendar.SelectedDate == DateTime.Now)
            {
                Response.Write("<script>alert('לא נבחר תאריך');</script>");
                return true;
            }

            else
            {
                return false;
            }

        }

        private void ClearWorkshopDetails()
        {
            PredictedStudentsNum.Text = "";
            hour.Text = "";
            minutes.Text = "";
            comments.Text = "";
            calendar.SelectedDate = DateTime.Now;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calendar_DayRender(object sender,
                         DayRenderEventArgs e)
        {

            if (e.Day.Date.CompareTo(DateTime.Today) < 0 || e.Day.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}
