using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace databaseteam18
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitButton.ServerClick += new EventHandler(submitButton_Click);
        }
                                               
        protected void submitButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);

                Random random = new Random();
                int login_ID = random.Next(10000, 20000);
                //int login_ID = 2000;

                string query = "INSERT INTO COMPANY.User_Login (login_ID, user_email, user_password) VALUES (@login_id, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login_id", login_ID);
                command.Parameters.AddWithValue("@Email", users_email.Value);
                command.Parameters.AddWithValue("@Password", user_password.Value);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                // Handle the error in some way, such as displaying an error message to the user or logging the error for later analysis
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


    }

}





//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace databaseteam18
//{
//    public partial class signup : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }

//        protected void submitButton_Click(object sender, EventArgs e)
//        {
//            string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
//            SqlConnection connection = new SqlConnection(connectionString);

//            //random random = new random();
//            //int loginid = random.next(1, 1001);
//            int login_ID = 1;

//            string query = "INSERT INTO COMPANY.User_Login (login_ID, user_email, user_password) VALUES (@login_ID, @Email, @Password)";
//            SqlCommand command = new SqlCommand(query, connection);
//            command.Parameters.AddWithValue("@login_ID", login_ID);
//            command.Parameters.AddWithValue("@Email", users_email.Value);
//            command.Parameters.AddWithValue("@Password", user_password.Value);


//            connection.Open();
//            command.ExecuteNonQuery();
//            connection.Close();
//        }

//    }

//}