using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Facility
{
    public partial class ManageVendor : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT VendorID, VendorName, ServiceType, ContactNumber FROM Vendors";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewVendors.DataSource = dt;
                GridViewVendors.DataBind();
            }
        }

        protected void GridViewVendors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int vendorId = Convert.ToInt32(GridViewVendors.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Vendors WHERE VendorID = @VendorID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VendorID", vendorId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Rebind the GridView to reflect changes
            BindGridView();
        }
    }
}
