using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.IO;

using WMPLib;

namespace ExtraTerrestrialTurmoil
{
    public partial class MainForm : Form
    {
        Random rand2 = new Random();

        bool left, right, up, down, shoot, p1Dead = false, p1IsRed = false,  p1DisabledWeapons = false;//Moves, shoots, and determines death for player
        bool left2, right2, up2, down2, shoot2, p2Dead = false, p2IsRed = false, p2DisabledWeapons = false; //Moves, shoots, and determines death for player2
        bool start = false, speedt = false, homing = false, killall = false; //In Game Triggers
        int lastdir, shootdir, lastdir2, shootdir2; //Directional Variables used for shooting and decelleration
        string p1Name = " ", p1Ship = "Speedster", p2Name = " ", p2Ship = "Speedster"; //Name of player or ship
        int p1Score, p1Live = 0, p2Score, p2Live = 0, p1Multiplier = 0, p1MCount = 0, p2Multiplier = 0, p2MCount = 0; //In game lives and score
        int p1Invunerable = 0, p2Invulnerable = 0;
        int enemies = 0, maxEnemies = 0, phase = 0, enemySpawn = 3, count = 0, gameMode = 0; //Counters within the GameEngine
        int force, accell, force2, accell2, playerSpeed, playerSpeed2, dashSpeed = 0, speed = 0, enemySpeed = 0; //All variables that control speed
        int p1BulletSpeed = 15, p2BulletSpeed = 15, enemyCheck = 0;
        int firsttime = 0, rnum = 0, instakilltick = 0, PUKillAll = 0;

        int redSwitch = 1, blueSwitch = 1, redEnemies = 0, maxRedEnemies = 3, blueEnemies = 0, maxBlueEnemies = 3, round = 0; //Battle Mode Variables

        //Options Recorder
        public string BGMEffect, soundEffect; public int BGMVolume;


        //Globally Defined Media
        StreamReader OptionsFile = File.OpenText(@"Data/Options.txt");

        PictureBox bPlay = new PictureBox();
        PictureBox bOptions = new PictureBox();
        PictureBox bCredits = new PictureBox();
        PictureBox bExit = new PictureBox();
        PictureBox picPowerUp = new PictureBox();

        WindowsMediaPlayer menu = new WindowsMediaPlayer();
        WindowsMediaPlayer soundExplosion = new WindowsMediaPlayer();
        WindowsMediaPlayer voice = new WindowsMediaPlayer();
        WindowsMediaPlayer hit = new WindowsMediaPlayer();

        SoundPlayer soundShoot = new SoundPlayer(Properties.Resources.RobinHoodShoot);
        SoundPlayer soundShoot2 = new SoundPlayer(Properties.Resources.RobinHoodShoot2);
        SoundPlayer soundShoot3 = new SoundPlayer(Properties.Resources.RobinHoodShoot3);
        SoundPlayer soundShoot4 = new SoundPlayer(Properties.Resources.RobinHoodShoot4);

        //  SoundPlayer soundExplosion = new SoundPlayer(Properties.Resources.RyanSnookExplosion);
        WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();

        //HighScore Data
        string[] p1sNames = new string[10];
        int[] p1sScores = new int[10];
        string[] p2sNames1 = new string[10];
        int[] p2sScores1 = new int[10];

        string[] p2sNames2 = new string[10];



        int[] p2sScores2 = new int[10];




        //Statuses
        int p1Paralzed = 0, p2Paralzed = 0;




        //Initialization - Reads DataFile, Begins Music, Create Start Menu
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;


            //Read Data File
            soundEffect = OptionsFile.ReadLine();
            BGMEffect = OptionsFile.ReadLine();
            BGMVolume = int.Parse(OptionsFile.ReadLine());
            OptionsFile.Close();



            //sounds
            soundExplosion.settings.volume = 20;
            voice.settings.volume = 100;
            menu.settings.volume = 40;
            hit.settings.volume = 30;

            //HighScores
            for (int a = 0; a < 10; a++)
            {
                if (a == 0) { p1sNames[a] = Properties.Settings.Default.Name1; p1sScores[a] = Properties.Settings.Default.Score1; p2sNames1[a] = Properties.Settings.Default.Name11; p2sScores1[a] = Properties.Settings.Default.Score11; p2sNames2[a] = Properties.Settings.Default.Name21; p2sScores2[a] = Properties.Settings.Default.Score21; }
                if (a == 1) { p1sNames[a] = Properties.Settings.Default.Name2; p1sScores[a] = Properties.Settings.Default.Score2; p2sNames1[a] = Properties.Settings.Default.Name12; p2sScores1[a] = Properties.Settings.Default.Score12; p2sNames2[a] = Properties.Settings.Default.Name22; p2sScores2[a] = Properties.Settings.Default.Score22; }
                if (a == 2) { p1sNames[a] = Properties.Settings.Default.Name3; p1sScores[a] = Properties.Settings.Default.Score3; p2sNames1[a] = Properties.Settings.Default.Name13; p2sScores1[a] = Properties.Settings.Default.Score13; p2sNames2[a] = Properties.Settings.Default.Name23; p2sScores2[a] = Properties.Settings.Default.Score23; }
                if (a == 3) { p1sNames[a] = Properties.Settings.Default.Name4; p1sScores[a] = Properties.Settings.Default.Score4; p2sNames1[a] = Properties.Settings.Default.Name14; p2sScores1[a] = Properties.Settings.Default.Score14; p2sNames2[a] = Properties.Settings.Default.Name24; p2sScores2[a] = Properties.Settings.Default.Score24; }
                if (a == 4) { p1sNames[a] = Properties.Settings.Default.Name5; p1sScores[a] = Properties.Settings.Default.Score5; p2sNames1[a] = Properties.Settings.Default.Name15; p2sScores1[a] = Properties.Settings.Default.Score15; p2sNames2[a] = Properties.Settings.Default.Name25; p2sScores2[a] = Properties.Settings.Default.Score25; }
                if (a == 5) { p1sNames[a] = Properties.Settings.Default.Name6; p1sScores[a] = Properties.Settings.Default.Score6; p2sNames1[a] = Properties.Settings.Default.Name16; p2sScores1[a] = Properties.Settings.Default.Score16; p2sNames2[a] = Properties.Settings.Default.Name26; p2sScores2[a] = Properties.Settings.Default.Score26; }
                if (a == 6) { p1sNames[a] = Properties.Settings.Default.Name7; p1sScores[a] = Properties.Settings.Default.Score7; p2sNames1[a] = Properties.Settings.Default.Name17; p2sScores1[a] = Properties.Settings.Default.Score17; p2sNames2[a] = Properties.Settings.Default.Name27; p2sScores2[a] = Properties.Settings.Default.Score27; }
                if (a == 7) { p1sNames[a] = Properties.Settings.Default.Name8; p1sScores[a] = Properties.Settings.Default.Score8; p2sNames1[a] = Properties.Settings.Default.Name18; p2sScores1[a] = Properties.Settings.Default.Score18; p2sNames2[a] = Properties.Settings.Default.Name28; p2sScores2[a] = Properties.Settings.Default.Score28; }
                if (a == 8) { p1sNames[a] = Properties.Settings.Default.Name9; p1sScores[a] = Properties.Settings.Default.Score9; p2sNames1[a] = Properties.Settings.Default.Name19; p2sScores1[a] = Properties.Settings.Default.Score19; p2sNames2[a] = Properties.Settings.Default.Name29; p2sScores2[a] = Properties.Settings.Default.Score29; }
                if (a == 9) { p1sNames[a] = Properties.Settings.Default.Name10; p1sScores[a] = Properties.Settings.Default.Score10; p2sNames1[a] = Properties.Settings.Default.Name20; p2sScores1[a] = Properties.Settings.Default.Score20; p2sNames2[a] = Properties.Settings.Default.Name30; p2sScores2[a] = Properties.Settings.Default.Score30; }
            }

            if (soundEffect == "true") voice.URL = @"Data\Sounds\vJimmySpannProductions.wav";

            pbSplashLogo.Visible = true;
            StartUp.Enabled = true;
            gbResolution.Visible = false;
        }
        private void StartUp_Tick(object sender, EventArgs e)
        {
            pbSplashLogo.Visible = false;
            gbResolution.Visible = true;


            //Begin Music
            var myPlayList = backgroundMusic.playlistCollection.newPlaylist("MyPlayList");
            var mediaItem = backgroundMusic.newMedia(@"BGM/BGM2.mp3");
            for (int a = 0; a <= 5; a++)
            {
                if (a == 1) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM2.mp3");
                if (a == 2) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM3.mp3");
                if (a == 3) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM1.mp3");
                if (a == 4) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM4.mp3");
                if (a == 5) mediaItem = backgroundMusic.newMedia(@"Data/BGM/BGM5.mp3");
                myPlayList.appendItem(mediaItem);
            }
            backgroundMusic.currentPlaylist = myPlayList;
            backgroundMusic.uiMode = "none";
            backgroundMusic.settings.volume = BGMVolume;
            backgroundMusic.settings.setMode("shuffle", true);
            backgroundMusic.settings.setMode("loop", true);
            if (BGMEffect != "true") backgroundMusic.controls.stop();

            StartUp.Enabled = false;
        }


        //GameEngine - The Heart of the Game
        private void EngineIteration(object sender, EventArgs e)
        {
            PlayerMovement();
            PlayerHealthandLives();
            Accelleration();
            Ailments();

            if (gameMode == 2) BattleMode();
            else { PhaseControl(); Multiplier(); }

            foreach (Control enemy in this.Controls)
                   {
                       if (killall) //Triggers the Killall switch that kills everything but players
                       {
                           if (enemy.Tag == "enemy" || enemy.Tag == "RedGuy" || enemy.Tag == "BlueGuy" || enemy.Tag == "bullet_up" || enemy.Tag == "bullet_left" || enemy.Tag == "bullet_down" || enemy.Tag == "bullet_right" || enemy.Tag == "bullet_up2" || enemy.Tag == "bullet_left2" || enemy.Tag == "bullet_down2" || enemy.Tag == "bullet_right2")
                           { Controls.Remove(enemy); enemies = 0; if(PUKillAll == 1) p1Score += 100 * p1Multiplier; if (PUKillAll == 2) p2Score += 100 * p2Multiplier; }
                       }
                       if (enemy.Tag == "enemy")
                       {
                           enemyCheck++;
                           if (enemyCheck > maxEnemies) Controls.Remove(enemy);
                       }


                           EnemyMovement(enemy); //Enemies chase players
                           Collisions(enemy); // Player/enemy, Player/Player, bullet/enemy
                           ObjectMovement(enemy); //Bullets move and hit walls
                   }


            enemyCheck = 0;
            if (phase == -1 || firsttime == 1) QuitSession();
        }



