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
    public partial class Pause : Form
    {
        public bool exitGame = false, exitSession = false, pauseOptions = false, menuActive = false;
        public string soundEffect, BGMEffect;
        public int BGMVolume;
        Options optionsMenu = new Options();

        public Pause()
        {
            InitializeComponent();

        }

        private void Pause_FormClosed(object sender, FormClosedEventArgs e)
        {
            
         //   mainform.GameEngine.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Pause_Load(object sender, EventArgs e)
        {
            if (pauseOptions == true)
            {
                Options optionsMenu = new Options();
                do
                {
                    StreamReader Optionsfile = File.OpenText(@"Data/Options.txt");
                    soundEffect = Optionsfile.ReadLine();
                    BGMEffect = Optionsfile.ReadLine();
                    BGMVolume = int.Parse(Optionsfile.ReadLine());
                    Optionsfile.Close();
                    optionsMenu.ShowDialog();
                } while (pauseOptions == true);
            } 
        }

        private void Pause_Activated(object sender, EventArgs e)
        {
            if (optionsMenu.Apply == true) { pauseOptions = true; Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            pauseOptions = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exitSession = true;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exitGame = true;
            Close();
        }


    }
}
