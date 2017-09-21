using gui.Models;
using System;
using System.Collections.Generic;

namespace gui.Gui
{
    public partial class Manager_Home : System.Web.UI.Page
    {
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            InitializeForm();
           
         

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