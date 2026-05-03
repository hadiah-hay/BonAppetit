namespace Bon
{
    partial class Form2
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
            lblWellnessTitle = new Label();
            pnlDietCard = new Panel();
            lblDietFoods = new Label();
            lblDietTip = new Label();
            lblDietAnswer = new Label();
            lblDietTitle = new Label();
            lblSocialTip = new Label();
            lblSocialAnswer = new Label();
            pnlSocialCard = new Panel();
            lblSocialFoods = new Label();
            lblSocialTitle = new Label();
            pnlSleepCard = new Panel();
            lblSleepFoods = new Label();
            lblSleepTip = new Label();
            lblSleepAnswer = new Label();
            lblSleepTitle = new Label();
            pnlHydrationCard = new Panel();
            lblHydrationFoods = new Label();
            lblHydrationTip = new Label();
            lblHydrationAnswer = new Label();
            lblHydrationTitle = new Label();
            pnlDietCard.SuspendLayout();
            pnlSocialCard.SuspendLayout();
            pnlSleepCard.SuspendLayout();
            pnlHydrationCard.SuspendLayout();
            SuspendLayout();
            // 
            // lblWellnessTitle
            // 
            lblWellnessTitle.AutoSize = true;
            lblWellnessTitle.BackColor = Color.FromArgb(128, 0, 200);
            lblWellnessTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblWellnessTitle.ForeColor = Color.White;
            lblWellnessTitle.Location = new Point(12, 22);
            lblWellnessTitle.Name = "lblWellnessTitle";
            lblWellnessTitle.Size = new Size(219, 25);
            lblWellnessTitle.TabIndex = 9;
            lblWellnessTitle.Text = "Today's Wellness Guide";
            lblWellnessTitle.Click += lblWellnessTitle_Click;
            // 
            // pnlDietCard
            // 
            pnlDietCard.BackColor = Color.FromArgb(232, 253, 240);
            pnlDietCard.BorderStyle = BorderStyle.FixedSingle;
            pnlDietCard.Controls.Add(lblDietFoods);
            pnlDietCard.Controls.Add(lblDietTip);
            pnlDietCard.Controls.Add(lblDietAnswer);
            pnlDietCard.Controls.Add(lblDietTitle);
            pnlDietCard.Location = new Point(11, 203);
            pnlDietCard.Margin = new Padding(3, 2, 3, 2);
            pnlDietCard.Name = "pnlDietCard";
            pnlDietCard.Size = new Size(202, 128);
            pnlDietCard.TabIndex = 15;
            // 
            // lblDietFoods
            // 
            lblDietFoods.ForeColor = Color.Purple;
            lblDietFoods.Location = new Point(7, 75);
            lblDietFoods.Name = "lblDietFoods";
            lblDietFoods.Size = new Size(184, 45);
            lblDietFoods.TabIndex = 3;
            lblDietFoods.Text = "label16";
            // 
            // lblDietTip
            // 
            lblDietTip.Location = new Point(7, 44);
            lblDietTip.Name = "lblDietTip";
            lblDietTip.Size = new Size(184, 30);
            lblDietTip.TabIndex = 2;
            lblDietTip.Text = "label15";
            // 
            // lblDietAnswer
            // 
            lblDietAnswer.AutoSize = true;
            lblDietAnswer.ForeColor = SystemColors.ControlDarkDark;
            lblDietAnswer.Location = new Point(7, 26);
            lblDietAnswer.Name = "lblDietAnswer";
            lblDietAnswer.Size = new Size(44, 15);
            lblDietAnswer.TabIndex = 1;
            lblDietAnswer.Text = "label14";
            // 
            // lblDietTitle
            // 
            lblDietTitle.AutoSize = true;
            lblDietTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDietTitle.Location = new Point(7, 6);
            lblDietTitle.Name = "lblDietTitle";
            lblDietTitle.Size = new Size(58, 19);
            lblDietTitle.TabIndex = 0;
            lblDietTitle.Text = "label13";
            // 
            // lblSocialTip
            // 
            lblSocialTip.Location = new Point(7, 44);
            lblSocialTip.Name = "lblSocialTip";
            lblSocialTip.Size = new Size(184, 30);
            lblSocialTip.TabIndex = 2;
            lblSocialTip.Text = "label19";
            // 
            // lblSocialAnswer
            // 
            lblSocialAnswer.AutoSize = true;
            lblSocialAnswer.ForeColor = SystemColors.ControlDarkDark;
            lblSocialAnswer.Location = new Point(7, 26);
            lblSocialAnswer.Name = "lblSocialAnswer";
            lblSocialAnswer.Size = new Size(44, 15);
            lblSocialAnswer.TabIndex = 1;
            lblSocialAnswer.Text = "label18";
            // 
            // pnlSocialCard
            // 
            pnlSocialCard.BackColor = Color.FromArgb(232, 240, 253);
            pnlSocialCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSocialCard.Controls.Add(lblSocialFoods);
            pnlSocialCard.Controls.Add(lblSocialTip);
            pnlSocialCard.Controls.Add(lblSocialAnswer);
            pnlSocialCard.Controls.Add(lblSocialTitle);
            pnlSocialCard.Location = new Point(221, 204);
            pnlSocialCard.Margin = new Padding(3, 2, 3, 2);
            pnlSocialCard.Name = "pnlSocialCard";
            pnlSocialCard.Size = new Size(202, 128);
            pnlSocialCard.TabIndex = 16;
            // 
            // lblSocialFoods
            // 
            lblSocialFoods.ForeColor = Color.Purple;
            lblSocialFoods.Location = new Point(7, 75);
            lblSocialFoods.Name = "lblSocialFoods";
            lblSocialFoods.Size = new Size(184, 45);
            lblSocialFoods.TabIndex = 3;
            lblSocialFoods.Text = "label20";
            // 
            // lblSocialTitle
            // 
            lblSocialTitle.AutoSize = true;
            lblSocialTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSocialTitle.Location = new Point(7, 6);
            lblSocialTitle.Name = "lblSocialTitle";
            lblSocialTitle.Size = new Size(58, 19);
            lblSocialTitle.TabIndex = 0;
            lblSocialTitle.Text = "label17";
            lblSocialTitle.Click += lblSocialTitle_Click;
            // 
            // pnlSleepCard
            // 
            pnlSleepCard.BackColor = Color.FromArgb(243, 232, 253);
            pnlSleepCard.BorderStyle = BorderStyle.FixedSingle;
            pnlSleepCard.Controls.Add(lblSleepFoods);
            pnlSleepCard.Controls.Add(lblSleepTip);
            pnlSleepCard.Controls.Add(lblSleepAnswer);
            pnlSleepCard.Controls.Add(lblSleepTitle);
            pnlSleepCard.Location = new Point(221, 66);
            pnlSleepCard.Margin = new Padding(3, 2, 3, 2);
            pnlSleepCard.Name = "pnlSleepCard";
            pnlSleepCard.Size = new Size(202, 128);
            pnlSleepCard.TabIndex = 14;
            // 
            // lblSleepFoods
            // 
            lblSleepFoods.ForeColor = Color.Purple;
            lblSleepFoods.Location = new Point(7, 75);
            lblSleepFoods.Name = "lblSleepFoods";
            lblSleepFoods.Size = new Size(184, 45);
            lblSleepFoods.TabIndex = 3;
            lblSleepFoods.Text = "label12";
            // 
            // lblSleepTip
            // 
            lblSleepTip.Location = new Point(7, 44);
            lblSleepTip.Name = "lblSleepTip";
            lblSleepTip.Size = new Size(184, 30);
            lblSleepTip.TabIndex = 2;
            lblSleepTip.Text = "label11";
            // 
            // lblSleepAnswer
            // 
            lblSleepAnswer.AutoSize = true;
            lblSleepAnswer.ForeColor = SystemColors.ControlDarkDark;
            lblSleepAnswer.Location = new Point(7, 26);
            lblSleepAnswer.Name = "lblSleepAnswer";
            lblSleepAnswer.Size = new Size(44, 15);
            lblSleepAnswer.TabIndex = 1;
            lblSleepAnswer.Text = "label10";
            // 
            // lblSleepTitle
            // 
            lblSleepTitle.AutoSize = true;
            lblSleepTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSleepTitle.Location = new Point(7, 6);
            lblSleepTitle.Name = "lblSleepTitle";
            lblSleepTitle.Size = new Size(50, 19);
            lblSleepTitle.TabIndex = 0;
            lblSleepTitle.Text = "label9";
            lblSleepTitle.Click += lblSleepTitle_Click;
            // 
            // pnlHydrationCard
            // 
            pnlHydrationCard.BackColor = Color.FromArgb(232, 245, 253);
            pnlHydrationCard.BorderStyle = BorderStyle.FixedSingle;
            pnlHydrationCard.Controls.Add(lblHydrationFoods);
            pnlHydrationCard.Controls.Add(lblHydrationTip);
            pnlHydrationCard.Controls.Add(lblHydrationAnswer);
            pnlHydrationCard.Controls.Add(lblHydrationTitle);
            pnlHydrationCard.Location = new Point(12, 66);
            pnlHydrationCard.Margin = new Padding(3, 2, 3, 2);
            pnlHydrationCard.Name = "pnlHydrationCard";
            pnlHydrationCard.Size = new Size(202, 128);
            pnlHydrationCard.TabIndex = 13;
            // 
            // lblHydrationFoods
            // 
            lblHydrationFoods.ForeColor = Color.Purple;
            lblHydrationFoods.Location = new Point(7, 75);
            lblHydrationFoods.Name = "lblHydrationFoods";
            lblHydrationFoods.Size = new Size(184, 45);
            lblHydrationFoods.TabIndex = 3;
            lblHydrationFoods.Text = "label8";
            // 
            // lblHydrationTip
            // 
            lblHydrationTip.Location = new Point(7, 44);
            lblHydrationTip.Name = "lblHydrationTip";
            lblHydrationTip.Size = new Size(184, 30);
            lblHydrationTip.TabIndex = 2;
            lblHydrationTip.Text = "label7";
            // 
            // lblHydrationAnswer
            // 
            lblHydrationAnswer.AutoSize = true;
            lblHydrationAnswer.ForeColor = SystemColors.ControlDarkDark;
            lblHydrationAnswer.Location = new Point(7, 26);
            lblHydrationAnswer.Name = "lblHydrationAnswer";
            lblHydrationAnswer.Size = new Size(38, 15);
            lblHydrationAnswer.TabIndex = 1;
            lblHydrationAnswer.Text = "label6";
            // 
            // lblHydrationTitle
            // 
            lblHydrationTitle.AutoSize = true;
            lblHydrationTitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHydrationTitle.Location = new Point(7, 6);
            lblHydrationTitle.Name = "lblHydrationTitle";
            lblHydrationTitle.Size = new Size(50, 19);
            lblHydrationTitle.TabIndex = 0;
            lblHydrationTitle.Text = "label5";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 343);
            Controls.Add(pnlDietCard);
            Controls.Add(pnlSocialCard);
            Controls.Add(pnlSleepCard);
            Controls.Add(pnlHydrationCard);
            Controls.Add(lblWellnessTitle);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            pnlDietCard.ResumeLayout(false);
            pnlDietCard.PerformLayout();
            pnlSocialCard.ResumeLayout(false);
            pnlSocialCard.PerformLayout();
            pnlSleepCard.ResumeLayout(false);
            pnlSleepCard.PerformLayout();
            pnlHydrationCard.ResumeLayout(false);
            pnlHydrationCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWellnessTitle;
        private Panel pnlDietCard;
        private Label lblDietFoods;
        private Label lblDietTip;
        private Label lblDietAnswer;
        private Label lblDietTitle;
        private Label lblSocialTip;
        private Label lblSocialAnswer;
        private Panel pnlSocialCard;
        private Label lblSocialFoods;
        private Label lblSocialTitle;
        private Panel pnlSleepCard;
        private Label lblSleepFoods;
        private Label lblSleepTip;
        private Label lblSleepAnswer;
        private Label lblSleepTitle;
        private Panel pnlHydrationCard;
        private Label lblHydrationFoods;
        private Label lblHydrationTip;
        private Label lblHydrationAnswer;
        private Label lblHydrationTitle;
    }
}