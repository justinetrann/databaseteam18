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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            //check if all required fields are filled
            if (string.IsNullOrEmpty(users_email.Value) || string.IsNullOrEmpty(user_password.Value) || string.IsNullOrEmpty(confirm_password.Value))
            {
                // Display error message
                errorMessage.InnerHtml = "Please fill in all fields.";
                errorMessage.Style.Remove("display");
                return;
            }
            // Check if passwords match
            if (user_password.Value != confirm_password.Value)
            {
                // Display error message
                errorMessage.InnerHtml = "Passwords do not match!";
                errorMessage.Style.Remove("display");
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                int login_ID = new Random().Next(50000, 90000);

                string query = "INSERT INTO COMPANY.User_Login (login_ID, user_email, user_password) VALUES (@login_id, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login_id", login_ID);
                command.Parameters.AddWithValue("@Email", users_email.Value);
                command.Parameters.AddWithValue("@Password", user_password.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                errorMessage.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



    }

}




