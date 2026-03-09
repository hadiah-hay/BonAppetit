using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Bon
{
}

namespace Bon
{
}

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

        // Ensure a UserPreferences table exists. Columns: ID AUTOINCREMENT PK, Username, PreferenceKey, PreferenceValue, Created
        public static void EnsurePreferencesTableExists(string connectionString)
        {
            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            // check if table exists
            DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            var exists = false;
            if (schema != null)
            {
                foreach (DataRow row in schema.Rows)
                {
                    var name = row["TABLE_NAME"]?.ToString();
                    if (string.Equals(name, "UserPreferences", StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if (!exists)
            {
                using var cmd = connection.CreateCommand();
                // Create table in Access
                cmd.CommandText = "CREATE TABLE UserPreferences (ID AUTOINCREMENT PRIMARY KEY, Username TEXT(255), PreferenceKey TEXT(255), PreferenceValue TEXT(255), Created DATETIME)";
                cmd.ExecuteNonQuery();
            }
        }

        // Save or replace a user's preference (simple upsert: delete existing key then insert)
        public static void SaveUserPreference(string connectionString, string username, string key, string value)
        {
            EnsurePreferencesTableExists(connectionString);
            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            using (var del = new OleDbCommand("DELETE FROM UserPreferences WHERE Username = ? AND PreferenceKey = ?", connection))
            {
                del.Parameters.AddWithValue("@p1", username);
                del.Parameters.AddWithValue("@p2", key);
                del.ExecuteNonQuery();
            }

            using (var ins = new OleDbCommand("INSERT INTO UserPreferences (Username, PreferenceKey, PreferenceValue, Created) VALUES (?, ?, ?, ?)", connection))
            {
                ins.Parameters.AddWithValue("@p1", username);
                ins.Parameters.AddWithValue("@p2", key);
                ins.Parameters.AddWithValue("@p3", value);
                ins.Parameters.AddWithValue("@p4", DateTime.Now);
                ins.ExecuteNonQuery();
            }
        }

        public static DataTable GetPreferencesForUser(string connectionString, string username)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand("SELECT * FROM [Preferences] WHERE [Username] = ?", connection);
            cmd.Parameters.AddWithValue("@p1", username);
            using var adapter = new OleDbDataAdapter(cmd);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }

        // Save a single preference column (Happy, Sad, Angry, Confused, Frustrated) for a user.
        // If a row for the user exists, update the column; otherwise insert a new row with that column set.
        public static void SavePreferenceColumn(string connectionString, string username, string columnName, string value)
        {
            // validate column name against allowed set to avoid SQL injection
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Happy", "Sad", "Angry", "Confused", "Frustrated" };
            if (!allowed.Contains(columnName))
                throw new ArgumentException("Invalid preference column", nameof(columnName));

            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            using var check = new OleDbCommand("SELECT COUNT(*) FROM [preferences] WHERE [Username] = ?", connection);
            check.Parameters.AddWithValue("@p1", username);
            var cnt = Convert.ToInt32(check.ExecuteScalar());

            if (cnt > 0)
            {
                // update existing row
                var sql = $"UPDATE [Preferences] SET [{columnName}] = ? WHERE [Username] = ?";
                using var cmd = new OleDbCommand(sql, connection);
                cmd.Parameters.AddWithValue("@p1", value);
                cmd.Parameters.AddWithValue("@p2", username);
                cmd.ExecuteNonQuery();
            }
            else
            {
                // insert new row with the single column value
                var sql = $"INSERT INTO [Preferences] ([Username], [{columnName}]) VALUES (?, ?)";
                using var cmd = new OleDbCommand(sql, connection);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", value);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
