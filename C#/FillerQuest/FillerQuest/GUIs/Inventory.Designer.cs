namespace AscendedRPG
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.InventoryList = new System.Windows.Forms.ListBox();
            this.SelectedArmorSkill = new System.Windows.Forms.TextBox();
            this.SelectedInventorySkill = new System.Windows.Forms.TextBox();
            this.DeleteSelectedInventory = new System.Windows.Forms.Button();
            this.ReserveSkillList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmbarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.EquipmentBox = new System.Windows.Forms.ListBox();
            this.ActiveSkillBox = new System.Windows.Forms.ListBox();
            this.musicBot = new System.ComponentModel.BackgroundWorker();
            this.SkillDisplayBox = new System.Windows.Forms.TextBox();
            this.head = new System.Windows.Forms.RadioButton();
            this.torso = new System.Windows.Forms.RadioButton();
            this.arms = new System.Windows.Forms.RadioButton();
            this.waist = new System.Windows.Forms.RadioButton();
            this.legs = new System.Windows.Forms.RadioButton();
            this.charms = new System.Windows.Forms.RadioButton();
            this.UnfilterButton = new System.Windows.Forms.Button();
            this.DefenseBox = new System.Windows.Forms.TextBox();
            this.CoinBox = new System.Windows.Forms.TextBox();
            this.TierBox = new System.Windows.Forms.TextBox();
            this.ItemCount = new System.Windows.Forms.TextBox();
            this.EquipmentGroup = new System.Windows.Forms.GroupBox();
            this.RelicGroup = new System.Windows.Forms.GroupBox();
            this.RelicInformation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MeldCharm = new System.Windows.Forms.Button();
            this.SelectedSkills = new System.Windows.Forms.TextBox();
            this.SelectedArmor = new System.Windows.Forms.TextBox();
            this.DeleteRelic = new System.Windows.Forms.Button();
            this.Relics = new System.Windows.Forms.ListBox();
            this.InventoryGroup = new System.Windows.Forms.GroupBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.EquipmentGroup.SuspendLayout();
            this.RelicGroup.SuspendLayout();
            this.InventoryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryList
            // 
            this.InventoryList.FormattingEnabled = true;
            this.InventoryList.Location = new System.Drawing.Point(11, 43);
            this.InventoryList.Name = "InventoryList";
            this.InventoryList.Size = new System.Drawing.Size(248, 290);
            this.InventoryList.TabIndex = 1;
            this.InventoryList.SelectedIndexChanged += new System.EventHandler(this.InventoryList_SelectedIndexChanged);
            this.InventoryList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InventoryList_MouseDown);
            // 
            // SelectedArmorSkill
            // 
            this.SelectedArmorSkill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedArmorSkill.Location = new System.Drawing.Point(9, 198);
            this.SelectedArmorSkill.Name = "SelectedArmorSkill";
            this.SelectedArmorSkill.ReadOnly = true;
            this.SelectedArmorSkill.Size = new System.Drawing.Size(391, 20);
            this.SelectedArmorSkill.TabIndex = 4;
            // 
            // SelectedInventorySkill
            // 
            this.SelectedInventorySkill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedInventorySkill.Location = new System.Drawing.Point(11, 19);
            this.SelectedInventorySkill.Name = "SelectedInventorySkill";
            this.SelectedInventorySkill.ReadOnly = true;
            this.SelectedInventorySkill.Size = new System.Drawing.Size(248, 20);
            this.SelectedInventorySkill.TabIndex = 5;
            // 
            // DeleteSelectedInventory
            // 
            this.DeleteSelectedInventory.Location = new System.Drawing.Point(11, 357);
            this.DeleteSelectedInventory.Name = "DeleteSelectedInventory";
            this.DeleteSelectedInventory.Size = new System.Drawing.Size(122, 25);
            this.DeleteSelectedInventory.TabIndex = 7;
            this.DeleteSelectedInventory.Text = "Delete Selected";
            this.DeleteSelectedInventory.UseVisualStyleBackColor = true;
            this.DeleteSelectedInventory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteSelectedInventory_MouseClick);
            // 
            // ReserveSkillList
            // 
            this.ReserveSkillList.FormattingEnabled = true;
            this.ReserveSkillList.Location = new System.Drawing.Point(225, 224);
            this.ReserveSkillList.Name = "ReserveSkillList";
            this.ReserveSkillList.Size = new System.Drawing.Size(175, 160);
            this.ReserveSkillList.TabIndex = 8;
            this.ReserveSkillList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReserveSkillList_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.EmbarkMenuItem,
            this.checkElementsToolStripMenuItem,
            this.relicsToolStripMenuItem,
            this.shopToolStripMenuItem,
            this.checkKeysToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(43, 20);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // EmbarkMenuItem
            // 
            this.EmbarkMenuItem.Name = "EmbarkMenuItem";
            this.EmbarkMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EmbarkMenuItem.Text = "Embark";
            this.EmbarkMenuItem.Click += new System.EventHandler(this.EmbarkMenuItem_Click);
            // 
            // relicsToolStripMenuItem
            // 
            this.relicsToolStripMenuItem.Name = "relicsToolStripMenuItem";
            this.relicsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.relicsToolStripMenuItem.Text = "Relics";
            this.relicsToolStripMenuItem.Visible = false;
            this.relicsToolStripMenuItem.Click += new System.EventHandler(this.relicsToolStripMenuItem_Click);
            // 
            // shopToolStripMenuItem
            // 
            this.shopToolStripMenuItem.Enabled = false;
            this.shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            this.shopToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.shopToolStripMenuItem.Text = "Shop";
            this.shopToolStripMenuItem.Click += new System.EventHandler(this.shopToolStripMenuItem_Click);
            // 
            // checkKeysToolStripMenuItem
            // 
            this.checkKeysToolStripMenuItem.Enabled = false;
            this.checkKeysToolStripMenuItem.Name = "checkKeysToolStripMenuItem";
            this.checkKeysToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.checkKeysToolStripMenuItem.Text = "B. Keys";
            this.checkKeysToolStripMenuItem.Click += new System.EventHandler(this.checkKeysToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // KeyBox
            // 
            this.KeyBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.KeyBox.Location = new System.Drawing.Point(228, 73);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.ReadOnly = true;
            this.KeyBox.Size = new System.Drawing.Size(172, 20);
            this.KeyBox.TabIndex = 10;
            this.KeyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EquipmentBox
            // 
            this.EquipmentBox.FormattingEnabled = true;
            this.EquipmentBox.Location = new System.Drawing.Point(9, 45);
            this.EquipmentBox.Name = "EquipmentBox";
            this.EquipmentBox.Size = new System.Drawing.Size(213, 147);
            this.EquipmentBox.TabIndex = 11;
            this.EquipmentBox.SelectedIndexChanged += new System.EventHandler(this.EquipmentBox_SelectedIndexChanged);
            // 
            // ActiveSkillBox
            // 
            this.ActiveSkillBox.FormattingEnabled = true;
            this.ActiveSkillBox.Location = new System.Drawing.Point(9, 224);
            this.ActiveSkillBox.Name = "ActiveSkillBox";
            this.ActiveSkillBox.Size = new System.Drawing.Size(213, 160);
            this.ActiveSkillBox.TabIndex = 12;
            this.ActiveSkillBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ActiveSkillBox_MouseDown);
            // 
            // musicBot
            // 
            this.musicBot.DoWork += new System.ComponentModel.DoWorkEventHandler(this.musicBot_DoWork);
            // 
            // SkillDisplayBox
            // 
            this.SkillDisplayBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SkillDisplayBox.Location = new System.Drawing.Point(228, 125);
            this.SkillDisplayBox.Multiline = true;
            this.SkillDisplayBox.Name = "SkillDisplayBox";
            this.SkillDisplayBox.ReadOnly = true;
            this.SkillDisplayBox.Size = new System.Drawing.Size(172, 67);
            this.SkillDisplayBox.TabIndex = 0;
            // 
            // head
            // 
            this.head.AutoSize = true;
            this.head.Location = new System.Drawing.Point(24, 337);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(33, 17);
            this.head.TabIndex = 14;
            this.head.TabStop = true;
            this.head.Text = "H";
            this.head.UseVisualStyleBackColor = true;
            this.head.CheckedChanged += new System.EventHandler(this.head_CheckedChanged);
            // 
            // torso
            // 
            this.torso.AutoSize = true;
            this.torso.Location = new System.Drawing.Point(63, 337);
            this.torso.Name = "torso";
            this.torso.Size = new System.Drawing.Size(32, 17);
            this.torso.TabIndex = 15;
            this.torso.TabStop = true;
            this.torso.Text = "T";
            this.torso.UseVisualStyleBackColor = true;
            this.torso.CheckedChanged += new System.EventHandler(this.torso_CheckedChanged);
            // 
            // arms
            // 
            this.arms.AutoSize = true;
            this.arms.Location = new System.Drawing.Point(101, 337);
            this.arms.Name = "arms";
            this.arms.Size = new System.Drawing.Size(32, 17);
            this.arms.TabIndex = 16;
            this.arms.TabStop = true;
            this.arms.Text = "A";
            this.arms.UseVisualStyleBackColor = true;
            this.arms.CheckedChanged += new System.EventHandler(this.arms_CheckedChanged);
            // 
            // waist
            // 
            this.waist.AutoSize = true;
            this.waist.Location = new System.Drawing.Point(139, 337);
            this.waist.Name = "waist";
            this.waist.Size = new System.Drawing.Size(36, 17);
            this.waist.TabIndex = 17;
            this.waist.TabStop = true;
            this.waist.Text = "W";
            this.waist.UseVisualStyleBackColor = true;
            this.waist.CheckedChanged += new System.EventHandler(this.waist_CheckedChanged);
            // 
            // legs
            // 
            this.legs.AutoSize = true;
            this.legs.Location = new System.Drawing.Point(181, 337);
            this.legs.Name = "legs";
            this.legs.Size = new System.Drawing.Size(31, 17);
            this.legs.TabIndex = 18;
            this.legs.TabStop = true;
            this.legs.Text = "L";
            this.legs.UseVisualStyleBackColor = true;
            this.legs.CheckedChanged += new System.EventHandler(this.legs_CheckedChanged);
            // 
            // charms
            // 
            this.charms.AutoSize = true;
            this.charms.Location = new System.Drawing.Point(218, 337);
            this.charms.Name = "charms";
            this.charms.Size = new System.Drawing.Size(32, 17);
            this.charms.TabIndex = 19;
            this.charms.TabStop = true;
            this.charms.Text = "C";
            this.charms.UseVisualStyleBackColor = true;
            this.charms.CheckedChanged += new System.EventHandler(this.charms_CheckedChanged);
            // 
            // UnfilterButton
            // 
            this.UnfilterButton.Location = new System.Drawing.Point(139, 357);
            this.UnfilterButton.Name = "UnfilterButton";
            this.UnfilterButton.Size = new System.Drawing.Size(120, 25);
            this.UnfilterButton.TabIndex = 20;
            this.UnfilterButton.Text = "Unfilter";
            this.UnfilterButton.UseVisualStyleBackColor = true;
            this.UnfilterButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UnfilterButton_MouseClick);
            // 
            // DefenseBox
            // 
            this.DefenseBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DefenseBox.Location = new System.Drawing.Point(9, 21);
            this.DefenseBox.Name = "DefenseBox";
            this.DefenseBox.ReadOnly = true;
            this.DefenseBox.Size = new System.Drawing.Size(213, 20);
            this.DefenseBox.TabIndex = 21;
            this.DefenseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoinBox
            // 
            this.CoinBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CoinBox.Location = new System.Drawing.Point(228, 47);
            this.CoinBox.Name = "CoinBox";
            this.CoinBox.ReadOnly = true;
            this.CoinBox.Size = new System.Drawing.Size(172, 20);
            this.CoinBox.TabIndex = 22;
            this.CoinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TierBox
            // 
            this.TierBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TierBox.Location = new System.Drawing.Point(228, 21);
            this.TierBox.Name = "TierBox";
            this.TierBox.ReadOnly = true;
            this.TierBox.Size = new System.Drawing.Size(172, 20);
            this.TierBox.TabIndex = 23;
            this.TierBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ItemCount.Location = new System.Drawing.Point(228, 99);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.ReadOnly = true;
            this.ItemCount.Size = new System.Drawing.Size(172, 20);
            this.ItemCount.TabIndex = 24;
            this.ItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EquipmentGroup
            // 
            this.EquipmentGroup.Controls.Add(this.RelicGroup);
            this.EquipmentGroup.Controls.Add(this.DefenseBox);
            this.EquipmentGroup.Controls.Add(this.ItemCount);
            this.EquipmentGroup.Controls.Add(this.SelectedArmorSkill);
            this.EquipmentGroup.Controls.Add(this.TierBox);
            this.EquipmentGroup.Controls.Add(this.ReserveSkillList);
            this.EquipmentGroup.Controls.Add(this.CoinBox);
            this.EquipmentGroup.Controls.Add(this.KeyBox);
            this.EquipmentGroup.Controls.Add(this.EquipmentBox);
            this.EquipmentGroup.Controls.Add(this.ActiveSkillBox);
            this.EquipmentGroup.Controls.Add(this.SkillDisplayBox);
            this.EquipmentGroup.Location = new System.Drawing.Point(273, 27);
            this.EquipmentGroup.Name = "EquipmentGroup";
            this.EquipmentGroup.Size = new System.Drawing.Size(406, 393);
            this.EquipmentGroup.TabIndex = 25;
            this.EquipmentGroup.TabStop = false;
            this.EquipmentGroup.Text = "Equipment";
            // 
            // RelicGroup
            // 
            this.RelicGroup.Controls.Add(this.RelicInformation);
            this.RelicGroup.Controls.Add(this.button1);
            this.RelicGroup.Controls.Add(this.MeldCharm);
            this.RelicGroup.Controls.Add(this.SelectedSkills);
            this.RelicGroup.Controls.Add(this.SelectedArmor);
            this.RelicGroup.Controls.Add(this.DeleteRelic);
            this.RelicGroup.Controls.Add(this.Relics);
            this.RelicGroup.Location = new System.Drawing.Point(0, 0);
            this.RelicGroup.Name = "RelicGroup";
            this.RelicGroup.Size = new System.Drawing.Size(406, 393);
            this.RelicGroup.TabIndex = 27;
            this.RelicGroup.TabStop = false;
            this.RelicGroup.Text = "Relics";
            this.RelicGroup.Visible = false;
            // 
            // RelicInformation
            // 
            this.RelicInformation.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RelicInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelicInformation.Location = new System.Drawing.Point(9, 13);
            this.RelicInformation.Multiline = true;
            this.RelicInformation.Name = "RelicInformation";
            this.RelicInformation.ReadOnly = true;
            this.RelicInformation.Size = new System.Drawing.Size(245, 233);
            this.RelicInformation.TabIndex = 28;
            this.RelicInformation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Craft";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // MeldCharm
            // 
            this.MeldCharm.Location = new System.Drawing.Point(146, 252);
            this.MeldCharm.Name = "MeldCharm";
            this.MeldCharm.Size = new System.Drawing.Size(108, 23);
            this.MeldCharm.TabIndex = 23;
            this.MeldCharm.Text = "Meld";
            this.MeldCharm.UseVisualStyleBackColor = true;
            this.MeldCharm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MeldCharm_MouseClick);
            // 
            // SelectedSkills
            // 
            this.SelectedSkills.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedSkills.Location = new System.Drawing.Point(9, 307);
            this.SelectedSkills.Multiline = true;
            this.SelectedSkills.Name = "SelectedSkills";
            this.SelectedSkills.ReadOnly = true;
            this.SelectedSkills.Size = new System.Drawing.Size(245, 75);
            this.SelectedSkills.TabIndex = 22;
            // 
            // SelectedArmor
            // 
            this.SelectedArmor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedArmor.Location = new System.Drawing.Point(9, 281);
            this.SelectedArmor.Name = "SelectedArmor";
            this.SelectedArmor.ReadOnly = true;
            this.SelectedArmor.Size = new System.Drawing.Size(245, 20);
            this.SelectedArmor.TabIndex = 21;
            this.SelectedArmor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeleteRelic
            // 
            this.DeleteRelic.Location = new System.Drawing.Point(260, 361);
            this.DeleteRelic.Name = "DeleteRelic";
            this.DeleteRelic.Size = new System.Drawing.Size(140, 23);
            this.DeleteRelic.TabIndex = 1;
            this.DeleteRelic.Text = "Delete Relic";
            this.DeleteRelic.UseVisualStyleBackColor = true;
            this.DeleteRelic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteRelic_MouseClick);
            // 
            // Relics
            // 
            this.Relics.FormattingEnabled = true;
            this.Relics.Location = new System.Drawing.Point(260, 13);
            this.Relics.Name = "Relics";
            this.Relics.Size = new System.Drawing.Size(140, 342);
            this.Relics.TabIndex = 0;
            this.Relics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Relics_MouseDown);
            // 
            // InventoryGroup
            // 
            this.InventoryGroup.Controls.Add(this.SelectedInventorySkill);
            this.InventoryGroup.Controls.Add(this.InventoryList);
            this.InventoryGroup.Controls.Add(this.UnfilterButton);
            this.InventoryGroup.Controls.Add(this.DeleteSelectedInventory);
            this.InventoryGroup.Controls.Add(this.charms);
            this.InventoryGroup.Controls.Add(this.head);
            this.InventoryGroup.Controls.Add(this.legs);
            this.InventoryGroup.Controls.Add(this.torso);
            this.InventoryGroup.Controls.Add(this.waist);
            this.InventoryGroup.Controls.Add(this.arms);
            this.InventoryGroup.Location = new System.Drawing.Point(0, 27);
            this.InventoryGroup.Name = "InventoryGroup";
            this.InventoryGroup.Size = new System.Drawing.Size(267, 393);
            this.InventoryGroup.TabIndex = 26;
            this.InventoryGroup.TabStop = false;
            this.InventoryGroup.Text = "Inventory";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // checkElementsToolStripMenuItem
            // 
            this.checkElementsToolStripMenuItem.Name = "checkElementsToolStripMenuItem";
            this.checkElementsToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.checkElementsToolStripMenuItem.Text = "Check Elements";
            this.checkElementsToolStripMenuItem.Click += new System.EventHandler(this.checkElementsToolStripMenuItem_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 423);
            this.Controls.Add(this.InventoryGroup);
            this.Controls.Add(this.EquipmentGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EquipmentGroup.ResumeLayout(false);
            this.EquipmentGroup.PerformLayout();
            this.RelicGroup.ResumeLayout(false);
            this.RelicGroup.PerformLayout();
            this.InventoryGroup.ResumeLayout(false);
            this.InventoryGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox InventoryList;
        private System.Windows.Forms.TextBox SelectedArmorSkill;
        private System.Windows.Forms.TextBox SelectedInventorySkill;
        private System.Windows.Forms.Button DeleteSelectedInventory;
        private System.Windows.Forms.ListBox ReserveSkillList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox KeyBox;
        private System.Windows.Forms.ListBox EquipmentBox;
        private System.Windows.Forms.ListBox ActiveSkillBox;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmbarkMenuItem;
        private System.ComponentModel.BackgroundWorker musicBot;
        private System.Windows.Forms.TextBox SkillDisplayBox;
        private System.Windows.Forms.RadioButton head;
        private System.Windows.Forms.RadioButton torso;
        private System.Windows.Forms.RadioButton arms;
        private System.Windows.Forms.RadioButton waist;
        private System.Windows.Forms.RadioButton legs;
        private System.Windows.Forms.ToolStripMenuItem shopToolStripMenuItem;
        private System.Windows.Forms.RadioButton charms;
        private System.Windows.Forms.Button UnfilterButton;
        private System.Windows.Forms.TextBox DefenseBox;
        private System.Windows.Forms.TextBox CoinBox;
        private System.Windows.Forms.TextBox TierBox;
        private System.Windows.Forms.ToolStripMenuItem checkKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.TextBox ItemCount;
        private System.Windows.Forms.GroupBox EquipmentGroup;
        private System.Windows.Forms.GroupBox InventoryGroup;
        private System.Windows.Forms.ToolStripMenuItem relicsToolStripMenuItem;
        private System.Windows.Forms.GroupBox RelicGroup;
        private System.Windows.Forms.ListBox Relics;
        private System.Windows.Forms.Button DeleteRelic;
        private System.Windows.Forms.TextBox SelectedSkills;
        private System.Windows.Forms.TextBox SelectedArmor;
        private System.Windows.Forms.Button MeldCharm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox RelicInformation;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkElementsToolStripMenuItem;
    }
}

