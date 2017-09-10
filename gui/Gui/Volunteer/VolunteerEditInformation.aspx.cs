using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui
{
    public partial class Default : System.Web.UI.Page
    {

        /*TODO
        - Update Volunteer To DB
        - Delete Volunteer To DB
            
            */



        DB db;
        //List<Volunteer> Volunteers = new List<Volunteer>();
        override protected void OnInit(EventArgs e)
        {
            db = new DB();
            db.IsConnect();
            this.Load += new System.EventHandler(this.Page_Load);
            List<ListItem> occupations = GetAllOccupation();
            if (DropDownList1.Items.Count < 1)
            {
                foreach (ListItem occName in occupations)
                {
                    DropDownList1.Items.Add(occName);
                }
            }
            List<ListItem> Refrencess = GetAllReference();
            if(DropDownList2.Items.Count<1)
            {
                foreach (ListItem occName in Refrencess)
                {
                    DropDownList1.Items.Add(occName);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            //Get From DB all area - and insert to html
            List<ListItem> result = db.GetAllAreas();
            if (CheckBoxList1.Items.Count < 1)
            {
                foreach (ListItem item in result)
                {
                    CheckBoxList1.Items.Add(item);
                }
            }
            if(Session["SelectedVolunteer"] !=null)
            {
                Volunteers = db.GetAllVolunteers();
                int SelectedVolunteerID = (int)Session["SelectedVolunteer"];
                Volunteer EditVolunteer = Volunteers.Find(x => x.Volunteer_ID == SelectedVolunteerID);


                firstname.Text = EditVolunteer.Volunteer_First_Name;
                lastname.Text = EditVolunteer.Volunteer_Last_Name;
                firstnameeng.Text = EditVolunteer.Volunteer_First_Name_Eng;
                lastnameeng.Text = EditVolunteer.Volunteer_Last_Name_Eng;
                email.Text = EditVolunteer.Volunteer_Email;
                phone.Text = EditVolunteer.Volunteer_phone;
                employee.Text = EditVolunteer.Volunteer_Employer;
                string Occupation = EditVolunteer.Volunteer_Occupation;
                for(int i=0;i< DropDownList1.Items.Count;i++)
                {
                    ListItem item = DropDownList1.Items[i];
                    if (item.Text.Equals(Occupation))
                    {
                        DropDownList1.SelectedIndex = i;
                    }
                }
                string refence = EditVolunteer.Volunteer_Reference;
                for (int i = 0; i < DropDownList2.Items.Count; i++)
                {
                    ListItem item = DropDownList2.Items[i];
                    if (item.Text.Equals(refence))
                    {
                        DropDownList2.SelectedIndex = i;
                    }
                }
                List<int> areaOfSelectedVol = EditVolunteer.Volunteer_Area_Activity;
                foreach (int valueOfArea in areaOfSelectedVol)
                {
                    CheckBoxList1.Items[valueOfArea-1].Selected = true;
                }
                int traning = EditVolunteer.Volunteer_Practice;
                TraningList.SelectedIndex = traning-1;
            }
            //page signin - get all data from html
            if (Page.IsPostBack)
            {

                string firstnamevalue = firstname.Text.ToString();
                string firstnameEngValue = firstnameeng.Text.ToString();
                string lastnamevalue = lastname.Text.ToString();
                string lastnameEngValue = lastnameeng.Text.ToString();
                string emailvalue = email.Text.ToString();
                string phonevalue = phone.Text.ToString();
                string occupation = DropDownList1.SelectedValue.ToString();
                string refernce = DropDownList2.SelectedValue.ToString();
                string employe = employee.Text.ToString();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        string value = item.Text.ToString();
                    }

                }
                /*
                Update Volunteer

                Or Delete

                */
                ErrorMsg.InnerText = "העדכון התבצעה בהצלחה";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Get Form elements and reset them
            //firstname.Text = "";
            //lastname.Text = "";
            //lastnameeng.Text = "";
            //email.Text = "";
            //employee.Text = "";
            //phone.Text = "";
            //DropDownList1.SelectedIndex = 0;
            //string refernce = DropDownList2.SelectedValue.ToString();
            //foreach (ListItem item in CheckBoxList1.Items)
            //{
            //    if (item.Selected)
            //    {
            //        item.Selected = false;
            //    }

            //}
        }
        public List<ListItem> GetAllOccupation()
        {
            List<ListItem> listItems = new List<ListItem>();
            listItems.Add(new ListItem("בחרי", "0"));
            listItems.Add(new ListItem("סטודנטית", "1"));
            listItems.Add(new ListItem("אקדמאית", "2"));
            listItems.Add(new ListItem("עובדת בתעשייה", "3"));
            listItems.Add(new ListItem("אחר", "4"));
            return listItems;
        }
        public List<ListItem> GetAllReference()
        {
            List<ListItem> listItems = new List<ListItem>();
            listItems.Add(new ListItem("בחרי","0"));
            listItems.Add(new ListItem("פייסבוק","1"));
            listItems.Add(new ListItem("מכרים","2"));
            listItems.Add(new ListItem("עבודה","3"));
            return listItems;
        }
    }
}