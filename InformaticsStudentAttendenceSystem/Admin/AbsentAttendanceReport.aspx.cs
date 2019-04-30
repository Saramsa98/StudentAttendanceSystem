using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InformaticsStudentAttendenceSystem.Admin
{
    public partial class AbsentAttendanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// use ExecuteNonQuery method for displaying the attendance table data in gridview
        /// </summary>
        public void show()
        {
            //creating the connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //creating the variable 
            var STATUS = "Absent";
            //selection query string for tblAttendance
            string query = "SELECT DISTINCT(STUDENTID), STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS " +
                "FROM tblAttendance WHERE STATUS='" + STATUS + "' AND \"Date\"='"+DateTime.Today+"'";
            //opening the database connection
            con.Open();
            // Instantiate a new command with a query and connection
             SqlCommand cmd = new SqlCommand(query, con);

            //Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();

            //create a new datatable
            DataTable dt = new DataTable();
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvAbsentReport.DataSource = dt;
            GvAbsentReport.DataBind();
            con.Close();
        }
        protected void btnAbsentReport_Click(object sender, EventArgs e)
        {

            show(); //calling the above created function
        }
    }
}