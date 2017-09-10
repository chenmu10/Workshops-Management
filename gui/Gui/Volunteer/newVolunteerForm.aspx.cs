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
        //TODO insert new Volunter to DB
        //TODO when select "אחר" in refernce - open TextBox to enter text.


        //TODO check new volunteer uniqness


        DB db;
        // fill all selectboxes
        public bool FormOkToDB = true;
        DateTime LastPostRequest;


        List<ListItem> Areas;
        override protected void OnInit(EventArgs e)
        {
            LastPostRequest = DateTime.Now;
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            Areas = db.GetAllAreas();
            GetItemsFromDB();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            FormOkToDB = !FormOkToDB;
            if (Page.IsPostBack && CheckForm() && FormOkToDB)
            {
                LastPostRequest = DateTime.Now;
                GetAllValue();
                // ClearForm();
                AreaErrorMsg.Text = "";
                msg.InnerText = "ההרשמה התבצעה בהצלחה!";
            }

        }
        private void ClearForm()
        {
            AreaErrorMsg.Text = "";
            Firstname.Text = "";
            Lastname.Text = "";
            Firstnameeng.Text = "";
            Lastnameeng.Text = "";
            Email.Text = "";
            Phone.Text = "";
            Employer.Text = "";
            DropDownListOccupation.SelectedIndex = 0; // occupation
            DropDownListReference.SelectedIndex = 0; // reference

            foreach (ListItem item in CheckBoxListAreas.Items) // activityAreas
            {
                if (item.Selected)
                {
                    item.Selected = false;
                }

            }
        }
        private void GetAllValue()
        {
            string firstnamevalue = Firstname.Text.ToString();
            string firstnameEngValue = Firstnameeng.Text.ToString();
            string lastnamevalue = Lastname.Text.ToString();
            string lastnameEngValue = Lastnameeng.Text.ToString();
            string emailvalue = Email.Text.ToString();
            string phonevalue = Phone.Text.ToString();
            string employervalue = Employer.Text.ToString();
            string occupation = DropDownListOccupation.SelectedValue.ToString();
            string reference = DropDownListReference.SelectedValue.ToString();
            foreach (ListItem item in CheckBoxListAreas.Items) // something didn't work for me, did the same thing below -חן
            {
                if (item.Selected)
                {
                    string activityAreas = item.Text.ToString();
                }

            }

            // get all selected from checkbox
            List<ListItem> selectedAreas = new List<ListItem>();
            List<int> SelectedAreas = new List<int>();
            foreach (ListItem item in CheckBoxListAreas.Items)
            {
                if (item.Selected)
                {
                    SelectedAreas.Add(int.Parse(item.Value) + 1);
                }
            }

            /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
            /*
            TODO :
            check PreferTraninigArea 
            */

            int PreferTraninigArea = DropDownListTraining.SelectedIndex;
            Volunteer NewVolunterr = new Volunteer(firstnamevalue, firstnameEngValue, lastnamevalue,
                lastnameEngValue, emailvalue, phonevalue, occupation, reference, SelectedAreas, employervalue, 0, PreferTraninigArea);
            db.InsetNewVolunteer(NewVolunterr);
        }
        private bool CheckAreaCheckList()
        {
            bool result = false;
            foreach (ListItem item in CheckBoxListAreas.Items)
            {
                if (item.Selected)
                {
                    result = true;
                }

            }
            return result;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        private bool CheckForm()
        {
            //check all fields for empty / nullable
            if (Firstname == null ||
                Lastname == null ||
                Email == null ||
                Phone == null ||
                DropDownListOccupation == null ||
                Employer == null ||
                DropDownListReference == null ||
                CheckBoxListAreas == null
                )
                return false;
            bool IsAreaChecked = CheckAreaCheckList();
            if (!IsAreaChecked)
            {
                AreaErrorMsg.Text = "חובה לבחור לפחות אזור אחד";
                return false;
            }

            return true;
        }
        public void GetItemsFromDB()
        {
            // Activity Areas to checkboxlist (multiple choice)

            if (CheckBoxListAreas.Items.Count < 1)
            {
                for (int i = 0; i < Areas.Count; i++)
                {
                    CheckBoxListAreas.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
                    DropDownListTraining.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
                }

            }

            // Occupations to dropdownlist
            List<ListItem> occupations = GetAllOccupation();
            if (DropDownListOccupation.Items.Count < 1)
            {
                foreach (ListItem occName in occupations)
                {
                    DropDownListOccupation.Items.Add(occName);
                }
            }

            // Reference to dropdownlist
            List<ListItem> references = GetAllReference();
            if (DropDownListReference.Items.Count < 1)
            {
                foreach (ListItem refName in references)
                {
                    DropDownListReference.Items.Add(refName);
                }
            }
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
            listItems.Add(new ListItem("בחרי"));
            listItems.Add(new ListItem("פייסבוק"));
            listItems.Add(new ListItem("מכרים"));
            listItems.Add(new ListItem("עבודה"));
            return listItems;


        }
    }
}