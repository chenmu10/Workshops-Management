using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Company
{
    public partial class EditInfoForCompan : System.Web.UI.Page
    {
        // TODO get companyID from session
        //      get num of workshops done at company. 

        DB db;
        int CompanyID;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            GetAreasFromDB();
            DisabledEdit();




            if (Session["SelectedCompany"] != null)
            {
                string key = Session["SelectedCompany"].ToString();
                try
                {
                    if (key.EndsWith("s"))
                    {
                        key = key.Remove(key.Length - 1);
                        CompanyID = int.Parse(key);
                        FillForm(CompanyID);
                    }
                    else
                    {
                        CompanyID = int.Parse(key);
                        FillForm(CompanyID);
                        DisabledEdit();
                    }

                }
                catch (Exception exp)
                {

                }

            }
        }
        public void FillForm(int ID)
        {
            List<Models.Company> companies = db.GetAllComapny();
            int SelectedCompanyID = ID;
            Models.Company EditCompany = companies.Find(x => x.Company_ID == SelectedCompanyID);
            companyIDLabel.Text = EditCompany.Company_ID.ToString();


            //companyID.Text = EditCompany.Company_ID.ToString();
            //companyName.Text = EditCompany.Company_Name;
            //companyAddress.Text = EditCompany.Company_Address;
            //int area = EditCompany.Company_Area_Activity;
            //DropDownListArea.SelectedIndex = area - 1;
            //DropDownListArea.BackColor = System.Drawing.Color.Gainsboro;
            //contactname.Text = EditCompany.Company_Contact_Name;
            //contactphone.Text = EditCompany.Company_Contact_phone;
            //contactemail.Text = EditCompany.Company_Contact_Email;
        }
        protected void DisabledEdit()
        {
            //companyID.Enabled = false;
            //companyName.Enabled = false;
            //companyAddress.Enabled = false;
            //DropDownListArea.Enabled = false;
            //contactname.Enabled = false;
            //contactphone.Enabled = false;
            //contactemail.Enabled = false;
            //doneWorkshopsNum.Enabled = false;
        }

        public void GetAreasFromDB()
        {
            List<ListItem> Areas = db.GetAllAreas();

            for (int i = 0; i < Areas.Count; i++)
            {
                //DropDownListArea.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Company/CompanyView.aspx", false);

        }
    }
}