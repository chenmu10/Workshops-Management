using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Workshop
{
    public partial class WorkshopsView : System.Web.UI.Page
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
        private void FillTable()
        {
            CompanyWorkshopsJoin = db.GetAllWorkshopsByJoin();
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
                Editbtn.Click += new EventHandler(MoreInfo_button);
                Editbtn.Text = "צפייה";
                Editbtn.Attributes.Add("WorkshopID", t.WorkShop_ID.ToString());
                Editbtn.Attributes.Add("IsCompany", t.Is_company.ToString());
                Editbtn.CssClass = "btn btn-default";

                Edit.Controls.Add(Editbtn);
                row.Cells.Add(Edit);
              
                workshopTable.Rows.Add(row);
            }

        }
        protected void NewComapnyWorkshop_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Workshop/newCompanyWorkshop.aspx", false);
        }
        protected void MoreInfo_button(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            string IsCompany = selectedButton.Attributes["IsCompany"].ToString();
            string WorkshopID = selectedButton.Attributes["WorkshopID"].ToString();
            Session["IsCompany"] = IsCompany;
            Session["WorkshopID"] = WorkshopID;
            if (bool.Parse(IsCompany))
            {
                Response.Redirect("../Workshop/CompanyWorkshopEditInfo.aspx", false);
            }
            else
            {
                Response.Redirect("../Workshop/SchoolWorkshopEditInfo.aspx", false);
            }


        }
        protected void Filter_Click(object sender, EventArgs e)
        {

        }

      
    }
}