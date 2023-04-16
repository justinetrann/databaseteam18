using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class project_dashboard : System.Web.UI.Page
    {
        protected GridView GridViewManagerProject;
        protected GridView GridViewDeletedProject;
        protected GridView GridViewDepartment;
        protected GridView GridViewDepartmentProject;
        protected GridView GridViewDepartmentDeletedProject;
        protected void Page_Load(object sender, EventArgs e)
        {
            // All Projects In Departments
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
            var queryString = "SELECT p.ID AS 'Project ID', " +
                   "p.Name AS 'Name', " +
                   "p.Start_Date AS 'Start Date', " +
                   "p.Status AS 'Status', " +
                   "p.Estimated_Cost AS 'Est. Cost', " +
                   "p.Effort AS 'Effort', " +
                   "p.Total_Cost AS 'Total Cost', " +
                   "p.Total_Effort AS 'Total Effort', " +
                   "p.Managers AS 'Manager', " +
                   "p.End_Date AS 'End Date', " +
                   "p.Deleted AS 'Deleted', " +
                   "p.Department_ID AS 'Dep. ID' " +
                   "FROM COMPANY.projects p " +
                   "WHERE p.Deleted = 0;";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewManagerProject.DataSource = ds.Tables[0];
            GridViewManagerProject.DataBind();

            queryString = "SELECT p.ID AS 'Project ID', " +
                   "p.Name AS 'Name', " +
                   "p.Start_Date AS 'Start Date', " +
                   "p.Status AS 'Status', " +
                   "p.Estimated_Cost AS 'Est. Cost', " +
                   "p.Effort AS 'Effort', " +
                   "p.Total_Cost AS 'Total Cost', " +
                   "p.Total_Effort AS 'Total Effort', " +
                   "p.Managers AS 'Manager', " +
                   "p.End_Date AS 'End Date', " +
                   "p.Deleted AS 'Deleted', " +
                   "p.Department_ID AS 'Dep. ID' " +
                   "FROM COMPANY.projects p "+
                   "WHERE p.Deleted = 1;";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewDeletedProject.DataSource = ds.Tables[0];
            GridViewDeletedProject.DataBind();

            queryString = "SELECT depId AS 'ID ', depName AS 'Department Name ' FROM COMPANY.department";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewDepartment.DataSource = ds.Tables[0];
            GridViewDepartment.DataBind();

            if (IsPostBack)
            {
                string eventTarget = Request.Form["__EVENTTARGET"];
                string projectName = removeProjects.Text.Trim();
                string departmentName = findProjectsDepartment.Text;
                if (eventTarget == FindProjectsDepButton.UniqueID)
                {
                    if (!departmentName.IsNullOrWhiteSpace())
                    {
                        FindDepProjects(sender, e);
                    }
                }

                if (eventTarget == RemoveDepartmentProject.UniqueID)
                {
                    if (!projectName.IsNullOrWhiteSpace())
                    {
                        RemoveDepProject(sender, e);
                    }
                }

                if (eventTarget == RestoreDepartmentProject.UniqueID)
                {
                    if (!projectName.IsNullOrWhiteSpace())
                    {
                        RestoreDepProject(sender, e);
                    }
                }
            }
        }

        protected void FindDepProjects(object sender, EventArgs e)
        {
            string departmentName = findProjectsDepartment.Text;

            // All Projects In Departments
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
            var queryString = "SELECT p.ID AS 'Project ID', " +
                               "p.Name AS 'Name', " +
                               "p.Start_Date AS 'Start Date', " +
                               "p.Status AS 'Status', " +
                               "p.Estimated_Cost AS 'Est. Cost', " +
                               "p.Effort AS 'Effort', " +
                               "p.Total_Cost AS 'Total Cost', " +
                               "p.Total_Effort AS 'Total Effort', " +
                               "p.Managers AS 'Manager', " +
                               "p.End_Date AS 'End Date', " +
                               "p.Deleted AS 'Deleted', " +
                               "d.depName AS 'Dep. Name ' " +
                               "FROM COMPANY.projects p " +
                               "LEFT JOIN COMPANY.department d ON d.depId = p.Department_ID " +
                               "WHERE d.depName = @DepartmentName AND p.Deleted = 0;";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            dataAdapter.Fill(ds);
            GridViewDepartmentProject.DataSource = ds.Tables[0];
            GridViewDepartmentProject.DataBind();

            // All Projects In Departments Deleted
            queryString = "SELECT p.ID AS 'Project ID', " +
                               "p.Name AS 'Name', " +
                               "p.Start_Date AS 'Start Date', " +
                               "p.Status AS 'Status', " +
                               "p.Estimated_Cost AS 'Est. Cost', " +
                               "p.Effort AS 'Effort', " +
                               "p.Total_Cost AS 'Total Cost', " +
                               "p.Total_Effort AS 'Total Effort', " +
                               "p.Managers AS 'Manager', " +
                               "p.End_Date AS 'End Date', " +
                               "p.Deleted AS 'Deleted', " +
                               "d.depName AS 'Dep. Name ' " +
                               "FROM COMPANY.projects p " +
                               "LEFT JOIN COMPANY.department d ON d.depId = p.Department_ID " +
                               "WHERE d.depName = @DepartmentName AND p.Deleted = 1;";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            dataAdapter.Fill(ds);
            GridViewDepartmentDeletedProject.DataSource = ds.Tables[0];
            GridViewDepartmentDeletedProject.DataBind();
        }

        protected void RemoveDepProject(object sender, EventArgs e)
        {
            string projectName = removeProjects.Text.Trim();
            bool isNumeric = int.TryParse(projectName, out int n);

            if (isNumeric)
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand("UPDATE COMPANY.projects SET Deleted = 1 WHERE ID = @ProjectID; UPDATE COMPANY.manages_project SET Deleted = 1 WHERE project_ID = @ProjectID", connection);
                    command.Parameters.AddWithValue("@ProjectID", projectName);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Project Deletion Successfully!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Project Deletion Failed!')</script>");
                    }

                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Project UID!!!')</script>");
            }

            removeProjects.Text = string.Empty;
        }

        protected void RestoreDepProject(object sender, EventArgs e)
        {
            string projectName = restoreProjects.Text.Trim();
            bool isNumeric = int.TryParse(projectName, out int n);

            if (isNumeric)
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE COMPANY.projects SET Deleted = 0 WHERE ID = @ProjectID;UPDATE COMPANY.manages_project SET Deleted = 0 WHERE project_ID = @ProjectID", connection);
                    command.Parameters.AddWithValue("@ProjectID", projectName);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Project Recovery Successfully!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Project Recovery Failed!')</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter Project UID!!!')</script>");
            }
 
            restoreProjects.Text = string.Empty;
        }
    }
}