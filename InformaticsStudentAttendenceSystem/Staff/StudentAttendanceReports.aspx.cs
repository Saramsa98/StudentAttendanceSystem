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
    public partial class StudentAttendanceReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownGroup();
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

        protected void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            var REPORT_TYPE = drpReportType.SelectedValue;

            if (REPORT_TYPE == "Daily")
            {

                con.Open();
                string query = "SELECT STUDENTID, STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS " +
                    "FROM tblAttendance WHERE GROUPNAME='" + drpGroup.SelectedValue + "' AND \"Date\"='"+DateTime.Today+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvAttendanceReport.DataSource = dt;
                GvAttendanceReport.DataBind();

            }
            else if (REPORT_TYPE == "Weekly")
            {

                var MONDAY = DateTime.Now.AddDays(((int)DateTime.Now.DayOfWeek * -1) + 1);
                MONDAY = new DateTime(MONDAY.Year, MONDAY.Month, MONDAY.Day, 00, 0, 0);

                var FRIDAY = MONDAY.AddDays(4);
                FRIDAY = new DateTime(FRIDAY.Year, FRIDAY.Month, FRIDAY.Day, 23, 0, 0);

                con.Open();
                string query = "SELECT STUDENTID, STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS " +
                    "FROM tblAttendance WHERE GROUPNAME='" + drpGroup.SelectedValue + "' AND DATE>='" + MONDAY + "' AND DATE<='" + FRIDAY + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvAttendanceReport.DataSource = dt;
                GvAttendanceReport.DataBind();
            }
            else
            {
                var MONTH = DateTime.Now.Month;
                var YEAR = DateTime.Now.Year;

                con.Open();

                string query = "SELECT STUDENTID, STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS " +
                    "FROM tblAttendance WHERE GROUPNAME='" + drpGroup.SelectedValue + "' AND MONTH(DATE)='" + MONTH + "' AND YEAR(DATE)='" + YEAR + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                GvAttendanceReport.DataSource = dt;
                GvAttendanceReport.DataBind();

            }

        }
    }
}