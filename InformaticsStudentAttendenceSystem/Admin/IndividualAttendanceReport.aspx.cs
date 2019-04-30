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
    public partial class IndividualAttendanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownStudentId();
            }
        }
        /// <summary>
        /// use ExecuteReader method for getting the value 
        /// </summary>
        public void DropDownStudentId()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpStudentId.Items.Clear();
                con.Open();
                string query = "select *from tblStudent";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["StudentId"].ToString();
                    newItem.Value = reader["StudentId"].ToString();
                    this.drpStudentId.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }



        protected void listStudentReport_Click(object sender, EventArgs e)
        {
            //creating the connection string
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            //using the condition for generting the report
            if (drpIndividualReportType.SelectedValue == "Daily")
            {


                con.Open();
                string query = "SELECT StudentId, StudentName, ModuleId, GroupName, Date, Status " +
                    "FROM tblAttendance WHERE StudentId='" + drpStudentId.SelectedValue + "' AND \"Date\"='"+DateTime.Today+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvIndividualReport.DataSource = dt;
                GvIndividualReport.DataBind();
                con.Close();

            }
            else if (drpIndividualReportType.SelectedValue == "Weekly")
            {
                //defining the variable
                var MONDAY = DateTime.Now.AddDays(((int)DateTime.Now.DayOfWeek * -1) + 1);
                MONDAY = new DateTime(MONDAY.Year, MONDAY.Month, MONDAY.Day, 00, 0, 0);

                var FRIDAY = MONDAY.AddDays(4);
                FRIDAY = new DateTime(FRIDAY.Year, FRIDAY.Month, FRIDAY.Day, 23, 0, 0);

                con.Open();
                string query = "SELECT StudentId, StudentName, ModuleId, GroupName, Date, Status " +
                    "FROM tblAttendance WHERE StudentId='" + drpStudentId.SelectedValue + "' AND DATE>='" + MONDAY + "' AND DATE<='" + FRIDAY + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvIndividualReport.DataSource = dt;
                GvIndividualReport.DataBind();
                con.Close();
            }
            else
            {
                var MONTH = DateTime.Now.Month;
                var YEAR = DateTime.Now.Year;
                con.Open();
                string query = "SELECT StudentId, StudentName, ModuleId, GroupName, Date, Status " +
                    "FROM tblAttendance WHERE StudentId='" + drpStudentId.SelectedValue + "' AND MONTH(Date)='" + MONTH + "' AND YEAR(DATE)='" + YEAR + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
               
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvIndividualReport.DataSource = dt;
                GvIndividualReport.DataBind();
                con.Close();

            }
        }
    }
}