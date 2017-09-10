using gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gui.Gui.Documents
{
        // TODO volunteer id should also appear in url so we can use it here
        // TODO db.insert new volunteer feedback 
        // TODO db.isFeedbackExist, db.GetVolNameByID, GetCompanyByID

        public partial class FeedbackVolunteer : System.Web.UI.Page
        {
            DB db;
            DateTime LastPostRequest;

            int idFromUrl = 2; //test value. change to: Convert.ToInt32(RouteData.Values["id"] + Request.Url.Query);

            override protected void OnInit(EventArgs e)
            {
                LastPostRequest = DateTime.Now;
                this.Load += new System.EventHandler(this.Page_Load);
                db = new DB();
                db.IsConnect();
            }

            protected void Page_Load(object sender, EventArgs e)
            {

                FillWorkshopData();

                if (Page.IsPostBack && IsFormValid())
                {
                    LastPostRequest = DateTime.Now;

                    // Feedback newVFeedback = AddValuesToFeedback();

                    //msg.Text = "טופס תקין, פונקצית הכנסה עוד לא הופעלה";

                    //if (db.isFeedbackExist(newVFeedback))
                    //{
                    //    Response.Write("<script>alert('משוב קיים. ניתן למלא רק פעם אחת.');</script>");
                    //}
                    //else if (db.insertFeedbackToDB(newVFeedback))
                    //{
                    //    Response.Redirect("SuccessForm.aspx", false);
                    //}
                    //else
                    //{
                    //    Response.Write("<script>alert('שגיאה בהכנסה ל-DB');</script>");
                    //}

                }


            }

            private void FillWorkshopData()
            {
                //Workshop ws = db.GetWorkshopByID(idFromUrl);
                //School sc = db.GetSchoolByID(ws.WorkShop_School_ID);
                ////Company cm = db.GetCompanyByID(ws.WorkShop_School_ID);
                ////string volunteerName = db.GetVolNameByID(volIDFromUrl);
                //workshopID.InnerText = Convert.ToString(ws.WorkShop_ID);
                //schoolName.InnerText = sc.School_Name;
                //address.InnerText = sc.School_Address;
                //date.InnerText = Convert.ToString(ws.WorkShop_Date.ToShortDateString());
                // volName.InnerText = db.GetVolNameByID(volIDFromUrl);

                // if it's company workshop:
                // companyName.InnerText = cm.Company_Name;
                // address.InnerText = cm.Company_Address;

            }

            private bool IsFormValid()
            {
                if (RadioButtonListteachePresent.SelectedIndex == -1 ||
                    RadioButtonListlistenLevel.SelectedIndex == -1 ||
                    String.IsNullOrWhiteSpace(difficulties.Text) ||
                    String.IsNullOrWhiteSpace(techProblems.Text) ||
                    String.IsNullOrWhiteSpace(comments.Text))
                {
                    msg.Text = "שדות ריקים בטופס";
                    return false;
                }
                else
                {
                    return true;
                }

            }

            //private Feedback AddValuesToFeedback()
            //{
            //    //1. create new feedback object
            //    //2. insert values
            //    //3. return feedback object

            //}

            private void ClearForm()
            {
                difficulties.Text = String.Empty;
                techProblems.Text = String.Empty;
                comments.Text = String.Empty;
                RadioButtonListlistenLevel.SelectedIndex = -1;
                RadioButtonListteachePresent.SelectedIndex = -1;

            }
        }

    }
