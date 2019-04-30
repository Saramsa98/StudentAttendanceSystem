using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace InformaticsStudentAttendenceSystem.Staff
{
    public partial class AddGroup : System.Web.UI.Page
    {
        //SqlConnection con;
        //SqlCommand cmd;
        //DataTable dt;
        //SqlDataReader reader;
        //string conn = @"Data Source=LAPTOP-LQOFE7MO\SQLEXPRESS;Initial Catalog=AttendanceSystem_Database;Integrated Security=True";

        public void FillDropdown()
        {
            this.drpYear.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                show();
                FillDropdown();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //var dt = Request.Form[drpYear.ID];

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblGroup values('" + txtGname.Text + "','" + drpYear.SelectedItem.Value+ "')";
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
            string query = "select Id, GroupName, Year from tblGroup";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            GvGroup.DataSource = dt;
            GvGroup.DataBind();
            con.Close();
        }

        protected void GvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvGroup.EditIndex = -1;
            show();
        }

        protected void GvGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvGroup.Rows[e.RowIndex].FindControl("Label1")).Text));
            string query = "delete from tblGroup where id='" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvGroup.EditIndex = e.NewEditIndex;
            show();
        }

        protected void GvGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
             int id = (Convert.ToInt32(((Label)GvGroup.Rows[e.RowIndex].FindControl("Label1")).Text));
            string gName = ((TextBox)GvGroup.Rows[e.RowIndex].FindControl("txtgName")).Text;
            string Year = ((TextBox)GvGroup.Rows[e.RowIndex].FindControl("txtYear")).Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "update tblGroup set GroupName='"+gName+"', Year='"+Year+"' where id ='"+id+"'";
           
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GvGroup.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show();
        }
    }
}