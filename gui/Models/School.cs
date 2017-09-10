using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class School
    {
        public int School_ID;
        public int School_Serial_Number;
        public string School_Name;
        public string School_Address;
        public string School_City;
        public int School_Area;
        public string School_Contact_Name;
        public string Scool_Contact_Phone;
        public string School_Contact_Email;
        public string School_Supervisor_Name;
        public string School_Supervisor_Phone;
        public string School_Parking_Info;
        public School() { }
        public School(int schoolId,int schoolSerial,
            string schoolName,string schoolAdress,
            int schoolArea, string schoolCity,
            string schoolContantName, 
            string schoolContactPhone,
            string schoolContactEmail,
            string schoolSupervisorName,
            string schoolSupervisorPhone,
            string _School_Parking_Info)
        {
            School_ID = schoolId;
            School_Serial_Number = schoolSerial;
            School_Name = schoolName;
            School_Address = schoolAdress;
            School_Area = schoolArea;
            School_City = schoolCity;
            School_Contact_Name = schoolContantName;
            Scool_Contact_Phone = schoolContactPhone;
            School_Contact_Email = schoolContactEmail;
            School_Supervisor_Name = schoolSupervisorName;
            School_Supervisor_Phone = schoolSupervisorPhone;
            School_Parking_Info = _School_Parking_Info;
    }
        public School(DataRow row)
        {

            School_ID = int.Parse(row["School_ID"].ToString());
            School_Serial_Number = int.Parse(row["School_serial_Number"].ToString());
            School_Name = row["School_Name"].ToString();
            School_Address = row["School_Address"].ToString();
            School_Area = int.Parse(row["School_Area_Activity"].ToString());
            School_Contact_Name = row["School_Contact_Name"].ToString();
            Scool_Contact_Phone = row["School_Contact_phone"].ToString();
            School_Contact_Email = row["School_Contact_Email"].ToString();
            School_City = row["School_City"].ToString();
            School_Supervisor_Name = row["School_Computer_Supervisor_Name"].ToString();
            School_Supervisor_Phone = row["School_Computer_Supervisor_Phone"].ToString();
            School_Parking_Info = row["School_Parking_Info"].ToString();
        }
    }
}