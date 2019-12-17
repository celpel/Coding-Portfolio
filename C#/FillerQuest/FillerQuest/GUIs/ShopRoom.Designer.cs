namespace AscendedRPG.GUIs
{
    partial class ShopRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopRoom));
            this.VendorPicture = new System.Windows.Forms.PictureBox();
            this.VendorTextBox = new System.Windows.Forms.TextBox();
            this.VendorWares = new System.Windows.Forms.ListBox();
            this.PurchaseButton = new System.Windows.Forms.Button();
            this.PlayerCoins = new System.Windows.Forms.TextBox();
            this.InformationBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reRollWaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charmRadio = new System.Windows.Forms.RadioButton();
            this.keyRadio = new System.Windows.Forms.RadioButton();
            this.itemRadio = new System.Windows.Forms.RadioButton();
            this.allRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.VendorPicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VendorPicture
            // 
            this.VendorPicture.Location = new System.Drawing.Point(3, 27);
            this.VendorPicture.Name = "VendorPicture";
            this.VendorPicture.Size = new System.Drawing.Size(169, 157);
            this.VendorPicture.TabIndex = 4;
            this.VendorPicture.TabStop = false;
            // 
            // VendorTextBox
            // 
            this.VendorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.VendorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorTextBox.Location = new System.Drawing.Point(178, 27);
            this.VendorTextBox.Multiline = true;
            this.VendorTextBox.Name = "VendorTextBox";
            this.VendorTextBox.ReadOnly = true;
            this.VendorTextBox.Size = new System.Drawing.Size(409, 156);
            this.VendorTextBox.TabIndex = 5;
            this.VendorTextBox.TabStop = false;
            // 
            // VendorWares
            // 
            this.VendorWares.FormattingEnabled = true;
            this.VendorWares.Location = new System.Drawing.Point(3, 190);
            this.VendorWares.Name = "VendorWares";
            this.VendorWares.Size = new System.Drawing.Size(219, 173);
            this.VendorWares.TabIndex = 6;
            this.VendorWares.SelectedIndexChanged += new System.EventHandler(this.VendorWares_SelectedIndexChanged);
            // 
            // PurchaseButton
            // 
            this.PurchaseButton.Location = new System.Drawing.Point(151, 372);
            this.PurchaseButton.Name = "PurchaseButton";
            this.PurchaseButton.Size = new System.Drawing.Size(71, 23);
            this.PurchaseButton.TabIndex = 7;
            this.PurchaseButton.Text = "Purchase";
            this.PurchaseButton.UseVisualStyleBackColor = true;
            this.PurchaseButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PurchaseButton_MouseClick);
            // 
            // PlayerCoins
            // 
            this.PlayerCoins.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PlayerCoins.Location = new System.Drawing.Point(3, 372);
            this.PlayerCoins.Name = "PlayerCoins";
            this.PlayerCoins.ReadOnly = true;
            this.PlayerCoins.Size = new System.Drawing.Size(142, 20);
            this.PlayerCoins.TabIndex = 8;
            // 
            // InformationBox
            // 
            this.InformationBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.InformationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformationBox.Location = new System.Drawing.Point(228, 190);
            this.InformationBox.Multiline = true;
            this.InformationBox.Name = "InformationBox";
            this.InformationBox.ReadOnly = true;
            this.InformationBox.Size = new System.Drawing.Size(359, 255);
            this.InformationBox.TabIndex = 9;
            this.InformationBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.reRollWaresToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(594, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // reRollWaresToolStripMenuItem
            // 
            this.reRollWaresToolStripMenuItem.Name = "reRollWaresToolStripMenuItem";
            this.reRollWaresToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.reRollWaresToolStripMenuItem.Text = "Re-Roll Wares";
            this.reRollWaresToolStripMenuItem.Click += new System.EventHandler(this.reRollWaresToolStripMenuItem_Click);
            // 
            // charmRadio
            // 
            this.charmRadio.AutoSize = true;
            this.charmRadio.Location = new System.Drawing.Point(6, 19);
            this.charmRadio.Name = "charmRadio";
            this.charmRadio.Size = new System.Drawing.Size(60, 17);
            this.charmRadio.TabIndex = 11;
            this.charmRadio.Text = "Charms";
            this.charmRadio.UseVisualStyleBackColor = true;
            this.charmRadio.CheckedChanged += new System.EventHandler(this.charmRadio_CheckedChanged);
            // 
            // keyRadio
            // 
            this.keyRadio.AutoSize = true;
            this.keyRadio.Location = new System.Drawing.Point(72, 19);
            this.keyRadio.Name = "keyRadio";
            this.keyRadio.Size = new System.Drawing.Size(48, 17);
            this.keyRadio.TabIndex = 12;
            this.keyRadio.Text = "Keys";
            this.keyRadio.UseVisualStyleBackColor = true;
            this.keyRadio.CheckedChanged += new System.EventHandler(this.keyRadio_CheckedChanged);
            // 
            // itemRadio
            // 
            this.itemRadio.AutoSize = true;
            this.itemRadio.Location = new System.Drawing.Point(126, 19);
            this.itemRadio.Name = "itemRadio";
            this.itemRadio.Size = new System.Drawing.Size(50, 17);
            this.itemRadio.TabIndex = 13;
            this.itemRadio.Text = "Items";
            this.itemRadio.UseVisualStyleBackColor = true;
            this.itemRadio.CheckedChanged += new System.EventHandler(this.itemRadio_CheckedChanged);
            // 
            // allRadio
            // 
            this.allRadio.AutoSize = true;
            this.allRadio.Checked = true;
            this.allRadio.Location = new System.Drawing.Point(181, 19);
            this.allRadio.Name = "allRadio";
            this.allRadio.Size = new System.Drawing.Size(36, 17);
            this.allRadio.TabIndex = 14;
            this.allRadio.TabStop = true;
            this.allRadio.Text = "All";
            this.allRadio.UseVisualStyleBackColor = true;
            this.allRadio.CheckedChanged += new System.EventHandler(this.allRadio_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.charmRadio);
            this.groupBox1.Controls.Add(this.allRadio);
            this.groupBox1.Controls.Add(this.keyRadio);
            this.groupBox1.Controls.Add(this.itemRadio);
            this.groupBox1.Location = new System.Drawing.Point(3, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 50);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // ShopRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InformationBox);
            this.Controls.Add(this.PlayerCoins);
            this.Controls.Add(this.PurchaseButton);
            this.Controls.Add(this.VendorWares);
            this.Controls.Add(this.VendorTextBox);
            this.Controls.Add(this.VendorPicture);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ShopRoom";
            this.Text = "Item Shop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShopRoom_FormClosing);
            this.Load += new System.EventHandler(this.ShopRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendorPicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VendorPicture;
        private System.Windows.Forms.TextBox VendorTextBox;
        private System.Windows.Forms.ListBox VendorWares;
        private System.Windows.Forms.Button PurchaseButton;
        private System.Windows.Forms.TextBox PlayerCoins;
        private System.Windows.Forms.TextBox InformationBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.RadioButton charmRadio;
        private System.Windows.Forms.RadioButton keyRadio;
        private System.Windows.Forms.RadioButton itemRadio;
        private System.Windows.Forms.RadioButton allRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem reRollWaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}