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
    public partial class ViewStudentsByAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }

        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "select StudentId, StudentName, Address, Mobile, Email, CourseName from tblStudent ";
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
            int id = (Convert.ToInt32(((Label)GvStudent.Rows[e.RowIndex].FindControl("lblStudentId")).Text));
            string query = "delete from tblStudent where StudentId='" + id + "'";
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
            int id = (Convert.ToInt32(((Label)GvStudent.Rows[e.RowIndex].FindControl("lblStudentId")).Text));
            string sName = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtStudentName")).Text;
            string sMobile = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtStudentMobile")).Text;
            string sAddress = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtStudentAdd")).Text;
            string sEmail = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtStudentEmail")).Text;

            string sCourse = ((TextBox)GvStudent.Rows[e.RowIndex].FindControl("txtCourseName")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblStudent set StudentName='" + sName + "', Address ='" + sAddress + "', Mobile='" + sMobile + "'," +
                "Email='" + sEmail + "', CourseName='" + sCourse + "' where StudentId ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvStudent.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }
    }
}