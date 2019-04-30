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
    public partial class TeacherReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
                FillDropDown();
            }
        }
        public void FillDropDown()
        {
            DropDownModuleName();
            DropDownTeacherType();
        }
        public void DropDownModuleName()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpModuleName.Items.Clear();
                con.Open();
                string query = "select *from tblModule";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["ModuleName"].ToString();
                    newItem.Value = reader["ModuleName"].ToString();
                    this.drpModuleName.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        public void DropDownTeacherType()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpTeacherType.Items.Clear();
                con.Open();
                string query = "select *from tblTeacher";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["TeacherType"].ToString();
                    newItem.Value = reader["TeacherType"].ToString();
                    this.drpTeacherType.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        //show data in grid view
        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "select  TeacherId, TeacherName, Mobile, Email,  ModuleAssigned, TeachingHrs from tblTeacher";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvTeacherReport.DataSource = dt;
            GvTeacherReport.DataBind();
            con.Close();
        }

        protected void GvTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvTeacherReport.EditIndex = -1;
            show();
        }

        protected void GvTeacher_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvTeacherReport.Rows[e.RowIndex].FindControl("lblID")).Text));
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
            GvTeacherReport.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvTeacher_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvTeacherReport.Rows[e.RowIndex].FindControl("lblID")).Text));
            string tName = ((TextBox)GvTeacherReport.Rows[e.RowIndex].FindControl("txtname")).Text;
            string tMobile = ((TextBox)GvTeacherReport.Rows[e.RowIndex].FindControl("txtmobile")).Text;
            
            string tEmail = ((TextBox)GvTeacherReport.Rows[e.RowIndex].FindControl("txtemail")).Text;
           
            string mAssigned = ((TextBox)GvTeacherReport.Rows[e.RowIndex].FindControl("txtmassigned")).Text;
            string tHours = ((TextBox)GvTeacherReport.Rows[e.RowIndex].FindControl("txttHrs")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblTeacher set TeacherName='" + tName + "', Mobile='" + tMobile + "', Email='" + tEmail + "'," +
                " ModuleAssigned='" + mAssigned + "', TeachingHrs='"+tHours+"' where TeacherId ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvTeacherReport.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }

        public void Search()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "select  TeacherId, TeacherName, Mobile, Email,  ModuleAssigned, TeachingHrs from tblTeacher where TeacherType='" + drpTeacherType.SelectedValue + "' AND ModuleAssigned='"+drpModuleName.SelectedValue+"' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvTeacherType.DataSource = dt;
            GvTeacherType.DataBind();
            con.Close();

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GvTeacherReport.Visible = false;
            GvTeacherType.Visible = true;
            Search();
        }
    }
}