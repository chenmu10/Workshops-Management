using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class CompanyView : System.Web.UI.Page
    {
        List<Company> companies = new List<Company>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        DB db;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            companies = db.GetAllComapny();
            Areas = db.GetAreaActivity();
            FillFilterDropdowns();

            foreach (Company company in companies)
            {
                TableCell id = new TableCell();
                id.Text = company.Company_ID.ToString();

                TableCell Name = new TableCell();
                Name.Text = company.Company_Name;

                TableCell Address = new TableCell();
                Address.Text = company.Company_Address;

                TableCell Area = new TableCell();
                Area.Text = Areas[company.Company_Area_Activity];

                TableCell ContectName = new TableCell();
                ContectName.Text = company.Company_Contact_Name;

                TableCell ContectEmail = new TableCell();
                ContectEmail.Text = company.Company_Contact_Email;

                TableCell ContectPhone = new TableCell();
                ContectPhone.Text = company.Company_Contact_phone;

                TableCell Edit = new TableCell();                
                Button Editbtn = new Button();
                Editbtn.ID = company.Company_ID.ToString();
                Editbtn.Click += new EventHandler(MoreInfo_button);
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Edit.Controls.Add(Editbtn);

                TableRow TableRow = new TableRow();
                TableRow.Cells.Add(Name);
                TableRow.Cells.Add(Address);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(ContectName);
                TableRow.Cells.Add(ContectPhone);
                TableRow.Cells.Add(ContectEmail);

                TableRow.Cells.Add(Edit);

                companyTable.Rows.Add(TableRow);
            }
            Sum.Text = "";
            Sum.Text = "כמות : ";
            Sum.Text += string.Format("{0}",companies.Count());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void newComapnyWorkshopBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewCompanyForm.aspx", false);
        }
        public List<Company> Filter_Click_View()
        {
            List<Company> result = db.GetAllComapny();
            

            return result;

        }
        protected void MoreInfo_button(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            try
            {
                int ID = int.Parse(selectedButton.ID);
                Session["SelectedCompany"] = ID;
                Response.Redirect("../Company/CompanyEditInformation.aspx", false);
            }
            catch(Exception exp)
            {
                return;
            }          
        }

        public void FillFilterDropdowns()
        {
            List<ListItem> Areas = db.GetAllAreas();
            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListAreas.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }
    }
}