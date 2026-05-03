namespace Bon
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnContinue = new Button();
            linkSwitch = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(31, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome to BonAppetit";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(52, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(211, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Start your journey to better wellness ✨";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(44, 98);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(44, 120);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(263, 23);
            txtUsername.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(44, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(44, 165);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(44, 195);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(44, 210);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(263, 23);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnContinue
            // 
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(44, 248);
            btnContinue.Margin = new Padding(3, 2, 3, 2);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(262, 34);
            btnContinue.TabIndex = 8;
            btnContinue.Text = "Login →";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += BtnContinue_Click;
            btnContinue.Paint += BtnContinue_Paint;
            // 
            // linkSwitch
            // 
            linkSwitch.AutoSize = true;
            linkSwitch.Location = new Point(79, 292);
            linkSwitch.Name = "linkSwitch";
            linkSwitch.Size = new Size(176, 15);
            linkSwitch.TabIndex = 9;
            linkSwitch.TabStop = true;
            linkSwitch.Text = "Don't have an account? Register";
            linkSwitch.LinkClicked += LinkSwitch_LinkClicked;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 225, 240);
            ClientSize = new Size(351, 418);
            Controls.Add(linkSwitch);
            Controls.Add(btnContinue);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AuthForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome ";
            Load += AuthForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnContinue;
        private LinkLabel linkSwitch;
    }
}