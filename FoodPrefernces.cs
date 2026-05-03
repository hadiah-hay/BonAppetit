using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
namespace Bon
{   public partial class FoodPrefernces : Form
    {   private readonly string _username;
        private string _hydrationAnswer;
        private string _sleepAnswer;
        private string _dietAnswer;
        private string _socialAnswer;
        private readonly string _connectionString =
            $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Bon.accdb";
        private readonly Dictionary<string, string> _foodDescriptions = new(StringComparer.OrdinalIgnoreCase)
        {   { "Gulab Jamun",    "Soft & syrupy, melts in your mouth" },
            { "Chocolate Cake", "Rich, indulgent & mood lifting" },
            { "Halwa",          "Warm, comforting & sweet" },
            { "Limes",          "Zesty & refreshing" },
            { "Yogurt",         "Cool, tangy & gut friendly" },
            { "Pickles",        "Sharp, crunchy & satisfying" },
            { "Kimchi",         "Fermented, bold & spicy" },
            { "Buffalo Wings",  "Crispy, saucy & fiery" },
            { "Thai Curry",     "Aromatic spices & rich heat" },
            { "Pretzels",       "Crunchy, salty & snackable" },
            { "Bacon",          "Smoky, crispy & savory" },
            { "Chedder Cheez",  "Creamy, sharp & satisfying" }};
        private readonly Dictionary<string, string> _emotionEmojis = new(StringComparer.OrdinalIgnoreCase)
        {   { "Happy",    "😊" },
            { "Sad",      "😢" },
            { "Angry",    "😠" },
            { "Stressed", "😩" },
            { "Bored",    "😴" } };
        public FoodPrefernces()
        {   InitializeComponent();}
        public FoodPrefernces(string username, string hydration = "", string sleep = "", string diet = "", string social = "") : this()
        {   _username = username;
            _hydrationAnswer = hydration;
            _sleepAnswer = sleep;
            _dietAnswer = diet;
            _socialAnswer = social; }
        private void FoodPrefernces_Load(object sender, EventArgs e)
        {   WireEmotionPanels();
            btnBack.Click += BtnBack_Click;}
        private void WireEmotionPanels()
        {   AttachClick(pnlHappy, "Happy");
            AttachClick(pnlSad, "Sad");
            AttachClick(pnlAngry, "Angry");
            AttachClick(pnlStressed, "Stressed");
            AttachClick(pnlBored, "Bored");}
        private void AttachClick(Panel panel, string emotion)
        {panel.Cursor = Cursors.Hand;
            panel.Click += (s, e) => EmotionSelected(emotion);
            foreach (Control c in panel.Controls)
            {   c.Cursor = Cursors.Hand;
                c.Click += (s, e) => EmotionSelected(emotion);}}
        private void EmotionSelected(string emotion)
        {   string craving = GetCravingForEmotion(emotion);
            if (string.IsNullOrEmpty(craving))
            {   MessageBox.Show($"No craving preference found for {emotion}. Please complete preferences first.");
                return;}
            List<string> foods = GetFoods(craving);
            if (foods.Count == 0)
            {   MessageBox.Show("No foods found for your preference.");
                return;}
            ShowRecommendations(emotion, craving, foods);}
        private void ShowRecommendations(string emotion, string craving, List<string> foods)
        {   lblEmotionEmoji.Text = _emotionEmojis.GetValueOrDefault(emotion, "😊");
            lblEmotionEmoji.Font = new Font("Segoe UI", 12F);
            lblEmotionName.Text = $"Feeling {emotion}";
            lblEmotionName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFood1Name.Text = foods.Count > 0 ? foods[0] : "";
            lblFood1Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood1Desc.Text = foods.Count > 0 ? _foodDescriptions.GetValueOrDefault(foods[0], "") : "";
            lblFood2Name.Text = foods.Count > 1 ? foods[1] : "";
            lblFood2Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood2Desc.Text = foods.Count > 1 ? _foodDescriptions.GetValueOrDefault(foods[1], "") : "";
            lblFood3Name.Text = foods.Count > 2 ? foods[2] : "";
            lblFood3Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood3Desc.Text = foods.Count > 2 ? _foodDescriptions.GetValueOrDefault(foods[2], "") : "";
            if (!string.IsNullOrEmpty(craving) && craving.Equals("spicy", StringComparison.OrdinalIgnoreCase))
            {   label3.Text = "You take things head on and are not afraid of failing.";
                label4.Text = "Adventureous";}
            else if (!string.IsNullOrEmpty(craving) && craving.Equals("sweet", StringComparison.OrdinalIgnoreCase))
            {   label3.Text = "You are the reason people believe in humanity.\n " +
                    "You motivate others to think positively.";
                label4.Text = "Kind";}
            else if (!string.IsNullOrEmpty(craving) && craving.Equals("sour", StringComparison.OrdinalIgnoreCase))
            {   label3.Text = "You are the sunshine of the group and your \n" +
                    " brightness makes others excited.";
                label4.Text = "Energentic";}
            else if (!string.IsNullOrEmpty(craving) && craving.Equals("salty", StringComparison.OrdinalIgnoreCase))
            {   label3.Text = "You are able to stay composed regardless of the situation.\n " +
                    "You bring peace to people just by your prssence.";
                label4.Text = "Calm";}
            else
            {   label3.Text = string.Empty;
                label4.Text = string.Empty;}
            tlpEmotions.Visible = false;
            lblTitle.Visible = false;
            if (panel1 != null)
            {
                panel1.Visible = true;
                panel1.BringToFront();}}
        private void BtnBack_Click(object sender, EventArgs e)
        {   panel1.Visible = false;
            tlpEmotions.Visible = true;
            lblTitle.Visible = true;}
        private string GetCravingForEmotion(string emotion)
        {   string column = emotion + "Craving"; // e.g. HappyCraving
            string query = $"SELECT [{column}] FROM Cravings WHERE Username = @username";
            try
            {   using var conn = new OleDbConnection(_connectionString);
                using var cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", _username);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";}
            catch (Exception ex)
            {   MessageBox.Show("Error reading craving: " + ex.Message);
                return "";} }
        private List<string> GetFoods(string category)
        {   var foods = new List<string>();
            string query = "SELECT TOP 3 FoodName FROM Foods WHERE Category = @category";
            try
            {   using var conn = new OleDbConnection(_connectionString);
                using var cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", category);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    foods.Add(reader["FoodName"].ToString());}
            catch (Exception ex)
            {   MessageBox.Show("Error reading foods: " + ex.Message);}
            return foods;}
        private void tlpEmotions_Paint(object sender, PaintEventArgs e) { }
        private void lblEmojiHappy_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton8_CheckedChanged(object sender, EventArgs e) { }
        private void pnlFood3_Paint(object sender, PaintEventArgs e) { }
        private void lblFoodGuide_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void lblEmotionName_Click(object sender, EventArgs e){}
        private void lblRecommended_Click(object sender, EventArgs e) {}
        private void lblFood2Name_Click(object sender, EventArgs e){ }

        private void lblFood2Desc_Click(object sender, EventArgs e) {}
        private void lblFood3Name_Click(object sender, EventArgs e) {}
        private void label2_Click(object sender, EventArgs e) {}
        private void panel1_Paint(object sender, PaintEventArgs e){ }
        private void panel2_Paint(object sender, PaintEventArgs e){}
        private void label4_Click_1(object sender, EventArgs e){ }
        private void lblWellnessTitle_Click(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e)
        {   try
            {   using var summary = new Form2(_connectionString, _hydrationAnswer, _sleepAnswer, _dietAnswer, _socialAnswer);
                this.Hide();
                summary.ShowDialog(this);
                this.Close();}
            catch (Exception ex)
            {   MessageBox.Show("Unable to open final summary: " + ex.Message);}}}}