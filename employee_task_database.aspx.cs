using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class employee_task_database : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Establishing connection string to database
            // Reading from the web.config file
            int selected_project_id = -1;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(dbConnectionString);

            connection.Open();


            //READ EMPLOYEE CURRENT PROJECTS AND DISPLAY IN DROP DOWN LIST
            string employee_id = Session["employee_id"].ToString();
            
            string read_employee_projects_query = "SELECT DISTINCT COMPANY.task_assignment.project_ID, COMPANY.projects.Name as project_name FROM COMPANY.task_assignment as TA inner join COMPANY.projects as P on TA.project_ID = P.ID WHERE employee_ID = @employee_id and project_assignment_status = 'active';";

            SqlCommand read_employee_projects_command = new SqlCommand(read_employee_projects_query, connection);
            read_employee_projects_command.Parameters.AddWithValue("@employee_id", employee_id);

            da = new SqlDataAdapter(read_employee_projects_command);

            // create a DataTable to hold the results
            DataTable projects = new DataTable();

            // fill the DataTable with the results of the SQL query
            da.Fill(projects);



            employee_projects.DataSource = projects;
            employee_projects.AppendDataBoundItems = true;
            employee_projects.DataTextField = "project_name"; // The column you want to display in the dropdown list
            employee_projects.DataValueField = "project_ID"; // The column you want to use as the value for the selected item
            employee_projects.DataBind();


            read_employee_projects_command.Dispose();
            da.Dispose();



            SqlDataReader project_id_reader = read_project_id_command.ExecuteReader();





            while (project_id_reader.Read())
            {
                project_id = Convert.ToInt32(project_id_reader["project_ID"].ToString());
            }

            project_id_reader.Close();
            connection.Close();




















            //var queryString = "SELECT * FROM COMPANY.tasks";
            var queryString  = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name', task_description as 'Description',task_est_duration as 'Duration', COMPANY.task_assignment.task_status as 'Status', task_creation_date as 'Creation Date', convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID WHERE  COMPANY.tasks.project_ID="+ project_id +"AND COMPANY.task_assignment.employee_ID ="+employee_id; // Return all records from Project Table in Database; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            //var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["Id"]);
            DropDownList statusDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("StatusDropDownList");
            int status = Convert.ToInt32(statusDropDownList.SelectedValue);

            // Update the status column in the database using the id value
            // ...

            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        private void BindGridView()
        {
            // Connect to database and execute query to retrieve data
           

            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string query = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name', task_description as 'Description',task_est_duration as 'Duration', COMPANY.task_assignment.task_status as 'Status', task_creation_date as 'Creation Date', convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID WHERE  COMPANY.tasks.project_ID=" + project_id + "AND COMPANY.task_assignment.employee_ID =" + employee_id;

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the GridView control
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }


    }
}