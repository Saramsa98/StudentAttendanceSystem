using InformaticsStudentAttendenceSystem.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace InformaticsStudentAttendenceSystem
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // create database
            CreateDatabase();

            //calling the TableCreation function
            TableCreation();


            //insert data
            AddAdminInfo();
        }
        

        public void TableCreation()
        {
            //calling the CreateTableAdmin function
            CreateTableAdmin();

            //calling the CreateTableCourse function
            CreateTableCourse();

            //calling the CreateTableModule function
            CreateTableModule();

            //calling the CreateTableStaff function
            CreateTableStaff();

            //calling the CreateTableTeacher function
            CreateTableTeacher();

            //calling the CreateTableYear function
            CreateTableYear();

            //calling the CreateTableGroup function
            CreateTableGroup();

            //calling the CreateTableTimeTable function
            CreateTableTimeTable();

            //calling the CreateTableStudent function
            CreateTableStudent();

            //calling the CreateTableAttendance function
            CreateTableAttendance();
        }

        //creating table admin
        public void CreateTableAdmin()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAdmin')
                CREATE TABLE tblAdmin
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                Username VARCHAR(50),
	                Password VARCHAR(50)
                )");

        }


        //creating table course
        public void CreateTableCourse()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblCourse')
                CREATE TABLE tblCourse
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                CourseCode VARCHAR(50),
	                CourseName VARCHAR(50)
                )");
        }

        //creating table module
        public void CreateTableModule()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblModule')
                CREATE TABLE tblModule
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                CourseName VARCHAR(50),
	                ModuleCode VARCHAR(50),
	                ModuleName VARCHAR(50)
                )");
        }

        //creating table staff
        public void CreateTableStaff()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblStaff')
                CREATE TABLE tblStaff
                (
	                [StaffId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                    [StaffName] VARCHAR(50) NOT NULL, 
                    [Email] VARCHAR(50) NOT NULL, 
                    [Mobile] VARCHAR(10) NOT NULL, 
                    [Qualification] VARCHAR(50) NOT NULL, 
                    [Address] VARCHAR(50) NOT NULL, 
                    [Gender] VARCHAR(10) NOT NULL, 
                    [Username] VARCHAR(20) NOT NULL, 
                    [Password] VARCHAR(20) NOT NULL 
                )");
        }

        //creating table teacher
        public void CreateTableTeacher()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblTeacher')
                CREATE TABLE tblTeacher
                (
	                [TeacherId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
                    [TeacherName] VARCHAR(50) NOT NULL, 
                    [Mobile] VARCHAR(10) NOT NULL, 
                    [Email] VARCHAR(50) NOT NULL, 
                    [DOB] VARCHAR(50) NOT NULL, 
                    [Qualification] VARCHAR(50) NOT NULL, 
                    [Address] VARCHAR(50) NOT NULL, 
                    [Gender] VARCHAR(10) NOT NULL, 
                    [ModuleAssigned] VARCHAR(50) NOT NULL, 
                    [TeacherType] VARCHAR(10) NOT NULL, 
                    [TeachingHrs] VARCHAR(10) NOT NULL, 
                    [Username] VARCHAR(20) NOT NULL, 
                    [Password] VARCHAR(20) NOT NULL 
                )");

        }

        //creating table year
        public void CreateTableYear()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblYear')
                CREATE TABLE tblYear
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                Year VARCHAR(50),
	                Semester VARCHAR(50)
                )");
        }

        //creating table group
        public void CreateTableGroup()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblGroup')
                CREATE TABLE tblGroup
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                GroupName VARCHAR(50),
	                Year VARCHAR(50)
                )");

        }

        public void CreateTableTimeTable()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblTimeTable')
                CREATE TABLE tblTimeTable
                (
	                 Id INT PRIMARY KEY IDENTITY(1,1),
	                 Day VARCHAR(50),
                     Time VARCHAR(50),
                     ClassType VARCHAR(50),
                     Year VARCHAR(50),
                     CourseName VARCHAR(50),
                     Intake VARCHAR(50),
                     ModuleCode VARCHAR(50),
                     ModuleTitle VARCHAR(50),
                     Lecturer VARCHAR(50),
                     GroupName VARCHAR(50),
                     Room VARCHAR(50)
                )");

        }

        //creating table student
        public void CreateTableStudent()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblStudent')
                CREATE TABLE tblStudent
                (
	                [StudentId] INT NOT NULL PRIMARY KEY, 
                    [StudentName] VARCHAR(50) NOT NULL, 
                    [Address] VARCHAR(50) NOT NULL, 
                    [Mobile] VARCHAR(10) NOT NULL, 
                    [Email] VARCHAR(50) NOT NULL, 
                    [DOB] VARCHAR(50) NOT NULL, 
                    [Gender] VARCHAR(10) NOT NULL, 
                    [EnrollDate] VARCHAR(20) NOT NULL, 
                    [CourseName] VARCHAR(50) NOT NULL, 
                    [ModuleCode] VARCHAR(50) NOT NULL, 
                    [Group] VARCHAR(20) NOT NULL, 
                    [Year] VARCHAR(20) NOT NULL 
                )");

        }

        //creating table student
        public void CreateTableAttendance()
        {
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAttendance')
                CREATE TABLE tblAttendance
                (
                   
	                [StudentId] INT NOT NULL, 
                    [StudentName] VARCHAR(50) NOT NULL, 
                    [ModuleId] VARCHAR(50) NOT NULL, 
                    [GroupName] VARCHAR(50) NOT NULL, 
                    [Date] date NOT NULL, 
                    [Status] VARCHAR(20) NOT NULL 
                )");

        }

        public void CreateTable(string createStatement)
        {
            using (SqlConnection defaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(createStatement);
                command.Connection = defaultConnection;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //inserting the admin info
        public void AddAdminInfo()
        {
            using (SqlConnection defaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(@"IF NOT EXISTS(SELECT TOP 1 Id FROM tblAdmin)
                INSERT INTO tblAdmin (Username, Password) 
                VALUES
                ('admin','admin123'),
                ('ashish','thapa')");
                command.Connection = defaultConnection;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //creation of database
        void CreateDatabase()
        {
            try
            {
                string masterConnectionString = ConfigurationManager.ConnectionStrings["masterConnectionString"].ConnectionString;
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                //SqlConnection con = new SqlConnection(connectionString);
                using (SqlConnection con = new SqlConnection(masterConnectionString))
                {
                    var databaseName = "AttendanceSystem_Database";
                    using (SqlConnection defaultConnection = new SqlConnection(connectionString))
                    {
                        databaseName = defaultConnection.Database;
                    }
                    con.Open();

                    SqlCommand command = new SqlCommand(string.Format("IF NOT EXISTS (select 1 from sys.databases where name = '{0}') CREATE DATABASE {0}", databaseName));
                    command.Connection = con;
                    command.ExecuteNonQuery();
                    // con.Close();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Database creation exception", ex);
            }
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}