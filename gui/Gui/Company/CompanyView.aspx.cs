using gui.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class CompanyView : System.Web.UI.Page
    {
        List<Models.Company> companies = new List<Models.Company>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        DB db;
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();
            FillFilterDropdowns();
            companies = db.GetAllComapny();
            FillTable(companies);
        }

        public void FillTable(List<Models.Company> companies)
        {
            Areas = db.GetAreaActivity();

            TableRow row0 = companyTable.Rows[0];
            companyTable.Rows.Clear();
            companyTable.Rows.Add(row0);


            bool managerOk = false;
            if (db.IsManager(Session["Manager"]))
            {
                managerOk = true;
                expot.Visible = true;
            }

            foreach (Models.Company company in companies)
            {
                TableCell id = new TableCell();
                id.Text = company.Company_ID.ToString();

                TableCell Name = new TableCell();
                Name.Text = company.Company_Name;

                TableCell Address = new TableCell();
                Address.Text = company.Company_Address;

                TableCell Area = new TableCell();
                Area.Text = Areas[company.Company_Area_Activity];

                TableCell ContectName = new TableCell();
                ContectName.Text = company.Company_Contact_Name;

                TableCell ContectEmail = new TableCell();
                ContectEmail.Text = company.Company_Contact_Email;

                TableCell ContectPhone = new TableCell();
                ContectPhone.Text = company.Company_Contact_phone;

                TableCell Edit = new TableCell();
                Button Editbtn = new Button();
                Editbtn.ID = company.Company_ID.ToString();
                Editbtn.Click += new EventHandler(MoreInfo_button);
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Edit.Controls.Add(Editbtn);

                if (managerOk)
                {
                    Button EditbtnManager = new Button();
                    EditbtnManager.ID = company.Company_ID.ToString() + "s";
                    EditbtnManager.Click += new EventHandler(MoreInfo_button);
                    EditbtnManager.Text = "עריכה";
                    EditbtnManager.CssClass = "btn btn-default";
                    Edit.Controls.Add(EditbtnManager);
                }

                TableRow TableRow = new TableRow();
                TableRow.Cells.Add(Name);
                TableRow.Cells.Add(Address);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(ContectName);
                TableRow.Cells.Add(ContectPhone);
                TableRow.Cells.Add(ContectEmail);

                TableRow.Cells.Add(Edit);

                companyTable.Rows.Add(TableRow);
            }
            Sum.Text = "";
            Sum.Text = "כמות : ";
            Sum.Text += string.Format("{0}", companies.Count());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void newComapnyWorkshopBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewCompanyForm.aspx", false);
        }
        public List<Models.Company> Filter_Click_View()
        {
            List<Models.Company> result = db.GetAllComapny();
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();
            if (DropDownListAreas.SelectedIndex!=0)
            {
                int index = DropDownListAreas.SelectedIndex;
                result = result.Where(x => x.Company_Area_Activity == index).ToList();
            }
            return result;

        }
        protected void MoreInfo_button(object sender, EventArgs e)
        {
            string key = ((Button)sender).ID.ToString();
            Session["SelectedCompany"] = key;
            Response.Redirect("../Company/EditInfoForCompany.aspx", false);            
        }

        public void FillFilterDropdowns()
        {
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();
            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListAreas.Items.Add(new System.Web.UI.WebControls.ListItem(Areas[i].Text, i.ToString()));
            }

        }

        protected void expot_Click(object sender, EventArgs e)
        {

        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();

            string path = Server.MapPath("..\\..\\Content\\Report.csv"); 
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                using (System.IO.StreamWriter filewriter = new System.IO.StreamWriter(path, true, Encoding.UTF8))
                {
                    filewriter.WriteLine("Company Name,Address,Area,Contant,Phone,Email");
                    List<Models.Company> Data = new List<Models.Company>();
                    if(DropDownListAreas.SelectedIndex!=0)
                    {
                        Data = Filter_Click_View();
                    
                    } // if
                    else if (!NameInput.Text.Equals("")) {
                        Data = Sreach_Click_View();
                    }
                    else
                    {
                        Data = db.GetAllComapny();
                    }

                    foreach (Models.Company com in Data)
                    {
                        string name = com.Company_Name.Replace(',', ' ');
                        string address = com.Company_Address.Replace(',', ' ');
                        string area = Areas[com.Company_Area_Activity - 1].ToString();
                        string Cname = com.Company_Contact_Name.Replace(',', ' ');
                        string Cphone = com.Company_Contact_phone.Replace(',', ' ');
                        string email = com.Company_Contact_Email.Replace(',', ' ');
                        area.Replace(',', ' ');
                        string str =
                            String.Format("{0},{1},{2},{3},{4},{5}",
                            name,
                            address,
                            area,
                            Cname,
                            Cphone,
                            email);

                        filewriter.WriteLine(str);
                    }
                }
                System.IO.FileInfo file = new System.IO.FileInfo(path); //get file object as FileInfo
                if (file.Exists) //-- if the file exists on the server
                {
                    Response.Clear(); //set appropriate headers
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/....";
                    Response.WriteFile(file.FullName);
                    Response.End(); //if file does not exist
                }
                else
                {
                    Response.Write("This file does not exist.");
                }
            }
            catch (Exception exp)
            {
            }
     }
        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //GridView1.AllowPaging = false;
            //GridView1.DataBind();
            //GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }


        protected void filter_Click(object sender, EventArgs e)
        {
            FillTable(Filter_Click_View());
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href = ''; </script>");
        }

        protected void search_Click(object sender, EventArgs e)
        {
            FillTable(Sreach_Click_View());
        }

        private List<Models.Company> Sreach_Click_View()
        {
            List<Models.Company> result = db.GetAllComapny();
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();
            if (!NameInput.Text.Equals(""))
            {
                string searchText = NameInput.Text;
                result = result.Where(x => x.Company_Name.Contains(searchText) ||
                x.Company_Contact_Name.Contains(searchText) ||
                x.Company_Address.Contains(searchText)
                ).ToList();
            }
            return result;
        }
    }

}
