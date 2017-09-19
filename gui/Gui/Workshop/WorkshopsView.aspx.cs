using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class WorkshopsView : System.Web.UI.Page
    {
        List<WorkshopJoin> WorkshopsJoin = new List<WorkshopJoin>();
        DB db;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();

            GetAreasFromDB();
            GetSchoolFromDB();
            GetCompanyFromDB();

            WorkshopsJoin = db.GetAllWorkshopsByJoin();
            FillTable(WorkshopsJoin);
        }
        public void GetAreasFromDB()
        {
            List<ListItem> Areas = db.GetAllAreas();
            if (DropDownListAreas.Items.Count <= 1)
            {
                for (int i = 0; i < Areas.Count; i++)
                {
                    DropDownListAreas.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
                }
            }
        }
        public void GetSchoolFromDB()
        {
            List<School> Schools = db.GetAllSchools();
            if(DropDownListSchool.Items.Count<=1)
            {
                foreach(School s in Schools)
                {
                    DropDownListSchool.Items.Add(new ListItem(s.School_Name, s.School_ID.ToString()));
                }
            }
        }
        public void GetCompanyFromDB()
        {
            List<Company> Companies = db.GetAllComapny();
            if(DropDownListCompany.Items.Count<=1)
            {
                foreach(Company c in Companies)
                {
                    DropDownListCompany.Items.Add(new ListItem(c.Company_Name, c.Company_ID.ToString()));
                }
            }
        }
        private void FillTable(List<WorkshopJoin> CompanyWorkshopsJoin)
        {


            TableRow Headers =  workshopTable.Rows[0];
            workshopTable.Rows.Clear();
            workshopTable.Rows.Add(Headers);

            /* Company Workshops*/
            foreach (WorkshopJoin t in CompanyWorkshopsJoin)
            {
                TableRow row = new TableRow();

                TableCell id = new TableCell();
                id.CssClass = "alnright";
                id.Text = t.WorkShop_ID;
                row.Cells.Add(id);

                TableCell type = new TableCell();
                type.CssClass = "alnright";
                if (t.Is_company)
                    type.Text = "בתעשייה";
                else
                    type.Text = "בבית ספר";
                row.Cells.Add(type);

                TableCell status = new TableCell();
                
                status.Text = t.Status_Description;
               
 
                 row.Cells.Add(status);

                TableCell Date = new TableCell();
                Date.CssClass = "alnright";
                Date.Text = t.WorkShop_Date;
                row.Cells.Add(Date);

                TableCell School = new TableCell();
                School.CssClass = "alnright";
                School.Text = t.School_Name;
                row.Cells.Add(School);

                TableCell Name = new TableCell();
                Name.CssClass = "alnright";
                Name.Text = t.Company_Name;
                row.Cells.Add(Name);

                int count = 0;
                if (!t.Volunteer1_Name.Equals("")) count++;
                if (!t.Volunteer2_Name.Equals("")) count++;
                if (!t.Volunteer3_Name.Equals("")) count++;
                if (!t.Volunteer4_Name.Equals("")) count++;

                TableCell volcount = new TableCell();
                volcount.CssClass = "alnright";
                volcount.Text = count.ToString(); ;
                row.Cells.Add(volcount);

                TableCell Edit = new TableCell();
                Button Editbtn = new Button();
                Editbtn.Click += MoreInfo_button;
                Editbtn.Text = "צפייה";
                Editbtn.Attributes.Add("WorkshopID", t.WorkShop_ID.ToString());
                Editbtn.Attributes.Add("IsCompany", t.Is_company.ToString());
                Editbtn.CssClass = "btn btn-default";

                Edit.Controls.Add(Editbtn);
                row.Cells.Add(Edit);
              
                workshopTable.Rows.Add(row);
            }

        }

        protected void NewComapnyWorkshop_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Workshop/newCompanyWorkshop.aspx", false);
        }
        protected void MoreInfo_button(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            string IsCompany = selectedButton.Attributes["IsCompany"].ToString();
            string WorkshopID = selectedButton.Attributes["WorkshopID"].ToString();
            Session["IsCompany"] = IsCompany;
            Session["WorkshopID"] = WorkshopID;
            if (bool.Parse(IsCompany))
            {
                Response.Redirect("../Workshop/CompanyWorkshopEditInfo.aspx", false);
            }
            else
            {
                Response.Redirect("../Workshop/SchoolWorkshopEditInfo.aspx", false);
            }


        }
        protected void Filter_Click(object sender, EventArgs e)
        {
            List<WorkshopJoin> result = db.GetAllWorkshopsByJoin();
            List<CompanyWorkshop> companies = db.GetAllCompanyWorshops();
            List<SchoolWorkShop> Schools = db.GetAllSchoolWorkShops();

            int status = DropDownListStatus.SelectedIndex;
            int type = DropDownListType.SelectedIndex;
            int area = DropDownListAreas.SelectedIndex;
            int shcool = DropDownListSchool.SelectedIndex;
            int company = DropDownListCompany.SelectedIndex;
            string start_date = from_Date.Text; //YYYY-MM-DD
            string end_date = to_Date.Text;

            if (status!=0)
            {
                result = result.FindAll(x => x.Status == status);
            }
            if (type != 0)
                result = result.FindAll(x => x.Is_company == (type == 1));
            if (area != 0)
                result = result.FindAll(x => x.Area == area);
            if (shcool != 0)
                result = result.FindAll(x => x.SchoolID == shcool);
            if (company != 0)
                result = result.FindAll(x => x.CompanyID == company);
            if(!start_date.Equals("") && !end_date.Equals(""))
            {
                //DateBetween 
                DateTime start = TimeReplace(start_date,false);
                DateTime end = TimeReplace(end_date, false);
                DateTime WorkshopDate= DateTime.Now;
                List<WorkshopJoin> removeable = new List<WorkshopJoin>();

                foreach (WorkshopJoin j in result)
                {
                    WorkshopDate = TimeReplace(j.WorkShop_Date,true);
                    if(!(WorkshopDate >= start && WorkshopDate <= end))
                    {
                        // not in between remove from the list
                        removeable.Add(j);
                    }
                }
                foreach(WorkshopJoin j in removeable)
                    result.Remove(j);                
            }




                FillTable(result);


        }

        public DateTime TimeReplace(string FullDate,bool shortdate)
        {
            string temp = FullDate;
            string[] date;
            string year ;
            string month;
            string day;
            if (shortdate)
            {
                temp = FullDate.Split(' ')[0];
                date = temp.Split('/');
                year = date[2];
                month = date[1];
                day = date[0];
            }
            else
            {
                date = temp.Split('-');
                year = date[0];
                month = date[1];
                day = date[2];
            }
                
            
            DateTime t = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            return t;



        }
      
    }
}