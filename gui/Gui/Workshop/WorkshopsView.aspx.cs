using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class WorkshopsView : System.Web.UI.Page
    {
        List<WorkshopJoin> WorkshopsJoin = new List<WorkshopJoin>();
        DB db;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            GetAreasFromDB();
            GetSchoolFromDB();
            GetCompanyFromDB();

            if (db.IsManager(Session["Manager"]))
            {
                expot.Visible = true;
            }

            WorkshopsJoin = db.GetAllWorkshopsByJoin();
           FillTable(WorkshopsJoin);

               
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
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
            List<Models.Company> Companies = db.GetAllComapny();
            if(DropDownListCompany.Items.Count<=1)
            {
                foreach(Models.Company c in Companies)
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
            int index = 0;
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
          
                Editbtn.Click += new EventHandler(MoreInfo_button12);
                Editbtn.ID = (index++).ToString();
                Editbtn.Text = "צפייה";
                Editbtn.Attributes.Add("WorkshopID", t.WorkShop_ID.ToString());
                Editbtn.Attributes.Add("IsCompany", t.Is_company.ToString());
                Editbtn.CssClass = "btn btn-default";

                Edit.Controls.Add(Editbtn);
                row.Cells.Add(Edit);
              
                workshopTable.Rows.Add(row);
            }
            Sum.Text = "";
            Sum.Text = "כמות : ";
            Sum.Text += string.Format("{0}", CompanyWorkshopsJoin.Count().ToString());
        }

        protected void NewComapnyWorkshop_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Workshop/newCompanyWorkshop.aspx", false);
        }
        protected void MoreInfo_button12(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
        
            List < WorkshopJoin > Table = Filter_Click_View();

            WorkshopJoin selectedWorkshop = Table[int.Parse(selectedButton.ID)];
            string IsCompany = selectedWorkshop.Is_company.ToString();
            string WorkshopID = selectedWorkshop.WorkShop_ID.ToString();

            Session["IsCompany"] = IsCompany;
            Session["WorkshopID"] = WorkshopID;


            if (bool.Parse(IsCompany))
            {
                //Response.Write("<script> window.location.href = '../Workshop/CompanyWorkshopEditInfo.aspx'; </script>");
                Response.Redirect("../Workshop/CompanyWorkshopEditInfo.aspx", false);
            }
            else
            {
                Response.Redirect("../Workshop/SchoolWorkshopEditInfo.aspx", false);
            }


        }
        public List<WorkshopJoin> Filter_Click_View()
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

            if (status != 0)
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
            if (!start_date.Equals("") && !end_date.Equals(""))
            {
                //DateBetween 
                DateTime start = TimeReplace(start_date, false);
                DateTime end = TimeReplace(end_date, false);
                DateTime WorkshopDate = DateTime.Now;
                List<WorkshopJoin> removeable = new List<WorkshopJoin>();

                foreach (WorkshopJoin j in result)
                {
                    WorkshopDate = TimeReplace(j.WorkShop_Date, true);
                    if (!(WorkshopDate >= start && WorkshopDate <= end))
                    {
                        // not in between remove from the list
                        removeable.Add(j);
                    }
                }
                foreach (WorkshopJoin j in removeable)
                    result.Remove(j);
            }

            return result;

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
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href = ''; </script>");
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();

            string path = Server.MapPath("..\\..\\Content\\Report.csv");
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                using (System.IO.StreamWriter filewriter = new System.IO.StreamWriter(path, true, Encoding.UTF8))
                {
                    filewriter.WriteLine("Type, status, Date, School, Company, Volunteers Count");
                    List<WorkshopJoin> Data = new List<WorkshopJoin>();
                    int status = DropDownListStatus.SelectedIndex;
                    int type = DropDownListType.SelectedIndex;
                    int area = DropDownListAreas.SelectedIndex;
                    int shcool = DropDownListSchool.SelectedIndex;
                    int company = DropDownListCompany.SelectedIndex;

                    if (status != 0 || type != 0 || area != 0 || shcool!=0 || company!=0)
                    {
                        Data = Filter_Click_View();

                    } // if
                    else
                    {
                        Data = db.GetAllWorkshopsByJoin();
                    }

                    foreach (WorkshopJoin com in Data)
                    {
                        string Type;
                        if (com.Is_company)
                            Type = "בתעשייה";
                        else
                            Type = "בבית ספר";
                       
                        string Vstatus =com.Status_Description.Replace(',', ' ');
                        string Date = com.WorkShop_Date.ToString().Replace(',', ' ');
                        string VSchool = com.School_Name.ToString().Replace(',', ' ');
                        string VCompany = com.Company_Name.ToString().Replace(',', ' ');
                        int count = 0;
                        if (!com.Volunteer1_Name.Equals("")) count++;
                        if (!com.Volunteer2_Name.Equals("")) count++;
                        if (!com.Volunteer3_Name.Equals("")) count++;
                        if (!com.Volunteer4_Name.Equals("")) count++;
                        string str =
                            String.Format("{0},{1},{2},{3},{4}",
                            Type,
                            Vstatus,
                            VSchool,
                            VCompany,
                            count
                            );

                        filewriter.WriteLine(str);
                    }
                }
                System.IO.FileInfo file = new System.IO.FileInfo(path); //get file object as FileInfo
                if (file.Exists) //-- if the file exists on the server
                {
                    Response.Clear(); //set appropriate headers
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/....";
                    Response.WriteFile(file.FullName);
                    Response.End(); //if file does not exist
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
            catch (Exception exp)
            {
            }
        }

    }
}