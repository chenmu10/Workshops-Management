
using ExcelDataReader;
using gui.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace gui
{
    class DB
    {
        string query;
        string query2;

         // Connection 
        public DB()
        {
     
        }
        public string DatabaseName = "MMT_DB";
        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }
        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    result = false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=myroot ; charset=utf8;", DatabaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();

                result = true;
            }

            return result;
        }
        public void Close()
        {
            connection.Close();
        }
        public bool IsManager(object o)
        {
            bool result = false;
            if (o != null)
            {
                string key = o.ToString();
                if (key.Equals("bxvkeqayl6pwtro97k21"))
                {
                    return true;
                }
            }
            return result;
        }

        #region Volunteer_Form
        public List<ListItem> GetAllAreas()
        {
            List<ListItem> listItems = new List<ListItem>();

            query = string.Format("SELECT * FROM Area_Activity");
            DataTable dt = Select(query);
            if (dt != null)
            {
                int index = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    listItems.Add(new ListItem(dr["Area_Activity_Description"].ToString(), dr["Area_Activity_ID"].ToString()));
                    index++;
                }
            }
            return listItems;
        }
        /// <summary>
        /// Request all volunteers
        /// </summary>
        /// <returns></returns>
        public List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> result = new List<Volunteer>();
            query = string.Format("SELECT * FROM volunteer");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Volunteer volunteer = new Volunteer(dr);
                    volunteer.Volunteer_Area_Activity = new List<int>();
                    query2 = string.Format("SELECT * FROM VolunteerToAreas WHERE Volunteer_ID='{0}'", volunteer.Volunteer_ID);
                    DataTable dt2 = Select(query2);
                    if (dt2 != null)
                    {
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            Int16 area = Int16.Parse((dr2["Volunteer_Area_Activity"]).ToString());
                            volunteer.Volunteer_Area_Activity.Add(area);
                        }
                    }
                    result.Add(volunteer);
                }
            }


            return result;
        }
        public List<Volunteer> gettAllNewVolunteers()
        {
            List<Volunteer> result = new List<Volunteer>();
            query = string.Format("SELECT * FROM volunteer WHERE Volunteer_Is_Active = False;");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Volunteer volunteer = new Volunteer(dr);
                    volunteer.Volunteer_Area_Activity = new List<int>();
                    query2 = string.Format("SELECT * FROM VolunteerToAreas WHERE Volunteer_ID='{0}'", volunteer.Volunteer_ID);
                    DataTable dt2 = Select(query2);
                    if (dt2 != null)
                    {
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            Int16 area = Int16.Parse((dr2["Volunteer_Area_Activity"]).ToString());
                            volunteer.Volunteer_Area_Activity.Add(area);
                        }
                    }
                    result.Add(volunteer);
                }
            }
            return result;
        }
        public List<Volunteer> GetAllVolunteersWithTraining(Boolean is_pass_traning)
        {
            List<Volunteer> result = new List<Volunteer>();

            if (is_pass_traning)
                query = string.Format("SELECT * FROM volunteer where Volunteer_Practice = 2  "); //Pass Traning
            else
                query = string.Format("SELECT * FROM volunteer where Volunteer_Practice = 1  "); // didnt pass traning
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new Volunteer(dr));
                }
            }
            return result;
        }
        public Boolean IsVolunteerExist(Volunteer volunteer)
        {
            Boolean result = false;
            query = string.Format("SELECT * FROM volunteer where Volunteer_Email = '{0}'", Val(volunteer.Volunteer_Email)); // didnt pass traning
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var temp = dr;
                }
                if (dt.Rows.Count >= 1)
                    result = true;
            }
            return result;
        }

        /// <summary>
        /// Insert new Volunteer - ID must of null , and all infomation correct
        /// True - if update succeded 
        /// False - if update failed
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public Boolean InsertNewVolunteer(Volunteer volunteer,bool isActive)
        {
            try
            {
                query = string.Format(@"INSERT INTO Volunteer 
                VALUES(null,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{12},{11});",
                    volunteer.Volunteer_Practice,
                    Val(volunteer.Volunteer_First_Name),
                    Val(volunteer.Volunteer_First_Name_Eng),
                    Val(volunteer.Volunteer_Last_Name),
                    Val(volunteer.Volunteer_Last_Name_Eng),
                    Val(volunteer.Volunteer_Email),
                    Val(volunteer.Volunteer_phone),
                    Val(volunteer.Volunteer_Occupation),
                    Val(volunteer.Volunteer_Reference),
                    Val(volunteer.Volunteer_Employer), 
                    volunteer.Volunteer_Number_Of_Activities,
                    volunteer.Volunteer_prefer_traning_area,
                    isActive);
                log(query);
                query += "SELECT Volunteer_ID FROM mmt_db.volunteer order by Volunteer_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0)
                    return false;

                //Get volunteer ID
                volunteer.Volunteer_ID = row;


                foreach (int Area in volunteer.Volunteer_Area_Activity)
                {
                    query = string.Format(@"INSERT INTO VolunteerToAreas VALUES(null,{0},{1});", volunteer.Volunteer_ID, Area);
                    log(query);
                    if (!Update(query)) return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateVolunteer(Volunteer volunteer)
        {
            query = string.Format(@"UPDATE Volunteer 
            SET    
            Volunteer_First_Name ='{1}',
            Volunteer_First_Name_Eng ='{2}',
            Volunteer_Last_Name ='{3}',
            Volunteer_Last_Name_Eng ='{4}',
            Volunteer_Email ='{5}',
            Volunteer_phone ='{6}',
            Volunteer_Occupation ='{7}',
            Volunteer_Reference ='{8}',
            Volunteer_Employer ='{9}',
            Volunteer_Number_Of_Activities ={10},
            Volunteer_Is_Active = True,
            Volunteer_prefer_traning_area ={11},
            Volunteer_Practice ={12}
            WHERE Volunteer_ID = {0};",
                volunteer.Volunteer_ID,
                Val(volunteer.Volunteer_First_Name),
                Val(volunteer.Volunteer_First_Name_Eng),
                Val(volunteer.Volunteer_Last_Name),
                Val(volunteer.Volunteer_Last_Name_Eng),
                Val(volunteer.Volunteer_Email),
                Val(volunteer.Volunteer_phone),
                Val(volunteer.Volunteer_Occupation),
                Val(volunteer.Volunteer_Reference),
                Val(volunteer.Volunteer_Employer),
                volunteer.Volunteer_Number_Of_Activities,
                volunteer.Volunteer_prefer_traning_area,
                volunteer.Volunteer_Practice
                );
            return Update(query);
        }
        public bool clearAndUpdateVoulnteerAreaActivity(Volunteer volunteer)
        {
            try
            {
                query = string.Format(@"DELETE FROM mmt_db.volunteertoareas WHERE Volunteer_ID={0}; ", volunteer.Volunteer_ID);
                Select(query);
                foreach (int i in volunteer.Volunteer_Area_Activity)
                {
                    query = string.Format(@"INSERT INTO VolunteerToAreas VALUES(null,{0},{1}); ", volunteer.Volunteer_ID, i);
                    Insert(query);
                }
            }
            catch (Exception exp)
            {
                return false;
            }
            return true;

        }
        public Boolean UpdateVolunteerTraning(Volunteer volunteer, int new_status)
        {
            query = string.Format(@"UPDATE Volunteer SET Volunteer_Practice = {0} WHERE Volunteer_ID = {1};", new_status, volunteer.Volunteer_ID);
            return Update(query);
        }
        /// <summary>
        /// DELETE volunteer by volunter ID
        /// </summary>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public Boolean DeleteVolunteer(Volunteer volunteer)
        {
            query = string.Format(@"DELETE FROM Volunteer WHERE Volunteer_ID = {0};", volunteer.Volunteer_ID);
            return Update(query);
        }

        public Volunteer GetVolunteerByID(int ID)
        {
            Volunteer result = new Volunteer();
            query = string.Format("SELECT * FROM mmt_db.volunteer WHERE Volunteer_ID ={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new Volunteer(dr);
                }
            }
            return result;
        }
        public List<string> getallStatus()
        {
            List<string> result = new List<string>();
            query = string.Format("SELECT * FROM mmt_db.Volunteers_Practice;");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(dr["Volunteers_Practice_Description"].ToString());
                }
            }
            return result;
        }

        #endregion

        #region WorkShop
        public List<School> GetAllSchools()
        {
            List<School> result = new List<School>();
            query = string.Format("SELECT * FROM school");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new School(dr));
                }
            }
            return result;
        }
        public bool updateSchoolWorkshopVolunteer(int schoolWorkShopID, int iD1, int iD2, int iD3, string ride1, string ride2, string ride3)
        {
            string i1, i2, i3;
            if (iD1 == 0) i1 = "NULL";
            else
            {
                i1 = iD1.ToString();
                query = string.Format(@"
                 INSERT INTO School_WorkShop_Ride VALUES({0},{1},'{2}');
                ", schoolWorkShopID, iD1, Val(ride1));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`school_workshop_ride` SET `School_WorkShop_Ride_Comment`='{2}' WHERE `School_WorkShop_Ride_ID`={0} and`School_WorkShop_Ride_Volunteer`={1};
                ", schoolWorkShopID, iD1, Val(ride1));
                Update(query);
            }
            if (iD2 == 0) i2 = "NULL";
            else
            {
                i2 = iD2.ToString();
                query = string.Format(@"
                 INSERT INTO School_WorkShop_Ride VALUES({0},{1},'{2}');
                ", schoolWorkShopID, iD2, Val(ride2));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`school_workshop_ride` SET `School_WorkShop_Ride_Comment`='{2}' WHERE `School_WorkShop_Ride_ID`={0} and`School_WorkShop_Ride_Volunteer`={1};
                ", schoolWorkShopID, iD2, Val(ride2));
                Update(query);
            }
            if (iD3 == 0) i3 = "NULL";
            else
            {
                i3 = iD3.ToString();
                query = string.Format(@"
                 INSERT INTO School_WorkShop_Ride VALUES({0},{1},'{2}');
                ", schoolWorkShopID, iD3, Val(ride3));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`school_workshop_ride` SET `School_WorkShop_Ride_Comment`='{2}' WHERE `School_WorkShop_Ride_ID`={0} and`School_WorkShop_Ride_Volunteer`={1};
                ", schoolWorkShopID, iD3, Val(ride3));
                Update(query);
            }

            query = string.Format(@"
            UPDATE schoolworkshop SET 
            WorkShop_Volunteer1={0}, WorkShop_Volunteer2={1}, WorkShop_Volunteer3={2} WHERE WorkShop_ID={3};
                ", i1, i2, i3, schoolWorkShopID);
            return Update(query);
        }
        public bool updateCompanyWorkshopVolunteer(int companyWorkShopID, int iD1, int iD2, int iD3, string ride1, string ride2, string ride3)
        {
            string i1, i2, i3;
            if (iD1 == 0) i1 = "NULL";
            else
            {
                i1 = iD1.ToString();
                query = string.Format(@"
                 INSERT INTO Company_WorkShop_Ride VALUES({0},{1},'{2}');
                ", companyWorkShopID, iD1, Val(ride1));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`company_workshop_ride` SET `Company_WorkShop_Ride_Comment`= '{2}' WHERE `Company_WorkShop_Ride_ID`= {0} and`Company_WorkShop_Ride_Volunteer`= {1};
                ", companyWorkShopID, iD1, Val(ride1));
                Update(query);

            }
            if (iD2 == 0) i2 = "NULL";
            else
            {
                i2 = iD2.ToString();
                query = string.Format(@"
                 INSERT INTO Company_WorkShop_Ride VALUES({0},{1},'{2}');
                ", companyWorkShopID, iD2, Val(ride2));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`company_workshop_ride` SET `Company_WorkShop_Ride_Comment`= '{2}' WHERE `Company_WorkShop_Ride_ID`= {0} and`Company_WorkShop_Ride_Volunteer`= {1};
                ", companyWorkShopID, iD1, Val( ride1));
                Update(query);
            }
            if (iD3 == 0) i3 = "NULL";
            else
            {
                i3 = iD3.ToString();
                query = string.Format(@"
                 INSERT INTO Company_WorkShop_Ride VALUES({0},{1},'{2}');
                ", companyWorkShopID, iD3, Val(ride3));
                Insert(query);
                query = string.Format(@"
                UPDATE `mmt_db`.`company_workshop_ride` SET `Company_WorkShop_Ride_Comment`= '{2}' WHERE `Company_WorkShop_Ride_ID`= {0} and`Company_WorkShop_Ride_Volunteer`= {1};
                ", companyWorkShopID, iD1, Val(ride1));
                Update(query);
            }

            query = string.Format(@"
            UPDATE CompanyWorkShop SET 
            WorkShop_Volunteer1={0}, WorkShop_Volunteer2={1}, WorkShop_Volunteer3={2} WHERE WorkShop_ID={3};
                ", i1, i2, i3, companyWorkShopID);
            return Update(query);
        }
        public bool updateCompanyWorkshopSchoolAssign(string WorkshopID, int SchoolID, string finalParticipants, string comments)
        {
            query = string.Format(@"
            UPDATE companyworkshop SET 
            WorkShop_School_ID={0}, WorkShop_School_Comments='{1}', WorkShop_Number_Of_Final_Student={2},WorkShop_Status={3} WHERE WorkShop_ID={4};
                ", SchoolID, Val(comments), Val(finalParticipants), 4, WorkshopID);
            return Update(query);
        }
        public List<CompanyWorkshop> GetAllCompanyWorshops()
        {
            List<CompanyWorkshop> result = new List<CompanyWorkshop>();
            query = string.Format("SELECT * FROM CompanyWorkShop WHERE Is_Active=1");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new CompanyWorkshop(dr));
                }
            }
            return result;
        }
 
        public List<SchoolWorkShop> GetAllSchoolWorkShops()
        {
            List<SchoolWorkShop> result = new List<SchoolWorkShop>();
            query = string.Format("SELECT * FROM SchoolWorkShop WHERE Is_Active=1");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(new SchoolWorkShop(dr));
                }
            }
            return result;
        }

        public bool InsertNewSchoolWorkShop(SchoolWorkShop NewSchoolWorkShop)
        {
            bool result = true;

            /*INSERT INTO SchoolWorkShop VALUES(null,1,'2017-1-1 12:12:00','2017-1-1 12:12:00','2017-1-12 12:12:00',1,1,2,3,4,20,20,'להדליק את המזגן לפני','רכזת עמט מיכל','052-5782802','mci@gamil.com',false,1);*/
            try
            {
                query = string.Format(@"INSERT INTO SchoolWorkShop 
                VALUES(null,5,'{0}','{1}','{2}',0,null,null,null,null,{3},{4},'{5}','{6}','{7}','{8}',{9},{10},True);",
                NewSchoolWorkShop.SchoolWorkShopDate1,
                NewSchoolWorkShop.SchoolWorkShopDate2,
                NewSchoolWorkShop.SchoolWorkShopDate3,
                NewSchoolWorkShop.SchoolWorkShopStudentCount,
                NewSchoolWorkShop.SchoolWorkShopComputerCount,
                NewSchoolWorkShop.SchoolWorkShopComments,
                Val(NewSchoolWorkShop.WorkShop_AMT_Contact_Name),
                Val(NewSchoolWorkShop.WorkShop_AMT_Contact_phone),
                Val(NewSchoolWorkShop.WorkShop_AMT_Contact_Email),
                NewSchoolWorkShop.WorkShop_For_AMT_students,
                NewSchoolWorkShop.WorkShop_School_ID
                );
                query += "SELECT WorkShop_ID FROM mmt_db.SchoolWorkShop order by WorkShop_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0) return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return result;
        }
        public bool InsertNewCompanyWorkShop(CompanyWorkshop workshop)
        {
            /*INSERT INTO CompanyWorkShop VALUES(null,1,'2017-1-1 12:12:00',1,1,2,3,20,'להדליק את המזגן לפני',1,1,1,'הערת בית ספר');*/
            try
            {

                query = string.Format(@"INSERT INTO CompanyWorkShop 
                VALUES(null,2,'{0}',null,null,null,null,{1},'{2}',null,{3},null,null,True);",
                    workshop.CompanyWorkShopDate,
                    workshop.WorkShop_Number_Of_StudentPredicted,
                    workshop.CompanyWorkShopComments,
                    workshop.CompanyID
                    );
                query += "SELECT WorkShop_ID FROM mmt_db.CompanyWorkShop order by WorkShop_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0) return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public List<WorkshopJoin> GetAllWorkshopsByJoin()
        {
            List<WorkshopJoin> result = new List<WorkshopJoin>();
            query = string.Format("SELECT * FROM Company_Workshops_view WHERE Is_Active=1");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WorkshopJoin t = new WorkshopJoin(dr);
                    t.Is_company = true;
                    result.Add(t);
                }
            }
            query = string.Format("SELECT * FROM school_workshops_view WHERE Is_Active=1");
            dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    WorkshopJoin t = new WorkshopJoin(dr, 2);
                    t.Is_company = false;
                    result.Add(t);
                }
            }
            return result;
        }
        public SchoolWorkShop GetSchoolWorkShopByJoinID(int ID)
        {
            SchoolWorkShop result = new SchoolWorkShop();
            query = string.Format("SELECT * FROM mmt_db.school_workshops_view WHERE WorkShop_ID ={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new SchoolWorkShop(dr);
                }
            }
            return result;
        }
        public CompanyWorkshop getCompanyWorkshopByID(int ID)
        {
            CompanyWorkshop result = new CompanyWorkshop();
            query = string.Format("SELECT * FROM mmt_db.companyworkshop WHERE WorkShop_ID ={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new CompanyWorkshop(dr);
                }
            }
            return result;
        }
        public WorkshopJoin GetJoinWorkShopByID(int ID)
        {
            WorkshopJoin SchoolWorkshops = new WorkshopJoin();
            query = string.Format("SELECT * FROM mmt_db.school_workshops_view WHERE WorkShop_ID ={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new WorkshopJoin(dr, 2);
                }
            }
            return SchoolWorkshops;
        }
        public WorkshopJoin GetJoinWorkShopByID(int ID, int i)
        {
            WorkshopJoin ComapnyWorkshops = new WorkshopJoin();
            query = string.Format("SELECT * FROM mmt_db.company_workshops_view WHERE WorkShop_ID ={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new WorkshopJoin(dr);
                }
            }
            return ComapnyWorkshops;
        }
        public SchoolWorkShop GetSchoolWorkshopByID(int workshopID)
        {
            SchoolWorkShop sc = null;
            query = string.Format("SELECT * FROM mmt_db.schoolworkshop where WorkShop_ID = '{0}'", workshopID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sc = new SchoolWorkShop(dr);
                }
            }
            return sc;
        }
        public bool SchoolWorkShopUpdateDate(int SchoolID, int selectDate)
        {
            query = string.Format(@"UPDATE schoolworkshop SET WorkShop_SelectedDate = {0} WHERE WorkShop_ID = {1};", selectDate, SchoolID);
            return Update(query);
        }
        public bool SchoolWorkShopUpdatestatus(int SchoolID, int status)
        {
            query = string.Format(@"UPDATE schoolworkshop SET WorkShop_Status = {0} WHERE WorkShop_ID = {1};", status, SchoolID);
            return Update(query);
        }
        public bool CompanyWorkshopUpdateStatus(int CompanyID, int status)
        {
            query = string.Format(@"UPDATE companyworkshop SET WorkShop_Status = {0} WHERE WorkShop_ID = {1};", status, CompanyID);
            return Update(query);
        }
        public bool InsertNewPrePare(int SchoolWorkShopID)
        {
            /*INSERT INTO mmt_db.prepare_school_workshop VALUES(NULL,NULL,NULL,FALSE,FALSE,FALSE,FALSE,NULL,NULL,NULL,NULL,1);*/
            try
            {
                query = string.Format(@"INSERT INTO prepare_school_workshop	VALUES(
                    null,null,0,0,0,0,0,'','','','','', {0},'',false,false);",
                    SchoolWorkShopID
                    );
                int row = Insert(query);
                //if (row == 0) return false;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdatePrepare(PrepareForm p)
        {
            query = string.Format(@"
            UPDATE Prepare_School_WorkShop SET 
            WorkShop_Number_Of_Final_Student = {1}, 
            WorkShop_Number_Of_emulator_Computer = {2},
            WorkShop_Is_Projector = {3},
            WorkShop_Did_Preparation = {4},
            WorkShop_Is_Seniors_Coming = {5},
            WorkShop_Is_Video_possible = {6},
            WorkShop_Comments = '{7}',
            WorkShop_Teacher_Name = '{8}',
            WorkShop_Teacher_phone = '{9}',
            WorkShop_Teacher_Email = '{10}',
            WorkShop_Parking ='{11}',
            WorkShop_Computer_Manager_Phone = '{12}'
            Workshop_Is_All_Student_Answer_PerWorkshop = {13},
            Workshop_Is_All_Student_Gmail = {14}
            WHERE Workshop_School_Workshop_ID = {0};",
            p.Workshop_School_Workshop_ID,
            p.WorkShop_Number_Of_Final_Student,
            p.WorkShop_Number_Of_emulator_Computer,
            p.WorkShop_Is_Projector == true ? 1 : 0,
            p.WorkShop_Did_Preparation == true ? 1 : 0,
            p.WorkShop_Is_Seniors_Coming == true ? 1 : 0,
            p.WorkShop_Is_Video_possible == true ? 1 : 0,
            Val(p.WorkShop_Comments),
            Val(p.WorkShop_Teacher_Name),
            Val(p.WorkShop_Teacher_phone),
            Val(p.WorkShop_Teacher_Email),
            Val(p.WorkShop_Parking),
            Val(p.WorkShop_Computer_Manager_Phone ),
            p.Workshop_Is_All_Student_Answer_PerWorkshop == true ? 1 : 0,
            p.Workshop_Is_All_Student_Gmail == true ? 1 : 0
            );
            return Update(query);
        }
        public PrepareForm getPrePareFormByWorkshopID(int workshopID)
        {
            PrepareForm result = null;
            query = string.Format("SELECT * FROM mmt_db.Prepare_School_WorkShop WHERE Workshop_School_Workshop_ID ={0}", workshopID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new PrepareForm(dr);
                }
            }
            return result;

        }
        public string getVolunteerSchoolRide(int volunteer_ID, int workshopId)
        {
            string result = "";
            query = string.Format("SELECT School_WorkShop_Ride_Comment FROM mmt_db.School_WorkShop_Ride where School_WorkShop_Ride_ID = {0} && School_WorkShop_Ride_Volunteer ={1}", workshopId, volunteer_ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return dr["School_WorkShop_Ride_Comment"].ToString();
                }
            }
            return result;
        }
        public string getVolunteerCompanyRide(int volunteer_ID, int workshopId)
        {
            string result = "";
            query = string.Format("SELECT Company_WorkShop_Ride_Comment FROM mmt_db.Company_WorkShop_Ride where Company_WorkShop_Ride_ID = {0} && Company_WorkShop_Ride_Volunteer ={1}", workshopId, volunteer_ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return dr["Company_WorkShop_Ride_Comment"].ToString();
                }
            }
            return result;
        }
        public bool DeleteCompanyWorkshop(int workshopID)
        {                
            //TODO add FeedBack constrain       
            query = string.Format(@"
            UPDATE `mmt_db`.`companyworkshop` SET Is_Active=0 WHERE `WorkShop_ID`= {0};", workshopID);
            return Update(query);
        }
        public bool DeleteSchoolWoshop(int workshopID)
        {
            query = string.Format(@" 
            UPDATE `mmt_db`.`schoolworkshop`  SET Is_Active=0  WHERE `WorkShop_ID`= {0};", workshopID);
            return Update(query);
        }
        public bool resetCompany(int workshopID)
        {
            //TODO add FeedBack constrain       
            query = string.Format(@" DELETE FROM `mmt_db`.`company_workshop_ride` WHERE `Company_WorkShop_Ride_ID`= {0};
            UPDATE `mmt_db`.`companyworkshop` SET WorkShop_Status=2,WorkShop_Volunteer1=null,WorkShop_Volunteer2=null,WorkShop_Volunteer3=null,WorkShop_School_ID=null,WorkShop_Number_Of_Final_Student=null,WorkShop_School_Comments=null WHERE `WorkShop_ID`={0};
            ", workshopID);
            return Update(query);
        }
        #endregion

        #region Manager

        //public List<Workshop> GetallWorkShopsBetweenMonths(int year,int startMonth, int endMonth)
        //{
        //    List<Workshop> result = new List<Workshop>();
        //    query = string.Format(@"SELECT * FROM mmt_db.workshop 
        //                           WHERE YEAR(`WorkShop_Date`) = {0}
        //                           AND MONTH(`WorkShop_Date`) BETWEEN {1} AND {2}; ", year, startMonth, endMonth);
        //    DataTable dt = Select(query);
        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            result.Add(new Workshop(dr));
        //        }
        //    }
        //    return result;
        //}

        public Dictionary<int, string> GetAreaActivity()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            query = string.Format(@"SELECT * FROM mmt_db.area_activity; ");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(int.Parse(dr["Area_Activity_ID"].ToString()), dr["Area_Activity_Description"].ToString());
                }
            }
            return result;
        }
        public List<string> getManagerDashBoard()
        {
            //Variables
            List<string> result = new List<string>();
            DataTable dt;

            //בקשות בתי ספר לקיום סדנא
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 5;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                result.Add(dr["result"].ToString());
            }
            //סדנאות בחברות לשיבוץ בתי ספר
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 2;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                result.Add(dr["result"].ToString());
            }

          
            //סדנאות לשיבוץ מתנדבות
            int count = 0;
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 1;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 1;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            result.Add(count.ToString());

            //סדנאות בשיבוץ הושלם להכנה
            count = 0;
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 3;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 3;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            result.Add(count.ToString());

            //סדנאות לביצוע
            count = 0;
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 7;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 7;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            result.Add(count.ToString());
            //סדנאות למישוב
            count = 0;
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 8;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 8;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            result.Add(count.ToString());
            //סדנאות סגורות
            count = 0;
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 9;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            query = "SELECT COUNT(*) as result FROM mmt_db.schoolworkshop WHERE WorkShop_Status = 9;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                count += int.Parse((dr["result"].ToString()));
            }
            result.Add(count.ToString());
            //מתנדבות חדשות לאישור

            query = "SELECT COUNT(*) as result  FROM mmt_db.volunteer WHERE Volunteer_Practice = 1;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                result.Add(dr["result"].ToString());
            }
            //סדנאות בחברות לשיבוץ בתי ספר
            query = "SELECT COUNT(*) as result FROM mmt_db.companyworkshop WHERE WorkShop_Status = 4;";
            dt = Select(query);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                result.Add(dr["result"].ToString());
            }

            return result;
        }



        public Dictionary<int, string> GetVolunteerStatus()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            query = string.Format(@"SELECT * FROM mmt_db.volunteers_practice; ");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(int.Parse(dr["Volunteers_Practice_ID"].ToString()), dr["Volunteers_Practice_Description"].ToString());
                }
            }
            return result;
        }
        #endregion

        #region School
        public Boolean InsetNewSchool(School school)
        {
            try
            {
                query = string.Format(@"INSERT INTO School VALUES(null,{0},'{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}');",
                school.School_Serial_Number,
                Val(school.School_Name),
                Val(school.School_Address),
                Val(school.School_City),
                school.School_Area,
                Val(school.School_Contact_Name),
                Val(school.Scool_Contact_Phone),
                Val(school.School_Contact_Email),
                Val(school.School_Supervisor_Name),
                Val(school.School_Supervisor_Phone),
                Val(school.School_Parking_Info)
                    );
                log(query);
                query += "SELECT School_ID FROM mmt_db.School order by School_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0)
                    return false;

                //Get volunteer ID
                school.School_ID = row;

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public School GetSchoolByID(int ID)
        {
            School result = new School();
            query = string.Format("SELECT * FROM School WHERE School_ID={0}", ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return new School(dr);
                }
            }
            return result;
        }
        #endregion

        #region Company
        public Boolean InsertNewCompany(Company company)
        {
            try
            {
                query = string.Format(@"INSERT INTO Company 
                VALUES(null,'{0}','{1}','{2}','{3}','{4}',{5});",
                    company.Company_Name,
                    company.Company_Address,
                    company.Company_Contact_Name,
                    company.Company_Contact_phone,
                    company.Company_Contact_Email,
                    company.Company_Area_Activity);
                query += "SELECT Company_ID FROM mmt_db.Company order by Company_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0) return false;

                //Get company ID
                company.Company_ID = row;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public List<Company> GetAllComapny()
        {
            List<Company> result = new List<Company>();
            query = string.Format("SELECT * FROM Company");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Company company = new Company(dr);
                    result.Add(company);
                }
            }
            return result;
        }
        public Company getCompanyByID(int ID)
        {
            Company result = new Company();
            query = string.Format("SELECT * FROM Company WHERE Company_ID = {0}",ID);
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result= new Company(dr);
                }
            }
            return result;
        }
        public Boolean UpdateCompany(Company company)
        {
            //TODO 
            return true;
            // query = string.Format(@"UPDATE Company SET Volunteer_Practice = {0} WHERE Volunteer_ID = {1};", );
            // return Update(query);
        }
        public Boolean DeleteCompany(Company company)
        {
            query = string.Format(@"DELETE FROM Company WHERE Company_ID = {0};", company.Company_ID);
            return Update(query);
        }
        
        #endregion

        #region FeedBack 

        public List<FeedBack> GetallFeedBacks()
        {
            List<FeedBack> result = new List<FeedBack>();
            query = string.Format("SELECT * FROM WorkShop_FeedBack");
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FeedBack s = new FeedBack(dr);
                    result.Add(s);
                }
            }
            return result;
        }
        public List<FeedBack> GetAllFeedBackByWorkshopID(int WorkshopID,bool IsCompany)
        {
            List<FeedBack> result = new List<FeedBack>();
            query = string.Format("SELECT * FROM WorkShop_FeedBack WHERE WorkShop_ID = {0} AND WorkShop_Is_Company={1}",
                WorkshopID, IsCompany
                );
            DataTable dt = Select(query);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FeedBack s = new FeedBack(dr);
                    result.Add(s);
                }
            }
            return result;
        }
        public bool InsertNewFeedBack(FeedBack f)
        {
            /*
            	WorkShop_ID INTEGER NOT NULL ,
	            WorkShop_Person INTEGER NOT NULL,
                WorkShop_Is_Volunteer boolean,
                WorkShop_Is_Company boolean,
                WorkShop_Is_Teacher_present INTEGER,
                WorkShop_Is_Teacher_present_Comment VARCHAR(150),
                WorkShop_Level_Of_Listening INTEGER,
                WorkShop_Main_Issues_Difficulties VARCHAR(150),
                WorkShop_Technical_Faults VARCHAR(150),
                WorkShop_General_Comments VARCHAR(150),
                WorkShop_Choosing_technological INTEGER,
                WorkShop_Activity_Again INTEGER,
                WorkShop_Opinion VARCHAR(150),
                WorkShop_Improves VARCHAR(150),
                WorkShop_Additional_Comments VARCHAR(150),
                WorkShop_Post_Feedback INTEGER,
                PRIMARY KEY (WorkShop_ID,WorkShop
            */
            int row=0;
            try
            {
                query = string.Format(@"INSERT INTO WorkShop_FeedBack VALUES
                    ({0},{1},{2},{3},{4},'{5}',{6},'{7}','{8}','{9}',{10},{11},'{12}','{13}','{14}',{15});
                    SELECT * FROM WorkShop_FeedBack WHERE WorkShop_ID={0} AND WorkShop_Person={1};
                     ",
                    f.WorkShop_ID,
                    f.WorkShop_Person,
                    f.WorkShop_Is_Volunteer,
                    f.WorkShop_Is_Company,
                    f.WorkShop_Is_Teacher_present,
                    f.WorkShop_Is_Teacher_present_Comment,
                    f.WorkShop_Level_Of_Listening,
                    Val(f.WorkShop_Main_Issues_Difficulties),
                    Val(f.WorkShop_Technical_Faults),
                    Val(f.WorkShop_General_Comments),
                    f.WorkShop_Choosing_technological,
                    f.WorkShop_Activity_Again,
                    Val(f.WorkShop_Opinion),
                    Val(f.WorkShop_Improves),
                    Val(f.WorkShop_Additional_Comments),
                    f.WorkShop_Post_Feedback
                    );
                row = Insert(query);
              
            }
            catch (Exception e)
            {
                return false;
            }
            if (row != 0) return true;
            return false;
        }
        public bool DeleteAllFeedBackOfWorkshop(int WorkshopID,int PersonID, bool IsCompany)
        {
            query = string.Format(@"DELETE FROM WorkShop_FeedBack WHERE WorkShop_ID = {0} AND WorkShop_Person={1} AND WorkShop_Is_Company = {2};", WorkshopID,PersonID, IsCompany);
            return Update(query);
        }
        public bool UpdateFeedBack(FeedBack f)
        {
            try
            {
                //Insert new
                if (InsertNewFeedBack(f)) return true;
                //Need To Update
                if(f.WorkShop_Is_Volunteer)
                {
                    query = string.Format(@"UPDATE  WorkShop_FeedBack SET 
                    WorkShop_Is_Teacher_present={3}, WorkShop_Is_Teacher_present_Comment='{4}',
                    WorkShop_Level_Of_Listening={5}, WorkShop_Main_Issues_Difficulties='{6}', WorkShop_Technical_Faults='{7}',
                    WorkShop_General_Comments='{8}'
                    WHERE WorkShop_ID = {0} AND WorkShop_Person={1} AND WorkShop_Is_Company = {2};",
                                       f.WorkShop_ID,
                                       f.WorkShop_Person,
                                       f.WorkShop_Is_Company,
                                       f.WorkShop_Is_Teacher_present,
                                       f.WorkShop_Is_Teacher_present_Comment,
                                       f.WorkShop_Level_Of_Listening,
                                       Val(f.WorkShop_Main_Issues_Difficulties),
                                       Val(f.WorkShop_Technical_Faults),
                                       Val(f.WorkShop_General_Comments));
                    return Update(query);
                }
                else //Teacher
                {
                    return true;
                }
               
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region DB commands
        public DataTable Select(string query)
        {
            DataTable result = new DataTable();
            //Open connection
            if (this.IsConnect() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    result.Load(dataReader);

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    // this.Close();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                }

            }
            return result;
        }
        public Boolean Update(string query)
        {
            Boolean result = true;
            //Open connection
            if (this.IsConnect() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        return true;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                    result = false;
                }

            }
            return result;
        }
        public int Insert(string query)
        {
            int result = 0;
            //Open connection
            if (this.IsConnect() == true)
            {
                try
                {

                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    // result = cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                }

            }
            return result;
        }
        #endregion

        public void GetVolunteerFromExel(string FilePath)
        {
            using (var reader = new StreamReader(FilePath, Encoding.Default, true))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (index>0)
                    {                        
                        string[] col = line.Split(',');
                        string EngName = col[0];
                        string HebName = col[1];
                        string Phone = col[2];
                        string Email = col[3];

                        string[] Eng = EngName.Split(' ');
                        string Eng_first = Eng[0];
                        string Eng_last = Eng[1];
                        if (Eng.Length > 2)
                            Eng_last += Eng[2];
                        string[] Heb = HebName.Split(' ');
                        string Heb_first = Heb[0];
                        string Heb_last = Heb[1];
                        if (Heb.Length > 2)
                            Heb_last += Heb[2];

                         

                        Volunteer v = new Volunteer();
                        List<int> areas = new List<int>();
                        areas.Add(4);
                        Heb_first = Val(Heb_first);
                        Heb_last = Val(Heb_last);
                        Eng_first = Val(Eng_first);
                        Eng_last = Val(Eng_last);
                        Email = Val(Email);

                        v.Volunteer_First_Name = Heb_first;
                        v.Volunteer_Last_Name = Heb_last;
                        v.Volunteer_First_Name_Eng = Eng_first;
                        v.Volunteer_Last_Name_Eng = Eng_last;
                        v.Volunteer_phone = Phone;
                        v.Volunteer_Email = Email;
                        v.Volunteer_Practice = 2;
                        v.Volunteer_Occupation = "";
                        v.Volunteer_Number_Of_Activities = 0;
                        v.Volunteer_Area_Activity = areas;
                        v.Volunteer_Employer = "";
                        v.Volunteer_prefer_traning_area =1;
                        
                        if (col[6] != "")
                            v.Volunteer_Practice = 3;
                        InsertNewVolunteer(v, true);                     

                    }
                   
                    index++;

                }        
            }
    }
        public void GetVolunteerFromExel2(string FilePath)
        {
            using (var reader = new StreamReader(FilePath, Encoding.Default, true))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (index > 0)
                    {
                        string[] col = line.Split(',');
    
                        string Eng_first = col[0];
                        string Eng_last = col[2];
                        string Heb_first = col[1];
                        string Heb_last = col[3];
                        string Phone = col[4];
                        string Email = col[5];
                        string emplyeer = col[6];
                        string occuptation = col[7];
                        string num = col[8];
                        string refrence = col[9];
                        List<int> intList = new List<int>();
                        try
                        {
                            intList = num.Select(digit => int.Parse(digit.ToString())).ToList<int>();

                        }
                        catch (Exception e)
                        {
                            string s = "";
                        }
                        Volunteer v = new Volunteer();
                        List<int> areas = intList;
                        Heb_first = Val(Heb_first);
                        Heb_last = Val(Heb_last);
                        Eng_first = Val(Eng_first);
                        Eng_last = Val(Eng_last);
                        Email = Val(Email);
                        emplyeer = Val(emplyeer);
                        occuptation = Val(occuptation);
                        refrence = Val(refrence);

                        v.Volunteer_First_Name = Heb_first;
                        v.Volunteer_Last_Name = Heb_last;
                        v.Volunteer_First_Name_Eng = Eng_first;
                        v.Volunteer_Last_Name_Eng = Eng_last;
                        v.Volunteer_phone = Phone;
                        v.Volunteer_Email = Email;
                        v.Volunteer_Practice = 2;
                        v.Volunteer_Occupation = occuptation;
                        v.Volunteer_Number_Of_Activities = 0;
                        v.Volunteer_Area_Activity = areas;
                        v.Volunteer_Employer = emplyeer;
                        v.Volunteer_Reference = refrence;
                        v.Volunteer_prefer_traning_area = int.Parse(col[10]);

                        InsertNewVolunteer(v, true);
                    }
                    index++;
                }
            }
        }
        private void log(string s)
        {
            //write to log
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\SQLData.txt", true))
            {
                file.WriteLine(s);
            }

        }
        public void GetSchoolFromExel(string FilePath)
        {
            using (var reader = new StreamReader(FilePath, Encoding.Default, true))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (index > 0)
                    {
                        string[] col = line.Split(',');

                        string ManagerName = col[0];
                        string ManagerEmail = col[1];
                        string ManagerPhone = col[2];
                        string Name = col[3];
                        string Adress = col[4];
                        string City = col[5];
                        int area = int.Parse(col[6]);
                        string Symbol = col[7];

                        ManagerPhone = Val(ManagerPhone);
                        Name = Val(Name);
                        ManagerName = Val(ManagerName);
                        ManagerEmail = Val(ManagerEmail);
                        Adress = Val(Adress);
                        City = Val(City);


                        School NewSchool = new School();
                        NewSchool.School_Contact_Name = ManagerName;
                        NewSchool.School_Contact_Email = ManagerEmail;
                        NewSchool.Scool_Contact_Phone = ManagerPhone;
                        NewSchool.School_Name = Name;
                        NewSchool.School_Address = Adress;
                        NewSchool.School_City = City;
                        NewSchool.School_Area = area;
                        try
                        {
                            NewSchool.School_Serial_Number = int.Parse(Symbol);
                        }
                        catch(Exception e)
                        {
                            string s = "";
                        }
                        

                        InsetNewSchool(NewSchool);
                    }
                    index++;
                }

            }
        }
        public string Val(string s)
        {
            return s.Replace('\'', ' ').Replace(';', ' ').Replace('*', ' ').Replace('"', ' ');
        }
    }
}