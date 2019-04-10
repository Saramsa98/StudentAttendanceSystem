using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace InformaticsStudentAttendenceSystem.Admin
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string conn = @"Data Source=LAPTOP-LQOFE7MO\SQLEXPRESS;Initial Catalog=AttendanceSystem_Database;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }
        //show data in grid view
        public void show()
        {
            con = new SqlConnection(conn);
            string query = "select  Photo, StaffName, Email, Mobile, Qualification, Address from tblStaff";
            cmd = new SqlCommand(query, con);
            dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvStaff.DataSource = dt;
            GvStaff.DataBind();
        }
    }
}