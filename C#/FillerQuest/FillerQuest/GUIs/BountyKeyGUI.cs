using AscendedRPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class BountyKeyGUI : Form
    {
        private Player p;

        public BountyKeyGUI(Player player)
        {
            p = player;
            InitializeComponent();
        }

        private void BountyKeyGUI_Load(object sender, EventArgs e)
        {
            if (p.BountyKeys.Count > 0)
                foreach (int k in p.BountyKeys)
                    KeyList.Items.Add($"Bounty Key - [T{k}]");

            if (p.EXBountyKeys.Count > 0)
                foreach (int exk in p.EXBountyKeys)
                    ExKeyList.Items.Add($"EX: Bounty Key - [T{exk}]");
        }
    }
}
