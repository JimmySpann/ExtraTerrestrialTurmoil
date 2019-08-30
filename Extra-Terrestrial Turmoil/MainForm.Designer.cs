namespace ExtraTerrestrialTurmoil
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GameEngine = new System.Windows.Forms.Timer(this.components);
            this.pPlayer = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pPlayer2 = new System.Windows.Forms.PictureBox();
            this.p1Health = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.p2Health = new System.Windows.Forms.ProgressBar();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.gbBattleHelpers = new System.Windows.Forms.GroupBox();
            this.rbHelpersDisabled = new System.Windows.Forms.RadioButton();
            this.rbHelpersEnabled = new System.Windows.Forms.RadioButton();
            this.cbHelperCount = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbBattleSpawn = new System.Windows.Forms.GroupBox();
            this.rbSTOuterBounds = new System.Windows.Forms.RadioButton();
            this.rbSTRandom = new System.Windows.Forms.RadioButton();
            this.rbSTTeamSides = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.bStartGame = new System.Windows.Forms.Button();
            this.bExitMenu = new System.Windows.Forms.Button();
            this.gbPlayer2 = new System.Windows.Forms.GroupBox();
            this.txtP2Health = new System.Windows.Forms.TextBox();
            this.txtP2Lives = new System.Windows.Forms.TextBox();
            this.rbP2Red = new System.Windows.Forms.RadioButton();
            this.rbP2Blue = new System.Windows.Forms.RadioButton();
            this.bP2Controls = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbP2Ship = new System.Windows.Forms.ComboBox();
            this.txtP2Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bGMControls = new System.Windows.Forms.Button();
            this.gbPlayer1 = new System.Windows.Forms.GroupBox();
            this.txtP1Health = new System.Windows.Forms.TextBox();
            this.rbP1Red = new System.Windows.Forms.RadioButton();
            this.rbP1Blue = new System.Windows.Forms.RadioButton();
            this.txtP1Lives = new System.Windows.Forms.TextBox();
            this.bP1Controls = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbp1Ship = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtp1Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb1Player = new System.Windows.Forms.RadioButton();
            this.rb2Players = new System.Windows.Forms.RadioButton();
            this.gbGameMode = new System.Windows.Forms.GroupBox();
            this.rbArcade = new System.Windows.Forms.RadioButton();
            this.rbSandBox = new System.Windows.Forms.RadioButton();
            this.rbBattle = new System.Windows.Forms.RadioButton();
            this.gbBattleStyle = new System.Windows.Forms.GroupBox();
            this.rbBSContinuous = new System.Windows.Forms.RadioButton();
            this.rbBSRouds = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHighScores = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbResolution = new System.Windows.Forms.GroupBox();
            this.bResOkay = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.lblp1Multiplier = new System.Windows.Forms.Label();
            this.lblp2Multiplier = new System.Windows.Forms.Label();
            this.timPowerUpDuration = new System.Windows.Forms.Timer(this.components);
            this.timPowerUpSpawn = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbSplashLogo = new System.Windows.Forms.PictureBox();
            this.StartUp = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPlayer2)).BeginInit();
            this.gbMenu.SuspendLayout();
            this.gbBattleHelpers.SuspendLayout();
            this.gbBattleSpawn.SuspendLayout();
            this.gbPlayer2.SuspendLayout();
            this.gbPlayer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbGameMode.SuspendLayout();
            this.gbBattleStyle.SuspendLayout();
            this.gbResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // GameEngine
            // 
            this.GameEngine.Interval = 10;
            this.GameEngine.Tick += new System.EventHandler(this.EngineIteration);
            // 
            // pPlayer
            // 
            this.pPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pPlayer.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.BlueWingUp;
            this.pPlayer.Location = new System.Drawing.Point(276, 28);
            this.pPlayer.Name = "pPlayer";
            this.pPlayer.Size = new System.Drawing.Size(61, 71);
            this.pPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pPlayer.TabIndex = 2;
            this.pPlayer.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(478, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // pPlayer2
            // 
            this.pPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.pPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pPlayer2.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.BlueWingUp;
            this.pPlayer2.Location = new System.Drawing.Point(287, 27);
            this.pPlayer2.Name = "pPlayer2";
            this.pPlayer2.Size = new System.Drawing.Size(61, 71);
            this.pPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pPlayer2.TabIndex = 4;
            this.pPlayer2.TabStop = false;
            // 
            // p1Health
            // 
            this.p1Health.BackColor = System.Drawing.Color.Maroon;
            this.p1Health.Location = new System.Drawing.Point(81, 35);
            this.p1Health.Name = "p1Health";
            this.p1Health.Size = new System.Drawing.Size(100, 16);
            this.p1Health.TabIndex = 5;
            this.p1Health.Value = 100;
            this.p1Health.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1341, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // p2Health
            // 
            this.p2Health.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.p2Health.BackColor = System.Drawing.Color.Maroon;
            this.p2Health.Location = new System.Drawing.Point(1410, 36);
            this.p2Health.Name = "p2Health";
            this.p2Health.Size = new System.Drawing.Size(100, 16);
            this.p2Health.TabIndex = 8;
            this.p2Health.Value = 100;
            this.p2Health.Visible = false;
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.gbBattleHelpers);
            this.gbMenu.Controls.Add(this.gbBattleSpawn);
            this.gbMenu.Controls.Add(this.bStartGame);
            this.gbMenu.Controls.Add(this.bExitMenu);
            this.gbMenu.Controls.Add(this.gbPlayer2);
            this.gbMenu.Controls.Add(this.bGMControls);
            this.gbMenu.Controls.Add(this.gbPlayer1);
            this.gbMenu.Controls.Add(this.groupBox3);
            this.gbMenu.Controls.Add(this.gbGameMode);
            this.gbMenu.Controls.Add(this.gbBattleStyle);
            this.gbMenu.Controls.Add(this.lbHighScores);
            this.gbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbMenu.Location = new System.Drawing.Point(393, 136);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(813, 696);
            this.gbMenu.TabIndex = 9;
            this.gbMenu.TabStop = false;
            this.gbMenu.Visible = false;
            // 
            // gbBattleHelpers
            // 
            this.gbBattleHelpers.Controls.Add(this.rbHelpersDisabled);
            this.gbBattleHelpers.Controls.Add(this.rbHelpersEnabled);
            this.gbBattleHelpers.Controls.Add(this.cbHelperCount);
            this.gbBattleHelpers.Controls.Add(this.label16);
            this.gbBattleHelpers.Controls.Add(this.label15);
            this.gbBattleHelpers.Location = new System.Drawing.Point(20, 515);
            this.gbBattleHelpers.Name = "gbBattleHelpers";
            this.gbBattleHelpers.Size = new System.Drawing.Size(699, 71);
            this.gbBattleHelpers.TabIndex = 14;
            this.gbBattleHelpers.TabStop = false;
            this.gbBattleHelpers.Visible = false;
            // 
            // rbHelpersDisabled
            // 
            this.rbHelpersDisabled.AutoSize = true;
            this.rbHelpersDisabled.Checked = true;
            this.rbHelpersDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHelpersDisabled.Location = new System.Drawing.Point(473, 16);
            this.rbHelpersDisabled.Name = "rbHelpersDisabled";
            this.rbHelpersDisabled.Size = new System.Drawing.Size(97, 24);
            this.rbHelpersDisabled.TabIndex = 4;
            this.rbHelpersDisabled.TabStop = true;
            this.rbHelpersDisabled.Text = "Disabled";
            this.rbHelpersDisabled.UseVisualStyleBackColor = true;
            // 
            // rbHelpersEnabled
            // 
            this.rbHelpersEnabled.AutoSize = true;
            this.rbHelpersEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHelpersEnabled.Location = new System.Drawing.Point(210, 18);
            this.rbHelpersEnabled.Name = "rbHelpersEnabled";
            this.rbHelpersEnabled.Size = new System.Drawing.Size(93, 24);
            this.rbHelpersEnabled.TabIndex = 3;
            this.rbHelpersEnabled.Text = "Enabled";
            this.rbHelpersEnabled.UseVisualStyleBackColor = true;
            // 
            // cbHelperCount
            // 
            this.cbHelperCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHelperCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHelperCount.FormattingEnabled = true;
            this.cbHelperCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbHelperCount.Location = new System.Drawing.Point(128, 44);
            this.cbHelperCount.MaxLength = 1;
            this.cbHelperCount.Name = "cbHelperCount";
            this.cbHelperCount.Size = new System.Drawing.Size(47, 24);
            this.cbHelperCount.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Helper Count:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Helpers:";
            // 
            // gbBattleSpawn
            // 
            this.gbBattleSpawn.Controls.Add(this.rbSTOuterBounds);
            this.gbBattleSpawn.Controls.Add(this.rbSTRandom);
            this.gbBattleSpawn.Controls.Add(this.rbSTTeamSides);
            this.gbBattleSpawn.Controls.Add(this.label17);
            this.gbBattleSpawn.Location = new System.Drawing.Point(20, 587);
            this.gbBattleSpawn.Name = "gbBattleSpawn";
            this.gbBattleSpawn.Size = new System.Drawing.Size(699, 48);
            this.gbBattleSpawn.TabIndex = 14;
            this.gbBattleSpawn.TabStop = false;
            this.gbBattleSpawn.Visible = false;
            // 
            // rbSTOuterBounds
            // 
            this.rbSTOuterBounds.AutoSize = true;
            this.rbSTOuterBounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSTOuterBounds.Location = new System.Drawing.Point(473, 14);
            this.rbSTOuterBounds.Name = "rbSTOuterBounds";
            this.rbSTOuterBounds.Size = new System.Drawing.Size(138, 24);
            this.rbSTOuterBounds.TabIndex = 6;
            this.rbSTOuterBounds.Text = "Outer Bounds";
            this.rbSTOuterBounds.UseVisualStyleBackColor = true;
            // 
            // rbSTRandom
            // 
            this.rbSTRandom.AutoSize = true;
            this.rbSTRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSTRandom.Location = new System.Drawing.Point(352, 14);
            this.rbSTRandom.Name = "rbSTRandom";
            this.rbSTRandom.Size = new System.Drawing.Size(94, 24);
            this.rbSTRandom.TabIndex = 5;
            this.rbSTRandom.Text = "Random";
            this.rbSTRandom.UseVisualStyleBackColor = true;
            // 
            // rbSTTeamSides
            // 
            this.rbSTTeamSides.AutoSize = true;
            this.rbSTTeamSides.Checked = true;
            this.rbSTTeamSides.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSTTeamSides.Location = new System.Drawing.Point(210, 14);
            this.rbSTTeamSides.Name = "rbSTTeamSides";
            this.rbSTTeamSides.Size = new System.Drawing.Size(121, 24);
            this.rbSTTeamSides.TabIndex = 4;
            this.rbSTTeamSides.TabStop = true;
            this.rbSTTeamSides.Text = "Team Sides";
            this.rbSTTeamSides.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Spawn Type:";
            // 
            // bStartGame
            // 
            this.bStartGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bStartGame.Location = new System.Drawing.Point(338, 649);
            this.bStartGame.Name = "bStartGame";
            this.bStartGame.Size = new System.Drawing.Size(139, 41);
            this.bStartGame.TabIndex = 10;
            this.bStartGame.Text = "Start Game";
            this.bStartGame.UseVisualStyleBackColor = true;
            this.bStartGame.Click += new System.EventHandler(this.bStartGame_Click);
            // 
            // bExitMenu
            // 
            this.bExitMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bExitMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExitMenu.Location = new System.Drawing.Point(744, 17);
            this.bExitMenu.Name = "bExitMenu";
            this.bExitMenu.Size = new System.Drawing.Size(63, 27);
            this.bExitMenu.TabIndex = 9;
            this.bExitMenu.Text = "E&xit";
            this.bExitMenu.UseVisualStyleBackColor = true;
            this.bExitMenu.Click += new System.EventHandler(this.bExitMenu_Click);
            // 
            // gbPlayer2
            // 
            this.gbPlayer2.Controls.Add(this.pPlayer2);
            this.gbPlayer2.Controls.Add(this.txtP2Health);
            this.gbPlayer2.Controls.Add(this.txtP2Lives);
            this.gbPlayer2.Controls.Add(this.rbP2Red);
            this.gbPlayer2.Controls.Add(this.rbP2Blue);
            this.gbPlayer2.Controls.Add(this.bP2Controls);
            this.gbPlayer2.Controls.Add(this.label12);
            this.gbPlayer2.Controls.Add(this.label13);
            this.gbPlayer2.Controls.Add(this.label14);
            this.gbPlayer2.Controls.Add(this.cbP2Ship);
            this.gbPlayer2.Controls.Add(this.txtP2Name);
            this.gbPlayer2.Controls.Add(this.label7);
            this.gbPlayer2.Controls.Add(this.label8);
            this.gbPlayer2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbPlayer2.Location = new System.Drawing.Point(414, 184);
            this.gbPlayer2.Name = "gbPlayer2";
            this.gbPlayer2.Size = new System.Drawing.Size(375, 263);
            this.gbPlayer2.TabIndex = 8;
            this.gbPlayer2.TabStop = false;
            this.gbPlayer2.Text = "Player 2";
            this.gbPlayer2.Visible = false;
            // 
            // txtP2Health
            // 
            this.txtP2Health.Enabled = false;
            this.txtP2Health.Location = new System.Drawing.Point(157, 103);
            this.txtP2Health.MaxLength = 4;
            this.txtP2Health.Name = "txtP2Health";
            this.txtP2Health.Size = new System.Drawing.Size(70, 31);
            this.txtP2Health.TabIndex = 19;
            this.txtP2Health.Text = "100";
            // 
            // txtP2Lives
            // 
            this.txtP2Lives.Enabled = false;
            this.txtP2Lives.Location = new System.Drawing.Point(157, 141);
            this.txtP2Lives.MaxLength = 2;
            this.txtP2Lives.Name = "txtP2Lives";
            this.txtP2Lives.Size = new System.Drawing.Size(40, 31);
            this.txtP2Lives.TabIndex = 20;
            this.txtP2Lives.Text = "5";
            // 
            // rbP2Red
            // 
            this.rbP2Red.AutoSize = true;
            this.rbP2Red.Enabled = false;
            this.rbP2Red.Location = new System.Drawing.Point(233, 178);
            this.rbP2Red.Name = "rbP2Red";
            this.rbP2Red.Size = new System.Drawing.Size(72, 29);
            this.rbP2Red.TabIndex = 20;
            this.rbP2Red.Text = "Red";
            this.rbP2Red.UseVisualStyleBackColor = true;
            this.rbP2Red.CheckedChanged += new System.EventHandler(this.rbP2Red_CheckedChanged);
            // 
            // rbP2Blue
            // 
            this.rbP2Blue.AutoSize = true;
            this.rbP2Blue.Checked = true;
            this.rbP2Blue.Location = new System.Drawing.Point(108, 178);
            this.rbP2Blue.Name = "rbP2Blue";
            this.rbP2Blue.Size = new System.Drawing.Size(77, 29);
            this.rbP2Blue.TabIndex = 19;
            this.rbP2Blue.TabStop = true;
            this.rbP2Blue.Text = "Blue";
            this.rbP2Blue.UseVisualStyleBackColor = true;
            // 
            // bP2Controls
            // 
            this.bP2Controls.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bP2Controls.Location = new System.Drawing.Point(126, 219);
            this.bP2Controls.Name = "bP2Controls";
            this.bP2Controls.Size = new System.Drawing.Size(113, 34);
            this.bP2Controls.TabIndex = 15;
            this.bP2Controls.Text = "Controls";
            this.bP2Controls.UseVisualStyleBackColor = true;
            this.bP2Controls.Click += new System.EventHandler(this.bP2Controls_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 25);
            this.label12.TabIndex = 16;
            this.label12.Text = "Team:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "Lives:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 25);
            this.label14.TabIndex = 14;
            this.label14.Text = "Max Health:";
            // 
            // cbP2Ship
            // 
            this.cbP2Ship.FormattingEnabled = true;
            this.cbP2Ship.Items.AddRange(new object[] {
            "Speedster",
            "Vulture",
            "Destroyer"});
            this.cbP2Ship.Location = new System.Drawing.Point(102, 65);
            this.cbP2Ship.Name = "cbP2Ship";
            this.cbP2Ship.Size = new System.Drawing.Size(139, 33);
            this.cbP2Ship.TabIndex = 8;
            this.cbP2Ship.Text = "Speedster";
            this.cbP2Ship.SelectedIndexChanged += new System.EventHandler(this.cbP2Ship_SelectedIndexChanged);
            // 
            // txtP2Name
            // 
            this.txtP2Name.Location = new System.Drawing.Point(101, 31);
            this.txtP2Name.MaxLength = 15;
            this.txtP2Name.Name = "txtP2Name";
            this.txtP2Name.Size = new System.Drawing.Size(140, 31);
            this.txtP2Name.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ship:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Name:";
            // 
            // bGMControls
            // 
            this.bGMControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGMControls.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bGMControls.Location = new System.Drawing.Point(258, 515);
            this.bGMControls.Name = "bGMControls";
            this.bGMControls.Size = new System.Drawing.Size(299, 57);
            this.bGMControls.TabIndex = 11;
            this.bGMControls.Text = "Game Master Controls";
            this.bGMControls.UseVisualStyleBackColor = true;
            this.bGMControls.Visible = false;
            this.bGMControls.Click += new System.EventHandler(this.bGMControls_Click);
            // 
            // gbPlayer1
            // 
            this.gbPlayer1.Controls.Add(this.pPlayer);
            this.gbPlayer1.Controls.Add(this.txtP1Health);
            this.gbPlayer1.Controls.Add(this.rbP1Red);
            this.gbPlayer1.Controls.Add(this.rbP1Blue);
            this.gbPlayer1.Controls.Add(this.txtP1Lives);
            this.gbPlayer1.Controls.Add(this.bP1Controls);
            this.gbPlayer1.Controls.Add(this.label11);
            this.gbPlayer1.Controls.Add(this.label10);
            this.gbPlayer1.Controls.Add(this.label9);
            this.gbPlayer1.Controls.Add(this.cbp1Ship);
            this.gbPlayer1.Controls.Add(this.label6);
            this.gbPlayer1.Controls.Add(this.txtp1Name);
            this.gbPlayer1.Controls.Add(this.label5);
            this.gbPlayer1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbPlayer1.Location = new System.Drawing.Point(20, 184);
            this.gbPlayer1.Name = "gbPlayer1";
            this.gbPlayer1.Size = new System.Drawing.Size(375, 263);
            this.gbPlayer1.TabIndex = 7;
            this.gbPlayer1.TabStop = false;
            this.gbPlayer1.Text = "Player 1";
            // 
            // txtP1Health
            // 
            this.txtP1Health.Enabled = false;
            this.txtP1Health.Location = new System.Drawing.Point(151, 101);
            this.txtP1Health.MaxLength = 4;
            this.txtP1Health.Name = "txtP1Health";
            this.txtP1Health.Size = new System.Drawing.Size(70, 31);
            this.txtP1Health.TabIndex = 15;
            this.txtP1Health.Text = "100";
            // 
            // rbP1Red
            // 
            this.rbP1Red.AutoSize = true;
            this.rbP1Red.Enabled = false;
            this.rbP1Red.Location = new System.Drawing.Point(227, 178);
            this.rbP1Red.Name = "rbP1Red";
            this.rbP1Red.Size = new System.Drawing.Size(72, 29);
            this.rbP1Red.TabIndex = 18;
            this.rbP1Red.Text = "Red";
            this.rbP1Red.UseVisualStyleBackColor = true;
            this.rbP1Red.Visible = false;
            this.rbP1Red.CheckedChanged += new System.EventHandler(this.rbP1Red_CheckedChanged);
            // 
            // rbP1Blue
            // 
            this.rbP1Blue.AutoSize = true;
            this.rbP1Blue.Checked = true;
            this.rbP1Blue.Location = new System.Drawing.Point(102, 178);
            this.rbP1Blue.Name = "rbP1Blue";
            this.rbP1Blue.Size = new System.Drawing.Size(77, 29);
            this.rbP1Blue.TabIndex = 17;
            this.rbP1Blue.TabStop = true;
            this.rbP1Blue.Text = "Blue";
            this.rbP1Blue.UseVisualStyleBackColor = true;
            // 
            // txtP1Lives
            // 
            this.txtP1Lives.Enabled = false;
            this.txtP1Lives.Location = new System.Drawing.Point(151, 138);
            this.txtP1Lives.MaxLength = 2;
            this.txtP1Lives.Name = "txtP1Lives";
            this.txtP1Lives.Size = new System.Drawing.Size(40, 31);
            this.txtP1Lives.TabIndex = 16;
            this.txtP1Lives.Text = "5";
            // 
            // bP1Controls
            // 
            this.bP1Controls.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bP1Controls.Location = new System.Drawing.Point(128, 219);
            this.bP1Controls.Name = "bP1Controls";
            this.bP1Controls.Size = new System.Drawing.Size(113, 34);
            this.bP1Controls.TabIndex = 14;
            this.bP1Controls.Text = "Controls";
            this.bP1Controls.UseVisualStyleBackColor = true;
            this.bP1Controls.Click += new System.EventHandler(this.bP1Controls_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "Team:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Lives:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Max Health:";
            // 
            // cbp1Ship
            // 
            this.cbp1Ship.FormattingEnabled = true;
            this.cbp1Ship.Items.AddRange(new object[] {
            "Speedster",
            "Vulture",
            "Destroyer"});
            this.cbp1Ship.Location = new System.Drawing.Point(102, 62);
            this.cbp1Ship.Name = "cbp1Ship";
            this.cbp1Ship.Size = new System.Drawing.Size(139, 33);
            this.cbp1Ship.TabIndex = 10;
            this.cbp1Ship.Text = "Speedster";
            this.cbp1Ship.SelectedIndexChanged += new System.EventHandler(this.cbp1Ship_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ship:";
            // 
            // txtp1Name
            // 
            this.txtp1Name.Location = new System.Drawing.Point(101, 28);
            this.txtp1Name.MaxLength = 15;
            this.txtp1Name.Name = "txtp1Name";
            this.txtp1Name.Size = new System.Drawing.Size(140, 31);
            this.txtp1Name.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Controls.Add(this.rb1Player);
            this.groupBox3.Controls.Add(this.rb2Players);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(20, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(756, 65);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Players";
            // 
            // rb1Player
            // 
            this.rb1Player.AutoSize = true;
            this.rb1Player.Checked = true;
            this.rb1Player.Location = new System.Drawing.Point(155, 27);
            this.rb1Player.Name = "rb1Player";
            this.rb1Player.Size = new System.Drawing.Size(117, 29);
            this.rb1Player.TabIndex = 1;
            this.rb1Player.TabStop = true;
            this.rb1Player.Text = "1 Player";
            this.rb1Player.UseVisualStyleBackColor = true;
            this.rb1Player.CheckedChanged += new System.EventHandler(this.rb1Player_CheckedChanged);
            // 
            // rb2Players
            // 
            this.rb2Players.AutoSize = true;
            this.rb2Players.Location = new System.Drawing.Point(502, 27);
            this.rb2Players.Name = "rb2Players";
            this.rb2Players.Size = new System.Drawing.Size(129, 29);
            this.rb2Players.TabIndex = 3;
            this.rb2Players.Text = "2 Players";
            this.rb2Players.UseVisualStyleBackColor = true;
            this.rb2Players.CheckedChanged += new System.EventHandler(this.rb2Players_CheckedChanged);
            // 
            // gbGameMode
            // 
            this.gbGameMode.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbGameMode.Controls.Add(this.rbArcade);
            this.gbGameMode.Controls.Add(this.rbSandBox);
            this.gbGameMode.Controls.Add(this.rbBattle);
            this.gbGameMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gbGameMode.Location = new System.Drawing.Point(19, 41);
            this.gbGameMode.Name = "gbGameMode";
            this.gbGameMode.Size = new System.Drawing.Size(756, 65);
            this.gbGameMode.TabIndex = 5;
            this.gbGameMode.TabStop = false;
            this.gbGameMode.Text = "Game Mode";
            // 
            // rbArcade
            // 
            this.rbArcade.AutoSize = true;
            this.rbArcade.Checked = true;
            this.rbArcade.Location = new System.Drawing.Point(156, 27);
            this.rbArcade.Name = "rbArcade";
            this.rbArcade.Size = new System.Drawing.Size(104, 29);
            this.rbArcade.TabIndex = 1;
            this.rbArcade.TabStop = true;
            this.rbArcade.Text = "Arcade";
            this.rbArcade.UseVisualStyleBackColor = true;
            this.rbArcade.CheckedChanged += new System.EventHandler(this.rbArcade_CheckedChanged);
            // 
            // rbSandBox
            // 
            this.rbSandBox.AutoSize = true;
            this.rbSandBox.Location = new System.Drawing.Point(503, 27);
            this.rbSandBox.Name = "rbSandBox";
            this.rbSandBox.Size = new System.Drawing.Size(131, 29);
            this.rbSandBox.TabIndex = 3;
            this.rbSandBox.Text = "Sand Box";
            this.rbSandBox.UseVisualStyleBackColor = true;
            this.rbSandBox.CheckedChanged += new System.EventHandler(this.rbSandBox_CheckedChanged);
            // 
            // rbBattle
            // 
            this.rbBattle.AutoSize = true;
            this.rbBattle.Location = new System.Drawing.Point(339, 25);
            this.rbBattle.Name = "rbBattle";
            this.rbBattle.Size = new System.Drawing.Size(91, 29);
            this.rbBattle.TabIndex = 2;
            this.rbBattle.Text = "Battle";
            this.rbBattle.UseVisualStyleBackColor = true;
            this.rbBattle.CheckedChanged += new System.EventHandler(this.rbBattle_CheckedChanged);
            // 
            // gbBattleStyle
            // 
            this.gbBattleStyle.Controls.Add(this.rbBSContinuous);
            this.gbBattleStyle.Controls.Add(this.rbBSRouds);
            this.gbBattleStyle.Controls.Add(this.label1);
            this.gbBattleStyle.Location = new System.Drawing.Point(20, 467);
            this.gbBattleStyle.Name = "gbBattleStyle";
            this.gbBattleStyle.Size = new System.Drawing.Size(699, 48);
            this.gbBattleStyle.TabIndex = 13;
            this.gbBattleStyle.TabStop = false;
            this.gbBattleStyle.Visible = false;
            // 
            // rbBSContinuous
            // 
            this.rbBSContinuous.AutoSize = true;
            this.rbBSContinuous.Checked = true;
            this.rbBSContinuous.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBSContinuous.Location = new System.Drawing.Point(473, 16);
            this.rbBSContinuous.Name = "rbBSContinuous";
            this.rbBSContinuous.Size = new System.Drawing.Size(118, 24);
            this.rbBSContinuous.TabIndex = 2;
            this.rbBSContinuous.TabStop = true;
            this.rbBSContinuous.Text = "Continuous";
            this.rbBSContinuous.UseVisualStyleBackColor = true;
            // 
            // rbBSRouds
            // 
            this.rbBSRouds.AutoSize = true;
            this.rbBSRouds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBSRouds.Location = new System.Drawing.Point(210, 16);
            this.rbBSRouds.Name = "rbBSRouds";
            this.rbBSRouds.Size = new System.Drawing.Size(89, 24);
            this.rbBSRouds.TabIndex = 1;
            this.rbBSRouds.Text = "Rounds";
            this.rbBSRouds.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Battle Style:";
            // 
            // lbHighScores
            // 
            this.lbHighScores.BackColor = System.Drawing.SystemColors.InfoText;
            this.lbHighScores.ForeColor = System.Drawing.SystemColors.Window;
            this.lbHighScores.FormattingEnabled = true;
            this.lbHighScores.ItemHeight = 25;
            this.lbHighScores.Location = new System.Drawing.Point(19, 467);
            this.lbHighScores.Name = "lbHighScores";
            this.lbHighScores.Size = new System.Drawing.Size(700, 179);
            this.lbHighScores.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Monotype Corsiva", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(323, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(937, 117);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Extra-Terrestrial Turmoil";
            this.toolTip1.SetToolTip(this.lblTitle, "Can\'t see Start Button? Click me!");
            this.lblTitle.Visible = false;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // gbResolution
            // 
            this.gbResolution.Controls.Add(this.bResOkay);
            this.gbResolution.Controls.Add(this.label18);
            this.gbResolution.Location = new System.Drawing.Point(501, 174);
            this.gbResolution.Name = "gbResolution";
            this.gbResolution.Size = new System.Drawing.Size(588, 303);
            this.gbResolution.TabIndex = 11;
            this.gbResolution.TabStop = false;
            this.gbResolution.Visible = false;
            // 
            // bResOkay
            // 
            this.bResOkay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bResOkay.Location = new System.Drawing.Point(231, 230);
            this.bResOkay.Name = "bResOkay";
            this.bResOkay.Size = new System.Drawing.Size(137, 51);
            this.bResOkay.TabIndex = 1;
            this.bResOkay.Text = "Okay";
            this.bResOkay.UseVisualStyleBackColor = true;
            this.bResOkay.Click += new System.EventHandler(this.bResOkay_Click);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.Control;
            this.label18.Location = new System.Drawing.Point(35, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(524, 86);
            this.label18.TabIndex = 0;
            this.label18.Text = "For best experience use resolution of 1600x900.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblp1Multiplier
            // 
            this.lblp1Multiplier.AutoSize = true;
            this.lblp1Multiplier.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblp1Multiplier.Location = new System.Drawing.Point(9, 90);
            this.lblp1Multiplier.Name = "lblp1Multiplier";
            this.lblp1Multiplier.Size = new System.Drawing.Size(67, 20);
            this.lblp1Multiplier.TabIndex = 12;
            this.lblp1Multiplier.Text = "label19";
            this.lblp1Multiplier.Visible = false;
            // 
            // lblp2Multiplier
            // 
            this.lblp2Multiplier.AutoSize = true;
            this.lblp2Multiplier.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblp2Multiplier.Location = new System.Drawing.Point(1354, 90);
            this.lblp2Multiplier.Name = "lblp2Multiplier";
            this.lblp2Multiplier.Size = new System.Drawing.Size(67, 20);
            this.lblp2Multiplier.TabIndex = 13;
            this.lblp2Multiplier.Text = "label20";
            this.lblp2Multiplier.Visible = false;
            // 
            // timPowerUpDuration
            // 
            this.timPowerUpDuration.Tick += new System.EventHandler(this.timPowerUpDuration_Tick);
            // 
            // timPowerUpSpawn
            // 
            this.timPowerUpSpawn.Interval = 10000;
            this.timPowerUpSpawn.Tick += new System.EventHandler(this.timPowerUpSpawn_Tick);
            // 
            // pbSplashLogo
            // 
            this.pbSplashLogo.Image = global::ExtraTerrestrialTurmoil.Properties.Resources.SplashLogo;
            this.pbSplashLogo.Location = new System.Drawing.Point(399, 243);
            this.pbSplashLogo.Name = "pbSplashLogo";
            this.pbSplashLogo.Size = new System.Drawing.Size(754, 249);
            this.pbSplashLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSplashLogo.TabIndex = 15;
            this.pbSplashLogo.TabStop = false;
            // 
            // StartUp
            // 
            this.StartUp.Interval = 4000;
            this.StartUp.Tick += new System.EventHandler(this.StartUp_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::ExtraTerrestrialTurmoil.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1588, 865);
            this.Controls.Add(this.pbSplashLogo);
            this.Controls.Add(this.lblp2Multiplier);
            this.Controls.Add(this.lblp1Multiplier);
            this.Controls.Add(this.gbResolution);
            this.Controls.Add(this.p2Health);
            this.Controls.Add(this.p1Health);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extra-Terrestrial Turmoil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pPlayer2)).EndInit();
            this.gbMenu.ResumeLayout(false);
            this.gbBattleHelpers.ResumeLayout(false);
            this.gbBattleHelpers.PerformLayout();
            this.gbBattleSpawn.ResumeLayout(false);
            this.gbBattleSpawn.PerformLayout();
            this.gbPlayer2.ResumeLayout(false);
            this.gbPlayer2.PerformLayout();
            this.gbPlayer1.ResumeLayout(false);
            this.gbPlayer1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbGameMode.ResumeLayout(false);
            this.gbGameMode.PerformLayout();
            this.gbBattleStyle.ResumeLayout(false);
            this.gbBattleStyle.PerformLayout();
            this.gbResolution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplashLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pPlayer2;
        private System.Windows.Forms.ProgressBar p1Health;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar p2Health;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.RadioButton rbBattle;
        private System.Windows.Forms.RadioButton rbArcade;
        private System.Windows.Forms.RadioButton rbSandBox;
        private System.Windows.Forms.GroupBox gbPlayer2;
        private System.Windows.Forms.GroupBox gbPlayer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb1Player;
        private System.Windows.Forms.RadioButton rb2Players;
        private System.Windows.Forms.GroupBox gbGameMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbP2Ship;
        private System.Windows.Forms.TextBox txtP2Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbp1Ship;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtp1Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bP2Controls;
        private System.Windows.Forms.TextBox txtP1Lives;
        private System.Windows.Forms.TextBox txtP1Health;
        private System.Windows.Forms.Button bP1Controls;
        private System.Windows.Forms.TextBox txtP2Lives;
        private System.Windows.Forms.TextBox txtP2Health;
        private System.Windows.Forms.RadioButton rbP2Red;
        private System.Windows.Forms.RadioButton rbP2Blue;
        private System.Windows.Forms.RadioButton rbP1Red;
        private System.Windows.Forms.RadioButton rbP1Blue;
        private System.Windows.Forms.Button bStartGame;
        private System.Windows.Forms.Button bExitMenu;
        public System.Windows.Forms.Timer GameEngine;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lbHighScores;
        private System.Windows.Forms.GroupBox gbBattleHelpers;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbBattleStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbBattleSpawn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rbBSRouds;
        private System.Windows.Forms.ComboBox cbHelperCount;
        private System.Windows.Forms.RadioButton rbBSContinuous;
        private System.Windows.Forms.RadioButton rbSTOuterBounds;
        private System.Windows.Forms.RadioButton rbSTRandom;
        private System.Windows.Forms.RadioButton rbSTTeamSides;
        private System.Windows.Forms.RadioButton rbHelpersDisabled;
        private System.Windows.Forms.RadioButton rbHelpersEnabled;
        private System.Windows.Forms.Button bGMControls;
        private System.Windows.Forms.GroupBox gbResolution;
        private System.Windows.Forms.Button bResOkay;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblp1Multiplier;
        private System.Windows.Forms.Label lblp2Multiplier;
        private System.Windows.Forms.Timer timPowerUpDuration;
        private System.Windows.Forms.Timer timPowerUpSpawn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pbSplashLogo;
        private System.Windows.Forms.Timer StartUp;
    }
}

