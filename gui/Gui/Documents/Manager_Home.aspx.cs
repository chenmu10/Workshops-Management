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
        public List<string> results = new List<string>();

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            InitializeForm();
        }

        private void InitializeForm()
        {
            db = new DB();
            db.IsConnect();

            results = db.getManagerDashBoard();
            newSchoolWorkshops.Text = results[0];
            newCompanyWorkshops.Text = results[1];
            assignVolunteers.Text = results[2];
            prepare.Text = results[3];
            execute.Text = results[4];
            feedback.Text = results[5];
            closed.Text = results[6];
            newVolunteers.Text = results[7];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (db.IsManager(Session["Manager"]))
            //    user.Text = "משתמש:מנהל";
        }



    }
}