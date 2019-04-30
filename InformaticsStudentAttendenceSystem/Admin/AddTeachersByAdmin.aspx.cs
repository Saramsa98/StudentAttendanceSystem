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
    public partial class AddTeachersByAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownModuleName();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            string query = "insert into tblTeacher values('" + txtname.Text + "','" + txtmobile.Text + "','" + txtemail.Text + "','" + txtDOB.Text + "'," +
                "'" + txtqual.Text + "','" + txtadd.Text + "','" + ddlgender.SelectedItem.Text + "','" + drpModule.SelectedValue + "'," +
                "'" + txtTeacherType.Text + "', '" + txtTeachingHrs.Text + "','" + txtuname.Text + "','" + txtpass.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Insert Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            Response.Redirect("~/Admin/ViewTeachers.aspx");
        }

        public void DropDownModuleName()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpModule.Items.Clear();
                con.Open();
                string query = "select *from tblModule";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["ModuleName"].ToString();
                    newItem.Value = reader["ModuleName"].ToString();
                    this.drpModule.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
    }
}