using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace InformaticsStudentAttendenceSystem.Admin
{
    public partial class adminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAPTOP-LQOFE7MO\SQLEXPRESS;Initial Catalog=AttendanceSystem_Database;Integrated Security=True;"))
            {
                string query = "Select COUNT(1) from tblAdmin where username=@username and password=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                
                sqlCon.Open();
               
                sqlcmd.Parameters.AddWithValue("@username", txtuname.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", txtupass.Text.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

                if (count == 1)
                {
                    Session["username"] = txtuname.Text.Trim();
                    Response.Redirect("~/Admin/AddStaff.aspx");
                }
                else
                {
                    lblErrorMessage.Visible = true;
                }
            }

            //if (txtuname.Text == "admin" && txtupass.Text == "123")
            //{

            //    Response.Redirect("~/index.aspx");
            //}
            //else
            //{
            //    lblErrorMessage.Visible = true;

            //}



        }
    }
}