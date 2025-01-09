using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Facility
{
    public partial class ManageVendors : System.Web.UI.Page
    {
        // Connection string from web.config
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadVendors();
            }
        }

        // Method to load vendors from database
        private void LoadVendors()
        {
            // SQL query to get vendor data
            string query = "SELECT VendorID, VendorName, ServiceType, ContactInfo FROM Vendors";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Bind the GridView with data
                    GridViewVendors.DataSource = reader;
                    GridViewVendors.DataBind();
                }
            }
        }

        // Method to handle deleting vendor (you can add logic here for deletion)
        protected void GridViewVendors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // You can get the VendorID from the GridView row and write your delete logic here.
            int vendorID = Convert.ToInt32(GridViewVendors.DataKeys[e.RowIndex].Value);

            string deleteQuery = "DELETE FROM Vendors WHERE VendorID = @VendorID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    // Reload the GridView after deleting a vendor
                    LoadVendors();
                }
            }
        }
    }
}

