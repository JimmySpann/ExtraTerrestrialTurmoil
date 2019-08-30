namespace ExtraTerrestrialTurmoil
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.button1 = new System.Windows.Forms.Button();
            this.trackBGMVolume = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbSEOn = new System.Windows.Forms.RadioButton();
            this.rbSEOff = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbBGMEOff = new System.Windows.Forms.RadioButton();
            this.rbBGMEOn = new System.Windows.Forms.RadioButton();
            this.bClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBGMVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 172);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBGMVolume
            // 
            this.trackBGMVolume.Location = new System.Drawing.Point(141, 128);
            this.trackBGMVolume.Margin = new System.Windows.Forms.Padding(5);
            this.trackBGMVolume.Maximum = 100;
            this.trackBGMVolume.Name = "trackBGMVolume";
            this.trackBGMVolume.Size = new System.Drawing.Size(173, 45);
            this.trackBGMVolume.TabIndex = 1;
            this.trackBGMVolume.Value = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sound Effects";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "BGM Volume";
            // 
            // rbSEOn
            // 
            this.rbSEOn.AutoSize = true;
            this.rbSEOn.Location = new System.Drawing.Point(150, 10);
            this.rbSEOn.Name = "rbSEOn";
            this.rbSEOn.Size = new System.Drawing.Size(50, 24);
            this.rbSEOn.TabIndex = 5;
            this.rbSEOn.TabStop = true;
            this.rbSEOn.Text = "On";
            this.rbSEOn.UseVisualStyleBackColor = true;
            this.rbSEOn.CheckedChanged += new System.EventHandler(this.rbSEOn_CheckedChanged);
            // 
            // rbSEOff
            // 
            this.rbSEOff.AutoSize = true;
            this.rbSEOff.Location = new System.Drawing.Point(211, 10);
            this.rbSEOff.Name = "rbSEOff";
            this.rbSEOff.Size = new System.Drawing.Size(52, 24);
            this.rbSEOff.TabIndex = 6;
            this.rbSEOff.TabStop = true;
            this.rbSEOff.Text = "Off";
            this.rbSEOff.UseVisualStyleBackColor = true;
            this.rbSEOff.CheckedChanged += new System.EventHandler(this.rbSEOff_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbSEOff);
            this.groupBox1.Controls.Add(this.rbSEOn);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 41);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rbBGMEOff);
            this.groupBox2.Controls.Add(this.rbBGMEOn);
            this.groupBox2.Location = new System.Drawing.Point(35, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 41);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "BGM Effects";
            // 
            // rbBGMEOff
            // 
            this.rbBGMEOff.AutoSize = true;
            this.rbBGMEOff.Location = new System.Drawing.Point(211, 10);
            this.rbBGMEOff.Name = "rbBGMEOff";
            this.rbBGMEOff.Size = new System.Drawing.Size(52, 24);
            this.rbBGMEOff.TabIndex = 6;
            this.rbBGMEOff.TabStop = true;
            this.rbBGMEOff.Text = "Off";
            this.rbBGMEOff.UseVisualStyleBackColor = true;
            this.rbBGMEOff.CheckedChanged += new System.EventHandler(this.rbBGMEOff_CheckedChanged);
            // 
            // rbBGMEOn
            // 
            this.rbBGMEOn.AutoSize = true;
            this.rbBGMEOn.Location = new System.Drawing.Point(150, 10);
            this.rbBGMEOn.Name = "rbBGMEOn";
            this.rbBGMEOn.Size = new System.Drawing.Size(50, 24);
            this.rbBGMEOn.TabIndex = 5;
            this.rbBGMEOn.TabStop = true;
            this.rbBGMEOn.Text = "On";
            this.rbBGMEOn.UseVisualStyleBackColor = true;
            this.rbBGMEOn.CheckedChanged += new System.EventHandler(this.rbBGMEOn_CheckedChanged);
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(93, 217);
            this.bClose.Margin = new System.Windows.Forms.Padding(5);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(125, 35);
            this.bClose.TabIndex = 9;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // Options
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(326, 278);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.trackBGMVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBGMVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TrackBar trackBGMVolume;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbSEOn;
        private System.Windows.Forms.RadioButton rbSEOff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbBGMEOff;
        private System.Windows.Forms.RadioButton rbBGMEOn;
        private System.Windows.Forms.Button bClose;
    }
}