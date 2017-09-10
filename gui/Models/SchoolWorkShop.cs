using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class SchoolWorkShop
    {
        public int SchoolWorkShopID;
        public int SchoolWorkShopStatus;
        public string SchoolWorkShopDate1; 
        public string SchoolWorkShopDate2;
        public string SchoolWorkShopDate3;
        public int SchoolWorkShopSelectedDate;
        public int SchoolWorkShopVolunteerID1;
        public int SchoolWorkShopVolunteerID2;
        public int SchoolWorkShopVolunteerID3;
        public int SchoolWorkShopVolunteerID4;
        public int SchoolWorkShopStudentCount;
        public int SchoolWorkShopComputerCount;
        public string SchoolWorkShopComments;
        public string WorkShop_AMT_Contact_Name;
        public string WorkShop_AMT_Contact_phone;
        public string WorkShop_AMT_Contact_Email;
        public bool WorkShop_For_AMT_students;
        public int WorkShop_School_ID;

        public SchoolWorkShop() { }
        public SchoolWorkShop(DataRow dr)
        {
            SchoolWorkShopID = int.Parse(dr["WorkShop_ID"].ToString());
            SchoolWorkShopStatus = int.Parse(dr["WorkShop_Status"].ToString());
            SchoolWorkShopDate1 = dr["WorkShop_Date1"].ToString();
            SchoolWorkShopDate2 = dr["WorkShop_Date2"].ToString();
            SchoolWorkShopDate3 = dr["WorkShop_Date3"].ToString();
            string str = dr["WorkShop_SelectedDate"].ToString();
            if (str.Equals(""))
                SchoolWorkShopSelectedDate = 0;
            else
                 SchoolWorkShopSelectedDate = int.Parse(dr["WorkShop_SelectedDate"].ToString()); 

            SchoolWorkShopVolunteerID1 = dr["WorkShop_Volunteer1"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Volunteer1"].ToString());
            SchoolWorkShopVolunteerID2 = dr["WorkShop_Volunteer2"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Volunteer2"].ToString());
            SchoolWorkShopVolunteerID3 = dr["WorkShop_Volunteer3"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Volunteer3"].ToString());
            SchoolWorkShopVolunteerID4 = dr["WorkShop_Volunteer4"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Volunteer4"].ToString());
            SchoolWorkShopStudentCount = dr["WorkShop_Number_Of_StudentPredicted"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Number_Of_StudentPredicted"].ToString());
            SchoolWorkShopComputerCount = dr["WorkShop_Number_Of_Computers"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_Number_Of_Computers"].ToString()); 
            SchoolWorkShopComments = dr["WorkShop_Comments"].ToString();
            WorkShop_AMT_Contact_Name = dr["WorkShop_AMT_Contact_Name"].ToString();
            WorkShop_AMT_Contact_phone = dr["WorkShop_AMT_Contact_phone"].ToString();
            WorkShop_AMT_Contact_Email = dr["WorkShop_AMT_Contact_Email"].ToString();
            WorkShop_For_AMT_students = Boolean.Parse(dr["WorkShop_For_AMT_students"].ToString());
            WorkShop_School_ID = dr["WorkShop_School_ID"].ToString().Equals("") ? 0 : int.Parse(dr["WorkShop_School_ID"].ToString()); 
        }
        public SchoolWorkShop(string _Date1, string _Date2, string _Date3,int _StudentCount,int _ComputerCount,string _Comments,
           string _WorkShop_AMT_Contact_Name,string _WorkShop_AMT_Contact_phone,string _WorkShop_AMT_Contact_Email,bool _WorkShop_For_AMT_students,int _school_ID)
        {
            SchoolWorkShopDate1 = _Date1;
            SchoolWorkShopDate2 = _Date2;
            SchoolWorkShopDate3 = _Date3;
            SchoolWorkShopStudentCount = _StudentCount;
            SchoolWorkShopComputerCount = _ComputerCount;
            SchoolWorkShopComments = _Comments;
            WorkShop_AMT_Contact_Name = _WorkShop_AMT_Contact_Name;
            WorkShop_AMT_Contact_phone = _WorkShop_AMT_Contact_phone;
            WorkShop_AMT_Contact_Email = _WorkShop_AMT_Contact_Email;
            WorkShop_For_AMT_students = _WorkShop_For_AMT_students;
            WorkShop_School_ID = _school_ID;
        } 
    }
}