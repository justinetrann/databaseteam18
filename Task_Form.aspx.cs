using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;

namespace databaseteam18
{
    public partial class Task_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);




        }
        protected void submitButton_Click(object sender, EventArgs e)

        {

            //check if all required fields are filled


            if (string.IsNullOrEmpty(task_Name.Value) || string.IsNullOrEmpty(task_Description.Value) || string.IsNullOrEmpty(estimated_duration.Value))

            {

                // Display error message

                errorMessage.InnerHtml = "Please fill in all fields.";

                errorMessage.Style.Remove("display");

                return;

            }






            try

            {

                Random rand = new Random();

                int task_id = rand.Next(20000, 40000);

                int project_id = Convert.ToInt32(Session["project_id"]);

                int predecessor_id = -1;
                int employee_id = -1;

                bool tasks_exsiting_flag = true;


                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                SqlConnection connection = new SqlConnection(connectionString);


                connection.Open();



                ////getting already existing tasks to determine predecessors
                string read_tasks_query = "SELECT (task_ID, task_name) FROM COMPANY.tasks WHERE project_id = @project_id;";

                SqlCommand read_tasks_command = new SqlCommand(read_tasks_query, connection);
                read_tasks_command.Parameters.AddWithValue("@project_id", project_id);




                SqlDataReader task_name_reader = read_tasks_command.ExecuteReader();






                int rowCount = 0;
                SqlDataAdapter da;

                while (task_name_reader.Read())
                {
                    rowCount++;
                }

                task_name_reader.Close();

                if (rowCount == 0)
                {
                    successMessage.InnerHtml = "There are no tasks for the current project!";
                    successMessage.Style.Remove("display");
                    tasks_exsiting_flag = false;
                }

                else if (rowCount > 0)
                {
                    da = new SqlDataAdapter(read_tasks_command);

                    // create a DataTable to hold the results
                    DataTable tasks = new DataTable();

                    // fill the DataTable with the results of the SQL query
                    da.Fill(tasks);

                    task_results.DataSource = tasks;
                    task_results.DataTextField = "task_name"; // The column you want to display in the dropdown list
                    task_results.DataValueField = "task_ID"; // The column you want to use as the value for the selected item
                    task_results.DataBind();

                    predecessor_id = Convert.ToInt32(task_results.SelectedValue);

                    read_tasks_command.Dispose();
                    da.Dispose();

                }
                ///////////////////////
                ///getting all employess that work for the department, which contains the project with the new task
                int department_id = Convert.ToInt32(Session["department_id"]);





                string read_employees_query = "SELECT employee_id, employee_first_name, employee_last_name FROM COMPANY.employees WHERE dept_ID = @department_id;";

                SqlCommand read_employees_command = new SqlCommand(read_employees_query, connection);
                read_employees_command.Parameters.AddWithValue("@department_id", department_id);



                da = new SqlDataAdapter(read_employees_command);

                // create a DataTable to hold the results
                DataTable employees = new DataTable();

                // fill the DataTable with the results of the SQL query
                da.Fill(employees);

                task_employees.DataSource = employees;
                task_employees.DataTextField = "employee_last_name, employee_first_name"; // The column you want to display in the dropdown list
                task_employees.DataValueField = "employee_id"; // The column you want to use as the value for the selected item
                task_employees.DataBind();

                employee_id = Convert.ToInt32(task_employees.SelectedValue);

                read_employees_command.Dispose();
                da.Dispose();



                ////////////////////////////

                ///Insert into tasks table
                ///

                int task_assignment_id = rand.Next(50000, 90000);
                int task_dependency_id = rand.Next(5000, 9000);

                string task_status = "assigned";


                DateTime currentDate = DateTime.Now;
                string task_creation_date = currentDate.ToString("MM/dd/yyyy");



                string query = "INSERT INTO COMPANY.tasks (project_ID, task_ID, task_name, task_description, task_est_duration, task_creation_date) VALUES (@project_id, @task_id, @task_name, @task_description, @task_est_duration, @task_creation_date);";

                query += "INSERT INTO COMPANY.task_asssignment (task_assignment_ID, task_id, employee_ID, project_ID, task_status, task_assignment_date) VALUES (@task_assignment_ID, @task_id,@employee_ID,@project_ID, @task_status, @task_assignment_date);";




                SqlCommand command = new SqlCommand(query, connection);



                command.Parameters.AddWithValue("@project_id", project_id);

                command.Parameters.AddWithValue("@task_id", task_id);

                command.Parameters.AddWithValue("@task_name", task_name.Value);

                command.Parameters.AddWithValue("@task_description", task_description.Value);

                command.Parameters.AddWithValue("@task_est_duration", estimated_duration);

                command.Parameters.AddWithValue("@task_creation_date", task_creation_date);


                command.Parameters.AddWithValue("@task_assignment_ID", task_assignment_id);
                command.Parameters.AddWithValue("@task_id", task_id);
                command.Parameters.AddWithValue("@employee_ID", employee_id);
                command.Parameters.AddWithValue("@project_ID", project_id);
                command.Parameters.AddWithValue("@task_status", task_status); 
                command.Parameters.AddWithValue("@task_assignment_date", task_creation_date);


                //Response.Redirect("~/Default.aspx");

                command.ExecuteNonQuery();








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





//}


//// create a connection to the database
//SqlConnection conn = new SqlConnection("YourConnectionStringHere");

//// create a SQL command to select data from the table
//SqlCommand cmd = new SqlCommand("SELECT * FROM YourTableNameHere", conn);

//// create a data adapter to fill the DataTable with the results of the SQL command
//SqlDataAdapter da = new SqlDataAdapter(cmd);

//// create a DataTable to hold the results
//DataTable dt = new DataTable();

//// fill the DataTable with the results of the SQL query
//da.Fill(dt);







//check if project_assignment_status was returned
//if (task_name_reader.HasRows)
//{
//errorMessage.InnerHtml = "Something unexpected happened. Please try again later.(more than 1 row returned by user_login table";
//errorMessage.Style.Remove("display");
//return;