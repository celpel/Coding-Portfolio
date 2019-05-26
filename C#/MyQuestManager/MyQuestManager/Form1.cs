using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using MySql.Data.MySqlClient;

namespace MyQuestManager
{
    public partial class bqm_players : Form
    {
        private EnemyManager _em;
        private List<Player> _players;
        private List<Enemy> _enemies;
        private long e_attacker;
        bool _isBoss;

        public bqm_players()
        {
            e_attacker = 0;
            _isBoss = false;
            _em = new EnemyManager();
            _players = new List<Player>();
            _enemies = new List<Enemy>();
            InitializeComponent();
        }

        //access a local SQL database to acquire all players present in a game
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _players.Clear();
            string dblink = @"Server=localhost;uid=root;pwd=root;database=myschema";

            try
            {
                var conn = new MySqlConnection(dblink);

                conn.Open();
                // playercount is assumed to never reach 6+ digits
                string q = "SELECT * FROM CURRENTPLAYERS";
                MySqlCommand m = new MySqlCommand(q, conn);
                MySqlDataReader ms = m.ExecuteReader();

                while (ms.Read())
                {
                    Player pl = new Player
                    {
                        Name = (string)ms["CNAME"],
                        Hp = (long)ms["HP"],
                        Mp = (long)ms["MP"],
                        Lvl = (long)ms["LVL"],
                        Xp = (long)ms["EXP"],
                        Attk = (long)ms["ATTK"],
                        Mgk = (long)ms["MGK"],
                        HPDMG = (long)ms["HPTEMP"],
                        MPDMG = (long)ms["MPTEMP"]
                    };
                    _players.Add(pl);
                }
                conn.Close();
                ResetComboBox();
                UpdateTextBoxes();
            }
            catch (MySqlException)
            {
                a_comboBox.Text = "SQL Error.";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _isBoss = false;
                long mi = long.Parse(min.Text);
                long ma = long.Parse(max.Text);

                var r = new Random();

                long d = r.NextLong(0, 3);
                long one, two, three;

                one = 0;
                two = 0;
                three = 0;

                switch (d)
                {
                    case 0:
                        one = r.NextLong(mi, ma + 1);
                        break;
                    case 1:
                        one = r.NextLong(mi, ma + 1);
                        two = r.NextLong(mi, ma + 1);
                        break;
                    case 2:
                        one = r.NextLong(mi, ma + 1);
                        two = r.NextLong(mi, ma + 1);
                        three = r.NextLong(mi, ma + 1);
                        break;
                }

                long[] group = { one, two, three };
                long mult = Multiplier();
                long[] hp = (_em.EnemyHP(group, mult));

                UpdateEnemyLevels(group, hp);
                expbox.Text = _em.EarnedXP(group, false, _players.Count) + "";
            }
            catch (FormatException)
            { }
        }

        private void boss_button_Click(object sender, EventArgs e)
        {
            try
            {
                _isBoss = true;
                long ma = long.Parse(max.Text);
                long one, two, three;

                one = ma;
                two = ma;
                three = ma;

                long[] group = { one, two, three };
                long mult = Multiplier();
                long hp = (_em.BossHP(one, mult));
                long[] health = { hp, -1, -1 };


                UpdateEnemyLevels(group, health);
                expbox.Text = (_em.EarnedXP(group, true, _players.Count) * 3) + "";

            }
            catch (FormatException)
            { }
        }

        private long Multiplier()
        {
            long mult = 0;

            for(int i = 0; i < _players.Count; i++)
            {
                mult += _players.ElementAt(i).Lvl;
            }

            return mult;
        }

        private void UpdateEnemyLevels(long[] levels, long[] health)
        {
            _enemies.Clear();

            enemy1.Text = $"Lvl: {levels[0]}";
            enemy2.Text = $"Lvl: {levels[1]}";
            enemy3.Text = $"Lvl: {levels[2]}";

            long[] group = levels;
            long hp = (_em.BossHP(levels[0], _players.Count));

            enemybox1.Text = health[0] + "";
            enemybox2.Text = health[1] + "";
            enemybox3.Text = health[2] + "";

            for (long i = 0; i < health.Length; i++)
            {
                if(health[i] > -1)
                {
                    Enemy e = new Enemy { Level = levels[i], HP = health[i], HPTEMP = health[i] };
                    _enemies.Add(e);
                }
            }
        }