        //Input Control
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(phase > 0) //No key actions unless game is started
            {
                if (e.KeyCode == Keys.Escape) { if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(8).wav"; PauseMenu(); } //Pauses the game

            if (!p1Dead) //Player1's Movement and shooting switches
            {
                if (p1Paralzed <= 0) //Moves player1 if player1 is not paralyzed
                { 
                    if (e.KeyCode == Keys.D) { right = true; }
                    if (e.KeyCode == Keys.A) { left = true; }
                    if (e.KeyCode == Keys.W) { up = true; }
                    if (e.KeyCode == Keys.S) { down = true; }
                }
                if (e.KeyCode == Keys.Space && p1DisabledWeapons == false) { if(!shoot) MakeBullet(); shoot = true; } //Shoots for player1
            }

            if (!p2Dead) //Player2's Movement and shooting switches
            {
                if (p2Paralzed <= 0)//Moves player2 if player2 is not paralyzed
                {
                    if (e.KeyCode == Keys.Left) { left2 = true; }
                    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad0) { up2 = true; }
                    if (e.KeyCode == Keys.Right) { right2 = true; }
                    if (e.KeyCode == Keys.Down) { down2 = true; }
                }
                if (e.KeyCode == Keys.Enter && p2DisabledWeapons == false) { if (!shoot2) MakeBullet2(); shoot2 = true; } //Shoots for player2
            }


            //Only SandBox Commands Below
            if (gameMode == 3) //SandBox Mode is gameMode 3
                {
                    if (e.KeyCode == Keys.Y) //Freezes and Unfreezes enemies. Controlled within EnenmyMovement
                    {
                        if (start == true) start = false;
                        else if (start == false) start = true;
                    }

                    if (e.KeyCode == Keys.U) //Toggles a speed up for all objects
                    {
                        if (speedt == true) { speedt = false; speed = 0; }
                        else if (speedt == false) { speedt = true; speed = 100; }
                    }

                    if (e.KeyCode == Keys.I) //Spawns Enemy in random location
                    {
                        Random rnum = new Random();
                        int sx = rnum.Next(75, this.Width - 75);
                        int sy = rnum.Next(75, this.Height - 100);
                        PictureBox pb2 = new PictureBox();
                        pb2.BackColor = Color.Transparent;
                        pb2.Image = Properties.Resources.enemy;
                        pb2.Location = new Point(sx, sy);
                        pb2.Size = new Size(31, 30);
                        pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb2.Tag = "enemy";
                        this.Controls.Add(pb2);
                    }

                    if (e.KeyCode == Keys.H) //Debug for Homing Missle
                    {
                        if (homing) homing = false;
                        else if (!homing) homing = true;
                    }

                    if (e.KeyCode == Keys.J) //Toggle for Killswitch
                    {
                        if (killall) killall = false;
                        else if (!killall) killall = true;
                    }

                    if (e.KeyCode == Keys.K) //Restarts Arcade Phases within SandBox
                    {
                        p1Score = 0;
                        p2Score = 0;
                        phase = 1;
                        maxEnemies = 1;
                    }

                    if(e.KeyCode == Keys.L)
                    {
                        SpawnPowerUps();
                    }
                } //END  if (gameMode == 3)
            } //END  if (phase > 0) 
        }//Activates anytime a key is pressed down

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Player1 Key Ups
            if (e.KeyCode == Keys.D) { right = false; lastdir = 3; } //Stops Accelleration and Decelleration
            if (e.KeyCode == Keys.A) { left = false; lastdir = 1; }  
            if (e.KeyCode == Keys.W) { up = false; lastdir = 2; }  
            if (e.KeyCode == Keys.S) { down = false; lastdir = 4; } 
            if (e.KeyCode == Keys.Space) { shoot = false; } //When shoot = false the player can shoot again. Used to fix spamming when shoot is held down.

            //Player2 Key Ups
            if (e.KeyCode == Keys.Left) { left2 = false; lastdir2 = 1; } //Stops Accelleration and Decelleration
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad0) { up2 = false; lastdir2 = 2; } 
            if (e.KeyCode == Keys.Right) { right2 = false; lastdir2 = 3; }
            if (e.KeyCode == Keys.Down) { down2 = false; lastdir2 = 4; }
            if (e.KeyCode == Keys.Enter) { shoot2 = false; } //When shoot = false the player can shoot again. Used to fix spamming when shoot is held down.
        }//Activates anytime a key is released



        //Iteration Methods
        private void PlayerMovement()
            {
                //PlayerSpeed
                playerSpeed = force + dashSpeed;
                playerSpeed2 = force2 + dashSpeed;
             

                //Player1 movements - Moves player based on playerSpeed which is calculated by Accelleration.
                        //Activates graphics for boosters when moving.
                if (!p1IsRed) // if player1 is not red
                {
                    if (p1Ship == "Speedster")
                    {
                        if (right == true && left != true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.RightAn; }
                        if (left == true && right != true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.LeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.UpAn; }
                        if (down == true) {pPlayer.Top += playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.DownAn; }
                    }
                    else if (p1Ship == "Vulture")
                    {
                        if (right == true && left != true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.Vulture_RightAn; }
                        if (left == true && right != true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.Vulture_LeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.Vulture_UpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.Vulture_DownAn; }
                    }
                    else if (p1Ship == "Destroyer")
                    {
                        if (right == true && left != true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_RightAn; }
                        if (left == true && right != true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.Destroyer_LeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.Destroyer_UpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.Destroyer_DownAn; }
                    }
                }
                else
                {
                    if (p1Ship == "Speedster")
                    {
                        if (right == true && left != true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterRightAn; }
                        if (left == true && right != true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.RedSpeedsterLeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.RedSpeedsterUpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.RedSpeedsterDownAn; }
                    }
                    else if (p1Ship == "Destroyer")
                    {
                        if (right == true && left != true) { pPlayer.Left += playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerRightAn; }
                        if (left == true && right != true) { pPlayer.Left -= playerSpeed; pPlayer.Image = Properties.Resources.RedDestroyerLeftAn; }
                        if (up == true) { pPlayer.Top -= playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.RedDestroyerUpAn; }
                        if (down == true) { pPlayer.Top += playerSpeed; if (left != true && right != true) pPlayer.Image = Properties.Resources.RedDestroyerDownAn; }
                    }
                }


            //Player2 movements - Moves player based on playerSpeed2 which is calculated by Accelleration.
            //Activates graphics for boosters when moving.
            if (!p2IsRed)
                {
                    if (p2Ship == "Speedster")
                    {
                        if (right2 == true && left2 != true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingRight; }
                        if (left2 == true && right2 != true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.BlueWingLeft; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.BlueWingUp; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.BlueWingDown; }
                    }
                    if (p2Ship == "Vulture")
                    {
                        if (right2 == true && left2 != true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_RightAn; }
                        if (left2 == true && right2 != true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.Vulture_LeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.Vulture_UpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.Vulture_DownAn; }
                    }
                    if (p2Ship == "Destroyer")
                    {
                        if (right2 == true && left2 != true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_RightAn; }
                        if (left2 == true && right2 != true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.Destroyer_LeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.Destroyer_UpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.Destroyer_DownAn; }
                    }
                }
                else
                {
                    if (p2Ship == "Speedster")
                    {
                        if (right2 == true && left2 != true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterRightAn; }
                        if (left2 == true && right2 != true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedSpeedsterLeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.RedSpeedsterUpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.RedSpeedsterDownAn; }
                    }
                    if (p2Ship == "Destroyer")
                    {
                        if (right2 == true && left2 != true) { pPlayer2.Left += playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerRightAn; }
                        if (left2 == true && right2 != true) { pPlayer2.Left -= playerSpeed2; pPlayer2.Image = Properties.Resources.RedDestroyerLeftAn; }
                        if (up2 == true) { pPlayer2.Top -= playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.RedDestroyerUpAn; }
                        if (down2 == true) { pPlayer2.Top += playerSpeed2; if (left2 != true && right2 != true) pPlayer2.Image = Properties.Resources.RedDestroyerDownAn; }
                    }
                }




                //Determines shoot direction within MakeBullet and MakeBullet2
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

            } //Moves players add move animation, determines shoot direction, loops map for players
        private void EnemyMovement(Control enemy)
            {
                //Determines Enemy Speed
                if (speedt) enemySpeed = 6;
                else enemySpeed = 3;

                if(gameMode == 2) //BattleMode Movements Only
                  {
                    if (!p1Dead && enemy.Tag == "RedGuy") //Moves Red Enemies towards Player1
                    {
                        if (enemy.Location.X > pPlayer.Location.X) enemy.Left -= enemySpeed;
                        if (enemy.Location.X < pPlayer.Location.X) enemy.Left += enemySpeed;
                        if (enemy.Location.Y < pPlayer.Location.Y) enemy.Top += enemySpeed;
                        if (enemy.Location.Y > pPlayer.Location.Y) enemy.Top -= enemySpeed;
                    }
                  
                    if (!p2Dead && enemy.Tag == "BlueGuy") //Moves Blue Enemies towards Player2
                    {
                        if (enemy.Location.X > pPlayer2.Location.X) enemy.Left -= enemySpeed;
                        if (enemy.Location.X < pPlayer2.Location.X) enemy.Left += enemySpeed;
                        if (enemy.Location.Y < pPlayer2.Location.Y) enemy.Top += enemySpeed;
                        if (enemy.Location.Y > pPlayer2.Location.Y) enemy.Top -= enemySpeed;
                    }

                }//END  if (gameMode == 2)


                //Deals with enemies within Arcade and SandBox Mode
                if (enemy.Tag == "enemy" || enemy.Tag == "PUWeaponsDisabled")
                {
                    //Calculates the distance between players and enemies
                    double p1Distance = Math.Round(Math.Sqrt(Math.Pow((enemy.Location.X - pPlayer.Location.X), 2) + Math.Pow((enemy.Location.Y - pPlayer.Location.Y), 2)));
                    double p2Distance = Math.Round(Math.Sqrt(Math.Pow((enemy.Location.X - pPlayer2.Location.X), 2) + Math.Pow((enemy.Location.Y - pPlayer2.Location.Y), 2)));

                    //Moves enemies towards players
                    if (start == true) //Enemies won't move if start == false
                    {

                        bool seekP1 = false;
        
                        //Decides which player is closest and chases them
                        if (p1Distance < p2Distance) seekP1 = true;
                        else seekP1 = false;

                        //Determines which players are alive and chases them
                        if (p2Dead || p2IsRed) seekP1 = true;
                        if (p1Dead || p1IsRed) seekP1 = false;


                        if (!p1Dead && seekP1) //Enemy chases player1
                        {
                            if (enemy.Location.X > pPlayer.Location.X) enemy.Left -= enemySpeed;
                            if (enemy.Location.X < pPlayer.Location.X) enemy.Left += enemySpeed;
                            if (enemy.Location.Y < pPlayer.Location.Y) enemy.Top += enemySpeed;
                            if (enemy.Location.Y > pPlayer.Location.Y) enemy.Top -= enemySpeed;
                        }

                        if (!p2Dead && !seekP1) //Enemy chases player2
                        {
                            if (enemy.Location.X > pPlayer2.Location.X) enemy.Left -= enemySpeed;
                            if (enemy.Location.X < pPlayer2.Location.X) enemy.Left += enemySpeed;
                            if (enemy.Location.Y < pPlayer2.Location.Y) enemy.Top += enemySpeed;
                            if (enemy.Location.Y > pPlayer2.Location.Y) enemy.Top -= enemySpeed;
                        }
                    }//END if (start == true)
                } //END if (enemy.tag == "enemy")
            } //Determines enemy speed and where the enemy moves
        private void ObjectMovement(Control enemy)
            {
            p1BulletSpeed = 15;
            if (p1Multiplier >= 2) p1BulletSpeed += 10;
            if (p1Multiplier >= 4) p1BulletSpeed += 10;
            if (p1Multiplier >= 6) p1BulletSpeed += 10;
            if (p1Multiplier >= 7) p1BulletSpeed += 10;

            //If bullet and wall collide + determines bullet speed
            if (enemy is PictureBox && enemy.Tag == "bullet_left")
                {
                    if (enemy.Location.X < 0) Controls.Remove(enemy); //If bullet hits the wall the bullet disappears
                    //if (p1Multiplier <= ) enemy.Left -= 15; //if speed mode is on, speed is doubled
                    if (!homing) enemy.Left -= p1BulletSpeed; //if homingmissles are off, then it will travel normally
            }
                if (enemy is PictureBox && enemy.Tag == "bullet_up")
                {
                 //   if (speedt) enemy.Top -= 15;
                    if (!homing) enemy.Top -= p1BulletSpeed;
                    if (enemy.Location.Y < 0) Controls.Remove(enemy);
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_right")
                {
                    if (enemy.Location.X > this.Width) Controls.Remove(enemy);
                  //  if (speedt) enemy.Left += 15;
                    if (!homing) enemy.Left += p1BulletSpeed;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_down")
                {
                    if (!homing) enemy.Top += p1BulletSpeed;
                //    if (speedt) enemy.Top += 15;
                    if (enemy.Location.Y > this.Height) Controls.Remove(enemy);
                }



                p2BulletSpeed = 15;
                if (p2Multiplier >= 2) p2BulletSpeed += 10;
                if (p2Multiplier >= 4) p2BulletSpeed += 10;
                if (p2Multiplier >= 6) p2BulletSpeed += 10;
                if (p2Multiplier >= 7) p2BulletSpeed += 10;
            
                if (enemy is PictureBox && enemy.Tag == "bullet_left2")
                {
                    if (enemy.Location.X < 0) Controls.Remove(enemy);
                   // if (speedt) enemy.Left -= 15;
                    if (!homing) enemy.Left -= p2BulletSpeed;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_up2")
                {
                   // if (speedt) enemy.Top -= 15;
                    if (!homing) enemy.Top -= p2BulletSpeed;
                    if (enemy.Location.Y < 0) Controls.Remove(enemy);
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_right2")
                {
                    if (enemy.Location.X > this.Width) Controls.Remove(enemy);
                   // if (speedt) enemy.Left += 15;
                    if (!homing) enemy.Left += p2BulletSpeed;
                }
                if (enemy is PictureBox && enemy.Tag == "bullet_down2")
                {
                    //if (speedt) enemy.Top += 15;
                    if (!homing) enemy.Top += p2BulletSpeed;
                    if (enemy.Location.Y > this.Height) Controls.Remove(enemy);
                }
            } //Determines the speed and direction of bullets. Removes bullet if hits a wall. Not Responsible for Homing Missles
       
        private void PlayerHealthandLives()
            {
                if (p1Health.Value == 0) //If player just lost of their health
                {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vComboBreaker.wav";
                if (gameMode == 2) //If battlemode is on
                    {
                         Random rnum = new Random(); //Creates Random Number Generator
                         int sx, sy; //Creates x and y for spawning

                         if (rbSTRandom.Checked == true) //Random Spawn
                         {
                            sx = rnum.Next(75, this.Width - 75);
                            sy = rnum.Next(75, this.Height - 100);
                            pPlayer.Location = new Point(sx, sy);
                         }
                         if (rbSTOuterBounds.Checked == true) //Outer Spawn
                         {
                             int ewns = rnum.Next(1, 4);
                             if (ewns == 1) pPlayer.Location = new Point(75, rnum.Next(75, this.Height - 100));
                             else if (ewns == 2) pPlayer.Location = new Point((this.Width - 75), rnum.Next(75, this.Height - 100));
                             else if (ewns == 3) pPlayer.Location = new Point(this.Width - 75, 75);
                             else if (ewns == 4) pPlayer.Location = new Point(this.Width - 75, (this.Height - 100));
                         }
                         if (rbSTTeamSides.Checked == true) //Team Side Spawn
                         {
                             sx = rnum.Next(70, this.Width / 2);
                             sy = rnum.Next(70, this.Height - 100);
                             pPlayer.Location = new Point(sx, sy);
                         }
                     } //END if(battlemode == 2)
                     else
                     {
                         pPlayer.Location = new Point(233, 109);
                     }

                    p1Live -= 1; //p1MCount = 0;
                    force = 0; accell = 0;
                    p1Health.Value = p1Health.Maximum;

                    if (rbBSRouds.Checked == true && round == 0) { p2Live += 1; p2Health.Value = 0; round = 1; }
                    else round = 0;
                } //END if(p1health.Value == 0)


                if (p2Health.Value == 0) //If player just lost of their health
                {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vComboBreaker.wav";
                if (gameMode == 2) //If battlemode is on
                {
                      Random rnum = new Random(); //Creates Random Number Generator
                      int sx, sy; //Creates x and y for spawning

                      if (rbSTRandom.Checked == true) //Random Spawn
                      {
                         sx = rnum.Next(75, this.Width - 75);
                         sy = rnum.Next(75, this.Height - 100);
                         pPlayer2.Location = new Point(sx, sy);
                      }
                      if (rbSTOuterBounds.Checked == true) //Outer Spawn
                      {
                         int ewns = rnum.Next(1, 4);
                         if (ewns == 1) pPlayer2.Location = new Point(75, rnum.Next(75, this.Height - 100));
                         else if (ewns == 2) pPlayer2.Location = new Point((this.Width - 75), rnum.Next(75, this.Height - 100));
                         else if (ewns == 3) pPlayer2.Location = new Point(this.Width - 75, 75);
                         else if (ewns == 4) pPlayer2.Location = new Point(this.Width - 75, (this.Height - 100));
                      }
                      if (rbSTTeamSides.Checked == true) //Team Side Spawn
                      {
                         sx = rnum.Next(this.Width / 2, this.Width - 100);
                         sy = rnum.Next(70, this.Height - 100);
                         pPlayer2.Location = new Point(sx, sy);
                      }

                    if (rbBSRouds.Checked == true) { p1Live += 1; p1Health.Value = 0; round = 1; }
                    else round = 0;
                } //END if(battlemode == 2)
                else
                 {
                    pPlayer2.Location = new Point(1314, 109);
                 }

                p2Live -= 1; p2MCount = 0;
                force2 = 0; accell2 = 0;
                p2Health.Value = p2Health.Maximum;
                } //END if(p1health.Value == 0)


                if (p1Live <= 0) //If player loses all of their lives
                {
                    pPlayer.Name = "pPlayer_dead";
                    Controls.Remove(pPlayer);
                    p1Dead = true;
                }


                if (p2Live <= 0) //If player loses all of their lives
                {
                    pPlayer2.Name = "pPlayer2_dead";
                    Controls.Remove(pPlayer2);
                    p2Dead = true;
                }


                if (p2Live <= 0 && p1Live <= 0) //If both players are dead
                {
                    phase = -1; //Resets gameEngine for next time

                }

        } //Controls player's health, lives, spawns
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
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.BlueWingLeft;
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
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.BlueWingUp;
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
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.BlueWingRight;
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
                                if (p1Ship == "Speedster") pPlayer.Image = Properties.Resources.BlueWingDown;
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
                if (p1Paralzed > 0) p1Paralzed -= 7;
                if (p2Paralzed > 0) p2Paralzed -= 7;
                if (p1Invunerable > 0) p1Invunerable -= 2;
            }
        private void Collisions(Control enemy)
            {
                //Keeps enemies from overlaying
                foreach (Control enemy2 in this.Controls)
                {
                if (enemy.Tag == "enemy" || enemy.Tag == "RedGuy" || enemy.Tag == "BlueGuy")
                {
                    if (enemy.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        if (enemy2.Tag == "enemy")
                        {
                            if (enemy2.Left < enemy.Location.X + enemy.Width && enemy2.Left > enemy.Location.X + enemy.Width / 2) enemy2.Left += 100;
                            else if (enemy2.Right > enemy.Location.X && enemy2.Right < enemy.Location.X + enemy.Width / 2) enemy2.Left -= 100;
                            else if (enemy2.Top < enemy.Location.Y + enemy.Height && enemy2.Top > enemy.Location.Y + enemy.Height / 2) enemy2.Top += 100;
                            else if (enemy2.Bottom > enemy.Location.Y && enemy2.Bottom < enemy.Location.Y + enemy.Height / 2) enemy2.Top -= 100;
                            
                        }

                        if (enemy2.Tag == "bullet_up" || enemy2.Tag == "bullet_left" || enemy2.Tag == "bullet_down" || enemy2.Tag == "bullet_right")
                        {

                            if (!p1IsRed && enemy.Tag != "BlueGuy")
                            {
                                if (enemies > 0) enemies--;
                                if (soundEffect == "true") { soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav"; }
                                p1Score += 10 * p1Multiplier; p1MCount += 1;
                                if(p1MCount == 62) voice.URL = @"Data\Sounds\vMassacre.wav";
                                if (p1MCount == 100) voice.URL = @"Data\Sounds\vIndestructable.wav";
                                Controls.Remove(enemy);
                               if(p1Multiplier < 5) Controls.Remove(enemy2);



                            }

                        }
                        if (enemy2.Tag == "bullet_up2" || enemy2.Tag == "bullet_left2" || enemy2.Tag == "bullet_down2" || enemy2.Tag == "bullet_right2")
                        {
                            if (enemies > 0)
                            {
                                if (!p2IsRed && enemy.Tag != "RedGuy")
                                {
                                    if (soundEffect == "true") { soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav"; }
                                    Controls.Remove(enemy);
                                    if (p2Multiplier < 5) Controls.Remove(enemy2);
                                    enemies--;
                                    p2Score += 10 * p2Multiplier; p2MCount += 1;
                                    if (p2MCount == 62) voice.URL = @"Data\Sounds\vMassacre.wav";
                                    if (p2MCount == 100) voice.URL = @"Data\Sounds\vIndestructable.wav";
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


                    //If player and enemy collide
                    if (!p1Dead && !p1IsRed && enemy.Tag != "BlueGuy")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                        {
                            if (p1Health.Value > 0 && p1Invunerable <= 0)
                            {
                                if (p1Health.Value < 10) p1Health.Value = 0;
                                else p1Health.Value -= 10;
                            }

                            if (soundEffect == "true") hit.URL = @"Data\Sounds\hybrid-v hit.wav";

                            if (p1Multiplier > 1 && p1Invunerable <= 0)
                            {
                                p1Multiplier--;
                                if (p1Multiplier == 1) p1MCount = 0;
                                else if (p1Multiplier == 2) p1MCount = 11;
                                else if (p1Multiplier == 3) p1MCount = 21;
                                else if (p1Multiplier == 4) p1MCount = 41;
                                else if (p1Multiplier == 5) p1MCount = 61;
                                else if (p1Multiplier == 6) p1MCount = 81;
                            }
                            

                            if (pPlayer.Left < enemy.Location.X + enemy.Width && pPlayer.Left > enemy.Location.X + enemy.Width / 2)
                            {
                                if (p1Invunerable <= 0)
                                {
                                    pPlayer.Left += 50;
                                    p1Invunerable = 50;
                                    playerSpeed = 0;
                                    accell = 0;
                                    //left = false; right = false; up = false; down = false; lastdir = 3;
                                    p1Paralzed = 10;
                                }
                                else enemy.Top -= 50;
                            }
                            else if (pPlayer.Right > enemy.Location.X && pPlayer.Right < enemy.Location.X + enemy.Width)
                            {
                                if (p1Invunerable <= 0)
                                {
                                    pPlayer.Left -= 50;
                                    p1Invunerable = 50;
                                    playerSpeed = 0;
                                    accell = 0;
                                    //left = false; right = false; up = false; down = false; lastdir = 1;
                                    p1Paralzed = 10;
                                }
                                else enemy.Left += 50;
                            }
                            else if (pPlayer.Top < enemy.Location.Y + enemy.Height && pPlayer.Top > enemy.Location.Y + enemy.Height / 2)
                            {
                                if (p1Invunerable <= 0)
                                {
                                    pPlayer.Top += 50;
                                    p1Invunerable = 50;
                                    playerSpeed = 0;
                                    accell = 0;
                                    //left = false; right = false; up = false; down = false; lastdir = 4;
                                    p1Paralzed = 10;
                                }
                                else enemy.Top -= 50;
                            }
                            else if (pPlayer.Bottom > enemy.Location.Y && pPlayer.Bottom < enemy.Location.Y + enemy.Height)
                            {
                                if (p1Invunerable <= 0)
                                {
                                    pPlayer.Top -= 50;
                                    p1Invunerable = 50;
                                    playerSpeed = 0;
                                    accell = 0;
                                    //left = false; right = false; up = false; down = false; lastdir = 2;
                                    p1Paralzed = 10;
                                }
                                else enemy.Top += 50;
                            }
                            else pPlayer.Top -= 50;


                        }//END if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                    }

                    //If player2 and enemy collide
                    if (!p2Dead && enemy.Tag != "RedGuy")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer2.Bounds))
                        {
                            if (pPlayer2.Left < enemy.Location.X + enemy.Width && pPlayer2.Left > enemy.Location.X + enemy.Width / 2)
                            {
                                if (p2Invulnerable <= 0)
                                {
                                    pPlayer2.Left += 50;
                                    p2Invulnerable = 50;
                                    playerSpeed2 = 0;
                                    accell2 = 0;
                                    p2Paralzed = 10;
                                }
                                else enemy.Top -= 50;
                            }
                            else if (pPlayer2.Right > enemy.Location.X && pPlayer2.Right < enemy.Location.X + enemy.Width)
                            {
                                if (p2Invulnerable <= 0)
                                {
                                    pPlayer2.Left -= 50;
                                    p2Invulnerable = 50;
                                    playerSpeed2 = 0;
                                    accell2 = 0;
                                    p2Paralzed = 10;
                                }
                                else enemy.Top += 50;
                            }
                            else if (pPlayer2.Top < enemy.Location.Y + enemy.Height && pPlayer2.Top > enemy.Location.Y + enemy.Height / 2)
                            {
                                if (p2Invulnerable <= 0)
                                {
                                    pPlayer2.Top += 50;
                                    p2Invulnerable = 50;
                                    playerSpeed2 = 0;
                                    accell2 = 0;
                                    p2Paralzed = 10;
                                }
                                else enemy.Top -= 50;
                            }
                            else if (pPlayer2.Bottom > enemy.Location.Y && pPlayer2.Bottom < enemy.Location.Y + enemy.Height)
                            {
                                if (p2Invulnerable <= 0)
                                {
                                    pPlayer2.Top -= 50;
                                    p2Invulnerable = 50;
                                    playerSpeed2 = 0;
                                    accell2 = 0;
                                    p2Paralzed = 10;
                                }
                                else enemy.Top += 50;
                            }
                            else pPlayer2.Top -= 50;
                            if (p2Health.Value > 0)
                            {
                                if (p2Health.Value < 10) p2Health.Value = 0;
                                else p2Health.Value -= 10;
                            }

                            if (soundEffect == "true") hit.URL = @"Data\Sounds\hybrid-v hit.wav";

                            if (p2Multiplier > 1)
                            {
                                p2Multiplier--;
                                if (p2Multiplier == 1) p2MCount = 0;
                                else if (p2Multiplier == 2) p2MCount = 11;
                                else if (p2Multiplier == 3) p2MCount = 21;
                                else if (p2Multiplier == 4) p2MCount = 41;
                                else if (p2Multiplier == 5) p2MCount = 61;
                                else if (p2Multiplier == 6) p2MCount = 81;
                            }

                        }
                    }
                }//END if (enemy.Tag == "enemy")

                if (enemy.Tag == "RedGuy" && enemy2.Tag == "BlueGuy")
                {
                    if (enemy.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        if (enemy2.Left < enemy.Location.X + enemy.Width && enemy2.Left > enemy.Location.X + enemy.Width / 2) enemy2.Left += 100;
                        if (enemy2.Right > enemy.Location.X && enemy2.Right < enemy.Location.X + enemy.Width / 2) enemy2.Left -= 100;
                        if (enemy2.Top < enemy.Location.Y + enemy.Height && enemy2.Top > enemy.Location.Y + enemy.Height / 2) enemy2.Top += 100;
                        if (enemy2.Bottom > enemy.Location.Y && enemy2.Bottom < enemy.Location.Y + enemy.Height / 2) enemy2.Top -= 100;
                    }
                }

                if (enemy.Tag == "BlueGuy" && enemy2.Tag == "BlueGuy")
                {
                    if (enemy.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        if (enemy2.Left < enemy.Location.X + enemy.Width && enemy2.Left > enemy.Location.X + enemy.Width / 2) enemy2.Left += 100;
                        if (enemy2.Right > enemy.Location.X && enemy2.Right < enemy.Location.X + enemy.Width / 2) enemy2.Left -= 100;
                        if (enemy2.Top < enemy.Location.Y + enemy.Height && enemy2.Top > enemy.Location.Y + enemy.Height / 2) enemy2.Top += 100;
                        if (enemy2.Bottom > enemy.Location.Y && enemy2.Bottom < enemy.Location.Y + enemy.Height / 2) enemy2.Top -= 100;
                    }
                }

                if (enemy.Tag == "RedGuy" && enemy2.Tag == "RedGuy")
                {
                    if (enemy.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        if (enemy2.Left < enemy.Location.X + enemy.Width && enemy2.Left > enemy.Location.X + enemy.Width / 2) enemy2.Left += 100;
                        if (enemy2.Right > enemy.Location.X && enemy2.Right < enemy.Location.X + enemy.Width / 2) enemy2.Left -= 100;
                        if (enemy2.Top < enemy.Location.Y + enemy.Height && enemy2.Top > enemy.Location.Y + enemy.Height / 2) enemy2.Top += 100;
                        if (enemy2.Bottom > enemy.Location.Y && enemy2.Bottom < enemy.Location.Y + enemy.Height / 2) enemy2.Top -= 100;
                    }
                }

                        if (enemy2.Tag == "bullet_up" || enemy2.Tag == "bullet_left" || enemy2.Tag == "bullet_down" || enemy2.Tag == "bullet_right")
                    {
                        if (enemy.Tag == "RedGuy" && enemy.Bounds.IntersectsWith(enemy2.Bounds))
                        {
                                if (enemies >= 0) enemies--;
                                if (soundEffect == "true") { soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav"; }
                                p1Score += 10;
                                redEnemies--;
                                Controls.Remove(enemy);
                                Controls.Remove(enemy2);
                        }

                    }
                    if (enemy2.Tag == "bullet_up2" || enemy2.Tag == "bullet_left2" || enemy2.Tag == "bullet_down2" || enemy2.Tag == "bullet_right2")
                    {
                        if (enemy.Tag == "BlueGuy" && enemy.Bounds.IntersectsWith(enemy2.Bounds))
                        {
                                    if (soundEffect == "true") { soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav"; }
                                    Controls.Remove(enemy);
                                    Controls.Remove(enemy2);
                                    enemies--;
                                    p2Score += 10;
                                    blueEnemies--;
                        }
                    }
                  
                }

                if(gameMode == 2)
                {
                    if (enemy.Tag == "bullet_up" || enemy.Tag == "bullet_left" || enemy.Tag == "bullet_down" || enemy.Tag == "bullet_right")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer2.Bounds))
                        {
                            if (soundEffect == "true") soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav";
                            Controls.Remove(enemy);
                            try { p2Health.Value -= 10; }
                            catch { p2Health.Value = 0; }

                        }
            
                    }
                    if (enemy.Tag == "bullet_up2" || enemy.Tag == "bullet_left2" || enemy.Tag == "bullet_down2" || enemy.Tag == "bullet_right2")
                    {
                        if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                        {
                            if (soundEffect == "true") soundExplosion.URL = @"Data\Sounds\RyanSnookExplosion.wav";
                            Controls.Remove(enemy);
                            try { p1Health.Value -= 10; }
                            catch { p1Health.Value = 0; }
                        }
                    }
                }
            if (enemy.Tag == "picPowerUp" || enemy.Tag == "PUWeaponsDisabled")
            {
                if (enemy.Bounds.IntersectsWith(pPlayer.Bounds))
                {
                    PowerUps1();
                }
            }

            if (enemy.Tag == "picPowerUp" || enemy.Tag == "PUWeaponsDisabled")
            {
                if (enemy.Bounds.IntersectsWith(pPlayer2.Bounds))
                {
                    PowerUps2();
                }
            }

        }
        private void QuitSession()
        {
            lblp1Multiplier.Visible = false;
            lblp2Multiplier.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            p1Health.Visible = false;
            p2Health.Visible = false;
            p1MCount = 0;
            p2MCount = 0;
            p1Multiplier = 0;
            p2Multiplier = 0;
            this.Controls.Remove(picPowerUp);

            start = false;
            homing = false;
            speedt = false;
            p1DisabledWeapons = false;
            p2DisabledWeapons = false;
            timPowerUpSpawn.Enabled = false;

            killall = true;

            this.Controls.Remove(pPlayer);
            this.Controls.Remove(pPlayer2);
            count++;

            if (count == 100)
            {

                if (gameMode == 1)
                {
                    if (rb1Player.Checked == true)
                    {
                        if (p1Score > p1sScores[0]) { p1sNames[0] = p1Name; p1sScores[0] = p1Score; }
                        else if (p1Score > p1sScores[1]) { p1sNames[1] = p1Name; p1sScores[1] = p1Score; }
                        else if (p1Score > p1sScores[2]) { p1sNames[2] = p1Name; p1sScores[2] = p1Score; }
                        else if (p1Score > p1sScores[3]) { p1sNames[3] = p1Name; p1sScores[3] = p1Score; }
                        else if (p1Score > p1sScores[4]) { p1sNames[4] = p1Name; p1sScores[4] = p1Score; }
                        else if (p1Score > p1sScores[5]) { p1sNames[5] = p1Name; p1sScores[5] = p1Score; }
                        else if (p1Score > p1sScores[6]) { p1sNames[6] = p1Name; p1sScores[6] = p1Score; }
                        else if (p1Score > p1sScores[7]) { p1sNames[7] = p1Name; p1sScores[7] = p1Score; }
                        else if (p1Score > p1sScores[8]) { p1sNames[8] = p1Name; p1sScores[8] = p1Score; }
                        else if (p1Score > p1sScores[9]) { p1sNames[9] = p1Name; p1sScores[9] = p1Score; }
                    }
                    else
                    {
                        if ((p1Score + p2Score) > (p2sScores1[0] + p2sScores2[0])) { p2sNames1[0] = p1Name; p2sScores1[0] = p1Score; p2sNames2[0] = p2Name; p2sScores2[0] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[1] + p2sScores2[1])) { p2sNames1[1] = p1Name; p2sScores1[1] = p1Score; p2sNames2[1] = p2Name; p2sScores2[1] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[2] + p2sScores2[2])) { p2sNames1[2] = p1Name; p2sScores1[2] = p1Score; p2sNames2[2] = p2Name; p2sScores2[2] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[3] + p2sScores2[3])) { p2sNames1[3] = p1Name; p2sScores1[3] = p1Score; p2sNames2[3] = p2Name; p2sScores2[3] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[4] + p2sScores2[4])) { p2sNames1[4] = p1Name; p2sScores1[4] = p1Score; p2sNames2[4] = p2Name; p2sScores2[4] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[5] + p2sScores2[5])) { p2sNames1[5] = p1Name; p2sScores1[5] = p1Score; p2sNames2[5] = p2Name; p2sScores2[5] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[6] + p2sScores2[6])) { p2sNames1[6] = p1Name; p2sScores1[6] = p1Score; p2sNames2[6] = p2Name; p2sScores2[6] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[7] + p2sScores2[7])) { p2sNames1[7] = p1Name; p2sScores1[7] = p1Score; p2sNames2[7] = p2Name; p2sScores2[7] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[8] + p2sScores2[8])) { p2sNames1[8] = p1Name; p2sScores1[8] = p1Score; p2sNames2[8] = p2Name; p2sScores2[8] = p2Score; }
                        else if ((p1Score + p2Score) > (p2sScores1[9] + p2sScores2[9])) { p2sNames1[9] = p1Name; p2sScores1[9] = p1Score; p2sNames2[9] = p2Name; p2sScores2[9] = p2Score; }

                    }

                    //Updates Highscores to system
                    for (int a = 0; a < 10; a++)
                    {
                        if (a == 0) { Properties.Settings.Default.Name1 = p1sNames[a]; Properties.Settings.Default.Score1 = p1sScores[a]; Properties.Settings.Default.Name11 = p2sNames1[a]; Properties.Settings.Default.Score11 = p2sScores1[a]; Properties.Settings.Default.Name21 = p2sNames2[a]; Properties.Settings.Default.Score21 = p2sScores2[a]; }
                        if (a == 1) { Properties.Settings.Default.Name2 = p1sNames[a]; Properties.Settings.Default.Score2 = p1sScores[a]; Properties.Settings.Default.Name12 = p2sNames1[a]; Properties.Settings.Default.Score12 = p2sScores1[a]; Properties.Settings.Default.Name22 = p2sNames2[a]; Properties.Settings.Default.Score22 = p2sScores2[a]; }
                        if (a == 2) { Properties.Settings.Default.Name3 = p1sNames[a]; Properties.Settings.Default.Score3 = p1sScores[a]; Properties.Settings.Default.Name13 = p2sNames1[a]; Properties.Settings.Default.Score13 = p2sScores1[a]; Properties.Settings.Default.Name23 = p2sNames2[a]; Properties.Settings.Default.Score23 = p2sScores2[a]; }
                        if (a == 3) { Properties.Settings.Default.Name4 = p1sNames[a]; Properties.Settings.Default.Score4 = p1sScores[a]; Properties.Settings.Default.Name14 = p2sNames1[a]; Properties.Settings.Default.Score14 = p2sScores1[a]; Properties.Settings.Default.Name24 = p2sNames2[a]; Properties.Settings.Default.Score24 = p2sScores2[a]; }
                        if (a == 4) { Properties.Settings.Default.Name5 = p1sNames[a]; Properties.Settings.Default.Score5 = p1sScores[a]; Properties.Settings.Default.Name15 = p2sNames1[a]; Properties.Settings.Default.Score15 = p2sScores1[a]; Properties.Settings.Default.Name25 = p2sNames2[a]; Properties.Settings.Default.Score25 = p2sScores2[a]; }
                        if (a == 5) { Properties.Settings.Default.Name6 = p1sNames[a]; Properties.Settings.Default.Score6 = p1sScores[a]; Properties.Settings.Default.Name16 = p2sNames1[a]; Properties.Settings.Default.Score16 = p2sScores1[a]; Properties.Settings.Default.Name26 = p2sNames2[a]; Properties.Settings.Default.Score26 = p2sScores2[a]; }
                        if (a == 6) { Properties.Settings.Default.Name7 = p1sNames[a]; Properties.Settings.Default.Score7 = p1sScores[a]; Properties.Settings.Default.Name17 = p2sNames1[a]; Properties.Settings.Default.Score17 = p2sScores1[a]; Properties.Settings.Default.Name27 = p2sNames2[a]; Properties.Settings.Default.Score27 = p2sScores2[a]; }
                        if (a == 7) { Properties.Settings.Default.Name8 = p1sNames[a]; Properties.Settings.Default.Score8 = p1sScores[a]; Properties.Settings.Default.Name18 = p2sNames1[a]; Properties.Settings.Default.Score18 = p2sScores1[a]; Properties.Settings.Default.Name28 = p2sNames2[a]; Properties.Settings.Default.Score28 = p2sScores2[a]; }
                        if (a == 8) { Properties.Settings.Default.Name9 = p1sNames[a]; Properties.Settings.Default.Score9 = p1sScores[a]; Properties.Settings.Default.Name19 = p2sNames1[a]; Properties.Settings.Default.Score19 = p2sScores1[a]; Properties.Settings.Default.Name29 = p2sNames2[a]; Properties.Settings.Default.Score29 = p2sScores2[a]; }
                        if (a == 9) { Properties.Settings.Default.Name10 = p1sNames[a]; Properties.Settings.Default.Score10 = p1sScores[a]; Properties.Settings.Default.Name20 = p2sNames1[a]; Properties.Settings.Default.Score20 = p2sScores1[a]; Properties.Settings.Default.Name30 = p2sNames2[a]; Properties.Settings.Default.Score30 = p2sScores2[a]; }
                        Properties.Settings.Default.Save();
                    }
                }


                count = 0;
                GameEngine.Stop();
                VictorySequence();
                p1Dead = false;
                p2Dead = false;
                p1Score = 0;
                p2Score = 0;
                left = false; right = false; up = false; down = false;
                left2 = false; right2 = false; up2 = false; down2 = false;
                killall = false;
                gameMode = 0;
                this.Controls.Add(bExit);
                this.Controls.Add(bCredits);
                this.Controls.Add(bOptions);
                this.Controls.Add(bPlay);
                this.Controls.Add(lblTitle);
                if (firsttime == 1) { MessageBox.Show("Sorry.. Weird glitch. Now try."); firsttime = 2; }
            }
        }
       
        
        private void VictorySequence()
        {
            GameOver gameOver = new GameOver();

            if (gameMode == 1)
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vGameOver.wav";
                if (rb2Players.Checked == true)
                {                    
                    gameOver.players2 = true;
                    for (int a = 0; a < 10; a++)
                    { gameOver.p2Scores[a] = (a + 1) + ".\t" + p2sNames1[a] + "\t" + p2sScores1[a] + "\t" + p2sNames2[a] + "\t" + p2sScores2[a] + "\t" + (p2sScores1[a] + p2sScores2[a]); }
                    gameOver.text = p1Name + "'s Score:" + p1Score + "                 " + p2Name + "'s Score:" + p2Score;
                }
                else
                {
                    lbHighScores.Items.Add("ID\tName\tScore");
                    for (int a = 0; a < 10; a++)
                    { gameOver.p1Scores[a] = (a + 1) + ".\t" + p1sNames[a] + "\t" + p1sScores[a]; }
                    gameOver.text = p1Name + "'s Score:" + p1Score;

                }
                gameOver.ShowDialog();
            }

            if(gameMode == 2)
            {
                TextForm textform = new TextForm();
                textform.Text = "Winner!";
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vChampion.wav";
                if (p1Dead) textform.text = "\r\n" + p2Name + " is the winner!";
                if(p2Dead) textform.text = "\r\n" + p1Name + " is the winner!";
                if (p1Dead && p2Dead) { textform.text = "\r\nNo one wins!"; textform.Text = "Draw!"; voice.URL = @"Data\Sounds\vDraw.wav"; }
                if (!p1Dead && !p2Dead) { textform.text = "\r\nNo one wins!"; textform.Text = "Draw!"; voice.URL = @"Data\Sounds\vDraw.wav"; }
                textform.ShowDialog();
            }

            if(gameMode == 3)
            {
                if(p1Dead || p2Dead)
                {
                    TextForm textform = new TextForm();
                    if (soundEffect == "true") voice.URL = @"Data\Sounds\vGameOver.wav";
                    textform.Text = "Game Over";
                    textform.text = "\r\nYou died....";
                    textform.ShowDialog();
                }
            }

        }
        private void Multiplier()
        {
            if (p1Multiplier == 1) { lblp1Multiplier.ForeColor = System.Drawing.Color.AliceBlue; }
            else if (p1Multiplier == 2) lblp1Multiplier.ForeColor = System.Drawing.Color.MediumTurquoise;
            else if (p1Multiplier == 3) lblp1Multiplier.ForeColor = System.Drawing.Color.Blue;
            else if (p1Multiplier == 4) lblp1Multiplier.ForeColor = System.Drawing.Color.Lime;
            else if (p1Multiplier == 5) { lblp1Multiplier.ForeColor = System.Drawing.Color.Yellow;}
            else if (p1Multiplier == 6) lblp1Multiplier.ForeColor = System.Drawing.Color.DarkRed;
            else if (p1Multiplier == 7) lblp1Multiplier.ForeColor = System.Drawing.Color.Red;

                     if (p1MCount <= 10) p1Multiplier = 1;
                else if (p1MCount <= 20) p1Multiplier = 2;
                else if (p1MCount <= 40) p1Multiplier = 3;
                else if (p1MCount <= 60) p1Multiplier = 4;
                else if (p1MCount <= 80) p1Multiplier = 5;
                else if (p1MCount <= 100) p1Multiplier = 6;
                else if (p1MCount > 100) p1Multiplier = 7;
            

                 if (p2Multiplier == 1) lblp2Multiplier.ForeColor = System.Drawing.Color.AliceBlue;
            else if (p2Multiplier == 2) lblp2Multiplier.ForeColor = System.Drawing.Color.MediumTurquoise;
            else if (p2Multiplier == 3) lblp2Multiplier.ForeColor = System.Drawing.Color.Blue;
            else if (p2Multiplier == 4) lblp2Multiplier.ForeColor = System.Drawing.Color.Lime;
            else if (p2Multiplier == 5) lblp2Multiplier.ForeColor = System.Drawing.Color.Yellow;
            else if (p2Multiplier == 6) lblp2Multiplier.ForeColor = System.Drawing.Color.DarkRed;
            else if (p2Multiplier == 7) lblp2Multiplier.ForeColor = System.Drawing.Color.Red;

                 if (p2MCount <= 10) p2Multiplier = 1;
            else if (p2MCount <= 20) p2Multiplier = 2;
            else if (p2MCount <= 40) p2Multiplier = 3;
            else if (p2MCount <= 60) p2Multiplier = 4;
            else if (p2MCount <= 80) p2Multiplier = 5;
            else if (p2MCount <= 100) p2Multiplier = 6;
            else if (p2MCount > 100) p2Multiplier = 7;
        }

        private void SpawnPowerUps()
        {
            rnum = rand2.Next(2, 8);
            int sx = rand2.Next(75, this.Width - 75);  
            int sy = rand2.Next(75, this.Height - 100);

            if (rnum == 1)//????
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.proton;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(64, 56);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            else if(rnum == 2)//Extra Life
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.Life;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(48, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                if(rb2Players.Checked == true)
                {
                    if(p1Live > 1 && !p2Dead) rnum = 4;
                    if (p2Live > 1 && !p1Dead) rnum = 4;
                }
                else if (p1Live > 1) rnum = 4;
            }
            else if (rnum == 3)//Freeze Enemies
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.FreezeEnemies;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(43, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            if (rnum == 4)//Health
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.Health;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(43, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            else if (rnum == 5)//InstaKill
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.InstaKill;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(43, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            else if (rnum == 6)//MaxCombo
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.MaxCombo;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "picPowerUp";
                picPowerUp.Size = new System.Drawing.Size(43, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            else if (rnum == 7)//DisableWeapons
            {
                picPowerUp.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.DisableWeapons;
                picPowerUp.Location = new Point(sx, sy);
                picPowerUp.Tag = "PUWeaponsDisabled";
                picPowerUp.Size = new System.Drawing.Size(43, 49);
                picPowerUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }

            this.Controls.Add(picPowerUp);
        }
        private void PowerUps1()
        {
            if (rnum == 1)//????
            {

            }
            else if (rnum == 2)//Extra Life
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vExtraLife.wav";
                if (p2Dead && rb2Players.Checked == true)
                {
                    p2Live++;
                    this.Controls.Add(pPlayer2);
                    p2Dead = false;
                    p2Health.Value = p2Health.Maximum;
                    pPlayer2.Location = new Point(1314, 109);
                }
                else p1Live++;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 3)//Freeze Enemies
            {
                start = false;
                timPowerUpDuration.Interval = 5000;
                timPowerUpDuration.Enabled = true;
                timPowerUpSpawn.Enabled = false;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 4)//Health
            {
                if (soundEffect == "true") menu.URL = @"Data\Sounds\qubodup-drminky-health.flac";
                p1Health.Value = p1Health.Maximum;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 5)//InstaKill
            {
                if (soundEffect == "true" && instakilltick == 0) voice.URL = @"Data\Sounds\vInstaKill.wav";
                PUKillAll = 1;
                timPowerUpDuration.Interval = 250;
                timPowerUpDuration.Enabled = true;
                timPowerUpSpawn.Enabled = false;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 6)//MaxCombo
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vMaxCombo.wav";
                if (p1Multiplier != 7) p1MCount = 101;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 7)//DisableWeapons
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vWeaponsDisabled.wav";
                p1DisabledWeapons = true;
                timPowerUpDuration.Interval = 5000;
                timPowerUpDuration.Enabled = true;
                timPowerUpSpawn.Enabled = false;
                this.Controls.Remove(picPowerUp);
            }
        }
        private void PowerUps2()
        {
            if (rnum == 1)//????
            {

            }
            else if (rnum == 2)//Extra Life
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vExtraLife.wav";
                if (p1Dead && rb2Players.Checked == true)
                {
                    p1Live++;
                    this.Controls.Add(pPlayer);
                    p1Dead = false;
                    p1Health.Value = p2Health.Maximum;
                    pPlayer.Location = new Point(233, 109);
                }
                else p2Live++;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 3)//Freeze Enemies
            {
                start = false;
                timPowerUpDuration.Interval = 5000;
                timPowerUpDuration.Enabled = true;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 4)//Health
            {
                p2Health.Value = p2Health.Maximum;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 5)//InstaKill
            {
                if (soundEffect == "true" && instakilltick == 0) voice.URL = @"Data\Sounds\vInstaKill.wav";
                PUKillAll = 2;
                timPowerUpDuration.Interval = 250;
                timPowerUpDuration.Enabled = true;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 6)//MaxCombo
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vMaxCombo.wav";
                if (p2Multiplier != 7) p2MCount = 101;
                this.Controls.Remove(picPowerUp);
            }
            else if (rnum == 7)//DisableWeapons
            {
                if (soundEffect == "true") voice.URL = @"Data\Sounds\vWeaponsDisabled.wav";
                p2DisabledWeapons = true;
                timPowerUpDuration.Interval = 5000;
                timPowerUpDuration.Enabled = true;
                this.Controls.Remove(picPowerUp);
            }
        }
        private void timPowerUpDuration_Tick(object sender, EventArgs e)
        {
            if (rnum == 1)//????
            {

            }
            else if (rnum == 2)//Extra Life
            {

            }
            else if (rnum == 3)//Freeze Enemies
            {
                start = true;
                timPowerUpDuration.Enabled = false;
                timPowerUpSpawn.Enabled = true;
            }
            else if (rnum == 4)//Health
            {

            }
            else if (rnum == 5)//InstaKill
            {
                if (killall == false) killall = true;
                instakilltick++;
                if (instakilltick == 10)
                {
                    killall = false;
                    timPowerUpDuration.Enabled = false;
                    timPowerUpSpawn.Enabled = true;
                    instakilltick = 0;
                }
            }
            else if (rnum == 6)//MaxCombo
            {

            }
            else if (rnum == 7)//DisableWeapons
            {
                p1DisabledWeapons = false;
                p2DisabledWeapons = false;
                timPowerUpDuration.Enabled = false;
                timPowerUpSpawn.Enabled = true;
            }
        }
        private void timPowerUpSpawn_Tick(object sender, EventArgs e)
        {
            SpawnPowerUps();
        }

        private void PhaseControl()
            {
                if (gameMode == 3) label2.Text = "Y:Start/Stop U:ToggleSpeed I:AddEnemyPress\n H:Homing J:KillAll K:ResetScore L:SpawnPowerUp";
                else label2.Text = "";
                label3.Text = "Player1: " + p1Name + "\nHealth: \nScore:" + p1Score + "\nLives: " + p1Live + "\nx" + p1Multiplier;
                label4.Text = "Player2: " + p2Name + "\nHealth: \nScore:" + p2Score + "\nLives: " + p2Live + "\nx" + p2Multiplier;
                lblp1Multiplier.Text = "x" + p1Multiplier + " Combo:" + p1MCount;
                lblp2Multiplier.Text = "x" + p2Multiplier + " Combo:" + p2MCount;

            if (phase == 0)
                {

                    this.Controls.Add(pPlayer); p1Dead = false;
                    if (rb2Players.Checked == true) { this.Controls.Add(pPlayer2); p2Dead = false; }

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

                    p1Multiplier = 1; p1MCount = 0;
                    p2Multiplier = 1; p2MCount = 0;
                    timPowerUpSpawn.Interval = 20000;
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

                if (enemySpawn == 1) pb2.Location = new Point(sx, sy); //Random Spawn
                if (enemySpawn == 2) //Outer Spawn
                {
                    if (ewns == 1) pb2.Location = new Point(75, sy);
                    else if (ewns == 2) pb2.Location = new Point((this.Width - 75), sy);
                    else if (ewns == 3) pb2.Location = new Point(sx, 75);
                    else if (ewns == 4) pb2.Location = new Point(sx, (this.Height - 100));
                }
                if (enemySpawn == 3) //Middle Spawn
                {
                    sx = rnum.Next(575, 1100);
                    sy = rnum.Next(225, 700);
                    pb2.Location = new Point(sx, sy);
                }
                    pb2.Size = new Size(31, 30);
                    pb2.Tag = "enemy";
                    this.Controls.Add(pb2);
                    enemies++;


                    if (rb2Players.Checked == false && phase == 1 && p1Score >= 50      ||  rb2Players.Checked == true && phase == 1 && (p1Score + p2Score) >= 150)        { phase++; start = true;   speedt = false;  enemySpawn = 3; } //1 move - slow - middle
                    if (rb2Players.Checked == false && phase == 2 && p1Score >= 150     ||  rb2Players.Checked == true && phase == 2 && (p1Score + p2Score) >= 450)       { phase++; speedt = false; maxEnemies = 2;  enemySpawn = 2; } // 2 move - slow - out
                    if (rb2Players.Checked == false && phase == 3 && p1Score >= 500     ||  rb2Players.Checked == true && phase == 3 && (p1Score + p2Score) >= 1500)       { phase++; speedt = false; maxEnemies = 2;  enemySpawn = 1; } // 2 move - slow - random
                    if (rb2Players.Checked == false && phase == 4 && p1Score >= 600     ||  rb2Players.Checked == true && phase == 4 && (p1Score + p2Score) >= 1800)       { phase++; speedt = false; maxEnemies = 3;  enemySpawn = 3; } // 3 move - slow - middle
                    if (rb2Players.Checked == false && phase == 5 && p1Score >= 1100     ||  rb2Players.Checked == true && phase == 5 && (p1Score + p2Score) >= 3300)       { phase++; speedt = false; maxEnemies = 3;  enemySpawn = 2; } // 3 move - slow - out
                    if (rb2Players.Checked == false && phase == 6 && p1Score >= 2500     ||  rb2Players.Checked == true && phase == 6 && (p1Score + p2Score) >= 7500)       { phase++; speedt = true;  maxEnemies = 3;  enemySpawn = 2; } // 3 move - fast - out
                    if (rb2Players.Checked == false && phase == 7 && p1Score >= 7500     ||  rb2Players.Checked == true && phase == 7 && (p1Score + p2Score) >= 22500)      { phase++; speedt = true;  maxEnemies = 3;  enemySpawn = 3; } // 3 move - fast - middle 
                    if (rb2Players.Checked == false && phase == 8 && p1Score >= 10000    ||  rb2Players.Checked == true && phase == 8 && (p1Score + p2Score) >= 30000)      { phase++; speedt = false; maxEnemies = 3;  enemySpawn = 1; } // 3 move - slow - random
                    if (rb2Players.Checked == false && phase == 9 && p1Score >= 12000    ||  rb2Players.Checked == true && phase == 9 && (p1Score + p2Score) >= 36000)      { phase++; speedt = true;  maxEnemies = 3;  enemySpawn = 1; timPowerUpSpawn.Interval = 20000; } // 3 move - fast - random
                    if (rb2Players.Checked == false && phase == 10 && p1Score >= 13000   ||  rb2Players.Checked == true && phase == 10 && (p1Score + p2Score) >= 39000)     { phase++; speedt = false; maxEnemies = 4;  enemySpawn = 3; } // 4 move - slow - middle
                    if (rb2Players.Checked == false && phase == 11 && p1Score >= 20000   ||  rb2Players.Checked == true && phase == 11 && (p1Score + p2Score) >= 60000)     { phase++; speedt = true;  maxEnemies = 4;  enemySpawn = 3; }
                    if (rb2Players.Checked == false && phase == 12 && p1Score >= 30000   ||  rb2Players.Checked == true && phase == 12 && (p1Score + p2Score) >= 90000)     { phase++; speedt = false; maxEnemies = 4;  enemySpawn = 2; }
                    if (rb2Players.Checked == false && phase == 13 && p1Score >= 33000  ||  rb2Players.Checked == true && phase == 13 && (p1Score + p2Score) >= 99000)     { phase++; speedt = true;  maxEnemies = 4;  enemySpawn = 2; }
                    if (rb2Players.Checked == false && phase == 14 && p1Score >= 37000   ||  rb2Players.Checked == true && phase == 14 && (p1Score + p2Score) >= 111000)     { phase++; speedt = false; maxEnemies = 4;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 15 && p1Score >= 39000   ||  rb2Players.Checked == true && phase == 15 && (p1Score + p2Score) >= 117000)     { phase++; speedt = true;  maxEnemies = 4;  enemySpawn = 1; timPowerUpSpawn.Interval = 15000; }
                    if (rb2Players.Checked == false && phase == 16 && p1Score >= 43000   ||  rb2Players.Checked == true && phase == 16 && (p1Score + p2Score) >= 129000)     { phase++; speedt = false; maxEnemies = 5;  enemySpawn = 3; } // 5 move - slow - middle
                    if (rb2Players.Checked == false && phase == 17 && p1Score >= 50000   ||  rb2Players.Checked == true && phase == 17 && (p1Score + p2Score) >= 150000)     { phase++; speedt = true;  maxEnemies = 5;  enemySpawn = 3; }
                    if (rb2Players.Checked == false && phase == 18 && p1Score >= 55000   ||  rb2Players.Checked == true && phase == 18 && (p1Score + p2Score) >= 165000)   { phase++; speedt = false; maxEnemies = 5;  enemySpawn = 2; }
                    if (rb2Players.Checked == false && phase == 19 && p1Score >= 70000   ||  rb2Players.Checked == true && phase == 19 && (p1Score + p2Score) >= 210000)   { phase++; speedt = true;  maxEnemies = 5;  enemySpawn = 2; }
                    if (rb2Players.Checked == false && phase == 20 && p1Score >= 80000   ||  rb2Players.Checked == true && phase == 20 && (p1Score + p2Score) >= 240000)   { phase++; speedt = false; maxEnemies = 5;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 21 && p1Score >= 90000   ||  rb2Players.Checked == true && phase == 21 && (p1Score + p2Score) >= 270000)   { phase++; speedt = true;  maxEnemies = 5;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 22 && p1Score >= 95000   ||  rb2Players.Checked == true && phase == 22 && (p1Score + p2Score) >= 285000)   { phase++; speedt = true;  maxEnemies = 6;  enemySpawn = 3; timPowerUpSpawn.Interval = 10000; } // 6 is all fast
                    if (rb2Players.Checked == false && phase == 23 && p1Score >= 100000   ||  rb2Players.Checked == true && phase == 23 && (p1Score + p2Score) >= 300000)   { phase++; speedt = true;  maxEnemies = 6;  enemySpawn = 2; }
                    if (rb2Players.Checked == false && phase == 24 && p1Score >= 110000   ||  rb2Players.Checked == true && phase == 24 && (p1Score + p2Score) >= 330000)   { phase++; speedt = true;  maxEnemies = 6;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 25 && p1Score >= 120000   ||  rb2Players.Checked == true && phase == 25 && (p1Score + p2Score) >= 360000)   { phase++; speedt = true;  maxEnemies = 7;  enemySpawn = 1; } //7+ is all fast - random
                    if (rb2Players.Checked == false && phase == 26 && p1Score >= 150000  ||  rb2Players.Checked == true && phase == 26 && (p1Score + p2Score) >= 450000)   { phase++; speedt = true;  maxEnemies = 8;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 27 && p1Score >= 170000  ||  rb2Players.Checked == true && phase == 27 && (p1Score + p2Score) >= 510000)   { phase++; speedt = true;  maxEnemies = 9;  enemySpawn = 1; }
                    if (rb2Players.Checked == false && phase == 28 && p1Score >= 200000 ||  rb2Players.Checked == true && phase == 28 && (p1Score + p2Score) >= 600000)   { phase++; speedt = true;  maxEnemies = 10; enemySpawn = 1; }
            } //if (phase >= 1 && enemies < maxEnemies && !killall && gameMode != 2)
        }
        private void BattleMode()
        {
            //All Phases for Battle
            label3.Text = "Player1: " + p1Name + "\nHealth:" + "\nLives: " + p1Live;
            label4.Text = "Player2: " + p2Name + "\nHealth:" + "\nLives: " + p2Live;


            if (phase == 0)
                {
                p1Dead = false;
                p2Dead = false;
                if (rbHelpersEnabled.Checked == true) { maxBlueEnemies = int.Parse(cbHelperCount.Text); maxRedEnemies = int.Parse(cbHelperCount.Text); }

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

                    pPlayer.Location = new Point(24, 560);
                    pPlayer2.Location = new Point(1501, 458);

                    phase++;
                }

            if (rbHelpersEnabled.Checked == true)
            {
                Random rnum = new Random(); //Creates Random Number Generator
                int sx, sy; //Creates x and y for spawning
                if (redEnemies < maxRedEnemies)
                {
                    if (enemies < 0) enemies = 0;
                    PictureBox pb2 = new PictureBox();
                    pb2.Name = "Enemy";
                    pb2.BackColor = Color.Transparent;
                    pb2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb2.Image = Properties.Resources.enemy;
                    if (rbSTRandom.Checked == true) //Random Spawn
                    {
                        sx = rnum.Next(75, this.Width - 100);
                        sy = rnum.Next(75, this.Height - 100);
                        pb2.Location = new Point(sx, sy);
                    }
                    if (rbSTOuterBounds.Checked == true) //Outer Spawn
                    {
                        int ewns = rnum.Next(1, 4);
                        if (ewns == 1) pb2.Location = new Point(75, rnum.Next(75, this.Height - 100));
                        else if (ewns == 2) pb2.Location = new Point((this.Width - 75), rnum.Next(75, this.Height - 100));
                        else if (ewns == 3) pb2.Location = new Point(this.Width - 75, 75);
                        else if (ewns == 4) pb2.Location = new Point(this.Width - 75, (this.Height - 100));
                    }
                    if (rbSTTeamSides.Checked == true) //Team Side Spawn
                    {
                        sx = rnum.Next(this.Width / 2, this.Width - 100);
                        sy = rnum.Next(70, this.Height - 100);
                        pb2.Location = new Point(sx, sy);
                    }
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
                    if (rbSTRandom.Checked == true) //Random Spawn
                    {
                        sx = rnum.Next(75, this.Width - 100);
                        sy = rnum.Next(75, this.Height - 100);
                        pb2.Location = new Point(sx, sy);
                    }
                    if (rbSTOuterBounds.Checked == true) //Outer Spawn
                    {
                        int ewns = rnum.Next(1, 4);
                        if (ewns == 1) pb2.Location = new Point(75, rnum.Next(75, this.Height - 100));
                        else if (ewns == 2) pb2.Location = new Point((this.Width - 75), rnum.Next(75, this.Height - 100));
                        else if (ewns == 3) pb2.Location = new Point(this.Width - 75, 75);
                        else if (ewns == 4) pb2.Location = new Point(this.Width - 75, (this.Height - 100));
                    }
                    if (rbSTTeamSides.Checked == true) //Team Side Spawn
                    {
                        sx = rnum.Next(75, this.Width / 2);
                        sy = rnum.Next(70, this.Height - 100);
                        pb2.Location = new Point(sx, sy);
                    }
                    pb2.Size = new Size(31, 30);
                    pb2.Tag = "BlueGuy";
                    this.Controls.Add(pb2);
                    blueEnemies++;
                }
            }

            if (p1Dead || p2Dead) { phase = -1; }
        }
       
        private void MakeBullet()
            {

                int x = 0;

                if (soundEffect == "true") { soundShoot.Play(); }
                if (soundEffect == "true" && p1Multiplier >= 3) { soundShoot2.Play(); }
                if (soundEffect == "true" && p1Multiplier >= 5) { soundShoot3.Play(); }
                if (soundEffect == "true" && p1Multiplier >= 7) { soundShoot4.Play(); }
                PictureBox bullet = new PictureBox();
                bullet.BackColor = Color.Transparent;
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                if (shootdir == 1)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_left;
                    else bullet.Image = Properties.Resources.bulletRedLeft;
                    if (p1Multiplier >= 3) { bullet.Size = new Size(75, 40); x = 0; }
                    if (p1Multiplier >= 5) { bullet.Size = new Size(100, 54); x = 0; }
                    if (p1Multiplier >= 6) { bullet.Size = new Size(150, 81); x = 0; }
                    if (p1Multiplier >= 7) { bullet.Size = new Size(250, 135); x = -5; }
                    if (p1Multiplier < 3) { bullet.Size = new Size(50, 27); x = 0; }
                    bullet.Location = new Point(pPlayer.Location.X - bullet.Width, pPlayer.Location.Y + ((pPlayer.Height / 2 + x) - (bullet.Height / 2)));
                    bullet.Tag = "bullet_left";
                }

                if (shootdir == 2)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_up;
                    else bullet.Image = Properties.Resources.bulletRedUp;
                    if (p1Multiplier >= 3) { bullet.Size = new Size(40, 75); x = 0; }
                    if (p1Multiplier >= 5) { bullet.Size = new Size(54, 100); x = 0; }
                    if (p1Multiplier >= 6) { bullet.Size = new Size(81, 150); x = 0; }
                    if (p1Multiplier >= 7) { bullet.Size = new Size(135, 250); x = -5; }
                    if (p1Multiplier < 3) { bullet.Size = new Size(27, 50); x = 0; }
                    bullet.Location = new Point(pPlayer.Location.X + ((pPlayer.Width / 2 + x) - (bullet.Width / 2)) , pPlayer.Location.Y - bullet.Height);
                    bullet.Tag = "bullet_up";
                }

                if (shootdir == 3)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_right;
                    else bullet.Image = Properties.Resources.bulletRedRight;
                    if (p1Multiplier >= 3) { bullet.Size = new Size(75, 40); x = 0; }
                    if (p1Multiplier >= 5) { bullet.Size = new Size(100, 54); x = 0; }
                    if (p1Multiplier >= 6) { bullet.Size = new Size(150, 81); x = 0; }
                    if (p1Multiplier >= 7) { bullet.Size = new Size(250, 135); x = -5; }
                    if (p1Multiplier < 3) { bullet.Size = new Size(50, 27); x = 0; }
                    bullet.Location = new Point(pPlayer.Location.X + pPlayer.Width, pPlayer.Location.Y + ((pPlayer.Height / 2 + x) - (bullet.Height / 2)));
                    bullet.Tag = "bullet_right";
                }
                if (shootdir == 4)
                {
                    if (!p1IsRed) bullet.Image = Properties.Resources.bullet_down;
                    else bullet.Image = Properties.Resources.bulletRedDown;
                    if (p1Multiplier >= 3) { bullet.Size = new Size(40, 75); x = 0; }
                    if (p1Multiplier >= 5) { bullet.Size = new Size(54, 100); x = 0; }
                    if (p1Multiplier >= 6) { bullet.Size = new Size(81, 150); x = 0; }
                    if (p1Multiplier >= 7) { bullet.Size = new Size(135, 250); x = -5; }
                    if (p1Multiplier < 3) { bullet.Size = new Size(27, 50); x = 0; }
                    bullet.Location = new Point(pPlayer.Location.X + ((pPlayer.Width / 2 + x) - (bullet.Width / 2)) , pPlayer.Location.Y + pPlayer.Height);
                    bullet.Tag = "bullet_down";
                }
                this.Controls.Add(bullet);
            }
        private void MakeBullet2()
            {
                int x = 0;
                if (soundEffect == "true") { soundShoot.Play(); }
            if (soundEffect == "true" && p2Multiplier >= 3) { soundShoot2.Play(); }
            if (soundEffect == "true" && p2Multiplier >= 5) { soundShoot3.Play(); }
            if (soundEffect == "true" && p2Multiplier >= 7) { soundShoot4.Play(); }
            PictureBox bullet = new PictureBox();
                bullet.BackColor = Color.Transparent;
                bullet.SizeMode = PictureBoxSizeMode.StretchImage;
                if (shootdir2 == 1)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_left;
                    else bullet.Image = Properties.Resources.bulletRedLeft;
                    if (p2Multiplier >= 3) { bullet.Size = new Size(75, 40); x = 0; }
                    if (p2Multiplier >= 5) { bullet.Size = new Size(100, 54); x = 0; }
                    if (p2Multiplier >= 6) { bullet.Size = new Size(150, 81); x = 0; }
                    if (p2Multiplier >= 7) { bullet.Size = new Size(250, 135); x = -5; }
                    if (p2Multiplier < 3) { bullet.Size = new Size(50, 27); x = 0; }
                    bullet.Location = new Point(pPlayer2.Location.X - bullet.Width, pPlayer2.Location.Y + ((pPlayer2.Height / 2 + x) - (bullet.Height / 2)));
                    bullet.Tag = "bullet_left2";
                }

                if (shootdir2 == 2)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_up;
                    else bullet.Image = Properties.Resources.bulletRedUp;
                    if (p2Multiplier >= 3) { bullet.Size = new Size(40, 75); x = 0; }
                    if (p2Multiplier >= 5) { bullet.Size = new Size(54, 100); x = 0; }
                    if (p2Multiplier >= 6) { bullet.Size = new Size(81, 150); x = 0; }
                    if (p2Multiplier >= 7) { bullet.Size = new Size(135, 250); x = -5; }
                    if (p2Multiplier < 3) { bullet.Size = new Size(27, 50); x = 0; }
                    bullet.Location = new Point(pPlayer2.Location.X + ((pPlayer2.Width / 2 + x) - (bullet.Width / 2)) , pPlayer2.Location.Y - bullet.Height);
                    bullet.Tag = "bullet_up2";
                }

                if (shootdir2 == 3)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_right;
                    else bullet.Image = Properties.Resources.bulletRedRight;
                    if (p2Multiplier >= 3) { bullet.Size = new Size(75, 40); x = 0; }
                    if (p2Multiplier >= 5) { bullet.Size = new Size(100, 54); x = 0; }
                    if (p2Multiplier >= 6) { bullet.Size = new Size(150, 81); x = 0; }
                    if (p2Multiplier >= 7) { bullet.Size = new Size(250, 135); x = -5; }
                    if (p2Multiplier < 3) { bullet.Size = new Size(50, 27); x = 0; }
                    bullet.Location = new Point(pPlayer2.Location.X + pPlayer2.Width, pPlayer2.Location.Y + ((pPlayer2.Height / 2 + x) - (bullet.Height / 2)));
                    bullet.Tag = "bullet_right2";
                }
                if (shootdir2 == 4)
                {
                    if (!p2IsRed) bullet.Image = Properties.Resources.bullet_down;
                    else bullet.Image = Properties.Resources.bulletRedDown;
                    if (p2Multiplier >= 3) { bullet.Size = new Size(40, 75); x = 0; }
                    if (p2Multiplier >= 5) { bullet.Size = new Size(54, 100); x = 0; }
                    if (p2Multiplier >= 6) { bullet.Size = new Size(81, 150); x = 0; }
                    if (p2Multiplier >= 7) { bullet.Size = new Size(135, 250); x = -5; }
                    if (p2Multiplier < 3) { bullet.Size = new Size(27, 50); x = 0; }
                    bullet.Location = new Point(pPlayer2.Location.X + ((pPlayer2.Width / 2 + x) - (bullet.Width / 2)) , pPlayer2.Location.Y + pPlayer2.Height);
                    bullet.Tag = "bullet_down2";
                }
                this.Controls.Add(bullet);
            }
       
        private void PauseMenu()
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
        private void bResOkay_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            //Create Menu
            gbResolution.Visible = false;
            lblTitle.Visible = true;
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vExtraTerrestrialTurmoil.wav";

            // Create bPlay
            bPlay.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.play_buttons;
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
            bOptions.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.optionst_buttons;
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
            bCredits.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.Creditst_buttons;
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
            bExit.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.exit_buttons;
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
        private void bPlay_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            gbMenu.Visible = true;
            this.gbPlayer1.Controls.Add(pPlayer);
            this.gbPlayer2.Controls.Add(pPlayer2);
            pPlayer.Location = new Point(276, 28);
            pPlayer2.Location = new Point(276, 28);
            lbHighScores.Items.Clear();

            if (rb2Players.Checked == true)
            {
                lbHighScores.Items.Add("ID\tP1Name\tScore\tP2Name\tScore\tTotalScore");
                for (int a = 0; a < 10; a++)
                { lbHighScores.Items.Add((a + 1) + ".\t" + p2sNames1[a] + "\t" + p2sScores1[a] + "\t" + p2sNames2[a] + "\t" + p2sScores2[a] + "\t" + (p2sScores1[a] + p2sScores2[a])); }
            }
            else
            {
                lbHighScores.Items.Add("ID\tName\tScore");
                for (int a = 0; a < 10; a++)
                { lbHighScores.Items.Add((a + 1) + ".\t" + p1sNames[a] + "\t" + p1sScores[a]); }
            }

            cbHelperCount.SelectedItem = "1";

        }
        private void bOptions_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
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
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            Credits creditsMenu = new Credits();
            creditsMenu.ShowDialog();
        }
        private void bExit_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            Close();
        }


        //MenuScreen Hovers
        private void bPlay_MouseHover(object sender, EventArgs e)
        {
            bPlay.Image = Properties.Resources.play_buttons_pressed_blue;
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vPlay.wav";
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(4).wav";
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
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vOptions.wav";
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(4).wav";
        }

        private void bCredits_MouseLeave(object sender, EventArgs e)
        {
            bCredits.Image = Properties.Resources.Creditst_buttons;
        }
        private void bCredits_MouseHover(object sender, EventArgs e)
        {
            bCredits.Image = Properties.Resources.Creditst_buttons_pressed;
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vCredits.wav";
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(4).wav";
        }

        private void bExit_MouseLeave(object sender, EventArgs e)
        {
            bExit.Image = Properties.Resources.exit_buttons;
        }
        private void bExit_MouseHover(object sender, EventArgs e)
        {
            bExit.Image = Properties.Resources.exit_buttons_pressed;
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vQuit.wav";
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(4).wav";
        }



        //PlayGameSettings
        private void cbp1Ship_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            if (p1IsRed == false)
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
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
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
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            gbPlayer2.Visible = false;

            lbHighScores.Items.Clear();
            lbHighScores.Items.Add("ID\tName\tScore");
            for (int a = 0; a < 10; a++)
                { lbHighScores.Items.Add((a + 1) + ".\t" + p1sNames[a] + "\t" + p1sScores[a]); }
        }
        private void rb2Players_CheckedChanged(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            gbPlayer2.Visible = true;
            if (rbArcade.Checked == true) { rbP2Red.Enabled = false; rbP2Red.Checked = false; rbP2Red.Visible = false; }
            lbHighScores.Items.Clear();
            lbHighScores.Items.Add("ID\tP1Name\tScore\tP2Name\tScore\tTotalScore");
            for (int a = 0; a < 10; a++)
                { lbHighScores.Items.Add((a + 1) + ".\t" + p2sNames1[a] + "\t" + p2sScores1[a] + "\t" + p2sNames2[a] + "\t" + p2sScores2[a] + "\t" + (p2sScores1[a] + p2sScores2[a])); }
        }

        private void rbP1Red_CheckedChanged(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
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
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
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
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            txtP1Health.Enabled = false; txtP1Health.Text = "100";
            txtP1Lives.Enabled = false; txtP1Lives.Text = "5";
            rbP1Blue.Enabled = true; rbP1Blue.Checked = true;
            rbP1Red.Enabled = false; rbP1Red.Checked = false; rbP1Red.Visible = false;

            txtP2Health.Enabled = false; txtP2Health.Text = "100";
            txtP2Lives.Enabled = false; txtP2Lives.Text = "5";
            rbP2Blue.Enabled = true; rbP2Blue.Checked = true; rbP2Blue.Visible = true;
            rbP2Red.Enabled = false; rbP2Red.Checked = false; rbP2Red.Visible = false;
            rb1Player.Checked = true;

            lbHighScores.Visible = true;
            gbBattleHelpers.Visible = false;
            gbBattleStyle.Visible = false;
            gbBattleSpawn.Visible = false;
            bGMControls.Visible = false;

        }
        private void rbBattle_CheckedChanged(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            txtP1Health.Enabled = true;
            txtP1Lives.Enabled = true;
            rbP1Blue.Enabled = true; rbP1Blue.Checked = true;
            rbP1Red.Enabled = false; rbP1Red.Checked = false; rbP1Red.Visible = false;

            txtP2Health.Enabled = true;
            txtP2Lives.Enabled = true;
            rbP2Blue.Enabled = false; rbP2Blue.Checked = false; rbP2Blue.Visible = false;
            rbP2Red.Enabled = true; rbP2Red.Checked = true; rbP2Red.Visible = true;
            rb2Players.Checked = true;

            lbHighScores.Visible = false;
            gbBattleHelpers.Visible = true;
            gbBattleStyle.Visible = true;
            gbBattleSpawn.Visible = true;
            bGMControls.Visible = false;
        }
        private void rbSandBox_CheckedChanged(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(33).wav";
            txtP1Health.Enabled = true;
            txtP1Lives.Enabled = true;
            rbP1Blue.Enabled = true;
            rbP1Red.Enabled = true; rbP1Red.Visible = true;

            txtP2Health.Enabled = true;
            txtP2Lives.Enabled = true;
            rbP2Blue.Enabled = true; rbP2Blue.Visible = true;
            rbP2Red.Enabled = true; rbP2Red.Visible = true;
            rb1Player.Checked = true;

            lbHighScores.Visible = false;
            gbBattleHelpers.Visible = false;
            gbBattleStyle.Visible = false;
            gbBattleSpawn.Visible = false;
            bGMControls.Visible = true;
        }

        private void bExitMenu_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            gbMenu.Visible = false;
        }
        private void bStartGame_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            if (soundEffect == "true") voice.URL = @"Data\Sounds\vStart.wav";
            try
            {
                
                label3.Visible = true;
                p1Health.Visible = true;
                p1MCount = 0;
                p2MCount = 0;


                p1Name = txtp1Name.Text;
                p1Ship = cbp1Ship.SelectedItem.ToString();
                p1Health.Maximum = int.Parse(txtP1Health.Text);
                p1Health.Value = int.Parse(txtP1Health.Text);
                p1Live = int.Parse(txtP1Lives.Text);

                if (rbArcade.Checked == true) gameMode = 1;
                else if (rbBattle.Checked == true) gameMode = 2;
                else if (rbSandBox.Checked == true) { gameMode = 3; label2.Visible = true; }

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

                if(gameMode != 2)
                {
                    timPowerUpSpawn.Enabled = true;
                    lblp1Multiplier.Visible = true;
                    if(rb2Players.Checked == true) lblp2Multiplier.Visible = true;
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
            catch
            {
                MessageBox.Show("Please enter valid data.");
            }
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
            if (gbMenu.Visible == true) bStartGame.PerformClick();
            bResOkay.Enabled = false;
            if (firsttime == 0) firsttime = 1;
        }

        //Control Guides in PlayGameSettings
           private void bP1Controls_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            TextForm textForm = new TextForm();
            textForm.Text = "Player 1 Controls";
            textForm.text = "Player 1\r\nA: Moves Left\r\nW: Moves Up\r\nD: Moves Right\r\nS: Moves Down\r\nSpace: Fires Missles\r\nA + D + W or D: Turrent Mode";
            textForm.ShowDialog();
        }
           private void bP2Controls_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            TextForm textForm = new TextForm();
            textForm.Text = "Player 2 Controls";
            textForm.text = "Player 2\r\nLeft: Moves Left\r\nUp or 0: Moves Up\r\nRight: Moves Right\r\nDown: Moves Down\r\nEnter: Fires Missles\r\nLeft + Right + Down or 0";
            textForm.ShowDialog();
        }
           private void bGMControls_Click(object sender, EventArgs e)
        {
            if (soundEffect == "true") menu.URL = @"Data\Sounds\FGBS(30).wav";
            TextForm textForm = new TextForm();
            textForm.Text = "Game Master Controls";
            textForm.text = "Game Master\r\nY: Starts/Stops Enemies\r\nU: SpeedUp/SlowDown Enemies\r\nI: Creates Enemy\r\nH: Toggles Homing Missles (buggy)\r\nJ: Toggles KillAll\r\nK: Resets Score        L: Spawns Power Up";
            textForm.ShowDialog();
        }
    }
}

