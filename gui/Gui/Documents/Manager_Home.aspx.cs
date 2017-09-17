using gui.Models;

using System;
using System.Collections.Generic;


namespace gui.Gui
{
    public partial class Manager_Home : System.Web.UI.Page
    {
        //List<Workshop> WorkShops = new List<Workshop>();
        DB db;
        //TODO Clander Next+Perv month event
        //TODO Display Workshop info
        //System.Web.UI.Page

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            InitializeForm();
        }

        private void InitializeForm()
        {
            //Start DB Connection
            db = new DB();
            db.IsConnect();
            //Get All WorkShops
            //WorkShops = db.GetallWorkShopsBetweenMonths(DateTime.Now.Year, getValidLastMonth(), getValidNextMonth());
            List<Volunteer> volunteerList = db.gettAllNewVolunteers();
           // VolunteerCounter.Text = volunteerList.Count.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

    
        }

  
    }
}