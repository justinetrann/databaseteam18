using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class department_assign : System.Web.UI.Page
    {
        protected GridView GridViewAdminDepartment;
        protected void Page_Load(object sender, EventArgs e)
        {
            userDepartmentAssignmentSubmitButton.ServerClick += new EventHandler(userDepartmentAssignmentSubmitButton_Click);

            // GETTING USER EMAILS
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            var queryString = "SELECT u.user_email, d.depName FROM COMPANY.User_Login u LEFT JOIN COMPANY.employees e ON e.employee_id = u.employee_ID LEFT JOIN COMPANY.department d ON d.depId = e.dept_ID"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridViewAdminDepartment.DataSource = ds.Tables[0];
            GridViewAdminDepartment.DataBind();
        }

        protected void userDepartmentAssignmentSubmitButton_Click(object sender, EventArgs e)

        {

            //check if all required fields are filled


            if (string.IsNullOrEmpty(user_login_email_dept.Value) || string.IsNullOrEmpty(department_id.Value))

            {

                // Display error message

                errorMessage1.InnerHtml = "Please fill in all fields.";

                errorMessage1.Style.Remove("display");

                return;

            }

            // Check if user email exists in database


            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                string email = user_login_email_dept.Value;
                int departmentID = int.Parse(department_id.Value);

                string query = "SELECT * FROM COMPANY.User_Login WHERE user_email=@Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    // if email exist in database, update user role


                    int rowCount = 0;
                    int employee_id = 5;

                    while (reader.Read())
                    {
                        rowCount++;
                        employee_id = Convert.ToInt32(reader["employee_id"]);

                    }


                    if (rowCount != 1)
                    {
                        errorMessage1.InnerHtml = "Something unexpected happened. Please try again later.(more than 1 row returned by user_login table";
                        errorMessage1.Style.Remove("display");
                        return;
                    }







                    string update_query = " UPDATE COMPANY.employees SET dept_ID = @deptID WHERE employee_id=@employeeId;";
                    SqlCommand update_command = new SqlCommand(update_query, connection);
                    update_command.Parameters.AddWithValue("@employeeId", employee_id);
                    update_command.Parameters.AddWithValue("@deptID", departmentID);


                    if (update_command.ExecuteNonQuery() == 1)
                    {
                        SuccessMessage1.InnerHtml = "User Department Set Successfully";
                        SuccessMessage1.Style.Remove("display");
                    }
                    else
                    {
                        // Display an error message
                        errorMessage1.InnerHtml = "Error while setting user department!";
                        errorMessage1.Style.Remove("display");
                    }


                    reader.Close();
                }
                else
                {
                    // Display an error message
                    errorMessage1.InnerHtml = "This user login email does not exist in the database!";
                    errorMessage1.Style.Remove("display");
                }

                reader.Close();
                command.Dispose();

                connection.Close();


            }

            catch (Exception ex)

            {

                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis

                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage1.InnerHtml = "A Database error occurred: " + ex.Message;
                errorMessage1.Style.Remove("display");

            }






        }
    }
}