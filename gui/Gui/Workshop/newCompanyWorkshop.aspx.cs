using Google.Maps;
using Google.Maps.StaticMaps;
using gui.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class newCompanyWorkshop : System.Web.UI.Page
    {

        List<Models.Company> Companies = new List<Models.Company>();
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Companies = db.GetAllComapny();
            GetAllCompaniesToList();
        }

        private void GetAllCompaniesToList()
        {
            if (dropDownCompanyName.Items.Count < 1)
            {
                dropDownCompanyName.Items.Add(new ListItem("בחר/י", "0"));
                for (int i = 0; i < Companies.Count; i++)
                {
                    dropDownCompanyName.Items.Add(new ListItem(Companies[i].Company_Name, (i + 1).ToString()));
                }

            }
        }

        protected void FillCompanyDetails(object sender, EventArgs e)
        {
            List<ListItem> Areas = db.GetAllAreas();

            Models.Company selectedComp = Companies[((DropDownList)sender).SelectedIndex - 1];
            companyID.Text = selectedComp.Company_ID.ToString();
            address.Text = selectedComp.Company_Address;
            area.Text = Areas[selectedComp.Company_Area_Activity].Text.ToString();
            area.CssClass = "form-control disabled";
            address.CssClass = "form-control disabled";
            companyID.CssClass = "form-control disabled";
        }


        protected void AddWorkshop(object sender, EventArgs e)
        {
            if (!IsEmptyFields())
            {
                CompanyWorkshop newcw = new CompanyWorkshop();
                newcw.CompanyWorkShopComments = comments.Text;
                newcw.WorkShop_Number_Of_StudentPredicted = Convert.ToInt32(PredictedStudentsNum.Text);
                newcw.CompanyID = Convert.ToInt32(companyID.Text);
                newcw.CompanyWorkShopDate = datePicker.Text + Convert2Time(hour.Text, minutes.Text);

                if (db.InsertNewCompanyWorkShop(newcw))
                {
                    Response.Write("<script>alert('הסדנא נוספה בהצלחה.');</script>");

                    //if(SendInvitesToSchools(newcw))
                    //{
                    //    Response.Write("<script>alert('אימיילים נשלחו אל בתי ספר רלוונטים');</script>");

                    //}
                    //else 
                    //{
                    //    Response.Write("<script>alert('שגיאה בשליחת אימיילים');</script>");
                    //}
                    ClearWorkshopDetails();
                }
                else
                {
                    Response.Write("<script>alert('שגיאה ביצירת סדנא');</script>");
                }

            }
        }


        /// <summary>
        /// This function send emails to all the relevant school.
        /// inform them that new company workshop was created
        /// </summary>
        protected bool SendInvitesToSchools(CompanyWorkshop selectedWorkshop)
        {
            List<School> allSchools = db.GetAllSchools();
            List<Models.Company> allCompany = db.GetAllComapny();

            int companyID = selectedWorkshop.CompanyID;
            Models.Company SelectedComapny = allCompany.Find(x => x.Company_ID == companyID);

            allSchools = allSchools.FindAll(x => x.School_Area == SelectedComapny.Company_Area_Activity);
            EmailHelper email = new EmailHelper();
            return email.SendInitesToSchools(allSchools, selectedWorkshop);
        }

        private bool IsEmptyFields()
        {
            if (dropDownCompanyName.SelectedIndex == 0)
            {
                Response.Write("<script>alert('לא נבחרה חברה');</script>");
                return true;
            }
            //else if (PredictedStudentsNum.Text.Equals("") || hour.Text.Equals("") || minutes.Text.Equals(""))
            //{
            //    Response.Write("<script>alert('שדות חובה חסרים');</script>");
            //    return true;
            //}
            //else if (calendar.SelectedDate.Date.ToString().Equals("01/01/0001 00:00:00") || calendar.SelectedDate == null || calendar.SelectedDate == DateTime.Now)
            //{
            //    Response.Write("<script>alert('לא נבחר תאריך');</script>");
            //    return true;
            //}

            else
            {
                return false;
            }

        }

        private void ClearWorkshopDetails()
        {
            companyID.Text = "";
            address.Text = "";
            area.Text = "";
            dropDownCompanyName.SelectedIndex = 0;
            PredictedStudentsNum.Text = "";
            hour.Text = "";
            minutes.Text = "";
            comments.Text = "";
            datePicker.Text = "";

        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calendar_DayRender(object sender,
                         DayRenderEventArgs e)
        {

            if (e.Day.Date.CompareTo(DateTime.Today) < 0 || e.Day.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        public string Convert2Time(string hour, string min)
        {

            if (int.Parse(hour) < 10) hour = "0" + hour;
            if (int.Parse(min) < 10) min = "0" + min;
            return " " + hour + ":" + min + ":" + "00";

        }
    }
}
