using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerEditInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO get specific volunteer details
            // if only view- run disabled textboxes:
            DisableForm(Page.Controls);
        }

        public void DisableForm(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = false;
                    ((TextBox)ctrl).CssClass = "form-control disabled";
                }
                             
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).Enabled = false;
                    ((DropDownList)ctrl).CssClass = "form-control disabled";
                }
                //else if (ctrl is CheckBox)
                //{
                //    ((CheckBox)ctrl).Enabled = false;
                //    ((CheckBox)ctrl).CssClass = "form-control disabled";
                //}
                   
                else if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).Enabled = false;
                }
                    
                
                DisableForm(ctrl.Controls);
            }
        }
    }
}