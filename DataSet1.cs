using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Bon
{
    public static class DataAccess
    {
        public static List<string> GetTableNames(string connectionString)
        {
            var tableNames = new List<string>();
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (schema == null) return tableNames;
                foreach (DataRow row in schema.Rows)
                {
                    var name = row["TABLE_NAME"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                        tableNames.Add(name);
                }
            }
            return tableNames;
        }
        public static void InsertNewFormAnswer(string connectionString, string username, string question, string answer)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "INSERT INTO [NewFormAnswers] ([Username], [Question], [Answer], [DateAnswered]) VALUES (?, ?, ?, ?)",
                connection);
            cmd.Parameters.AddWithValue("@p1", username);
            cmd.Parameters.AddWithValue("@p2", question);
            cmd.Parameters.AddWithValue("@p3", answer);
            cmd.Parameters.AddWithValue("@p4", DateTime.Now);
            connection.Open();
            cmd.ExecuteNonQuery();
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
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
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

        // Save a single preference column for a user (Happy, Sad, Angry, Stressed, Bored)
        public static void SavePreferenceColumn(string connectionString, string username, string columnName, string value)
        {
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                { "Happy", "Sad", "Angry", "Stressed", "Bored" };

            if (!allowed.Contains(columnName))
                throw new ArgumentException("Invalid preference column", nameof(columnName));

            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            using var check = new OleDbCommand("SELECT COUNT(*) FROM [Preferences] WHERE [Username] = ?", connection);
            check.Parameters.AddWithValue("@p1", username);
            var cnt = Convert.ToInt32(check.ExecuteScalar());

            if (cnt > 0)
            {
                var sql = $"UPDATE [Preferences] SET [{columnName}] = ? WHERE [Username] = ?";
                using var cmd = new OleDbCommand(sql, connection);
                cmd.Parameters.AddWithValue("@p1", value);
                cmd.Parameters.AddWithValue("@p2", username);
                cmd.ExecuteNonQuery();
            }
            else
            {
                var sql = $"INSERT INTO [Preferences] ([Username], [{columnName}]) VALUES (?, ?)";
                using var cmd = new OleDbCommand(sql, connection);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", value);
                cmd.ExecuteNonQuery();
            }
        }

        // Save all cravings for a user in one go
        public static void SaveCravings(string connectionString, string username,
            string happy, string sad, string angry, string stressed, string bored)
        {
            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            using var check = new OleDbCommand("SELECT COUNT(*) FROM [Cravings] WHERE [Username] = ?", connection);
            check.Parameters.AddWithValue("@p1", username);
            var cnt = Convert.ToInt32(check.ExecuteScalar());

            if (cnt > 0)
            {
                using var cmd = new OleDbCommand(
                    "UPDATE [Cravings] SET [HappyCraving]=?, [SadCraving]=?, [AngryCraving]=?, [StressedCraving]=?, [BoredCraving]=? WHERE [Username]=?",
                    connection);
                cmd.Parameters.AddWithValue("@p1", happy);
                cmd.Parameters.AddWithValue("@p2", sad);
                cmd.Parameters.AddWithValue("@p3", angry);
                cmd.Parameters.AddWithValue("@p4", stressed);
                cmd.Parameters.AddWithValue("@p5", bored);
                cmd.Parameters.AddWithValue("@p6", username);
                cmd.ExecuteNonQuery();
            }
            else
            {
                using var cmd = new OleDbCommand(
                    "INSERT INTO [Cravings] ([Username],[HappyCraving],[SadCraving],[AngryCraving],[StressedCraving],[BoredCraving]) VALUES (?,?,?,?,?,?)",
                    connection);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", happy);
                cmd.Parameters.AddWithValue("@p3", sad);
                cmd.Parameters.AddWithValue("@p4", angry);
                cmd.Parameters.AddWithValue("@p5", stressed);
                cmd.Parameters.AddWithValue("@p6", bored);
                cmd.ExecuteNonQuery();
            }
        }

        // Get a user's craving for a specific emotion
        public static string GetCravingForEmotion(string connectionString, string username, string emotion)
        {
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                { "HappyCraving", "SadCraving", "AngryCraving", "StressedCraving", "BoredCraving" };

            if (!allowed.Contains(emotion))
                throw new ArgumentException("Invalid craving column", nameof(emotion));

            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand($"SELECT [{emotion}] FROM [Cravings] WHERE [Username] = ?", connection);
            cmd.Parameters.AddWithValue("@p1", username);
            connection.Open();
            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? string.Empty;
        }

        // Get all foods for a category (Sweet, Sour, Spicy, Salty)
        public static DataTable GetFoodsByCategory(string connectionString, string category)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand("SELECT [FoodName] FROM [Foods] WHERE [Category] = ?", connection);
            cmd.Parameters.AddWithValue("@p1", category);
            using var adapter = new OleDbDataAdapter(cmd);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }
        public static void SaveAllPreferences(string connectionString, string username,
    string happy, string sad, string angry, string stressed, string bored)
        {
            using var connection = new OleDbConnection(connectionString);
            connection.Open();

            using var check = new OleDbCommand("SELECT COUNT(*) FROM [Preferences] WHERE [Username] = ?", connection);
            check.Parameters.AddWithValue("@p1", username);
            var cnt = Convert.ToInt32(check.ExecuteScalar());

            if (cnt > 0)
            {
                using var cmd = new OleDbCommand(
                    "UPDATE [Preferences] SET [Happy]=?, [Sad]=?, [Angry]=?, [Stressed]=?, [Bored]=? WHERE [Username]=?",
                    connection);
                cmd.Parameters.AddWithValue("@p1", happy);
                cmd.Parameters.AddWithValue("@p2", sad);
                cmd.Parameters.AddWithValue("@p3", angry);
                cmd.Parameters.AddWithValue("@p4", stressed);
                cmd.Parameters.AddWithValue("@p5", bored);
                cmd.Parameters.AddWithValue("@p6", username);
                cmd.ExecuteNonQuery();
            }
            else
            {
                using var cmd = new OleDbCommand(
                    "INSERT INTO [Preferences] ([Username],[Happy],[Sad],[Angry],[Stressed],[Bored]) VALUES (?,?,?,?,?,?)",
                    connection);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", happy);
                cmd.Parameters.AddWithValue("@p3", sad);
                cmd.Parameters.AddWithValue("@p4", angry);
                cmd.Parameters.AddWithValue("@p5", stressed);
                cmd.Parameters.AddWithValue("@p6", bored);
                cmd.ExecuteNonQuery();
            }
        }
        public static bool UserHasPreferences(string connectionString, string username)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand("SELECT COUNT(*) FROM [Preferences] WHERE [Username] = ?", connection);
            cmd.Parameters.AddWithValue("@p1", username);
            connection.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
        public static DataTable GetWellnessRecommendation(string connectionString, string category, string answer)
        {
            var dt = new DataTable();
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand(
                "SELECT [Tip], [Food1], [Food2], [Food3] FROM [WellnessRecommendations] WHERE [Category] = ? AND [Answer] = ?",
                connection);
            cmd.Parameters.AddWithValue("@p1", category);
            cmd.Parameters.AddWithValue("@p2", answer);
            using var adapter = new OleDbDataAdapter(cmd);
            connection.Open();
            adapter.Fill(dt);
            return dt;
        }
    }
}