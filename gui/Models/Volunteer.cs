using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class Volunteer
    {
        public int Volunteer_ID;
        public int Volunteer_Practice;
        public string Volunteer_First_Name;
        public string Volunteer_First_Name_Eng;
        public string Volunteer_Last_Name;
        public string Volunteer_Last_Name_Eng;
        public string Volunteer_Email;
        public string Volunteer_phone;
        public string Volunteer_Occupation;
        public string Volunteer_Reference;
        public List<int> Volunteer_Area_Activity;
        public string Volunteer_Employer;
        public int Volunteer_Number_Of_Activities;
        public int Volunteer_prefer_traning_area;
        public Volunteer(DataRow row)
        {
            Volunteer_ID = int.Parse(row["Volunteer_ID"].ToString());
            Volunteer_Practice = int.Parse(row["Volunteer_Practice"].ToString());
            Volunteer_First_Name = row["Volunteer_First_Name"].ToString();
            Volunteer_First_Name_Eng = row["Volunteer_First_Name_Eng"].ToString(); ;
            Volunteer_Last_Name = row["Volunteer_Last_Name"].ToString();
            Volunteer_Last_Name_Eng = row["Volunteer_Last_Name_Eng"].ToString();
            Volunteer_Email = row["Volunteer_Email"].ToString();
            Volunteer_phone = row["Volunteer_phone"].ToString();
            Volunteer_Occupation = row["Volunteer_Occupation"].ToString();
            Volunteer_Reference = row["Volunteer_Reference"].ToString();
            Volunteer_Employer = row["Volunteer_Employer"].ToString();
            Volunteer_Number_Of_Activities = int.Parse(row["Volunteer_Number_Of_Activities"].ToString());
            Volunteer_prefer_traning_area = int.Parse(row["Volunteer_prefer_traning_area"].ToString());
        }
        public Volunteer() {

        Volunteer_First_Name="";
        Volunteer_First_Name_Eng = "";
        Volunteer_Last_Name = "";
        Volunteer_Last_Name_Eng = "";
        Volunteer_Email = "";
        Volunteer_phone = "";
        Volunteer_Occupation = "";
        Volunteer_Reference = "";
        Volunteer_Employer = "";
    }
        public Volunteer(string _First_Name,string _First_Name_Eng,string _Last_Name,string _Last_Name_Eng,string _Email,
         string _phone,string _Occupation,string _Reference,List<int> _Area_Activity,string _Employer,int _Number_Of_Activities,
         int _Volunteer_prefer_traning_area)
        {
            Volunteer_Practice = 1;
            Volunteer_First_Name = _First_Name;
            Volunteer_First_Name_Eng = _First_Name_Eng;
            Volunteer_Last_Name = _Last_Name;
            Volunteer_Last_Name_Eng = _Last_Name_Eng;
            Volunteer_Email = _Email;
            Volunteer_phone = _phone;
            Volunteer_Occupation = _Occupation;
            Volunteer_Reference = _Reference;
            Volunteer_Area_Activity = _Area_Activity;
            Volunteer_Employer = _Employer;
            Volunteer_Number_Of_Activities = 0;
            Volunteer_prefer_traning_area = _Volunteer_prefer_traning_area;
    }
    }
}