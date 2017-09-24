using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using gui.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace gui.Gui
{
    public partial class Manager_Home : System.Web.UI.Page
    {
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            InitializeForm();
            //EmailHelper.MakeAppointment(new List<string>() { "chenmu10@gmail.com" }, "Tel Aviv", new DateTime(2017, 09, 27, 10, 00, 0), new DateTime(2017, 09, 27, 13, 00, 0));
            


        }

        private void InitializeForm()
        {
            db = new DB();
            db.IsConnect();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

    
        }

       
    }
}