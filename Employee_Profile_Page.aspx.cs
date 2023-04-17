using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace databaseteam18
{
    public partial class Employee_Profile_Page : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            int role_ID = int.Parse(Session["role_id"].ToString());
            //Console.WriteLine(role_ID.ToString(), role_ID.ToString());

            if (role_ID == 3)
            {
                this.MasterPageFile = "~/employee_site.Master"; // Path to Site Master with different navbar for user_role_id = 1
            }
            else if (role_ID == 2)
            {
                this.MasterPageFile = "~/Site.Master";

            }
            else if (role_ID == 1)
            {
                this.MasterPageFile = "~/admin_site.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);

            int employee_id = (int)Session["employee_id"];
            string queryStringAccess = "SELECT e.employee_first_name, e.employee_middle_name, e.employee_last_name, " +
                "e.employee_id, e.dob, e.SEX, ul.user_email, e.phoneNum, d.depName " +
                "FROM COMPANY.employees e " +
                "LEFT JOIN COMPANY.department d ON d.depId = e.dept_ID " +
                "LEFT JOIN COMPANY.User_Login ul ON e.employee_id = ul.employee_ID " +
                "WHERE e.employee_id = @Employee_ID";


                string firstName = "";
                string middleName = "";
                string lastName = "";
                string dob = "";
                string sex = "";
                string email = "";
                string phoneNumber = "";
                string SSN = "";
                string departmentName = "";
                dbConncetion.Open();
                using (var command = new SqlCommand(queryStringAccess, dbConncetion))
                {
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    using (var reader = command.ExecuteReader())
                    {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            firstName = reader.GetString(0);
                        }

                        if (!reader.IsDBNull(1))
                        {
                            middleName = reader.GetString(1);
                        }

                        if (!reader.IsDBNull(2))
                        {
                            lastName = reader.GetString(2);
                        }

                        if (!reader.IsDBNull(4))
                        {
                            dob = reader.GetString(4);
                        }

                        if (!reader.IsDBNull(5))
                        {
                            sex = reader.GetString(5);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            email = reader.GetString(6);
                        }

                        if (!reader.IsDBNull(7))
                        {
                            phoneNumber = reader.GetString(7);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            departmentName = reader.GetString(8);
                        }
                    }
                }
                }

                if (firstName.Length != 0)
                {
                    first_name.Text = firstName;
                }

                if (middleName.Length != 0)
                {
                    middle_name.Text = middleName;
                }

                if (employee_id != 0)
                {
                    employeeID.Text = employee_id.ToString();
                }

                if (lastName.Length != 0)
                {
                    last_name.Text = lastName;
                }

                if (dob.Length != 0)
                {
                    date_of_birth.Text = dob;
                }

                if (sex.Length != 0)
                {
                    gender.Text = sex;
                }

                if (email.Length != 0)
                {
                    email_address.Text = email;
                }

                if (phoneNumber.Length != 0)
                {
                    phone_number.Text = phoneNumber;
                }

                if (SSN.Length != 0)
                {
                    string lastFourSSN = SSN.Substring(SSN.Length - 4);
                    SSN_num.Text = lastFourSSN;
                }

                if (departmentName.Length != 0)
                {
                    departName.Text = departmentName;
                }

            if (IsPostBack)
            {
                string eventTarget = Request.Form["__EVENTTARGET"];
                if (eventTarget == btnFirstName.UniqueID)
                {
                    btnChangeFirstName(sender, e);
                }

                if (eventTarget == btnMiddleName.UniqueID)
                {
                    btnChangeMiddleName(sender, e);
                }

                if (eventTarget == btnLastName.UniqueID)
                {
                    btnChangeLastName(sender, e);
                }

                if (eventTarget == btnDOB.UniqueID)
                {
                    btnChangeDOB(sender, e);
                }

                if (eventTarget == btnDOB.UniqueID)
                {
                    btnChangeDOB(sender, e);
                }
                
                if (eventTarget == btnGender.UniqueID)
                {
                    btnChangeGender(sender, e);
                }

                if (eventTarget == btnPhoneNumber.UniqueID)
                {
                    btnChangePhoneNumber(sender, e);
                }

            }
        }
        protected void btnChangeFirstName(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string firstName = first_name.Text;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET employee_first_name = @New_First_Name OUTPUT INSERTED.employee_first_name WHERE employee_id = @Employee_ID", connection);
                command.Parameters.AddWithValue("@Employee_ID", employee_id);
                command.Parameters.AddWithValue("@New_First_Name", firstName);
                string updatedFirstName = (string)command.ExecuteScalar();
                first_name.Text = updatedFirstName;
            }
        }


        protected void btnChangeMiddleName(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string middleName = middle_name.Text;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET employee_middle_name = @New_middle_Name WHERE employee_id = @Employee_ID", connection);
                command.Parameters.AddWithValue("@Employee_ID", employee_id);
                command.Parameters.AddWithValue("@New_middle_Name", middleName);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    middle_name.Text = (string)reader["employee_middle_name"];
                }
                reader.Close();
            }
        }

        protected void btnChangeLastName(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
        }

        protected void btnChangeDOB(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
        }

        protected void btnChangeGender(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
        }

        protected void btnChangePhoneNumber(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);
        }

    }
}