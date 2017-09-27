using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui
{
    public partial class Default1 : System.Web.UI.Page
    {
        List<School> Schools = new List<School>();
        List<ListItem> Areas;
        bool IsNewSchool;
        DB db;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load1);
            IsNewSchool = true;
          
            db = new DB();
            db.IsConnect();
            Schools = db.GetAllSchools();
            Areas = db.GetAllAreas();
            InitializeForm();
        }
        protected void Page_Load1(object sender, EventArgs e)
        {
            
            //Page Back
            if (Page.IsPostBack  && CheckFormValidation())
            {
                
                // school data
                int SchoolSymbol = Convert.ToInt32(schoolSymbol.Text.ToString());
                string SchoolName = schoolname.Text.ToString();
                string SchoolAddress = schooladdress.Text.ToString();
                string SchoolCity = city.Text.ToString();
                int SchoolAreaValue = SchoolArea.SelectedIndex;

                //computer contact
                string ContantComputer = computercontact.Text.ToString();
                string ContantComputerPhone = computercontactphone.Text.ToString();

                // contact data
                string ContactName = contactname.Text.ToString();
                string ContactPhone = contactphone.Text.ToString();
                string ContactEmail = contactemail.Text.ToString();


                // workshop data
                string StudentPredict = studentpredict.Text.ToString();

                //string Date1 = Convert2Date(Calendar1.SelectedDate.Date.ToString(),hh1.Text.ToString(),mm1.Text.ToString());
                //string Date2 = Convert2Date(Calendar2.SelectedDate.Date.ToString(), hh2.Text.ToString(), mm2.Text.ToString());
                //string Date3 = Convert2Date(Calendar3.SelectedDate.Date.ToString(), hh2.Text.ToString(), mm3.Text.ToString());
                string Date1 = datetimePicker1.Text;
                string Date2 = datetimePicker2.Text;
                string Date3 = datetimePicker3.Text;
                int StudentCount = int.Parse(studentpredict.Text.ToString());
                int ComputerCount = int.Parse(numberofcumputers.Text.ToString());
                string FormComment = comments.Text.ToString();
                int x=scientificWorkshop.SelectedIndex;
                bool isAMTStudent = false;
                if (x==0)
                {
                isAMTStudent = true;
                }

                if (!Schools.Exists(Schools => Schools.School_Serial_Number == SchoolSymbol)) //new school
                {
                    School newSchool = new School(0, SchoolSymbol, SchoolName, SchoolAddress, SchoolAreaValue, SchoolCity, ContactName, ContactPhone, ContactEmail, ContantComputer, ContantComputerPhone, "");
                    db.InsetNewSchool(newSchool);
                    SchoolWorkShop NewSchoolWorkShop = new SchoolWorkShop(Date1, Date2, Date3, StudentCount, ComputerCount, FormComment,
                    ContactName, ContactPhone, ContactEmail, isAMTStudent, newSchool.School_ID);
                    if (db.InsertNewSchoolWorkShop(NewSchoolWorkShop))
                    {
                        
                        Response.Write("<script>alert('בית ספר חדש וסדנא חדשה נוספו בהצלחה');</script>");
                        Response.Redirect("../Documents/SuccessForm.aspx", false);

                    }
                        
                }
                else
                {
                    SchoolWorkShop NewSchoolWorkShop = new SchoolWorkShop(Date1, Date2, Date3, StudentCount, ComputerCount, FormComment,
                    ContactName, ContactPhone, ContactEmail, isAMTStudent, Schools.Find(y =>y.School_Serial_Number== SchoolSymbol).School_ID);
                    if (db.InsertNewSchoolWorkShop(NewSchoolWorkShop))
                    {
                        Response.Write("<script>alert('סדנא נוצרה בהצלחה');</script>");
                        Response.Redirect("../Documents/SuccessForm.aspx", false);
                    }
                       
                    
                }
                
                

            }


        }

        private bool CheckFormValidation()
        {
            // Check if all Input are fill?
            bool inputsNotFull = false;
            inputsNotFull = inputsNotFull || schoolSymbol.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || schoolname.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || schooladdress.Text.ToString().Equals("");

            inputsNotFull = inputsNotFull || contactname.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || contactphone.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || contactemail.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || computercontact.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || computercontactphone.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || city.Text.ToString().Equals("");

            inputsNotFull = inputsNotFull || studentpredict.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || numberofcumputers.Text.ToString().Equals("");
            inputsNotFull = inputsNotFull || isDateEmpty();
            return !inputsNotFull;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (schoolSymbol.Text.Length < 1)
            {
                ClearForm();
                EnableEdit();
                return;
            }
            //Check if School Symbol is exist
            foreach (School SelectedShcool in Schools)
            {

                if (SelectedShcool.School_Serial_Number == int.Parse(schoolSymbol.Text.ToString()))
                {
                    schoolname.Text = SelectedShcool.School_Name;
                    schooladdress.Text = SelectedShcool.School_Address;
                    contactname.Text = SelectedShcool.School_Contact_Name;
                    contactphone.Text = SelectedShcool.Scool_Contact_Phone;
                    contactemail.Text = SelectedShcool.School_Contact_Email;
                    city.Text = SelectedShcool.School_City;
                    SchoolArea.SelectedIndex = SelectedShcool.School_Area;
                    computercontact.Text = SelectedShcool.School_Supervisor_Name;
                    computercontactphone.Text = SelectedShcool.School_Supervisor_Phone;
                    DisableEdit();
                    IsNewSchool = false;
                    return;
                }
            }
            //Didnt Find School - need to enter new School
            ClearForm();
            EnableEdit();
            IsNewSchool = true;

        }
        public void ClearForm()
        {
            schoolname.Text = "";
            schooladdress.Text = "";
            contactname.Text = "";
            contactphone.Text = "";
            contactemail.Text = "";
            city.Text = "";
            computercontact.Text = "";
            computercontactphone.Text = "";
            SchoolArea.SelectedIndex = 0;
        }

      

        public void EnableEdit()
        {
            schoolname.Enabled = true;
            schooladdress.Enabled = true;
            contactname.Enabled = true;
            contactphone.Enabled = true;
            contactemail.Enabled = true;
            city.Enabled = true;           
            SchoolArea.Enabled = true;
            computercontact.Enabled = true;
            computercontactphone.Enabled = true;
        }
        public void DisableEdit()
        {
            schoolname.Enabled = false;
            schooladdress.Enabled = false;
            contactname.Enabled = false;
            contactphone.Enabled = false;
            contactemail.Enabled = false;
            city.Enabled = false;
            SchoolArea.Enabled = false;
            computercontact.Enabled = false;
            computercontactphone.Enabled = false;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (isDateEmpty())
            {
                // DateError.Text = "נא לבחור 3 תאריכים אפשריים";
                Response.Write("<script>alert('נא לסמן 3 תאריכים');</script>");
                //string script = "alert('please select a date');";
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
            else
            {
                DateError.Text = "";
                // string script = "alert('just a test');";
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
        }
        public bool isDateEmpty() 
        {
            //return( Calendar1.SelectedDate.Date == DateTime.MinValue ||
            //        Calendar2.SelectedDate.Date == DateTime.MinValue ||
            //        Calendar3.SelectedDate.Date == DateTime.MinValue);
            return (String.IsNullOrEmpty(datetimePicker1.Text)|| String.IsNullOrEmpty(datetimePicker2.Text) || String.IsNullOrEmpty(datetimePicker3.Text));
        }
        public void InitializeForm()
        {
            if (SchoolArea.Items.Count < 1)
            {
                SchoolArea.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < Areas.Count; i++)
                {
                    SchoolArea.Items.Add(new ListItem(Areas[i].Text, (i+1).ToString()));
                }

            }
        }

        public string Convert2Date(string date,string hour,string min)
        {
            string[] dateFormat = date.Split('/');
            string year = dateFormat[2].Split(' ')[0];
            string mounth = dateFormat[1];
            string day = dateFormat[0];
            if (int.Parse(hour) < 10) hour = "0" + hour;
            if (int.Parse(min) < 10) min = "0" + min;
            return year + "-" + mounth + "-"+day+" "+hour+":"+ min + ":"+"00";
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.Date.CompareTo(DateTime.Today) < 0 || e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date == DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void Calendar3_DayRender(object sender, DayRenderEventArgs e)
        {

        }
    }
}