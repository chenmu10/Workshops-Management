using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace gui.Gui.Volunteer
{
    /// <summary>
    /// Summary description for VolunteerHandler
    /// </summary>
    public class VolunteerHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DB db = new DB();
            db.IsConnect();
            List<Models.Volunteer> allVOl = db.GetAllVolunteers();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = context.Request["term"] ?? "";
            List<string> Names = new List<string>();
            allVOl = allVOl.Where(x => x.Volunteer_Email.ToUpper().StartsWith(str.ToUpper()) && x.Volunteer_Practice!=1).ToList();

            foreach (Models.Volunteer v in allVOl)
            {
                Names.Add(v.Volunteer_Email);
            }
           
            context.Response.ContentType = "text/plain";

            context.Response.Write(js.Serialize(Names));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}