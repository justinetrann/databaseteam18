using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace databaseteam18
{
    public partial class project_manager_dashboard : System.Web.UI.Page
    {
        protected GridView GridViewAdminProject1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            var queryString = "SELECT p.Name, p.Start_Date, p.End_Date, d.depName FROM COMPANY.projects p LEFT JOIN COMPANY.department d ON p.Department_ID = d.depid ORDER BY p.End_Date ASC"; // Return all records from Project Table in Database
            var dbConncetion = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);

            GridViewAdminProject1.DataSource = ds.Tables[0];
            GridViewAdminProject1.DataBind();
        }
    }
}