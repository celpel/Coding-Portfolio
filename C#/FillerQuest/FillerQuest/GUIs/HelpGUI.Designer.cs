namespace FillerQuest.GUIs
{
    partial class HelpGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpGUI));
            this.HelpItems = new System.Windows.Forms.ListBox();
            this.HelpDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HelpItems
            // 
            this.HelpItems.FormattingEnabled = true;
            this.HelpItems.Items.AddRange(new object[] {
            "Inventory",
            "Equipment",
            "Relics",
            "Tiers",
            "Dellen Coins",
            "Shop",
            "Enemies",
            "Skills",
            "Combat"});
            this.HelpItems.Location = new System.Drawing.Point(13, 13);
            this.HelpItems.Name = "HelpItems";
            this.HelpItems.Size = new System.Drawing.Size(179, 238);
            this.HelpItems.TabIndex = 0;
            this.HelpItems.SelectedIndexChanged += new System.EventHandler(this.HelpItems_SelectedIndexChanged);
            // 
            // HelpDisplay
            // 
            this.HelpDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HelpDisplay.Location = new System.Drawing.Point(199, 13);
            this.HelpDisplay.Multiline = true;
            this.HelpDisplay.Name = "HelpDisplay";
            this.HelpDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HelpDisplay.Size = new System.Drawing.Size(389, 238);
            this.HelpDisplay.TabIndex = 1;
            this.HelpDisplay.Text = "Click on a topic to find out more about it.";
            // 
            // HelpGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 268);
            this.Controls.Add(this.HelpDisplay);
            this.Controls.Add(this.HelpItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HelpGUI";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HelpItems;
        private System.Windows.Forms.TextBox HelpDisplay;
    }
}