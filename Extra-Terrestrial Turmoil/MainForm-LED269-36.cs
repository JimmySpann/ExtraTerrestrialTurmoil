using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.IO;
using WMPLib;

namespace WindowsFormsApplication5
{
    public partial class MainForm : Form
    {
        bool left, right, up, down, shoot, p1Dead = false, p1IsRed = false; //Moves, shoots, and determines death for player
        bool left2, right2, up2, down2, shoot2, p2Dead = false, p2IsRed = false; //Moves, shoots, and determines death for player2
        bool start = false, speedt = false, homing = false, killall = false; //In Game Triggers
        int lastdir, shootdir, lastdir2, shootdir2; //Directional Variables used for shooting and decelleration
        string p1Name = " ", p1Ship = "Speedster", p2Name = " ", p2Ship = "Speedster"; //Name of player or ship
        int p1Score, p1Live = 0, p2Score, p2Live = 0; //In game lives and score
        int enemies = 0, maxEnemies = 0, phase = 0, enemySpawn = 0, count = 0, gameMode = 0; //Counters within the GameEngine
        int force, accell, force2, accell2, playerSpeed, playerSpeed2, dashSpeed = 0, speed = 0, enemySpeed = 0; //All variables that control speed

        int redSwitch = 1, blueSwitch = 1, redEnemies = 0, maxRedEnemies = 3, blueEnemies = 0, maxBlueEnemies = 3;

        //Options Recorder
        public string BGMEffect, soundEffect; public int BGMVolume;


        //Globally Defined Media
        StreamReader OptionsFile = File.OpenText(@"Data/Options.txt");

        PictureBox bPlay = new PictureBox();
        PictureBox bOptions = new PictureBox();
        PictureBox bCredits = new PictureBox();
        PictureBox bExit = new PictureBox();
        PictureBox RedMShipAn = new PictureBox();
        PictureBox BlueMShipAn = new PictureBox();
        PictureBox rexplo = new PictureBox();

        SoundPlayer soundShoot = new SoundPlayer(Properties.Resources.RobinHoodShoot);
        SoundPlayer soundExplosion = new SoundPlayer(Properties.Resources.RyanSnookExplosion);
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();

        //Statuses
        int p1Paralzed = 0, p2Paralzed = 0;


        //Initialization
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
           
            //Read Data Files
            soundEffect = OptionsFile.ReadLine();
            BGMEffect = OptionsFile.ReadLine();
            BGMVolume = int.Parse(OptionsFile.ReadLine());
            OptionsFile.Close();

            //Begin Music
            var myPlayList = backgroundMusic.playlistCollection.newPlaylist("MyPlayList");
            var mediaItem = backgroundMusic.newMedia(@"BGM/BGM2.mp3");
            for (int a = 0; a <= 5; a++)
            {
                if(a == 1) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM2.mp3");
                if(a == 2) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM3.mp3");
                if(a == 3) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM1.mp3");
                if(a == 4) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM4.mp3");
                if(a == 5) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM5.mp3");
                myPlayList.appendItem(mediaItem);
            }
            backgroundMusic.currentPlaylist = myPlayList;
            backgroundMusic.uiMode = "none";
            backgroundMusic.settings.volume = BGMVolume;
            backgroundMusic.settings.setMode("shuffle", true);
            backgroundMusic.settings.setMode("loop", true);
            if (BGMEffect != "true") backgroundMusic.controls.stop();

            // Create bPlay
            bPlay.Image = global::WindowsFormsApplication5.Properties.Resources.play_buttons;
            bPlay.Name = "bPlay";
            bPlay.Size = new System.Drawing.Size(213, 91);
            bPlay.Location = new System.Drawing.Point(690, 171);
            bPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bPlay.TabIndex = 13;
            bPlay.TabStop = false;
            bPlay.Click += new System.EventHandler(this.bPlay_Click);
            bPlay.MouseLeave += new System.EventHandler(this.bPlay_MouseLeave);
            bPlay.MouseHover += new System.EventHandler(this.bPlay_MouseHover);

            // Create bOptions
            bOptions.Image = global::WindowsFormsApplication5.Properties.Resources.optionst_buttons;
            bOptions.Location = new System.Drawing.Point(690, 311);
            bOptions.Name = "bOptions";
            bOptions.Size = new System.Drawing.Size(213, 91);
            bOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bOptions.TabIndex = 14;
            bOptions.TabStop = false;
            bOptions.Click += new System.EventHandler(this.bOptions_Click);
            bOptions.MouseLeave += new System.EventHandler(this.bOptions_MouseLeave);
            bOptions.MouseHover += new System.EventHandler(this.bOptions_MouseHover);

            // Create bCredits
            bCredits.Image = global::WindowsFormsApplication5.Properties.Resources.Creditst_buttons;
            bCredits.Location = new System.Drawing.Point(690, 457);
            bCredits.Name = "bCredits";
            bCredits.Size = new System.Drawing.Size(213, 91);
            bCredits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bCredits.TabIndex = 15;
            bCredits.TabStop = false;
            bCredits.Click += new System.EventHandler(this.bCredits_Click);
            bCredits.MouseLeave += new System.EventHandler(this.bCredits_MouseLeave);
            bCredits.MouseHover += new System.EventHandler(this.bCredits_MouseHover);

            // Create bExit
            bExit.Image = global::WindowsFormsApplication5.Properties.Resources.exit_buttons;
            bExit.Location = new System.Drawing.Point(690, 607);
            bExit.Name = "bExit";
            bExit.Size = new System.Drawing.Size(213, 91);
            bExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            bExit.TabIndex = 16;
            bExit.TabStop = false;
            bExit.Click += new System.EventHandler(this.bExit_Click);
            bExit.MouseLeave += new System.EventHandler(this.bExit_MouseLeave);
            bExit.MouseHover += new System.EventHandler(this.bExit_MouseHover);

            //ActivateMenuScreen
            this.Controls.Add(bExit);
            this.Controls.Add(bCredits);
            this.Controls.Add(bOptions);
            this.Controls.Add(bPlay);

        }


        //GameEngine
        private void EngineIteration(object sender, EventArgs e)
        {

            PlayerMovement();
            PlayerHealthandLives();
            Accelleration();
            Ailments();
            if (gameMode == 2) BattleMode();
            else PhaseControl();


            foreach (Control enemy in this.Controls)
                   {
                       if (killall)
                       {
                           if (enemy.Tag == "enemy" || enemy.Tag == "bullet_up" || enemy.Tag == "bullet_left" || enemy.Tag == "bullet_down" || enemy.Tag == "bullet_right" || enemy.Tag == "bullet_up2" || enemy.Tag == "bullet_left2" || enemy.Tag == "bullet_down2" || enemy.Tag == "bullet_right2")
                           { Controls.Remove(enemy); enemies = 0; p1Score += 10; }
                       }
                           EnemyMovement(enemy); //Enemies chase players
                           Collisions(enemy); // Player/enemy, Player/Player, bullet/enemy
                           ObjectMovement(enemy); //Bullets move and hit walls
                   }

            if (phase == -1) QuitSession();
        }



        //Input Control
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(phase > 0)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    GameEngine.Stop();
                    Pause pauseMenu = new Pause();

