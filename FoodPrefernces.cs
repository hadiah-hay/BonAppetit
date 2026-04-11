using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Bon
{
    public partial class FoodPrefernces : Form
    {
        private readonly string _username;
        private readonly string _connectionString =
            $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={AppDomain.CurrentDomain.BaseDirectory}Bon.accdb";

        // Hardcoded short descriptions per food
        private readonly Dictionary<string, string> _foodDescriptions = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Gulab Jamun",    "Soft & syrupy, melts in your mouth" },
            { "Chocolate Cake", "Rich, indulgent & mood lifting" },
            { "Halwa",          "Warm, comforting & sweet" },
            { "Limes",          "Zesty & refreshing" },
            { "Yougurt",         "Cool, tangy & gut friendly" },
            { "Pickles",        "Sharp, crunchy & satisfying" },
            { "Kimchi",         "Fermented, bold & spicy" },
            { "Buffalo Wings",  "Crispy, saucy & fiery" },
            { "Thai Curry",     "Aromatic spices & rich heat" },
            { "Pretzels",       "Crunchy, salty & snackable" },
            { "Bacon",          "Smoky, crispy & savory" },
            { "Chedder Cheez",  "Creamy, sharp & satisfying" }
        };

        // Emoji per emotion
        private readonly Dictionary<string, string> _emotionEmojis = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Happy",    "😊" },
            { "Sad",      "😢" },
            { "Angry",    "😠" },
            { "Stressed", "😩" },
            { "Bored",    "😴" }
        };

        public FoodPrefernces()
        {
            InitializeComponent();
        }

        public FoodPrefernces(string username) : this()
        {
            _username = username;
        }

        private void FoodPrefernces_Load(object sender, EventArgs e)
        {
            WireEmotionPanels();
            btnBack.Click += BtnBack_Click;
        }

        // ── MAKE EMOTION PANELS CLICKABLE ───────────────────────────
        private void WireEmotionPanels()
        {
            AttachClick(pnlHappy, "Happy");
            AttachClick(pnlSad, "Sad");
            AttachClick(pnlAngry, "Angry");
            AttachClick(pnlStressed, "Stressed");
            AttachClick(pnlBored, "Bored");
        }

        private void AttachClick(Panel panel, string emotion)
        {
            panel.Cursor = Cursors.Hand;
            panel.Click += (s, e) => EmotionSelected(emotion);

            // Also attach to every child label inside the panel
            // so clicking the emoji or name text also works
            foreach (Control c in panel.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.Click += (s, e) => EmotionSelected(emotion);
            }
        }

        // ── WHEN EMOTION IS CLICKED ─────────────────────────────────
        private void EmotionSelected(string emotion)
        {
            // 1. Get their saved craving for this emotion from DB
            string craving = GetCravingForEmotion(emotion);
            
            if (string.IsNullOrEmpty(craving))
            {
                MessageBox.Show($"No craving preference found for {emotion}. Please complete preferences first.");
                return;
            }

            // 2. Get 3 matching foods from DB
            List<string> foods = GetFoods(craving);
            if (foods.Count == 0)
            {
                MessageBox.Show("No foods found for your preference.");
                return;
            }

            // 3. Fill in the recommendation panel
            ShowRecommendations(emotion, craving, foods);
        }

        // ── FILL & SHOW RECOMMENDATION PANEL ───────────────────────
        private void ShowRecommendations(string emotion, string craving, List<string> foods)
        {
            // Set emotion card
            lblEmotionEmoji.Text = _emotionEmojis.GetValueOrDefault(emotion, "😊");
            lblEmotionEmoji.Font = new Font("Segoe UI", 16F);
            lblEmotionName.Text = $"Feeling {emotion}";
            lblEmotionName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Set food card 1
            lblFood1Name.Text = foods.Count > 0 ? foods[0] : "";
            lblFood1Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood1Desc.Text = foods.Count > 0 ? _foodDescriptions.GetValueOrDefault(foods[0], "") : "";

            // Set food card 2
            lblFood2Name.Text = foods.Count > 1 ? foods[1] : "";
            lblFood2Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood2Desc.Text = foods.Count > 1 ? _foodDescriptions.GetValueOrDefault(foods[1], "") : "";

            // Set food card 3
            lblFood3Name.Text = foods.Count > 2 ? foods[2] : "";
            lblFood3Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFood3Desc.Text = foods.Count > 2 ? _foodDescriptions.GetValueOrDefault(foods[2], "") : "";

            // Switch panels
            tlpEmotions.Visible = false;
            lblTitle.Visible = false;
            panel1.Visible = true;
        }

        // ── BACK BUTTON ─────────────────────────────────────────────
        private void BtnBack_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            tlpEmotions.Visible = true;
            lblTitle.Visible = true;
        }

        // ── DB: GET CRAVING FOR EMOTION ─────────────────────────────
        private string GetCravingForEmotion(string emotion)
        {
            string column = emotion + "Craving"; // e.g. HappyCraving
            string query = $"SELECT [{column}] FROM Cravings WHERE Username = @username";

            try
            {
                using var conn = new OleDbConnection(_connectionString);
                using var cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", _username);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading craving: " + ex.Message);
                return "";
            }
        }

        // ── DB: GET 3 FOODS BY CATEGORY ─────────────────────────────
        private List<string> GetFoods(string category)
        {
            var foods = new List<string>();
            string query = "SELECT TOP 3 FoodName FROM Foods WHERE Category = @category";

            try
            {
                using var conn = new OleDbConnection(_connectionString);
                using var cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", category);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    foods.Add(reader["FoodName"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading foods: " + ex.Message);
            }

            return foods;
        }

        // ── KEEP EXISTING EMPTY HANDLERS ────────────────────────────
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
    }
}