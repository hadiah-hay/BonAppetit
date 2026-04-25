namespace Bon
{
    partial class preferences
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainFlow = new FlowLayoutPanel();
            headerPanel = new Panel();
            headerTitle = new Label();
            headerSubtitle = new Label();
            title = new Label();
            labelSaveError = new Label();
            buttonSave = new Button();

            mainFlow.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();

            // ── FORM ────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 233, 250);
            ClientSize = new Size(560, 720);
            Controls.Add(mainFlow);
            Name = "preferences";
            Text = "Preferences";
            Load += preferences_Load;

            // ── MAIN SCROLL PANEL ───────────────────────────────────
            mainFlow.AutoScroll = true;
            mainFlow.BackColor = Color.White;
            mainFlow.Dock = DockStyle.Fill;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Name = "mainFlow";
            mainFlow.Padding = new Padding(0);
            mainFlow.Size = new Size(560, 720);
            mainFlow.TabIndex = 0;
            mainFlow.WrapContents = false;

            // ── PURPLE HEADER PANEL ─────────────────────────────────
            headerPanel.BackColor = Color.FromArgb(120, 80, 200);
            headerPanel.Size = new Size(560, 90);
            headerPanel.Margin = new Padding(0, 0, 0, 0);
            headerPanel.Controls.Add(headerTitle);
            headerPanel.Controls.Add(headerSubtitle);

            // Header title
            headerTitle.AutoSize = true;
            headerTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            headerTitle.ForeColor = Color.White;
            headerTitle.Location = new Point(25, 18);
            headerTitle.Text = "Preferences";

            // Header subtitle
            headerSubtitle.AutoSize = true;
            headerSubtitle.Font = new Font("Segoe UI", 9F);
            headerSubtitle.ForeColor = Color.FromArgb(220, 210, 255);
            headerSubtitle.Location = new Point(25, 52);
            headerSubtitle.Text = "Share your emotional wellness insights";

            mainFlow.Controls.Add(headerPanel);

            // ── "How often do you feel:" label ──────────────────────
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 11F);
            title.ForeColor = Color.FromArgb(50, 50, 50);
            title.Margin = new Padding(25, 20, 0, 10);
            title.Name = "title";
            title.Text = "How often do you feel:";
            mainFlow.Controls.Add(title);

            // ── SAVE ERROR LABEL ────────────────────────────────────
            labelSaveError.AutoSize = true;
            labelSaveError.ForeColor = Color.Red;
            labelSaveError.Font = new Font("Segoe UI", 9F);
            labelSaveError.Margin = new Padding(25, 0, 0, 0);
            labelSaveError.Name = "labelSaveError";
            labelSaveError.Text = "";

            // ── SAVE BUTTON ─────────────────────────────────────────
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.BackColor = Color.FromArgb(120, 80, 200);
            buttonSave.ForeColor = Color.White;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.Margin = new Padding(25, 15, 0, 20);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(160, 40);
            buttonSave.Text = "Save Preferences";
            buttonSave.Click += buttonSave_Click;

            mainFlow.ResumeLayout(false);
            mainFlow.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        // ── BUILD BLOCK ─────────────────────────────────────────────
        private void BuildBlock(string emotion,
            out Button b1, out Button b2, out Button b3, out Button b4, out Button b5,
            out Panel cravingPanel, out Label cravingLabel,
            out Button sw, out Button so, out Button sp, out Button sa,
            EventHandler freqHandler)
        {
            // Outer card
            var card = new Panel();
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(25, 5, 25, 8);
            card.Size = new Size(500, 80);
            card.AutoSize = false;

            // Emotion label
            var emoLabel = new Label();
            emoLabel.AutoSize = true;
            emoLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            emoLabel.ForeColor = Color.FromArgb(40, 40, 40);
            emoLabel.Text = emotion;
            emoLabel.Location = new Point(15, 10);
            card.Controls.Add(emoLabel);

            // Frequency buttons row
            var freqRow = new FlowLayoutPanel();
            freqRow.AutoSize = true;
            freqRow.FlowDirection = FlowDirection.LeftToRight;
            freqRow.Location = new Point(10, 38);
            freqRow.Margin = new Padding(0);

            b1 = MakeFreqBtn("Never", freqHandler);
            b2 = MakeFreqBtn("Sometimes", freqHandler);
            b3 = MakeFreqBtn("Often", freqHandler);
            b4 = MakeFreqBtn("Frequently", freqHandler);
            b5 = MakeFreqBtn("Always", freqHandler);

            freqRow.Controls.Add(b1); freqRow.Controls.Add(b2);
            freqRow.Controls.Add(b3); freqRow.Controls.Add(b4);
            freqRow.Controls.Add(b5);
            card.Controls.Add(freqRow);
            mainFlow.Controls.Add(card);

            // Craving panel (hidden by default)
            cravingPanel = new Panel();
            cravingPanel.BackColor = Color.FromArgb(225, 230, 248);
            cravingPanel.BorderStyle = BorderStyle.None;
            cravingPanel.Visible = false;
            cravingPanel.Margin = new Padding(25, 0, 25, 8);
            cravingPanel.Size = new Size(500, 95);
            cravingPanel.AutoSize = false;

            cravingLabel = new Label();
            cravingLabel.AutoSize = true;
            cravingLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            cravingLabel.ForeColor = Color.FromArgb(60, 60, 80);
            cravingLabel.Text = $"What do you crave when you feel {emotion}?";
            cravingLabel.Location = new Point(12, 10);
            cravingPanel.Controls.Add(cravingLabel);

            sw = MakeCravingBtn("Sweet", 12, 40, CravingButtonClick);
            so = MakeCravingBtn("Sour", 122, 40, CravingButtonClick);
            sp = MakeCravingBtn("Spicy", 232, 40, CravingButtonClick);
            sa = MakeCravingBtn("Salty", 342, 40, CravingButtonClick);

            cravingPanel.Controls.Add(sw); cravingPanel.Controls.Add(so);
            cravingPanel.Controls.Add(sp); cravingPanel.Controls.Add(sa);
            mainFlow.Controls.Add(cravingPanel);
        }

        // ── FREQUENCY BUTTON FACTORY ────────────────────────────────
        private Button MakeFreqBtn(string text, EventHandler handler)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 8.5F);
            btn.Size = new Size(88, 30);
            btn.Margin = new Padding(0, 0, 6, 0);
            btn.UseVisualStyleBackColor = false;
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 185, 230);
            btn.FlatAppearance.BorderSize = 1;
            btn.ForeColor = Color.FromArgb(72, 52, 120);
            btn.Click += handler;
            return btn;
        }

        // ── CRAVING BUTTON FACTORY ──────────────────────────────────
        private Button MakeCravingBtn(string text, int x, int y, EventHandler handler)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 9F);
            btn.Size = new Size(100, 30);
            btn.Location = new Point(x, y);
            btn.UseVisualStyleBackColor = false;
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 185, 230);
            btn.FlatAppearance.BorderSize = 1;
            btn.ForeColor = Color.FromArgb(72, 52, 120);
            btn.Click += handler;
            return btn;
        }

        // ── FIELD DECLARATIONS ──────────────────────────────────────
        private FlowLayoutPanel mainFlow;
        private Panel headerPanel;
        private Label headerTitle;
        private Label headerSubtitle;
        private Label title;
        private Button buttonSave;
        private Label labelSaveError;

        private Button button1, button2, button3, button4, button5;
        private Button button6, button7, button8, button9, button10;
        private Button button11, button12, button13, button14, button15;
        private Button button16, button17, button18, button19, button20;
        private Button button21, button22, button23, button24, button25;

        private Panel happycraving; private Label happylabel;
        private Button sweet1, sour1, spicy1, salty1;
        private Panel sadcraving; private Label sadlabel;
        private Button sweet2, sour2, spicy2, salty2;
        private Panel angrypanel; private Label angrylabel;
        private Button sweet3, sour3, spicy3, salty3;
        private Panel boredpanel; private Label boredlabel;
        private Button sweet4, sour4, spicy4, salty4;
        private Panel stressedpanel; private Label stressedlabel;
        private Button sweet5, sour5, spicy5, salty5;
    }
}