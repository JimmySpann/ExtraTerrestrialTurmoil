using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace ExtraTerrestrialTurmoil
{
    partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = "Version 1.1";
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void Credits_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Credits"); listBox1.Items.Add(" ");
            listBox1.Items.Add("Programming:"); listBox1.Items.Add("        Jimmy Spann"); listBox1.Items.Add(" ");
            listBox1.Items.Add("Graphics:"); listBox1.Items.Add("        sujit1717 - Opengameart.com"); listBox1.Items.Add("        Osmic - Opengameart.com"); listBox1.Items.Add(" ");
            listBox1.Items.Add("Sound Effects:"); listBox1.Items.Add("        Robinhood76 - Freesound.org"); listBox1.Items.Add("        Ryansnook - Freesound.org"); listBox1.Items.Add("        Qubodup & DrMinky - FreeSound.org"); listBox1.Items.Add("        CCHub - Free Music and Footages - youtube.com"); listBox1.Items.Add("        Hybrid-V - FreeSound.org"); listBox1.Items.Add(" "); listBox1.Items.Add(" ");
            listBox1.Items.Add("Background Music:"); listBox1.Items.Add("        Spartacus!! - David Fau"); listBox1.Items.Add("        Facing Your Nemesis - TeknoAXE"); listBox1.Items.Add("        Eyesplit - SilvermanSound.com"); listBox1.Items.Add("        Revealed - David Fau"); listBox1.Items.Add("        Secta - Contra"); listBox1.Items.Add(" ");
            listBox1.Items.Add("Game Testers:"); listBox1.Items.Add("        Michael Mcdowell"); listBox1.Items.Add(" ");
            listBox1.Items.Add("Special Thanks To: "); listBox1.Items.Add("        Mr. Alimagham"); listBox1.Items.Add("        Cooltext.com"); listBox1.Items.Add("        Дима Магуров"); listBox1.Items.Add("        Tyler Gillespie"); listBox1.Items.Add("        Noah Aguado"); listBox1.Items.Add("        Jordan Ruppe"); listBox1.Items.Add("        Casey Ruppe"); listBox1.Items.Add("        Jesse ");
            labelCompanyName.Text = "CPT-185-A01 Final Project";
            labelVersion.Text = "Version 1.2";
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void labelVersion_Click(object sender, EventArgs e)
        {
            WindowsMediaPlayer voice = new WindowsMediaPlayer();
            voice.settings.volume = 100;
            voice.URL = @"Data\Sounds\vKidAgain.wav";
            MessageBox.Show("Easter Egg!");

        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
