using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class employee_master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            signoutButton.ServerClick += new EventHandler(signoutButton_Click);

        }

        protected void signoutButton_Click(object sender, EventArgs e)

        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
}