using System;
using System.Windows.Forms;

namespace Bon
{
    public partial class NewForm : Form
    {
        private readonly string _username;
        private Button _selectedQ1, _selectedQ2, _selectedQ3, _selectedQ4;
        private string _ans1, _ans2, _ans3, _ans4;

        public NewForm()
        {
            InitializeComponent();
        }

        public NewForm(string username) : this()
        {
            _username = username;
        }

        private void NewForm_Load(object sender, EventArgs e)
        {
            // optional initialization
            // attach option handlers for all option buttons
            var optionButtons = new Button[] { button1, button2, button3, button4, button5,
                button6, button7, button8, button9, button10,
                button11, button12, button13, button14, button15,
                button16, button17, button18, button19, button20 };

            foreach (var b in optionButtons)
            {
                b.Click += OptionButton_Click;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Ensure there is a username to associate answers with
            if (string.IsNullOrWhiteSpace(_username))
            {
                MessageBox.Show("Username not available. Cannot save answers.");
                return;
            }

            // Save any selected answers to DB
            try
            {
                if (!string.IsNullOrEmpty(_ans1)) DataAccess.InsertNewFormAnswer(AppDomain.CurrentDomain.BaseDirectory + "Bon.accdb" == null ? throw new InvalidOperationException() : DataAccessConnectionString(), _username, "Hydration", _ans1);
            }
            catch { }

            try { if (!string.IsNullOrEmpty(_ans2)) DataAccess.InsertNewFormAnswer(DataAccessConnectionString(), _username, "Sleep", _ans2); } catch { }
            try { if (!string.IsNullOrEmpty(_ans3)) DataAccess.InsertNewFormAnswer(DataAccessConnectionString(), _username, "Diet", _ans3); } catch { }
            try { if (!string.IsNullOrEmpty(_ans4)) DataAccess.InsertNewFormAnswer(DataAccessConnectionString(), _username, "Social", _ans4); } catch { }

            // After saving navigate to FoodPrefernces
            try
            {
                var pref = new FoodPrefernces(_username);
                this.Hide();
                pref.ShowDialog(this);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open preferences: " + ex.Message);
            }
        }

        // Helper to provide the same connection string as other forms
        private string DataAccessConnectionString()
        {
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Bon.accdb";
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            // Determine which question group by Y coordinate
            int y = btn.Location.Y;
            if (y >= 80 && y < 120)
            {
                // Q1
                SelectButton(ref _selectedQ1, btn);
                _ans1 = btn.Text;
            }
            else if (y >= 150 && y < 195)
            {
                // Q2
                SelectButton(ref _selectedQ2, btn);
                _ans2 = btn.Text;
            }
            else if (y >= 235 && y < 265)
            {
                // Q3
                SelectButton(ref _selectedQ3, btn);
                _ans3 = btn.Text;
            }
            else if (y >= 310 && y < 345)
            {
                // Q4
                SelectButton(ref _selectedQ4, btn);
                _ans4 = btn.Text;
            }
        }

        private void SelectButton(ref Button current, Button newBtn)
        {
            if (current != null)
            {
                current.BackColor = SystemColors.Control;
            }
            current = newBtn;
            current.BackColor = Color.LightBlue;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
