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
            companyIDLabel.Enabled = false;
            companyNameLabel.Text = EditCompany.Company_Name.ToString();
            companyAddressLabel.Text = EditCompany.Company_Address.ToString();
            DropDownListAreaLabel.SelectedIndex = EditCompany.Company_Area_Activity - 1;
            contactnameLabel.Text = EditCompany.Company_Contact_Name;
            contactphoneLabel.Text = EditCompany.Company_Contact_phone;
            contactemailLabel.Text = EditCompany.Company_Contact_Email;

        }
        protected void DisabledEdit()
        {
            companyIDLabel.Enabled = false;
            companyNameLabel.Enabled = false;
            companyAddressLabel.Enabled = false;
            DropDownListAreaLabel.Enabled = false;
            contactnameLabel.Enabled = false;
            contactphoneLabel.Enabled = false;
            contactemailLabel.Enabled = false;
            ((DropDownList)DropDownListAreaLabel).CssClass = "form-control disabled";
            Update.Visible = false;
        }
        public void GetAreasFromDB()
        {
            List<ListItem> Areas = db.GetAllAreas();

            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListAreaLabel.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Company/CompanyView.aspx", false);
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Session["SelectedCompany"] != null)
            {
                string key = Session["SelectedCompany"].ToString();
                try
                {
                    if (key.EndsWith("s"))
                    {
                        key = key.Remove(key.Length - 1);
                        CompanyID = int.Parse(key);
                    }
                    else
                    {
                        CompanyID = int.Parse(key);
                    }
                }
                catch (Exception exp)
                {
                    return;
                }
                List<Models.Company> companies = db.GetAllComapny();
                int SelectedCompanyID = CompanyID;
                Models.Company EditCompany = companies.Find(x => x.Company_ID == SelectedCompanyID);
                EditCompany.Company_Name = companyNameLabel.Text;
                EditCompany.Company_Address = companyAddressLabel.Text;
                EditCompany.Company_Contact_Email = contactemailLabel.Text;
                EditCompany.Company_Contact_Name = contactnameLabel.Text;
                EditCompany.Company_Contact_phone = contactphoneLabel.Text;
                EditCompany.Company_Area_Activity = DropDownListAreaLabel.SelectedIndex + 1;


                if (!db.UpdateCompany(EditCompany))
                {
                    Response.Write("<script>alert('בעיה בהכנסה למסד הנתונים');  window.location.href = '';</script>");
                }
                Response.Write("<script>alert('העדכון התבצעה בהצלחה');  window.location.href = '';</script>");

            }
        }

        protected void back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../Company/CompanyView.aspx", false);

        }
    }
}