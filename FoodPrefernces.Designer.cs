namespace Bon
{
    partial class FoodPrefernces
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
            radioButton5 = new RadioButton();
            pnlEmotions = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            pnlFood3 = new Panel();
            label7 = new Label();
            lblFood3Desc = new Label();
            lblFood3Name = new Label();
            pnlFood2 = new Panel();
            label6 = new Label();
            lblFood2Desc = new Label();
            lblFood2Name = new Label();
            pnlFood1 = new Panel();
            label5 = new Label();
            lblFood1Desc = new Label();
            lblFood1Name = new Label();
            lblRecommended = new Label();
            pnlEmotionCard = new Panel();
            lblEmotionName = new Label();
            lblEmotionEmoji = new Label();
            pnlHeader = new Panel();
            label1 = new Label();
            lblSubtitle = new Label();
            lblFoodGuide = new Label();
            btnBack = new Button();
            tlpEmotions = new TableLayoutPanel();
            pnlHappy = new Panel();
            lblNameHappy = new Label();
            lblEmojiHappy = new Label();
            pnlSad = new Panel();
            lblNameSad = new Label();
            lblEmojiSad = new Label();
            pnlAngry = new Panel();
            lblNameAngry = new Label();
            lblEmojiAngry = new Label();
            pnlStressed = new Panel();
            lblEmojiStressed = new Label();
            lblEmojiStrssed = new Label();
            pnlBored = new Panel();
            lblNameBored = new Label();
            lblEmojiBored = new Label();
            panel6 = new Panel();
            lblTitle = new Label();
            button1 = new Button();
            pnlEmotions.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlFood3.SuspendLayout();
            pnlFood2.SuspendLayout();
            pnlFood1.SuspendLayout();
            pnlEmotionCard.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpEmotions.SuspendLayout();
            pnlHappy.SuspendLayout();
            pnlSad.SuspendLayout();
            pnlAngry.SuspendLayout();
            pnlStressed.SuspendLayout();
            pnlBored.SuspendLayout();
            SuspendLayout();
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(-326, 154);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(56, 19);
            radioButton5.TabIndex = 10;
            radioButton5.TabStop = true;
            radioButton5.Text = "Sweet";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // pnlEmotions
            // 
            pnlEmotions.Controls.Add(panel1);
            pnlEmotions.Controls.Add(tlpEmotions);
            pnlEmotions.Controls.Add(lblTitle);
            pnlEmotions.Dock = DockStyle.Fill;
            pnlEmotions.Location = new Point(0, 0);
            pnlEmotions.Margin = new Padding(3, 2, 3, 2);
            pnlEmotions.Name = "pnlEmotions";
            pnlEmotions.Size = new Size(424, 489);
            pnlEmotions.TabIndex = 28;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pnlFood3);
            panel1.Controls.Add(pnlFood2);
            panel1.Controls.Add(pnlFood1);
            panel1.Controls.Add(lblRecommended);
            panel1.Controls.Add(pnlEmotionCard);
            panel1.Controls.Add(pnlHeader);
            panel1.Controls.Add(btnBack);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(2);
            panel1.Size = new Size(424, 489);
            panel1.TabIndex = 2;
            panel1.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 240, 255);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(18, 379);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(385, 52);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 20);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 4);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 0;
            label4.Text = "label4";
            label4.Click += label4_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(128, 0, 200);
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 350);
            label2.Name = "label2";
            label2.Size = new Size(159, 25);
            label2.TabIndex = 7;
            label2.Text = "Your Personality";
            label2.Click += label2_Click;
            // 
            // pnlFood3
            // 
            pnlFood3.BackColor = Color.FromArgb(232, 240, 253);
            pnlFood3.BorderStyle = BorderStyle.FixedSingle;
            pnlFood3.Controls.Add(label7);
            pnlFood3.Controls.Add(lblFood3Desc);
            pnlFood3.Controls.Add(lblFood3Name);
            pnlFood3.Location = new Point(18, 293);
            pnlFood3.Margin = new Padding(3, 2, 3, 2);
            pnlFood3.Name = "pnlFood3";
            pnlFood3.Size = new Size(385, 52);
            pnlFood3.TabIndex = 6;
            pnlFood3.Paint += pnlFood3_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(7, 7);
            label7.Name = "label7";
            label7.Size = new Size(21, 19);
            label7.TabIndex = 4;
            label7.Text = "3.";
            // 
            // lblFood3Desc
            // 
            lblFood3Desc.AutoSize = true;
            lblFood3Desc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFood3Desc.ForeColor = Color.Gray;
            lblFood3Desc.Location = new Point(39, 26);
            lblFood3Desc.Name = "lblFood3Desc";
            lblFood3Desc.Size = new Size(38, 15);
            lblFood3Desc.TabIndex = 1;
            lblFood3Desc.Text = "label3";
            // 
            // lblFood3Name
            // 
            lblFood3Name.AutoSize = true;
            lblFood3Name.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFood3Name.Location = new Point(32, 8);
            lblFood3Name.Name = "lblFood3Name";
            lblFood3Name.Size = new Size(50, 19);
            lblFood3Name.TabIndex = 0;
            lblFood3Name.Text = "label4";
            lblFood3Name.Click += lblFood3Name_Click;
            // 
            // pnlFood2
            // 
            pnlFood2.BackColor = Color.FromArgb(232, 253, 240);
            pnlFood2.BorderStyle = BorderStyle.FixedSingle;
            pnlFood2.Controls.Add(label6);
            pnlFood2.Controls.Add(lblFood2Desc);
            pnlFood2.Controls.Add(lblFood2Name);
            pnlFood2.Location = new Point(18, 237);
            pnlFood2.Margin = new Padding(3, 2, 3, 2);
            pnlFood2.Name = "pnlFood2";
            pnlFood2.Size = new Size(385, 52);
            pnlFood2.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(5, 7);
            label6.Name = "label6";
            label6.Size = new Size(21, 19);
            label6.TabIndex = 3;
            label6.Text = "2.";
            // 
            // lblFood2Desc
            // 
            lblFood2Desc.AutoSize = true;
            lblFood2Desc.ForeColor = Color.Gray;
            lblFood2Desc.Location = new Point(35, 25);
            lblFood2Desc.Name = "lblFood2Desc";
            lblFood2Desc.Size = new Size(38, 15);
            lblFood2Desc.TabIndex = 1;
            lblFood2Desc.Text = "label2";
            lblFood2Desc.Click += lblFood2Desc_Click;
            // 
            // lblFood2Name
            // 
            lblFood2Name.AutoSize = true;
            lblFood2Name.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFood2Name.Location = new Point(30, 7);
            lblFood2Name.Name = "lblFood2Name";
            lblFood2Name.Size = new Size(50, 19);
            lblFood2Name.TabIndex = 0;
            lblFood2Name.Text = "label3";
            lblFood2Name.Click += lblFood2Name_Click;
            // 
            // pnlFood1
            // 
            pnlFood1.BackColor = Color.FromArgb(243, 232, 253);
            pnlFood1.BorderStyle = BorderStyle.FixedSingle;
            pnlFood1.Controls.Add(label5);
            pnlFood1.Controls.Add(lblFood1Desc);
            pnlFood1.Controls.Add(lblFood1Name);
            pnlFood1.Location = new Point(18, 181);
            pnlFood1.Margin = new Padding(3, 2, 3, 2);
            pnlFood1.Name = "pnlFood1";
            pnlFood1.Size = new Size(385, 52);
            pnlFood1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 7);
            label5.Name = "label5";
            label5.Size = new Size(21, 19);
            label5.TabIndex = 2;
            label5.Text = "1.";
            // 
            // lblFood1Desc
            // 
            lblFood1Desc.AutoSize = true;
            lblFood1Desc.ForeColor = Color.Gray;
            lblFood1Desc.Location = new Point(38, 23);
            lblFood1Desc.Name = "lblFood1Desc";
            lblFood1Desc.Size = new Size(38, 15);
            lblFood1Desc.TabIndex = 1;
            lblFood1Desc.Text = "label2";
            // 
            // lblFood1Name
            // 
            lblFood1Name.AutoSize = true;
            lblFood1Name.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFood1Name.Location = new Point(30, 7);
            lblFood1Name.Name = "lblFood1Name";
            lblFood1Name.Size = new Size(50, 19);
            lblFood1Name.TabIndex = 0;
            lblFood1Name.Text = "label2";
            // 
            // lblRecommended
            // 
            lblRecommended.AutoSize = true;
            lblRecommended.BackColor = Color.FromArgb(128, 0, 200);
            lblRecommended.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRecommended.ForeColor = Color.White;
            lblRecommended.Location = new Point(10, 154);
            lblRecommended.Name = "lblRecommended";
            lblRecommended.Size = new Size(132, 25);
            lblRecommended.TabIndex = 3;
            lblRecommended.Text = "Craving Picks";
            lblRecommended.Click += lblRecommended_Click;
            // 
            // pnlEmotionCard
            // 
            pnlEmotionCard.BackColor = Color.FromArgb(245, 240, 255);
            pnlEmotionCard.BorderStyle = BorderStyle.FixedSingle;
            pnlEmotionCard.Controls.Add(lblEmotionName);
            pnlEmotionCard.Controls.Add(lblEmotionEmoji);
            pnlEmotionCard.Location = new Point(18, 100);
            pnlEmotionCard.Margin = new Padding(3, 2, 3, 2);
            pnlEmotionCard.Name = "pnlEmotionCard";
            pnlEmotionCard.Size = new Size(385, 48);
            pnlEmotionCard.TabIndex = 2;
            // 
            // lblEmotionName
            // 
            lblEmotionName.AutoSize = true;
            lblEmotionName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmotionName.Location = new Point(86, 9);
            lblEmotionName.Name = "lblEmotionName";
            lblEmotionName.Size = new Size(65, 25);
            lblEmotionName.TabIndex = 1;
            lblEmotionName.Text = "label2";
            lblEmotionName.Click += lblEmotionName_Click;
            // 
            // lblEmotionEmoji
            // 
            lblEmotionEmoji.AutoSize = true;
            lblEmotionEmoji.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmotionEmoji.Location = new Point(14, 9);
            lblEmotionEmoji.Name = "lblEmotionEmoji";
            lblEmotionEmoji.Size = new Size(63, 25);
            lblEmotionEmoji.TabIndex = 0;
            lblEmotionEmoji.Text = "label2";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(128, 0, 200);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblFoodGuide);
            pnlHeader.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlHeader.Location = new Point(0, 34);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(422, 60);
            pnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 36);
            label1.Name = "label1";
            label1.Size = new Size(182, 19);
            label1.TabIndex = 2;
            label1.Text = "Personalized for your mood";
            label1.Click += label1_Click_1;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(38, 28);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(0, 19);
            lblSubtitle.TabIndex = 1;
            // 
            // lblFoodGuide
            // 
            lblFoodGuide.AutoSize = true;
            lblFoodGuide.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFoodGuide.ForeColor = Color.White;
            lblFoodGuide.Location = new Point(3, 7);
            lblFoodGuide.Name = "lblFoodGuide";
            lblFoodGuide.Size = new Size(183, 30);
            lblFoodGuide.TabIndex = 0;
            lblFoodGuide.Text = "Your Food Guide";
            lblFoodGuide.Click += lblFoodGuide_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.DimGray;
            btnBack.Location = new Point(9, 8);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(70, 22);
            btnBack.TabIndex = 0;
            btnBack.Text = "<-- Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // tlpEmotions
            // 
            tlpEmotions.ColumnCount = 2;
            tlpEmotions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEmotions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEmotions.Controls.Add(pnlHappy, 0, 0);
            tlpEmotions.Controls.Add(pnlSad, 1, 0);
            tlpEmotions.Controls.Add(pnlAngry, 0, 1);
            tlpEmotions.Controls.Add(pnlStressed, 1, 1);
            tlpEmotions.Controls.Add(pnlBored, 0, 2);
            tlpEmotions.Controls.Add(panel6, 1, 2);
            tlpEmotions.Location = new Point(18, 52);
            tlpEmotions.Margin = new Padding(3, 2, 3, 2);
            tlpEmotions.Name = "tlpEmotions";
            tlpEmotions.RowCount = 3;
            tlpEmotions.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpEmotions.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpEmotions.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpEmotions.Size = new Size(394, 375);
            tlpEmotions.TabIndex = 1;
            tlpEmotions.Paint += tlpEmotions_Paint;
            // 
            // pnlHappy
            // 
            pnlHappy.BackColor = Color.FromArgb(255, 224, 130);
            pnlHappy.Controls.Add(lblNameHappy);
            pnlHappy.Controls.Add(lblEmojiHappy);
            pnlHappy.Dock = DockStyle.Fill;
            pnlHappy.Location = new Point(3, 2);
            pnlHappy.Margin = new Padding(3, 2, 3, 2);
            pnlHappy.Name = "pnlHappy";
            pnlHappy.Size = new Size(191, 121);
            pnlHappy.TabIndex = 0;
            // 
            // lblNameHappy
            // 
            lblNameHappy.AutoSize = true;
            lblNameHappy.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameHappy.Location = new Point(61, 79);
            lblNameHappy.Name = "lblNameHappy";
            lblNameHappy.Size = new Size(54, 20);
            lblNameHappy.TabIndex = 1;
            lblNameHappy.Text = "Happy";
            // 
            // lblEmojiHappy
            // 
            lblEmojiHappy.AutoSize = true;
            lblEmojiHappy.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmojiHappy.Location = new Point(44, 15);
            lblEmojiHappy.Name = "lblEmojiHappy";
            lblEmojiHappy.Size = new Size(94, 65);
            lblEmojiHappy.TabIndex = 0;
            lblEmojiHappy.Text = "😊";
            lblEmojiHappy.Click += lblEmojiHappy_Click;
            // 
            // pnlSad
            // 
            pnlSad.BackColor = Color.FromArgb(144, 202, 249);
            pnlSad.Controls.Add(lblNameSad);
            pnlSad.Controls.Add(lblEmojiSad);
            pnlSad.Dock = DockStyle.Fill;
            pnlSad.Location = new Point(200, 2);
            pnlSad.Margin = new Padding(3, 2, 3, 2);
            pnlSad.Name = "pnlSad";
            pnlSad.Size = new Size(191, 121);
            pnlSad.TabIndex = 1;
            // 
            // lblNameSad
            // 
            lblNameSad.AutoSize = true;
            lblNameSad.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameSad.Location = new Point(74, 79);
            lblNameSad.Name = "lblNameSad";
            lblNameSad.Size = new Size(34, 20);
            lblNameSad.TabIndex = 1;
            lblNameSad.Text = "Sad";
            // 
            // lblEmojiSad
            // 
            lblEmojiSad.AutoSize = true;
            lblEmojiSad.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmojiSad.Location = new Point(44, 15);
            lblEmojiSad.Name = "lblEmojiSad";
            lblEmojiSad.Size = new Size(94, 65);
            lblEmojiSad.TabIndex = 0;
            lblEmojiSad.Text = "😢";
            // 
            // pnlAngry
            // 
            pnlAngry.BackColor = Color.FromArgb(239, 154, 154);
            pnlAngry.Controls.Add(lblNameAngry);
            pnlAngry.Controls.Add(lblEmojiAngry);
            pnlAngry.Dock = DockStyle.Fill;
            pnlAngry.Location = new Point(3, 127);
            pnlAngry.Margin = new Padding(3, 2, 3, 2);
            pnlAngry.Name = "pnlAngry";
            pnlAngry.Size = new Size(191, 121);
            pnlAngry.TabIndex = 2;
            // 
            // lblNameAngry
            // 
            lblNameAngry.AutoSize = true;
            lblNameAngry.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameAngry.Location = new Point(61, 76);
            lblNameAngry.Name = "lblNameAngry";
            lblNameAngry.Size = new Size(53, 20);
            lblNameAngry.TabIndex = 2;
            lblNameAngry.Text = "Angry";
            // 
            // lblEmojiAngry
            // 
            lblEmojiAngry.AutoSize = true;
            lblEmojiAngry.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmojiAngry.Location = new Point(44, 15);
            lblEmojiAngry.Name = "lblEmojiAngry";
            lblEmojiAngry.Size = new Size(94, 65);
            lblEmojiAngry.TabIndex = 1;
            lblEmojiAngry.Text = "😠";
            // 
            // pnlStressed
            // 
            pnlStressed.BackColor = Color.FromArgb(206, 147, 216);
            pnlStressed.Controls.Add(lblEmojiStressed);
            pnlStressed.Controls.Add(lblEmojiStrssed);
            pnlStressed.Dock = DockStyle.Fill;
            pnlStressed.Location = new Point(200, 127);
            pnlStressed.Margin = new Padding(3, 2, 3, 2);
            pnlStressed.Name = "pnlStressed";
            pnlStressed.Size = new Size(191, 121);
            pnlStressed.TabIndex = 3;
            // 
            // lblEmojiStressed
            // 
            lblEmojiStressed.AutoSize = true;
            lblEmojiStressed.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmojiStressed.Location = new Point(57, 75);
            lblEmojiStressed.Name = "lblEmojiStressed";
            lblEmojiStressed.Size = new Size(68, 20);
            lblEmojiStressed.TabIndex = 3;
            lblEmojiStressed.Text = "Stressed";
            // 
            // lblEmojiStrssed
            // 
            lblEmojiStrssed.AutoSize = true;
            lblEmojiStrssed.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmojiStrssed.Location = new Point(45, 15);
            lblEmojiStrssed.Name = "lblEmojiStrssed";
            lblEmojiStrssed.Size = new Size(94, 65);
            lblEmojiStrssed.TabIndex = 2;
            lblEmojiStrssed.Text = "😩";
            // 
            // pnlBored
            // 
            pnlBored.BackColor = Color.FromArgb(165, 214, 167);
            pnlBored.Controls.Add(lblNameBored);
            pnlBored.Controls.Add(lblEmojiBored);
            pnlBored.Dock = DockStyle.Fill;
            pnlBored.Location = new Point(3, 252);
            pnlBored.Margin = new Padding(3, 2, 3, 2);
            pnlBored.Name = "pnlBored";
            pnlBored.Size = new Size(191, 121);
            pnlBored.TabIndex = 4;
            // 
            // lblNameBored
            // 
            lblNameBored.AutoSize = true;
            lblNameBored.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNameBored.Location = new Point(66, 75);
            lblNameBored.Name = "lblNameBored";
            lblNameBored.Size = new Size(51, 20);
            lblNameBored.TabIndex = 4;
            lblNameBored.Text = "Bored";
            // 
            // lblEmojiBored
            // 
            lblEmojiBored.AutoSize = true;
            lblEmojiBored.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmojiBored.Location = new Point(44, 15);
            lblEmojiBored.Name = "lblEmojiBored";
            lblEmojiBored.Size = new Size(94, 65);
            lblEmojiBored.TabIndex = 3;
            lblEmojiBored.Text = "😴";
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(200, 252);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(191, 121);
            panel6.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(285, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "How do you feel today?";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.DimGray;
            button1.Location = new Point(333, 444);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(70, 22);
            button1.TabIndex = 8;
            button1.Text = "Next -->";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FoodPrefernces
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 489);
            Controls.Add(pnlEmotions);
            Controls.Add(radioButton5);
            Name = "FoodPrefernces";
            Text = "How do you feel today?";
            Load += FoodPrefernces_Load;
            pnlEmotions.ResumeLayout(false);
            pnlEmotions.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlFood3.ResumeLayout(false);
            pnlFood3.PerformLayout();
            pnlFood2.ResumeLayout(false);
            pnlFood2.PerformLayout();
            pnlFood1.ResumeLayout(false);
            pnlFood1.PerformLayout();
            pnlEmotionCard.ResumeLayout(false);
            pnlEmotionCard.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpEmotions.ResumeLayout(false);
            pnlHappy.ResumeLayout(false);
            pnlHappy.PerformLayout();
            pnlSad.ResumeLayout(false);
            pnlSad.PerformLayout();
            pnlAngry.ResumeLayout(false);
            pnlAngry.PerformLayout();
            pnlStressed.ResumeLayout(false);
            pnlStressed.PerformLayout();
            pnlBored.ResumeLayout(false);
            pnlBored.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton radioButton5;
        private Panel pnlEmotions;
        private Label lblTitle;
        private TableLayoutPanel tlpEmotions;
        private Panel pnlHappy;
        private Panel pnlSad;
        private Panel pnlAngry;
        private Panel pnlStressed;
        private Panel pnlBored;
        private Panel panel6;
        private Label lblNameHappy;
        private Label lblEmojiHappy;
        private Label lblNameSad;
        private Label lblEmojiSad;
        private Label lblEmojiAngry;
        private Label lblNameAngry;
        private Label lblEmojiStrssed;
        private Label lblEmojiStressed;
        private Label lblNameBored;
        private Label lblEmojiBored;
        private Panel panel1;
        private Panel pnlHeader;
        private Button btnBack;
        private Label lblRecommended;
        private Panel pnlEmotionCard;
        private Panel pnlFood3;
        private Panel pnlFood2;
        private Panel pnlFood1;
        private Label lblFoodGuide;
        private Label lblSubtitle;
        private Label label1;
        private Label lblFood3Name;
        private Label lblFood2Name;
        private Label lblFood1Name;
        private Label lblEmotionName;
        private Label lblEmotionEmoji;
        private Label lblFood3Desc;
        private Label lblFood2Desc;
        private Label lblFood1Desc;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button button1;
    }
}