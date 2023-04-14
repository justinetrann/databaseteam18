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
using System.Runtime.Remoting.Messaging;
using System.Collections.ObjectModel;

namespace databaseteam18
{
    public partial class project_manager_dashboard : System.Web.UI.Page
    {
        protected GridView GridViewManagerProject1;
        protected GridView GridViewManagerTask;
        protected GridView GridViewManagerEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);

            // Getting Users First Name, Last Name, and Department Name
            int employee_id = 0;
            if (Session["employee_id"] != null)
            {
                employee_id = int.Parse(Session["employee_id"].ToString());
            }
            else
            {
                // testing
                employee_id = 69802;
            }

            string queryStringAccess = "SELECT e.employee_first_name, e.employee_last_name, d.depName FROM COMPANY.employees e JOIN COMPANY.department d ON e.dept_ID = d.depId WHERE e.employee_id = @Employee_id";
            
            // temp department
            string departmentName = "Executive Department";
            string firstName = "First Name";
            string lastName = "Last Name";
            dbConncetion.Open();
            using (var command = new SqlCommand(queryStringAccess, dbConncetion))
            {
                command.Parameters.AddWithValue("@Employee_id", employee_id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader.GetString(0);
                        lastName = reader.GetString(1);
                        departmentName = reader.GetString(2);

                    }
                }
            }

            if (firstName.Length != 0)
            {
                first_name.InnerText = firstName;
            }

            if (lastName.Length != 0)
            {
                last_name.InnerText = lastName;
            }

            if (departmentName.Length != 0)
            {
                Department.InnerText = departmentName;
            }

            var queryString = "SELECT p.Name, p.Start_Date, p.End_Date, d.depName FROM COMPANY.projects p LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid WHERE d.depName = @DepartmentName ORDER BY p.End_Date ASC";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewManagerProject1.DataSource = ds.Tables[0];
            GridViewManagerProject1.DataBind();

            queryString = "SELECT p.Name, t.task_name, ta.task_status, ta.task_deadline FROM COMPANY.projects p JOIN COMPANY.task_assignment ta ON p.ID = ta.Project_ID JOIN COMPANY.tasks t ON t.task_id = ta.task_id JOIN COMPANY.department d ON p.Department_ID = d.depid WHERE d.depName = @DepartmentName ORDER BY p.Name ASC";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            dataAdapter.Fill(ds);
            GridViewManagerTask.DataSource = ds.Tables[0];
            GridViewManagerTask.DataBind();

            queryString = "SELECT p.Name as Project_Name, ta.employee_id, d.depName, t.task_name FROM COMPANY.projects p JOIN COMPANY.task_assignment ta ON p.ID = ta.Project_ID LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid JOIN COMPANY.tasks t ON t.task_id = ta.task_id LEFT JOIN COMPANY.employees e ON e.employee_id = ta.employee_ID WHERE d.depName = @DepartmentName";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            dataAdapter.Fill(ds);
            GridViewManagerEmployees.DataSource = ds.Tables[0];
            GridViewManagerEmployees.DataBind();

        }
    }
}