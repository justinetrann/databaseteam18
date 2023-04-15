﻿using System;
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
        protected GridView GridViewDepartment;
        protected GridView GridViewDepartmentProject;
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
                   "FROM COMPANY.projects p;";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewManagerProject.DataSource = ds.Tables[0];
            GridViewManagerProject.DataBind();

            queryString = "SELECT depId AS 'ID ', depName AS 'Department Name ' FROM COMPANY.department";
            dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            ds = new DataSet();
            dataAdapter.Fill(ds);
            GridViewDepartment.DataSource = ds.Tables[0];
            GridViewDepartment.DataBind();

            if (IsPostBack)
            {
                string eventTarget = Request.Form["__EVENTTARGET"];
                if (eventTarget == FindProjectsDepButton.UniqueID)
                {
                    FindDepProjects(sender, e);
                }

                if (eventTarget == RemoveDepartmentProject.UniqueID)
                {
                    RemoveDepProject(sender, e);
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
                               "WHERE d.depName = @DepartmentName;";
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);
            var ds = new DataSet();
            dataAdapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
            dataAdapter.Fill(ds);
            GridViewDepartmentProject.DataSource = ds.Tables[0];
            GridViewDepartmentProject.DataBind();
        }

        protected void RemoveDepProject(object sender, EventArgs e)
        {
            string projectName = removeProjects.Text;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE COMPANY.projects SET Deleted = 1 WHERE ID = @ProjectID", connection);
                command.Parameters.AddWithValue("@ProjectID", projectName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Project Updated Successfully!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Project Updated Failed!')</script>");
                }

            }
        }
    }
}