using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Bon
{   public partial class Form2 : Form
    {   private readonly string _connectionString;
        private readonly string _hydrationAnswer;
        private readonly string _sleepAnswer;
        private readonly string _dietAnswer;
        private readonly string _socialAnswer;
        public Form2()
        {   InitializeComponent(); } 
        public Form2(string connectionString, string hydration, string sleep, string diet, string social) : this()
        {   _connectionString = connectionString;
            _hydrationAnswer = hydration;
            _sleepAnswer = sleep;
            _dietAnswer = diet;
            _socialAnswer = social; }
        private void Form2_Load(object sender, EventArgs e)
        {   LoadWellnessInsights();}
        private void LoadWellnessInsights()
        {   lblHydrationTitle.Text = "💧 Hydration";
            lblSleepTitle.Text = "😴 Sleep Quality";
            lblDietTitle.Text = "🥗 Diet";
            lblSocialTitle.Text = "⚡ Social Battery";
            LoadCard("Hydration", _hydrationAnswer, lblHydrationAnswer, lblHydrationTip, lblHydrationFoods);
            LoadCard("Sleep", _sleepAnswer, lblSleepAnswer, lblSleepTip, lblSleepFoods);
            LoadCard("Diet", _dietAnswer, lblDietAnswer, lblDietTip, lblDietFoods);
            LoadCard("Social", _socialAnswer, lblSocialAnswer, lblSocialTip, lblSocialFoods); }
        private void LoadCard(string category, string answer, Label lblAnswer, Label lblTip, Label lblFoods)
        {   if (string.IsNullOrEmpty(answer)) return;
            var dt = DataAccess.GetWellnessRecommendation(_connectionString, category, answer);
            if (dt.Rows.Count == 0) return;
            var row = dt.Rows[0];
            lblAnswer.Text = answer;
            lblTip.Text = row["Tip"].ToString();
            lblFoods.Text = $"• {row["Food1"]}\n• {row["Food2"]}\n• {row["Food3"]}"; }
        private void lblWellnessTitle_Click(object sender, EventArgs e){}
        private void lblSleepTitle_Click(object sender, EventArgs e){}
        private void lblSocialTitle_Click(object sender, EventArgs e){} }}
