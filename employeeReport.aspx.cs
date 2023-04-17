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

namespace databaseteam18
{
    public partial class employeeReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);

            BindGridView();
            //get the employees from the current department in the ddl


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
                employees_da = new SqlDataAdapter(read_employees_command);

                // create a DataTable to hold the results
                DataTable employees = new DataTable();

                // fill the DataTable with the results of the SQL query
                employees_da.Fill(employees);



                department_employees.DataSource = employees;
                //---->1. task_employees.AppendDataBoundItems = true;
                department_employees.DataTextField = "employee_full_name"; // The column you want to display in the dropdown list
                department_employees.DataValueField = "employee_id"; // The column you want to use as the value for the selected item
                department_employees.DataBind();

                //this.employee_id = Convert.ToInt32(task_employees.SelectedValue);

                read_employees_command.Dispose();
                //da.Dispose();
            }


            // Retrieve the value for tasksCompletionRate from the backend
            double tasksCompletionRate = 50; // Replace with your actual value

            // Set the value of tasksCompletionRateValue to this value
            tasksCompletionRateValue.Value = tasksCompletionRate.ToString();

            int tasksCompletedVal = 20;
            tasksCompleted.Value = tasksCompletedVal.ToString();

            //progress bar color;
            if (tasksCompletionRate < 50)
                progressBarColor.Value = "bg-danger";
            else if (tasksCompletionRate >= 50 && tasksCompletionRate < 75)
                progressBarColor.Value = "bg-warning";
            else
                progressBarColor.Value = "";

        }


        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridView();
        }

        //bind gridView function
        private void BindGridView()
        {
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string project_id = Session["project_id"].ToString();

            var queryString = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name', task_description as 'Description',task_est_duration as 'Duration',task_predecessor_ID as 'Task_Pred_ID', task_priority as 'Task Priority', COMPANY.task_assignment.task_status as 'Status', COMPANY.tasks.deleted as 'Delete', task_creation_date as 'Creation Date', task_assignment_date as 'Assignment Date', task_deadline as 'Deadline', convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID left outer join COMPANY.Tasks_Dependecies TDP on TDP.task_descendant_ID = COMPANY.tasks.task_ID WHERE  COMPANY.tasks.project_ID=" + project_id + "AND COMPANY.tasks.deleted = 0;"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            //var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }
    }
}


//<asp:HiddenField runat = "server" ID="tasksCompleted" />
//<asp:HiddenField runat = "server" ID="tasksCompletedOnTime" />
//<asp:HiddenField runat = "server" ID="tasksCompletedLate" />
//< asp:HiddenField runat = "server" ID="hoursWorked" />