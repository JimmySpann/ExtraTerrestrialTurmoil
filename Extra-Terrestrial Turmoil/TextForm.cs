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
    public partial class TextForm : Form
    {
        public string text;
        public TextForm()
        {
            InitializeComponent();
        }

        private void TextForm_Load(object sender, EventArgs e)
        {
            if (this.Text == "Game Over" || this.Text == "Winner!" || this.Text == "Draw!")
                label1.Font = new Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
