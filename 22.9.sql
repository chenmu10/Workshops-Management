Drop DATABASE IF exists MMT_DB;
CREATE DATABASE MMT_DB;
USE MMT_DB;

CREATE TABLE IF NOT EXISTS Status (
	Status_ID INTEGER NOT NULL AUTO_INCREMENT,
    Status_Description VARCHAR (25),
    PRIMARY KEY (Status_ID)
);
INSERT INTO Status VALUES(null,' לשיבוץ מתנדבות');
INSERT INTO Status VALUES(null,' לשיבוץ בית ספר');
INSERT INTO Status VALUES(null,' שיבוץ מתנדבות הושלם');
INSERT INTO Status VALUES(null,' שיבוץ בית ספר הושלם');
INSERT INTO Status VALUES(null,'לבדיקת תאריכים');
INSERT INTO Status VALUES(null,'להכנה');
INSERT INTO Status VALUES(null,'לביצוע');
INSERT INTO Status VALUES(null,'למישוב');
INSERT INTO Status VALUES(null,'סגור');
INSERT INTO Status VALUES(null,'בוטל');

CREATE TABLE IF NOT EXISTS Area_Activity  (
	Area_Activity_ID INTEGER NOT NULL AUTO_INCREMENT,
    Area_Activity_Description VARCHAR (50),
    PRIMARY KEY (Area_Activity_ID)
);
INSERT INTO Area_Activity VALUES(null,'צפון');
INSERT INTO Area_Activity VALUES(null,'חיפה והסביבה');
INSERT INTO Area_Activity VALUES(null,'עמק חפר והסביבה');
INSERT INTO Area_Activity VALUES(null,'אזור המרכז');
INSERT INTO Area_Activity VALUES(null,'איזור ירושלים');
INSERT INTO Area_Activity VALUES(null,'איזור באר שבע');
INSERT INTO Area_Activity VALUES(null,'השפלה ( אשדוד, רחובות, והסביבה)');

CREATE TABLE IF NOT EXISTS Volunteers_Practice (
	Volunteers_Practice_ID INTEGER NOT NULL AUTO_INCREMENT,
    Volunteers_Practice_Description VARCHAR (25),
    PRIMARY KEY (Volunteers_Practice_ID)
);

INSERT INTO Volunteers_Practice VALUES(null,'ללא הכשרה');
INSERT INTO Volunteers_Practice VALUES(null,'מתנדבת חדשה');
INSERT INTO Volunteers_Practice VALUES(null,'מתנדבת ותיקה');

CREATE TABLE IF NOT EXISTS School (
	School_ID INTEGER NOT NULL AUTO_INCREMENT,
    School_serial_Number INTEGER NOT NULL,
    School_Name VARCHAR (50),
    School_Address VARCHAR (50),
    School_City VARCHAR (50),
    School_Area_Activity INTEGER NOT NULL,
    School_Contact_Name VARCHAR (50),
    School_Contact_phone VARCHAR (15),
    School_Contact_Email VARCHAR (70),
    School_Computer_Supervisor_Name VARCHAR (70),
    School_Computer_Supervisor_Phone VARCHAR (20),
    School_Parking_Info VARCHAR(150),
    PRIMARY KEY (School_ID),
    FOREIGN KEY(School_Area_Activity) references Area_Activity(Area_Activity_ID),
    UNIQUE (School_serial_Number)
);

