using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace Bon
{    public partial class preferences : Form
    {    private readonly string _username;
        private readonly string _connectionString =
            $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Bon.accdb";
        private readonly Dictionary<string, string> _selections = new(StringComparer.OrdinalIgnoreCase);
        private readonly string[] _requiredKeys = new[] { "Happy", "Sad", "Angry", "Bored", "Stressed" };
        public preferences()
        {   InitializeComponent();
            try
            {   var tables = DataAccess.GetTableNames(_connectionString);}
            catch (Exception ex) { Debug.WriteLine(ex.Message); } }
        public preferences(string username) : this()
        { _username = username;} 
        private void preferences_Load(object sender, EventArgs e)
        {    BuildBlock("Happy", out button1, out button2, out button3, out button4, out button5, out happycraving, out happylabel, out sweet1, out sour1, out spicy1, out salty1, HappyFrequencySelected);
            BuildBlock("Sad", out button6, out button7, out button8, out button9, out button10, out sadcraving, out sadlabel, out sweet2, out sour2, out spicy2, out salty2, SadFrequencySelected);
            BuildBlock("Angry", out button11, out button12, out button13, out button14, out button15, out angrypanel, out angrylabel, out sweet3, out sour3, out spicy3, out salty3, AngryFrequencySelected);
            BuildBlock("Bored", out button16, out button17, out button18, out button19, out button20, out boredpanel, out boredlabel, out sweet4, out sour4, out spicy4, out salty4, BoredFrequencySelected);
            BuildBlock("Stressed", out button21, out button22, out button23, out button24, out button25, out stressedpanel, out stressedlabel, out sweet5, out sour5, out spicy5, out salty5, StressedFrequencySelected);
            mainFlow.Controls.Add(buttonSave);
            mainFlow.Controls.Add(labelSaveError);
            happycraving.Visible = false;
            sadcraving.Visible = false;
            angrypanel.Visible = false;
            boredpanel.Visible = false;
            stressedpanel.Visible = false;}
        private void HappyFrequencySelected(object sender, EventArgs e)
        {    Highlight(new[] { button1, button2, button3, button4, button5 }, (Button)sender);
            _selections["Happy"] = ((Button)sender).Text;
            happycraving.Visible = true;}
        private void SadFrequencySelected(object sender, EventArgs e)
        {    Highlight(new[] { button6, button7, button8, button9, button10 }, (Button)sender);
            _selections["Sad"] = ((Button)sender).Text;
            sadcraving.Visible = true; }
        private void AngryFrequencySelected(object sender, EventArgs e)
        {   Highlight(new[] { button11, button12, button13, button14, button15 }, (Button)sender);
            _selections["Angry"] = ((Button)sender).Text;
            angrypanel.Visible = true;}
        private void BoredFrequencySelected(object sender, EventArgs e)
        {    Highlight(new[] { button16, button17, button18, button19, button20 }, (Button)sender);
            _selections["Bored"] = ((Button)sender).Text;
            boredpanel.Visible = true; }
        private void StressedFrequencySelected(object sender, EventArgs e)
        {Highlight(new[] { button21, button22, button23, button24, button25 }, (Button)sender);
            _selections["Stressed"] = ((Button)sender).Text;
            stressedpanel.Visible = true;}
        private void CravingButtonClick(object? sender, EventArgs e)
        {   if (sender is not Button btn) return;
            foreach (Control c in btn.Parent.Controls)
                if (c is Button b) b.BackColor = SystemColors.Control;
            btn.BackColor = Color.LightBlue;
            if (btn.Parent == happycraving) _selections["HappyCraving"] = btn.Text;
            else if (btn.Parent == sadcraving) _selections["SadCraving"] = btn.Text;
            else if (btn.Parent == angrypanel) _selections["AngryCraving"] = btn.Text;
            else if (btn.Parent == boredpanel) _selections["BoredCraving"] = btn.Text;
            else if (btn.Parent == stressedpanel) _selections["StressedCraving"] = btn.Text; }
        private void buttonSave_Click(object sender, EventArgs e)
        {   labelSaveError.Text = string.Empty;
            var missing = new List<string>();
            foreach (var key in _requiredKeys)
                if (!_selections.ContainsKey(key) || string.IsNullOrWhiteSpace(_selections[key]))
                    missing.Add(key);
            if (missing.Count > 0)
            {  labelSaveError.Text = "Please select: " + string.Join(", ", missing);
                return; }
            if (string.IsNullOrEmpty(_username))
            {   labelSaveError.Text = "No username provided.";
                return;}
            try
            {   DataAccess.SaveAllPreferences(
                    _connectionString, _username,
                    _selections.GetValueOrDefault("Happy", ""),
                    _selections.GetValueOrDefault("Sad", ""),
                    _selections.GetValueOrDefault("Angry", ""),
                    _selections.GetValueOrDefault("Stressed", ""),
                    _selections.GetValueOrDefault("Bored", ""));
                DataAccess.SaveCravings(
                    _connectionString, _username,
                    _selections.GetValueOrDefault("HappyCraving", ""),
                    _selections.GetValueOrDefault("SadCraving", ""),
                    _selections.GetValueOrDefault("AngryCraving", ""),
                    _selections.GetValueOrDefault("StressedCraving", ""),
                    _selections.GetValueOrDefault("BoredCraving", ""));
                this.Close();}
            catch (Exception ex)
            {   Debug.WriteLine($"Save failed: {ex.Message}");
                labelSaveError.Text = "Saving failed: " + ex.Message; } }
        private void Highlight(Button[] group, Button selected)
        {   foreach (var b in group) b.BackColor = SystemColors.Control;
            selected.BackColor = Color.LightBlue; }
        private void mainFlow_Paint(object sender, PaintEventArgs e)
        {}}}