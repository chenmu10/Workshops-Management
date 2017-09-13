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
        public enum schoolByType { SchoolInvite, VolunteerInvite, AssignComplete, SchoolPrepare, executeVolunteers, executeSchool,  };
        public static Dictionary<schoolByType, MessageStructure> PREDEFINED_TEMPLATES = new Dictionary<schoolByType, MessageStructure>()
        {
		// Templates for Emails
            { schoolByType.SchoolInvite ,
              new MessageStructure()
              {
              Subject = "סדנא חדשה באזורכם-פרויקט מהממט",
              Body = "<h2> שלום, {0} </h2>" +
                  "\nישנה סדנא חדשה באזורכם. <br><br> \n" +
                  "מעבר לעמוד השיבוץ: {1}" +
                  "<img src='{2}'>"
              }
            },
            { schoolByType.VolunteerInvite,
               new MessageStructure()
               {
                   Subject = "סדנה חדשה באזורך-פרויקט מהממט",
                   Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
               }
            },
            { schoolByType.SchoolPrepare,
               new MessageStructure()
               {Subject = "הכנה לסדנת מהממט",
                   Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
               }
            },
            { schoolByType.AssignComplete,
                new MessageStructure()
                {Subject = "שיבוץ לסדנה הושלם-פרויקט מהממט",
                    Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
                }
            }
        };

        private string fromAddress = "chenitunes@gmail.com";
        private string fromPassword = "mmtproject";
        private string signature = "בברכה,\nפרויקט מהממט, המרכז לחינוך סייבר";
        private MessageStructure emailInfo;
        private SmtpClient smtp;


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
            string sendBody = string.Format(emailInfo.Body, dynamicInfo);

            var mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, "MMT");
            mail.To.Add(new MailAddress(toAddress));
            mail.Subject = emailInfo.Subject;
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