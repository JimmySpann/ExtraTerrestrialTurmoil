namespace ExtraTerrestrialTurmoil
{
    partial class GameOver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOver));
            this.button1 = new System.Windows.Forms.Button();
            this.lbHighScores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(300, 421);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Okay";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbHighScores
            // 
            this.lbHighScores.BackColor = System.Drawing.SystemColors.InfoText;
            this.lbHighScores.ForeColor = System.Drawing.SystemColors.Window;
            this.lbHighScores.FormattingEnabled = true;
            this.lbHighScores.ItemHeight = 25;
            this.lbHighScores.Location = new System.Drawing.Point(17, 100);
            this.lbHighScores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbHighScores.Name = "lbHighScores";
            this.lbHighScores.Size = new System.Drawing.Size(736, 304);
            this.lbHighScores.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(735, 64);
            this.label1.TabIndex = 14;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(767, 490);
            this.Controls.Add(this.lbHighScores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOver";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameOver";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbHighScores;
        private System.Windows.Forms.Label label1;
    }
}