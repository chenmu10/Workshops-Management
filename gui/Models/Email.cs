using Google.Maps;
using Google.Maps.StaticMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace gui.Models
{

    public class EmailTemplate
    {
        private string fromAddress = "chenitunes@gmail.com"; // temporary - personal email..
        private string fromPassword = "mmtproject";
        private string signature = "בברכה,\nפרויקט מהממט, המרכז לחינוך סייבר";
        private MessageStructure emailInfo;
        private SmtpClient smtp;

        public enum GeneralByType { VolunteerInvite, AssignComplete, FeedBack, CancelWorkshop };
        public enum CompanyByType { SchoolInvite, executeVolunteers, executeSchool, executeCompany };
        public enum SchoolByType { SchoolPrepare, executeVolunteers, executeSchool };

        //templates for general workshop emails    
        public static Dictionary<GeneralByType, MessageStructure> PREDEFINED_TEMPLATES_GENERAL = new Dictionary<GeneralByType, MessageStructure>(){
        {GeneralByType.VolunteerInvite, new MessageStructure(){ Subject="סדנה חדשה באזורך-פרויקט מהממט",
                                                                Body="שלום, {0}," + "\n ישנה סדנא חדשה באזורך \n" + "מעבר לעמוד שיבוץ: {1}"
                                                                } } ,
        {GeneralByType.AssignComplete, new MessageStructure() { Subject = "שיבוץ הושלם בסדנא-פרויקט מהממט",
                                                                Body = "שלום, {0}," + "\n השיבוץ לסדנא הושלם. תשלח תזכורת יומיים לפני. "
        } },
        {GeneralByType.FeedBack, new MessageStructure(){ Subject="בקשה למשוב-פרויקט מהממט", Body="Content"} },
        {GeneralByType.CancelWorkshop, new MessageStructure() { Subject = "ביטול סדנא-פרויקט מהממט", Body = "Content"} }
        };

        //templates for SCHOOL workshop emails    
        public static Dictionary<SchoolByType, MessageStructure> PREDEFINED_TEMPLATES_SCHOOL = new Dictionary<SchoolByType, MessageStructure>(){
        {SchoolByType.SchoolPrepare, new MessageStructure(){ Subject="הכנה לסדנא-פרויקט מהממט", Body="Content"} } ,
        {SchoolByType.executeVolunteers, new MessageStructure() { Subject = "הוראות לקראת סדנא-פרויקט מהממט", Body = "Content"} },
        {SchoolByType.executeSchool, new MessageStructure(){ Subject="הוראות לקראת סדנא-פרויקט מהממט", Body="Content"} }
        };

        //templates for COMPANY workshop emails    
        public static Dictionary<CompanyByType, MessageStructure> PREDEFINED_TEMPLATES_COMPANY = new Dictionary<CompanyByType, MessageStructure>(){
        {CompanyByType.SchoolInvite, new MessageStructure(){ Subject="סדנא חדשה בתעשייה באזורכם-פרויקט מהממט",
                                                              Body = "<h2> שלום, {0} </h2>" +
                                                                      "\nישנה סדנא חדשה באזורכם. <br><br> \n" +
                                                                      "מעבר לעמוד השיבוץ: {1}" +
                                                                      "<img src='{2}'>"
                                                                  } } ,
        {CompanyByType.executeVolunteers, new MessageStructure() { Subject = "הוראות לקראת סדנא-פרויקט מהממט", Body = "Content"} },
        {CompanyByType.executeSchool, new MessageStructure() { Subject = "הוראות לקראת סדנא-פרויקט מהממט", Body = "Content"} },
        {CompanyByType.executeCompany, new MessageStructure(){ Subject="הוראות לקראת סדנא-פרויקט מהממט", Body="Content"} }
        };


        public EmailTemplate(MessageStructure emailInfo)
        {
            this.emailInfo = emailInfo;

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

        public void Send(string toAddress, params string[] dynamicInfo)
        {
            string sendBody;

            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, "MMT");
            mail.To.Add(new MailAddress(toAddress));
            mail.Subject = emailInfo.Subject;
            sendBody = string.Format(emailInfo.Body, dynamicInfo);
            mail.Body = sendBody + "\n\n\n" + signature;
            mail.IsBodyHtml = true;
           
            smtp.Send(mail);
        }

        public class MessageStructure
        {
            public string Subject;
            public string Body;
        }

    }
}