using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class WorkshopJoin
    {
        public string WorkShop_ID;
        public string Status_Description;
        public string WorkShop_Date;
        public string School_Name;
        public string Company_Name;
        public string Volunteer1_Name;
        public string Volunteer2_Name;
        public string Volunteer3_Name;
        public string Volunteer4_Name;
        public bool Is_company;

        public WorkshopJoin(DataRow dr)
        {
            WorkShop_ID = dr["WorkShop_ID"].ToString();
            Status_Description = dr["Status_Description"].ToString();
            WorkShop_Date = dr["WorkShop_Date"].ToString();
            School_Name = dr["School_Name"].ToString();
            Company_Name = dr["Company_Name"].ToString();
            Volunteer1_Name = dr["Volunteer1_Name"].ToString();
            Volunteer2_Name = dr["Volunteer2_Name"].ToString();
            Volunteer3_Name = dr["Volunteer3_Name"].ToString();
            Volunteer4_Name = dr["Volunteer4_Name"].ToString();

        }
        public WorkshopJoin(DataRow dr,int x)
        {
            string isDateSelected;
            WorkShop_ID = dr["WorkShop_ID"].ToString();
            Status_Description = dr["Status_Description"].ToString();
            isDateSelected = dr["WorkShop_SelectedDate"].ToString();
            if (isDateSelected.Equals("0") || isDateSelected.Equals(""))
            {
                WorkShop_Date = "אין תאריך עדיין";
            }
            else
            {
                int index = int.Parse(isDateSelected);
                WorkShop_Date = dr["WorkShop_Date"+ index].ToString();
            }

            School_Name = dr["School_Name"].ToString();
            Company_Name = "-";
            Volunteer1_Name = dr["Volunteer1_Name"].ToString();
            Volunteer2_Name = dr["Volunteer2_Name"].ToString();
            Volunteer3_Name = dr["Volunteer3_Name"].ToString();
            Volunteer4_Name = dr["Volunteer4_Name"].ToString();
        }

        public WorkshopJoin()
        {
        }
    }
}