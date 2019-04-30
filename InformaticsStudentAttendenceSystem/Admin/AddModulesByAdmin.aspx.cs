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
    public partial class AddModulesByAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //calling the function
                show();
                dropdownCoursenName(); 
            }

        }

        /// <summary>
        /// use ExecuteNonQuery method for insert
        /// </summary>
        protected void btnModule_Click(object sender, EventArgs e)
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //insertion  query string
            string query = "insert into tblModule values('" + drpCname.Text + "','" + txtModuleCode.Text + "','" + txtModuleName.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            con.Open(); //opening the connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close(); //closing the connection
            lbl.Text = "Insert Successfully!";
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteReader method for getting the value 
        /// </summary>
        public void dropdownCoursenName()
        {
            this.drpCname.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                con.Open(); //opening the connection
                string query = "select *from tblCourse"; //selection query string
                SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
                SqlDataReader reader = cmd.ExecuteReader(); //Call Execute reader to get query results

                while (reader.Read())
                {
                    ListItem newItem = new ListItem(); //creating the new list item
                    newItem.Text = reader["CourseName"].ToString(); 
                    newItem.Value = reader["CourseName"].ToString(); 
                    this.drpCname.Items.Add(newItem); 

                }
                reader.Close(); //closing the reader
                con.Close(); //closing the database connection
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for displaying the module table data in gridview
        /// </summary>
        public void show()
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //selection query string 
            string query = "select Id,  ModuleCode, ModuleName, CourseName from tblModule"; //selection query for table module
            con.Open(); //opening the connection
            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            DataTable dt = new DataTable(); //creating the new datatable
            SqlDataAdapter sda = new SqlDataAdapter(cmd); 
            sda.Fill(dt); //fill the datatable
            GvModule.DataSource = dt; 
            GvModule.DataBind(); 
            con.Close(); //closing the database connection
        }

        protected void GvModule_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvModule.EditIndex = -1;
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for Delete
        /// </summary>
        protected void GvModule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvModule.Rows[e.RowIndex].FindControl("lblModuleId")).Text));
            //delete query string for table module
            string query = "delete from tblModule where id='" + id + "'";
            con.Open(); //opening the database connection
            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close(); //closing the connection
            lbl.Text = "Deleted Successfully!";
            show(); //calling the show function
        }

        protected void GvModule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvModule.EditIndex = e.NewEditIndex;
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for update
        /// </summary>

        protected void GvModule_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //defining the variable
            int id = (Convert.ToInt32(((Label)GvModule.Rows[e.RowIndex].FindControl("lblModuleId")).Text));
            string mCode = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtModuleCode")).Text;
            string mName = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtModuleName")).Text;
            string course = ((TextBox)GvModule.Rows[e.RowIndex].FindControl("txtCourse")).Text;
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //update query string for the module table
            string query = "update tblModule set ModuleCode='" + mCode + "', ModuleName='" + mName + "', CourseName='" + course + "' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            con.Open(); //opening the database connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close(); //closing the datbase connection
            GvModule.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show(); //calling the show funciton
        }
    }
}