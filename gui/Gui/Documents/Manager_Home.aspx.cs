using gui.Models;

using System;
using System.Collections.Generic;

//chen
namespace gui.Gui
{
    public partial class Manager_Home : System.Web.UI.Page
    {
        //List<Workshop> WorkShops = new List<Workshop>();
        DB db;
        //TODO Clander Next+Perv month event
        //TODO Display Workshop info
        //System.Web.UI.Page

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            InitializeForm();

        }

        private void InitializeForm()
        {
            //Start DB Connection
            db = new DB();
            db.IsConnect();
            //Get All WorkShops
            //WorkShops = db.GetallWorkShopsBetweenMonths(DateTime.Now.Year, getValidLastMonth(), getValidNextMonth());
            List<Volunteer> volunteerList = db.gettAllNewVolunteers();
           // VolunteerCounter.Text = volunteerList.Count.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        //protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    //string test1 = e.Day.Date.ToString();
        //    //string test2 = WorkShops[0].WorkShop_Date.ToString();


        //    //if(WorkShops.Exists(x=> x.WorkShop_Date.Date==e.Day.Date.Date))
        //    //{
        //    //    e.Cell.BackColor = Color.IndianRed;
        //    //}
                

        //}

        //protected void Calendar_SelectionChanged(object sender, EventArgs e)
        //{

        //    DateText.Text = "";
        //    if (WorkShops.Exists(x => x.WorkShop_Date.Date == Calendar.SelectedDate.Date.Date))
        //    {
        //        Workshop selectedWorkShop = WorkShops.Find(x => x.WorkShop_Date.Date == Calendar.SelectedDate.Date.Date);
               
        //        DateText.Text += "צריך להציג פרטים של הסדנא בתאריך הזה";
        //        DateText.Text += selectedWorkShop.WorkShop_Status.ToString() + selectedWorkShop.WorkShop_School_ID;
        //    }
        //    else
        //    {
        //        DateText.Text = "אין סדנאות בתאריך זה";
        //    }

            

        //}
        //public int getValidLastMonth()
        //{
        //    int month = DateTime.Now.Month;
        //    month--;
        //    if (month < 1)
        //        return 12;
        //    else
        //        return month;
        //}
        //public int getValidNextMonth()
        //{
        //    int month = DateTime.Now.Month;
        //    month++;
        //    if (month >12)
        //        return 1;
        //    else
        //        return month;
        //}

  
    }
}