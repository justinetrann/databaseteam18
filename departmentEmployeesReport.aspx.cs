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
using System.Web.Script.Serialization;
using System.Reflection;

namespace databaseteam18
{
    public partial class departmentEmployeesReport : System.Web.UI.Page
    {

        public class PieChartData
        {
            public string label;
            public int value;

            public PieChartData(string label, int value)
            {
                this.label = label;
                this.value = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);


            SqlDataAdapter employees_da;

            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            //////////////////////////
            ///getting all employees that work for the department, which contains the project with the new task
            int department_id = Convert.ToInt32(Session["department_id"]);

            //errorMessage.InnerHtml = department_id.ToString();


            //errorMessage.Style.Remove("display");

            //return;

            string read_employees_query = "SELECT employee_id, convert(varchar, employee_id) + ' ' + employee_first_name + ' ' + employee_last_name AS employee_full_name FROM COMPANY.employees WHERE dept_ID = @department_id;";

            SqlCommand read_employees_command = new SqlCommand(read_employees_query, connection);
            read_employees_command.Parameters.AddWithValue("@department_id", department_id);


            if (!IsPostBack)
            {
                //employees_da = new SqlDataAdapter(read_employees_command);

                //// create a DataTable to hold the results
                //DataTable employees = new DataTable();

                //// fill the DataTable with the results of the SQL query
                //employees_da.Fill(employees);



                //department_employees.DataSource = employees;
                ////---->1. task_employees.AppendDataBoundItems = true;
                //department_employees.DataTextField = "employee_full_name"; // The column you want to display in the dropdown list
                //department_employees.DataValueField = "employee_id"; // The column you want to use as the value for the selected item
                //department_employees.DataBind();

                ////this.employee_id = Convert.ToInt32(task_employees.SelectedValue);

                //read_employees_command.Dispose();
                ////da.Dispose();
            }
            // PIE CHART CONTROL

            List<PieChartData> dataPoints = new List<PieChartData>();
            dataPoints.Add(new PieChartData("Category 1", 25));
            dataPoints.Add(new PieChartData("Category 2", 40));
            dataPoints.Add(new PieChartData("Category 3", 35));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string serializedData = serializer.Serialize(dataPoints);

            HttpContext.Current.Session["PieChartData"] = serializedData;






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
            //string employee_id = department_employees.SelectedValue;
            string start_date_input = report_start_date.Value;
            string completion_date_input = report_end_date.Value;

            

            var queryString = "SELECT CONVERT(varchar, E.employee_id) + ' ' + E.employee_first_name + ' ' + E.employee_last_name AS 'Employee Name'," +
                              " COUNT(*) AS 'Completed Tasks'," +
                              " SUM(CASE WHEN task_completion_status = 'On Time' THEN 1 ELSE 0 END) AS 'On Time'," +
                              " SUM(CASE WHEN task_completion_status = 'Late' THEN 1 ELSE 0 END) AS 'Late'," +
                              " CASE WHEN SUM(CASE WHEN task_completion_status = 'On Time' THEN 1 ELSE 0 END) = 0" +
                              " THEN NULL" +
                              " ELSE CONCAT(ROUND(CAST(SUM(CASE WHEN task_completion_status = 'On Time' THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*) * 100, 0), '%') END" +
                              " AS 'On Time Tasks Completion Ratio'" +
                              " FROM COMPANY.task_assignment TA " +
                              " INNER JOIN COMPANY.employees E ON E.employee_id = TA.employee_ID " +
                              " WHERE task_status = 'Completed' AND TA.deleted = 0 " +
                              " AND task_start_date > @start_date_input AND task_completion_date < @completion_date_input AND E.dept_ID = @department_id" +
                              " GROUP BY CONVERT(varchar, E.employee_id) + ' ' + E.employee_first_name + ' ' + E.employee_last_name;";


            //Modify your query string to include parameter placeholders




