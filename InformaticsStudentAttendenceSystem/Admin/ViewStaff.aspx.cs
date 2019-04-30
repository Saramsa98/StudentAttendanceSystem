using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InformaticsStudentAttendenceSystem.Admin
{
    public partial class ViewStaff : System.Web.UI.Page
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
        //show data in grid view
        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "select StaffId, StaffName, Email, Mobile, Qualification, Address from tblStaff";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvStaff.DataSource = dt;
            GvStaff.DataBind();
            con.Close();
        }

        protected void GvStaff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvStaff.EditIndex = -1;
            show();
        }

        protected void GvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvStaff.Rows[e.RowIndex].FindControl("lblStaffId")).Text));
            string query = "delete from tblStaff where StaffId='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            lbl.ForeColor = System.Drawing.Color.Red;
            show();
        }

        protected void GvStaff_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvStaff.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvStaff_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvStaff.Rows[e.RowIndex].FindControl("lblStaffId")).Text));
            string sName = ((TextBox)GvStaff.Rows[e.RowIndex].FindControl("txtStaffName")).Text;
            string sEmail = ((TextBox)GvStaff.Rows[e.RowIndex].FindControl("txtEmail")).Text;
            string sMobile = ((TextBox)GvStaff.Rows[e.RowIndex].FindControl("txtMobile")).Text;
            string sQual = ((TextBox)GvStaff.Rows[e.RowIndex].FindControl("txtQual")).Text;
            string sAdd = ((TextBox)GvStaff.Rows[e.RowIndex].FindControl("txtAdd")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblStaff set StaffName='" + sName + "', Email='" + sEmail + "', Mobile='" + sMobile + "'," +
                " Qualification='" + sQual + "', Address='" + sAdd + "' where StaffId ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvStaff.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }
    }
}