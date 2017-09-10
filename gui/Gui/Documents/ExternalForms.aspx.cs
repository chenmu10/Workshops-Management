using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class ExternalForms : System.Web.UI.Page
    {
        DB db;
        //TODO Create View For Forms
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
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

  
        protected void WorkShopSchools(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "../Workshop/NewSchoolWorkshop.aspx" + "','_blank')", true);

        }
        protected void RepotsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExternalForms.aspx", false);
        }
        protected void NewVolunteer(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "../Volunteer/NewVolunteerForm.aspx" + "','_blank')", true);
        }
        protected void PrepareForm(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "../Workshop/WorkShopPrepareForm.aspx" + "','_blank')", true);
        }
        protected void SchollComapmyBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "../School/SchoolSelectWorkshopFromIndustry.aspx" + "','_blank')", true);
        }

        protected void VolunteerAssign_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "../Volunteer/VolunteerAssignWorkshops.aspx" + "','_blank')", true);
        }

        protected void FeedbackVolunteer_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "FeedbackVolunteer.aspx" + "','_blank')", true);
        }

        protected void FeedbackTeacher_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + "FeedbackTeacher.aspx" + "','_blank')", true);
        }
    }
}