using System;
using System.Windows.Forms;
using System.Drawing;

namespace Bon
{
    public class AuthForm : Form
    {
        private Button btnLogin;
        private Button btnSignUp;
        private Label labelTitle;

        public AuthForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            labelTitle = new Label();
            btnLogin = new Button();
            btnSignUp = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            labelTitle.Location = new Point(102, 28);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(211, 20);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Please choose an option:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(60, 80);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(120, 36);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Log in";
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(240, 80);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(120, 36);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "Sign up";
            btnSignUp.Click += BtnSignUp_Click;
            // 
            // AuthForm
            // 
            ClientSize = new Size(420, 180);
            Controls.Add(labelTitle);
            Controls.Add(btnLogin);
            Controls.Add(btnSignUp);
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            // Open a dedicated login dialog that asks for username and password
            using (var login = new LoginForm())
            {
                var result = login.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // authenticated - open main form
                    using (var f = new Form1())
                    {
                        this.Hide();
                        f.ShowDialog(this);
                        this.Show();
                    }
                }
                // otherwise stay on this form
            }
        }

        private void BtnSignUp_Click(object? sender, EventArgs e)
        {
            // Open Form1 in sign-up mode
            using (var f = new Form1(isSignupMode: true))
            {
                this.Hide();
                f.ShowDialog(this);
                if (f.PreferencesOpened)
                {
                    // user was moved to preferences; close auth form
                    this.Close();
                    return;
                }
                this.Show();
            }
        }
    }
}
