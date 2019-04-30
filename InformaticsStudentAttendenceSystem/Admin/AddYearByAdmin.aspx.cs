using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace InformaticsStudentAttendenceSystem.Admin
{
    public partial class AddYearByAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void btnaddstd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblYear values('" + txtYear.Text + "','" + txtSemester.Text + "')";
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
            string query = "select Id, Year, Semester from tblYear";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvYear.DataSource = dt;
            GvYear.DataBind();
            con.Close();
        }

        protected void GvYear_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvYear.EditIndex = -1;
            show();
        }

        protected void GvYear_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvYear.Rows[e.RowIndex].FindControl("Label3")).Text));
            string query = "delete from tblYear where id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvYear_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvYear.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvYear_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvYear.Rows[e.RowIndex].FindControl("Label3")).Text));
            string Year = ((TextBox)GvYear.Rows[e.RowIndex].FindControl("txtYear")).Text;
            string Semester = ((TextBox)GvYear.Rows[e.RowIndex].FindControl("txtSemester")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblYear set Year='" + Year + "', Semester='" + Semester + "' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvYear.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show();
        }
    }
}