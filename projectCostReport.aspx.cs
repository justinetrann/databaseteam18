using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace databaseteam18
{
    public partial class projectCostReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);


            SqlDataAdapter projects_da;

            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            //////////////////////////
            ///getting all employees that work for the department, which contains the project with the new task
            int department_id = Convert.ToInt32(Session["department_id"]);

            //errorMessage.InnerHtml = department_id.ToString();


            //errorMessage.Style.Remove("display");

            //return;

            string read_project_query = "SELECT ID, convert(varchar, ID) + ' ' + Name AS project_full_name FROM COMPANY.projects WHERE Department_ID = @department_id;";

            SqlCommand read_projects_command = new SqlCommand(read_project_query, connection);
            read_projects_command.Parameters.AddWithValue("@department_id", department_id);


            if (!IsPostBack)
            {
                //projects_da = new SqlDataAdapter(read_projects_command);

                //// create a DataTable to hold the results
                //DataTable projects = new DataTable();

                //// fill the DataTable with the results of the SQL query
                //projects_da.Fill(projects);



                //department_project.DataSource = projects;
                ////---->1. task_employees.AppendDataBoundItems = true;
                //department_project.DataTextField = "project_full_name"; // The column you want to display in the dropdown list
                //department_project.DataValueField = "ID"; // The column you want to use as the value for the selected item
                //department_project.DataBind();

                ////this.employee_id = Convert.ToInt32(task_employees.SelectedValue);

                //read_projects_command.Dispose();
                //da.Dispose();
            }

        }


        protected void submitButton_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        //bind gridView function
        private void BindGridView()
        {
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string project_id = Session["project_id"].ToString();
            string department_id = Session["department_id"].ToString();
            string employee_id = Session["employee_id"].ToString();
            string start_date_input = report_start_date.Value;
            string completion_date_input = report_end_date.Value;


            var queryString = "SELECT COMPANY.tasks.task_ID AS 'Task ID', " +
             "COMPANY.projects.Name as 'Project', " +
             "task_name AS 'Task Name', " +
             "task_description AS 'Description', " +
             "cost AS 'Cost', " +
             "CONVERT(varchar, COMPANY.employees.employee_id) + ' ' + " +
             "COMPANY.employees.employee_first_name + ' ' + " +
             "COMPANY.employees.employee_last_name AS 'Employee', " +
             "task_start_date AS 'Started On', " +
             "task_completion_date AS 'Completed On' " +
             "FROM COMPANY.tasks " +
             "INNER JOIN COMPANY.task_assignment " +
             "ON COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID " +
             "INNER JOIN COMPANY.employees " +
             "ON COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID " +
             " inner join COMPANY.projects on COMPANY.projects.ID = COMPANY.task_assignment.project_ID " +
             "WHERE COMPANY.task_assignment.task_status = 'Completed' " +
             "AND COMPANY.tasks.deleted = 0 " +
             "AND task_start_date > @start_date_input " +
             "AND task_completion_date < @completion_date_input" +
             " AND COMPANY.projects.Department_ID = @department_id " +
             "ORDER BY COMPANY.projects.Name;";








            //Modify your query string to include parameter placeholders




            var connection = new SqlConnection(dbConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);

            // Add parameters to the query and set their values
            command.Parameters.AddWithValue("@department_id", department_id);
            command.Parameters.AddWithValue("@start_date_input", start_date_input);
            command.Parameters.AddWithValue("@completion_date_input", completion_date_input);


            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            connection.Close();
            GridView1.DataBind();



            //get the count of tasks completed and store it in a reader
            //       string read_completed_tasks_query = "SELECT COUNT(*) as 'tasks_completed' FROM COMPANY.task_assignment WHERE task_status = 'Completed'" +
            //" AND deleted = 0 AND employee_ID = @employee_id" +
            //" AND task_start_date > @start_date_input AND task_completion_date < @completion_date_input;";

            string read_department_name_query = "SELECT depName from COMPANY.department WHERE depId = @department_id;";

            SqlCommand read_department_name_command = new SqlCommand(read_department_name_query, connection);
            read_department_name_command.Parameters.AddWithValue("@department_id", department_id);


            connection.Open();

            SqlDataReader dep_name_reader = read_department_name_command.ExecuteReader();

            if (dep_name_reader.HasRows)
            {
                if (dep_name_reader.Read())
                {
                    departmentName.Value = Convert.ToString(dep_name_reader["depName"]);
                }
            }


            dep_name_reader.Close();
            connection.Close();


            //get the count of tasks completed late and store it in the reader
            //       string read_completed_late_tasks_query = "SELECT COUNT(*) as 'tasks_completed' FROM COMPANY.task_assignment WHERE task_status = 'Completed'" +
            //" AND deleted = 0 AND employee_ID = @employee_id" +
            //" AND task_start_date > @start_date_input AND task_completion_date < @completion_date_input AND task_completion_status = 'Late';";

            var estimated_depCost_query = "SELECT SUM(DISTINCT(COMPANY.projects.estimated_cost)) AS 'Total Estimated Cost' " +
                           "FROM COMPANY.tasks " +
                           "INNER JOIN COMPANY.task_assignment ON COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID " +
                           "INNER JOIN COMPANY.projects ON COMPANY.projects.ID = COMPANY.task_assignment.project_ID " +
                           "WHERE COMPANY.task_assignment.task_status = 'Completed' " +
                           "AND COMPANY.tasks.deleted = 0 " +
                           "AND task_start_date > @start_date_input " +
                           "AND task_completion_date < @completion_date_input " +
                           "AND COMPANY.projects.Department_ID = @department_id;";

            SqlCommand estimated_depCost_command = new SqlCommand(estimated_depCost_query, connection);
            estimated_depCost_command.Parameters.AddWithValue("@department_id", department_id);
            estimated_depCost_command.Parameters.AddWithValue("@start_date_input", start_date_input);
            estimated_depCost_command.Parameters.AddWithValue("@completion_date_input", completion_date_input);

            connection.Open();

            SqlDataReader estimated_depCost_reader = estimated_depCost_command.ExecuteReader();

            if (estimated_depCost_reader.HasRows)
            {
                if (estimated_depCost_reader.Read())
                {
                    estProjectCost.Value = Convert.ToString(estimated_depCost_reader["Total Estimated Cost"]);
                }
            }


            estimated_depCost_reader.Close();
            connection.Close();


            //get the count of tasks completed on time and store it in the reader
            var actual_project_cost_query = "SELECT SUM(cost) AS 'Total Cost' " +
                  "FROM COMPANY.tasks " +
                  "INNER JOIN COMPANY.task_assignment " +
                  "ON COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID " +
                  "INNER JOIN COMPANY.employees " +
                  "ON COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID " +
                  "INNER JOIN COMPANY.projects " +
                  "ON COMPANY.projects.ID = COMPANY.task_assignment.project_ID " +
                  "WHERE COMPANY.task_assignment.task_status = 'Completed' " +
                  "AND COMPANY.tasks.deleted = 0 " +
                  "AND task_start_date > @start_date_input " +
                  "AND task_completion_date < @completion_date_input " +
                  "AND COMPANY.projects.Department_ID = @department_id;";

            SqlCommand actual_project_cost_command = new SqlCommand(actual_project_cost_query, connection);
            actual_project_cost_command.Parameters.AddWithValue("@department_id", department_id);
            actual_project_cost_command.Parameters.AddWithValue("@start_date_input", start_date_input);
            actual_project_cost_command.Parameters.AddWithValue("@completion_date_input", completion_date_input);

            connection.Open();

            SqlDataReader actual_project_cost_reader = actual_project_cost_command.ExecuteReader();

            if (actual_project_cost_reader.HasRows)
            {
                if (actual_project_cost_reader.Read())
                {
                    actualProjectCost.Value = Convert.ToString(actual_project_cost_reader["Total Cost"]);
                }
            }

            actual_project_cost_reader.Close();
            connection.Close();




            //projectCost variance


            string projectEstimatedCostString = estProjectCost.Value;
            float projectEstimatedCostFloat = float.Parse(projectEstimatedCostString);

            string projectActualCostString = actualProjectCost.Value;
            float projectActualCostFloat = float.Parse(projectActualCostString);
            // Do something with tasksCompletedOnTimeInt

            /*double tasksCompletionRate = (tasksCompletedOnTimeFloat / tasksCompletedFloat) * 100;*/
            // Replace with your actual value
            double projectVariancedouble = projectEstimatedCostFloat - projectActualCostFloat;
            double projectCostVariancePercentageDouble = Math.Abs(projectVariancedouble / projectEstimatedCostFloat) * 100;
            string projectVariancedoubleString = projectVariancedouble.ToString("F2");
            string projectCostVariancePercentageString = projectCostVariancePercentageDouble.ToString("F2");
            // Set the value of the HiddenFields to the calculated values
            projectCostVariancePercentage.Value = projectCostVariancePercentageString;
            projectCostVariance.Value = projectVariancedoubleString;
            // Set the value of the progressBarColor HiddenField based on the magnitude of the cost variance
            if (projectVariancedouble < 0)
            {
                progressBarColor.Value = "bg-danger";
            }
            else if (projectVariancedouble > 0)
            {
                progressBarColor.Value = "bg-success";
            }
            else
            {
                progressBarColor.Value = "bg-info";
            }






        }
    }
}



