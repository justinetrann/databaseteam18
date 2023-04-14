using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Data.Odbc;

namespace databaseteam18
{
    public partial class project_manager_dashboard : System.Web.UI.Page
    {
        protected GridView GridViewManagerProject1;
        protected GridView GridViewManagerTask;
        protected GridView GridViewManagerEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Getting Users First Name, Last Name, and Department Name
            string email = User.Identity.Name;
            string firstName = string.Empty;
            string lastName = string.Empty;

            if(email.Length == 0){
                first_name.InnerHtml = "First Name";
            }else{
                first_name.InnerHtml = email;
            }

            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            var queryString = "SELECT p.Name, p.Start_Date, p.End_Date, d.depName FROM COMPANY.projects p LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid ORDER BY p.End_Date ASC"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewManagerProject1.DataSource = ds.Tables[0];
            GridViewManagerProject1.DataBind();

            queryString = "SELECT p.Name, t.task_name, ta.task_status, ta.task_deadline FROM COMPANY.projects p JOIN COMPANY.task_assignment ta ON p.ID = ta.Project_ID JOIN COMPANY.tasks t ON t.task_id = ta.task_id ORDER BY p.Name ASC"; // Return all records from Project Table in Database
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.Fill(ds);

            GridViewManagerTask.DataSource = ds.Tables[0];
            GridViewManagerTask.DataBind();

            //queryString = "SELECT p.Name as Project_Name, e.employee_first_name as first_name, ta.employee_id as ID, d.depName, t.task_name FROM COMPANY.projects p JOIN COMPANY.task_assignment ta ON p.ID = ta.Project_ID LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid JOIN COMPANY.tasks t ON t.task_id = ta.task_id LEFT JOIN COMPANY.employees e ON e.employee_id = ta.employee_ID"; // Return all records from Project Table in Database
            //dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            //ds = new DataSet();
            //dataAdapter.Fill(ds);

            //GridViewManagerEmployees.DataSource = ds.Tables[0];
            //GridViewManagerEmployees.DataBind();

        }
    }
}