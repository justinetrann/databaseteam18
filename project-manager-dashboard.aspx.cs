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
            int users_login_id = int.Parse(Session["user_login_id"].ToString());
            int employee_id = int.Parse(Session["employee_id"].ToString());
            int role_ID = int.Parse(Session["role_id"].ToString());

            string queryStringAccess = "SELECT e.employee_first_name, e.employee_last_name, d.depName " +
                                             "FROM COMPANY.employees e, COMPANY.department d " +
                                             "JOIN COMPANY.department d ON e.managerID = d.dpHeadID" +
                                             "WHERE e.employee_id = @employee_id";
            // temp department
            string departmentName = "Executive Department";
            using (var command = new SqlCommand(queryStringAccess, dbConncetion))
            {
                command.Parameters.AddWithValue("@employee_id", employee_id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string firstName = reader.GetString(0);
                        string lastName = reader.GetString(1);
                        departmentName = reader.GetString(2);

                        if(firstName.Length != 0)
                        {
                            first_name.InnerText = firstName;
                        }
                        else
                        {
                            first_name.InnerText = "First Name";
                        }

                        if (lastName.Length != 0)
                        {
                            last_name.InnerText = lastName;
                        }
                        else
                        {
                            last_name.InnerText = "Last Name";
                        }

                        if (departmentName.Length != 0)
                        {
                            Department.InnerText = departmentName;
                        }
                        else
                        {
                            Department.InnerText = "Department Name";
                        }
                    }
                }
            }



            var queryString = "SELECT p.Name, p.Start_Date, p.End_Date, d.depName FROM COMPANY.projects p LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid WHERE d.depName = @DepartmentName ORDER BY p.End_Date ASC";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
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