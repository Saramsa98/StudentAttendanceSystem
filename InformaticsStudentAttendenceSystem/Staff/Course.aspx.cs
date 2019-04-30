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
    public partial class Course : System.Web.UI.Page
    {
        //SqlConnection con;
        //SqlCommand cmd;
        //DataTable dt;
        //string conn = @"Data Source=LAPTOP-LQOFE7MO\SQLEXPRESS;Initial Catalog=AttendanceSystem_Database;Integrated Security=True";
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
            
        }

        protected void btnCourse_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblCourse values('" + txtCode.Text + "','" + txtCname.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Insert Successfully!";
            show();
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "select Id, CourseCode, CourseName from tblCourse";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvCourse.DataSource = dt;
            GvCourse.DataBind();
            con.Close();
        }

        protected void GvCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvCourse.EditIndex = -1;
            show();
        }

        protected void GvCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvCourse.Rows[e.RowIndex].FindControl("lblCId")).Text));
            string query = "delete from tblCourse where id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvCourse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvCourse.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvCourse.Rows[e.RowIndex].FindControl("lblCId")).Text));
            string cCode = ((TextBox)GvCourse.Rows[e.RowIndex].FindControl("txtCode")).Text;
            string cName = ((TextBox)GvCourse.Rows[e.RowIndex].FindControl("txtCname")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblCourse set CourseCode='" + cCode + "', CourseName='" + cName + "' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvCourse.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show();
        }
    }
}