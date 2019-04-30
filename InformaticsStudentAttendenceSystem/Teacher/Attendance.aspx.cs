using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InformaticsStudentAttendenceSystem.Teacher
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
                GvAttendance.Visible = false;
                //GvAttendanceByYear.Visible = false;
                btnSave.Visible = false;
                //btnSaveLecture.Visible = false;
            }
        }

       
        public void FillDropDown()
        {
            //DropDownYear();
            //DropDownModuleCode();
            DropDownGroup();
            DropDownModuleId();
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

      
        public void DropDownModuleId()
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

        protected void listStudent_Click(object sender, EventArgs e)
        {
            GvAttendance.Visible = true;
            //GvAttendanceByYear.Visible = false;
            btnSave.Visible = true;
            //btnSaveLecture.Visible = false;
            PopulateGridviewbyGroup();
        }

       
        
        void PopulateGridviewbyGroup()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            DataTable dt = new DataTable();
            var MID = drpModuleId.SelectedValue;
            var GNAME = drpGroup.SelectedValue;

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT STUDENTID, STUDENTNAME FROM tblStudent WHERE ModuleCode='" + MID + "' AND \"Group\" ='" + GNAME + "' ", con);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GvAttendance.DataSource = dt;
                GvAttendance.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvAttendance.DataSource = dt;
                GvAttendance.DataBind();
                GvAttendance.Rows[0].Cells.Clear();
                GvAttendance.Rows[0].Cells.Add(new TableCell());
                GvAttendance.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                GvAttendance.Rows[0].Cells[0].Text = "No Data Found ..!";
                GvAttendance.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            foreach (GridViewRow row in GvAttendance.Rows)
            {
                var SID = ((Label)row.FindControl("sID")).Text;
                var SNAME = ((Label)row.FindControl("sName")).Text;
                var STATUS = ((DropDownList)row.Cells[2].FindControl("drpstatusList")).SelectedValue;
                var DATE = DateTime.Now;
                var MID = drpModuleId.SelectedValue;
                var GNAME = drpGroup.SelectedValue;

                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO tblAttendance (STUDENTID, STUDENTNAME, MODULEID, GROUPNAME, DATE, STATUS)" +
                    " VALUES ('" + SID + "', '" + SNAME + "', '" + MID + "', '" + GNAME + "', '"+ DATE +"','" + STATUS + "' )", con);
                cmd.ExecuteNonQuery();
                con.Close();

                lbl.Text = "Success";
                lbl.ForeColor = System.Drawing.Color.Green;
            }
        }

        //void PopulateGridviewbyYear()
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        //    DataTable dt = new DataTable();
        //    var MID = drpModuleCode.SelectedValue;
        //    var YEAR = drpGroup.SelectedValue;

        //    con.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter("SELECT STUDENTID, STUDENTNAME FROM tblStudent WHERE ModuleCode='" + MID + "' AND \"Group\" ='" + YEAR + "' ", con);
        //    sda.Fill(dt);

        //    if (dt.Rows.Count > 0)
        //    {
        //        GvAttendance.DataSource = dt;
        //        GvAttendance.DataBind();
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        GvAttendance.DataSource = dt;
        //        GvAttendance.DataBind();
        //        GvAttendance.Rows[0].Cells.Clear();
        //        GvAttendance.Rows[0].Cells.Add(new TableCell());
        //        GvAttendance.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
        //        GvAttendance.Rows[0].Cells[0].Text = "No Data Found ..!";
        //        GvAttendance.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //    }

        //}

        //protected void btnSaveLecture_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
        //    foreach (GridViewRow row in GvAttendance.Rows)
        //    {
        //        var SID = ((Label)row.FindControl("sID")).Text;
        //        var SNAME = ((Label)row.FindControl("sName")).Text;
        //        var STATUS = ((DropDownList)row.Cells[2].FindControl("statusList")).SelectedValue;
        //        var DATE = DateTime.Now;
        //        var MID = drpModuleCode.SelectedValue;
        //        var GNAME = drpGroup.SelectedValue;

        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("INSERT INTO ATTENDENCE (STUDENTID, STUDENTNAME, CLASSID, DATE, STATUS)" +
        //            " VALUES ('" + SID + "', '" + SNAME + "', '" + MID + "', '" + GNAME + "', '"+ DATE +"','" + STATUS + "' )", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //        lbl.Text = "Success";
        //    }
        //}
    }
}