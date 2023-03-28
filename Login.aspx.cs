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
using System.Threading;

namespace databaseteam18
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginButton.ServerClick += new EventHandler(loginButton_Click);
            signupButton.ServerClick += new EventHandler(signupButton_Click);
        }

        protected void loginButton_Click(object sender, EventArgs e)

        {


            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                string email = login_email.Value;
                string password = login_password.Value;
                int employee_id = -1;

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


                    // Set Session Variables and Redirect the user to the home page
                    while (reader.Read())


                    {
                        Session["user_login_id"] = Convert.ToInt32(reader["login_ID"]);
                        Session["employee_id"] = Convert.ToInt32(reader["employee_ID"]);
                        Session["role_id"] = Convert.ToInt32(reader["user_role_ID"]);
                        //setting current user department_id and project_id to default value -1
                        Session["department_id"] = -1;
                        Session["project_id"] = -1;

                        employee_id = Convert.ToInt32(reader["employee_ID"]);


                    }

                    //reader.Close();


                    ////// Read user current department_id and project_id
                    ///
                    
                    string read_dept_query = "SELECT dept_ID FROM COMPANY.employees WHERE employee_id=@employee_id;";
                    SqlCommand read_deptcommand = new SqlCommand(read_dept_query, connection);
                    read_deptcommand.Parameters.AddWithValue("@employee_id", employee_id);

                    //connection.Open();
                    SqlDataReader read_deptreader = read_deptcommand.ExecuteReader();

                    if (read_deptreader.HasRows)
                    {


                        rowCount = 0;

                        while (read_deptreader.Read())
                        {
                            rowCount++;
                        }


                        if (rowCount != 1)
                        {
                            errorMessage.InnerHtml = "Something unexpected happened. Please try again later.(more than 1 row returned by user_login table";
                            errorMessage.Style.Remove("display");
                            return;
                        }

                        read_deptreader.Close();

                        read_deptreader = read_deptcommand.ExecuteReader();



                        //Read current employee department id
                        while (read_deptreader.Read())


                        {
                            Session["department_id"] = Convert.ToInt32(read_deptreader["dept_ID"]);


                        }


                        read_deptreader.Close();


                    }
                    else
                    {
                        //successMessage.InnerHtml = "Login successfull with following warning: no department assigned to this user.";
                        //successMessage.Style.Remove("display");
                        //System.Threading.Thread.Sleep(3500);
                        Response.Redirect("~/Default.aspx");
                        //Response.AddHeader("REFRESH", "5;URL=~/Default.aspx");
                    }

                    /////////////////////////////////////////////////

                    //successMessage.InnerHtml = "Login successfull!";
                    //successMessage.Style.Remove("display");
                    //System.Threading.Thread.Sleep(1000);



                    Response.Redirect("~/Default.aspx");
                    //Response.AddHeader("REFRESH", "5;URL=~/Default.aspx");


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


        protected void signupButton_Click(object sender, EventArgs e)

        {
            Response.Redirect("~/Signup.aspx");
        }


        }

    
}