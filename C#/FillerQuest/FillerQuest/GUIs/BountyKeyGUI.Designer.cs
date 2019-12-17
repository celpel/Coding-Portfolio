namespace AscendedRPG.GUIs
{
    partial class BountyKeyGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BountyKeyGUI));
            this.KeyList = new System.Windows.Forms.ListBox();
            this.ExKeyList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // KeyList
            // 
            this.KeyList.FormattingEnabled = true;
            this.KeyList.Location = new System.Drawing.Point(13, 13);
            this.KeyList.Name = "KeyList";
            this.KeyList.Size = new System.Drawing.Size(134, 264);
            this.KeyList.TabIndex = 0;
            // 
            // ExKeyList
            // 
            this.ExKeyList.FormattingEnabled = true;
            this.ExKeyList.Location = new System.Drawing.Point(153, 13);
            this.ExKeyList.Name = "ExKeyList";
            this.ExKeyList.Size = new System.Drawing.Size(134, 264);
            this.ExKeyList.TabIndex = 1;
            // 
            // BountyKeyGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 289);
            this.Controls.Add(this.ExKeyList);
            this.Controls.Add(this.KeyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BountyKeyGUI";
            this.Text = "Bounty Keys";
            this.Load += new System.EventHandler(this.BountyKeyGUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox KeyList;
        private System.Windows.Forms.ListBox ExKeyList;
    }
}