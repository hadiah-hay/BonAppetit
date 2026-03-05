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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblError = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(0, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Click += lblUsername_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(0, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(100, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(0, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 27);
            txtPassword.TabIndex = 3;
            // 
            // lblError
            // 
            lblError.Location = new Point(0, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(100, 23);
            lblError.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Click += BtnLogin_Click;
            // 
            // LoginForm
            // 
            ClientSize = new Size(360, 160);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblError);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Log in";
            ResumeLayout(false);
            PerformLayout();
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

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
