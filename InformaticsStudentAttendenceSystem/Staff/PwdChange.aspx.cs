using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InformaticsStudentAttendenceSystem.Staff
{
    public partial class PwdChange : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
       

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lbl.Text = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("select * from tblStaff where Password='" + txtOldpwd.Text + "'", con);
            DataTable dt = new DataTable();
            SQLAdapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                lbl.Text = "Invalid current password";
                lbl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                SQLAdapter = new SqlDataAdapter("update tblStaff set Password='" + txtNewpwd.Text + "' where Username='" + Session["username"].ToString() + "'", con);
                SQLAdapter.Fill(dt);
                lbl.Text = "Password changed successfully";
                lbl.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}