
namespace Bon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(324, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // labelUsernameError
            // 
            labelUsernameError = new Label();
            labelUsernameError.AutoSize = true;
            labelUsernameError.ForeColor = Color.Red;
            labelUsernameError.Location = new Point(324, 105);
            labelUsernameError.Name = "labelUsernameError";
            labelUsernameError.Size = new Size(0, 15);
            labelUsernameError.TabIndex = 8;
            labelUsernameError.Text = string.Empty;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(354, 34);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Login ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 83);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 122);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 3;
            label3.Text = "email ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(219, 159);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 4;
            label4.Text = "Password";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(324, 119);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // labelEmailError
            // 
            labelEmailError = new Label();
            labelEmailError.AutoSize = true;
            labelEmailError.ForeColor = Color.Red;
            labelEmailError.Location = new Point(324, 144);
            labelEmailError.Name = "labelEmailError";
            labelEmailError.Size = new Size(0, 15);
            labelEmailError.TabIndex = 9;
            labelEmailError.Text = string.Empty;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(324, 159);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // labelPasswordError
            // 
            labelPasswordError = new Label();
            labelPasswordError.AutoSize = true;
            labelPasswordError.ForeColor = Color.Red;
            labelPasswordError.Location = new Point(324, 184);
            labelPasswordError.Name = "labelPasswordError";
            labelPasswordError.Size = new Size(0, 15);
            labelPasswordError.TabIndex = 10;
            labelPasswordError.Text = string.Empty;
            // 
            // buttonSave
            // 
            buttonSave = new Button();
            buttonSave.Location = new Point(324, 200);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSave);
            Controls.Add(textBox3);
            Controls.Add(labelPasswordError);
            Controls.Add(textBox2);
            Controls.Add(labelEmailError);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(labelUsernameError);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button buttonSave;
        private Label labelUsernameError;
        private Label labelEmailError;
        private Label labelPasswordError;
    }
}
