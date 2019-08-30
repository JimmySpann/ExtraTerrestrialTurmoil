using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExtraTerrestrialTurmoil
{
    public partial class Options : Form
    {
       public bool  Apply = false;
       public string soundEffect, BGMEffect;
       public int BGMVolume;

        public Options()
        {
            InitializeComponent();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BGMVolume = trackBGMVolume.Value;
            File.Delete(@"Data/Options.txt");
            File.AppendAllText(@"Data/Options.txt", soundEffect + "\n" + BGMEffect + "\n" + BGMVolume);
            Apply = true;
            Close();
        }

        private void rbSEOn_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSEOn.Checked) { soundEffect = "true"; }
        }

        private void rbSEOff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSEOff.Checked) { soundEffect = "false"; }
        }

        private void rbBGMEOn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBGMEOn.Checked) { BGMEffect = "true"; }
        }

        private void rbBGMEOff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBGMEOff.Checked) { BGMEffect = "false"; }

        }

        private void Options_Load(object sender, EventArgs e)
        {
            StreamReader OptionsFile = File.OpenText(@"Data/Options.txt");
            soundEffect = OptionsFile.ReadLine();
            BGMEffect = OptionsFile.ReadLine();
            BGMVolume = int.Parse(OptionsFile.ReadLine());
            OptionsFile.Close();
            if (BGMEffect == "true") rbBGMEOn.Checked = true;
            else rbBGMEOff.Checked = true;
            if (soundEffect == "true") rbSEOn.Checked = true;
            else rbSEOff.Checked = true;
            trackBGMVolume.Value = BGMVolume;
            Apply = false;

        }
    }
}
