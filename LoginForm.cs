using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bon
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblUsername;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblError;

        private readonly string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\Bon.accdb";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Log in";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(360, 160);

            lblUsername = new Label { Text = "Username:", Location = new Point(20, 20), AutoSize = true };
            txtUsername = new TextBox { Location = new Point(110, 16), Width = 220 };

            lblPassword = new Label { Text = "Password:", Location = new Point(20, 56), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(110, 52), Width = 220, PasswordChar = '*' };

            lblError = new Label { ForeColor = Color.Red, Location = new Point(20, 88), AutoSize = true };

            btnLogin = new Button { Text = "Log in", Location = new Point(110, 110), Size = new Size(90, 28) };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, lblError, btnLogin });
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter username and password.";
                return;
            }

            try
            {
                var dt = DataAccess.GetUser(connectionString, username);
                if (dt.Rows.Count == 0)
                {
                    lblError.Text = "Invalid username or password.";
                    return;
                }

                var stored = dt.Rows[0]["Password"]?.ToString() ?? string.Empty;
                if (stored == password)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error checking credentials.";
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
        }
    }
}
