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
using WebGrease.Activities;

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
            // SETTING UPDATE BUTTONS EVENTS HANDLER
            // Register First Name Change event handler
            btnFirstName.Click += new EventHandler(btnChangeFirstName);

            // Register Middle Name Change event handler
            btnMiddleName.Click += new EventHandler(btnChangeMiddleName);

            // Register Last Name Change event handler
            btnLastName.Click += new EventHandler(btnChangeLastName);

            // Register DOB Change event handler
            btnDOB.Click += new EventHandler(btnChangeDOB);

            // Register Gender Change event handler
            btnGender.Click += new EventHandler(btnChangeGender);

            // Register Email Change event handler
            btnEmail.Click += new EventHandler(btnChangeEmail);

            // Register Phone Number Change event handler
            btnPhoneNumber.Click += new EventHandler(btnChangePhoneNumber);

            if (!IsPostBack)
                readEmployeeProfileInfo(sender, e);
        }

        protected void readEmployeeProfileInfo(object sender, EventArgs e)
        {


            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            var dbConncetion = new SqlConnection(dbConnectionString);

            int employee_id = (int)Session["employee_id"];
            string queryStringAccess = "SELECT e.employee_first_name, e.employee_middle_name, e.employee_last_name, " +
                "e.employee_id, e.dob, e.SEX, ul.user_email, e.phoneNum, e.SSN, d.depName " +
                "FROM COMPANY.employees e " +
                "LEFT JOIN COMPANY.department d ON d.depId = e.dept_ID " +
                "LEFT JOIN COMPANY.User_Login ul ON e.employee_id = ul.employee_ID " +
                "WHERE e.employee_id = @Employee_ID";


            string firstName = "";
            string middleName = "";
            string lastName = "";
            DateTime dob_dt;
            

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
                            //successMessage.InnerHtml = reader.GetDateTime(4);
                            //successMessage.Style.Remove("display");
                            //return;
                            dob_dt = reader.GetDateTime(4);
                            dob = dob_dt.ToString("MM/dd/yyyy");

                        }


                        if (!reader.IsDBNull(5))
                        {
                            sex = reader.GetString(5);
                        }

                        if (!reader.IsDBNull(6))
                        {
                            email = reader.GetString(6);
                        }

                        if (!reader.IsDBNull(8))
                        {
                            phoneNumber = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(8))
                        {
                            SSN = reader.GetString(8);
                        }

                        if (!reader.IsDBNull(9))
                        {
                            departmentName = reader.GetString(9);
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
                current_date_of_birth.Text = dob;
            }

            if (sex.Length != 0)
            {
                gender.SelectedValue = sex;
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
                SSN_num.Text = "***-**-" + lastFourSSN;
            }

            if (departmentName.Length != 0)
            {
                departName.Text = departmentName;
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
                string updateFirstNameSuccess = (string)command.ExecuteScalar();
                readEmployeeProfileInfo(sender, e);

                if (updateFirstNameSuccess != null)
                {
                    successMessage.InnerHtml = "First Name Updated Successfully.";
                    successMessage.Style.Remove("display");
                    return;
                }
                else
                {
                    errorMessage.InnerHtml = "Error Updating Last Name!";
                    errorMessage.Style.Remove("display");
                    return;
                }
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
                SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET employee_middle_name = @New_middle_Name OUTPUT INSERTED.employee_middle_name WHERE employee_id = @Employee_ID", connection);
                command.Parameters.AddWithValue("@Employee_ID", employee_id);
                command.Parameters.AddWithValue("@New_middle_Name", middleName);
                command.ExecuteNonQuery();
                string updateMiddleNameSuccess = (string)command.ExecuteScalar();
                readEmployeeProfileInfo(sender, e);

                if (updateMiddleNameSuccess != null)
                {
                    successMessage.InnerHtml = "Middle Name Updated Successfully.";
                    successMessage.Style.Remove("display");
                    return;
                }
                else
                {
                    errorMessage.InnerHtml = "Error Updating Middle Name!";
                    errorMessage.Style.Remove("display");
                    return;
                }
            }
        }

        protected void btnChangeLastName(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;
            string lastName = last_name.Text;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET employee_last_name = @New_last_Name OUTPUT INSERTED.employee_last_name WHERE employee_id = @Employee_ID", connection);
                command.Parameters.AddWithValue("@Employee_ID", employee_id);
                command.Parameters.AddWithValue("@New_last_Name", lastName);
                command.ExecuteNonQuery();
                string updateLastNameSuccess = (string)command.ExecuteScalar();
                readEmployeeProfileInfo(sender, e);

                if (updateLastNameSuccess != null)
                {
                    successMessage.InnerHtml = "Last Name Updated Successfully.";
                    successMessage.Style.Remove("display");
                    return;
                }
                else
                {
                    errorMessage.InnerHtml = "Error Updating Last Name!";
                    errorMessage.Style.Remove("display");
                    return;
                }
            }
        }

        protected void btnChangeDOB(object sender, EventArgs e)
        {
            try
            {
                int employee_id = (int)Session["employee_id"];
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                string DOB = date_of_birth.Text;

                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET dob = @New_DOB OUTPUT INSERTED.dob WHERE employee_id = @Employee_ID", connection);
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    command.Parameters.AddWithValue("@New_DOB", DOB);
                    command.ExecuteNonQuery();
                    DateTime updateDOBSuccess = (DateTime)command.ExecuteScalar();
                    readEmployeeProfileInfo(sender, e);

                    if (updateDOBSuccess != null)
                    {
                        successMessage.InnerHtml = "Date of Birth Updated Successfully.";
                        successMessage.Style.Remove("display");
                        return;
                    }
                    else
                    {
                        errorMessage.InnerHtml = "Error Updating Date of Birth!";
                        errorMessage.Style.Remove("display");
                        return;
                    }
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage.InnerHtml = "Error While Updating Information (DB error) ";
                errorMessage.Style.Remove("display");
                //if (ex.Message.Contains("Manager already has an ongoing project"))
                //{
                //    // Display a personalized error message to the user
                //    Console.WriteLine("An error occurred: " + ex.Message);
                //    errorMessage.InnerHtml = "You alread have an ongoing project. Pause or Complete a project before starting a new one.";
                //    errorMessage.Style.Remove("display");
                //}
                //else
                //{
                // If the error was caused by something else, display a generic error message
                //Console.WriteLine("An error occurred: " + ex.Message);
                //errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                //errorMessage.Style.Remove("display");
            }

        }

        protected void btnChangeGender(object sender, EventArgs e)
        {
            int employee_id = (int)Session["employee_id"];
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

            string new_gender = gender.SelectedValue;

            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET SEX = @New_gender OUTPUT INSERTED.SEX WHERE employee_id = @Employee_ID", connection);
                command.Parameters.AddWithValue("@Employee_ID", employee_id);
                command.Parameters.AddWithValue("@New_gender", new_gender);
                command.ExecuteNonQuery();
                string updateGenderSuccess = (string)command.ExecuteScalar();
                readEmployeeProfileInfo(sender, e);

                if (updateGenderSuccess != null)
                {
                    successMessage.InnerHtml = "Gender Updated Successfully.";
                    successMessage.Style.Remove("display");
                    return;
                }
                else
                {
                    errorMessage.InnerHtml = "Error Updating Gender!";
                    errorMessage.Style.Remove("display");
                    return;
                }
            }
        }

        protected void btnChangeEmail(object sender, EventArgs e)
        {
            try
            {
                int employee_id = (int)Session["employee_id"];
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                string new_email = email_address.Text;

                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE COMPANY.User_Login SET user_email = @New_email OUTPUT INSERTED.user_email WHERE login_ID in (SELECT DISTINCT login_ID from COMPANY.employees WHERE employee_id = @Employee_ID)", connection);
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    command.Parameters.AddWithValue("@New_email", new_email);
                    command.ExecuteNonQuery();
                    string updateEmailSuccess = (string)command.ExecuteScalar();
                    readEmployeeProfileInfo(sender, e);

                    if (updateEmailSuccess != null)
                    {
                        successMessage.InnerHtml = "Email Updated Successfully.";
                        successMessage.Style.Remove("display");
                        return;
                    }
                    else
                    {
                        errorMessage.InnerHtml = "Error Updating Email!";
                        errorMessage.Style.Remove("display");
                        return;
                    }
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage.InnerHtml = "Error While Updating Information (DB error) ";
                errorMessage.Style.Remove("display");
                //if (ex.Message.Contains("Manager already has an ongoing project"))
                //{
                //    // Display a personalized error message to the user
                //    Console.WriteLine("An error occurred: " + ex.Message);
                //    errorMessage.InnerHtml = "You alread have an ongoing project. Pause or Complete a project before starting a new one.";
                //    errorMessage.Style.Remove("display");
                //}
                //else
                //{
                // If the error was caused by something else, display a generic error message
                //Console.WriteLine("An error occurred: " + ex.Message);
                //errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                //errorMessage.Style.Remove("display");
            }
        }

        protected void btnChangePhoneNumber(object sender, EventArgs e)
        {
            try {
                int employee_id = (int)Session["employee_id"];
                string dbConnectionString = ConfigurationManager.ConnectionStrings["DataBaseConnectionString"].ConnectionString;

                string new_phonenum = phone_number.Text;


                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE COMPANY.employees SET phoneNUM = @New_phonenum OUTPUT INSERTED.phoneNUM WHERE employee_id = @Employee_ID", connection);
                    command.Parameters.AddWithValue("@Employee_ID", employee_id);
                    command.Parameters.AddWithValue("@New_phonenum", new_phonenum);
                    command.ExecuteNonQuery();
                    string updatePhoneNumSuccess = (string)command.ExecuteScalar();
                    readEmployeeProfileInfo(sender, e);

                    if (updatePhoneNumSuccess != null && updatePhoneNumSuccess == new_phonenum)
                    {
                        successMessage.InnerHtml = "Phone Number Updated Successfully.";
                        successMessage.Style.Remove("display");
                        return;
                    }
                    else
                    {
                        errorMessage.InnerHtml = "Error Updating Phone Number!";
                        errorMessage.Style.Remove("display");
                        return;
                    }
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine("An error occurred: " + ex.Message);
                errorMessage.InnerHtml = "Error While Updating Information (DB error). Make sure entered phone number is 10 digits.";
                errorMessage.Style.Remove("display");
                //if (ex.Message.Contains("Manager already has an ongoing project"))
                //{
                //    // Display a personalized error message to the user
                //    Console.WriteLine("An error occurred: " + ex.Message);
                //    errorMessage.InnerHtml = "You alread have an ongoing project. Pause or Complete a project before starting a new one.";
                //    errorMessage.Style.Remove("display");
                //}
                //else
                //{
                // If the error was caused by something else, display a generic error message
                //Console.WriteLine("An error occurred: " + ex.Message);
                //errorMessage.InnerHtml = "A Database error occurred: " + ex.Message;
                //errorMessage.Style.Remove("display");
            }
        }

    }
}