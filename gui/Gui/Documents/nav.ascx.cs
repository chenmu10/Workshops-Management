using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Documents
{
    public partial class nav : System.Web.UI.UserControl
    {
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            DB db;
            db = new DB();
            db.IsConnect();
            if (db.IsManager(Session["Manager"]))
            {
                volunter.Visible = false;
                company.Visible = false;
                school.Visible = false;
                workshop.Visible = false;
                forms.Visible = false;
                shobech.Visible = false;
                manager.Visible = true;
                ManagerLink1.Visible = true;
                reports.Visible = true;
                EmailTampL.Visible = true;
            }
            else
            { //to be shore
                volunter.Visible = true;
                company.Visible = true;
                school.Visible = true;
                workshop.Visible = true;
                forms.Visible = true;
                shobech.Visible = true;
                manager.Visible = true;
                EmailTampL.Visible = false;
            }
                

                
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Documents/Manager_Home.aspx", false);
        }

        protected void VolunteerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Volunteer/VolunteerView.aspx", false);
        }

        protected void SchoolBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../School/SchoolsView.aspx", false);
        }

        protected void WorkShopsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Workshop/WorkshopsView.aspx", false);
        }

        protected void RepotsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Documents/ExternalForms.aspx", false);
        }
        protected void CompanyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Company/CompanyView.aspx", false);
        }
    }
}