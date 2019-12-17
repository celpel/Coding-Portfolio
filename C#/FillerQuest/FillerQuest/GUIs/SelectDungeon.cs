using AscendedRPG.Files;
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
    public partial class SelectDungeon : Form
    {
        private Player p;
        private MusicManager mm;

        public bool UserClosing { get; set; }

        public SelectDungeon(Player player, MusicManager jb)
        {
            p = player;
            mm = jb;
            InitializeComponent();
        }

        private void SelectDungeon_Load(object sender, EventArgs e)
        {
            TierBox.Value = p.Tier;
        }

        private void TierBox_ValueChanged(object sender, EventArgs e)
        {
            int t = (int)TierBox.Value;

            if(t < 1)
            {
                TierBox.Value = 1;
            }

            if(t > p.Tier)
            {
                TierBox.Value = p.Tier; // prevent you from going over maximum
            }
        }

        private void SelectDungeon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!UserClosing)
                {
                    Application.Exit();
                }
            }
        }

        private void GoBack_MouseClick(object sender, MouseEventArgs e)
        {
            UserClosing = true;
            Close();
        }

        private void EmbarkButton_MouseClick(object sender, MouseEventArgs e)
        {
            int t = (int)TierBox.Value;

            if(t == 500)
            {
                MessageBox.Show("Before you enter the dungeon, you see a message inscribed on the wall nearby. " +
                    "\"Beyond this door awaits your final challenge. Once you conquer this, you will truly ascend. Good luck.\"");
            }

            mm.Stop();

            Visible = false;

            DungeonGUI dgui = new DungeonGUI(t, mm);
            dgui.StartPosition = FormStartPosition.Manual;
            dgui.Location = Location;
            dgui.ShowDialog();

            p = SaveManager.LoadGame();
            mm.SetIdleTheme(p.Tier);
            mm.PlayIdleSong();
            UserClosing = true;
            Close();
        }
    }
}