        private void UpdateTextBoxes()
        {
            if(a_comboBox.SelectedIndex > -1)
            {
                Player b = _players.ElementAt(a_comboBox.SelectedIndex);
                attk.Text = "AP: " + b.Attk;
                magic.Text = "MGP: " + b.Mgk;

                if(b.Attk > b.Mgk || b.Attk == b.Mgk)
                {
                    attkr.Checked = true;
                }
                else
                {
                    mgcr.Checked = true;
                }
            }
            else
            {
                a_comboBox.SelectedIndex = 0;
                UpdateTextBoxes();
            }

        }

        private void attkbutton_Click(object sender, EventArgs e)
        {
            CheckBox[] targets = { e1rb, e2rb, e3rb };
            TextBox[] enemies = { enemybox1, enemybox2, enemybox3 };
            TextBox[] e_dmg = { e_1_dmg, e_2_dmg, e_3_dmg };
            Player attacker = _players.ElementAt(a_comboBox.SelectedIndex);
            try
            {
                long bloss = 0;
                long hits = long.Parse(hitss.Text);
                if(hits <= 0)
                {
                    hits = 1;
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i].Checked && !enemies[i].Text.Equals("0"))
                    {
                        long hp = long.Parse(enemies[i].Text);
                        if (mgcr.Checked)
                        {
                            if (crit.Checked)
                            {
                                bloss = (attacker.Mgk * 2) - (attacker.Attk / 2);
                                hp -= bloss * hits;
                            }
                            else
                            {
                                bloss = attacker.Mgk - (attacker.Attk / 2);
                                hp -= bloss * hits;
                            }
                        }
                        else if (attkr.Checked)
                        {
                            if (crit.Checked)
                            {
                                bloss = (attacker.Attk * 2);
                                hp -= bloss * hits;
                            }
                            else
                            {
                                bloss = attacker.Attk;
                                hp -= bloss * hits;
                            }
                        }

                        if (hp < 0)
                        {
                            hp = 0;
                            bloss = 0;
                        }

                        _enemies.ElementAt(i).HPTEMP = hp;
                        enemies[i].Text = hp + "";
                        e_dmg[i].Text = bloss * hits + "";
                    }
                }

                crit.Checked = false;
                e1rb.Checked = false;
                e2rb.Checked = false;
                e3rb.Checked = false;
                hitss.Text = "1";
            }
            catch (FormatException)
            {
                hitss.Text = "1";
            }

        }

        private void eneattack_Click(object sender, EventArgs e)
        {
            try
            {
                long totaldmg = 0;
                long playerLevel = _players.ElementAt(a_comboBox.SelectedIndex).Lvl;
                Label[] levels = { enemy1, enemy2, enemy3 };
                Label l = levels[e_attacker];
                char[] delim = { ' ', ':' };
                string[] number = l.Text.Split(delim);
                string x = number[number.Length - 1];
                if (!x.Equals("-1"))
                {
                    long realLevel = long.Parse(x);
                    totaldmg = new Random().NextLong(10, 21) * realLevel;

                    if(playerLevel + 3 > realLevel && !_isBoss)
                    {
                        if ((totaldmg > _players.ElementAt(a_comboBox.SelectedIndex).Hp))
                        {
                            totaldmg -= _players.ElementAt(a_comboBox.SelectedIndex).Hp / 15;
                        }
                    }

                }

                if (crit.Checked)
                {
                    totaldmg *= 2;
                }
                elevel.Text = l.Text;
                e_attack.Text = totaldmg + " ";
                e_attacker++;

                if (e_attacker == levels.Length)
                {
                    e_attacker = 0;
                }
            }
            catch (Exception)
            { }
        }

        private void a_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }

        private void remove_player_Click(object sender, EventArgs e)
        {
            _players.RemoveAt(a_comboBox.SelectedIndex);
            ResetComboBox();
            UpdateTextBoxes();
        }

        private void ResetComboBox()
        {
            a_comboBox.DataSource = null;
            a_comboBox.DataSource = _players;
        }

        private void rollB_Click(object sender, EventArgs e)
        {
            try
            {
                int d = Int32.Parse(rollbox.Text);
                int val = new Random().Next(1, d + 1);
                resultBox.Text = val + "";
            }
            catch (Exception)
            { }
        }
    }
}
