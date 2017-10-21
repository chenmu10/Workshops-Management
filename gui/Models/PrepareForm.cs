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
        public string WorkShop_Computer_Manager_Phone;
        public bool Workshop_Is_All_Student_Answer_PerWorkshop;
        public bool Workshop_Is_All_Student_Gmail;

        public PrepareForm() { }
        public PrepareForm(int School_ID,int Workshop_ID)
        {
            Prepare_School_WorkShop_ID = School_ID;
            WorkShop_Number_Of_Final_Student=0;
            WorkShop_Number_Of_emulator_Computer=0;
            WorkShop_Is_Projector=false;
            WorkShop_Did_Preparation=false;
            WorkShop_Is_Seniors_Coming=false;
            WorkShop_Is_Video_possible=false;
            WorkShop_Comments="";
            WorkShop_Teacher_Name="";
            WorkShop_Teacher_phone="";
            WorkShop_Teacher_Email="";
            Workshop_School_Workshop_ID= Workshop_ID;
            WorkShop_Parking="";
            WorkShop_Computer_Manager_Phone = "";
            Workshop_Is_All_Student_Answer_PerWorkshop = false;
            Workshop_Is_All_Student_Gmail = false;
    }
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

            WorkShop_Computer_Manager_Phone = row["WorkShop_Computer_Manager_Phone"].ToString().Equals("") ? "" : row["WorkShop_Computer_Manager_Phone"].ToString();
            Workshop_Is_All_Student_Answer_PerWorkshop = bool.Parse(row["Workshop_Is_All_Student_Answer_PerWorkshop"].ToString());
            Workshop_Is_All_Student_Gmail = bool.Parse(row["Workshop_Is_All_Student_Gmail"].ToString());


        }
    }
    
}