            var connection = new SqlConnection(dbConnectionString);
            SqlCommand command = new SqlCommand(queryString, connection);
            int department_id = Convert.ToInt32(Session["department_id"]);
            // Add parameters to the query and set their values
            //command.Parameters.AddWithValue("@employee_id", 0);
            command.Parameters.AddWithValue("@start_date_input", start_date_input);
            command.Parameters.AddWithValue("@completion_date_input", completion_date_input);
            command.Parameters.AddWithValue("@department_id", department_id);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            connection.Close();
            GridView1.DataBind();



            //get the count of projects completed and store it in a reader
            string read_completed_projects_query = "SELECT COUNT(*) as 'projects_completed' FROM COMPANY.projects WHERE Status = 'Completed'" +
     " AND Deleted = 0 AND Department_ID = @department_id" +
     " AND Start_Date > @start_date_input AND end_date < @completion_date_input;";

            SqlCommand read_completed_projects_command = new SqlCommand(read_completed_projects_query, connection);
            read_completed_projects_command.Parameters.AddWithValue("@department_id", department_id);
            read_completed_projects_command.Parameters.AddWithValue("@start_date_input", start_date_input);
            read_completed_projects_command.Parameters.AddWithValue("@completion_date_input", completion_date_input);

            connection.Open();

            SqlDataReader completed_projects_reader = read_completed_projects_command.ExecuteReader();

            if (completed_projects_reader.HasRows)
            {
                if (completed_projects_reader.Read())
                {
                    projectsCompleted.Value = Convert.ToString(completed_projects_reader["projects_completed"]);
                }
            }


            completed_projects_reader.Close();
            connection.Close();


            
            //total hours
            string total_hours_query = "SELECT SUM(DATEDIFF(second, task_start_date, task_completion_date)) / 3600.0 as total_hours_worked " +
               "FROM COMPANY.tasks " +
               "INNER JOIN COMPANY.task_assignment ON COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID " +
               "WHERE COMPANY.task_assignment.task_status = 'Completed' " +
               "AND COMPANY.tasks.deleted = 0 " +
               //"AND COMPANY.task_assignment.employee_ID = @employee_id " +
               "AND task_start_date > @start_date_input " +
               "AND task_completion_date < @completion_date_input;";

            SqlCommand total_hours_command = new SqlCommand(total_hours_query, connection);
            //total_hours_command.Parameters.AddWithValue("@employee_id", 0);
            total_hours_command.Parameters.AddWithValue("@start_date_input", start_date_input);
            total_hours_command.Parameters.AddWithValue("@completion_date_input", completion_date_input);

            connection.Open();
            SqlDataReader reader = total_hours_command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    double totalHoursWorked = Convert.ToDouble(reader["total_hours_worked"]);
                    string totalHoursWorkedString = totalHoursWorked.ToString("F2");

                    // Do something with the formatted value
                    totalHoursCompleted.Value = totalHoursWorkedString + " hours";
                }
            }
            reader.Close();
            connection.Close();

            ////set completion rate and progress bar class

            //string tasksCompletedOnTimeString = projectsCompleted.Value;
            //float tasksCompletedOnTimeFloat = float.Parse(tasksCompletedOnTimeString);

            //string tasksCompletedString = projectsCompleted.Value;
            //float tasksCompletedFloat = float.Parse(tasksCompletedString);
            //// Do something with tasksCompletedOnTimeInt

            //double tasksCompletionRate = (tasksCompletedOnTimeFloat / tasksCompletedFloat) * 100; // Replace with your actual value
            //string tasksCompletionRateString = tasksCompletionRate.ToString("F2");
            //// Set the value of tasksCompletionRateValue to this value
            //projectsCompleted.Value = tasksCompletionRateString;



            // PIE CHART CONTROL

            List<PieChartData> dataPoints = new List<PieChartData>();
            dataPoints.Add(new PieChartData("Category 1", 25));
            dataPoints.Add(new PieChartData("Category 2", 40));
            dataPoints.Add(new PieChartData("Category 3", 35));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string serializedData = serializer.Serialize(dataPoints);

            HttpContext.Current.Session["PieChartData"] = serializedData;




        }
    }
}

