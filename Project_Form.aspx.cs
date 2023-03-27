using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class Project_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            submitButton.ServerClick += new EventHandler(submitButton_Click);

        }




        protected void submitButton_Click(object sender, EventArgs e)

        {

            //check if all required fields are filled


            if (string.IsNullOrEmpty(project_name.Value) || string.IsNullOrEmpty(project_start_date.Value) || string.IsNullOrEmpty(project_end_date.Value) || string.IsNullOrEmpty(estimated_cost.Value) || string.IsNullOrEmpty(estimated_effort.Value))

            {

                // Display error message

                errorMessage.InnerHtml = "Please fill in all fields.";

                errorMessage.Style.Remove("display");

                return;

            }

            // Check if date are in correct format

            
            //if (phone_number.Value.Length < 10)

            //{

            //    // Display error message

            //    errorMessage.InnerHtml = "Please enter a valid phone number!";

            //    errorMessage.Style.Remove("display");

            //    return;

            //}
            //if (ssn.Value.Length != 9)

            //{

            //    // Display error message

            //    errorMessage.InnerHtml = "Please enter a valid SSN!(Do not include dashes)";

            //    errorMessage.Style.Remove("display");

            //    return;

            //}




            try

            {

                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                Random rand = new Random();

                int project_id = rand.Next(50000, 90000);
                string status = "";


                DateTime projectEndDate = DateTime.ParseExact(project_end_date.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Now;

                if (projectEndDate <= today)
                    status = "COMPLETED";
                else if (projectEndDate > today)
                    status = "ONGOING";


                //Get current employee Department ID
                int employee_id= Session["employee_id"]
                int department_id = -1;
                string query = "SELECT dept_ID FROM COMPANY.employees WHERE employee_id = @employee_id ;";
                SqlCommand read_command = new SqlCommand(query, connection);
                read_command.Parameters.AddWithValue("@employee_id", employee_id);
                connection.Open();

                read_command.ExecuteNonQuery();

                SqlDataReader reader = read_command.ExecuteReader();

                //check if dept_id was returned
                if (reader.HasRows)
                {
                    
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

                    reader = read_command.ExecuteReader();



                    //Redirect the user to the home page
                    while (reader.Read())


                    {
                        department_id = Convert.ToInt32(reader["dept_ID"]);
                        

                    }



                    ////////////


                    if (department_id == -1)
                    {
                        errorMessage.InnerHtml = "No Department ID assigned to your user Login! Contact Admin for support.";
                        errorMessage.Style.Remove("display");
                    }
                    else
                    {
                        string query = "INSERT INTO COMPANY.projects (ID, Name, Start_Date, End_Date, Status, Estimated_Cost, Effort, Department_ID) VALUES (@project_id, @project_name, @start_date, @end_date, @status, @estimated_cost, @estimated_effort, @department_id);";

                        //query += "INSERT INTO COMPANY.employees (employee_ID, employee_first_name, employee_last_name, SSN, phoneNUM, login_ID) VALUES (@employee_id, @employee_fname,@employee_lname, @ssn, @phone_num, @login_id_emp_table);";




                        SqlCommand command = new SqlCommand(query, connection);



                        command.Parameters.AddWithValue("@project_id", project_id);

                        command.Parameters.AddWithValue("@project_name", project_name.Value);

                        command.Parameters.AddWithValue("@start_date", project_start_date.Value);

                        command.Parameters.AddWithValue("@end_date", project_end_date.Value);

                        command.Parameters.AddWithValue("@status", status);

                        command.Parameters.AddWithValue("@estimated_cost", estimated_cost.Value);

                        command.Parameters.AddWithValue("@estimated_effort", estimated_effort.Value);

                        command.Parameters.AddWithValue("@department_id", department_id);


                        //Response.Redirect("~/Default.aspx");

                        command.ExecuteNonQuery();

                        connection.Close();
                        successMessage.InnerHtml = "New Project Added Successfully!";
                        successMessage.Style.Remove("display");


                    }

                   


            }

            catch (Exception ex)

            {

                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis

                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                errorMessage.Style.Remove("display");

            }

            /// <summary>
            /// Determine if Date String is an actual date
            /// Date format = MM/DD/YYYY
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private bool ValidateDate(string date)
            {
                try
                {
                    // for US, alter to suit if splitting on hyphen, comma, etc.
                    string[] dateParts = date.Split('/');

                    // create new date from the parts; if this does not fail
                    // the method will return true and the date is valid
                    DateTime testDate = new
                        DateTime(Convert.ToInt32(dateParts[2]),
                        Convert.ToInt32(dateParts[0]),
                        Convert.ToInt32(dateParts[1]));

                    return true;
                }
                catch
                {
                    // if a test date cannot be created, the
                    // method will return false
                    return false;
                }
            }

        }






    }

}