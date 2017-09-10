using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class ApproveNewVolunteerForm : System.Web.UI.Page
    {
        // TO DO add call form DB to school id #1# (search #1# to find the place to fix, you can use ctr+f))
        // TO DO check if the volunteer is senior #3#
        // TO DO WorkshopJoin should hold volunteer mail instead of names, after you fix this go to #4# (in 3 places you can use ctr+f)and replace the code in the " /*....*/ "
        // TO DO add VolunterAsiignPlaceHolder.Display = flase when Editbtn is pressed
        List<WorkshopJoin> CompanyWorkshopsJoin = new List<WorkshopJoin>();
        DB db;
        /*override protected void OnInit(EventArgs e)
        {
        
           // WorkShops = db.GetallWorkShopsBetweenMonths(DateTime.Now.Year, getValidLastMonth(), getValidNextMonth());

        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            FillTable();
        }

        private void FillTable()
        {
            CompanyWorkshopsJoin = db.GetAllWorkshopsByJoin();

            foreach (WorkshopJoin t in CompanyWorkshopsJoin)
            {
                if (t.Status_Description.Equals(" לשיבוץ מתנדבות"))
                {
                    TableRow row = new TableRow();

                    TableCell School = new TableCell();
                    School.Text = t.School_Name;
                    row.Cells.Add(School);

                    TableCell Address = new TableCell();
                    getSchoolAddress(int.Parse(t.WorkShop_ID), t.Is_company, School.Text);
                    row.Cells.Add(School);

                    TableCell Date = new TableCell();
                    Date.Text = t.WorkShop_Date;
                    row.Cells.Add(Date);

                    TableCell Name = new TableCell();
                    Name.Text = t.Company_Name;
                    row.Cells.Add(Name);

                    TableCell Assign = new TableCell();
                    Assign.Text = "hello";
                    row.Cells.Add(Assign);

                    TableCell Edit = new TableCell();
                    Button Editbtn = new Button();
                    Editbtn.Attributes.Add("WorkshopID", t.WorkShop_ID.ToString());
                    // TO DO #4#
                    Editbtn.Attributes.Add("Voluntter1", t.Volunteer1_Name);
                    Editbtn.Attributes.Add("Voluntter2", t.Volunteer2_Name);
                    Editbtn.Attributes.Add("Voluntter3", t.Volunteer3_Name);
                    /*
                    Editbtn.Attributes.Add("Voluntter1", t.Volunteer1_Mail);
                    Editbtn.Attributes.Add("Voluntter2", t.Volunteer2_Mail);
                    Editbtn.Attributes.Add("Voluntter3", t.Volunteer3_Mail);
                    */
                    Editbtn.Attributes.Add("IsCompany", t.Is_company.ToString());
                    Editbtn.Click += new EventHandler(worckshopToAssign);
                    Editbtn.Text = "שיבוץ לסדנא";
                    Edit.Controls.Add(Editbtn);
                    row.Cells.Add(Edit);
                    worckshopTable.Rows.Add(row);
                }
            }
        }

        protected void worckshopToAssign(object sender, EventArgs e)
        {

            Button selectedButton = (Button)sender;
            string isCompany = selectedButton.Attributes["IsCompany"];
            string workshopId = selectedButton.Attributes["WorkshopID"];
            string volunteer1 = selectedButton.Attributes["Voluntter1"];
            string volunteer2 = selectedButton.Attributes["Voluntter2"];
            string volunteer3 = selectedButton.Attributes["Voluntter3"];

            if (bool.Parse(isCompany))
            {
                CompanyWorkshop companyWorkshop;
                // TO FIX #2# 
                List<CompanyWorkshop> allCompanyWorkshops = db.GetAllCompanyWorshops();
                foreach (CompanyWorkshop t in allCompanyWorkshops)
                {
                    if (t.CompanyWorkShopID == int.Parse(workshopId))
                    {
                        companyWorkshop = t;
                        break;
                    }
                }

                workshopIdLabel.Text = workshopId;
                InitializeVoluntter1(volunteer1);
                InitializeVoluntter2(volunteer2);
                InitializeVoluntter3(volunteer3);
            }

        }

        public void InitializeVoluntter1(string volunteer1)
        {
            List<ListItem> listItems = new List<ListItem>();
            List<Volunteer> Allvolunteers;
            Allvolunteers = db.GetAllVolunteers();
            //if (Voluntter1DropDownList.Items.Count < 1)
            if (volunteer1.Equals(""))
            {
                Voluntter1DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < Allvolunteers.Count; i++)
                {
                    //TO DO check if the volunteer is senior #3#
                    //if (isSenior && Allvolunteers[i].Volunteers_Practice == 3)
                    {
                        listItems.Add(new ListItem(Allvolunteers[i].Volunteer_Email));
                        Voluntter1DropDownList.Items.Add(new ListItem(listItems[i].Text, (i + 1).ToString()));
                    }
                }
            }
            else
            {
                Voluntter1DropDownList.Items.Add(new ListItem(volunteer1, "0"));
                Voluntter1DropDownList.Items[0].Enabled = true;
            }
        }

        public void InitializeVoluntter2(string volunteer2)
        {

            List<ListItem> listItems = new List<ListItem>();
            List<Volunteer> Allvolunteers;
            Allvolunteers = db.GetAllVolunteers();
            //if (Voluntter1DropDownList.Items.Count < 1)
            {
                if (volunteer2.Equals(""))
                {
                    Voluntter2DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                    for (int i = 0; i < Allvolunteers.Count; i++)
                    {
                        listItems.Add(new ListItem(Allvolunteers[i].Volunteer_Email));
                        Voluntter2DropDownList.Items.Add(new ListItem(listItems[i].Text, (i + 1).ToString()));
                    }
                }
                else
                {
                    Voluntter2DropDownList.Items.Add(new ListItem(volunteer2, "0"));
                    Voluntter2DropDownList.Items[0].Enabled = true;
                }
            }

        }

        public void InitializeVoluntter3(string volunteer3)
        {
            List<ListItem> listItems = new List<ListItem>();
            List<Volunteer> Allvolunteers;
            Allvolunteers = db.GetAllVolunteers();
            //if (Voluntter1DropDownList.Items.Count < 1)
            {
                if (volunteer3.Equals(""))
                {
                    Voluntter3DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                    for (int i = 0; i < Allvolunteers.Count; i++)
                    {
                        listItems.Add(new ListItem(Allvolunteers[i].Volunteer_Email));
                        Voluntter3DropDownList.Items.Add(new ListItem(listItems[i].Text, (i + 1).ToString()));
                    }
                }
                else
                {
                    Voluntter3DropDownList.Items.Add(new ListItem(volunteer3, "0"));
                    //Voluntter3DropDownList.Items[0].Enabled = true;
                }
            }
        }

        private string getSchoolAddress(int workShop_ID, bool isCompany, string workshopAddress)
        {
            string address;
            if (isCompany)
            {
                List<CompanyWorkshop> TempCompanyWorkshop = db.GetAllCompanyWorshops();
                List<Company> allCompany = db.GetAllComapny();
                CompanyWorkshop t = TempCompanyWorkshop.Find(x => x.CompanyWorkShopID == workShop_ID);
                address = allCompany.Find(y => y.Company_ID == t.CompanyID).Company_Address;
            }
            else
            {
                int tempBugFix = 1112121; // delete when BUG #1# fixed

                List<SchoolWorkShop> TempSchoolWorkshop = db.GetAllSchoolWorkShops();
                List<School> allSchool = db.GetAllSchools();
                SchoolWorkShop t = TempSchoolWorkshop.Find(x => x.SchoolWorkShopID == workShop_ID);
                address = allSchool.Find(y => y.School_Serial_Number == tempBugFix).School_Address; /*  #1#  t.school_ID*/
            }

            return address;
        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            //string test1 = e.Day.Date.ToString();
            //string test2 = WorkShops[0].WorkShop_Date.ToString();


            //if (WorkShops.Exists(x => x.WorkShop_Date.Date == e.Day.Date.Date))
            //{
            //    e.Cell.BackColor = Color.IndianRed;
            //}


        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {





        }
        public int getValidLastMonth()
        {
            int month = DateTime.Now.Month;
            month--;
            if (month < 1)
                return 12;
            else
                return month;
        }
        public int getValidNextMonth()
        {
            int month = DateTime.Now.Month;
            month++;
            if (month > 12)
                return 1;
            else
                return month;
        }

    }
}