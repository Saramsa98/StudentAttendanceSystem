using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InformaticsStudentAttendenceSystem.Teacher
{
    public partial class AbsentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

       

        public void show()
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            

            var STATUS = "Absent";
            string query = "SELECT DISTINCT(STUDENTID), STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS " +
                "FROM tblAttendance WHERE STATUS='" + STATUS + "' AND \"Date\"='"+DateTime.Today+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvAbsentReport.DataSource = dt;
            GvAbsentReport.DataBind();
            con.Close();
        }
        protected void btnAbsentReport_Click(object sender, EventArgs e)
        {
            
            show();
        }
    }
}