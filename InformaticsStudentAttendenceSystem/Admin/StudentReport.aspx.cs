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
    public partial class ViewStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
                DropDownCourseName();
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

        
        public void show()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "select StudentId, StudentName, Address, Email, Gender, EnrollDate, CourseName from tblStudent order by EnrollDate ";
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
        public void Search()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "select StudentId, StudentName, Address, Email, Gender, EnrollDate, CourseName from tblStudent where CourseName='" + drpCourseName.SelectedValue +"' ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvSearch.DataSource = dt;
            GvSearch.DataBind();
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GvStudent.Visible = false;
            GvSearch.Visible = true;
            Search();
        }
    }
}