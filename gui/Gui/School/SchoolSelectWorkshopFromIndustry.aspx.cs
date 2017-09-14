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
        List<School> Schools = new List<School>();
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
            workshopTable.Rows.Clear();
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
            Session["SelectedWorkshopID"] = WorkshopID;
            workshopIdLabel.Text = WorkshopID;
            ClearForm();
        }

        protected void Assign_Click(object sender, EventArgs e)
        {

            string str = "123";
            Schools = db.GetAllSchools();
            //Check Workshop Selected + School Symbol
            if (workshopIdLabel.Text.Equals(""))
            {
                Msg.Text = "לא נבחרה סדנא";
                return;
            }
            if (schoolSymbol.Text.Length < 1)
            {
                Msg.Text = "לא נבחר בית ספר";
                return;
            }

            int sybol;
            try
            {
                sybol = int.Parse(schoolSymbol.Text.ToString());
            }
            catch (Exception exp)
            {
                return;
            }
            List<School> selected = Schools.Where(x => x.School_Serial_Number == sybol).ToList();
            if (selected.Count < 1)
            {
                Msg.Text = "לא נמצא בית ספר תואם";
                return;
            }
            if (finalParticipants.Text.Equals(""))
            {
                Msg.Text = "יש לבחור מספר משתתפים";
                return;
            }

            //Pass all the test update to DB
            string WorkshopID = Session["SelectedWorkshopID"].ToString();
            db.updateCompanyWorkshopSchoolAssign(WorkshopID, selected[0], finalParticipants.Text, comments.Text);

            FillTable();
            Msg.Text = "הסדנא עודכנה בהצלחה";
            return;




        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void ClearForm()
        {
            schoolSymbol.Text = "";
            finalParticipants.Text = "";
            comments.Text = "";
            schoolName.Text = "";
        }

        protected void searchSchool_Click(object sender, EventArgs e)
        {
            Schools = db.GetAllSchools();
            Msg.Text = "";
            if (schoolSymbol.Text.Length < 1)
            {
                ClearForm();
                return;
            }
            int sybol;
            try
            {
                sybol = int.Parse(schoolSymbol.Text.ToString());
            }
            catch (Exception exp)
            {
                Msg.Text = "יש להזין מספרים לסמל בית הספר בלבד";
                return;
            }

            List<School> selected = Schools.Where(x => x.School_Serial_Number == sybol).ToList();
            if (selected.Count < 1)
            {
                Msg.Text = "לא נמצא בית ספר תואם";
                ClearForm();
            }
            else
            {
                schoolName.Text = selected[0].School_Name;
                finalParticipants.Text = "";
                comments.Text = "";
            }
        }
    }
}