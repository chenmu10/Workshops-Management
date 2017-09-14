using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
using gui.Models;

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
            query = string.Format("SELECT * FROM volunteer where Volunteer_Email = '{0}'", volunteer.Volunteer_Email); // didnt pass traning
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
        public Boolean InsetNewVolunteer(Volunteer volunteer)
        {
            try
            {
                query = string.Format(@"INSERT INTO Volunteer 
                VALUES(null,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},False,{11});",
                    volunteer.Volunteer_Practice, volunteer.Volunteer_First_Name, volunteer.Volunteer_First_Name_Eng, volunteer.Volunteer_Last_Name,
                    volunteer.Volunteer_Last_Name_Eng, volunteer.Volunteer_Email, volunteer.Volunteer_phone, volunteer.Volunteer_Occupation, volunteer.Volunteer_Reference,
                    volunteer.Volunteer_Employer, volunteer.Volunteer_Number_Of_Activities, volunteer.Volunteer_prefer_traning_area);
                query += "SELECT Volunteer_ID FROM mmt_db.volunteer order by Volunteer_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0) return false;

                //Get volunteer ID
                volunteer.Volunteer_ID = row;


                foreach (int Area in volunteer.Volunteer_Area_Activity)
                {
                    query = string.Format(@"INSERT INTO VolunteerToAreas VALUES(null,{0},{1});", volunteer.Volunteer_ID, Area);
                    if (!Update(query)) return false;
                }
            }
            catch (Exception e)
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
                ", schoolWorkShopID, iD1, ride1);
                Insert(query);
            }
            if (iD2 == 0) i2 = "NULL";
            else
            {
                i2 = iD2.ToString();
                query = string.Format(@"
                 INSERT INTO School_WorkShop_Ride VALUES({0},{1},'{2}');
                ", schoolWorkShopID, iD2, ride2);
                Insert(query);
            }
            if (iD3 == 0) i3 = "NULL";
            else
            {
                i3 = iD3.ToString();
                query = string.Format(@"
                 INSERT INTO School_WorkShop_Ride VALUES({0},{1},'{2}');
                ", schoolWorkShopID, iD3, ride3);
                Insert(query);
            }

            query = string.Format(@"
            UPDATE schoolworkshop SET 
            WorkShop_Volunteer1={0}, WorkShop_Volunteer2={1}, WorkShop_Volunteer3={2} WHERE WorkShop_ID={3};
                ", i1, i2, i3, schoolWorkShopID);
            return Update(query);
        }
        public bool updateCompanyWorkshopSchoolAssign(string WorkshopID, School School, string finalParticipants, string comments)
        {
            query = string.Format(@"
            UPDATE companyworkshop SET 
            WorkShop_School_ID={0}, WorkShop_School_Comments={1}, WorkShop_Number_Of_Final_Student={2},WorkShop_Status={3} WHERE WorkShop_ID={4};
                ", School, comments, finalParticipants, 4, WorkshopID);
            return Update(query);
        }
        public List<CompanyWorkshop> GetAllCompanyWorshops()
        {
            List<CompanyWorkshop> result = new List<CompanyWorkshop>();
            query = string.Format("SELECT * FROM CompanyWorkShop");
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
            query = string.Format("SELECT * FROM SchoolWorkShop");
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
                VALUES(null,5,'{0}','{1}','{2}',0,null,null,null,null,{3},{4},'{5}','{6}','{7}','{8}',{9},{10});",
                NewSchoolWorkShop.SchoolWorkShopDate1, NewSchoolWorkShop.SchoolWorkShopDate2, NewSchoolWorkShop.SchoolWorkShopDate3,
                NewSchoolWorkShop.SchoolWorkShopStudentCount, NewSchoolWorkShop.SchoolWorkShopComputerCount, NewSchoolWorkShop.SchoolWorkShopComments,
                NewSchoolWorkShop.WorkShop_AMT_Contact_Name, NewSchoolWorkShop.WorkShop_AMT_Contact_phone, NewSchoolWorkShop.WorkShop_AMT_Contact_Email,
                NewSchoolWorkShop.WorkShop_For_AMT_students, NewSchoolWorkShop.WorkShop_School_ID
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
        public List<WorkshopJoin> GetAllWorkshopsByJoin()
        {
            List<WorkshopJoin> result = new List<WorkshopJoin>();
            query = string.Format("SELECT * FROM Company_Workshops_view");
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
            query = string.Format("SELECT * FROM school_workshops_view");
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
        public bool InsertNewPrePare(int SchoolWorkShopID)
        {
            /*INSERT INTO mmt_db.prepare_school_workshop VALUES(NULL,NULL,NULL,FALSE,FALSE,FALSE,FALSE,NULL,NULL,NULL,NULL,1);*/
            try
            {
                query = string.Format(@"INSERT INTO mmt_db.prepare_school_workshop 
                VALUES(NULL,NULL,NULL,FALSE,FALSE,FALSE,FALSE,NULL,NULL,NULL,NULL,{0}););",
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
        public PrepareForm getPrePareFormByWorkshopID(int workshopID)
        {
            PrepareForm result = new PrepareForm();
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
                school.School_Serial_Number, school.School_Name, school.School_Address, school.School_City, school.School_Area, school.School_Contact_Name, school.Scool_Contact_Phone,
                school.School_Contact_Email, school.School_Supervisor_Name, school.School_Supervisor_Phone, school.School_Parking_Info
                    );
                query += "SELECT School_ID FROM mmt_db.School order by School_ID DESC LIMIT 1;";
                int row = Insert(query);
                if (row == 0) return false;

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
        public Boolean InsertNewCompanyWorkShop(CompanyWorkshop workshop)
        {
            /*INSERT INTO CompanyWorkShop VALUES(null,1,'2017-1-1 12:12:00',1,1,2,3,20,'להדליק את המזגן לפני',1,1,1,'הערת בית ספר');*/
            try
            {
                query = string.Format(@"INSERT INTO CompanyWorkShop 
                VALUES(null,2,'{0}',null,null,null,null,{1},'{2}',null,{3},null,null);",
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
            Boolean result = false;
            //Open connection
            if (this.IsConnect() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    int affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows > 0;
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
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

    }
}