INSERT INTO School VALUES(null,111111,'אורט שמונה','אורי אילן 11','קריית שמונה',1,'ישראל ישראלי','052-58756874','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);
INSERT INTO School VALUES(null,222222,'מקיף ח','אבא הלל סילבר 2','חיפה',2,'משה כהן','052-58756823','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);
INSERT INTO School VALUES(null,333333,'יפה נוף','החריש 8','עמק חפר',3,'דן דניאל','052-58754374','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);
INSERT INTO School VALUES(null,444444,'אורט','רוטשילד 10','תל אביב',4,'מיקי כץ','052-5856874','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);
INSERT INTO School VALUES(null,555555,'עירוני א','אברהם שטרן 7','ירושלים',5,'רוני רון','052-582756874','chenmu10@gmail.com','אחראי מחשבים א','052-5782802','חנייה ברחוב ליד עולה 4 שקל');
INSERT INTO School VALUES(null,666666,'עירוני ב','אברהם אבינו 4','באר שבע',6,'גילה גיל','052-58527574','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);
INSERT INTO School VALUES(null,777777,'עירוני ג','העצמאות 1','אשדוד',7,'ליסה סגן','052-587256874','chenmu10@gmail.com','אחראי מחשבים א','052-5782802',null);


CREATE TABLE IF NOT EXISTS Company(
	Company_ID INTEGER NOT NULL AUTO_INCREMENT,
    Company_Name VARCHAR (50),
    Company_Address VARCHAR (50),
    Company_Contact_Name VARCHAR (50),
    Company_Contact_phone VARCHAR (15),
    Company_Contact_Email VARCHAR (70),
    Company_Area_Activity INTEGER ,
    PRIMARY KEY (Company_ID),
	FOREIGN KEY (Company_Area_Activity) references Area_Activity(Area_Activity_ID)
);
INSERT INTO Company VALUES(null,'Google','יגאל אלון 12, תל אביב','אורנה אטיאס','052-58756874','chenmu10@gmail.com',4);
INSERT INTO Company VALUES(null,'Microsoft','השלום 9, חיפה','מוריה בן שושן','052-58756874','chenmu10@gmail.com',2);
INSERT INTO Company VALUES(null,'Facebook','רוטשילד 20, ירושלים','מוריה בן שושן','052-58756874','chenmu10@gmail.com',5);


CREATE TABLE IF NOT EXISTS Volunteer (
	Volunteer_ID INTEGER NOT NULL AUTO_INCREMENT,
    Volunteer_Practice INTEGER NOT NULL,
    Volunteer_First_Name NVARCHAR (50),
    Volunteer_First_Name_Eng NVARCHAR (50),
    Volunteer_Last_Name NVARCHAR (50),
    Volunteer_Last_Name_Eng NVARCHAR (50),
    Volunteer_Email VARCHAR (70),
    Volunteer_phone VARCHAR (15),
    Volunteer_Occupation VARCHAR (50),
    Volunteer_Reference VARCHAR (75),
    Volunteer_Employer VARCHAR (50),
    Volunteer_Number_Of_Activities INTEGER,
    Volunteer_Is_Active Bool DEFAULT True,
    Volunteer_prefer_traning_area INTEGER,
    PRIMARY KEY (Volunteer_ID),
    FOREIGN KEY (Volunteer_Practice) references Volunteers_Practice(Volunteers_Practice_ID),
    FOREIGN KEY (Volunteer_prefer_traning_area) references Area_Activity(Area_Activity_ID),
    UNIQUE (Volunteer_Email)
);
INSERT INTO Volunteer VALUES(null,1,'נועה','Noa','רובין','Rubin','a@gmail.com','052-5465468','סטודנטית','פייסבוק','google',0,True,1);
INSERT INTO Volunteer VALUES(null,1,'אביה','Avia','רובין','Rubin','b@gmail.com','052-5465468','סטודנטית','פייסבוק','facebook',0,True,2);
INSERT INTO Volunteer VALUES(null,1,'חן','Chen','יהלום','Yhlon','c@gmail.com','052-5465468','אקדמאית','מכרים','HP',0,True,3);
INSERT INTO Volunteer VALUES(null,2,'דודית','Duduit','ניצן','Nizhan','cd@gmail.com','052-5465468','אקדמאית','מכרים','google',0,True,4);
INSERT INTO Volunteer VALUES(null,2,'בת','Bat','בן','Ben','e@gmail.com','052-5465468','עובדת בתעשייה','עבודה','intel',1,True,5);
INSERT INTO Volunteer VALUES(null,3,'חדווה','Chedva','מתמטיקת','Math','f@gmail.com','052-5465468','עובדת בתעשייה','עבודה','intel',2,True,6);
INSERT INTO Volunteer VALUES(null,3,'דניאל','New volunteer','מתמטיקת','Math','g@gmail.com','052-5465468','עובדת בתעשייה','עבודה','microsoft',3,True,7);

CREATE TABLE IF NOT EXISTS VolunteerToAreas(
VolunteerToAreas_ID INTEGER NOT NULL AUTO_INCREMENT,
Volunteer_ID INTEGER NOT NULL,
Volunteer_Area_Activity INTEGER NOT NULL,
UNIQUE (Volunteer_ID,Volunteer_Area_Activity),
PRIMARY KEY (VolunteerToAreas_ID),
FOREIGN KEY(Volunteer_ID) references Volunteer(Volunteer_ID),
FOREIGN KEY(Volunteer_Area_Activity) references Area_Activity(Area_Activity_ID)
);
INSERT INTO VolunteerToAreas VALUES(null,1,1);
INSERT INTO VolunteerToAreas VALUES(null,1,2);
INSERT INTO VolunteerToAreas VALUES(null,2,1);
INSERT INTO VolunteerToAreas VALUES(null,2,3);
INSERT INTO VolunteerToAreas VALUES(null,3,4);
INSERT INTO VolunteerToAreas VALUES(null,3,5);
INSERT INTO VolunteerToAreas VALUES(null,4,6);
INSERT INTO VolunteerToAreas VALUES(null,5,7);
INSERT INTO VolunteerToAreas VALUES(null,6,5);
INSERT INTO VolunteerToAreas VALUES(null,7,1);
INSERT INTO VolunteerToAreas VALUES(null,7,3);



CREATE TABLE IF NOT EXISTS CompanyWorkShop(
	WorkShop_ID INTEGER NOT NULL AUTO_INCREMENT,
    WorkShop_Status INTEGER NOT NULL,
    WorkShop_Date DateTime NOT NULL,
    WorkShop_Volunteer1 INTEGER,
    WorkShop_Volunteer2 INTEGER,
    WorkShop_Volunteer3 INTEGER,
    WorkShop_Volunteer4 INTEGER,
    WorkShop_Number_Of_StudentPredicted INTEGER,
    WorkShop_Comments VARCHAR (250),
    WorkShop_School_ID INTEGER,  
    WorkShop_Company_ID INTEGER,
    WorkShop_Number_Of_Final_Student INTEGER,
    WorkShop_School_Comments VARCHAR (250),
    PRIMARY KEY (WorkShop_ID),
    FOREIGN KEY (WorkShop_School_ID) references School(School_ID),
    FOREIGN KEY (WorkShop_Company_ID) references Company(Company_ID),
    FOREIGN KEY (WorkShop_Status) references Status(Status_ID),
    FOREIGN KEY (WorkShop_Volunteer1) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer2) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer3) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer4) references Volunteer(Volunteer_ID)
);
INSERT INTO CompanyWorkShop VALUES(null,2,'2017-1-1 08:00:00',null,null,null,null,20,'הערות חברה ביצירת סדנא',null,1,null,null);
INSERT INTO CompanyWorkShop VALUES(null,2,'2017-1-1 08:00:00',null,null,null,null,30,'הערות חברה ביצירת סדנא',null,2,null,null);
INSERT INTO CompanyWorkShop VALUES(null,2,'2017-1-1 08:00:00',null,null,null,null,40,'הערות חברה ביצירת סדנא',null,3,null,null);
INSERT INTO CompanyWorkShop VALUES(null,4,'2017-8-8 09:00:00',null,null,null,null,10,'הערות חברה ביצירת סדנא',3,2,12,'הערת בית ספר');
INSERT INTO CompanyWorkShop VALUES(null,1,'2017-9-9 10:00:00',null,null,null,null,30,'הערות חברה ביצירת סדנא',2,3,30,'הערת בית ספר');
INSERT INTO CompanyWorkShop VALUES(null,1,'2017-9-27 08:00:00',1,null,null,null,50,'הערות חברה ביצירת סדנא',1,1,50,'הערת בית ספר');
INSERT INTO CompanyWorkShop VALUES(null,1,'2017-9-27 08:00:00',1,null,4,null,60,'הערות חברה ביצירת סדנא',1,2,60,'הערת בית ספר');
INSERT INTO CompanyWorkShop VALUES(null,3,'2017-9-27 08:00:00',3,4,6,null,70,'הערות חברה ביצירת סדנא',1,3,70,'הערת בית ספר');
INSERT INTO CompanyWorkShop VALUES(null,3,'2017-9-27 08:00:00',5,2,7,null,80,'הערות חברה ביצירת סדנא',1,1,80,'הערת בית ספר');




CREATE TABLE IF NOT EXISTS SchoolWorkShop(
	WorkShop_ID INTEGER NOT NULL AUTO_INCREMENT,
    WorkShop_Status INTEGER NOT NULL,
    WorkShop_Date1 DateTime NOT NULL,
    WorkShop_Date2 DateTime NOT NULL,
    WorkShop_Date3 DateTime NOT NULL,
    WorkShop_SelectedDate INTEGER,
    WorkShop_Volunteer1 INTEGER,
    WorkShop_Volunteer2 INTEGER,
    WorkShop_Volunteer3 INTEGER,
    WorkShop_Volunteer4 INTEGER,
    WorkShop_Number_Of_StudentPredicted INTEGER,
	WorkShop_Number_Of_Computers INTEGER,
    WorkShop_Comments VARCHAR (250),
	WorkShop_AMT_Contact_Name VARCHAR (50),
    WorkShop_AMT_Contact_phone VARCHAR (15),
    WorkShop_AMT_Contact_Email VARCHAR (70),
    WorkShop_For_AMT_students BOOLEAN NOT NULL DEFAULT FALSE,
    WorkShop_School_ID INTEGER,  
    PRIMARY KEY (WorkShop_ID),
    FOREIGN KEY (WorkShop_Status) references Status(Status_ID),
    FOREIGN KEY (WorkShop_Volunteer1) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer2) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer3) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_Volunteer4) references Volunteer(Volunteer_ID),
    FOREIGN KEY (WorkShop_School_ID) references School(School_ID)
);
INSERT INTO SchoolWorkShop VALUES(null,5,'2017-1-1 12:12:00','2017-1-1 12:12:00','2017-1-12 12:12:00',null,null,null,null,null,20,10,'סדנא אוטומטית',null,null,null,false,1);
INSERT INTO SchoolWorkShop VALUES(null,5,'2017-2-1 12:12:00','2017-5-1 12:12:00','2017-2-15 12:12:00',null,null,null,null,null,30,20,'סדנא אוטומטית',null,null,null,true,2);
INSERT INTO SchoolWorkShop VALUES(null,1,'2017-3-1 12:12:00','2017-6-1 12:12:00','2017-3-1 12:12:00',2,null,null,null,null,20,20,'סדנא אוטומטית',null,null,null,false,3);
INSERT INTO SchoolWorkShop VALUES(null,1,'2017-4-20 12:12:00','2017-7-1 12:12:00','2017-7-1 12:12:00',1,1,2,null,null,20,20,'סדנא אוטומטית',null,null,null,false,4);
INSERT INTO SchoolWorkShop VALUES(null,6,'2017-4-20 12:12:00','2017-7-1 12:12:00','2017-7-1 12:12:00',3,1,2,6,null,20,20,'סדנא אוטומטית',null,null,null,true,5);



