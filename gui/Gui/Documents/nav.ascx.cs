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