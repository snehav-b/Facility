using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["FacilityDB"].ConnectionString;

    // Method to open and return a database connection
    public static SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        return conn;
    }

    // Method to execute a query that returns a DataTable (e.g., fetching data for display)
    public static DataTable ExecuteQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
    }

    // Method to execute a non-query (e.g., insert, update, delete)
    public static int ExecuteNonQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd.ExecuteNonQuery();
        }
    }
}