CREATE TABLE IF NOT EXISTS Prepare_School_WorkShop (
	Prepare_ID INTEGER NOT NULL AUTO_INCREMENT,
	WorkShop_Number_Of_Final_Student INTEGER,
    WorkShop_Number_Of_emulator_Computer INTEGER,
    WorkShop_Is_Projector BOOLEAN NOT NULL DEFAULT FALSE,
    WorkShop_Did_Preparation BOOLEAN NOT NULL DEFAULT FALSE,
    WorkShop_Is_Seniors_Coming BOOLEAN NOT NULL DEFAULT FALSE,
    WorkShop_Is_Video_possible BOOLEAN NOT NULL DEFAULT FALSE,
    WorkShop_Comments VARCHAR(150),
	WorkShop_Teacher_Name VARCHAR (50),
    WorkShop_Teacher_phone VARCHAR (15),
    WorkShop_Teacher_Email VARCHAR (70),
    WorkShop_Parking VARCHAR (70),
    Workshop_School_Workshop_ID INTEGER,
    UNIQUE ( Workshop_School_Workshop_ID),
    PRIMARY KEY (Prepare_ID),
    FOREIGN KEY (Workshop_School_Workshop_ID) references SchoolWorkShop(WorkShop_ID)
);
INSERT INTO prepare_school_workshop	VALUES(null,55,55,true,	true,true,true,	'הערות מטופס הכנה','רינה המורה','052-5465468','chenmu10@gmail.com','חנייה בתשלום', 5);

