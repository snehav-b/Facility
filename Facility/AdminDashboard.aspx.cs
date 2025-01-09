using System;
using System.Web.UI;

namespace YourProjectNamespace
{
    public partial class AdminDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in as an admin (for example, using session or cookie)
                if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
                {
                    Response.Redirect("Login.aspx"); // Redirect to login if not an admin
                }
            }
        }
    }
}
