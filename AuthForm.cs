using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data;

namespace Bon
{
    public partial class AuthForm : Form
    {
        private bool isLoginMode = true;
        private readonly string connectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Bon.accdb";

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
            Button btn = sender as Button;

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
            linkSwitch.Text = isLoginMode
                ? "Don't have an account? Register"
                : "Already have an account? Login";

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
                if (LoginUser(txtUsername.Text, txtPassword.Text))
                    OpenMainForm();
                else
                    MessageBox.Show("Invalid credentials.");
            }
            else
            {
                if (RegisterUser(txtUsername.Text, txtEmail.Text, txtPassword.Text))
                {
                    MessageBox.Show("Registration successful!");
                    LinkSwitch_LinkClicked(null, null);
                }
                else
                    MessageBox.Show("Registration failed.");
            }
        }

        private void OpenMainForm()
        {
            using (var f = new Form1())
            {
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
        }
        //first project upload

        // uploading project to github

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

                lblPassword.Location = new Point(50, 190);
                txtPassword.Location = new Point(50, 210);
                btnContinue.Location = new Point(50, 260);
                linkSwitch.Location = new Point(90, 320);
            }
            else
            {
                lblEmail.Visible = true;
                txtEmail.Visible = true;

                lblPassword.Location = new Point(50, 250);
                txtPassword.Location = new Point(50, 270);
                btnContinue.Location = new Point(50, 320);
                linkSwitch.Location = new Point(90, 380);
            }
        }
    }
}