CREATE TABLE IF NOT EXISTS School_WorkShop_Ride (
	School_WorkShop_Ride_ID INTEGER NOT NULL AUTO_INCREMENT,
	School_WorkShop_Ride_Volunteer INTEGER  NOT NULL,
    School_WorkShop_Ride_Comment VARCHAR(150),
    PRIMARY KEY (School_WorkShop_Ride_ID,School_WorkShop_Ride_Volunteer),
    FOREIGN KEY (School_WorkShop_Ride_ID) references SchoolWorkShop(WorkShop_ID),
    FOREIGN KEY (School_WorkShop_Ride_Volunteer) references Volunteer(Volunteer_ID)
);
INSERT INTO School_WorkShop_Ride VALUES(1,1,'לנסוע ביחד מירשולים');

CREATE TABLE IF NOT EXISTS Company_WorkShop_Ride (
	Company_WorkShop_Ride_ID INTEGER NOT NULL AUTO_INCREMENT,
	Company_WorkShop_Ride_Volunteer INTEGER  NOT NULL,
    Company_WorkShop_Ride_Comment VARCHAR(150),
    PRIMARY KEY (Company_WorkShop_Ride_ID,Company_WorkShop_Ride_Volunteer),
    FOREIGN KEY (Company_WorkShop_Ride_ID) references CompanyWorkShop(WorkShop_ID),
    FOREIGN KEY (Company_WorkShop_Ride_Volunteer) references Volunteer(Volunteer_ID)
);
INSERT INTO Company_WorkShop_Ride VALUES(1,1,'לנסוע ביחד מירשולים');





