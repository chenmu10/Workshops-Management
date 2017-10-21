using Google.Apis.Auth.OAuth2;

using Google.Apis.Services;
using Google.Maps;
using Google.Maps.StaticMaps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;

namespace gui.Models
{
    public class EmailHelper
    {
        string fromAddress = "mmt.send@gmail.com"; // temporary - personal email..
        string fromPassword = "mmtproject";
        string TestMail = "chenmu10@gmail.com";
        string EmailTitle = "MMT";
        string ManagerMail = "chenmu10@gmail.com";
        string signature, signature_path, sendBody;
        bool IsTestMode = false;
        SmtpClient smtp;
        DB db;


        // Files path
        // General
        string VolunteerInviteBody;
        string feedbackVolunteer;
        string CancelWorkshop;

        // Company
        string SchoolInviteBody;
        string AssignCompleteCompany;

        // School
        string AssignCompleteSchool;
        string PrepareBody;
        string feedbackTeacher;
   


    /// <summary>
    /// Constractor
    /// </summary>
    public EmailHelper() {

            db = new DB();
            db.IsConnect();
            signature_path = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailMessages/Signature.txt");
            SchoolInviteBody = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailMessages/CompanyWorkshop/SchoolInviteMailBody.txt");
            VolunteerInviteBody = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailMessages/General/VolunteerInviteBody.txt");
            AssignCompleteSchool = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailMessages/SchoolWorkshop/AssignCompleteSchool.txt");
            PrepareBody = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailMessages/SchoolWorkshop/PrepareBody.txt");

           
       
     


    smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, fromPassword),
                Timeout = 20000
            };



        }

        public bool SendInitesToSchools(List<School> allSchools,CompanyWorkshop selectedWorkshop)
        {
            //Variables
            List<Company> allCompany = db.GetAllComapny();
            List<ListItem> Areas = db.GetAllAreas();

            Company company; 
            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, "סדנא חדשה באזורך-פרויקט מהממט");
            foreach (School s in allSchools)
            {
                //Read Files
                sendBody = File.ReadAllText(SchoolInviteBody, Encoding.UTF8);
                signature = File.ReadAllText(signature_path, Encoding.UTF8);

                //Subject & Body information
                string subject = sendBody.Split('%')[0].Replace("\n", "").Replace("\r", "");
                sendBody = sendBody.Split('%')[1];
                company = allCompany.Find(x => x.Company_ID == selectedWorkshop.CompanyID);
                string Area = Areas[company.Company_Area_Activity-1].Text;

            
                //Body information replace by values
                // Replace {0},{1},{2}....
                sendBody = string.Format(sendBody,
                company.Company_Name,
                selectedWorkshop.CompanyWorkShopDate.Split(' ')[0],
                selectedWorkshop.WorkShop_Number_Of_StudentPredicted,
                s.School_Name,
                Area
                );

                mail.Subject = subject;
                sendBody = sendBody.Replace("\n", "<br>");
                mail.Body = sendBody + signature;
                mail.IsBodyHtml = true;
                

                //Try to send mail
                try
                {
                    if(IsTestMode)
                        mail.To.Add(new MailAddress(TestMail));
                    else
                        mail.To.Add(new MailAddress(s.School_Contact_Email));

                    smtp.Send(mail);
                }catch(Exception e)
                {
                    return false;
                }
              
            } // foreach
            return true;
        }

        public bool SendInivetsToVolunteers(List<Volunteer> allVolunteer,int Area_Activity,string Date)
        {
            //Variables
            List<ListItem> Areas = db.GetAllAreas(); // notice index starts in 0 and in db it's 1 (צפון)

            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, EmailTitle);

            foreach (Volunteer v in allVolunteer)
            {
                //Read Files
                sendBody = File.ReadAllText(VolunteerInviteBody, Encoding.UTF8);
                signature = File.ReadAllText(signature_path, Encoding.UTF8);

                //Subject & Body information
                string subject = sendBody.Split('%')[0].Replace("\n", "").Replace("\r", "");
                sendBody = sendBody.Split('%')[1];
                string Area = Areas[Area_Activity-1].Text; // -1 כי אינדקס מערך מתחיל ב-0


                //Body information replace by values
                // Replace {0},{1},{2}....
                sendBody = string.Format(sendBody,
                v.Volunteer_First_Name+" "+v.Volunteer_Last_Name,                
                Area,
                Date
                );

                mail.Subject = subject;
                sendBody = sendBody.Replace("\n", "<br>");
                mail.Body = sendBody + signature;
                mail.IsBodyHtml = true;


                //Try to send mail
                try
                {
                    if (IsTestMode)
                        mail.To.Add(new MailAddress(TestMail));
                    else
                        mail.To.Add(new MailAddress(v.Volunteer_Email));

                    smtp.Send(mail);
                }
                catch (Exception e)
                {
                    return false;
                }

            } // foreach
            return true;
        }

        /// Update all volnteer,school,manger that workshop x is full 
        public bool SendAssignComplete(SchoolWorkShop s)
        {
            List<Volunteer> allVolunteer = db.GetAllVolunteers();
            List<School> allSchool = db.GetAllSchools();
            Volunteer v1 = allVolunteer.Find(x => x.Volunteer_ID == s.SchoolWorkShopVolunteerID1);
            Volunteer v2 = allVolunteer.Find(x => x.Volunteer_ID == s.SchoolWorkShopVolunteerID2);
            Volunteer v3 = allVolunteer.Find(x => x.Volunteer_ID == s.SchoolWorkShopVolunteerID3);
            School selectedSchool = allSchool.Find(x => x.School_ID == s.WorkShop_School_ID);
            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, EmailTitle);
           

            //Read Files
            sendBody = File.ReadAllText(AssignCompleteSchool, Encoding.UTF8);
                signature = File.ReadAllText(signature_path, Encoding.UTF8);

                //Subject & Body information
                string subject = sendBody.Split('%')[0].Replace("\n", "").Replace("\r", "");
                sendBody = sendBody.Split('%')[1];

            string email1 = v1 == null ? "" : v1.Volunteer_Email;
            string email2 = v1 == null ? "" : v2.Volunteer_Email;
            string email3 = v1 == null ? "" : v3.Volunteer_Email;

            string name1 = v1 == null ? "" : v1.Volunteer_First_Name+" "+v1.Volunteer_Last_Name;
            string name2 = v1 == null ? "" : v2.Volunteer_First_Name + " " + v2.Volunteer_Last_Name;
            string name3 = v1 == null ? "" : v3.Volunteer_First_Name + " " + v3.Volunteer_Last_Name;
            string addressAndCity = selectedSchool.School_Address+ " " + selectedSchool.School_City;
            string map = GetStaticMap(addressAndCity);
            string addressForMap = addressAndCity.Replace(" ", "+");
                     

            //Body information replace by values
            // Replace {0},{1},{2}....
            sendBody = string.Format(sendBody,
                    s.getSelectedDate(), 
                    selectedSchool.School_Name,
                    addressAndCity,
                    name1,
                    name2,
                    name3,
                    addressForMap,
                    map
                );

            mail.Subject = subject;
            sendBody = sendBody.Replace("\n", "<br>");
            mail.Body = sendBody + signature;
            mail.IsBodyHtml = true;

            DateTime startTime = Convert.ToDateTime(s.SchoolWorkShopDate1); // רק להגשה- אין בדיקה איזה תאריך נבחר
            DateTime endTime = startTime.AddHours(4);
            //MakeAppointment(new List<string>() { "chenmu10@gmail.com" }, addressAndCity, startTime, endTime);

            //Try to send mail
            try
            {
                if (IsTestMode) {
                    mail.To.Add(new MailAddress(TestMail));
                    //MakeAppointment(new List<string>() { "chenmu10@gmail.com" }, addressAndCity, startTime, endTime);

                }
                   
         
                    else
                {
                    mail.To.Add(new MailAddress(email1));
                    mail.To.Add(new MailAddress(email2));
                    mail.To.Add(new MailAddress(email3));
                    mail.To.Add(new MailAddress(selectedSchool.School_Contact_Email));
                    mail.To.Add(new MailAddress(ManagerMail));
                    
                }
                       

                    smtp.Send(mail);
                }
                catch (Exception e)
                {
                    return false;
                }

            return true;
        }

        public bool PrepareMail(SchoolWorkShop s)
        {
            List<School> allSchool = db.GetAllSchools();
            School selectedSchool = allSchool.Find(x => x.School_ID == s.WorkShop_School_ID);
            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, EmailTitle);

            //Read Files
            sendBody = File.ReadAllText(PrepareBody, Encoding.UTF8);
            signature = File.ReadAllText(signature_path, Encoding.UTF8);

            //Subject & Body information
            string subject = sendBody.Split('%')[0].Replace("\n", "").Replace("\r", "");
            sendBody = sendBody.Split('%')[1];

            //Body information replace by values
            // Replace {0},{1},{2}....
            sendBody = string.Format(sendBody,
                    s.getSelectedDate().Split(' ')[0],
                    selectedSchool.School_Name,
                    selectedSchool.School_Address,
                    s.SchoolWorkShopID
                );

            mail.Subject = subject;
            sendBody = sendBody.Replace("\n", "<br>");
            mail.Body = sendBody + signature;
            mail.IsBodyHtml = true;


            //Try to send mail
            try
            {
                if (IsTestMode)
                    mail.To.Add(new MailAddress(TestMail));
                else
                {
                    mail.To.Add(new MailAddress(selectedSchool.School_Contact_Email));
                    mail.To.Add(new MailAddress(ManagerMail));
                }


                smtp.Send(mail);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public void Test()
        {
            /*    SMTP Test    */




        }
       

        private static string GetStaticMap(string address)
        {
            var map = new StaticMapRequest();
            MapMarkersCollection markers = new MapMarkersCollection();
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

        //public static void MakeAppointment(List<string> emails, string address, DateTime start, DateTime end)
        //{
        //    List<EventAttendee> event_attendees = new List<EventAttendee>();
        //    foreach (string email in emails)
        //    {
        //        EventAttendee attendee = new EventAttendee();
        //        attendee.Email = email;
        //        event_attendees.Add(attendee);
        //    }

        //    Event new_event = new Event();

        //    new_event.Summary = "סדנת מהממט";
        //    //new_event.Description = "מידע על סדנא";
        //    new_event.Location = address;

        //    new_event.Start = new EventDateTime();
        //    //new_event.Start.DateTime = new DateTime(2017, 09, 26, 15, 0, 0);
        //    new_event.Start.DateTime = start;

        //    new_event.End = new EventDateTime();
        //    //new_event.End.DateTime = new DateTime(2017, 09, 26, 15, 30, 0);
        //    new_event.End.DateTime = end;
        //    new_event.Attendees = event_attendees;

        //    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //        new ClientSecrets
        //        {
        //            //mmt.send
        //            ClientId = "757049045443-rn00q79rdiprdv2dgj1kd8652chtk4ud.apps.googleusercontent.com",
        //            ClientSecret = "BLHLOKQewOa_cgycBktWZyzQ",
        //        },
        //        new[] { CalendarService.Scope.Calendar },
        //        "user",
        //        CancellationToken.None).Result;

        //    // Create the service.
        //    var service = new CalendarService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = "Calendar API Sample",
        //    });


        //    EventsResource.InsertRequest request = service.Events.Insert(new_event, "mmt.send@gmail.com");
        //    request.SendNotifications = true;
        //    Event createdEvent = request.Execute();
        //}
    }
}