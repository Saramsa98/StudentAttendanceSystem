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
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropDown();
            }
        }

        public void FillDropDown()
        {
            DropDownYear();
            DropDownCourseName();
            DropDownModuleCode();
            DropDownGroup();
        }

        public void DropDownYear()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                con.Open();
                string query = "select *from tblYear";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["Year"].ToString();
                    newItem.Value = reader["Year"].ToString();
                    this.drpYear.Items.Add(newItem);

                }
                reader.Close();
                con.Close();
            }
        }

        public void DropDownGroup()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpGroup.Items.Clear();
                con.Open();
                string query = "select *from tblGroup";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["GroupName"].ToString();
                    newItem.Value = reader["GroupName"].ToString();
                    this.drpGroup.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        public void DropDownModuleCode()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpModuleId.Items.Clear();
                con.Open();
                string query = "select *from tblModule";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["ModuleCode"].ToString();
                    newItem.Value = reader["ModuleCode"].ToString();
                    this.drpModuleId.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        public void DropDownCourseName()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpCourseName.Items.Clear();
                con.Open();
                string query = "select *from tblCourse";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["CourseName"].ToString();
                    newItem.Value = reader["CourseName"].ToString();
                    this.drpCourseName.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "insert into tblStudent values('" + txtStudentId.Text + "','" + txtStudentName.Text + "', '" + txtAdd.Text + "'," +
                "'" + txtMobile.Text + "','" + txtEmail.Text + "','" + txtDOB.Text + "','" + drpGender.SelectedItem.Value + "'," +
                "'" + txtEnrollDate.Text + "','" + drpCourseName.Text + "','"+drpModuleId.SelectedValue+"'," +
                "'"+drpGroup.SelectedValue+"','"+drpYear.SelectedValue+"')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Insert Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("~/Staff/ViewStudent.aspx");
        }
    }
}