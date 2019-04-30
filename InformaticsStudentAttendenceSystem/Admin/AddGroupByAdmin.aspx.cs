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
    public partial class AddGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //calling the function
                show();
                FillDropdown();   
            }
        }

        /// <summary>
        /// use ExecuteReader method for getting the value 
        /// </summary>
        public void FillDropdown()
        {
            this.drpYear.Items.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString))
            {
                con.Open(); //openiong the connection
                string query = "select *from tblYear"; //selection query string for table year
                SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
                SqlDataReader reader = cmd.ExecuteReader();  //Call execute reader to send command

                while (reader.Read())
                {
                    ListItem newItem = new ListItem(); // creating the new listitem
                    newItem.Text = reader["Year"].ToString(); 
                    newItem.Value = reader["Year"].ToString();
                    this.drpYear.Items.Add(newItem); 

                }
                reader.Close(); //closing kteh sql data reader
                con.Close(); //closing the connection
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for insert
        /// </summary>
        protected void btnadd_Click(object sender, EventArgs e)
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "insert into tblGroup values('" + txtGname.Text + "','" + drpYear.SelectedItem.Value + "')";
            //Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();//opening the database connection

            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close();//closing the database connection
            lbl.Text = "Insert Successfully!";
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for displaying the group table data in gridview
        /// </summary>
        public void show()
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            string query = "select Id, GroupName, Year from tblGroup";
            con.Open();
            //Instantiate a new command with a query and connection
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            DataTable dt = new DataTable(); //creating new datatable
            SqlDataAdapter sda = new SqlDataAdapter(cmd); 
            sda.Fill(dt); //filling the datatable
            GvGroup.DataSource = dt;
            GvGroup.DataBind();
            con.Close(); //closing the database connection
        }

        protected void GvGroup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvGroup.EditIndex = -1;
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for Delete
        /// </summary>
        protected void GvGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            int id = (Convert.ToInt32(((Label)GvGroup.Rows[e.RowIndex].FindControl("Label1")).Text));
            //delete query string
            string query = "delete from tblGroup where id='" + id + "'";
            con.Open(); //opening the database connection
            SqlCommand cmd = new SqlCommand(query, con); //Instantiate a new command with a query and connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close();
            lbl.Text = "Deleted Successfully!";
            show();
        }

        protected void GvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvGroup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvGroup.EditIndex = e.NewEditIndex;
            show(); //calling the show function
        }

        /// <summary>
        /// use ExecuteNonQuery method for update
        /// </summary>
        protected void GvGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { 
            //creating the variable
            int id = (Convert.ToInt32(((Label)GvGroup.Rows[e.RowIndex].FindControl("Label1")).Text));
            string gName = ((TextBox)GvGroup.Rows[e.RowIndex].FindControl("txtgName")).Text;
            string Year = ((TextBox)GvGroup.Rows[e.RowIndex].FindControl("txtYear")).Text;
            // Creating instance of SqlConnection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString);
            //update query for table group
            string query = "update tblGroup set GroupName='" + gName + "', Year='" + Year + "' where id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);//Instantiate a new command with a query and connection
            con.Open(); //opening the database connection
            cmd.ExecuteNonQuery(); //Call ExecuteNonQuery to send command
            con.Close(); //closing the database connection
            GvGroup.EditIndex = -1;
            lbl.Text = "Updated Successfully!";
            show(); //calling the show function
        }
    }
}