using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraTerrestrialTurmoil
{
    public partial class GameOver : Form
    {
        public string[] p1Scores = new string[10];
        public string[] p2Scores = new string[10];
        public string text;
        public bool players2;

        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

            if (players2)
            {
                lbHighScores.Items.Add("ID\tP1Name\tScore\tP2Name\tScore\tTotalScore");
                for (int a = 0; a < 10; a++) { lbHighScores.Items.Add(p2Scores[a]); }
            }
            else
            {

                lbHighScores.Items.Add("ID\tName\tScore");
                for (int a = 0; a < 10; a++) { lbHighScores.Items.Add(p1Scores[a]); }
            }

            label1.Text = text;
        }
    }
}