                    do
                    {

                        if (pauseMenu.pauseOptions == true)
                        {
                            Options optionsMenu = new Options();
                            do
                            {
                                StreamReader Optionsfile = File.OpenText(@"Data/Options.txt");
                                soundEffect = Optionsfile.ReadLine();
                                BGMEffect = Optionsfile.ReadLine();
                                BGMVolume = int.Parse(Optionsfile.ReadLine());
                                backgroundMusic.settings.volume = BGMVolume;
                                if (BGMEffect != "true") backgroundMusic.controls.stop();
                                else backgroundMusic.controls.play();
                                Optionsfile.Close();
                                optionsMenu.ShowDialog();
                            } while (optionsMenu.Apply == true);
                        }

                        pauseMenu.pauseOptions = false;
                        pauseMenu.ShowDialog();

                    } while (pauseMenu.pauseOptions == true);

                    if (pauseMenu.exitGame == true) Close();
                    if (pauseMenu.exitSession == true)
                    {
                        pauseMenu.exitSession = false;
                        phase = -1;
                    }     
                }

            if (!p1Dead)
            {
                if (p1Paralzed <= 0)
                { 
                if (e.KeyCode == Keys.D) { right = true; }
                if (e.KeyCode == Keys.A) { left = true; }
                if (e.KeyCode == Keys.W) { up = true; }
                if (e.KeyCode == Keys.S) { down = true; }
                }
            if (e.KeyCode == Keys.Space) { if(!shoot) MakeBullet(); shoot = true; }
            }

            if (!p2Dead)
            {
                if (p2Paralzed <= 0)
                {
                    if (e.KeyCode == Keys.Left) { left2 = true; }
                    if (e.KeyCode == Keys.Up) { up2 = true; }
                    if (e.KeyCode == Keys.Right) { right2 = true; }
                    if (e.KeyCode == Keys.Down) { down2 = true; }
                }
                if (e.KeyCode == Keys.Enter) { if (!shoot2) MakeBullet2(); shoot2 = true; ; }
            }

            if (gameMode == 3)
                {
                    if (e.KeyCode == Keys.Y)
                    {
                        if (start == true) start = false;
                        else if (start == false) start = true;
                    }
                    if (e.KeyCode == Keys.U)
                    {
                        if (speedt == true) { speedt = false; speed = 0; }
                        else if (speedt == false) { speedt = true; speed = 100; }
                    }
                    if (e.KeyCode == Keys.I)
                    {
                        Random rnum = new Random();
                        int sx = rnum.Next(0, this.Width);
                        int sy = rnum.Next(0, this.Height);
                        PictureBox pb2 = new PictureBox();
                        pb2.BackColor = Color.Transparent;
                        pb2.Image = Properties.Resources.enemy;
                        pb2.Location = new Point(sx, sy);
                        pb2.Size = new Size(31, 30);
                        pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb2.Tag = "enemy";
                        this.Controls.Add(pb2);
                    }
                    if (e.KeyCode == Keys.H)
                    {
                        if (homing) homing = false;
                        else if (!homing) homing = true;
                    }
                    if (e.KeyCode == Keys.J)
                    {
                        if (killall) killall = false;
                        else if (!killall) killall = true;
                    }
                    if (e.KeyCode == Keys.K)
                    {
                        p1Score = 0;
                        p2Score = 0;
                        phase = 1;
                        maxEnemies = 1;
                    }
                } 
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) { right = false; lastdir = 3; }
            if (e.KeyCode == Keys.A) { left = false; lastdir = 1; }
            if (e.KeyCode == Keys.W) { up = false; lastdir = 2; }
            if (e.KeyCode == Keys.S) { down = false; lastdir = 4; }
            if (e.KeyCode == Keys.Space) { shoot = false; }
            if (e.KeyCode == Keys.Left) { left2 = false; lastdir2 = 1; }
            if (e.KeyCode == Keys.Up) { up2 = false; lastdir2 = 2; }
            if (e.KeyCode == Keys.Right) { right2 = false; lastdir2 = 3; }
            if (e.KeyCode == Keys.Down) { down2 = false; lastdir2 = 4; }
            if (e.KeyCode == Keys.Enter) { shoot2 = false; }
        }



        //Iteration Methods
            private void PlayerMovement()
            {
                //PlayerSpeed
                playerSpeed = force + dashSpeed;
                playerSpeed2 = force2 + dashSpeed;


                //Player1 movements
                if (!p1IsRed)
                {
                    if (p1Ship == "Speedster")
                    {
                        if (right == true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.BlueWingRight; }
                        if (left == true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.BlueWingLeft; }
                        if (up == true) { pPlayer.Top -= playerSpeed; pPlayer.Image = Properties.Resources.BlueWingUp; }
                        if (down == true) { pPlayer.Top += playerSpeed; pPlayer.Image = Properties.Resources.BlueWingDown; }
                    }
                    else if (p1Ship == "Vulture")
                    {
                        if (right == true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.Vulture_RightAn; }
                        if (left == true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.Vulture_LeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; pPlayer.Image = Properties.Resources.Vulture_UpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; pPlayer.Image = Properties.Resources.Vulture_DownAn; }
                    }
                    else if (p1Ship == "Destroyer")
                    {
                        if (right == true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_RightAn; }
                        if (left == true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_LeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_UpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_DownAn; }
                    }
                }
                else
                {
                    if (p1Ship == "Speedster")
                    {
                        if (right == true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterRightAn; }
                        if (left == true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterLeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterUpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterDownAn; }
                    }
                    else if (p1Ship == "Destroyer")
                    {
                        if (right == true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerRightAn; }
                        if (left == true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerLeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerUpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerDownAn; }
                    }
                }


                if (!p2IsRed)
                {
                    if (p2Ship == "Speedster")
                    {
                        if (right2 == true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingRight; }
                        if (left2 == true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingLeft; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingUp; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingDown; }
                    }
                    if (p2Ship == "Vulture")
                    {
                        if (right2 == true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_RightAn; }
                        if (left2 == true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_LeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_UpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_DownAn; }
                    }
                    if (p2Ship == "Destroyer")
                    {
                        if (right2 == true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_RightAn; }
                        if (left2 == true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_LeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_UpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_DownAn; }
                    }
                }
                else
                {
                    if (p2Ship == "Speedster")
                    {
                        if (right2 == true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterRightAn; }
                        if (left2 == true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterLeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterUpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterDownAn; }
                    }
                    if (p2Ship == "Destroyer")
                    {
                        if (right2 == true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerRightAn; }
                        if (left2 == true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerLeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerUpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerDownAn; }
                    }
                }




                //Determines shoot direction
                if (left == true && up == false && right == false && down == false) shootdir = 1;
                if (left == false && up == true && right == false && down == false) shootdir = 2;
                if (left == false && up == false && right == true && down == false) shootdir = 3;
                if (left == false && up == false && right == false && down == true) shootdir = 4;

                if (left2 == true && up2 == false && right2 == false && down2 == false) shootdir2 = 1;
                if (left2 == false && up2 == true && right2 == false && down2 == false) shootdir2 = 2;
                if (left2 == false && up2 == false && right2 == true && down2 == false) shootdir2 = 3;
                if (left2 == false && up2 == false && right2 == false && down2 == true) shootdir2 = 4;

                //loops map for players
                if (pPlayer.Location.X > this.Width - 75) pPlayer.Location = new Point(20, pPlayer.Location.Y);
                if (pPlayer.Location.X < 0) pPlayer.Location = new Point(this.Width - 20 - pPlayer.Width, pPlayer.Location.Y);
                if (pPlayer.Location.Y < 0) pPlayer.Location = new Point(pPlayer.Location.X, this.Height - 35 - pPlayer.Height);
                if (pPlayer.Location.Y > this.Height - 100) pPlayer.Location = new Point(pPlayer.Location.X, 20);

                if (pPlayer2.Location.X > this.Width - 75) pPlayer2.Location = new Point(20, pPlayer2.Location.Y);
                if (pPlayer2.Location.X < 0) pPlayer2.Location = new Point(this.Width - 20 - pPlayer2.Width, pPlayer2.Location.Y);
                if (pPlayer2.Location.Y < 0) pPlayer2.Location = new Point(pPlayer2.Location.X, this.Height - 35 - pPlayer2.Height);
                if (pPlayer2.Location.Y > this.Height - 100) pPlayer2.Location = new Point(pPlayer2.Location.X, 20);

            }
            private void EnemyMovement(Control enemy)
            {
                //Enemy Speed
                if (speedt) enemySpeed = 6;
                else enemySpeed = 3;

                if(gameMode == 2)
            {
           /*     if (enemy.Tag == "RedMShip")
                {
                    if (redSwitch == 1) { RedMShipAn.Top -= 4; if (RedMShipAn.Top <= 75) redSwitch = 2; }
                    else if (redSwitch == 2) { RedMShipAn.Top += 4; if (RedMShipAn.Top >= this.Height - 160) redSwitch = 1; }
                }
                if (enemy.Tag == "BlueMShip")
                {
                    if (blueSwitch == 2) { BlueMShipAn.Top -= 4; if (BlueMShipAn.Top <= 75) blueSwitch = 1; }
                    else if (blueSwitch == 1) { BlueMShipAn.Top += 4; if (BlueMShipAn.Top >= this.Height - 160) blueSwitch = 2; }
                } */

                if (!p1Dead && enemy.Tag == "RedGuy")
                {
                    if (enemy.Location.X > pPlayer.Location.X) enemy.Left -= enemySpeed;
                    if (enemy.Location.X < pPlayer.Location.X) enemy.Left += enemySpeed;
                    if (enemy.Location.Y < pPlayer.Location.Y) enemy.Top += enemySpeed;
                    if (enemy.Location.Y > pPlayer.Location.Y) enemy.Top -= enemySpeed;
                }

                if (!p2Dead && enemy.Tag == "BlueGuy")
                {
                    if (enemy.Location.X > pPlayer2.Location.X) enemy.Left -= enemySpeed;
                    if (enemy.Location.X < pPlayer2.Location.X) enemy.Left += enemySpeed;
                    if (enemy.Location.Y < pPlayer2.Location.Y) enemy.Top += enemySpeed;
                    if (enemy.Location.Y > pPlayer2.Location.Y) enemy.Top -= enemySpeed;
                }

            }



                if (enemy.Tag == "enemy")
                {

                    double p1Distance = Math.Round(Math.Sqrt(Math.Pow((enemy.Location.X - pPlayer.Location.X), 2) + Math.Pow((enemy.Location.Y - pPlayer.Location.Y), 2)));
                    double p2Distance = Math.Round(Math.Sqrt(Math.Pow((enemy.Location.X - pPlayer2.Location.X), 2) + Math.Pow((enemy.Location.Y - pPlayer2.Location.Y), 2)));

                    //Moves enemies towards players
                    if (start == true)
                    {

                        bool eh = false;
                        eh = false;
                        if (p1Distance < p2Distance) eh = true;
                        if (p2Dead || p2IsRed) eh = true;
                        if (p1Dead || p1IsRed) eh = false;
                        if (!p1Dead && eh)
                        {
                            if (enemy.Location.X > pPlayer.Location.X) enemy.Left -= enemySpeed;
                            if (enemy.Location.X < pPlayer.Location.X) enemy.Left += enemySpeed;
                            if (enemy.Location.Y < pPlayer.Location.Y) enemy.Top += enemySpeed;
                            if (enemy.Location.Y > pPlayer.Location.Y) enemy.Top -= enemySpeed;
                        }

                        if (!p2Dead && !eh)
                        {
                            if (enemy.Location.X > pPlayer2.Location.X) enemy.Left -= enemySpeed;
                            if (enemy.Location.X < pPlayer2.Location.X) enemy.Left += enemySpeed;
                            if (enemy.Location.Y < pPlayer2.Location.Y) enemy.Top += enemySpeed;
                            if (enemy.Location.Y > pPlayer2.Location.Y) enemy.Top -= enemySpeed;
                        }
                    }
                }



            }
            private void ObjectMovement(Control enemy)
            {
                //If bullet and wall collide + moves bullet
                if (enemy is PictureBox && enemy.Tag == "bullet_left")
                {
                    if (enemy.Location.X < 0) Controls.Remove(enemy);
                    if (speedt) enemy.Left -= 15;
                    if (!homing) enemy.Left -= 15;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_up")
                {
                    if (speedt) enemy.Top -= 15;
                    if (!homing) enemy.Top -= 15;
                    if (enemy.Location.Y < 0) Controls.Remove(enemy);
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_right")
                {
                    if (enemy.Location.X > this.Width) Controls.Remove(enemy);
                    if (speedt) enemy.Left += 15;
                    if (!homing) enemy.Left += 15;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_down")
                {
                    if (!homing) enemy.Top += 15;
                    if (speedt) enemy.Top += 15;
                    if (enemy.Location.Y > this.Height) Controls.Remove(enemy);
                }


                if (enemy is PictureBox && enemy.Tag == "bullet_left2")
                {
                    if (enemy.Location.X < 0) Controls.Remove(enemy);
                    if (speedt) enemy.Left -= 15;
                    if (!homing) enemy.Left -= 15;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_up2")
                {
                    if (speedt) enemy.Top -= 15;
                    if (!homing) enemy.Top -= 15;
                    if (enemy.Location.Y < 0) Controls.Remove(enemy);
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_right2")
                {
                    if (enemy.Location.X > this.Width) Controls.Remove(enemy);
                    if (speedt) enemy.Left += 15;
                    if (!homing) enemy.Left += 15;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_down2")
                {
                    if (speedt) enemy.Top += 15;
                    if (!homing) enemy.Top += 15;
                    if (enemy.Location.Y > this.Height) Controls.Remove(enemy);
                }
            }

            private void PlayerHealthandLives()
            {
                if (p1Health.Value == 0)
                {
                    p1Live -= 1;
                    pPlayer.Location = new Point(233, 109);
                    force = 0; accell = 0;
                    p1Health.Value = p1Health.Maximum;
                }

                if (p2Health.Value == 0)
                {
                    p2Live -= 1;
                    pPlayer2.Location = new Point(1314, 109);
                    force2 = 0; accell2 = 0;
                    p2Health.Value = p1Health.Maximum;
                }

                if (p1Live <= 0)
                {
                    pPlayer.Name = "pPlayer_dead";
                    Controls.Remove(pPlayer);
                    p1Dead = true;
                }

                if (p2Live <= 0)
                {
                    pPlayer2.Name = "pPlayer2_dead";
                    Controls.Remove(pPlayer2);
                    p2Dead = true;
                }

                if (p2Live <= 0 && p1Live <= 0)
                {
                    if (phase != -1) MessageBox.Show("Game Over");
                    phase = -1;

                }
            }
            private void Accelleration()
            {
                //Player1 Accelleration
                if (right == true || left == true || up == true || down == true)
                {
                    if (accell <= 75 + speed)
                    {
                        if (speedt == true) { Invalidate(); accell += 4; }
                        accell += 4;
                        force = accell / 8;
                    }
                }
                else
                {
                    if (accell >= 5)
                    {
                        if (speedt == true) { Invalidate(); accell -= 4; }
                        accell -= 8;
                        force = accell / 8;
                        if (lastdir == 1)
                        {
                            if (!p1IsRed)
                            {
                                if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Left;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Left;
                            }
                            else
                            {
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.RedSpeedsterLeft;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerLeft;
                            }

                            pPlayer.Left -= playerSpeed;
                        }
                        if (lastdir == 2)
                        {
                            if (!p1IsRed)
                            {
                                if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Up;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Up;
                            }
                            else
                            {
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerUp;
                            }
                            pPlayer.Top -= playerSpeed;
                        }
                        if (lastdir == 3)
                        {
                            if (!p1IsRed)
                            {
                                if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Right;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Right;
                            }
                            else
                            {
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.RedSpeedsterRight;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerRight;
                            }
                            pPlayer.Left += playerSpeed;
                        }
                        if (lastdir == 4)
                        {
                            if (!p1IsRed)
                            {
                                if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Down;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Down;
                            }
                            else
                            {
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.RedSpeedsterDown;
                                if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerDown;
                            }
                            pPlayer.Top += playerSpeed;
                        }
                    }
                }

                //Player2 Accelleration
                if (right2 == true || left2 == true || up2 == true || down2 == true)
                {
                    if (accell2 <= 75 + speed)
                    {
                        if (speedt == true) { Invalidate(); accell2 += 4; }
                        accell2 += 4;
                        force2 = accell2 / 8;
                    }
                }
                else
                {
                    if (accell2 >= 0)
                    {
                        if (speedt == true) { Invalidate(); accell2 -= 4; }
                        accell2 -= 8;
                        force2 = accell2 / 8;
                        if (lastdir2 == 1)
                        {
                            if (!p2IsRed)
                            {
                                if (p2Ship == "Vulture") pPlayer2.Image = Properties.Resources.Vulture_Left;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.Destroyer_Left;
                            }
                            else
                            {
                                if (p2Ship == "Speedster") pPlayer2.Image = Properties.Resources.RedSpeedsterLeft;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.RedDestroyerLeft;
                            }
                            pPlayer2.Left -= playerSpeed2;
                        }
                        if (lastdir2 == 2)
                        {
                            if (!p2IsRed)
                            {
                                if (p2Ship == "Vulture") pPlayer2.Image = Properties.Resources.Vulture_Up;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.Destroyer_Up;
                            }
                            else
                            {
                                if (p2Ship == "Speedster") pPlayer2.Image = Properties.Resources.RedSpeedsterUp;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.RedDestroyerUp;
                            }
                            pPlayer2.Top -= playerSpeed2;
                        }
                        if (lastdir2 == 3)
                        {
                            if (!p2IsRed)
                            {
                                if (p2Ship == "Vulture") pPlayer2.Image = Properties.Resources.Vulture_Right;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.Destroyer_Right;
                            }
                            else
                            {
                                if (p2Ship == "Speedster") pPlayer2.Image = Properties.Resources.RedSpeedsterRight;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.RedDestroyerRight;
                            }
                            pPlayer2.Left += playerSpeed2;
                        }
                        if (lastdir2 == 4)
                        {
                            if (!p2IsRed)
                            {
                                if (p2Ship == "Vulture") pPlayer2.Image = Properties.Resources.Vulture_Down;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.Destroyer_Down;
                            }
                            else
                            {
                                if (p2Ship == "Speedster") pPlayer2.Image = Properties.Resources.RedSpeedsterDown;
                                if (p2Ship == "Destroyer") pPlayer2.Image = Properties.Resources.RedDestroyerDown;
                            }
                            pPlayer2.Top += playerSpeed2;
                        }
                    }
                }

            }
            private void Ailments()
            {
                if (p1Paralzed > 0) p1Paralzed -= 3;
                if (p2Paralzed > 0) p2Paralzed -= 3;
            }
            private void Collisions(Control enemy)
            {
                //Keeps enemies from overlaying
                foreach (Control enemy2 in this.Controls)
                {
                if (enemy.Tag == "enemy")
                {
                    if (enemy.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        if (enemy2.Tag == "enemy")
                        {
                            if (enemy2.Left < enemy.Location.X + enemy.Width && enemy2.Left > enemy.Location.X + enemy.Width / 2) enemy2.Left += 100;
                            if (enemy2.Right > enemy.Location.X && enemy2.Right < enemy.Location.X + enemy.Width / 2) enemy2.Left -= 100;
                            if (enemy2.Top < enemy.Location.Y + enemy.Height && enemy2.Top > enemy.Location.Y + enemy.Height / 2) enemy2.Top += 100;
                            if (enemy2.Bottom > enemy.Location.Y && enemy2.Bottom < enemy.Location.Y + enemy.Height / 2) enemy2.Top -= 100;
                        }

                        if (enemy2.Tag == "bullet_up" || enemy2.Tag == "bullet_left" || enemy2.Tag == "bullet_down" || enemy2.Tag == "bullet_right")
                        {

                            if (!p1IsRed)
                            {
                                if (enemies >= 0) enemies--;
                                if (soundEffect == "true") soundExplosion.Play();
                                p1Score += 10;
                                Controls.Remove(enemy);
                                Controls.Remove(enemy2);
                            }

                        }
                        if (enemy2.Tag == "bullet_up2" || enemy2.Tag == "bullet_left2" || enemy2.Tag == "bullet_down2" || enemy2.Tag == "bullet_right2")
                        {
                            if (enemies >= 0)
                            {
                                if (!p2IsRed)
                                {
                                    if (soundEffect == "true") soundExplosion.Play();
                                    Controls.Remove(enemy);
                                    Controls.Remove(enemy2);
                                    enemies--;
                                    p2Score += 10;
                                }
                            }
                        }
                    }
                    if (homing)
                    {
                        if (enemy2 is PictureBox && enemy2.Tag == "bullet_left" || enemy2.Tag == "bullet_up" || enemy2.Tag == "bullet_right" || enemy2.Tag == "bullet_down")
                        {
                            if (enemy2.Location.X > enemy.Location.X) { enemy2.Left -= enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_left; }
                            if (enemy2.Location.X < enemy.Location.X) { enemy2.Left += enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_right; }
                            if (enemy2.Location.Y < enemy.Location.Y) { enemy2.Top += enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_down; }
                            if (enemy2.Location.Y > enemy.Location.Y) { enemy2.Top -= enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_up; }
                        }

                        if (enemy2 is PictureBox && enemy2.Tag == "bullet_left2" || enemy2.Tag == "bullet_up2" || enemy2.Tag == "bullet_right2" || enemy2.Tag == "bullet_down2")
                        {
                            if (enemy2.Location.X > enemy.Location.X) { enemy2.Left -= enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_left; }
                            if (enemy2.Location.X < enemy.Location.X) { enemy2.Left += enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_right; }
                            if (enemy2.Location.Y < enemy.Location.Y) { enemy2.Top += enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_down; }
                            if (enemy2.Location.Y > enemy.Location.Y) { enemy2.Top -= enemySpeed; enemy2.BackgroundImage = Properties.Resources.bullet_up; }
                        }
                    }
                }


                    //If player and enemy collide
                    if (!p1Dead && !p1IsRed)
                    {
                    if (enemy.Tag == "enemy" || enemy.Tag == "RedGuy")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                        {
                            if (pPlayer.Left < enemy.Location.X + enemy.Width && pPlayer.Left > enemy.Location.X + enemy.Width / 2)
                            {
                                pPlayer.Left += 50;
                                left = false; right = false; up = false; down = false; lastdir = 3;
                                p1Paralzed = 10;
                            }
                            if (pPlayer.Right > enemy.Location.X && pPlayer.Right < enemy.Location.X + enemy.Width)
                            {
                                pPlayer.Left -= 50;
                                left = false; right = false; up = false; down = false; lastdir = 1;
                                p1Paralzed = 10;
                            }
                            if (pPlayer.Top < enemy.Location.Y + enemy.Height && pPlayer.Top > enemy.Location.Y + enemy.Height / 2)
                            {
                                pPlayer.Top += 50;
                                left = false; right = false; up = false; down = false; lastdir = 4;
                                p1Paralzed = 10;
                            }
                            if (pPlayer.Bottom > enemy.Location.Y && pPlayer.Bottom < enemy.Location.Y + enemy.Height)
                            {
                                pPlayer.Top -= 50;
                                left = false; right = false; up = false; down = false; lastdir = 2;
                                p1Paralzed = 10;
                            }
                            if (p1Health.Value > 0)
                            {
                                if (p1Health.Value < 10) p1Health.Value = 0;
                                else p1Health.Value -= 10;
                            }
                        }
                    }
                    }

                    //If player2 and enemy collide
                    if (!p2Dead)
                    {
                    if (enemy.Tag == "enemy" && !p2IsRed || enemy.Tag == "BlueGuy")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer2.Bounds))
                        {
                            if (pPlayer2.Left < enemy.Location.X + enemy.Width && pPlayer2.Left > enemy.Location.X + enemy.Width / 2)
                            {
                                pPlayer2.Left += 50;
                                left2 = false; right2 = false; up2 = false; down2 = false; lastdir2 = 3;
                                p2Paralzed = 10;
                            }
                            if (pPlayer2.Right > enemy.Location.X && pPlayer2.Right < enemy.Location.X + enemy.Width)
                            {
                                pPlayer2.Left -= 50;
                                left2 = false; right2 = false; up2 = false; down2 = false; lastdir2 = 1;
                                p2Paralzed = 10;
                            }
                            if (pPlayer2.Top < enemy.Location.Y + enemy.Height && pPlayer2.Top > enemy.Location.Y + enemy.Height / 2)
                            {
                                pPlayer2.Top += 50;
                                left2 = false; right2 = false; up2 = false; down2 = false; lastdir2 = 4;
                                p2Paralzed = 10;
                            }
                            if (pPlayer2.Bottom > enemy.Location.Y && pPlayer2.Bottom < enemy.Location.Y + enemy.Height)
                            {
                                pPlayer2.Top -= 50;
                                left2 = false; right2 = false; up2 = false; down2 = false; lastdir2 = 2;
                                p2Paralzed = 10;
                            }
                            if (p2Health.Value > 0)
                            {
                                if (p2Health.Value < 10) p2Health.Value = 0;
                                else p2Health.Value -= 10;
                            }
                        }
                    }
                    }
                

                    if (enemy2.Tag == "bullet_up" || enemy2.Tag == "bullet_left" || enemy2.Tag == "bullet_down" || enemy2.Tag == "bullet_right")
                    {
                        if (enemy.Tag == "RedGuy" && enemy.Bounds.IntersectsWith(enemy2.Bounds))
                        {
                                if (enemies >= 0) enemies--;
                                if (soundEffect == "true") soundExplosion.Play();
                                p1Score += 10;
                                Controls.Remove(enemy);
                                Controls.Remove(enemy2);
                        }

                    }
                    if (enemy2.Tag == "bullet_up2" || enemy2.Tag == "bullet_left2" || enemy2.Tag == "bullet_down2" || enemy2.Tag == "bullet_right2")
                    {
                        if (enemy.Tag == "BlueGuy" && enemy.Bounds.IntersectsWith(enemy2.Bounds))
                        {
                                    if (soundEffect == "true") soundExplosion.Play();
                                    Controls.Remove(enemy);
                                    Controls.Remove(enemy2);
                                    enemies--;
                                    p2Score += 10;
                            
                        }
                    }
                  
                }

                if (enemy.Tag == "bullet_up" || enemy.Tag == "bullet_left" || enemy.Tag == "bullet_down" || enemy.Tag == "bullet_right")
                {
                   if (enemy.Bounds.IntersectsWith(pPlayer2.Bounds))
                   {
                       if (soundEffect == "true") soundExplosion.Play();
                       Controls.Remove(enemy);
                       p2Health.Value -= 10;
                   }

                }
                if (enemy.Tag == "bullet_up2" || enemy.Tag == "bullet_left2" || enemy.Tag == "bullet_down2" || enemy.Tag == "bullet_right2")
                {
                   if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                   {
                       if (soundEffect == "true") soundExplosion.Play();
                       Controls.Remove(enemy);
                       p1Health.Value -= 10;
                   }
                }
            }
            private void QuitSession()
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                p1Health.Visible = false;
                p2Health.Visible = false;
                start = false;
                homing = false;
                speedt = false;

                killall = true;

                this.Controls.Remove(pPlayer);
                this.Controls.Remove(pPlayer2);
                this.Controls.Remove(BlueMShipAn);
                this.Controls.Remove(RedMShipAn);
            count++;

                if (count == 100)
                {
                    count = 0;
                    GameEngine.Stop();
                    this.Controls.Add(bExit);
                    this.Controls.Add(bCredits);
                    this.Controls.Add(bOptions);
                    this.Controls.Add(bPlay);
                    this.Controls.Add(lblTitle);
                    p1Dead = false;
                    p2Dead = false;
                    p1Score = 0;
                    p2Score = 0;
                    left = false; right = false; up = false; down = false;
                    left2 = false; right2 = false; up2 = false; down2 = false;
                    killall = false;
                }

            }

            private void PhaseControl()
            {
                //label1.Text = "X: " + pPlayer.Location.X + "\n" + "Y: " + pPlayer.Location.Y + "\n" + "Force: " + force + "\n";
                if (gameMode == 3) label2.Text = "Y:Start/Stop U:ToggleSpeed I:AddEnemyPress\n H:Homing J:KillAll K:ResetScore" + phase + "    ";
                else label2.Text = "";
                label3.Text = "Player1: " + p1Name + "\nHealth: \nScore:" + p1Score + "\nLives: " + p1Live;
                label4.Text = "Player2: " + p2Name + "\nHealth: \nScore:" + p2Score + "\nLives: " + p2Live;

                if (phase == 0)
                {
                    this.Controls.Add(pPlayer);
                    if (rb2Players.Checked == true) this.Controls.Add(pPlayer2);

                    if (!p1IsRed)
                    {
                        if (p1Ship == "Speeder") pPlayer.Image = Properties.Resources.BlueWingUp;
                        else if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Up;
                        else if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Up;
                    }
                    else
                    {
                        if (p1Ship == "Speeder") pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                        else if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerUp;
                    }

                    if (!p2IsRed)
                    {
                        if (p2Ship == "Speeder") pPlayer.Image = Properties.Resources.BlueWingUp;
                        else if (p2Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Up;
                        else if (p2Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Up;
                    }
                    else
                    {
                        if (p2Ship == "Speeder") pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                        else if (p2Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerUp;
                    }


                    pPlayer.Location = new Point(233, 109);
                    pPlayer2.Location = new Point(1314, 109);

                enemySpawn = 3;
                maxEnemies = 1;
                    phase++;
                }


            //All Phases for Arcade
                if (phase >= 1 && enemies < maxEnemies && !killall && gameMode != 2)
                {
                    if (enemies < 0) enemies = 0;
                    Random rnum = new Random();
                    int ewns = rnum.Next(1, 4);
                    int sx = rnum.Next(75, this.Width - 75); //RedMShipAn.Location.X + RedMShipAn.Width / 2;
                    int sy = rnum.Next(75, this.Height - 100); //RedMShipAn.Location.Y + RedMShipAn.Height / 2;
                    PictureBox pb2 = new PictureBox();
                    pb2.Name = "Enemy";
                    pb2.BackColor = Color.Transparent;
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb2.Image = Properties.Resources.enemy;

                if (enemySpawn == 1) pb2.Location = new Point(sx, sy);
                if (enemySpawn == 2)
                {
                    if (ewns == 1) pb2.Location = new Point(75, sy);
                    else if (ewns == 2) pb2.Location = new Point((this.Width - 75), sy);
                    else if (ewns == 3) pb2.Location = new Point(sx, 75);
                    else if (ewns == 4) pb2.Location = new Point(sx, (this.Height - 100));
                }
                if (enemySpawn == 3)
                {
                    sx = rnum.Next(575, 1100);
                    sy = rnum.Next(225, 700);
                    pb2.Location = new Point(sx, sy);
                }
                    pb2.Size = new Size(31, 30);
                    pb2.Tag = "enemy";
                    this.Controls.Add(pb2);
                    enemies++;
                    if (phase == 1 && p1Score > 50 || phase == 1 && (p1Score + p2Score) > 70) { start = true; phase++; enemySpawn = 3; }
                    if (phase == 2 && p1Score > 200 || phase == 2 && (p1Score + p2Score) > 350) { maxEnemies = 2; phase++; }
                    if (phase == 3 && p1Score > 300 || phase == 3 && (p1Score + p2Score) > 500) { maxEnemies = 3; phase++; }
                    if (phase == 4 && p1Score > 1000 || phase == 4 && (p1Score + p2Score) > 1500) { speedt = true; phase++; }
                    if (phase == 5 && p1Score > 1500 || phase == 5 && (p1Score + p2Score) > 1900) { speedt = false; start = false; maxEnemies = 5; phase++; }
                    if (phase == 6 && p1Score > 1700 || phase == 6 && (p1Score + p2Score) > 2200) { start = true; phase++; }
                    if (phase == 7 && p1Score > 3500 || phase == 7 && (p1Score + p2Score) > 5000) { speedt = true; phase++; }
                    if (phase == 8 && p1Score > 10000 || phase == 8 && (p1Score + p2Score) > 60000) { speedt = false; start = false; maxEnemies = 10; phase++; }
                    if (phase == 9 && p1Score > 70000 || phase == 9 && (p1Score + p2Score) > 90000) { speedt = false; start = true; maxEnemies = 10; phase++; }
                    if (phase == 10 && p1Score > 100000 || phase == 10 && (p1Score + p2Score) > 150000) { speedt = true; start = true; maxEnemies = 10; phase++; }
                }
            }
            private void BattleMode()
        {
            //All Phases for Battle
            label3.Text = "Player1: " + p1Name + "\nHealth: \nScore:" + p1Score + "\nLives: " + p1Live;
            label4.Text = "Player2: " + p2Name + "\nHealth: \nScore:" + p2Score + "\nLives: " + p2Live;

            if (phase == 0)
                {

                    this.Controls.Add(pPlayer);
                    if (rb2Players.Checked == true) this.Controls.Add(pPlayer2);

                    if (!p1IsRed)
                    {
                        if (p1Ship == "Speeder") pPlayer.Image = Properties.Resources.BlueWingUp;
                        else if (p1Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Up;
                        else if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Up;
                    }
                    else
                    {
                        if (p1Ship == "Speeder") pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                        else if (p1Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerUp;
                    }

                    if (!p2IsRed)
                    {
                        if (p2Ship == "Speeder") pPlayer.Image = Properties.Resources.BlueWingUp;
                        else if (p2Ship == "Vulture") pPlayer.Image = Properties.Resources.Vulture_Up;
                        else if (p2Ship == "Destroyer") pPlayer.Image = Properties.Resources.Destroyer_Up;
                    }
                    else
                    {
                        if (p2Ship == "Speeder") pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                        else if (p2Ship == "Destroyer") pPlayer.Image = Properties.Resources.RedDestroyerUp;
                    }


                    RedMShipAn.BackColor = Color.Transparent;
                    RedMShipAn.Location = new Point(1466, 435);
                    RedMShipAn.Image = Properties.Resources.RedMShipAn1;
                    RedMShipAn.Size = new Size(131, 116);
                    RedMShipAn.SizeMode = PictureBoxSizeMode.StretchImage;
                    RedMShipAn.Tag = "RedMShip";
                    this.Controls.Add(RedMShipAn);

                    BlueMShipAn.BackColor = Color.Transparent;
                    BlueMShipAn.Location = new Point(40, 435);
                    BlueMShipAn.Image = Properties.Resources.BlueMShipAn;
                    BlueMShipAn.Size = new Size(131, 116);
                    BlueMShipAn.SizeMode = PictureBoxSizeMode.StretchImage;
                    BlueMShipAn.Tag = "BlueMShip";
                    this.Controls.Add(BlueMShipAn);

                    pPlayer.Location = new Point(233, 109);
                    pPlayer2.Location = new Point(1314, 109);

                    phase++;
                }


                if(redEnemies < maxRedEnemies)
                {
                    if (enemies < 0) enemies = 0;
                    PictureBox pb2 = new PictureBox();
                    pb2.Name = "Enemy";
                    pb2.BackColor = Color.Transparent;
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb2.Image = Properties.Resources.enemy;
                    pb2.Location = new Point(RedMShipAn.Left, RedMShipAn.Top);
                    pb2.Size = new Size(31, 30);
                    pb2.Tag = "RedGuy";
                    this.Controls.Add(pb2);
                    redEnemies++;
                }

                if (blueEnemies < maxBlueEnemies)
                {
                    if (enemies < 0) enemies = 0;
                    PictureBox pb2 = new PictureBox();
                    pb2.Name = "Enemy";
                    pb2.BackColor = Color.Transparent;
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb2.Image = Properties.Resources.BlueEnemyAn;
                    pb2.Location = new Point(BlueMShipAn.Left, BlueMShipAn.Top);
                    pb2.Size = new Size(31, 30);
                    pb2.Tag = "BlueGuy";
                    this.Controls.Add(pb2);
                    blueEnemies++;
                }

            }
        
            private void MakeBullet()
            {
                if (soundEffect == "true") soundShoot.Play();
                PictureBox bullet = new PictureBox();
                bullet.BackColor = Color.Transparent;
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                if (shootdir == 1)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_left;
                    else bullet.Image = Properties.Resources.bulletRedLeft;
                    bullet.Location = new Point(pPlayer.Location.X - 5, pPlayer.Location.Y + pPlayer.Height / 2 - 11);
                    bullet.Size = new Size(50, 27);
                    bullet.Tag = "bullet_left";
                }

                if (shootdir == 2)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_up;
                    else bullet.Image = Properties.Resources.bulletRedUp;
                    bullet.Location = new Point(pPlayer.Location.X + pPlayer.Width / 3 + 5, pPlayer.Location.Y - 5);
                    bullet.Size = new Size(27, 50);
                    bullet.Tag = "bullet_up";
                }

                if (shootdir == 3)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_right;
                    else bullet.Image = Properties.Resources.bulletRedRight;
                    bullet.Location = new Point(pPlayer.Location.X + pPlayer.Width, pPlayer.Location.Y + pPlayer.Height / 2 - 11);
                    bullet.Size = new Size(50, 27);
                    bullet.Tag = "bullet_right";
                }
                if (shootdir == 4)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_down;
                    else bullet.Image = Properties.Resources.bulletRedDown;
                    bullet.Location = new Point(pPlayer.Location.X + pPlayer.Width / 3 + 5, pPlayer.Location.Y + pPlayer.Height - 3);
                    bullet.Size = new Size(27, 50);
                    bullet.Tag = "bullet_down";
                }
                this.Controls.Add(bullet);
            }
            private void MakeBullet2()
            {
                if (soundEffect == "true") soundShoot.Play();
                PictureBox bullet = new PictureBox();
                bullet.BackColor = Color.Transparent;
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                if (shootdir2 == 1)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_left;
                    else bullet.Image = Properties.Resources.bulletRedLeft;
                    bullet.Location = new Point(pPlayer2.Location.X - 5, pPlayer2.Location.Y + pPlayer2.Height / 2 - 11);
                    bullet.Size = new Size(50, 27);
                    bullet.Tag = "bullet_left2";
                }

                if (shootdir2 == 2)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_up;
                    else bullet.Image = Properties.Resources.bulletRedUp;
                    bullet.Location = new Point(pPlayer2.Location.X + pPlayer2.Width / 3 + 5, pPlayer2.Location.Y - 5);
                    bullet.Size = new Size(27, 50);
                    bullet.Tag = "bullet_up2";
                }

                if (shootdir2 == 3)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_right;
                    else bullet.Image = Properties.Resources.bulletRedRight;
                    bullet.Location = new Point(pPlayer2.Location.X + pPlayer2.Width, pPlayer2.Location.Y + pPlayer2.Height / 2 - 11);
                    bullet.Size = new Size(50, 27);
                    bullet.Tag = "bullet_right2";
                }
                if (shootdir2 == 4)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_down;
                    else bullet.Image = Properties.Resources.bulletRedDown;
                    bullet.Location = new Point(pPlayer2.Location.X + pPlayer2.Width / 3 + 5, pPlayer2.Location.Y + pPlayer2.Height - 3);
                    bullet.Size = new Size(27, 50);
                    bullet.Tag = "bullet_down2";
                }
                this.Controls.Add(bullet);
            }
        




        //PauseRelated
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (phase > 0) GameEngine.Start();
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            GameEngine.Stop();
        }



        //MenuButtons
        private void bPlay_Click(object sender, EventArgs e)
        {
            gbMenu.Visible = true;
            cbp1Ship.Text = "Speedster";
            cbP2Ship.Text = "Speedster";
            this.gbPlayer1.Controls.Add(pPlayer);
            this.gbPlayer2.Controls.Add(pPlayer2);
            pPlayer.Image = Properties.Resources.BlueWingUp;
            pPlayer2.Image = Properties.Resources.BlueWingUp;
            pPlayer.Location = new Point(276, 28);
            pPlayer2.Location = new Point(276, 28);
        }
        private void bOptions_Click(object sender, EventArgs e)
        {
            Options optionsMenu = new Options();
            do
            {
                StreamReader Optionsfile = File.OpenText(@"Data/Options.txt");
                soundEffect = Optionsfile.ReadLine();
                BGMEffect = Optionsfile.ReadLine();
                BGMVolume = int.Parse(Optionsfile.ReadLine());
                Optionsfile.Close();

                backgroundMusic.settings.volume = BGMVolume;
                if (BGMEffect != "true") backgroundMusic.controls.stop();
                else backgroundMusic.controls.play();
                optionsMenu.ShowDialog();
            } while (optionsMenu.Apply == true);
        }
        private void bCredits_Click(object sender, EventArgs e)
        {
            Credits creditsMenu = new Credits();
            creditsMenu.ShowDialog();
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //MenuScreen Hovers
        private void bPlay_MouseHover(object sender, EventArgs e)
        {
            bPlay.Image = Properties.Resources.play_buttons_pressed_blue;
        }
        private void bPlay_MouseLeave(object sender, EventArgs e)
        {
            bPlay.Image = Properties.Resources.play_buttons;
        }

        private void bOptions_MouseLeave(object sender, EventArgs e)
        {
            bOptions.Image = Properties.Resources.optionst_buttons;
        }
        private void bOptions_MouseHover(object sender, EventArgs e)
        {
            bOptions.Image = Properties.Resources.optionst_buttons_pressed;
        }

        private void bCredits_MouseLeave(object sender, EventArgs e)
        {
            bCredits.Image = Properties.Resources.Creditst_buttons;
        }
        private void bCredits_MouseHover(object sender, EventArgs e)
        {
            bCredits.Image = Properties.Resources.Creditst_buttons_pressed;
        }

        private void bExit_MouseLeave(object sender, EventArgs e)
        {
            bExit.Image = Properties.Resources.exit_buttons;
        }
        private void bExit_MouseHover(object sender, EventArgs e)
        {
            bExit.Image = Properties.Resources.exit_buttons_pressed;
        }



        //PlayGameSettings
        private void cbp1Ship_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(p1IsRed == false)
            {
                if (cbp1Ship.SelectedItem.ToString() == "Speedster")
                {
                    pPlayer.Image = Properties.Resources.BlueWingUp;
                }
                else if (cbp1Ship.SelectedItem.ToString() == "Vulture")
                {
                    pPlayer.Image = Properties.Resources.Vulture_Up;
                }
                else if (cbp1Ship.SelectedItem.ToString() == "Destroyer")
                {
                    pPlayer.Image = Properties.Resources.Destroyer_Up;
                }
            }
            else
            {
                if (cbp1Ship.SelectedItem.ToString() == "Speedster")
                {
                    pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                }
                else if (cbp1Ship.SelectedItem.ToString() == "Vulture")
                {
                    pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                }
                else if (cbp1Ship.SelectedItem.ToString() == "Destroyer")
                {
                    pPlayer.Image = Properties.Resources.RedDestroyerUp;
                }
            }

        }
        private void cbP2Ship_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p2IsRed == false)
            {
                if (cbP2Ship.SelectedItem.ToString() == "Speedster")
                {
                    pPlayer2.Image = Properties.Resources.BlueWingUp;
                }
                else if (cbP2Ship.SelectedItem.ToString() == "Vulture")
                {
                    pPlayer2.Image = Properties.Resources.Vulture_Up;
                }
                else if (cbP2Ship.SelectedItem.ToString() == "Destroyer")
                {
                    pPlayer2.Image = Properties.Resources.Destroyer_Up;
                }
            }
            else
            {
                if (cbP2Ship.SelectedItem.ToString() == "Speedster")
                {
                    pPlayer2.Image = Properties.Resources.RedSpeedsterUp;
                }
                else if (cbP2Ship.SelectedItem.ToString() == "Vulture")
                {
                    pPlayer2.Image = Properties.Resources.RedSpeedsterUp;
                }
                else if (cbP2Ship.SelectedItem.ToString() == "Destroyer")
                {
                    pPlayer2.Image = Properties.Resources.RedDestroyerUp;
                }
            }
        }

        private void rb1Player_CheckedChanged(object sender, EventArgs e)
        {

            gbPlayer2.Visible = false;
        }
        private void rb2Players_CheckedChanged(object sender, EventArgs e)
        {
            gbPlayer2.Visible = true;
        }

        private void rbP1Red_CheckedChanged(object sender, EventArgs e)
        {
            if (rbP1Red.Checked == true)
            {
                p1IsRed = true;
                rbP2Red.Checked = false; rbP2Blue.Checked = true;
                if (cbp1Ship.SelectedItem.ToString() == "Speedster")
                       pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                if (cbp1Ship.SelectedItem.ToString() == "Vulture")
                {
                    cbp1Ship.SelectedItem = "Speedster";
                    pPlayer.Image = Properties.Resources.RedSpeedsterUp;
                }

                if (cbp1Ship.SelectedItem.ToString() == "Destroyer")
                    pPlayer.Image = Properties.Resources.RedDestroyerUp;

                cbp1Ship.Items.Remove("Vulture");

            }
            else
            {
                p1IsRed = false;
                if (cbp1Ship.SelectedItem.ToString() == "Speedster")
                    pPlayer.Image = Properties.Resources.BlueWingUp;
                if (cbp1Ship.SelectedItem.ToString() == "Vulture")
                    pPlayer.Image = Properties.Resources.Vulture_Up;
                if (cbp1Ship.SelectedItem.ToString() == "Destroyer")
                    pPlayer.Image = Properties.Resources.Destroyer_Up;

                cbp1Ship.Items.Add("Vulture");
            }

        }
        private void rbP2Red_CheckedChanged(object sender, EventArgs e)
        {
            if (rbP2Red.Checked == true)
            {
                p2IsRed = true;
                rbP1Red.Checked = false; rbP1Blue.Checked = true;
                if (cbP2Ship.SelectedItem.ToString() == "Speedster")
                    pPlayer2.Image = Properties.Resources.RedSpeedsterUp;
                if (cbP2Ship.SelectedItem.ToString() == "Vulture")
                {
                    cbP2Ship.SelectedItem = "Speedster";
                    pPlayer2.Image = Properties.Resources.RedSpeedsterUp;
                }
                if (cbP2Ship.SelectedItem.ToString() == "Destroyer")
                    pPlayer2.Image = Properties.Resources.RedDestroyerUp;

                cbP2Ship.Items.Remove("Vulture");
            }
            else
            {
                p2IsRed = false;
                if (cbP2Ship.SelectedItem.ToString() == "Speedster")
                    pPlayer2.Image = Properties.Resources.BlueWingUp;
                if (cbP2Ship.SelectedItem.ToString() == "Vulture")
                    pPlayer2.Image = Properties.Resources.Vulture_Up;
                if (cbP2Ship.SelectedItem.ToString() == "Destroyer")
                    pPlayer2.Image = Properties.Resources.Destroyer_Up;

                cbP2Ship.Items.Add("Vulture");
            }
        }

        private void rbArcade_CheckedChanged(object sender, EventArgs e)
        {
            txtP1Health.Enabled = false; txtP1Health.Text = "100";
            txtP1Lives.Enabled = false; txtP1Lives.Text = "5";
            rbP1Blue.Enabled = true; rbP1Blue.Checked = true;
            rbP1Red.Enabled = false; rbP1Red.Checked = false; rbP1Red.Visible = false;

            txtP2Health.Enabled = false; txtP2Health.Text = "100";
            txtP2Lives.Enabled = false; txtP2Lives.Text = "5";
            rbP2Blue.Enabled = true; rbP2Blue.Checked = true; rbP2Blue.Visible = true;
            rbP2Red.Enabled = false; rbP2Red.Checked = false; rbP2Red.Visible = false;
            rb1Player.Checked = true;

        }
        private void rbBattle_CheckedChanged(object sender, EventArgs e)
        {
            txtP1Health.Enabled = true;
            txtP1Lives.Enabled = true;
            rbP1Blue.Enabled = true; rbP1Blue.Checked = true;
            rbP1Red.Enabled = false; rbP1Red.Checked = false; rbP1Red.Visible = false;

            txtP2Health.Enabled = true;
            txtP2Lives.Enabled = true;
            rbP2Blue.Enabled = false; rbP2Blue.Checked = false; rbP2Blue.Visible = false;
            rbP2Red.Enabled = true; rbP2Red.Checked = true; rbP2Red.Visible = true;
            rb2Players.Checked = true;
        }
        private void rbSandBox_CheckedChanged(object sender, EventArgs e)
        {
            txtP1Health.Enabled = true;
            txtP1Lives.Enabled = true;
            rbP1Blue.Enabled = true;
            rbP1Red.Enabled = true; rbP1Red.Visible = true;

            txtP2Health.Enabled = true;
            txtP2Lives.Enabled = true;
            rbP2Blue.Enabled = true; rbP2Blue.Visible = true;
            rbP2Red.Enabled = true; rbP2Red.Visible = true;
            rb1Player.Checked = true;
        }

        private void bExitMenu_Click(object sender, EventArgs e)
        {
            gbMenu.Visible = false;
        }
        private void bStartGame_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            p1Health.Visible = true;

            p1Name = txtp1Name.Text;
            p1Ship = cbp1Ship.SelectedItem.ToString();
            p1Health.Maximum = int.Parse(txtP1Health.Text);
            p1Health.Value = int.Parse(txtP1Health.Text);
            p1Live = int.Parse(txtP1Lives.Text);

            if (rbArcade.Checked == true) gameMode = 1;
            else if (rbBattle.Checked == true) gameMode = 2;
            else if (rbSandBox.Checked == true) gameMode = 3;

            if (rb2Players.Checked == true)
            {
                label4.Visible = true;
                p2Health.Visible = true;

                p2Name = txtP2Name.Text;
                p2Ship = cbP2Ship.SelectedItem.ToString();
                p2Health.Maximum = int.Parse(txtP2Health.Text);
                p2Health.Value = int.Parse(txtP2Health.Text);
                p2Live = int.Parse(txtP2Lives.Text);
            }

            gbPlayer1.Controls.Remove(pPlayer);
            gbPlayer2.Controls.Remove(pPlayer2);
            this.Controls.Remove(lblTitle);
            this.Controls.Remove(bExit);
            this.Controls.Remove(bCredits);
            this.Controls.Remove(bOptions);
            this.Controls.Remove(bPlay);
            gbMenu.Visible = false;
            phase = 0;
            GameEngine.Start();
        }
    }
}

