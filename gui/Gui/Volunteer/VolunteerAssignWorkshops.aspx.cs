using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class VolunteerAssignWorkshops : System.Web.UI.Page
    {
        List<WorkshopJoin> CompanyWorkshopsJoin = new List<WorkshopJoin>();
        DB db;

        override protected void OnInit(EventArgs e)
        {
            Workshop_Selected_Visibly_Change(true);
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            if (!Page.IsPostBack)
            {              
                List<ListItem> areas = db.GetAllAreas();
                DropDownListAreas.Items.Clear();
                DropDownListAreas.Items.Add(new ListItem("איזור"));
                foreach (ListItem i in areas)
                {
                    DropDownListAreas.Items.Add(i);
                }                               
            }
            FillTable(db.GetAllWorkshopsByJoin());
        }

        protected void FillTable(List<WorkshopJoin> CompanyWorkshopsJoins)
        {
            int countLines = 0;
            TableRow row0=workshopTable.Rows[0];
            workshopTable.Rows.Clear();
            workshopTable.Rows.Add(row0);
            foreach (WorkshopJoin t in CompanyWorkshopsJoins)
            {
                if (t.Status==1)
                {
                    TableRow row = new TableRow();

                    countLines++;
                    TableCell lineNumber = new TableCell();
                    lineNumber.Text = countLines.ToString();
                    row.Cells.Add(lineNumber);


                    /*
                    TableCell workshopID = new TableCell();
                    workshopID.Text = t.WorkShop_ID;
                    row.Cells.Add(workshopID);
                    */

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
                    Editbtn.Attributes.Add("countLine", countLines.ToString());
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
                    Editbtn.Text = "הרשמה";
                    Editbtn.CssClass = "btn btn-info";
                    Edit.Controls.Add(Editbtn);
                    row.Cells.Add(Edit);
                    workshopTable.Rows.Add(row);

                }
            }
        }

        protected void Workshop_Selected_Visibly_Change(bool toHide)
        {
            if (toHide == true)
            {
                VolunteerAssignPlaceHolder.Visible = false;
            }
            else
            {
                VolunteerAssignPlaceHolder.Visible = true;
            }
        }

        protected void Clear_Bold_In_Table()
        {
            foreach (TableRow t in workshopTable.Rows)
            {
                t.Font.Bold = false;
            }
        }

        protected void Select_Click(object sender, EventArgs e)
        {
            emailerror.Visible = false;
            V1Name.Text = "";
            V2Name.Text = "";
            V3Name.Text = "";
            Clear_Bold_In_Table();
            DupLabel.Visible = false;
            succsess.Visible = false;
            nonSelected.Visible = false;
            List<Models.Volunteer> Volunteers = db.GetAllVolunteers();
            Models.Volunteer volnteer1 = new Models.Volunteer(), volnteer2 = new Models.Volunteer(), volnteer3 = new Models.Volunteer();
            Button selectedButton = (Button)sender;
            workshopTable.Rows[int.Parse(selectedButton.Attributes["CountLine"])].Font.Bold = true;
            string isCompany = selectedButton.Attributes["IsCompany"];
            string workshopId = selectedButton.Attributes["WorkshopID"];
            string CountLine = selectedButton.Attributes["CountLine"];
            Session["LocalWorkShopID"] = workshopId;
            Session["LocalCountLine"] = CountLine;
            Session["LocalisCompany"] = isCompany;
            workshopIdLabel.Text = CountLine;
            if (bool.Parse(isCompany))
            {
                // Company Workshop 
                CompanyWorkshop SelectedWorkshop = db.getCompanyWorkshopByID(int.Parse(workshopId));

                if (!(SelectedWorkshop.CompanyWorkShopVolunteerID1.Equals("") || SelectedWorkshop.CompanyWorkShopVolunteerID1.Equals("0")))
                {
                    volnteer1 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.CompanyWorkShopVolunteerID1);
                }
                if (!(SelectedWorkshop.CompanyWorkShopVolunteerID2.Equals("") || SelectedWorkshop.CompanyWorkShopVolunteerID2.Equals("0")))
                {
                    volnteer2 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.CompanyWorkShopVolunteerID2);
                }
                if (!(SelectedWorkshop.CompanyWorkShopVolunteerID3.Equals("") || SelectedWorkshop.CompanyWorkShopVolunteerID3.Equals("0")))
                {
                    volnteer3 = Volunteers.Find(x => x.Volunteer_ID == SelectedWorkshop.CompanyWorkShopVolunteerID3);
                }
                InitializeVoluntter1(volnteer1, Volunteers);
                InitializeVoluntter2(volnteer2, Volunteers);
                InitializeVoluntter3(volnteer3, Volunteers);

                InitializeVoluntterRide(volnteer1, volnteer2, volnteer3, int.Parse(workshopId), bool.Parse(isCompany));
                //Remove Duplicated Volunteers
                RemoveDup(volnteer1, volnteer2, volnteer3);
                Workshop_Selected_Visibly_Change(false);

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
            Workshop_Selected_Visibly_Change(false);

        }

        private void InitializeVoluntterRide(Models.Volunteer volnteer1, Models.Volunteer volnteer2, Models.Volunteer volnteer3, int workshopId, bool isCompany)
        {
            string Ride1 = "", Ride2 = "", Ride3 = "";
            volunteer1Ride.Enabled = true;
            volunteer2Ride.Enabled = true;
            volunteer3Ride.Enabled = true;
            if (isCompany)
            {
                if (volnteer1 != null)
                {
                    Ride1 = db.getVolunteerCompanyRide(volnteer1.Volunteer_ID, workshopId);
                    volunteer1Ride.Enabled = false;
                    if (Ride1.Equals("")) Ride1 = " ";
                }
                if (volnteer2 != null)
                {
                    Ride2 = db.getVolunteerCompanyRide(volnteer2.Volunteer_ID, workshopId);
                    volunteer2Ride.Enabled = false;
                    if (Ride2.Equals("")) Ride2 = " ";
                }
                if (volnteer3 != null)
                {
                    Ride3 = db.getVolunteerCompanyRide(volnteer3.Volunteer_ID, workshopId);
                    volunteer3Ride.Enabled = false;
                    if (Ride3.Equals("")) Ride3 = " ";
                }
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

        private void RemoveDup(Models.Volunteer volnteer1, Models.Volunteer volnteer2, Models.Volunteer volnteer3)
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

        public void InitializeVoluntter1(Models.Volunteer volunteer, List<Models.Volunteer> Volunteerlist)
        {
            if (volunteer != null)
            {
                V1Name.Enabled = false;
                V1Name.Text = volunteer.Volunteer_First_Name + " " + volunteer.Volunteer_Last_Name;
            }
            else
                V1Name.Enabled = true;


            //Voluntter1DropDownList.Items.Clear();
            //VolunteerName1.Text = "";
            //Voluntter1DropDownList.BackColor = System.Drawing.Color.White;
            //if (volunteer == null)
            //{
            //    ListItem t = new ListItem("בחר/י", "0");
            //    t.Attributes.Add("ID", "0");
            //    Voluntter1DropDownList.Items.Add(t);

            //    foreach (Models.Volunteer v in Volunteerlist)
            //    {
            //        if (v.Volunteer_Practice == 3) //וותיקה
            //        {
            //            ListItem i = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
            //            i.Attributes.Add("ID", v.Volunteer_ID.ToString());
            //            Voluntter1DropDownList.Items.Add(i);
            //        }
            //    }
            //}
            //else
            //{
            //    ListItem t = new ListItem(volunteer.Volunteer_Email);
            //    t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());

            //    Voluntter1DropDownList.Items.Add(t);
            //    Voluntter1DropDownList.DataBind();
            //    //VolunteerName1.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
            //    Voluntter1DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
            //}
        }
        public void InitializeVoluntter2(Models.Volunteer volunteer, List<Models.Volunteer> Volunteerlist)
        {
            if (volunteer != null)
            {
                V2Name.Enabled = false;
                V2Name.Text = volunteer.Volunteer_First_Name + " " + volunteer.Volunteer_Last_Name;
            }
            else
                V2Name.Enabled = true;
            //Voluntter2DropDownList.Items.Clear();
            //VolunteerName2.Text = "";
            //Voluntter2DropDownList.BackColor = System.Drawing.Color.White;
            //if (volunteer == null)
            //{
            //    ListItem t = new ListItem("בחר/י", "0");
            //    t.Attributes.Add("ID", "0");
            //    Voluntter2DropDownList.Items.Add(t);

            //    foreach (Models.Volunteer v in Volunteerlist)
            //    {
            //        if (v.Volunteer_Practice == 2 || v.Volunteer_Practice == 3)
            //        {
            //            t = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
            //            t.Attributes.Add("ID", v.Volunteer_ID.ToString());
            //            Voluntter2DropDownList.Items.Add(t);
            //        }
            //    }
            //}
            //else
            //{
            //    ListItem t = new ListItem(volunteer.Volunteer_Email);
            //    t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());
            //    Voluntter2DropDownList.Items.Add(t);
            //    //VolunteerName2.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
            //    Voluntter2DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
            //}
        }
        public void InitializeVoluntter3(Models.Volunteer volunteer, List<Models.Volunteer> Volunteerlist)
        {

            if (volunteer != null)
            {
                V3Name.Enabled = false;
                V3Name.Text = volunteer.Volunteer_First_Name + " " + volunteer.Volunteer_Last_Name;
            }
            else
                V3Name.Enabled = true;

            //Voluntter3DropDownList.Items.Clear();
            //VolunteerName3.Text = "";
            //Voluntter3DropDownList.BackColor = System.Drawing.Color.White;
            //if (volunteer == null)
            //{
            //    ListItem t = new ListItem("בחר/י", "0");
            //    t.Attributes.Add("ID", "0");
            //    Voluntter3DropDownList.Items.Add(t);

            //    foreach (Models.Volunteer v in Volunteerlist)
            //    {
            //        if (v.Volunteer_Practice == 2 || v.Volunteer_Practice == 3)
            //        {
            //            t = new ListItem(v.Volunteer_Email, v.Volunteer_First_Name + " " + v.Volunteer_Last_Name);
            //            t.Attributes.Add("ID", v.Volunteer_ID.ToString());
            //            Voluntter3DropDownList.Items.Add(t);
            //        }
            //    }
            //}
            //else
            //{
            //    ListItem t = new ListItem(volunteer.Volunteer_Email);
            //    t.Attributes.Add("ID", volunteer.Volunteer_ID.ToString());
            //    Voluntter3DropDownList.Items.Add(t);
            //    //VolunteerName3.Text = volunteer.Volunteer_First_Name + "  " + volunteer.Volunteer_Last_Name;
            //    Voluntter3DropDownList.BackColor = System.Drawing.Color.LightSlateGray;
            //}
        }


        private string GetWorkshopAddress(int workShop_ID, bool isCompany)
        {
            string address;
            if (isCompany)
            {
                List<CompanyWorkshop> TempCompanyWorkshop = db.GetAllCompanyWorshops();
                List<Models.Company> allCompany = db.GetAllComapny();
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
            List<Models.Volunteer> Volunteers = db.GetAllVolunteers();
            int ID1 = 0, ID2 = 0, ID3 = 0;
            string v1Email = "", v2Email = "", v3Email = "";
            Models.Volunteer V1 = new Models.Volunteer(), V2 = new Models.Volunteer(), V3 = new Models.Volunteer();

            if (V1Name.Enabled)
                v1Email = V1Name.Text;
            if (V2Name.Enabled)
                v2Email = V2Name.Text;
            if (V3Name.Enabled)
                v3Email = V3Name.Text;

            string isCompany = Session["LocalisCompany"].ToString();
            string workshopId = Session["LocalWorkShopID"].ToString();
           
            if (bool.Parse(isCompany))
            {
                // Company Workshop 
                CompanyWorkshop selectedWorkshop = db.getCompanyWorkshopByID(int.Parse(workshopId));
                ID1 = selectedWorkshop.CompanyWorkShopVolunteerID1;
                ID2 = selectedWorkshop.CompanyWorkShopVolunteerID2;
                ID3 = selectedWorkshop.CompanyWorkShopVolunteerID3;

                V1 = Volunteers.Find(x => x.Volunteer_ID == ID1);
                V2 = Volunteers.Find(x => x.Volunteer_ID == ID2);
                V3 = Volunteers.Find(x => x.Volunteer_ID == ID3);

                if (V1Name.Enabled && V2 != null && V3 != null)
                    if (v1Email == V2.Volunteer_Email || v1Email == V3.Volunteer_Email)
                        DupLabel.Visible = true;
                if (V2Name.Enabled && V1 != null && V3 != null)
                    if (v2Email == V1.Volunteer_Email || v2Email == V3.Volunteer_Email)
                        DupLabel.Visible = true;
                if (V3Name.Enabled && V1 != null && V2 != null)
                    if (v3Email == V1.Volunteer_Email || v3Email == V2.Volunteer_Email)
                        DupLabel.Visible = true;

                if(!v1Email.Equals("") && !v2Email.Equals("") && v1Email.Equals(v2Email))
                    DupLabel.Visible = true;
                if (!v1Email.Equals("") && !v3Email.Equals("") && v1Email.Equals(v3Email))
                    DupLabel.Visible = true;
                if (!v3Email.Equals("") && !v2Email.Equals("") && v3Email.Equals(v2Email))
                    DupLabel.Visible = true;

                //if (v1Email.Equals(v2Email) || v2Email.Equals(v3Email) || v1Email.Equals(v3Email))
                //    DupLabel.Visible = true;

                if (DupLabel.Visible) return;
                // was change
                if (!v2Email.Equals("") || !v1Email.Equals("") || !v3Email.Equals(""))
                {
                    if (!v1Email.Equals(""))
                        ID1 = Volunteers.Find(x => x.Volunteer_Email == v1Email).Volunteer_ID;
                    if (!v2Email.Equals(""))
                        ID2 = Volunteers.Find(x => x.Volunteer_Email == v2Email).Volunteer_ID;
                    if (!v3Email.Equals(""))
                        ID3 = Volunteers.Find(x => x.Volunteer_Email == v3Email).Volunteer_ID;

                    if (db.updateCompanyWorkshopVolunteer(selectedWorkshop.CompanyWorkShopID, ID1, ID2, ID3,
                        volunteer1Ride.Text, volunteer2Ride.Text, volunteer3Ride.Text))
                    {
                        Clear_Bold_In_Table();
                        Workshop_Selected_Visibly_Change(true);
                        succsess.Visible = true;

                        V1Name.Enabled = true;
                        V2Name.Enabled = true;
                        V3Name.Enabled = true;
                    }
                }


                }
                else
                {
                    //School workshop
                SchoolWorkShop SelectedWorkshop = db.GetSchoolWorkshopByID(int.Parse(workshopId));
                ID1 = SelectedWorkshop.SchoolWorkShopVolunteerID1;
                ID2 = SelectedWorkshop.SchoolWorkShopVolunteerID2;
                ID3 = SelectedWorkshop.SchoolWorkShopVolunteerID3;

                V1 = Volunteers.Find(x => x.Volunteer_ID == ID1);
                V2 = Volunteers.Find(x => x.Volunteer_ID == ID2);
                V3 = Volunteers.Find(x => x.Volunteer_ID == ID3);

                if (V1Name.Enabled && V2 != null && V3 != null)
                    if (v1Email == V2.Volunteer_Email || v1Email == V3.Volunteer_Email)
                        DupLabel.Visible = true;
                if (V2Name.Enabled && V1 != null && V3 != null)
                    if (v2Email == V1.Volunteer_Email || v2Email == V3.Volunteer_Email)
                        DupLabel.Visible = true;
                if (V3Name.Enabled && V1 != null && V2 != null)
                    if (v3Email == V1.Volunteer_Email || v3Email == V2.Volunteer_Email)
                        DupLabel.Visible = true;

                if (!v1Email.Equals("") && !v2Email.Equals("") && v1Email.Equals(v2Email))
                    DupLabel.Visible = true;
                if (!v1Email.Equals("") && !v3Email.Equals("") && v1Email.Equals(v3Email))
                    DupLabel.Visible = true;
                if (!v3Email.Equals("") && !v2Email.Equals("") && v3Email.Equals(v2Email))
                    DupLabel.Visible = true;

                //if (v1Email.Equals(v2Email) || v2Email.Equals(v3Email) || v1Email.Equals(v3Email))
                //    DupLabel.Visible = true;

                if (DupLabel.Visible) return;
                // was change
                if (!v2Email.Equals("") || !v1Email.Equals("") || !v3Email.Equals(""))
                {
                    if (!v1Email.Equals(""))
                        if (!Volunteers.Exists(x => x.Volunteer_Email == v1Email))
                        {
                            emailerror.Visible = true;
                            return;
                        }
                    if (!v2Email.Equals(""))
                        if (!Volunteers.Exists(x => x.Volunteer_Email == v2Email))
                        {
                            emailerror.Visible = true;
                            return;
                        }
                    if (!v3Email.Equals(""))
                        if (!Volunteers.Exists(x => x.Volunteer_Email == v3Email))
                        {
                            emailerror.Visible = true;
                            return;
                        }


                    if (!v1Email.Equals(""))
                        ID1 = Volunteers.Find(x => x.Volunteer_Email == v1Email).Volunteer_ID;
                    if (!v2Email.Equals(""))
                        ID2 = Volunteers.Find(x => x.Volunteer_Email == v2Email).Volunteer_ID;
                    if (!v3Email.Equals(""))
                        ID3 = Volunteers.Find(x => x.Volunteer_Email == v3Email).Volunteer_ID;

                    if (db.updateSchoolWorkshopVolunteer(SelectedWorkshop.SchoolWorkShopID, ID1, ID2, ID3,
                        volunteer1Ride.Text, volunteer2Ride.Text, volunteer3Ride.Text))
                    {
                        Clear_Bold_In_Table();
                        Workshop_Selected_Visibly_Change(true);
                        succsess.Visible = true;

                        V1Name.Enabled = true;
                        V2Name.Enabled = true;
                        V3Name.Enabled = true;
                    }
                }
            }
           }

        protected void Select_Click1(object sender, EventArgs e)
        {
            int index = DropDownListAreas.SelectedIndex+1;
            List<WorkshopJoin> allWorkshop= db.GetAllWorkshopsByJoin();
            allWorkshop = allWorkshop.Where(x => x.Area == index).ToList();
            FillTable(allWorkshop);
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href = ''; </script>");

        }
       
    }
}