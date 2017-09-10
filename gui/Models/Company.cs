using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class Company
    {
        public int Company_ID;
        public string Company_Name;
        public string Company_Address;
        public string Company_Contact_Name;
        public string Company_Contact_phone;
        public string Company_Contact_Email;
        public int Company_Area_Activity;
        public Company() { }
        public Company(DataRow row)
        {
            Company_ID = int.Parse(row["Company_ID"].ToString());
            Company_Name = row["Company_Name"].ToString();
            Company_Address = row["Company_Address"].ToString();
            Company_Contact_Name = row["Company_Contact_Name"].ToString();
            Company_Contact_phone = row["Company_Contact_phone"].ToString();
            Company_Contact_Email = row["Company_Contact_Email"].ToString();
            Company_Area_Activity = int.Parse(row["Company_Area_Activity"].ToString());
        }
    }
}