using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Establishing connection string to database
            // Reading from the web.config file
            //string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            //var queryString = "SELECT * FROM Projects"; // Return all records from Project Table in Database
            //var dbConncetion = new SqlConnection(dbConnectionString);
            //var dataAdapter = new SqlDataAdapter(queryString, dbConncetion);

            //var commandBuilder = new SqlCommandBuilder(dataAdapter);
            //var ds = new DataSet();
            //dataAdapter.Fill(ds);

            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
        }
    }
}