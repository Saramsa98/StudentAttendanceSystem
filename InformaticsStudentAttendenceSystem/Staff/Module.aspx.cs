using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace InformaticsStudentAttendenceSystem.Staff
{
    public partial class Module : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
                dropdownCoursenName();
            }
            
        }

        public void dropdownCoursenName ()
        {
            this.drpCname.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "select *from tblCourse";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["CourseName"].ToString();
                    newItem.Value = reader["CourseName"].ToString();
                    this.drpCname.Items.Add(newItem);

                }
                reader.Close();
                con.Close();
            }
        }
        protected void btnModule_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblModule values('" + drpCname.Text + "','" + txtModuleCode.Text + "','"+ txtModuleName.Text + "')";
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
            string query = "select Id,  ModuleCode, ModuleName, CourseName from tblModule";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvModule.DataSource = dt;
            GvModule.DataBind();
            con.Close();
        }

        protected void GvModule_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvModule.EditIndex = -1;
            show();
        }

        protected void GvModule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvModule.Rows[e.RowIndex].FindControl("lblModuleId")).Text));
            string query = "delete from tblModule where id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvModule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvModule.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvModule_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvModule.Rows[e.RowIndex].FindControl("lblModuleId")).Text));
            string mCode = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtModuleCode")).Text;
            string mName = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtModuleName")).Text;
            string course = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtCourse")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblModule set ModuleCode='"+mCode+"', ModuleName='" + mName + "', Course='" + course + "' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvModule.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show();
        }
    }
}