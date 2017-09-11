using gui.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerAssignWorkshops : System.Web.UI.Page
    {
        List<WorkshopJoin> CompanyWorkshopsJoin = new List<WorkshopJoin>();
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
                    Editbtn.CssClass = "btn btn-info";
                    Edit.Controls.Add(Editbtn);
                    row.Cells.Add(Edit);
                    workshopTable.Rows.Add(row);
                }
            }
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            DupLabel.Visible = false;
            succsess.Visible = false;
            nonSelected.Visible = false;
            List<Volunteer> Volunteers = db.GetAllVolunteers();
            Volunteer volnteer1 = new Volunteer(), volnteer2 = new Volunteer(), volnteer3 = new Volunteer();
            Button selectedButton = (Button)sender;
            string isCompany = selectedButton.Attributes["IsCompany"];
            string workshopId = selectedButton.Attributes["WorkshopID"];
            Session["LocalWorkShopID"] = workshopId;
            Session["LocalisCompany"] = isCompany;
            workshopIdLabel.Text = workshopId;
            if (bool.Parse(isCompany))
            {
                // Company Workshop 
                CompanyWorkshop selectedWorkshop = db.getCompanyWorkshopByID(int.Parse(workshopId));
            }
            else
            {
                //School workshop

                SchoolWorkShop SelectedWorkshop = db.GetSchoolWorkshopByID(int.Parse(workshopId));
                if (!(SelectedWorkshop.SchoolWorkShopVolunteerID1.Equals("") || SelectedWorkshop.SchoolWorkShopVolunteerID1.Equals("0")))
                {
                    volnteer1 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.SchoolWorkShopVolunteerID1);
                }
                if (!(SelectedWorkshop.SchoolWorkShopVolunteerID2.Equals("") || SelectedWorkshop.SchoolWorkShopVolunteerID2.Equals("0")))
                {
                    volnteer2 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.SchoolWorkShopVolunteerID2);
                }
                if (!(SelectedWorkshop.SchoolWorkShopVolunteerID3.Equals("") || SelectedWorkshop.SchoolWorkShopVolunteerID3.Equals("0")))
                {
                    volnteer3 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.SchoolWorkShopVolunteerID3);
                }
            }
            InitializeVoluntter1(volnteer1, Volunteers);
            InitializeVoluntter2(volnteer2, Volunteers);
            InitializeVoluntter3(volnteer3, Volunteers);

            InitializeVoluntterRide(volnteer1, volnteer2, volnteer3, int.Parse(workshopId), bool.Parse(isCompany));
            //Remove Duplicated Volunteers
            RemoveDup(volnteer1, volnteer2, volnteer3);



        }

        private void InitializeVoluntterRide(Volunteer volnteer1, Volunteer volnteer2, Volunteer volnteer3, int workshopId, bool isCompany)
        {
            string Ride1 = "", Ride2 = "", Ride3 = "";
            volunteer1Ride.Enabled = true;
            volunteer2Ride.Enabled = true;
            volunteer3Ride.Enabled = true;
            if (isCompany)
            {

            }
            else
            {
                if (volnteer1 != null)
                {
                    Ride1 = db.getVolunteerSchoolRide(volnteer1.Volunteer_ID, workshopId);
                    volunteer1Ride.Enabled = false;
                    if (Ride1.Equals("")) Ride1 = " ";
                }
                if (volnteer2 != null)
                {
                    Ride2 = db.getVolunteerSchoolRide(volnteer2.Volunteer_ID, workshopId);
                    volunteer2Ride.Enabled = false;
                    if (Ride2.Equals("")) Ride2 = " ";
                }
                if (volnteer3 != null)
                {
                    Ride3 = db.getVolunteerSchoolRide(volnteer3.Volunteer_ID, workshopId);
                    volunteer3Ride.Enabled = false;
                    if (Ride3.Equals("")) Ride3 = " ";
                }

            }


            volunteer1Ride.Text = Ride1;
            volunteer2Ride.Text = Ride2;
            volunteer3Ride.Text = Ride3;

        }

        private void RemoveDup(Volunteer volnteer1, Volunteer volnteer2, Volunteer volnteer3)
        {

            if (volnteer1 != null)
            {
                if (Voluntter2DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter2DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter2DropDownList.Items[i];
                        if (t.Text.Equals(volnteer1.Volunteer_Email.ToString()))
                            Voluntter2DropDownList.Items.Remove(t);
                    }
                }
                if (Voluntter3DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter3DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter3DropDownList.Items[i];
                        if (t.Text.Equals(volnteer1.Volunteer_Email.ToString()))
                            Voluntter3DropDownList.Items.Remove(t);
                    }
                }

            }
            if (volnteer2 != null)
            {
                if (Voluntter1DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter1DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter1DropDownList.Items[i];
                        if (t.Text.Equals(volnteer2.Volunteer_Email.ToString()))
                            Voluntter1DropDownList.Items.Remove(t);
                    }
                }
                if (Voluntter3DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter3DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter3DropDownList.Items[i];
                        if (t.Text.Equals(volnteer2.Volunteer_Email.ToString()))
                            Voluntter3DropDownList.Items.Remove(t);
                    }
                }

            }
            if (volnteer3 != null)
            {
                if (Voluntter1DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter1DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter1DropDownList.Items[i];
                        if (t.Text.Equals(volnteer3.Volunteer_Email.ToString()))
                            Voluntter1DropDownList.Items.Remove(t);
                    }
                }
                if (Voluntter2DropDownList.Items.Count > 1)
                {
                    for (int i = 0; i < Voluntter2DropDownList.Items.Count; i++)
                    {
                        ListItem t = Voluntter2DropDownList.Items[i];
                        if (t.Text.Equals(volnteer3.Volunteer_Email.ToString()))
                            Voluntter2DropDownList.Items.Remove(t);
                    }
                }

            }
        }

        public void InitializeVoluntter1(Volunteer volunteer, List<Volunteer> Volunteerlist)
        {
            Voluntter1DropDownList.Items.Clear();
            VolunteerName1.Text = "";
            Voluntter1DropDownList.BackColor = System.Drawing.Color.White;
            if (volunteer == null)
            {
                ListItem t = new ListItem("בחר/י", "0");
                t.Attributes.Add("ID", "0");
                Voluntter1DropDownList.Items.Add(t);

                foreach (Volunteer v in Volunteerlist)
                {
                    if (v.Volunteer_Practice == 3) //וותיקה
                    {
                        ListItem i = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
                        i.Attributes.Add("ID", v.Volunteer_ID.ToString());
                        Voluntter1DropDownList.Items.Add(i);
                    }
                }
            }
            else
            {
                ListItem t = new ListItem(volunteer.Volunteer_Email);
                t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());

                Voluntter1DropDownList.Items.Add(t);
                Voluntter1DropDownList.DataBind();
                VolunteerName1.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
                Voluntter1DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
            }
        }
        public void InitializeVoluntter2(Volunteer volunteer, List<Volunteer> Volunteerlist)
        {
            Voluntter2DropDownList.Items.Clear();
            VolunteerName2.Text = "";
            Voluntter2DropDownList.BackColor = System.Drawing.Color.White;
            if (volunteer == null)
            {
                ListItem t = new ListItem("בחר/י", "0");
                t.Attributes.Add("ID", "0");
                Voluntter2DropDownList.Items.Add(t);

                foreach (Volunteer v in Volunteerlist)
                {
                    if (v.Volunteer_Practice == 2 || v.Volunteer_Practice == 3)
                    {
                        t = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
                        t.Attributes.Add("ID", v.Volunteer_ID.ToString());
                        Voluntter2DropDownList.Items.Add(t);
                    }
                }
            }
            else
            {
                ListItem t = new ListItem(volunteer.Volunteer_Email);
                t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());
                Voluntter2DropDownList.Items.Add(t);
                VolunteerName2.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
                Voluntter2DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
            }
        }
        public void InitializeVoluntter3(Volunteer volunteer, List<Volunteer> Volunteerlist)
        {
            Voluntter3DropDownList.Items.Clear();
            VolunteerName3.Text = "";
            Voluntter3DropDownList.BackColor = System.Drawing.Color.White;
            if (volunteer == null)
            {
                ListItem t = new ListItem("בחר/י", "0");
                t.Attributes.Add("ID", "0");
                Voluntter3DropDownList.Items.Add(t);

                foreach (Volunteer v in Volunteerlist)
                {
                    if (v.Volunteer_Practice == 2 || v.Volunteer_Practice == 3)
                    {
                        t = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
                        t.Attributes.Add("ID", v.Volunteer_ID.ToString());
                        Voluntter3DropDownList.Items.Add(t);
                    }
                }
            }
            else
            {
                ListItem t = new ListItem(volunteer.Volunteer_Email);
                t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());
                Voluntter3DropDownList.Items.Add(t);
                VolunteerName3.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
                Voluntter3DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
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

        protected void Voluntter1DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Voluntter1DropDownList.SelectedIndex;
            string Name = Voluntter1DropDownList.Items[index].Value;
            if (index == 0)
                VolunteerName1.Text = "";
            else
                VolunteerName1.Text = Name;
        }

        protected void Voluntter2DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Voluntter2DropDownList.SelectedIndex;
            string Name = Voluntter2DropDownList.Items[index].Value;
            if (index == 0)
                VolunteerName2.Text = "";
            else
                VolunteerName2.Text = Name;
        }

        protected void Voluntter3DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Voluntter3DropDownList.SelectedIndex;
            string Name = Voluntter3DropDownList.Items[index].Value;
            if (index == 0)
                VolunteerName3.Text = "";
            else
                VolunteerName3.Text = Name;
        }

        protected void assign_Click(object sender, EventArgs e)
        {
            DupLabel.Visible = false;
            succsess.Visible = false;
            nonSelected.Visible = false;
            List<Volunteer> Volunteers = db.GetAllVolunteers();
            // Check if 2/3 of the same try to submit
            ListItem t1 = Voluntter1DropDownList.SelectedItem;
            ListItem t2 = Voluntter2DropDownList.SelectedItem;
            ListItem t3 = Voluntter3DropDownList.SelectedItem;

            int ID1 = 0, ID2 = 0, ID3 = 0;
            bool result = true;
            try { ID1 = int.Parse(t1.Value); } catch (Exception exp) { ID1 = 1; }
            try { ID2 = int.Parse(t2.Value); } catch (Exception exp) { ID2 = 1; }
            try { ID3 = int.Parse(t3.Value); } catch (Exception exp) { ID3 = 1; }

            if (ID1 != 0 && ID2 != 0)
                if (t1.Value.Equals(t2.Value))
                    result = false;
            if (ID1 != 0 && ID3 != 0)
                if (t1.Value.Equals(t3.Value))
                    result = false;
            if (ID2 != 0 && ID3 != 0)
                if (t2.Value.Equals(t3.Value))
                    result = false;


            if (result)
            {
                string isCompany = Session["LocalisCompany"].ToString();
                string workshopId = Session["LocalWorkShopID"].ToString();
                if (ID1 != 0) ID1 = Volunteers.Find(x => x.Volunteer_Email.Equals(t1.Text.ToString())).Volunteer_ID;
                if (ID2 != 0) ID2 = Volunteers.Find(x => x.Volunteer_Email.Equals(t2.Text.ToString())).Volunteer_ID;
                if (ID3 != 0) ID3 = Volunteers.Find(x => x.Volunteer_Email.Equals(t3.Text.ToString())).Volunteer_ID;

                if (bool.Parse(isCompany))
                {
                    // Company Workshop 
                    CompanyWorkshop selectedWorkshop = db.getCompanyWorkshopByID(int.Parse(workshopId));
                }
                else
                {
                    //School workshop
                    SchoolWorkShop SelectedWorkshop = db.GetSchoolWorkshopByID(int.Parse(workshopId));
                    //Check if was change
                    if (ID1 != SelectedWorkshop.SchoolWorkShopVolunteerID1 ||
                       ID2 != SelectedWorkshop.SchoolWorkShopVolunteerID2 ||
                       ID3 != SelectedWorkshop.SchoolWorkShopVolunteerID3)
                    {
                        //Update DB
                        if (db.updateSchoolWorkshopVolunteer(SelectedWorkshop.SchoolWorkShopID, ID1, ID2, ID3,
                            volunteer1Ride.Text, volunteer2Ride.Text, volunteer3Ride.Text))
                        {
                            succsess.Visible = true;
                        }

                    }
                    else
                    {
                        nonSelected.Visible = true;
                    }

                }


            }
            else
            {
                DupLabel.Visible = true;
            }
        }
    }
}