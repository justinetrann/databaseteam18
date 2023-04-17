using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class employeeReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve the value for tasksCompletionRate from the backend
            double tasksCompletionRate = 50; // Replace with your actual value

            // Set the value of tasksCompletionRateValue to this value
            tasksCompletionRateValue.Value = tasksCompletionRate.ToString();

            int tasksCompletedVal = 20;
            tasksCompleted.Value = tasksCompletedVal.ToString();

            //string progressBarColorValue = "";
            if (tasksCompletionRate < 50)
                progressBarColor.Value = "bg-danger";
            else if (tasksCompletionRate >= 50 && tasksCompletionRate < 75)
                progressBarColor.Value = "bg-warning";
            else
                progressBarColor.Value = "";


        }
    }
}


//<asp:HiddenField runat = "server" ID="tasksCompleted" />
//<asp:HiddenField runat = "server" ID="tasksCompletedOnTime" />
//<asp:HiddenField runat = "server" ID="tasksCompletedLate" /> progressBarColor