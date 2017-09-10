using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class NewCompanyForm : System.Web.UI.Page
    {
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();

            GetAreasFromDB();
        }

        public void GetAreasFromDB()
        {
            List<ListItem> Areas = db.GetAllAreas();

            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListArea.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }
        }

        protected void AddCompany(object sender, EventArgs e)
        {
            if (!IsEmptyFields())
            {
                Company newComp = new Company();
                newComp.Company_Name = companyName.Text;
                newComp.Company_Address = companyAddress.Text;
                newComp.Company_Contact_Name = contactname.Text;
                newComp.Company_Contact_phone = contactphone.Text;
                newComp.Company_Contact_Email = contactemail.Text;
                newComp.Company_Area_Activity = Convert.ToInt32(DropDownListArea.SelectedValue);
                // no check if company exists, no check if email exist

                if (db.InsertNewCompany(newComp))
                {
                    Response.Write("<script>alert('חברה נוספה בהצלחה');</script>");
                    ClearForm();
                }
                else
                {
                    Response.Write("<script>alert('שגיאה');</script>");
                }

            }

        }

        private bool IsEmptyFields() //check all fields for empty / null
        {

            if (companyName.Text.Equals("") || companyAddress.Text.Equals("") || contactname.Text.Equals("") ||
                contactphone.Text.Equals("") || contactemail.Text.Equals("") || DropDownListArea.SelectedIndex == 0)
            {
                Response.Write("<script>alert('שדות חובה חסרים');</script>");
                return true;
            }

            else
            {
                return false;
            }

        }

        private void ClearForm()
        {
            companyName.Text = "";
            companyAddress.Text = "";
            contactname.Text = "";
            contactphone.Text = "";
            contactemail.Text = "";
            DropDownListArea.SelectedIndex = 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}