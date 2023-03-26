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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginButton.ServerClick += new EventHandler(loginButton_Click);
        }

        protected void loginButton_Click(object sender, EventArgs e)

        {


            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                string email = login_email.Value;
                string password = login_password.Value;

                string query = "SELECT * FROM COMPANY.User_Login WHERE user_email=@Email AND user_password=@Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //Create a session for the user


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

                    reader.Close();

                    reader = command.ExecuteReader();

                 

                    //Redirect the user to the home page
                    while (reader.Read())


                    {
                        Session["user_login_id"] = reader.GetInt32(0);
                        Session["employee_id"] = reader.GetInt32(7);
                       
                    }

                    Response.Redirect("~/Default.aspx");


                }
                else
                {
                    // Display an error message
                    errorMessage.InnerHtml = "Your Email or Password is incorrect!";
                    errorMessage.Style.Remove("display");
                }

                reader.Close();
                command.Dispose();














                connection.Close();
               













               

                //command.ExecuteNonQuery();

           




                //errorMessage.Style.Add("display", "none");

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