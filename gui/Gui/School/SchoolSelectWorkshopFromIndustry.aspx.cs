using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class SchoolSelectWorkshopFromIndustry : System.Web.UI.Page
    {
        List<CompanyWorkshop> CompanyWorkshops = new List<CompanyWorkshop>();
        DB db;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            FillTable();
        }

        protected void FillTable()
        {
            CompanyWorkshops = db.GetAllCompanyWorshops();

            foreach (CompanyWorkshop t in CompanyWorkshops)
            {
                if (t.CompanyWorkShopStatus == 2) // status "assign school"
                {
                    TableRow row = new TableRow();

                    TableCell workshopID = new TableCell();
                    workshopID.Text = t.CompanyWorkShopID.ToString();
                    row.Cells.Add(workshopID);

                    TableCell Date = new TableCell();
                    Date.Text = t.CompanyWorkShopDate;
                    row.Cells.Add(Date);

                    TableCell Address = new TableCell();
                    Address.Text = GetCompanyAddress(t.CompanyID);
                    row.Cells.Add(Address);

                    TableCell companyName = new TableCell();
                    companyName.Text = GetCompanyName(t.CompanyID);
                    row.Cells.Add(companyName);

                    TableCell participantsPossible = new TableCell();
                    participantsPossible.Text = t.WorkShop_Number_Of_StudentPredicted.ToString();
                    row.Cells.Add(participantsPossible);

                    TableCell Edit = new TableCell();
                    Button Editbtn = new Button();
                    Editbtn.Text = "בחירה";
                    Editbtn.CssClass = "btn btn-info";
                    Editbtn.Attributes.Add("WorkshopID", t.CompanyWorkShopID.ToString());
                    Editbtn.Click += new EventHandler(Select_Click);
                    Edit.Controls.Add(Editbtn);
                    row.Cells.Add(Edit);
                    workshopTable.Rows.Add(row);
                }
            }
        }

        private string GetCompanyAddress(int companyID)
        {
            string address;
            List<Company> companies = db.GetAllComapny();
            address = companies.Find(y => y.Company_ID == companyID).Company_Address;
            return address;
        }

        private string GetCompanyName(int companyID)
        {
            string name;
            List<Company> companies = db.GetAllComapny();
            name = companies.Find(y => y.Company_ID == companyID).Company_Name;
            return name;
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            string WorkshopID = selectedButton.Attributes["WorkshopID"].ToString();
            workshopIdLabel.Text = WorkshopID;
        }

        protected void Assign_Click(object sender, EventArgs e)
        {
                
        
        
        //TODO 
          // show school name by serial num
            //Update Companyworkshop BY ID 

            //Update number of studes, comments
        }


        protected void ShowSchool_Click(object sender, EventArgs e)
        {
            List<School> allSchools = db.GetAllSchools();
          
            if (!string.IsNullOrEmpty(schoolSymbol.Text.ToString())) 
            {
                foreach (School currSchool in allSchools)
                {

                    if (currSchool.School_Serial_Number == int.Parse(schoolSymbol.Text.ToString()))
                    {
                        schoolName.Text = currSchool.School_Name;
                        return;

                    }
                    else
                    {
                        schoolName.Text = "";
                    }
                }
            }
           
            
        }
    }
}