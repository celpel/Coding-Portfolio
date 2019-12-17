namespace AscendedRPG
{
    partial class DungeonGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonGUI));
            this.CombatLog = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.PlayerHealth = new System.Windows.Forms.ProgressBar();
            this.Skills = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useBountyKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useEXBountyKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useElderKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnemyGroup = new System.Windows.Forms.GroupBox();
            this.EnemyBox3 = new System.Windows.Forms.TextBox();
            this.EnemyBox2 = new System.Windows.Forms.TextBox();
            this.EnemyBox1 = new System.Windows.Forms.TextBox();
            this.EnemyBar3 = new System.Windows.Forms.ProgressBar();
            this.EnemyBar2 = new System.Windows.Forms.ProgressBar();
            this.EnemyBar1 = new System.Windows.Forms.ProgressBar();
            this.EnemyPic3 = new System.Windows.Forms.PictureBox();
            this.EnemyPic2 = new System.Windows.Forms.PictureBox();
            this.EnemyPic1 = new System.Windows.Forms.PictureBox();
            this.TurnBox = new System.Windows.Forms.TextBox();
            this.TargetGroup = new System.Windows.Forms.GroupBox();
            this.Target3 = new System.Windows.Forms.RadioButton();
            this.Target2 = new System.Windows.Forms.RadioButton();
            this.Target1 = new System.Windows.Forms.RadioButton();
            this.BossGroup = new System.Windows.Forms.GroupBox();
            this.SubBar19 = new System.Windows.Forms.ProgressBar();
            this.SubBar18 = new System.Windows.Forms.ProgressBar();
            this.SubBar17 = new System.Windows.Forms.ProgressBar();
            this.TitleCard = new System.Windows.Forms.PictureBox();
            this.SubBar16 = new System.Windows.Forms.ProgressBar();
            this.SubBar15 = new System.Windows.Forms.ProgressBar();
            this.SubBar14 = new System.Windows.Forms.ProgressBar();
            this.SubBar13 = new System.Windows.Forms.ProgressBar();
            this.SubBar12 = new System.Windows.Forms.ProgressBar();
            this.SubBar11 = new System.Windows.Forms.ProgressBar();
            this.SubBar10 = new System.Windows.Forms.ProgressBar();
            this.SubBar9 = new System.Windows.Forms.ProgressBar();
            this.SubBar8 = new System.Windows.Forms.ProgressBar();
            this.SubBar7 = new System.Windows.Forms.ProgressBar();
            this.SubBar6 = new System.Windows.Forms.ProgressBar();
            this.SubBar5 = new System.Windows.Forms.ProgressBar();
            this.SubBar4 = new System.Windows.Forms.ProgressBar();
            this.SubBar3 = new System.Windows.Forms.ProgressBar();
            this.SubBar2 = new System.Windows.Forms.ProgressBar();
            this.SubBar1 = new System.Windows.Forms.ProgressBar();
            this.BossBar = new System.Windows.Forms.ProgressBar();
            this.BossName = new System.Windows.Forms.TextBox();
            this.BossPicture = new System.Windows.Forms.PictureBox();
            this.UseSkillButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ProfilePic = new System.Windows.Forms.PictureBox();
            this.FightsLeft = new System.Windows.Forms.TextBox();
            this.CurrentFight = new System.Windows.Forms.TextBox();
            this.UseItemButton = new System.Windows.Forms.Button();
            this.ItemList = new System.Windows.Forms.ListBox();
            this.RemainingItemBox = new System.Windows.Forms.TextBox();
            this.UseRelic = new System.Windows.Forms.Button();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.EnemyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic1)).BeginInit();
            this.TargetGroup.SuspendLayout();
            this.BossGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // CombatLog
            // 
            this.CombatLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CombatLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombatLog.Location = new System.Drawing.Point(488, 316);
            this.CombatLog.Multiline = true;
            this.CombatLog.Name = "CombatLog";
            this.CombatLog.ReadOnly = true;
            this.CombatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CombatLog.Size = new System.Drawing.Size(181, 242);
            this.CombatLog.TabIndex = 0;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NameBox.Location = new System.Drawing.Point(187, 342);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(295, 20);
            this.NameBox.TabIndex = 1;
            this.NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Location = new System.Drawing.Point(187, 316);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(295, 20);
            this.PlayerHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PlayerHealth.TabIndex = 2;
            // 
            // Skills
            // 
            this.Skills.FormattingEnabled = true;
            this.Skills.Location = new System.Drawing.Point(187, 368);
            this.Skills.Name = "Skills";
            this.Skills.Size = new System.Drawing.Size(213, 134);
            this.Skills.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.useBountyKeyToolStripMenuItem,
            this.useEXBountyKeyToolStripMenuItem,
            this.useElderKeyToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // useBountyKeyToolStripMenuItem
            // 
            this.useBountyKeyToolStripMenuItem.Enabled = false;
            this.useBountyKeyToolStripMenuItem.Name = "useBountyKeyToolStripMenuItem";
            this.useBountyKeyToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.useBountyKeyToolStripMenuItem.Text = "Use Bounty Key";
            this.useBountyKeyToolStripMenuItem.Click += new System.EventHandler(this.useBountyKeyToolStripMenuItem_Click);
            // 
            // useEXBountyKeyToolStripMenuItem
            // 
            this.useEXBountyKeyToolStripMenuItem.Enabled = false;
            this.useEXBountyKeyToolStripMenuItem.Name = "useEXBountyKeyToolStripMenuItem";
            this.useEXBountyKeyToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.useEXBountyKeyToolStripMenuItem.Text = "Use EX Bounty Key";
            this.useEXBountyKeyToolStripMenuItem.Visible = false;
            this.useEXBountyKeyToolStripMenuItem.Click += new System.EventHandler(this.useEXBountyKeyToolStripMenuItem_Click);
            // 
            // useElderKeyToolStripMenuItem
            // 
            this.useElderKeyToolStripMenuItem.Enabled = false;
            this.useElderKeyToolStripMenuItem.Name = "useElderKeyToolStripMenuItem";
            this.useElderKeyToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.useElderKeyToolStripMenuItem.Text = "Use Elder Key";
            this.useElderKeyToolStripMenuItem.Click += new System.EventHandler(this.useElderKeyToolStripMenuItem_Click);
            // 
            // EnemyGroup
            // 
            this.EnemyGroup.Controls.Add(this.EnemyBox3);
            this.EnemyGroup.Controls.Add(this.EnemyBox2);
            this.EnemyGroup.Controls.Add(this.EnemyBox1);
            this.EnemyGroup.Controls.Add(this.EnemyBar3);
            this.EnemyGroup.Controls.Add(this.EnemyBar2);
            this.EnemyGroup.Controls.Add(this.EnemyBar1);
            this.EnemyGroup.Controls.Add(this.EnemyPic3);
            this.EnemyGroup.Controls.Add(this.EnemyPic2);
            this.EnemyGroup.Controls.Add(this.EnemyPic1);
            this.EnemyGroup.Location = new System.Drawing.Point(7, 27);
            this.EnemyGroup.Name = "EnemyGroup";
            this.EnemyGroup.Size = new System.Drawing.Size(662, 257);
            this.EnemyGroup.TabIndex = 7;
            this.EnemyGroup.TabStop = false;
            this.EnemyGroup.Text = "Enemies";
            // 
            // EnemyBox3
            // 
            this.EnemyBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox3.Location = new System.Drawing.Point(455, 226);
            this.EnemyBox3.Name = "EnemyBox3";
            this.EnemyBox3.ReadOnly = true;
            this.EnemyBox3.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox3.TabIndex = 8;
            this.EnemyBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBox2
            // 
            this.EnemyBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox2.Location = new System.Drawing.Point(238, 226);
            this.EnemyBox2.Name = "EnemyBox2";
            this.EnemyBox2.ReadOnly = true;
            this.EnemyBox2.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox2.TabIndex = 7;
            this.EnemyBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBox1
            // 
            this.EnemyBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox1.Location = new System.Drawing.Point(19, 226);
            this.EnemyBox1.Name = "EnemyBox1";
            this.EnemyBox1.ReadOnly = true;
            this.EnemyBox1.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox1.TabIndex = 6;
            this.EnemyBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBar3
            // 
            this.EnemyBar3.Location = new System.Drawing.Point(455, 201);
            this.EnemyBar3.Name = "EnemyBar3";
            this.EnemyBar3.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar3.TabIndex = 5;
            // 
            // EnemyBar2
            // 
            this.EnemyBar2.Location = new System.Drawing.Point(238, 201);
            this.EnemyBar2.Name = "EnemyBar2";
            this.EnemyBar2.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar2.TabIndex = 4;
            // 
            // EnemyBar1
            // 
            this.EnemyBar1.Location = new System.Drawing.Point(19, 201);
            this.EnemyBar1.Name = "EnemyBar1";
            this.EnemyBar1.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar1.TabIndex = 3;
            // 
            // EnemyPic3
            // 
            this.EnemyPic3.Location = new System.Drawing.Point(455, 19);
            this.EnemyPic3.Name = "EnemyPic3";
            this.EnemyPic3.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic3.TabIndex = 2;
            this.EnemyPic3.TabStop = false;
            // 
            // EnemyPic2
            // 
            this.EnemyPic2.Location = new System.Drawing.Point(238, 19);
            this.EnemyPic2.Name = "EnemyPic2";
            this.EnemyPic2.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic2.TabIndex = 1;
            this.EnemyPic2.TabStop = false;
            // 
            // EnemyPic1
            // 
            this.EnemyPic1.ErrorImage = null;
            this.EnemyPic1.InitialImage = null;
            this.EnemyPic1.Location = new System.Drawing.Point(19, 19);
            this.EnemyPic1.Name = "EnemyPic1";
            this.EnemyPic1.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic1.TabIndex = 0;
            this.EnemyPic1.TabStop = false;
            // 
            // TurnBox
            // 
            this.TurnBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TurnBox.Location = new System.Drawing.Point(7, 290);
            this.TurnBox.Name = "TurnBox";
            this.TurnBox.ReadOnly = true;
            this.TurnBox.Size = new System.Drawing.Size(662, 20);
            this.TurnBox.TabIndex = 8;
            // 
            // TargetGroup
            // 
            this.TargetGroup.Controls.Add(this.Target3);
            this.TargetGroup.Controls.Add(this.Target2);
            this.TargetGroup.Controls.Add(this.Target1);
            this.TargetGroup.Location = new System.Drawing.Point(187, 508);
            this.TargetGroup.Name = "TargetGroup";
            this.TargetGroup.Size = new System.Drawing.Size(213, 50);
            this.TargetGroup.TabIndex = 9;
            this.TargetGroup.TabStop = false;
            this.TargetGroup.Text = "Targets";
            // 
            // Target3
            // 
            this.Target3.AutoSize = true;
            this.Target3.Location = new System.Drawing.Point(154, 19);
            this.Target3.Name = "Target3";
            this.Target3.Size = new System.Drawing.Size(49, 17);
            this.Target3.TabIndex = 2;
            this.Target3.TabStop = true;
            this.Target3.Text = "three";
            this.Target3.UseVisualStyleBackColor = true;
            // 
            // Target2
            // 
            this.Target2.AutoSize = true;
            this.Target2.Location = new System.Drawing.Point(95, 19);
            this.Target2.Name = "Target2";
            this.Target2.Size = new System.Drawing.Size(42, 17);
            this.Target2.TabIndex = 1;
            this.Target2.TabStop = true;
            this.Target2.Text = "two";
            this.Target2.UseVisualStyleBackColor = true;
            // 
            // Target1
            // 
            this.Target1.AutoSize = true;
            this.Target1.Checked = true;
            this.Target1.Location = new System.Drawing.Point(29, 19);
            this.Target1.Name = "Target1";
            this.Target1.Size = new System.Drawing.Size(43, 17);
            this.Target1.TabIndex = 0;
            this.Target1.TabStop = true;
            this.Target1.Text = "one";
            this.Target1.UseVisualStyleBackColor = true;
            // 
            // BossGroup
            // 
            this.BossGroup.Controls.Add(this.SubBar19);
            this.BossGroup.Controls.Add(this.SubBar18);
            this.BossGroup.Controls.Add(this.SubBar17);
            this.BossGroup.Controls.Add(this.TitleCard);
            this.BossGroup.Controls.Add(this.SubBar16);
            this.BossGroup.Controls.Add(this.SubBar15);
            this.BossGroup.Controls.Add(this.SubBar14);
            this.BossGroup.Controls.Add(this.SubBar13);
            this.BossGroup.Controls.Add(this.SubBar12);
            this.BossGroup.Controls.Add(this.SubBar11);
            this.BossGroup.Controls.Add(this.SubBar10);
            this.BossGroup.Controls.Add(this.SubBar9);
            this.BossGroup.Controls.Add(this.SubBar8);
            this.BossGroup.Controls.Add(this.SubBar7);
            this.BossGroup.Controls.Add(this.SubBar6);
            this.BossGroup.Controls.Add(this.SubBar5);
            this.BossGroup.Controls.Add(this.SubBar4);
            this.BossGroup.Controls.Add(this.SubBar3);
            this.BossGroup.Controls.Add(this.SubBar2);
            this.BossGroup.Controls.Add(this.SubBar1);
            this.BossGroup.Controls.Add(this.BossBar);
            this.BossGroup.Controls.Add(this.BossName);
            this.BossGroup.Controls.Add(this.BossPicture);
            this.BossGroup.Location = new System.Drawing.Point(7, 26);
            this.BossGroup.Name = "BossGroup";
            this.BossGroup.Size = new System.Drawing.Size(662, 258);
            this.BossGroup.TabIndex = 10;
            this.BossGroup.TabStop = false;
            this.BossGroup.Text = "Boss Battle";
            // 
            // SubBar19
            // 
            this.SubBar19.Location = new System.Drawing.Point(19, 48);
            this.SubBar19.Name = "SubBar19";
            this.SubBar19.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar19.RightToLeftLayout = true;
            this.SubBar19.Size = new System.Drawing.Size(20, 12);
            this.SubBar19.TabIndex = 33;
            this.SubBar19.Visible = false;
            // 
            // SubBar18
            // 
            this.SubBar18.Location = new System.Drawing.Point(41, 48);
            this.SubBar18.Name = "SubBar18";
            this.SubBar18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar18.RightToLeftLayout = true;
            this.SubBar18.Size = new System.Drawing.Size(20, 12);
            this.SubBar18.TabIndex = 32;
            this.SubBar18.Visible = false;
            // 
            // SubBar17
            // 
            this.SubBar17.Location = new System.Drawing.Point(63, 48);
            this.SubBar17.Name = "SubBar17";
            this.SubBar17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar17.RightToLeftLayout = true;
            this.SubBar17.Size = new System.Drawing.Size(20, 12);
            this.SubBar17.TabIndex = 31;
            this.SubBar17.Visible = false;
            // 
            // TitleCard
            // 
            this.TitleCard.InitialImage = null;
            this.TitleCard.Location = new System.Drawing.Point(19, 66);
            this.TitleCard.Name = "TitleCard";
            this.TitleCard.Size = new System.Drawing.Size(416, 155);
            this.TitleCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TitleCard.TabIndex = 30;
            this.TitleCard.TabStop = false;
            // 
            // SubBar16
            // 
            this.SubBar16.Location = new System.Drawing.Point(85, 48);
            this.SubBar16.Name = "SubBar16";
            this.SubBar16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar16.RightToLeftLayout = true;
            this.SubBar16.Size = new System.Drawing.Size(20, 12);
            this.SubBar16.TabIndex = 21;
            this.SubBar16.Visible = false;
            // 
            // SubBar15
            // 
            this.SubBar15.Location = new System.Drawing.Point(107, 48);
            this.SubBar15.Name = "SubBar15";
            this.SubBar15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar15.RightToLeftLayout = true;
            this.SubBar15.Size = new System.Drawing.Size(20, 12);
            this.SubBar15.TabIndex = 20;
            this.SubBar15.Visible = false;
            // 
            // SubBar14
            // 
            this.SubBar14.Location = new System.Drawing.Point(129, 48);
            this.SubBar14.Name = "SubBar14";
            this.SubBar14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar14.RightToLeftLayout = true;
            this.SubBar14.Size = new System.Drawing.Size(20, 12);
            this.SubBar14.TabIndex = 19;
            this.SubBar14.Visible = false;
            // 
            // SubBar13
            // 
            this.SubBar13.Location = new System.Drawing.Point(151, 48);
            this.SubBar13.Name = "SubBar13";
            this.SubBar13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar13.RightToLeftLayout = true;
            this.SubBar13.Size = new System.Drawing.Size(20, 12);
            this.SubBar13.TabIndex = 18;
            this.SubBar13.Visible = false;
            // 
            // SubBar12
            // 
            this.SubBar12.Location = new System.Drawing.Point(173, 48);
            this.SubBar12.Name = "SubBar12";
            this.SubBar12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar12.RightToLeftLayout = true;
            this.SubBar12.Size = new System.Drawing.Size(20, 12);
            this.SubBar12.TabIndex = 17;
            this.SubBar12.Visible = false;
            // 
            // SubBar11
            // 
            this.SubBar11.Location = new System.Drawing.Point(195, 48);
            this.SubBar11.Name = "SubBar11";
            this.SubBar11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar11.RightToLeftLayout = true;
            this.SubBar11.Size = new System.Drawing.Size(20, 12);
            this.SubBar11.TabIndex = 16;
            this.SubBar11.Visible = false;
            // 
            // SubBar10
            // 
            this.SubBar10.Location = new System.Drawing.Point(217, 48);
            this.SubBar10.Name = "SubBar10";
            this.SubBar10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar10.RightToLeftLayout = true;
            this.SubBar10.Size = new System.Drawing.Size(20, 12);
            this.SubBar10.TabIndex = 15;
            this.SubBar10.Visible = false;
            // 
            // SubBar9
            // 
            this.SubBar9.Location = new System.Drawing.Point(239, 48);
            this.SubBar9.Name = "SubBar9";
            this.SubBar9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar9.RightToLeftLayout = true;
            this.SubBar9.Size = new System.Drawing.Size(20, 12);
            this.SubBar9.TabIndex = 14;
            this.SubBar9.Visible = false;
            // 
            // SubBar8
            // 
            this.SubBar8.Location = new System.Drawing.Point(261, 48);
            this.SubBar8.Name = "SubBar8";
            this.SubBar8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar8.RightToLeftLayout = true;
            this.SubBar8.Size = new System.Drawing.Size(20, 12);
            this.SubBar8.TabIndex = 13;
            this.SubBar8.Visible = false;
            // 
            // SubBar7
            // 
            this.SubBar7.Location = new System.Drawing.Point(283, 48);
            this.SubBar7.Name = "SubBar7";
            this.SubBar7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar7.RightToLeftLayout = true;
            this.SubBar7.Size = new System.Drawing.Size(20, 12);
            this.SubBar7.TabIndex = 12;
            this.SubBar7.Visible = false;
            // 
            // SubBar6
            // 
            this.SubBar6.Location = new System.Drawing.Point(305, 48);
            this.SubBar6.Name = "SubBar6";
            this.SubBar6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar6.RightToLeftLayout = true;
            this.SubBar6.Size = new System.Drawing.Size(20, 12);
            this.SubBar6.TabIndex = 11;
            this.SubBar6.Visible = false;
            // 
            // SubBar5
            // 
            this.SubBar5.Location = new System.Drawing.Point(327, 48);
            this.SubBar5.Name = "SubBar5";
            this.SubBar5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar5.RightToLeftLayout = true;
            this.SubBar5.Size = new System.Drawing.Size(20, 12);
            this.SubBar5.TabIndex = 10;
            this.SubBar5.Visible = false;
            // 
            // SubBar4
            // 
            this.SubBar4.Location = new System.Drawing.Point(349, 48);
            this.SubBar4.Name = "SubBar4";
            this.SubBar4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar4.RightToLeftLayout = true;
            this.SubBar4.Size = new System.Drawing.Size(20, 12);
            this.SubBar4.TabIndex = 9;
            this.SubBar4.Visible = false;
            // 
            // SubBar3
            // 
            this.SubBar3.Location = new System.Drawing.Point(371, 48);
            this.SubBar3.Name = "SubBar3";
            this.SubBar3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar3.RightToLeftLayout = true;
            this.SubBar3.Size = new System.Drawing.Size(20, 12);
            this.SubBar3.TabIndex = 8;
            this.SubBar3.Visible = false;
            // 
            // SubBar2
            // 
            this.SubBar2.Location = new System.Drawing.Point(393, 48);
            this.SubBar2.Name = "SubBar2";
            this.SubBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar2.RightToLeftLayout = true;
            this.SubBar2.Size = new System.Drawing.Size(20, 12);
            this.SubBar2.TabIndex = 7;
            this.SubBar2.Visible = false;
            // 
            // SubBar1
            // 
            this.SubBar1.Location = new System.Drawing.Point(415, 48);
            this.SubBar1.Name = "SubBar1";
            this.SubBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubBar1.RightToLeftLayout = true;
            this.SubBar1.Size = new System.Drawing.Size(20, 12);
            this.SubBar1.TabIndex = 6;
            this.SubBar1.Visible = false;
            // 
            // BossBar
            // 
            this.BossBar.Location = new System.Drawing.Point(19, 30);
            this.BossBar.Maximum = 2500;
            this.BossBar.Name = "BossBar";
            this.BossBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BossBar.RightToLeftLayout = true;
            this.BossBar.Size = new System.Drawing.Size(416, 16);
            this.BossBar.TabIndex = 5;
            // 
            // BossName
            // 
            this.BossName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BossName.Location = new System.Drawing.Point(19, 227);
            this.BossName.Name = "BossName";
            this.BossName.ReadOnly = true;
            this.BossName.Size = new System.Drawing.Size(634, 20);
            this.BossName.TabIndex = 4;
            this.BossName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BossPicture
            // 
            this.BossPicture.Location = new System.Drawing.Point(441, 30);
            this.BossPicture.Name = "BossPicture";
            this.BossPicture.Size = new System.Drawing.Size(212, 191);
            this.BossPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BossPicture.TabIndex = 3;
            this.BossPicture.TabStop = false;
            // 
            // UseSkillButton
            // 
            this.UseSkillButton.Location = new System.Drawing.Point(7, 479);
            this.UseSkillButton.Name = "UseSkillButton";
            this.UseSkillButton.Size = new System.Drawing.Size(81, 23);
            this.UseSkillButton.TabIndex = 11;
            this.UseSkillButton.Text = "Use Skill";
            this.UseSkillButton.UseVisualStyleBackColor = true;
            this.UseSkillButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UseSkillButton_MouseClick);
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ProfilePic
            // 
            this.ProfilePic.Location = new System.Drawing.Point(7, 316);
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.Size = new System.Drawing.Size(174, 155);
            this.ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePic.TabIndex = 34;
            this.ProfilePic.TabStop = false;
            // 
            // FightsLeft
            // 
            this.FightsLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FightsLeft.Location = new System.Drawing.Point(7, 534);
            this.FightsLeft.Name = "FightsLeft";
            this.FightsLeft.ReadOnly = true;
            this.FightsLeft.Size = new System.Drawing.Size(174, 20);
            this.FightsLeft.TabIndex = 35;
            this.FightsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentFight
            // 
            this.CurrentFight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentFight.Location = new System.Drawing.Point(7, 508);
            this.CurrentFight.Name = "CurrentFight";
            this.CurrentFight.ReadOnly = true;
            this.CurrentFight.Size = new System.Drawing.Size(174, 20);
            this.CurrentFight.TabIndex = 36;
            this.CurrentFight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UseItemButton
            // 
            this.UseItemButton.Location = new System.Drawing.Point(406, 532);
            this.UseItemButton.Name = "UseItemButton";
            this.UseItemButton.Size = new System.Drawing.Size(76, 23);
            this.UseItemButton.TabIndex = 37;
            this.UseItemButton.Text = "Use Item";
            this.UseItemButton.UseVisualStyleBackColor = true;
            this.UseItemButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UseItemButton_MouseClick);
            // 
            // ItemList
            // 
            this.ItemList.FormattingEnabled = true;
            this.ItemList.Location = new System.Drawing.Point(406, 368);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(76, 134);
            this.ItemList.TabIndex = 38;
            this.ItemList.SelectedIndexChanged += new System.EventHandler(this.ItemList_SelectedIndexChanged);
            // 
            // RemainingItemBox
            // 
            this.RemainingItemBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemainingItemBox.Location = new System.Drawing.Point(406, 508);
            this.RemainingItemBox.Name = "RemainingItemBox";
            this.RemainingItemBox.ReadOnly = true;
            this.RemainingItemBox.Size = new System.Drawing.Size(76, 20);
            this.RemainingItemBox.TabIndex = 39;
            this.RemainingItemBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UseRelic
            // 
            this.UseRelic.Location = new System.Drawing.Point(100, 479);
            this.UseRelic.Name = "UseRelic";
            this.UseRelic.Size = new System.Drawing.Size(81, 23);
            this.UseRelic.TabIndex = 40;
            this.UseRelic.Text = "Use Relic";
            this.UseRelic.UseVisualStyleBackColor = true;
            this.UseRelic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UseRelic_MouseClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // DungeonGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 565);
            this.Controls.Add(this.UseRelic);
            this.Controls.Add(this.RemainingItemBox);
            this.Controls.Add(this.ItemList);
            this.Controls.Add(this.UseItemButton);
            this.Controls.Add(this.BossGroup);
            this.Controls.Add(this.CurrentFight);
            this.Controls.Add(this.FightsLeft);
            this.Controls.Add(this.ProfilePic);
            this.Controls.Add(this.UseSkillButton);
            this.Controls.Add(this.TargetGroup);
            this.Controls.Add(this.TurnBox);
            this.Controls.Add(this.EnemyGroup);
            this.Controls.Add(this.Skills);
            this.Controls.Add(this.PlayerHealth);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.CombatLog);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DungeonGUI";
            this.Text = "Dungeon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DungeonGUI_FormClosing);
            this.Load += new System.EventHandler(this.DungeonGUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DungeonGUI_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EnemyGroup.ResumeLayout(false);
            this.EnemyGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic1)).EndInit();
            this.TargetGroup.ResumeLayout(false);
            this.TargetGroup.PerformLayout();
            this.BossGroup.ResumeLayout(false);
            this.BossGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitleCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CombatLog;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.ProgressBar PlayerHealth;
        private System.Windows.Forms.ListBox Skills;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.GroupBox EnemyGroup;
        private System.Windows.Forms.TextBox TurnBox;
        private System.Windows.Forms.PictureBox EnemyPic1;
        private System.Windows.Forms.PictureBox EnemyPic3;
        private System.Windows.Forms.PictureBox EnemyPic2;
        private System.Windows.Forms.ProgressBar EnemyBar1;
        private System.Windows.Forms.ProgressBar EnemyBar3;
        private System.Windows.Forms.ProgressBar EnemyBar2;
        private System.Windows.Forms.TextBox EnemyBox1;
        private System.Windows.Forms.TextBox EnemyBox3;
        private System.Windows.Forms.TextBox EnemyBox2;
        private System.Windows.Forms.GroupBox TargetGroup;
        private System.Windows.Forms.RadioButton Target2;
        private System.Windows.Forms.RadioButton Target1;
        private System.Windows.Forms.RadioButton Target3;
        private System.Windows.Forms.GroupBox BossGroup;
        private System.Windows.Forms.PictureBox BossPicture;
        private System.Windows.Forms.ProgressBar BossBar;
        private System.Windows.Forms.ProgressBar SubBar1;
        private System.Windows.Forms.ProgressBar SubBar9;
        private System.Windows.Forms.ProgressBar SubBar8;
        private System.Windows.Forms.ProgressBar SubBar7;
        private System.Windows.Forms.ProgressBar SubBar6;
        private System.Windows.Forms.ProgressBar SubBar5;
        private System.Windows.Forms.ProgressBar SubBar4;
        private System.Windows.Forms.ProgressBar SubBar3;
        private System.Windows.Forms.ProgressBar SubBar2;
        private System.Windows.Forms.ProgressBar SubBar16;
        private System.Windows.Forms.ProgressBar SubBar15;
        private System.Windows.Forms.ProgressBar SubBar14;
        private System.Windows.Forms.ProgressBar SubBar13;
        private System.Windows.Forms.ProgressBar SubBar12;
        private System.Windows.Forms.ProgressBar SubBar11;
        private System.Windows.Forms.ProgressBar SubBar10;
        private System.Windows.Forms.Button UseSkillButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox TitleCard;
        private System.Windows.Forms.ToolStripMenuItem useBountyKeyToolStripMenuItem;
        private System.Windows.Forms.TextBox BossName;
        private System.Windows.Forms.ToolStripMenuItem useEXBountyKeyToolStripMenuItem;
        private System.Windows.Forms.PictureBox ProfilePic;
        private System.Windows.Forms.TextBox FightsLeft;
        private System.Windows.Forms.TextBox CurrentFight;
        private System.Windows.Forms.Button UseItemButton;
        private System.Windows.Forms.ListBox ItemList;
        private System.Windows.Forms.TextBox RemainingItemBox;
        private System.Windows.Forms.Button UseRelic;
        private System.Windows.Forms.ProgressBar SubBar19;
        private System.Windows.Forms.ProgressBar SubBar18;
        private System.Windows.Forms.ProgressBar SubBar17;
        private System.Windows.Forms.ToolStripMenuItem useElderKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}