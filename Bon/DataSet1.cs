using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Bon
{
    /// <summary>
    /// Helper methods for accessing the Access database.
    /// </summary>
    public static class DataAccess
    {
        public static List<string> GetTableNames(string connectionString)
        {
            var tableNames = new List<string>();
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (schema == null)
                    return tableNames;

                foreach (DataRow row in schema.Rows)
                {
                    var name = row["TABLE_NAME"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                        tableNames.Add(name);
                }
            }

            return tableNames;
        }

        public static DataTable GetUsers(string connectionString)
        {
            var dt = new DataTable();
            using (var connection = new OleDbConnection(connectionString))
            using (var command = new OleDbCommand("SELECT [Username], [email_ID], [Password] FROM [Users]", connection))
            using (var adapter = new OleDbDataAdapter(command))
            {
                connection.Open();
                adapter.Fill(dt);
            }

            return dt;
        }

        public static bool UserExists(string connectionString, string username)
        {
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand("SELECT COUNT(*) FROM [Users] WHERE [Username] = ?", connection);
            command.Parameters.AddWithValue("@p1", username);
            connection.Open();
            var result = command.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }

        public static int InsertUser(string connectionString, string username, string email, string password)
        {
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand("INSERT INTO [Users] ([Username], [email_ID], [Password]) VALUES (?, ?, ?)", connection);
            command.Parameters.AddWithValue("@p1", username);
            command.Parameters.AddWithValue("@p2", email);
            command.Parameters.AddWithValue("@p3", password);
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public static int UpdateUser(string connectionString, string username, string email, string password)
        {
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand("UPDATE [Users] SET [email_ID] = ?, [Password] = ? WHERE [Username] = ?", connection);
            command.Parameters.AddWithValue("@p1", email);
            command.Parameters.AddWithValue("@p2", password);
            command.Parameters.AddWithValue("@p3", username);
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public static DataTable GetUser(string connectionString, string username)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var command = new OleDbCommand("SELECT [Username], [email_ID], [Password] FROM [Users] WHERE [Username] = ?", connection);
            command.Parameters.AddWithValue("@p1", username);
            using var adapter = new OleDbDataAdapter(command);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }
    }
}