USE `mmt_db`;        
CREATE  OR REPLACE VIEW `Company_Workshops_view` AS
SELECT WorkShop_ID,Status_Description, WorkShop_Date,School_Name,Company_Name,WorkShop_Status,Company.Company_Area_Activity  AS Area, Company.Company_ID,School.School_ID,
concat(V1.Volunteer_First_Name," ",V1.Volunteer_Last_Name) as Volunteer1_Name,
concat(V2.Volunteer_First_Name," ",V2.Volunteer_Last_Name) as Volunteer2_Name,
concat(V3.Volunteer_First_Name," ",V3.Volunteer_Last_Name) as Volunteer3_Name,
concat(V4.Volunteer_First_Name," ",V4.Volunteer_Last_Name) as Volunteer4_Name

FROM CompanyWorkShop
LEFT JOIN School ON CompanyWorkShop.WorkShop_School_ID=School.School_ID
LEFT JOIN Company ON CompanyWorkShop.WorkShop_Company_ID=Company.Company_ID
LEFT JOIN Status ON CompanyWorkShop.WorkShop_Status = Status.Status_ID
LEFT JOIN Volunteer as V1 ON CompanyWorkShop.WorkShop_Volunteer1 = V1.Volunteer_ID
LEFT JOIN Volunteer as V2 ON CompanyWorkShop.WorkShop_Volunteer2 = V2.Volunteer_ID
LEFT JOIN Volunteer as V3 ON CompanyWorkShop.WorkShop_Volunteer3 = V3.Volunteer_ID
LEFT JOIN Volunteer as V4 ON CompanyWorkShop.WorkShop_Volunteer4 = V4.Volunteer_ID
;
USE `mmt_db`;
CREATE  OR REPLACE VIEW `School_workshops_view` AS
SELECT WorkShop_ID,Status_Description, WorkShop_Date1, WorkShop_Date2, WorkShop_Date3,WorkShop_SelectedDate,School.School_Name,WorkShop_Status,School.School_Area_Activity AS Area,School.School_ID,
concat(V1.Volunteer_First_Name," ",V1.Volunteer_Last_Name) as Volunteer1_Name,
concat(V2.Volunteer_First_Name," ",V2.Volunteer_Last_Name) as Volunteer2_Name,
concat(V3.Volunteer_First_Name," ",V3.Volunteer_Last_Name) as Volunteer3_Name,
concat(V4.Volunteer_First_Name," ",V4.Volunteer_Last_Name) as Volunteer4_Name

FROM SchoolWorkShop
LEFT JOIN Status ON SchoolWorkShop.WorkShop_Status = Status.Status_ID
LEFT JOIN School ON SchoolWorkShop.WorkShop_School_ID=School.School_ID
LEFT JOIN Volunteer as V1 ON SchoolWorkShop.WorkShop_Volunteer1 = V1.Volunteer_ID
LEFT JOIN Volunteer as V2 ON SchoolWorkShop.WorkShop_Volunteer2 = V2.Volunteer_ID
LEFT JOIN Volunteer as V3 ON SchoolWorkShop.WorkShop_Volunteer3 = V3.Volunteer_ID
LEFT JOIN Volunteer as V4 ON SchoolWorkShop.WorkShop_Volunteer4 = V4.Volunteer_ID
;