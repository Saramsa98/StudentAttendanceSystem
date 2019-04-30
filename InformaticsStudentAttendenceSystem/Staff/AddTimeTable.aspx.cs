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
    public partial class AddTimeTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDropDown();
                show();
            }
        }
        public void FillDropDown()
        {
            DropDownYear();
            DropDownCourseName();
            DropDownModuleCode();
            DropDownModuleName();
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
        public void DropDownCourseName()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpCourse.Items.Clear();
                con.Open();
                string query = "select *from tblCourse";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["CourseName"].ToString();
                    newItem.Value = reader["CourseName"].ToString();
                    this.drpCourse.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }

        public void DropDownModuleCode()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpModulecode.Items.Clear();
                con.Open();
                string query = "select *from tblModule";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["ModuleCode"].ToString();
                    newItem.Value = reader["ModuleCode"].ToString();
                    this.drpModulecode.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        public void DropDownModuleName()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnectionString"].ConnectionString))
            {
                this.drpModuletitle.Items.Clear();
                con.Open();
                string query = "select *from tblModule";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = reader["ModuleName"].ToString();
                    newItem.Value = reader["ModuleName"].ToString();
                    this.drpModuletitle.Items.Add(newItem);
                }
                reader.Close();
                con.Close();
            }
        }
        protected void btnTimetable_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblTimeTable values ('" + txtDay.Text + "','" + txtTime.Text + "','" + txtClass.Text + "','" + drpYear.SelectedItem.Value + "'," +
                "'" + drpCourse.SelectedItem.Value + "','" + txtIntake.Text + "','" + drpModulecode.SelectedItem.Value + "','" + drpModuletitle.SelectedItem.Value + "'," +
                "'" + txtLecturer.Text + "','" + drpGroup.SelectedItem.Value + "','" + txtRoom.Text + "')";
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
            string query = "select Id, Day, Time, ClassType, Year, CourseName,Intake, ModuleCode,ModuleTitle ,Lecturer,GroupName, Room from tblTimeTable";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvTimeTable.DataSource = dt;
            GvTimeTable.DataBind();
            con.Close();
        }

        protected void GvTimeTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvTimeTable.EditIndex = -1;
            show();
        }

        protected void GvTimeTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvTimeTable.Rows[e.RowIndex].FindControl("lblId")).Text));
            string query = "delete from tblTimeTable where id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvTimeTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvTimeTable.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvTimeTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (Convert.ToInt32(((Label)GvTimeTable.Rows[e.RowIndex].FindControl("lblId")).Text));
            string day = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtDay")).Text;
            string time = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtTime")).Text;
            string classtype = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtClassType")).Text;
            string year = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtYear")).Text;
            string coursename = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtCourseName")).Text;
            string intake = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtIntake")).Text;
            string modulecode = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtModuleCode")).Text;
            string moduletitle = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtModuleTitle")).Text;
            string lecturer = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtLecturer")).Text;
            string groupname = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtGroupName")).Text;
            string room = ((TextBox)GvTimeTable.Rows[e.RowIndex].FindControl("txtRoom")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblTimeTable set Day='" + day + "', Time='" + time + "',ClassType='"+classtype+"',Year='"+year+"', CourseName='"+coursename+"', " +
                "Intake='"+intake+"', ModuleCode='"+modulecode+"', ModuleTitle='"+moduletitle+"',Lecturer='"+lecturer+"', GroupName='"+groupname+"'," +
                " Room='"+room+"' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvTimeTable.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            lbl.ForeColor = System.Drawing.Color.Green;
            show();
        }
    }
}