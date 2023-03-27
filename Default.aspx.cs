using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace databaseteam18
{
    public partial class _Default : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                //this.MasterPageFile = "~/default_site.Master";
                Response.Redirect("~/Login.aspx");
            }
            else
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
                    this.MasterPageFile = "~/Site.Master";
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Your other Page_Load code here
        }
    }
}