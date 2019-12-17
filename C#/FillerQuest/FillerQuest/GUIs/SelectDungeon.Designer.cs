using System;

namespace AscendedRPG
{
    partial class SelectDungeon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDungeon));
            this.label1 = new System.Windows.Forms.Label();
            this.GoBack = new System.Windows.Forms.Button();
            this.EmbarkButton = new System.Windows.Forms.Button();
            this.TierBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.TierBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tier";
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(53, 41);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(75, 23);
            this.GoBack.TabIndex = 3;
            this.GoBack.Text = "Go back";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoBack_MouseClick);
            // 
            // EmbarkButton
            // 
            this.EmbarkButton.Location = new System.Drawing.Point(134, 41);
            this.EmbarkButton.Name = "EmbarkButton";
            this.EmbarkButton.Size = new System.Drawing.Size(75, 23);
            this.EmbarkButton.TabIndex = 4;
            this.EmbarkButton.Text = "Embark";
            this.EmbarkButton.UseVisualStyleBackColor = true;
            this.EmbarkButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmbarkButton_MouseClick);
            // 
            // TierBox
            // 
            this.TierBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TierBox.Location = new System.Drawing.Point(43, 15);
            this.TierBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.TierBox.Name = "TierBox";
            this.TierBox.Size = new System.Drawing.Size(166, 20);
            this.TierBox.TabIndex = 5;
            this.TierBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TierBox.ValueChanged += new System.EventHandler(this.TierBox_ValueChanged);
            // 
            // SelectDungeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 72);
            this.Controls.Add(this.TierBox);
            this.Controls.Add(this.EmbarkButton);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDungeon";
            this.Text = "Select Dungeon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectDungeon_FormClosing);
            this.Load += new System.EventHandler(this.SelectDungeon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TierBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.Button EmbarkButton;
        private System.Windows.Forms.NumericUpDown TierBox;
    }
}