using System;
using System.Data;
using System.Data.OleDb;

namespace Bon
{
    /// <summary>
    /// Helper class for accessing the Access database for user login and registration.
    /// </summary>
    public static class DataAccess
    {
        /// <summary>
        /// Get a specific user by username.
        /// </summary>
        public static DataTable GetUser(string connectionString, string username)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "SELECT [Username], [email_ID], [Password] FROM [Users] WHERE [Username] = ?",
                connection);
            cmd.Parameters.AddWithValue("@p1", username);
            using var adapter = new OleDbDataAdapter(cmd);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Check if a username already exists.
        /// </summary>
        public static bool UserExists(string connectionString, string username)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "SELECT COUNT(*) FROM [Users] WHERE [Username] = ?",
                connection);
            cmd.Parameters.AddWithValue("@p1", username);
            connection.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        /// <summary>
        /// Insert a new user into the database.
        /// </summary>
        public static int InsertUser(string connectionString, string username, string email, string password)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "INSERT INTO [Users] ([Username], [email_ID], [Password]) VALUES (?, ?, ?)",
                connection);
            cmd.Parameters.AddWithValue("@p1", username);
            cmd.Parameters.AddWithValue("@p2", email);
            cmd.Parameters.AddWithValue("@p3", password);
            connection.Open();
            return cmd.ExecuteNonQuery();
        }
        public static DataTable GetUsers(string connectionString)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand("SELECT * FROM [Users]", connection);
            using var adapter = new OleDbDataAdapter(cmd);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }

        // Update user password
        public static int UpdateUser(string connectionString, string username, string email, string password)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "UPDATE [Users] SET [email_ID] = ?, [Password] = ? WHERE [Username] = ?",
                connection);

            cmd.Parameters.AddWithValue("@p1", email);
            cmd.Parameters.AddWithValue("@p2", password);
            cmd.Parameters.AddWithValue("@p3", username);

            connection.Open();
            return cmd.ExecuteNonQuery();
        }

        // Get table names
        public static DataTable GetTableNames(string connectionString)
        {
            using var connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection.GetSchema("Tables");
        }
    }
}