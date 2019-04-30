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
    public partial class ViewTeachers : System.Web.UI.Page
    {
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
            string query = "select  TeacherId, TeacherName, Mobile, Address,Email, ModuleAssigned from tblTeacher";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvTeacher.DataSource = dt;
            GvTeacher.DataBind();
        }

        protected void GvTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvTeacher.EditIndex = -1;
            show();
        }

        protected void GvTeacher_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvTeacher.Rows[e.RowIndex].FindControl("lblID")).Text));
            string query = "delete from tblTeacher where TeacherId='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            lbl.ForeColor = System.Drawing.Color.Red;
            show();
        }

        protected void GvTeacher_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvTeacher.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvTeacher_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvTeacher.Rows[e.RowIndex].FindControl("lblID")).Text));
            string tName = ((TextBox)GvTeacher.Rows[e.RowIndex].FindControl("txtname")).Text;
            string tMobile = ((TextBox)GvTeacher.Rows[e.RowIndex].FindControl("txtmobile")).Text;
            string tAddress = ((TextBox)GvTeacher.Rows[e.RowIndex].FindControl("txtadd")).Text;
            string tEmail = ((TextBox)GvTeacher.Rows[e.RowIndex].FindControl("txtemail")).Text;
           
            string mAssigned = ((TextBox)GvTeacher.Rows[e.RowIndex].FindControl("txtmassigned")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblTeacher set TeacherName='" + tName + "', Mobile='" + tMobile + "', Address ='" + tAddress + "'," +
                "Email='" + tEmail + "', ModuleAssigned='" + mAssigned + "' where TeacherId ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvTeacher.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }
    }
}