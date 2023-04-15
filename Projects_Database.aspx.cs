using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class Projects : System.Web.UI.Page
    {
        protected GridView GridView1;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Establishing connection string to database
            // Reading from the web.config file
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string manager_employee_ID = Session["employee_id"].ToString();

            var queryString = "SELECT ID as 'Project ID', Name as 'Project Name',Start_Date as 'Start', deadline as 'Deadline', Status as 'Status', end_date as 'Completion Date', Estimated_Cost as 'Est. Cost', Effort as 'Est. Effort', Total_Cost as 'Tot. Cost', Total_Effort as 'Tot. Effort', DepName as 'Department', project_assignment_status as 'Assign. Status' FROM COMPANY.projects P inner join COMPANY.manages_project MP on P.ID = MP.Project_ID inner join COMPANY.department D on D.depId = P.Department_ID WHERE MP.employee_ID =" + manager_employee_ID+";"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}