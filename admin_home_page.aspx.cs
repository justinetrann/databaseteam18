﻿using System;

using System.Collections.Generic;

using System.Configuration;

using System.Data.SqlClient;

using System.Data;

using System.Linq;

using System.Web;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Diagnostics;
namespace databaseteam18
{

    public partial class admin_home_page : System.Web.UI.Page

    {
        protected GridView GridViewAdmin;

        protected void Page_Load(object sender, EventArgs e)

        {

            userRoleAssignmentSubmitButton.ServerClick += new EventHandler(userRoleAssignmentSubmitButton_Click);

            // GETTING USER EMAILS
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            var queryString = "SELECT u.user_email, r.role_type FROM COMPANY.User_Login u LEFT JOIN COMPANY.role r ON u.user_role_ID = r.role_ID"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridViewAdmin.DataSource = ds.Tables[0];
            GridViewAdmin.DataBind();


        }


        protected void userRoleAssignmentSubmitButton_Click(object sender, EventArgs e)

        {

            //check if all required fields are filled


            if (string.IsNullOrEmpty(user_login_email.Value) || string.IsNullOrEmpty(role_id.Value))

            {

                //Display error message

                errorMessage.InnerHtml = "Please fill in all fields.";

                errorMessage.Style.Remove("display");

                return;

            }

            //C/*heck if user email exists in databa*/se


            try

            {
                SuccessMessage.Style.Add("display", "none");
                errorMessage.Style.Add("display", "none");

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                string email = user_login_email.Value;
                int roleID = int.Parse(role_id.Value);

                string query = "SELECT * FROM COMPANY.User_Login WHERE user_email=@Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //if email exist in database, update user role


                    int rowCount = 0;

                    while (reader.Read())
                    {
                        rowCount++;
                    }


                    if (rowCount != 1)
                    {
                        errorMessage.InnerHtml = "Something unexpected happened. Please try again later.(more than 1 row returned by user_login table";
                        errorMessage.Style.Remove("display");
                        return;
                    }







                    string update_query = " UPDATE COMPANY.User_Login SET user_role_ID = @roleID WHERE user_email=@Email;";
                    SqlCommand update_command = new SqlCommand(update_query, connection);
                    update_command.Parameters.AddWithValue("@Email", email);
                    update_command.Parameters.AddWithValue("@roleID", roleID);
                    update_command.ExecuteNonQuery();

                    if (update_command.ExecuteNonQuery() == 1)
                    {
                        SuccessMessage.InnerHtml = "User Role Updated Successfully";
                        SuccessMessage.Style.Remove("display");
                    }
                    else
                    {
                        //Display an error message
                        errorMessage.InnerHtml = "Error while updating user role!";
                        errorMessage.Style.Remove("display");
                    }

                    reader.Close();

                }
                else
                {
                    //Display an error message
                    errorMessage.InnerHtml = "This user login email does not exist in the database!";
                    errorMessage.Style.Remove("display");
                }


                reader.Close();

                connection.Close();


            }

            catch (Exception ex)

            {

                //Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis


               Console.WriteLine("An error occurred: " + ex.Message);
               errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                errorMessage.Style.Remove("display");

            }






        }


        
       



    }




}

