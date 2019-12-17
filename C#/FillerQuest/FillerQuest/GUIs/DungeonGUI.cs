using AscendedRPG.Enemies;
using AscendedRPG.Files;
using AscendedRPG.GUIs;
using FillerQuest.GUIs;
using FillerQuest.Relics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class DungeonGUI : Form
    {
        private Player p;

        private Dungeon d;

        private TurnPress tp;
        private Random r;
        private List<ProgressBar> sbars;
        private MusicManager mm;
        private int eTurn;
        private BossCalculator bc;
        private Relic relic;

        public bool UserClosing { get; set; }
        public bool IsPlayerTurn { get; set; }

        public DungeonGUI(int t, MusicManager jbox)
        {
            r = new Random();
            eTurn = 0;
            sbars = new List<ProgressBar>();
            mm = jbox;
            d = new Dungeon(t);
            bc = new BossCalculator();
            InitializeComponent();
        }

        private void DungeonGUI_Load(object sender, EventArgs e)
        {
            p = SaveManager.LoadGame();

            RelicManager rm = SaveManager.LoadRelicManager();

            relic = rm.Current;

            ProfilePic.Image = Image.FromFile(p.Picture);

            RegisterPlayerOffensives();

            RegisterPlayerPassives();

            RegisterBountyKeys();

            RegisterEXBountyKeys();

            if (p.GodLordKeys > 0 && d.CanUseBountyKey())
                useElderKeyToolStripMenuItem.Enabled = true;

            RegisterItems();

            int hp = p.GetHP() + p.Set.GetDefense() + p.stats[Stat.DEFENSE];

            PlayerHealth.Maximum = hp;
            PlayerHealth.Value = hp;

            if (relic != null)
                NameBox.Text = $"{rm.Current.ToString()} {p.Name}";
            else
                NameBox.Text = $"[None] {p.Name}";

            Text = $"Tier {d.tier} Dungeon";
           
            sbars.Add(SubBar1);
            sbars.Add(SubBar2);
            sbars.Add(SubBar3);
            sbars.Add(SubBar4);
            sbars.Add(SubBar5);
            sbars.Add(SubBar6);
            sbars.Add(SubBar7);
            sbars.Add(SubBar8);
            sbars.Add(SubBar9);
            sbars.Add(SubBar10);
            sbars.Add(SubBar11);
            sbars.Add(SubBar12);
            sbars.Add(SubBar13);
            sbars.Add(SubBar14);
            sbars.Add(SubBar15);
            sbars.Add(SubBar16);
            sbars.Add(SubBar17);
            sbars.Add(SubBar18);
            sbars.Add(SubBar19);

            mm.SetFloorSong(d.tier);

            mm.SetBossSong(r.Next(1,d.tier));

            mm.SetInvaderSong(d.tier);

            mm.SetBountySong(d.tier);

            mm.SetEXSong();

            mm.PlayFloorSong();

            mm.SetElderSong(d.tier);

            FightsLeft.Text = $"Fights remaining: {d.GetFights()}";

            CurrentFight.Text = $"Current Fight: {d.GetCurrentFight()}";

            CreateEnemies();
        }

        private void RegisterItems()
        {
            ItemList.Items.Clear();
            foreach(FillerQuest.Item item in p.Items)
            {
                if(item.Quantity > 0)
                {
                    ItemList.Items.Add(item);
                }
            }

            if (ItemList.Items.Count > 0)
                ItemList.SelectedIndex = 0;
            else
                RemainingItemBox.Text = $"{0}";
        }

        private void RegisterBountyKeys()
        {
            if(p.BountyKeys.Count > 0)
            {
                if(p.BountyKeys.Contains(d.tier))
                {
                    useBountyKeyToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void RegisterEXBountyKeys()
        {
            if (p.EXBountyKeys.Count > 0)
            {
                if (p.EXBountyKeys.Contains(d.tier))
                {
                    useEXBountyKeyToolStripMenuItem.Visible = true;
                    useEXBountyKeyToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void RegisterPlayerOffensives()
        {
            Skills.DataSource = p.Set.ActiveSkills;
        }

        private void RegisterPlayerPassives()
        {
            if(p.Set.ReserveSkills.Count > 0)
            {
                foreach(Skill reserve in p.Set.ReserveSkills)
                {
                    int type = reserve.S_Type;
                    if (type == SkillType.PASSIVE_BUFF)
                    {
                        p.stats[reserve.Element] += reserve.Multiplier;
                    }
                    else if (type == SkillType.PASSIVE_VOID)
                    {
                        p.resistances[reserve.Element] += reserve.Multiplier;
                    }
                }
            }
        }

        private void CreateEnemies()
        {
            PictureBox[] e_icons = { EnemyPic1, EnemyPic2, EnemyPic3 };
            TextBox[] e_boxes = { EnemyBox1, EnemyBox2, EnemyBox3 };
            ProgressBar[] e_bars = { EnemyBar1, EnemyBar2, EnemyBar3 };
            RadioButton[] c_boxes = { Target1, Target2, Target3 };

            IsPlayerTurn = true;

            tp = new TurnPress(p.Turns + p.stats[Stat.TURNS]);

            TurnBox.Text = tp.PrintIcons();

            for (int e = 0; e < e_icons.Length; e++)
            {
                if(e_icons[e].Image != null)
                {
                    e_icons[e].Image = null;
                }
                e_boxes[e].Text = "";
                c_boxes[e].Enabled = false;
            }

            d.GenerateFight();
            c_boxes[0].Checked = true;

            if (d.isBoss)
            {
                BossGroup.Visible = true;
                EnemyGroup.Visible = false;
                useBountyKeyToolStripMenuItem.Enabled = false;
                useEXBountyKeyToolStripMenuItem.Enabled = false;
                useElderKeyToolStripMenuItem.Enabled = false;

                Enemy boss = d.enemies[0];
                
                BossPicture.Image = Image.FromFile(boss.image);
                BossName.Text = boss.weakName;

                bc.CheckDefault(boss.hp);
                bc.SetSubBars(boss.hp);
                BossBar.Maximum = bc.hp_default;

                int subs = bc.subbars;
                int baseB = bc.baseBar;

                for(int i = 0; i < subs; i++)
                {
                    sbars[i].Visible = true;
                    sbars[i].Value = sbars[i].Maximum;
                }

                BossBar.Value = baseB;
                mm.Pause();

                if (d.isFinalBoss)
                {
                    mm.Stop();
                    mm.SetFinalBossSong();
                    mm.PlayFinalBossSong();
                }
                else if (d.isElderGod)
                    mm.PlayElderSong();
                else if (d.isEXBoss || d.isEXInvader)
                    mm.PlayEXSong();
                else if (d.isBountyBoss)
                    mm.PlayBountySong();
                else if (d.isInvader)
                    mm.PlayInvaderSong();
                else
                    mm.PlayBossSong();

                TitleCard.Image = Image.FromFile(boss.titleCard);
            }
            else
            {
                BossGroup.Visible = false;
                EnemyGroup.Visible = true;

                switch (d.enemies.Count)
                {
                    case 1:
                        e_icons[1].Image = Image.FromFile(d.enemies[0].image);
                        e_boxes[1].Text = d.enemies[0].weakName;
                        e_bars[1].Maximum = d.enemies[0].hp;
                        e_bars[1].Value = d.enemies[0].hp; // change later
                        c_boxes[0].Enabled = true;
                        break;
                    case 2:
                        int x = 0;
                        for (int i = 0; i < d.enemies.Count; i++)
                        {
                            e_icons[x].Image = Image.FromFile(d.enemies[i].image);
                            e_boxes[x].Text = d.enemies[i].weakName;
                            e_bars[x].Maximum = d.enemies[i].hp;
                            e_bars[x].Value = d.enemies[i].hp;
                            c_boxes[i].Enabled = true;
                            x += 2;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < d.enemies.Count; i++)
                        {
                            e_icons[i].Image = Image.FromFile(d.enemies[i].image);
                            e_boxes[i].Text = d.enemies[i].weakName;
                            e_bars[i].Maximum = d.enemies[i].hp;
                            e_bars[i].Value = d.enemies[i].hp;
                            c_boxes[i].Enabled = true;
                        }
                        break;
                }
            }
        }


        private void ReduceBar(ProgressBar bar, int index, Skill skill, TextBox e_box)
        {
            Enemy target = d.enemies[index];

            // generalize this for boss battle
            bool critWeak = false;

            int damage = SkillManager.CalculateDamage(skill.Damage, skill.Multiplier) + p.stats[Stat.ATTACK];

            if (p.elementalAttackModifier[skill.Element] == 1)
                damage += (int)(damage * .25);

            int c = r.Next(0, 100);

            if (c < 25)
            {
                damage = (damage * 2) + p.stats[Stat.CRITS]; // crit damge + critboost
                CombatLog.AppendText("A critical was hit.");
                CombatLog.AppendText(Environment.NewLine);
                critWeak = true;
            }

            if (d.enemies[index].weakness.Contains(skill.Element))
            {
                damage = (damage * 2) + p.stats[Stat.CRITS]; // treated like crits too
                CombatLog.AppendText($"A weakness was hit! {target.name} was weak to {SkillManager.ElementToString(skill.Element)}!");

                if(d.IsNewWeakness(target.image, skill.Element))
                {
                    d.NewWeaknessFound(target, skill.Element);
                    e_box.Text = target.weakName;
                    UpdateTextBoxes();
                }

                CombatLog.AppendText(Environment.NewLine);
                critWeak = true;
            }

            if (d.isBoss)
            {
                DamageBoss(target, damage);
                CombatLog.AppendText($"It hit for {damage} damage.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
            }
            else
            {
                DamageEnemy(target, bar, damage, index);
            }

            if (critWeak)
                tp.HalfTurn();
            else
                tp.FullTurn();

            if (!d.isBoss)
            {
                CheckHP();
            }
            CheckTurnPlayer();
        }

        private void UpdateTextBoxes()
        {
            TextBox[] e_boxes = { EnemyBox1, EnemyBox2, EnemyBox3 };

            switch (d.maxEnemies)
            {
                case 1:
                    d.GetPlayerKnownWeaknesses(d.enemies[0]);
                    e_boxes[1].Text = d.enemies[0].weakName;
                    break;
                case 2:
                    int x = 0;
                    for (int i = 0; i < d.enemies.Count; i++)
                    {
                        d.GetPlayerKnownWeaknesses(d.enemies[i]);
                        e_boxes[x].Text = d.enemies[i].weakName;
                        x += 2;
                    }
                    break;
                case 3:
                    for (int i = 0; i < d.enemies.Count; i++)
                    {
                        d.GetPlayerKnownWeaknesses(d.enemies[i]);
                        e_boxes[i].Text = d.enemies[i].weakName;
                    }
                    break;
            }
        }

        private void DamageEnemy(Enemy target, ProgressBar bar, int damage, int index)
        {
            RadioButton[] c_boxes = { Target1, Target2, Target3 };
            string log;

            if (bar.Value - damage <= 0)
            {
                log = $"It hit for {damage} damage. {target.name} died!";
                bar.Value = 0;
                target.hp = 0;
                d.enemyTurns--;
                c_boxes[index].Enabled = false;
                c_boxes[index].Checked = false;

                if(target.isEx)
                {
                    DistributeRewards(d.GetArmorRewards(1, true, r));
                }

                if(target.name.Equals("Pot of Greed"))
                {
                    DistributeRewards(d.GetArmorRewards(r.Next(1, 3), false, r));
                }

                foreach (RadioButton rb in c_boxes)
                {
                    if (rb.Enabled && !rb.Checked)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
            else
            {
                log = $"It hit for {damage} damage.";
                bar.Value -= damage;
                target.hp -= damage;
            }

            CombatLog.AppendText(log);
            CombatLog.AppendText(Environment.NewLine);
            CombatLog.AppendText(Environment.NewLine);
        }

        private void DistributeRewards(List<Armor> rewards)
        {
            for (int i = 0; i < rewards.Count; i++)
            {
                if (p.Inventory.Count < 100)
                    p.Inventory.Add(rewards[i]);
                else
                    p.ReserveArmor.Add(rewards[i]);
            }

            SaveManager.SaveGame(p);
        }

        private void DamageBoss(Enemy target, int damage)
        {
            if (BossBar.Value - damage <= 0)
            {
                if(bc.subbars == 0)
                {
                    BossBar.Value = 0;
                    CombatLog.AppendText($"{target.name} died!");
                    CombatLog.AppendText(Environment.NewLine);
                    CombatLog.AppendText(Environment.NewLine);

                    mm.StopBoss();
                    mm.SetBossSong(r.Next(1, d.tier));
                    mm.ResumeSong();

                    DungeonCheck();
                }
                else
                {
                    damage -= damage - BossBar.Value;
                    BossBar.Value = bc.hp_default;
                    sbars[bc.subbars - 1].Value = 0;
                    bc.subbars--;
                    DamageBoss(target, damage);
                }
            }
            else
            {
                BossBar.Value -= damage;
            }
        }

        private void CheckTurnPlayer()
        {
            if (tp.turnEnd)
            {
                // begin enemy turn
                IsPlayerTurn = false;
                tp = new TurnPress(d.enemyTurns * 2);

                CombatLog.AppendText("Player turn over, it is now the enemy's turn.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);

                TurnBox.Text = tp.PrintIcons();

                UseSkillButton.Enabled = false;
                UseItemButton.Enabled = false;
                UseRelic.Enabled = false;
                IsPlayerTurn = false;

                if (!d.IsDungeonComplete())
                {
                    eTurn = 0;
                    timer.Start();
                }
            }
            else
            {
                TurnBox.Text = tp.PrintIcons();
            }
        }

        private void CheckTurnEnemies()
        {
            if (tp.turnEnd)
            {
                timer.Stop();
                // begin player turn
                IsPlayerTurn = true;
                tp = new TurnPress(p.Turns + p.stats[Stat.TURNS]);
                UseSkillButton.Enabled = true;
                UseItemButton.Enabled = true;
                UseRelic.Enabled = true;
                IsPlayerTurn = true;
                CombatLog.AppendText($"Enemy turn over, it is now {p.Name}'s turn.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
                TurnBox.Text = tp.PrintIcons();
            }
            else
            {
                TurnBox.Text = tp.PrintIcons();
            }  
        }

        private void EnemyAttack()
        {
            if (eTurn == d.enemies.Count)
            {
                eTurn = 0;
            }

            Enemy attacker = d.enemies[eTurn];

            if (attacker.hp > 0)
            {
                Skill s = attacker.active[r.Next(0, attacker.active.Count)];

                CombatLog.AppendText($"{attacker.name} used {s.Name}");
                CombatLog.AppendText(Environment.NewLine);

                int h = r.Next(0, 100);

                if (h < 95)
                {
                    int damage = SkillManager.CalculateDamage(s.Damage, s.Multiplier);

                    damage -= p.resistances[s.Element];

                    bool crit = IsCritHit();

                    if (crit)
                    {
                        damage = (damage * 2); // crit damage
                        tp.HalfTurn();
                    }
                    else
                    {
                        tp.FullTurn();
                    }

                    string log;

                    if (PlayerHealth.Value - damage <= 0)
                    {
                        timer.Stop();
                        PlayerHealth.Value = 0;
                        tp.turnEnd = true;
                        log = "You died! Returning you back to the Select Dungeon screen...";
                        MessageBox.Show(log);
                        Run();
                    }
                    else
                    {
                        log = $"It hit for {damage} damage.";

                        int v = PlayerHealth.Value - damage;

                        if (v >= PlayerHealth.Maximum)
                        {
                            PlayerHealth.Value = PlayerHealth.Maximum;
                        }
                        else
                        {
                            PlayerHealth.Value -= damage;
                        }

                        CombatLog.AppendText(log);
                        CombatLog.AppendText(Environment.NewLine);
                        CombatLog.AppendText(Environment.NewLine);
                    }

                }
                else
                {
                    CombatLog.AppendText("The attack missed.");
                    CombatLog.AppendText(Environment.NewLine);
                    CombatLog.AppendText(Environment.NewLine);
                    tp.Miss();
                }

                CheckTurnEnemies();
            }
            eTurn++;
        }

        private bool IsCritHit()
        {
            int c = r.Next(0, 100);

            if (c < 25)
            {
                CombatLog.AppendText("A critical was hit.");
                CombatLog.AppendText(Environment.NewLine);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CheckHP()
        {
            ProgressBar[] e_bars = { EnemyBar1, EnemyBar2, EnemyBar3 };
            int count = 0;
            foreach(ProgressBar pb in e_bars)
            {
                if(pb.Value == 0)
                {
                    count++;
                }
            }
            if(count == 3)
            {
                DungeonCheck();
            }
        }

        private void DungeonCheck()
        {
            d.EndFight();
            bool f = d.IsDungeonComplete();
            if (!f)
            {
                CombatLog.AppendText($"All enemies killed. Remaining fights: {d.GetFights()}");
                int m = d.tier * r.Next(50, 61) + 1000;
                CombatLog.AppendText(Environment.NewLine);
                FightsLeft.Text = $"Fights remaining: {d.GetFights()}";
                CurrentFight.Text = $"Current Fight: {d.GetCurrentFight()}";

                PlayerHealth.Value = PlayerHealth.Maximum;

                if(d.isBoss)
                {
                    bc.ResetBars();

                    m = d.tier * r.Next(80, 101);
                    foreach (ProgressBar sb in sbars)
                    {
                        sb.Visible = false;
                    }

                    if(d.isEXBoss)
                    {
                        p.Set.ReserveSkills.AddRange(d.GetPassiveReserveSkillRewards());
                        d.isEXBoss = false;
                        m += 5000;
                    }

                    if(d.isInvader)
                    {
                        p.Set.ReserveSkills.AddRange(d.GetPassiveReserveSkillRewards());
                        SaveManager.SaveGame(p);
                        d.isInvader = false;
                        d.isEXInvader = false;
                        m += 8000;
                    }

                    if(d.isBountyBoss)
                    {
                        p.Set.ReserveSkills.AddRange(d.GetPassiveReserveSkillRewards());
                        SaveManager.SaveGame(p);
                        d.isBountyBoss = false;
                        d.isEXInvader = false;
                        m += 10000;
                    }

                    if(d.isElderGod)
                    {
                        p.AddDellenCoin(m + 50000);
                        d.ForceEnd();
                        DungeonCheck();
                    }

                    if (p.BountyKeys.Contains(d.tier) && d.CanUseBountyKey())
                    {
                        useBountyKeyToolStripMenuItem.Enabled = true;
                    }

                    if (p.EXBountyKeys.Contains(d.tier) && d.CanUseBountyKey())
                    {
                        useEXBountyKeyToolStripMenuItem.Enabled = true;
                    }

                    if (p.GodLordKeys > 0 && d.CanUseBountyKey())
                    {
                        useElderKeyToolStripMenuItem.Enabled = true;
                    }    
                }

                CombatLog.AppendText($"Money earned: {m}");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
                p.AddDellenCoin(m);
                SaveManager.SaveGame(p);
                CreateEnemies();
            }
            else
            {
                mm.Stop();
                mm.StopBoss();
                p.ResetElementalMods();
                if (d.tier == 500)
                {
                    // show epilogue here
                    Visible = false;

                    string[] d =
                    { "After a long journey, you've finally done it.",
                    "You have completed one of the most nonsensically grindy journies of all time.",
                    "After days of training, the last great challenge of the Endless Dungeon has fallen before you.",
                    "As a reward for your efforts, you will now receive the answer you seek.",
                    "The Endless Dungeon is not truly endless. No, it is a finite labyrinth meant as a test.",
                    "Once every eon, it manifests itself in your world, looking for challengers who can best it.",
                    "Those who are willing to take on the tower underestimate its size.",
                    "They enter confident and leave in despair.",
                    "The reason why the tower imposes a challenge of this magnitude upon those who enter it...",
                    "...is because it seeks a new master.",
                    "When the last eon draws to an end, the old master must resign his position onto to the worthy few who best him.",
                    "Now that you have accomplished this feat, you will assume the role of the new master.",
                    "And, next time the challenge rises once more... you must be prepared to fight for your position.",
                    "Unless you cheated to get this far, then you suck.",
                    "THE END"};

                    DialogBox db = new DialogBox(d);
                    db.StartPosition = FormStartPosition.Manual;
                    db.Location = Location;
                    db.ShowDialog();
                    db.ShowDialog();

                    Visible = true;
                }
                else
                {
                    MessageBox.Show("Dungeon Complete.");
                }

                // receive inventory rewards
                List<Armor> rewards = d.GetArmorRewards(r.Next(2, 4), false, r);

                foreach (Armor a in rewards)
                {
                    if(p.Inventory.Count < 100)
                    {
                        p.Inventory.Add(a);
                    }
                    else
                    {
                        p.ReserveArmor.Add(a);
                    }
                }

                // receive additional rewards (passives)
                int passive = r.Next(0, 100);

                if (passive < 5)
                {
                    p.Set.ReserveSkills.AddRange(d.GetPassiveReserveSkillRewards());
                }

                if (d.tier == p.Tier && d.tier != 500)
                {
                    p.Tier++;
                }

                Run();
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Retreating from dungeon...");
            Run();
        }

        private void Run()
        {
            mm.StopBoss();
            mm.Stop();
            UserClosing = true;
            SaveManager.SaveGame(p);
            Close();
        }

        private void DungeonGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(!UserClosing)
                {
                    SaveManager.SaveGame(p);
                    Application.Exit();
                }
            }
        }

        private void UseSkillButton_MouseClick(object sender, MouseEventArgs e)
        {
            UseSelectedSkill();
        }

        private void UseSelectedSkill()
        {
            Skill s = Skills.SelectedItem as Skill;

            CombatLog.AppendText($"{p.Name} used {s.Name}");
            CombatLog.AppendText(Environment.NewLine);

            int h = r.Next(0, 100);

            if (h < 95)
            {
                try
                {
                    if (d.isBoss)
                    {
                        ReduceBar(BossBar, 0, s, BossName);
                    }
                    else
                    {
                        DealDamageToEnemies(s);
                    }
                }
                catch (Exception) { }
            }
            else
            {
                CombatLog.AppendText("The attack missed.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
                tp.Miss();
                CheckTurnPlayer();
            }
        }


        private void UseRelic_MouseClick(object sender, MouseEventArgs e)
        {
            UseRelicButton();
        }

        private void UseRelicButton()
        {
            if (relic != null && tp.icons > 1)
            {
                int h = r.Next(0, 100);
                if (h < 95)
                {
                    switch (relic.RelicType)
                    {
                        case 0:
                            int hp = (int)(relic.Damage * .01);

                            if ((PlayerHealth.Value + hp) >= PlayerHealth.Maximum)
                            {
                                PlayerHealth.Value = PlayerHealth.Maximum;
                            }
                            else
                            {
                                PlayerHealth.Value += hp;
                            }

                            DealDamageRelic(relic.Damage, 0);

                            break;
                        case 1:
                            int damage = relic.Damage * 2;

                            DealDamageRelic(damage, 0);

                            break;
                        default:
                            int accuracy = 100;

                            DealDamageRelic(relic.Damage, accuracy);

                            break;
                    }
                }
                else
                {
                    CombatLog.AppendText("The attack missed.");
                    CombatLog.AppendText(Environment.NewLine);
                    CombatLog.AppendText(Environment.NewLine);
                    tp.Miss();
                    CheckTurnPlayer();
                }
            }
        }

        private void DealDamageRelic(int damage, int accuracy)
        {
            if(d.isBoss)
            {
                ReduceBarRelic(BossBar, 0, damage, BossName, accuracy);
            }
            else
            {
                if (Target1.Checked)
                {
                    switch (d.maxEnemies)
                    {
                        case 1:
                            ReduceBarRelic(EnemyBar2, 0, damage, EnemyBox2, accuracy);
                            break;
                        default:
                            ReduceBarRelic(EnemyBar1, 0, damage, EnemyBox1, accuracy);
                            break;
                    }
                }
                else if (Target2.Checked)
                {
                    switch (d.maxEnemies)
                    {
                        case 2:
                            ReduceBarRelic(EnemyBar3, 1, damage, EnemyBox3, accuracy);
                            break;
                        case 3:
                            ReduceBarRelic(EnemyBar2, 1, damage, EnemyBox2, accuracy);
                            break;
                    }
                }
                else
                {
                    switch (d.maxEnemies)
                    {
                        case 3:
                            ReduceBarRelic(EnemyBar3, 2, damage, EnemyBox3, accuracy);
                            break;
                    }
                }
            }

        }

        private void ReduceBarRelic(ProgressBar bar, int index, int damage, TextBox e_box, int accuracy)
        {
            Enemy target = d.enemies[index];

            damage += p.stats[Stat.ATTACK];

            foreach(int elem in relic.Elements)
                if (p.elementalAttackModifier[elem] == 1)
                    damage += (int)(damage * .25);

            int c = r.Next(0, 100);

            if (c < 25 + accuracy)
            {
                damage = (damage * 2) + p.stats[Stat.CRITS]; // crit damge + critboost
                CombatLog.AppendText("A critical was hit.");
                CombatLog.AppendText(Environment.NewLine);
            }

            foreach (int elem in relic.Elements)
                if (d.enemies[index].weakness.Contains(elem))
                {
                    damage = (damage * 2) + p.stats[Stat.CRITS]; // treated like crits too
                    CombatLog.AppendText($"A weakness was hit! {target.name} was weak to {SkillManager.ElementToString(elem)}!");

                    if (d.IsNewWeakness(target.image, elem))
                    {
                        d.NewWeaknessFound(target, elem);
                        e_box.Text = target.weakName;
                        UpdateTextBoxes();
                    }

                    CombatLog.AppendText(Environment.NewLine);
                }

            if (d.isBoss)
            {
                DamageBoss(target, damage);
                CombatLog.AppendText($"It hit for {damage} damage.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
            }
            else
            {
                DamageEnemy(target, bar, damage, index);
            }

            for (int i = 0; i < 3; i++)
                tp.FullTurn();

            if (!d.isBoss)
            {
                CheckHP();
            }
            CheckTurnPlayer();
        }

        private void DealDamageToEnemies(Skill skill)
        {
            if (Target1.Checked)
            {
                switch (d.maxEnemies)
                {
                    case 1:
                        ReduceBar(EnemyBar2, 0, skill, EnemyBox2);
                        break;
                    default:
                        ReduceBar(EnemyBar1, 0, skill, EnemyBox1);
                        break;
                }
            }
            else if (Target2.Checked)
            {
                switch (d.maxEnemies)
                {
                    case 2:
                        ReduceBar(EnemyBar3, 1, skill, EnemyBox3);
                        break;
                    case 3:
                        ReduceBar(EnemyBar2, 1, skill, EnemyBox2);
                        break;
                }
            }
            else
            {
                switch (d.maxEnemies)
                {
                    case 3:
                        ReduceBar(EnemyBar3, 2, skill, EnemyBox3);
                        break;
                }
            }
        }


        private void UseItemButton_MouseClick(object sender, MouseEventArgs e)
        {
            UseItem();
        }

        private void UseItem()
        {
            try
            {
                FillerQuest.Item i = ItemList.SelectedItem as FillerQuest.Item;
                if (i.ItemType == 0)
                {
                    int hp = (int)(PlayerHealth.Maximum * .15);
                    if (PlayerHealth.Value + hp > PlayerHealth.Maximum)
                    {
                        PlayerHealth.Value = PlayerHealth.Maximum;
                    }
                    else
                    {
                        PlayerHealth.Value += hp;
                    }
                }
                else
                {
                    p.elementalAttackModifier[i.ItemType - 1] = 1;
                }

                p.Items[i.ItemType].Quantity--;
                RegisterItems();
            }
            catch (Exception)
            {
                RemainingItemBox.Text = 0.ToString();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EnemyAttack();
        }

        private void useBountyKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(d.GetFights() > 5)
            if (MessageBox.Show("You are about to summon a Bounty Boss. Do you wish to continue with this decision?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p.BountyKeys.Remove(d.tier);
                d.isBountyBoss = true;
                DisableUseKeys();

                CombatLog.AppendText($"You have used a Bounty Key for Tier {d.tier}. The next boss you face will be a Bounty Boss.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
            }
        }

        private void useEXBountyKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to summon an EX Bounty Boss. Do you wish to continue with this decision?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p.EXBountyKeys.Remove(d.tier);
                d.isBountyBoss = true;
                d.isEXInvader = true;
                DisableUseKeys();

                CombatLog.AppendText($"You have used an EX Bounty Key for Tier {d.tier}. The next boss you face will be an EX Bounty Boss.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
            }
        }

        private void useElderKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to summon an Elder God. Do you wish to continue with this decision?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                p.GodLordKeys--;
                d.isElderGod = true;

                DisableUseKeys();

                CombatLog.AppendText($"An Elder God approaches. May God have mercy on your soul.");
                CombatLog.AppendText(Environment.NewLine);
                CombatLog.AppendText(Environment.NewLine);
            }
        }

        private void DisableUseKeys()
        {
            useBountyKeyToolStripMenuItem.Enabled = false;
            useEXBountyKeyToolStripMenuItem.Enabled = false;
            useElderKeyToolStripMenuItem.Enabled = false;
        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string help = "Combat" +
                "\n\nCombat borrows from the Turn Press system from SMT. {00} represents a full turn, {0 represents a half turn." +
                "\n\nWhen you hit a critical or a weakness, you use up 1 half turn. If you attack but do not hit a critical or a weakness, you will either use up a half turn (if you have one) or a full turn." +
                " Missing an attack functions in the exact same way." +
                "\n\nEnemies all have a [???] next to their name. This represents a weakness you haven't found yet. Once you find this weakness, you'll know what it is for the rest of the game." +
                "\n\nTo attack, just click on the skill you want and press \"Use Skill.\"" +
                "\n\nWhenever you clear a set of enemies or a boss, you will heal to max HP." +
                "\n\nPotions or Element Elixers can be used to boost your stats without risking a turn during battle, however." +
                "\n\nFinally, if you're feeling overwhelmed, you can click \"Run\" to back out of the dungeon.";

            MessageBox.Show(help);
        }

        private void elementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string help = "Elemental Prefixes" +
                "\n\nFlaming: Fire" +
                "\nFlowing: Water" +
                "\nFreezing: Ice" +
                "\nShocking: Shock" +
                "\nBreezing: Wind" +
                "\nNuclear: Nuke" +
                "\nDark: Dark" +
                "\nBright: Light" +
                "\nRaging: Physical";

            MessageBox.Show(help);
        }

        private void rewardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string help = "Rewards" +
                "\n\nAll rewards give different quantities of money." +
                "\n\nCompleting a tier: 2-3 pieces of armor (not including charms) and a 5% chance of getting 1-2 passives (between +1, and +2)" +
                "\nNormal Enemies & Bosses: Money" +
                "\nPot of Greed: 1-2 pieces of armor" +
                "\nInvaders: 1-2 passives (between +1, and +2)" +
                "\nBounty Bosses: 1-2 passives (between +1, and +2)" +
                "\nEX Enemies: EX Armor" +
                "\nEX Bosses: 1-2 passives (between +1, and +2)" +
                "\nEX Invaders: 1-2 passives (between +3, and +4)" +
                "\nEX Bounty Bosses: 1-2 passives (between +3, and +4)";

            MessageBox.Show(help);
        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillerQuest.Item i = ItemList.SelectedItem as FillerQuest.Item;
                RemainingItemBox.Text = $"{i.Quantity}";
            }
            catch (Exception)
            {
                RemainingItemBox.Text = 0.ToString();
            }
        }

        private void DungeonGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if(IsPlayerTurn)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:

                        UseSelectedSkill();
                        break;

                    case Keys.E:

                        UseItem();
                        break;

                    case Keys.W:

                        try
                        {
                            if (ItemList.SelectedIndex - 1 < 0)
                                ItemList.SelectedIndex = ItemList.Items.Count - 1;
                            else
                                ItemList.SelectedIndex--;
                        }
                        catch (ArgumentOutOfRangeException) { }


                        break;

                    case Keys.S:

                        try
                        {
                            if (ItemList.SelectedIndex + 1 > ItemList.Items.Count - 1)
                                ItemList.SelectedIndex = 0;
                            else
                                ItemList.SelectedIndex++;
                        }
                        catch (ArgumentOutOfRangeException) { }

                        break;

                    case Keys.F:

                        UseRelicButton();

                        break;

                }
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpGUI help = new HelpGUI();
            help.StartPosition = FormStartPosition.Manual;
            help.Location = Location;
            help.ShowDialog();
        }
    }
}
