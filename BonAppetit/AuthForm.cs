using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

namespace Bon
{
    public partial class AuthForm : Form
    {
        private bool isLoginMode = true;
        private readonly string connectionString =
    $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Bon.accdb";

        public AuthForm()
        {
            InitializeComponent();
            ApplyLayout();


            // Start in login mode
            lblEmail.Visible = false;
            txtEmail.Visible = false;
        }

        // Gradient Button
        private void BtnContinue_Paint(object sender, PaintEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                btn.ClientRectangle,
                Color.FromArgb(186, 142, 255),
                Color.FromArgb(140, 180, 255),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, btn.ClientRectangle);
            }

            TextRenderer.DrawText(
                e.Graphics,
                btn.Text,
                btn.Font,
                btn.ClientRectangle,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void LinkSwitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isLoginMode = !isLoginMode;

            btnContinue.Text = isLoginMode ? "Login →" : "Register →";
            linkSwitch.Text = isLoginMode? "Don't have an account? Register": "Already have an account? Login";

            ApplyLayout();
            btnContinue.Invalidate();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                (!isLoginMode && string.IsNullOrWhiteSpace(txtEmail.Text)))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            if (isLoginMode)
            {
                // Existing user logging in: only ask their mood (FoodPrefernces)
                if (LoginUser(txtUsername.Text, txtPassword.Text))
                {
                    using var f = new FoodPrefernces(txtUsername.Text);
                    this.Hide();
                    f.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
            else
            {
                // New user registering: require filling preferences
                if (RegisterUser(txtUsername.Text, txtEmail.Text, txtPassword.Text))
                {
                    using var pref = new preferences(txtUsername.Text);
                    this.Hide();
                    pref.ShowDialog(this);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed.");
                }
            }
        }

        private void OpenMainForm()
        {
            preferences pref = new preferences(txtUsername.Text);
            this.Hide();
            pref.ShowDialog(this);
            this.Close();
        }

        private bool LoginUser(string username, string password)
        {
            var dt = DataAccess.GetUser(connectionString, username);
            if (dt.Rows.Count == 0) return false;

            var stored = dt.Rows[0]["Password"]?.ToString() ?? "";
            return stored == password;
        }

        private bool RegisterUser(string username, string email, string password)
        {
            if (DataAccess.UserExists(connectionString, username))
            {
                MessageBox.Show("Username already exists.");
                return false;
            }

            return DataAccess.InsertUser(connectionString, username, email, password) > 0;
        }
        private void ApplyLayout()
        {
            if (isLoginMode)
            {
                lblEmail.Visible = false;
                txtEmail.Visible = false;

                lblPassword.Location = new Point(45, 150);
                txtPassword.Location = new Point(45, 170);
                btnContinue.Location = new Point(45, 200);
                linkSwitch.Location = new Point(75, 240);
            }
            else
            {
                lblEmail.Visible = true;
                txtEmail.Visible = true;

                lblPassword.Location = new Point(45, 190);
                txtPassword.Location = new Point(45, 205);
                btnContinue.Location = new Point(45, 245);
                linkSwitch.Location = new Point(75, 280);
            }
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
