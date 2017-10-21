using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace gui.Models
{
    public class FeedBack
    {
        public int WorkShop_ID;
        public int WorkShop_Person;
        public bool WorkShop_Is_Volunteer;
        public bool WorkShop_Is_Company;
        public int WorkShop_Is_Teacher_present;
        public string WorkShop_Is_Teacher_present_Comment;
        public int WorkShop_Level_Of_Listening;
        public string WorkShop_Main_Issues_Difficulties;
        public string WorkShop_Technical_Faults;
        public string WorkShop_General_Comments;
        public int WorkShop_Choosing_technological;
        public int WorkShop_Activity_Again;
        public string WorkShop_Opinion;
        public string WorkShop_Improves;
        public string WorkShop_Additional_Comments;
        public int WorkShop_Post_Feedback;
        public FeedBack() { }
        public FeedBack(DataRow dt) {
            try
            {
                WorkShop_ID = dt["WorkShop_ID"] != null ? int.Parse(dt["WorkShop_ID"].ToString()) : 0;
                WorkShop_Person = dt["WorkShop_Person"] != null ? int.Parse(dt["WorkShop_Person"].ToString()) : 0;
                WorkShop_Is_Volunteer = dt["WorkShop_Is_Volunteer"] != null ? bool.Parse(dt["WorkShop_Is_Volunteer"].ToString()) : false;
                WorkShop_Is_Company = dt["WorkShop_Is_Company"] != null ? bool.Parse(dt["WorkShop_Is_Company"].ToString()) : false;
                WorkShop_Is_Teacher_present = dt["WorkShop_Is_Teacher_present"] != null ? int.Parse(dt["WorkShop_Is_Teacher_present"].ToString()) : 0;
                WorkShop_Is_Teacher_present_Comment = dt["WorkShop_Is_Teacher_present_Comment"] != null ? dt["WorkShop_Is_Teacher_present_Comment"].ToString() :"";
                WorkShop_Level_Of_Listening = dt["WorkShop_Level_Of_Listening"] != null ? int.Parse(dt["WorkShop_Level_Of_Listening"].ToString()) : 0;
                WorkShop_Main_Issues_Difficulties = dt["WorkShop_Main_Issues_Difficulties"] != null ? dt["WorkShop_Main_Issues_Difficulties"].ToString() : "";
                WorkShop_Technical_Faults = dt["WorkShop_Technical_Faults"] != null ? dt["WorkShop_Technical_Faults"].ToString() : "";
                WorkShop_General_Comments = dt["WorkShop_General_Comments"] != null ? dt["WorkShop_General_Comments"].ToString() : "";
                WorkShop_Choosing_technological = dt["WorkShop_Choosing_technological"] != null ? int.Parse(dt["WorkShop_Choosing_technological"].ToString()) : 0;
                WorkShop_Activity_Again = dt["WorkShop_Activity_Again"] != null ? int.Parse(dt["WorkShop_Activity_Again"].ToString()) : 0;
                WorkShop_Opinion = dt["WorkShop_Opinion"] != null ? dt["WorkShop_Opinion"].ToString() : "";
                WorkShop_Improves = dt["WorkShop_Improves"] != null ? dt["WorkShop_Improves"].ToString() : "";
                WorkShop_Additional_Comments = dt["WorkShop_Additional_Comments"] != null ? dt["WorkShop_Additional_Comments"].ToString() : "";
                WorkShop_Post_Feedback = dt["WorkShop_Post_Feedback"] != null ? int.Parse(dt["WorkShop_Post_Feedback"].ToString()) : 0;
            }
            catch(Exception e)
            {
                //Log
            }
        }
    }
    
}