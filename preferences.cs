using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Bon
{
    public partial class preferences : Form
    {
        private readonly string _username;
        private readonly string _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\Bon.accdb";
        private readonly Dictionary<string, string> _selections = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly string[] _requiredKeys = new[] { "Happy", "Sad", "Angry", "Confused", "Frustrated" };
        public preferences()
        {
            InitializeComponent();
            AttachPreferenceHandlers();
            // Check that the Preferences table exists in the database
            try
            {
                var tables = DataAccess.GetTableNames(_connectionString);
                var hasPreferences = tables.Exists(t => string.Equals(t, "Preferences", StringComparison.OrdinalIgnoreCase));
                if (!hasPreferences)
                {
                    // show inline notice on the title label and write debug output
                    label1.Text += " (DB table 'Preferences' not found)";
                    Debug.WriteLine("Preferences form: 'Preferences' table not found. Available tables: " + string.Join(", ", tables));
                }
                else
                {
                    Debug.WriteLine("Preferences form: 'Preferences' table found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Preferences table check failed: {ex.Message}");
            }
        }

        public preferences(string username) : this()
        {
            _username = username;
        }

        private void AttachPreferenceHandlers()
        {
            // attach a shared handler to all buttons to capture preference selections
            foreach (Control c in this.Controls)
            {
                if (c is Button b && b != null)
                {
                    // ignore navigation or other buttons (such as the Save button)
                    if (string.Equals(b.Name, "buttonSave", StringComparison.OrdinalIgnoreCase))
                        continue;

                    b.Click += PreferenceButtonClick;
                }
            }
        }

        

        private void PreferenceButtonClick(object? sender, EventArgs e)
        {
            if (!(sender is Button btn))
                return;

            try
            {
                // find the nearest label above the button to determine the question (preference key)
                Label nearest = null;
                int maxY = int.MinValue;
                foreach (Control c in this.Controls)
                {
                    if (c is Label lab)
                    {
                        if (lab.Location.Y < btn.Location.Y && lab.Location.Y > maxY)
                        {
                            maxY = lab.Location.Y;
                            nearest = lab;
                        }
                    }
                }

                var key = nearest?.Text ?? "Unknown";
                var value = btn.Text;

                // store selection in memory and update UI states
                _selections[key] = value;

                // visually mark selected button and clear peers
                foreach (Control c in this.Controls)
                {
                    if (c is Button other && other != null && !string.Equals(other.Name, "buttonSave", StringComparison.OrdinalIgnoreCase))
                    {
                        // find nearest label for the other button
                        Label otherNearest = null;
                        int otherMaxY = int.MinValue;
                        foreach (Control cc in this.Controls)
                        {
                            if (cc is Label lab)
                            {
                                if (lab.Location.Y < other.Location.Y && lab.Location.Y > otherMaxY)
                                {
                                    otherMaxY = lab.Location.Y;
                                    otherNearest = lab;
                                }
                            }
                        }

                        if (otherNearest != null && string.Equals(otherNearest.Text, key, StringComparison.OrdinalIgnoreCase))
                        {
                            other.BackColor = SystemColors.Control;
                        }
                    }
                }
                btn.BackColor = Color.LightBlue;

                // require username
                if (string.IsNullOrEmpty(_username))
                {
                    Debug.WriteLine("Preferences: no username provided; cannot save preference.");
                    return;
                }

                // Save is deferred until the Save button is clicked. Indicate in debug
                Debug.WriteLine($"Staged preference for {_username}: {key} = {value}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Saving preference failed: {ex.Message}");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelSaveError.Text = string.Empty;
            // check required keys
            var missing = new List<string>();
            foreach (var key in _requiredKeys)
            {
                if (!_selections.ContainsKey(key) || string.IsNullOrWhiteSpace(_selections[key]))
                    missing.Add(key);
            }

            if (missing.Count > 0)
            {
                labelSaveError.Text = "Please select a choice for: " + string.Join(", ", missing);
                return;
            }

            if (string.IsNullOrEmpty(_username))
            {
                labelSaveError.Text = "No username provided; cannot save preferences.";
                return;
            }

            try
            {
                // persist all selections
                foreach (var kv in _selections)
                {
                    // only save allowed keys
                    if (Array.Exists(_requiredKeys, k => string.Equals(k, kv.Key, StringComparison.OrdinalIgnoreCase)))
                    {
                        DataAccess.SavePreferenceColumn(_connectionString, _username, kv.Key, kv.Value);
                    }
                }

                using var f = new PreferencesSavedForm();
                f.ShowDialog(this);
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Saving all preferences failed: {ex.Message}");
                labelSaveError.Text = "Saving preferences failed.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
