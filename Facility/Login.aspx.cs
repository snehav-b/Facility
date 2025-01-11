using System;
using System.Data.SqlClient;
using System.Configuration;

namespace YourNamespace
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the session already has a logged-in user
            if (Session["Username"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Connection string from web.config
            string connStr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // For simplicity, plain password. Use hashing for production.

                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        // Successful login
                        Session["Username"] = username; // Store user session
                        Response.Redirect("Dashboard.aspx"); // Redirect to the dashboard page
                    }
                    else
                    {
                        // Invalid login attempt
                        lblError.Text = "Invalid username or password!";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    lblError.Text = "An error occurred. Please try again.";
                    lblError.Visible = true;
                }
            }
        }
    }
}
