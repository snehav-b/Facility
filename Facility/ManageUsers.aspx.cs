using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class ManageUsers : System.Web.UI.Page

{
    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUsers();
        }
    }

    private void LoadUsers()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewUsers.DataSource = dt;
            GridViewUsers.DataBind();
        }
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (FirstName, LastName, Username, Email, Password) VALUES (@FirstName, @LastName, @Username, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        LoadUsers();
    }

    protected void GridViewUsers_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        GridViewUsers.EditIndex = e.NewEditIndex;
        LoadUsers();
    }

    protected void GridViewUsers_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        GridViewUsers.EditIndex = -1;
        LoadUsers();
    }

    protected void GridViewUsers_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridViewUsers.Rows[e.RowIndex];
        int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
        string firstName = ((TextBox)row.Cells[1].Controls[0]).Text;
        string lastName = ((TextBox)row.Cells[2].Controls[0]).Text;
        string username = ((TextBox)row.Cells[3].Controls[0]).Text;
        string email = ((TextBox)row.Cells[4].Controls[0]).Text;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Username = @Username, Email = @Email WHERE UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@UserId", userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        GridViewUsers.EditIndex = -1;
        LoadUsers();
    }

    protected void GridViewUsers_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        int userId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserId", userId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        LoadUsers();
    }
}


