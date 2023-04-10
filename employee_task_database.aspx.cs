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
        public int selected_project_id = -1;
        public string ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                var queryString = "SELECT COMPANY.tasks.task_ID as 'Task ID', task_name as 'Task Name', task_description as 'Description', COMPANY.task_assignment.task_status as 'Status', task_priority as 'Task Priority',  COMPANY.task_assignment.task_assignment_date as 'Assignment Date',  COMPANY.task_assignment.task_deadline as 'Deadline' , convert(varchar,COMPANY.task_assignment.employee_id) + ' ' + employee_first_name + ' ' + employee_last_name as 'Employee'  FROM COMPANY.tasks  inner join COMPANY.task_assignment on COMPANY.task_assignment.task_id = COMPANY.tasks.task_ID inner join COMPANY.employees on COMPANY.employees.employee_id = COMPANY.task_assignment.employee_ID WHERE  COMPANY.tasks.project_ID=" + selected_project_id + "AND COMPANY.task_assignment.employee_ID =" + employee_id; // Return all records from Project Table in Database; // Return all records from Project Table in Database
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
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string ID = row.Cells[0].Text;

            DropDownList statusDropDownList = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("StatusDropDownList");
            string status = (statusDropDownList.SelectedValue);

            

            // Update the status column in the database using the id value
            // ...

            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string query = "UPDATE COMPANY.task_assignment SET task_status = @status WHERE task_id = @id;";


           SqlConnection connection = new SqlConnection(connectionString);
            
                SqlCommand command = new SqlCommand(query, connection);
                
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", ID);

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
            //auto clicks the view tasks button to bind the gridview and display tasks
            viewTasksButton_Click(null, null);
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }


    }
}