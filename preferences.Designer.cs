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
            buttonSave = new Button();
            labelSaveError = new Label();
            mainFlow.SuspendLayout();
            SuspendLayout();

            // ── FLOW PANEL fills the form ──
            mainFlow.AutoScroll = true;
            mainFlow.Dock = DockStyle.Fill;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.WrapContents = false;
            mainFlow.Padding = new Padding(20, 10, 20, 10);
            mainFlow.Name = "mainFlow";

            // ── TITLE ──
            var title = new Label();
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 18F);
            title.Text = "How often do you feel:";
            title.Name = "label1";
            title.Margin = new Padding(0, 0, 0, 10);
            mainFlow.Controls.Add(title);
            label1 = title;

            // ── BUILD EACH EMOTION BLOCK ──
            BuildBlock("Happy", out button1, out button2, out button3, out button4, out button5,
                       out happycraving, out happylabel, out sweet1, out sour1, out spicy1, out salty1,
                       HappyFrequencySelected);

            BuildBlock("Sad", out button6, out button7, out button8, out button9, out button10,
                       out sadcraving, out sadlabel, out sweet2, out sour2, out spicy2, out salty2,
                       SadFrequencySelected);

            BuildBlock("Angry", out button11, out button12, out button13, out button14, out button15,
                       out angrypanel, out angrylabel, out sweet3, out sour3, out spicy3, out salty3,
                       AngryFrequencySelected);

            BuildBlock("Bored", out button16, out button17, out button18, out button19, out button20,
                       out boredpanel, out boredlabel, out sweet4, out sour4, out spicy4, out salty4,
                       BoredFrequencySelected);

            BuildBlock("Stressed", out button21, out button22, out button23, out button24, out button25,
                       out stressedpanel, out stressedlabel, out sweet5, out sour5, out spicy5, out salty5,
                       StressedFrequencySelected);

            // ── SAVE ──
            buttonSave.Text = "Save";
            buttonSave.Font = new Font("Microsoft Sans Serif", 9F);
            buttonSave.Size = new Size(120, 35);
            buttonSave.Margin = new Padding(0, 20, 0, 5);
            buttonSave.Click += buttonSave_Click;
            mainFlow.Controls.Add(buttonSave);

            labelSaveError.AutoSize = true;
            labelSaveError.ForeColor = Color.Red;
            labelSaveError.Text = "";
            labelSaveError.Name = "labelSaveError";
            mainFlow.Controls.Add(labelSaveError);

            mainFlow.ResumeLayout(false);

            // ── FORM ──
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(mainFlow);
            Name = "preferences";
            Text = "Preferences";
            Load += preferences_Load;
            ResumeLayout(false);
        }

        private void BuildBlock(string emotion,
            out Button b1, out Button b2, out Button b3, out Button b4, out Button b5,
            out Panel cravingPanel, out Label cravingLabel,
            out Button sw, out Button so, out Button sp, out Button sa,
            EventHandler freqHandler)
        {
            // Emotion label
            var emoLabel = new Label();
            emoLabel.AutoSize = true;
            emoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            emoLabel.Text = emotion;
            emoLabel.Margin = new Padding(0, 15, 0, 5);
            mainFlow.Controls.Add(emoLabel);

            // Frequency buttons row
            var freqPanel = new FlowLayoutPanel();
            freqPanel.AutoSize = true;
            freqPanel.FlowDirection = FlowDirection.LeftToRight;
            freqPanel.Margin = new Padding(0, 0, 0, 5);

            b1 = MakeFreqBtn("Never", freqHandler);
            b2 = MakeFreqBtn("Sometimes", freqHandler);
            b3 = MakeFreqBtn("Often", freqHandler);
            b4 = MakeFreqBtn("Frequently", freqHandler);
            b5 = MakeFreqBtn("Always", freqHandler);

            freqPanel.Controls.Add(b1); freqPanel.Controls.Add(b2);
            freqPanel.Controls.Add(b3); freqPanel.Controls.Add(b4);
            freqPanel.Controls.Add(b5);
            mainFlow.Controls.Add(freqPanel);

            // Craving panel (hidden by default)
            cravingPanel = new Panel();
            cravingPanel.AutoSize = true;
            cravingPanel.Visible = false;
            cravingPanel.BorderStyle = BorderStyle.FixedSingle;
            cravingPanel.Margin = new Padding(0, 5, 0, 5);
            cravingPanel.Padding = new Padding(10);
            cravingPanel.MinimumSize = new Size(580, 90);

            cravingLabel = new Label();
            cravingLabel.AutoSize = true;
            cravingLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic);
            cravingLabel.Text = $"What do you crave when you feel {emotion}?";
            cravingLabel.Location = new Point(10, 10);
            cravingPanel.Controls.Add(cravingLabel);

            sw = MakeCravingBtn("Sweet", 10, 50, CravingButtonClick);
            so = MakeCravingBtn("Sour", 120, 50, CravingButtonClick);
            sp = MakeCravingBtn("Spicy", 230, 50, CravingButtonClick);
            sa = MakeCravingBtn("Salty", 340, 50, CravingButtonClick);

            cravingPanel.Controls.Add(sw); cravingPanel.Controls.Add(so);
            cravingPanel.Controls.Add(sp); cravingPanel.Controls.Add(sa);
            mainFlow.Controls.Add(cravingPanel);
        }

        private Button MakeFreqBtn(string text, EventHandler handler)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Microsoft Sans Serif", 8.25F);
            btn.Size = new Size(90, 30);
            btn.Margin = new Padding(0, 0, 5, 0);
            btn.UseVisualStyleBackColor = true;
            btn.Click += handler;
            return btn;
        }

        private Button MakeCravingBtn(string text, int x, int y, EventHandler handler)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btn.Size = new Size(94, 30);
            btn.Location = new Point(x, y);
            btn.UseVisualStyleBackColor = true;
            btn.Click += handler;
            return btn;
        }

        private FlowLayoutPanel mainFlow;
        private Label label1;
        private Button button1, button2, button3, button4, button5;
        private Button button6, button7, button8, button9, button10;
        private Button button11, button12, button13, button14, button15;
        private Button button16, button17, button18, button19, button20;
        private Button button21, button22, button23, button24, button25;
        private Button buttonSave;
        private Label labelSaveError;
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