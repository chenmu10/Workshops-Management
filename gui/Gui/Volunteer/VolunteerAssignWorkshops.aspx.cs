using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerAssignWorkshops : System.Web.UI.Page
    {
        // TO DO add call from DB to school id #1# (search #1# to find the place to fix, you can use ctr+f))
        // TO DO check if the volunteer is senior #3#
        // TO DO WorkshopJoin should hold volunteer mail instead of names, after you fix this go to #4# (in 3 places you can use ctr+f)and replace the code in the " /*....*/ "
        // TO DO add VolunterAssignPlaceHolder.Display = flase when Editbtn is pressed
        List<WorkshopJoin> CompanyWorkshopsJoin = new List<WorkshopJoin>();

        DB db;

        List<bool> volExist;
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

        protected void FillTable()
        {
            CompanyWorkshopsJoin = db.GetAllWorkshopsByJoin();

            foreach (WorkshopJoin t in CompanyWorkshopsJoin)
            {

                if (t.Status_Description.Equals(" לשיבוץ מתנדבות"))
                {
                    TableRow row = new TableRow();

                    TableCell workshopID = new TableCell();
                    workshopID.Text = t.WorkShop_ID;
                    row.Cells.Add(workshopID);

                    TableCell Date = new TableCell();
                    Date.Text = t.WorkShop_Date;
                    row.Cells.Add(Date);

                    TableCell Address = new TableCell();
                    Address.Text = GetWorkshopAddress(int.Parse(t.WorkShop_ID), t.Is_company);
                    row.Cells.Add(Address);

                    TableCell SchoolName = new TableCell();
                    SchoolName.Text = t.School_Name;
                    row.Cells.Add(SchoolName);

                    TableCell companyName = new TableCell();
                    companyName.Text = t.Company_Name;
                    row.Cells.Add(companyName);

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
                    Editbtn.Click += new EventHandler(Select_Click);
                    Editbtn.Text = "בחירה";
                    Edit.Controls.Add(Editbtn);
                    row.Cells.Add(Edit);
                    workshopTable.Rows.Add(row);
                }
            }
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            ClearForm();

            Button selectedButton = (Button)sender;

            string isCompany = selectedButton.Attributes["IsCompany"];
            string workshopId = selectedButton.Attributes["WorkshopID"];
            //SchoolWorkShop s = db.GetSchoolWorkShopByID(int.Parse(workshopId));
            //string volunteer1 = selectedButton.Attributes["Voluntter1"];
            //string volunteer2 = selectedButton.Attributes["Voluntter2"];
            //string volunteer3 = selectedButton.Attributes["Voluntter3"];

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

            }

            //workshopIdLabel.Text = workshopId;
            //InitializeVoluntter1(volunteer1);
            //InitializeVoluntter2(volunteer2);
            //InitializeVoluntter3(volunteer3);

        }

        public void InitializeVoluntter1(string volunteer1)
        {
            List<Volunteer> volunteers = db.GetAllVolunteers();
            //if (Voluntter1DropDownList.Items.Count < 1)
            if (volunteer1.Equals(""))
            {
                volExist[1] = false;
                Voluntter1DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < volunteers.Count; i++)
                {
                    if (volunteers[i].Volunteer_Practice == 3)
                    {
                        // listItems.Add(new ListItem(volunteers[i].Volunteer_Email));
                        // Voluntter1DropDownList.Items.Add(new ListItem(listItems[i].Text, (i + 1).ToString()));
                        Voluntter1DropDownList.Items.Add(new ListItem(volunteers[i].Volunteer_Email));
                    }
                }
            }
            else
            {
                Voluntter1DropDownList.Items.Add(new ListItem(volunteer1));
                Voluntter1DropDownList.Enabled = false;
            }
        }

        public void InitializeVoluntter2(string volunteer2)
        {
            List<Volunteer> volunteers = db.GetAllVolunteers();
            //if (Voluntter1DropDownList.Items.Count < 1)
            if (volunteer2.Equals(""))
            {
                volExist[2] = false;
                Voluntter2DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < volunteers.Count; i++)
                {
                    if (volunteers[i].Volunteer_Practice == 3)
                    {
                        // listItems.Add(new ListItem(volunteers[i].Volunteer_Email));
                        // Voluntter1DropDownList.Items.Add(new ListItem(listItems[i].Text, (i + 1).ToString()));
                        Voluntter2DropDownList.Items.Add(new ListItem(volunteers[i].Volunteer_Email));
                    }
                }
            }
            else
            {
                Voluntter2DropDownList.Items.Add(new ListItem(volunteer2));
                Voluntter2DropDownList.Enabled = false;
            }
        }

        public void InitializeVoluntter3(string volunteer3)
        {


            //if (Voluntter1DropDownList.Items.Count < 1)
            if (volunteer3.Equals(""))
            {
                List<Volunteer> volunteers = db.GetAllVolunteers();
                volExist[3] = false;
                Voluntter3DropDownList.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < volunteers.Count; i++)
                {
                    if (volunteers[i].Volunteer_Practice == 3)
                    {
                        Voluntter3DropDownList.Items.Add(new ListItem(volunteers[i].Volunteer_Email));
                    }
                }
            }
            else
            {
                Voluntter3DropDownList.Items.Add(new ListItem(volunteer3));
                Voluntter3DropDownList.Enabled = false;
            }
        }

        private string GetWorkshopAddress(int workShop_ID, bool isCompany)
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
                List<SchoolWorkShop> TempSchoolWorkshop = db.GetAllSchoolWorkShops();
                List<School> allSchool = db.GetAllSchools();
                SchoolWorkShop t = TempSchoolWorkshop.Find(x => x.SchoolWorkShopID == workShop_ID);
                address = allSchool.Find(y => y.School_ID == t.WorkShop_School_ID).School_Address;
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


        public void ClearForm()
        {
            Voluntter1DropDownList.Items.Clear();
            Voluntter2DropDownList.Items.Clear();
            Voluntter3DropDownList.Items.Clear();
        }

        //protected void Assign_Click(object sender, EventArgs e)
        //{
        //    if (Volunteer1.)


        //TODO check duplicated volunteer 



        //    db.insertVolunteer();
        //}
    }
}