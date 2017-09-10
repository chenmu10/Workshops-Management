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
        public enum Type { SchoolInvite, VolunteerInvite, AssignComplete, SchoolPrepare, executeVolunteers, executeSchool,  };
        public static Dictionary<Type, MessageStructure> PREDEFINED_TEMPLATES = new Dictionary<Type, MessageStructure>()
        {
		// Templates for Emails
            { Type.SchoolInvite ,
              new MessageStructure()
              {
              Subject = "סדנא חדשה באזורכם-פרויקט מהממט",
              Body = "שלום, {0}" +
                  "\nישנה סדנא חדשה באזורכם. \n" +
                  "מעבר לעמוד השיבוץ: {1}"
              }  //blabladfdfdfdfdjhggjhjj
            },
            { Type.VolunteerInvite,
               new MessageStructure()
               {
                   Subject = "סדנה חדשה באזורך-פרויקט מהממט",
                   Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
               }
            },
            { Type.SchoolPrepare,
               new MessageStructure()
               {Subject = "הכנה לסדנת מהממט",
                   Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
               }
            },
            { Type.AssignComplete,
                new MessageStructure()
                {Subject = "שיבוץ לסדנה הושלם-פרויקט מהממט",
                    Body = "Hello {0}\nThere is a workshop near {1}.\n{2}"
                }
            }
        };

        private string fromAddress = "";
        private string fromPassword = "";
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
            smtp.Send(mail);
        }

        public class MessageStructure
        {
            public string Subject;
            public string Body;
        }


    }
}