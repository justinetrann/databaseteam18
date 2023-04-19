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
            if (phone_number.Value.Length < 10)

            {

                // Display error message

                errorMessage.InnerHtml = "Please enter a valid phone number!";

                errorMessage.Style.Remove("display");

                return;

            }
            if (ssn.Value.Length != 9)

            {

                // Display error message

                errorMessage.InnerHtml = "Please enter a valid SSN!(Do not include dashes)";

                errorMessage.Style.Remove("display");

                return;

            }




            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                Random rand = new Random();

                int login_ID = rand.Next(50000, 90000);

                int employee_ID = rand.Next(50000, 90000);


                int default_role = 3;


                string query = "INSERT INTO COMPANY.User_Login (login_ID, user_email, user_password, user_role_ID, employee_ID) VALUES (@login_id_log_table, @Email, @Password, @default_role, @user_login_employee_ID);";

                query += "INSERT INTO COMPANY.employees (employee_ID, employee_first_name, employee_last_name, SSN, phoneNUM, login_ID) VALUES (@employee_id, @employee_fname,@employee_lname, @ssn, @phone_num, @login_id_emp_table);";


                

                SqlCommand command = new SqlCommand(query, connection);



                command.Parameters.AddWithValue("@employee_id", employee_ID);

                command.Parameters.AddWithValue("@employee_fname", first_name.Value);

                command.Parameters.AddWithValue("@employee_lname", last_name.Value);

                command.Parameters.AddWithValue("@ssn", ssn.Value);

                command.Parameters.AddWithValue("@phone_num", phone_number.Value);

                command.Parameters.AddWithValue("@login_id_emp_table", login_ID);

                command.Parameters.AddWithValue("@login_id_log_table", login_ID);

                command.Parameters.AddWithValue("@Email", users_email.Value);

                command.Parameters.AddWithValue("@Password", user_password.Value);

                command.Parameters.AddWithValue("@default_role", default_role);
                command.Parameters.AddWithValue("@user_login_employee_id", employee_ID);


                Session["user_login_id"] = login_ID;
                Session["employee_id"] = employee_ID;
                Session["role_id"] = default_role;
                //assign default value of -1 to user department_id and project_id
                Session["department_id"] = -1;
                Session["project_id"] = -1;

                //Response.Redirect("~/Default.aspx");





                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();

                Response.Redirect("~/Default.aspx");




                errorMessage.Style.Add("display", "none");

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

//departmentID


