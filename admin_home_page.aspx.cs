using System;

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

        protected void Page_Load(object sender, EventArgs e)

        {

            userRoleAssignmentSubmitButton.ServerClick += new EventHandler(userRoleAssignmentSubmitButton_Click);

        }




        protected void userRoleAssignmentSubmitButton_Click(object sender, EventArgs e)

        {

            //check if all required fields are filled


            if (string.IsNullOrEmpty(user_login_email.Value) || string.IsNullOrEmpty(role_id.Value))

            {

                // Display error message

                errorMessage.InnerHtml = "Please fill in all fields.";

                errorMessage.Style.Remove("display");

                return;

            }

            // Check if user email exists in database


            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                string email = user_login_email.Value;
                string roleID = role_id.Value;

                string query = "SELECT * FROM COMPANY.User_Login WHERE user_email=@Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // if email exist in database, update user role


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



                    



                    string query = " UPDATE COMPANY.User_Login SET user_role_ID = @roleID WHERE user_email=@Email;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@roleID", roleID);

                    successMessage.InnerHtml = "User Role Updated Successfully";
                    successMessage.Style.Remove("display");
                    reader.Close();

                }
                else
                {
                    // Display an error message
                    errorMessage.InnerHtml = "This user login email does not exist in the database!";
                    errorMessage.Style.Remove("display");
                }

                reader.Close();
                command.Dispose();

                connection.Close();


            }

            catch (Exception ex)

            {

                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis

                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                errorMessage.Style.Remove("display");

            }






        }






    }




}

