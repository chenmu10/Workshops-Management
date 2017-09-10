using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class CompanyWorkshop
    {
        public int CompanyWorkShopID;
        public int CompanyWorkShopStatus;
        public string CompanyWorkShopDate;
        public int WorkShop_Number_Of_StudentPredicted;
        public int WorkShop_Number_Of_Final_Student;
        public int CompanyWorkShopVolunteerID1;
        public int CompanyWorkShopVolunteerID2;
        public int CompanyWorkShopVolunteerID3;
        public int CompanyWorkShopVolunteerID4;    
        public string CompanyWorkShopComments;
        public string WorkShop_School_Comment;
        public int CompanyID;
        public int CompanySchoolID;
        public CompanyWorkshop(DataRow dr)
        {
            CompanyWorkShopID = int.Parse(dr["WorkShop_ID"].ToString());
            CompanyWorkShopStatus = int.Parse(dr["WorkShop_Status"].ToString());
            CompanyWorkShopDate = dr["WorkShop_Date"].ToString();
            WorkShop_Number_Of_StudentPredicted = int.Parse(dr["WorkShop_Number_Of_StudentPredicted"].ToString());
            WorkShop_Number_Of_Final_Student = int.Parse(dr["WorkShop_Number_Of_Final_Student"].ToString());
            CompanyWorkShopVolunteerID1 = int.Parse(dr["WorkShop_Volunteer1"].ToString());
            CompanyWorkShopVolunteerID2 = int.Parse(dr["WorkShop_Volunteer2"].ToString());
            CompanyWorkShopVolunteerID3 = int.Parse(dr["WorkShop_Volunteer3"].ToString());
            CompanyWorkShopVolunteerID4 = int.Parse(dr["WorkShop_Volunteer4"].ToString());
            CompanyWorkShopComments = dr["WorkShop_Comments"].ToString();
            WorkShop_School_Comment = dr["WorkShop_School_Comments"].ToString();
            CompanyID = int.Parse(dr["WorkShop_Company_ID"].ToString());
            CompanySchoolID = int.Parse(dr["WorkShop_School_ID"].ToString());
        }
        public CompanyWorkshop() { }
    }
}