using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class PrepareForm
    {
        public int Prepare_School_WorkShop_ID;
        public int WorkShop_Number_Of_Final_Student;
        public int WorkShop_Number_Of_emulator_Computer;
        public bool WorkShop_Is_Projector;
        public bool WorkShop_Did_Preparation;
        public bool WorkShop_Is_Seniors_Coming;
        public bool WorkShop_Is_Video_possible;
        public string WorkShop_Comments;
        public string WorkShop_Teacher_Name;
        public string WorkShop_Teacher_phone;
        public string WorkShop_Teacher_Email;
        public int Workshop_School_Workshop_ID;
        public string WorkShop_Parking;
        public PrepareForm() { }
        public PrepareForm(DataRow row)
        {
            Prepare_School_WorkShop_ID = row["Prepare_ID"].ToString().Equals("") ? 0 : int.Parse(row["Prepare_ID"].ToString());
            WorkShop_Number_Of_Final_Student = row["WorkShop_Number_Of_Final_Student"].ToString().Equals("") ? 0 : int.Parse(row["WorkShop_Number_Of_Final_Student"].ToString());
            WorkShop_Number_Of_emulator_Computer = row["WorkShop_Number_Of_emulator_Computer"].ToString().Equals("") ? 0 : int.Parse(row["WorkShop_Number_Of_emulator_Computer"].ToString());

            WorkShop_Is_Projector = bool.Parse(row["WorkShop_Is_Projector"].ToString());
            WorkShop_Did_Preparation = bool.Parse(row["WorkShop_Did_Preparation"].ToString());
            WorkShop_Is_Seniors_Coming = bool.Parse(row["WorkShop_Is_Seniors_Coming"].ToString());
            WorkShop_Is_Video_possible = bool.Parse(row["WorkShop_Is_Video_possible"].ToString());

            WorkShop_Comments=row["WorkShop_Comments"].ToString().Equals("") ? "" : row["WorkShop_Comments"].ToString();
            WorkShop_Teacher_Name = row["WorkShop_Teacher_Name"].ToString().Equals("") ? "" : row["WorkShop_Teacher_Name"].ToString();
            WorkShop_Teacher_phone = row["WorkShop_Teacher_phone"].ToString().Equals("") ? "" : row["WorkShop_Teacher_phone"].ToString();
            WorkShop_Teacher_Email = row["WorkShop_Teacher_Email"].ToString().Equals("") ? "" : row["WorkShop_Teacher_Email"].ToString();
            Workshop_School_Workshop_ID = row["Workshop_School_Workshop_ID"].ToString().Equals("") ? 0 : int.Parse(row["Workshop_School_Workshop_ID"].ToString());
            WorkShop_Parking = row["WorkShop_Parking"].ToString().Equals("") ? "" : row["WorkShop_Parking"].ToString();

        }
    }
    
}