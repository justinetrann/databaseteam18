using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class Projects : System.Web.UI.Page
    {
        public string current_employee_id;
        public string new_employee;
        public DropDownList ddl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridView();


        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            int rowIndex = e.NewEditIndex;

            BindGridView();

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = GridView2.Rows[e.RowIndex];

            //Get project ID
            string project_id = row.Cells[0].Text;


            //Get project Name Update Value
            string new_project_name = "";
            TextBox ProjectNameTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("ProjectNameTextBox");
            if (!string.IsNullOrEmpty(ProjectNameTextBox.Text))
            {
                 new_project_name = ProjectNameTextBox.Text;
            }



            //Get project deadline Update Value
            string new_project_deadline = "";
            TextBox DeadlineTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("DeadlineTextBox");
            if (!string.IsNullOrEmpty(DeadlineTextBox.Text))
            {
                new_project_deadline = DeadlineTextBox.Text;
            }
         

            //Get project Status Update Value
            DropDownList statusDropDownList = (DropDownList)GridView2.Rows[e.RowIndex].FindControl("StatusDropDownList");
            string new_project_status = (statusDropDownList.SelectedValue);

            string project_end_date = "";

            if (new_project_status == "COMPLETED")
                project_end_date = DateTime.Now.ToString();


            //Get project est cost Update Value
            string new_project_est_cost = "";
            TextBox EstCostTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("EstCostTextBox");
            if (!string.IsNullOrEmpty(EstCostTextBox.Text))
            {
                new_project_est_cost = EstCostTextBox.Text;
            }



            //Get project est effort Update Value
            string new_project_est_effort = "NULL";
            TextBox EstEffortTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("EstEffortTextBox");
            if (!string.IsNullOrEmpty(EstEffortTextBox.Text))
            {
                new_project_est_effort = EstEffortTextBox.Text;
            }


            //Get project total cost Update Value
            string new_project_total_cost = "NULL";
            TextBox TotCostTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("TotCostTextBox");
            string new_project_total_cost = TotCostTextBox.Text;

            //Get project total effort Update Value
            TextBox TotEffortTextBox = (TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("TotEffortTextBox");
            string new_project_total_effort = TotEffortTextBox.Text;


            




            // Update the Task and Task Assignment tables with update data
            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string query = "UPDATE COMPANY.projects SET Name = @new_project_name, Status = @new_project_status, deadline = @new_project_deadline, Estimated_Cost = @new_project_est_cost, Effort = @new_project_est_effort, Total_Cost = @new_project_total_cost, Total_Effort = @new_project_total_effort, end_date = @project_end_date WHERE ID = @project_id;";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@project_id", project_id);
            command.Parameters.AddWithValue("@new_project_name", new_project_name);
            command.Parameters.AddWithValue("@new_project_status", new_project_status);
            command.Parameters.AddWithValue("@new_project_deadline", new_project_deadline);
            command.Parameters.AddWithValue("@new_project_est_cost", new_project_est_cost);
            command.Parameters.AddWithValue("@new_project_est_effort", new_project_est_effort);
            command.Parameters.AddWithValue("@new_project_total_cost", new_project_total_cost);
            command.Parameters.AddWithValue("@new_project_total_effort", new_project_total_effort);
            command.Parameters.AddWithValue("@project_end_date", project_end_date);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();



            GridView2.EditIndex = -1;
            BindGridView();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;

            BindGridView();
        }

        private void BindGridView()
        {
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string manager_employee_ID = Session["employee_id"].ToString();

            var queryString = "SELECT ID as 'Project ID', Name as 'Project Name',Start_Date as 'Start', deadline as 'Deadline', Status as 'Status', end_date as 'Completion Date', Estimated_Cost as 'Est Cost', Effort as 'Est Effort', Total_Cost as 'Tot Cost', Total_Effort as 'Tot Effort', DepName as 'Department', project_assignment_status as 'Assign Status' FROM COMPANY.projects P inner join COMPANY.manages_project MP on P.ID = MP.Project_ID inner join COMPANY.department D on D.depId = P.Department_ID WHERE MP.employee_ID =" + manager_employee_ID + ";"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView2.Rows[e.RowIndex];


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



            GridView2.EditIndex = -1;
            BindGridView();
            
        }

    }
}



