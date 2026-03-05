using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Mail;
using System.IO;

namespace Bon

{
    public partial class Form1 : Form
    {
        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\Bon.accdb";
        private readonly bool _isSignupMode;
        public bool PreferencesOpened { get; private set; }
       public Form1()
        {
            InitializeComponent();
            _isSignupMode = false;
        }

        public Form1(bool isSignupMode)
        {
            InitializeComponent();
            _isSignupMode = isSignupMode;
            PreferencesOpened = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var tables = DataAccess.GetTableNames(connectionString);
                if (tables.Rows.Count == 0)
                {
                    Debug.WriteLine("No user tables found in the database.");
                }
                else
                {
                    // Show table names so you can confirm the exact name to query
                    Debug.WriteLine("Tables: " + string.Join(", ", tables));
                    // If Users table exists, load its rows and populate the first record into the text boxes
                    bool usersTableExists = false;

                    foreach (DataRow row in tables.Rows)
                    {
                        if (row["TABLE_NAME"].ToString() == "Users")
                        {
                            usersTableExists = true;
                            break;
                        }
                    }

                    if (usersTableExists)
                    {
                        var users = DataAccess.GetUsers(connectionString);
                        Debug.WriteLine($"Users rows: {users.Rows.Count}");
                    }
                    {
                        var users = DataAccess.GetUsers(connectionString);
                        Debug.WriteLine($"Users rows: {users.Rows.Count}");
                        // Do not pre-fill text boxes on startup; keep them empty for new input.
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error accessing database: {ex.Message}");
            }

            // Ensure text boxes are empty when the application starts
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            labelUsernameError.Text = string.Empty;
            labelEmailError.Text = string.Empty;
            labelPasswordError.Text = string.Empty;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var username = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                labelUsernameError.Text = string.Empty;
                return;
            }

            try
            {
                // show inline validation: username must be unique
                var exists = DataAccess.UserExists(connectionString, username);
                labelUsernameError.Text = exists ? "Username already exists" : string.Empty;
            }
            catch (Exception ex)
            {
                // don't surface error to UI; write to debug
                Debug.WriteLine($"Username check failed: {ex.Message}");
                labelUsernameError.Text = string.Empty;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           var pwd = textBox3.Text ?? string.Empty;
           if (string.IsNullOrEmpty(pwd))
           {
               labelPasswordError.Text = string.Empty;
               return;
           }

           labelPasswordError.Text = pwd.Length < 8 ? "Password must be at least 8 characters" : string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var email = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                labelEmailError.Text = string.Empty;
                return;
            }

            try
            {
                // Use MailAddress to validate email format
                var addr = new MailAddress(email);
                labelEmailError.Text = string.Empty;
            }
            catch (FormatException)
            {
                labelEmailError.Text = "Invalid email address";
                Debug.WriteLine($"Invalid email entered: {email}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text.Trim();
            var email = textBox2.Text.Trim();
            var password = textBox3.Text;

            if (string.IsNullOrEmpty(username))
            {
                Debug.WriteLine("Validation: username is empty.");
                return;
            }

            // Prevent save if password is too short
            if ((textBox3.Text ?? string.Empty).Length < 8)
            {
                labelPasswordError.Text = "Password must be at least 8 characters";
                Debug.WriteLine("Validation: password too short.");
                return;
            }

            try
            {
                int rowsAffected = 0;
                var exists = DataAccess.UserExists(connectionString, username);
                if (exists)
                {
                    rowsAffected = DataAccess.UpdateUser(connectionString, username, email, password);
                    Debug.WriteLine(rowsAffected > 0 ? "User updated." : "No rows updated.");
                }
                else
                {
                    rowsAffected = DataAccess.InsertUser(connectionString, username, email, password);
                    Debug.WriteLine(rowsAffected > 0 ? "User inserted." : "No rows inserted.");
                }

                if (rowsAffected > 0)
                {
                    // Diagnostic: verify the record in DB and write to debug output
                    var verify = DataAccess.GetUser(connectionString, username);
                    if (verify.Rows.Count > 0)
                    {
                        var r = verify.Rows[0];
                        Debug.WriteLine($"DB record - Username: {r["Username"]}, email_ID: {r["email_ID"]}, Password: {r["Password"]}");
                    }
                    else
                    {
                        Debug.WriteLine("Record not found after save.");
                    }

                    // Show file existence and last write time for the data source file
                    try
                    {
                        var dataSource = GetDataSourcePathFromConnectionString(connectionString);
                        if (!string.IsNullOrEmpty(dataSource))
                        {
                            var fileExists = File.Exists(dataSource);
                            var lastWrite = fileExists ? File.GetLastWriteTime(dataSource).ToString() : "N/A";
                            Debug.WriteLine($"DataSource: {dataSource}\nExists: {fileExists}\nLastWrite: {lastWrite}");
                        }
                    }
                    catch { }

                    // Clear text boxes after successful store
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                    // If this form was opened for sign-up and we just inserted a new user, open preferences
                    if (!exists && _isSignupMode)
                    {
                        try
                        {
                            this.Hide();
                            using (var pref = new preferences())
                            {
                                pref.ShowDialog(this);
                            }
                            PreferencesOpened = true;
                            this.Close();
                            return; // ensure we exit after closing
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Opening preferences failed: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("No rows affected; not clearing input fields.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB error: {ex.Message}");
            }
        }

        private static string GetDataSourcePathFromConnectionString(string cs)
        {
            // crude parser for Data Source=...; in the connection string
            var parts = cs.Split(';');
            foreach (var p in parts)
            {
                var kv = p.Split('=');
                if (kv.Length == 2 && kv[0].Trim().Equals("Data Source", StringComparison.OrdinalIgnoreCase))
                    return kv[1].Trim().Trim('"');
            }
            return string.Empty;
        }
    }
}
