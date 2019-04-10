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

            //create tables
            CreateTable(@"IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tblAdmin')
                CREATE TABLE tblAdmin
                (
	                Id INT PRIMARY KEY IDENTITY(1,1),
	                Username VARCHAR(50),
	                Password VARCHAR(50)
                )");
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
                    [Photo] NVARCHAR(250) NULL, 
                    [Username] VARCHAR(20) NOT NULL, 
                    [Password] VARCHAR(20) NOT NULL 
                )");
            //insert data
            AddAdminInfo();
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