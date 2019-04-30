using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InformaticsStudentAttendenceSystem.Staff
{
    public partial class ViewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                show();
            }
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "select StudentId, StudentName, Address, Mobile, Email, Gender, EnrollDate, CourseName from tblStudent ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvStudent.DataSource = dt;
            GvStudent.DataBind();
            con.Close();

        }

        protected void GvStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvStudent.EditIndex = -1;
            show();
        }

        protected void GvStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvStudent.Rows[e.RowIndex].FindControl("lblID")).Text));
            string query = "delete from tblTeacher where TeacherId='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            lbl.ForeColor = System.Drawing.Color.Red;
            show();
        }

        protected void GvStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvStudent.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvStudent.Rows[e.RowIndex].FindControl("lblID")).Text));
            string sName = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtStudentName")).Text;
            string sAddress = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtAdd")).Text;
            string sMobile = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtMobile")).Text;
            string sEmail = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtEmail")).Text;
            string sGender = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtGender")).Text;
            string sEnrollDate = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtEnrollDate")).Text;
            string sCourseName = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtCourseName")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblStudent set StudentName='" + sName + "', Address ='" + sAddress + "', Mobile='" + sMobile + "'," +
                "Email='" + sEmail + "', Gender='"+sGender+"', EnrollDate='"+sEnrollDate+"',CourseName='" + sCourseName + "' where StudentId ='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GvStudent.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }
    }

}