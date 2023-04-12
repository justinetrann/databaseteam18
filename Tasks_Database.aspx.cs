﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace databaseteam18
{
    public partial class Tasks_Database : System.Web.UI.Page
    {
        public string current_employee_id;
        public string new_employee;
        public DropDownList ddl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindGridView();


            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
               GridView1.EditIndex = e.NewEditIndex;
            int rowIndex = e.NewEditIndex;


           

            BindGridView();
            
            ddl = (DropDownList)GridView1.Rows[rowIndex].FindControl("EmployeeDropDownList");



            // Populate the DropDownList with data
            int department_id = Convert.ToInt32(Session["department_id"]);
            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string read_employees_query = "SELECT employee_id, convert(varchar, employee_id) + ' ' + employee_first_name + ' ' + employee_last_name AS employee_full_name FROM COMPANY.employees WHERE dept_ID = @department_id;";
            SqlCommand read_employees_command = new SqlCommand(read_employees_query, connection);
            read_employees_command.Parameters.AddWithValue("@department_id", department_id);

            SqlDataAdapter da = new SqlDataAdapter(read_employees_command);
            DataTable employees = new DataTable();
            da.Fill(employees);

           
            ddl.DataSource = employees;
            ddl.AppendDataBoundItems = true;
            ddl.DataTextField = "employee_full_name";
            ddl.DataValueField = "employee_id";
            ddl.DataBind();
            


            

            da.Dispose();
            read_employees_command.Dispose();
            connection.Close();


            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = GridView1.Rows[e.RowIndex];

            //Get Task ID
            string task_id = row.Cells[0].Text;
     

            //Get Task Name Update Value
            TextBox TaskNameTextBox = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("TaskNameTextBox");
            string new_task_name = TaskNameTextBox.Text;

            //Get Task Description Update Value
            TextBox DescriptionTextBox = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("DescriptionTextBox");
            string new_task_description = DescriptionTextBox.Text;

            //Get Task Status Update Value
            DropDownList statusDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("StatusDropDownList");
            string new_task_status = (statusDropDownList.SelectedValue);

            //Get New Assigned Employee Value
            DropDownList employeeDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("EmployeeDropDownList");
            string new_assigned_employee = (employeeDropDownList.SelectedValue);

            //errorMessage.InnerHtml = new_assigned_employee;
            //errorMessage.Style.Remove("display");
            //return;



            //Get Task Deadline Update Value
            TextBox DeadlineTextBox = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("DeadlineTextBox");
            string new_task_deadline = DeadlineTextBox.Text;


            //Get Task Priority Update Value
            DropDownList TaskPriorityDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("TaskPriorityDropDownList");
            string new_task_priority = (TaskPriorityDropDownList.SelectedValue);




            // Update the Task and Task Assignment tables with update data
            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string query = "UPDATE COMPANY.task_assignment SET task_priority = @task_priority, task_status = @task_status, task_deadline = @task_deadline, employee_ID = @employee_id WHERE task_id = @task_id;";
            query += "UPDATE COMPANY.tasks SET task_name = @task_name, task_description = @task_description WHERE task_id = @task_id;";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@task_priority", new_task_priority);
            command.Parameters.AddWithValue("@task_status", new_task_status);
            command.Parameters.AddWithValue("@task_deadline", new_task_deadline); 
            command.Parameters.AddWithValue("@employee_id", new_assigned_employee);
            command.Parameters.AddWithValue("@task_id", task_id);
            command.Parameters.AddWithValue("@task_name", new_task_name);
            command.Parameters.AddWithValue("@task_description", new_task_description);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();



            GridView1.EditIndex = -1;
            BindGridView();
            //GridView1.Columns[5].Visible = true;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;

            BindGridView();
            //GridView1.Columns[5].Visible = true;
        }

        private void BindGridView()
        {
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string project_id = Session["project_id"].ToString();

            var queryString = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name', task_description as 'Description',task_est_duration as 'Duration', task_priority as 'Task Priority', COMPANY.task_assignment.task_status as 'Status', COMPANY.tasks.deleted as 'Delete', task_creation_date as 'Creation Date', task_assignment_date as 'Assignment Date', task_deadline as 'Deadline', convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID WHERE  COMPANY.tasks.project_ID=" + project_id + "AND COMPANY.tasks.deleted = 0;" ; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

           
            //Get Task ID
            string task_id = row.Cells[0].Text;






            // Update the Task and Task Assignment tables with update data
            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string query = "UPDATE COMPANY.task_assignment SET deleted = 1 WHERE task_id = @task_id;";
            query += "UPDATE COMPANY.tasks SET deleted = 1 WHERE task_id = @task_id;";
            query += "UPDATE COMPANY.tasks_Dependecies SET deleted = 1 WHERE task_predecessor_ID = @task_id OR task_descendant_ID = @task_id;";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

           
            command.Parameters.AddWithValue("@task_id", task_id);
           

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();



            GridView1.EditIndex = -1;
            BindGridView();
            //GridView1.Columns[5].Visible = true;
        }

    }
}