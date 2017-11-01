using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui
{
    public partial class SchoolsView : System.Web.UI.Page
    {
        List<School> Schools = new List<School>();
        Dictionary<int, string> Areas = new Dictionary<int, string>();
        Dictionary<int, string> ListStatus = new Dictionary<int, string>();
        DB db;

        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            db = new DB();
            db.IsConnect();

            Schools = db.GetAllSchools();
            FillFilterDropdowns();
            FillTable(Schools);

        }

        private void FillTable(List<School> schools)
        {

            bool managerOk = false;
            if (db.IsManager(Session["Manager"]))
            {
                managerOk = true;
                expot.Visible = true;
            }

            Areas = db.GetAreaActivity();
            ListStatus = db.GetVolunteerStatus();

            TableRow row0 = ScoolsTable.Rows[0];
            ScoolsTable.Rows.Clear();
            ScoolsTable.Rows.Add(row0);

            int index = 1;
            foreach (School School in Schools)
            {

                TableCell id = new TableCell();
                id.Text = index.ToString();
                index++;

                TableCell Name = new TableCell();
                Name.Text = School.School_Name;

                TableCell Symbol = new TableCell();
                Symbol.Text = School.School_Serial_Number.ToString(); ;

                TableCell Area = new TableCell();
                Area.Text = Areas[School.School_Area];

                TableCell Address = new TableCell();
                Address.Text = School.School_Address;

                TableCell ContectName = new TableCell();
                ContectName.Text = School.School_Contact_Name;

                TableCell ContectEmail = new TableCell();
                ContectEmail.Text = School.School_Contact_Email;

                TableCell ContectPhone = new TableCell();
                ContectPhone.Text = School.Scool_Contact_Phone;

                TableCell Edit = new TableCell();
                Button Editbtn = new Button();
                Editbtn.Text = "צפייה";
                Editbtn.CssClass = "btn btn-default";
                Editbtn.ID = School.School_ID.ToString() + "s";
                Editbtn.Click += new EventHandler(MoreInfo_button);
                Edit.Controls.Add(Editbtn);

                if (managerOk)
                {
                    Button EditbtnManager = new Button();
                    EditbtnManager.ID = School.School_ID.ToString();
                    EditbtnManager.Click += new EventHandler(MoreInfo_button);
                    EditbtnManager.Text = "עריכה";
                    EditbtnManager.CssClass = "btn btn-default";
                    Edit.Controls.Add(EditbtnManager);
                }
                TableRow TableRow = new TableRow();

                TableRow.Cells.Add(id);
                TableRow.Cells.Add(Name);
                TableRow.Cells.Add(Symbol);
                TableRow.Cells.Add(Area);
                TableRow.Cells.Add(Address);
                TableRow.Cells.Add(ContectName);
                TableRow.Cells.Add(ContectPhone);
                TableRow.Cells.Add(ContectEmail);

                TableRow.Cells.Add(Edit);

                ScoolsTable.Rows.Add(TableRow);
            }
            Sum.Text = "";
            Sum.Text = "כמות : ";
            Sum.Text += string.Format("{0}", Schools.Count());

        }


        protected void MoreInfo_button(object sender, EventArgs e)
        {
            int btnID = int.Parse(((Button)sender).ID.Replace('s', ' '));
            Session["SelectedSchool"] = btnID;
            Response.Redirect("SchoolEditInfo.aspx", false);

        }

        public void FillFilterDropdowns()
        {
            List<ListItem> Areas = db.GetAllAreas();
            for (int i = 0; i < Areas.Count; i++)
            {
                DropDownListAreas.Items.Add(new ListItem(Areas[i].Text, i.ToString()));
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            Schools = db.GetAllSchools();
            string name = nameText.Text;
            string symbol = symbolText.Text;
            if (!name.Equals(""))
            {
                Schools = Schools.FindAll(x => x.School_Name.ToUpper().Contains(name.ToUpper()) || x.School_Contact_Name.ToUpper().Contains(name.ToUpper()) ||
                 x.School_Contact_Email.ToUpper().Contains(name.ToUpper()) || x.School_Address.ToUpper().Contains(name.ToUpper())
                ).ToList();

            }
            if (!symbol.Equals(""))
            {
                int symbolNum;
                try
                {
                    symbolNum = int.Parse(symbol);
                    Schools = Schools.FindAll(x => x.School_Serial_Number == symbolNum).ToList();
                }
                catch (Exception exp)
                {
                }

            }
            FillTable(Schools);
        }

        protected void filter_Click(object sender, EventArgs e)
        {
            int areaindex = DropDownListAreas.SelectedIndex;
            if (areaindex == 0)
            {
                ErrorMsg(1);
                return;
            }
            Schools = db.GetAllSchools();
            Schools = Schools.Where(x => x.School_Area == areaindex).ToList();
            FillTable(Schools);

        }
        private void ErrorMsg(int i)
        {
            string str;
            switch (i)
            {
                case 1:
                    str = "יש לבחור איזור על מנת לסנן";
                    Response.Write("<script>alert('" + str + "');</script>");
                    break;

            }
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<System.Web.UI.WebControls.ListItem> Areas = db.GetAllAreas();

            string path = Server.MapPath("SchooReport.csv");
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                using (System.IO.StreamWriter filewriter = new System.IO.StreamWriter(path, true, Encoding.UTF8))
                {
                    filewriter.WriteLine("School Name, Symbol, Area, Address, Contact Name, Contact Email, Contact Phone");
                    List<School> Data = new List<School>();
                    Schools = db.GetAllSchools();
                    int areaindex = DropDownListAreas.SelectedIndex;
                    string name = nameText.Text;
                    string symbol = symbolText.Text;

                    if (areaindex != 0)
                    {
                        Data = Schools.Where(x => x.School_Area == areaindex).ToList();
                    } // if
                    else if (!name.Equals("") || !symbol.Equals(""))
                    {
                        if (!name.Equals(""))
                            Data = Schools.FindAll(x => x.School_Name.Contains(name) || x.School_Contact_Name.Contains(name) ||
                                     x.School_Contact_Email.Contains(name) || x.School_Address.Contains(name)
                                    ).ToList();
                        if (!symbol.Equals(""))
                        {
                            int symbolNum = int.Parse(symbol);
                            Data = Schools.FindAll(x => x.School_Serial_Number == symbolNum).ToList();
                        }
                    }
                    else
                    {
                        Data = Schools;
                    }

                    foreach (School com in Data)
                    {
                        try
                        {
                            name = com.School_Name.Replace(',', ' ');
                            string Symbol = com.School_Serial_Number.ToString();
                            string Area = Areas[com.School_Area - 1].ToString().Replace(',', ' ');
                            string address = com.School_Address.Replace(',', ' ');
                            string Cname = com.School_Contact_Name.Replace(',', ' ');
                            string CEmail = com.School_Contact_Email.Replace(',', ' ');
                            string CPhone = com.Scool_Contact_Phone.Replace(',', ' ');
                            string str =
                                String.Format("{0},{1},{2},{3},{4},{5},{6}",
                                name,
                                Symbol,
                                Area,
                                address,
                                Cname,
                                CEmail,
                                CPhone
                                );
                            filewriter.WriteLine(str);
                        }
                        catch(Exception ex)
                        {
                            filewriter.WriteLine(ex.ToString());
                        }
                    

                        
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
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.location.href = ''; </script>");
        }
    }
}