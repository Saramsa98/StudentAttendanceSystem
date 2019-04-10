using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace InformaticsStudentAttendenceSystem.Admin
{
    
    public partial class AddStaff : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string conn = @"Data Source=LAPTOP-LQOFE7MO\SQLEXPRESS;Initial Catalog=AttendanceSystem_Database;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void btnadd_Click(object sender, EventArgs e)
        {
    
            con = new SqlConnection(conn);
            fileuploadImage.SaveAs(Server.MapPath("~/StaffImg/" + fileuploadImage.FileName));
            string link = "~/StaffImg/" + Path.GetFileName(fileuploadImage.FileName);
            string str = "insert into tblStaff values('" + txtname.Text + "','" + txtemail.Text + "','" + txtmobile.Text + "','" + txtqual.Text + "','" + txtadd.Text + "','" + ddlgender.SelectedItem.Text + "','"+ link + "','" + txtuname.Text + "','" + txtpass.Text + "')";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Insert Successfully!");
            Response.Redirect("~/Admin/ViewStaff.aspx");

        }
    }
}