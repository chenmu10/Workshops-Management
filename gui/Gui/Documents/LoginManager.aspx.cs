using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Documents
{
    public partial class LoginManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msg.Text = "";
            logouwButton.Visible = false;
            if (Session["Manager"] != null)
            {             
                string key = Session["Manager"].ToString();
                if (key.Equals("bxvkeqayl6pwtro97k21"))
                {
                    username.Visible = false;
                    password.Visible = false;
                    submitButton.Visible = false;
                    usernameLabel.Visible = false;
                    passwordLabel.Visible = false;
                    logouwButton.Visible = true;
                    msg.Text = "משתמש מחובר";
                }
            }
 
            if (Page.IsPostBack)
            {
                divBox.Style.Clear();
                divBox.Attributes["class"] = "login-box";
            }
            else
            {
                divBox.Style.Clear();
                divBox.Attributes["class"] = "login-box animated fadeInUp";
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;

            try
            {
                if (user.Equals("mmt") && pass.Equals("mmt")) 
                {
                    msg.Text = "";
                    Response.Redirect("../Documents/Manager_Home.aspx", false);
                    Session["Manager"] = "bxvkeqayl6pwtro97k21";
                }
                msg.Text = "שם משתמש או סיסמא אינם נכונים";
            }
            catch(Exception exp)
            {
                msg.Text = "שם משתמש או סיסמא אינם נכונים";
            }
        }

        protected void logouwButton_Click(object sender, EventArgs e)
        {
            Session["Manager"] = null;
            Response.Redirect("../Documents/LoginManager.aspx", false);
        }
    }
}