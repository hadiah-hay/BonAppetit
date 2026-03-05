using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bon
{
    public class PreferencesSavedForm : Form
    {
        private Label lblMessage;
        private Button btnOk;

        public PreferencesSavedForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Preferences Saved";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(320, 140);

            lblMessage = new Label();
            lblMessage.Text = "Your preferences have been saved.";
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(20, 20);

            btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Size = new Size(80, 28);
            btnOk.Location = new Point(200, 80);
            btnOk.Click += (s, e) => this.Close();

            this.Controls.Add(lblMessage);
            this.Controls.Add(btnOk);
        }
    }
}
