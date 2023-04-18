﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace databaseteam18
{
    public partial class employee_task_database : System.Web.UI.Page
    {
        public int selected_project_id = -1;
        public string ID;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            int role_ID = int.Parse(Session["role_id"].ToString());
            //Console.WriteLine(role_ID.ToString(), role_ID.ToString());

            if (role_ID == 3)
            {
                this.MasterPageFile = "~/employee_site.Master"; // Path to Site Master with different navbar for user_role_id = 1
            }
            else if (role_ID == 2)
            {
                this.MasterPageFile = "~/Site.Master";

            }
            else if (role_ID == 1)
            {
                this.MasterPageFile = "~/admin_site.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            successMessage.Style.Add("display", "none");
            errorMessage.Style.Add("display", "none");
            submitButton.ServerClick += new EventHandler(viewTasksButton_Click);
            // Establishing connection string to database
            // Reading from the web.config file

            SqlDataAdapter da;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            SqlConnection connection = new SqlConnection(dbConnectionString);

            connection.Open();


            //READ EMPLOYEE CURRENT PROJECTS AND DISPLAY IN DROP DOWN LIST
            string employee_id = Session["employee_id"].ToString();

            string read_employee_projects_query = "SELECT DISTINCT TA.project_ID, P.Name as project_name FROM COMPANY.task_assignment as TA inner join COMPANY.projects as P on TA.project_ID = P.ID WHERE employee_ID = @employee_id and project_assignment_status = 'active';";

            SqlCommand read_employee_projects_command = new SqlCommand(read_employee_projects_query, connection);
            read_employee_projects_command.Parameters.AddWithValue("@employee_id", employee_id);


            if (!IsPostBack)
            {
                da = new SqlDataAdapter(read_employee_projects_command);

                // create a DataTable to hold the results
                DataTable projects = new DataTable();

                // fill the DataTable with the results of the SQL query
                da.Fill(projects);

                employee_projects.DataSource = projects;
                employee_projects.AppendDataBoundItems = true;
                employee_projects.Items.Insert(0, new ListItem("Select a project", "-1"));
                employee_projects.DataTextField = "project_name"; // The column you want to display in the dropdown list
                employee_projects.DataValueField = "project_ID"; // The column you want to use as the value for the selected item
                employee_projects.DataBind();
                read_employee_projects_command.Dispose();
                da.Dispose();

                connection.Close();


            }

        }

        protected void viewTasksButton_Click(object sender, EventArgs e)

        {
            string employee_id = Session["employee_id"].ToString();
            if (employee_projects.SelectedValue.ToString() == "-1")
            {// Display error message

                errorMessage.InnerHtml = "You have not selected any project. Check again when you are assigned a project.";

                errorMessage.Style.Remove("display");

                return;
            }


            else
            {
                selected_project_id = Convert.ToInt32(employee_projects.SelectedValue);
                //var queryString = "SELECT * FROM COMPANY.tasks";
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                var queryString = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name',task_start_date as 'StartDate', task_description as 'Description', COMPANY.task_assignment.task_status as 'Status', task_predecessor_ID as 'Task_Pred_ID', task_priority as 'Task Priority',  COMPANY.task_assignment.task_assignment_date as 'Assignment Date',  COMPANY.task_assignment.task_deadline as 'Deadline' ,COMPANY.task_assignment.task_completion_date as 'CompletionDate',COMPANY.task_assignment.task_completion_status as 'CompletionStatus', convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID left outer join COMPANY.Tasks_Dependecies TDP on TDP.task_descendant_ID = COMPANY.tasks.task_ID WHERE  COMPANY.tasks.project_ID=" + selected_project_id + "AND COMPANY.task_assignment.employee_ID =" + employee_id + "AND COMPANY.tasks.deleted = 0;"; // Return all records from Project Table in Database; // Return all records from Project Table in Database
                var dbConncetion = new SqlConnection(dbConnectionString);
                SqlCommand read_employee_tasks_command = new SqlCommand(queryString, dbConncetion);
                var dataAdapter = new SqlDataAdapter(read_employee_tasks_command);

                //var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView1.Visible = true;

                dbConncetion.Close();

            }





        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
            //GridView1.Columns[5].Visible = false;
            //GridView1.DataKeyNames = new string[] { "task_name" };
            //errorMessage.InnerHtml = GridView1.DataKeys.Count.ToString();

            //errorMessage.Style.Remove("display");

            //return;

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];

                string ID = row.Cells[0].Text;
                string task_deadline_txt = row.Cells[6].Text;

                DropDownList statusDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("StatusDropDownList");
                string status = (statusDropDownList.SelectedValue);



                DateTime task_deadline = DateTime.ParseExact(task_deadline_txt, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                DateTime current_datetime = DateTime.Now;

                //errorMessage.InnerHtml ="Current: " + current_datetime + "   Deadline: " + task_deadline.ToString();
                //errorMessage.Style.Remove("display");
                //return;


                // Update the status column in the database using the id value

                // ...
                if (status == "Completed")
                {
                    string completion_status = "";


                    if (current_datetime > task_deadline)
                    {
                        completion_status = "Late";
                    }
                    else
                        completion_status = "On Time";

                    string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                    string query = "UPDATE COMPANY.task_assignment SET task_status = @status, task_completion_status = @completion_status, task_completion_date = @completion_date  WHERE task_id = @id;";


                    SqlConnection connection = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", ID);
                    command.Parameters.AddWithValue("@completion_status", completion_status);
                    command.Parameters.AddWithValue("@completion_date", current_datetime);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    successMessage.InnerHtml = "Task Updated Successfully.";
                    successMessage.Style.Remove("display");
                    
                }
                else if(status == "Started")
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                    string query = "UPDATE COMPANY.task_assignment SET task_status = @status, task_start_date = @start_date WHERE task_id = @id;";


                    SqlConnection connection = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", ID);
                    command.Parameters.AddWithValue("@start_date", current_datetime);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    successMessage.InnerHtml = "Task Updated Successfully.";
                    successMessage.Style.Remove("display");
                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                    string query = "UPDATE COMPANY.task_assignment SET task_status = @status WHERE task_id = @id;";


                    SqlConnection connection = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", ID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    successMessage.InnerHtml = "Task Updated Successfully.";
                    successMessage.Style.Remove("display");
                    
                }






                GridView1.EditIndex = -1;
                BindGridView();
            }
            catch (SqlException ex)

            {
                if (ex.Message.Contains("dependent"))
                {
                    // Display a personalized error message to the user

                    Console.WriteLine("An error occurred: " + ex.Message);
                    errorMessage.InnerHtml = ex.Message;
                    errorMessage.Style.Remove("display");
                }
                else
                {
                    // If the error was caused by something else, display a generic error message
                    Console.WriteLine("An error occurred: " + ex.Message);
                    errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                    errorMessage.Style.Remove("display");
                }

                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis


            }
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
            //auto clicks the view tasks button to bind the gridview and display tasks
            viewTasksButton_Click(null, null);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


    }
}