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

        // Insert an answer record from NewForm
        public static int InsertNewFormAnswer(string connectionString, string username, string question, string answer)
        {
            using var connection = new OleDbConnection(connectionString);
            using var cmd = new OleDbCommand("INSERT INTO [NewFormAnswers] ([Username],[Question],[Answer],[DateAnswered]) VALUES (?,?,?,?)", connection);
            cmd.Parameters.AddWithValue("@p1", username);
            cmd.Parameters.AddWithValue("@p2", question);
            cmd.Parameters.AddWithValue("@p3", answer);
            cmd.Parameters.AddWithValue("@p4", DateTime.Now);
            connection.Open();
            return cmd.ExecuteNonQuery();
        }

        // Ensure required tables exist in the Access database. Creates missing tables and
        // seeds the `Foods` table with sample entries if it's empty.
        public static void EnsureSchemaExists(string connectionString)
        {
            try
            {
                var existing = GetTableNames(connectionString);

                using var connection = new OleDbConnection(connectionString);
                connection.Open();

                void Exec(string sql)
                {
                    using var cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }

                if (!existing.Exists(t => string.Equals(t, "Users", StringComparison.OrdinalIgnoreCase)))
                {
                    Exec("CREATE TABLE [Users] ([Username] TEXT(100) PRIMARY KEY, [email_ID] TEXT(255), [Password] TEXT(255))");
                }

                if (!existing.Exists(t => string.Equals(t, "Preferences", StringComparison.OrdinalIgnoreCase)))
                {
                    Exec("CREATE TABLE [Preferences] ([Username] TEXT(100) PRIMARY KEY, [Happy] TEXT(50), [Sad] TEXT(50), [Angry] TEXT(50), [Stressed] TEXT(50), [Bored] TEXT(50))");
                }

                if (!existing.Exists(t => string.Equals(t, "Cravings", StringComparison.OrdinalIgnoreCase)))
                {
                    Exec("CREATE TABLE [Cravings] ([Username] TEXT(100) PRIMARY KEY, [HappyCraving] TEXT(50), [SadCraving] TEXT(50), [AngryCraving] TEXT(50), [StressedCraving] TEXT(50), [BoredCraving] TEXT(50))");
                }

                if (!existing.Exists(t => string.Equals(t, "Foods", StringComparison.OrdinalIgnoreCase)))
                {
                    Exec("CREATE TABLE [Foods] ([FoodName] TEXT(255), [Category] TEXT(50))");
                }

                if (!existing.Exists(t => string.Equals(t, "DailyMoods", StringComparison.OrdinalIgnoreCase)))
                {
                    Exec("CREATE TABLE [DailyMoods] ([Username] TEXT(100), [Mood] TEXT(50), [DateRecorded] DATETIME)");
                }

                // Table for answers submitted from the NewForm
                if (!existing.Exists(t => string.Equals(t, "NewFormAnswers", StringComparison.OrdinalIgnoreCase)))
                {
                    // Question and Answer stored as TEXT (255). Use DateRecorded to track when answer was given.
                    Exec("CREATE TABLE [NewFormAnswers] ([Username] TEXT(100), [Question] TEXT(255), [Answer] MEMO, [DateAnswered] DATETIME)");
                }

                // Seed Foods if empty
                using (var chk = new OleDbCommand("SELECT COUNT(*) FROM [Foods]", connection))
                {
                    var cnt = Convert.ToInt32(chk.ExecuteScalar());
                    if (cnt == 0)
                    {
                        var foods = new (string Name, string Category)[]
                        {
                            ("Gulab Jamun", "sweet"),
                            ("Chocolate Cake", "sweet"),
                            ("Halwa", "sweet"),
                            ("Limes", "sour"),
                            ("Yogurt", "sour"),
                            ("Pickles", "sour"),
                            ("Kimchi", "spicy"),
                            ("Buffalo Wings", "spicy"),
                            ("Thai Curry", "spicy"),
                            ("Pretzels", "salty"),
                            ("Bacon", "salty"),
                            ("Chedder Cheez", "salty")
                        };

                        using var ins = new OleDbCommand("INSERT INTO [Foods] ([FoodName],[Category]) VALUES (?,?)", connection);
                        foreach (var f in foods)
                        {
                            ins.Parameters.Clear();
                            ins.Parameters.AddWithValue("@p1", f.Name);
                            ins.Parameters.AddWithValue("@p2", f.Category);
                            ins.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
                // If schema creation fails, don't crash the app — user can fix DB manually.
            }
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
    }
}