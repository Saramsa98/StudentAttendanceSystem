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
    public partial class AddCoursesByAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show(); // calling the function when the page loads
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for insert
        /// </summary>
        protected void btnCourse_Click(object sender, EventArgs e)
        {
            //creating the datbase coonnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //query to insert the course details
            string query = "insert into tblCourse values('" + txtCode.Text + "','" + txtCname.Text + "')";
            //opening the database connection
            con.Open();
            //Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(query, con);
            //Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
            //closing the database connection
            con.Close();
            lbl.Text = "Insert Successfully!";
            show(); //calling the function 
        }
        /// <summary>
        /// use ExecuteNonQuery method for displaying the course table data in gridview
        /// </summary>
        public void show()
        {
            //creating the database connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //selection query string for course table
            string query = "select Id, CourseCode, CourseName from tblCourse";
            con.Open(); //opening the connectuon
            //Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(query, con);
            //Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
            //creating the new datatable
            DataTable dt = new DataTable();  //creating new datatable
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt); //filling the datatable
            GvCourse.DataSource = dt;
            GvCourse.DataBind();
            con.Close(); //closing the datbase connection
        }

        protected void GvCourse_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvCourse.EditIndex = -1;
            show(); //calling the show function
        } 

        /// <summary>
        /// use ExecuteNonQuery method for Delete
        /// </summary>
        protected void GvCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvCourse.Rows[e.RowIndex].FindControl("lblCId")).Text));

            //query for deleting the the details of selected course
            string query = "delete from tblCourse where id='" + id + "'"; 
            con.Open(); //opening the connection
            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            cmd.ExecuteNonQuery();   //Call ExecuteNonQuery to send command
            con.Close();  //closing the database connection
            lbl.Text = "Deleted Successfully!";
            show(); //calling the function
        }

        protected void GvCourse_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvCourse.EditIndex = e.NewEditIndex;
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for Update
        /// </summary>
        protected void GvCourse_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //creating the variable
            int id = (Convert.ToInt32(((Label)GvCourse.Rows[e.RowIndex].FindControl("lblCId")).Text));
            string cCode = ((TextBox)GvCourse.Rows[e.RowIndex].FindControl("txtCode")).Text;
            string cName = ((TextBox)GvCourse.Rows[e.RowIndex].FindControl("txtCname")).Text;
            //creating the connection string
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);

            //query for updating the course details
            string query = "update tblCourse set CourseCode='" + cCode + "', CourseName='" + cName + "' where id ='" + id + "'";
            //Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(query, con);
            //opening the database connection
            con.Open();
            //Call ExecuteNonQuery to send command
            cmd.ExecuteNonQuery();
            //closing the database connection
            con.Close();
            GvCourse.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show(); //calling the show function
        }
    }
}