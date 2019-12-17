using AscendedRPG.Files;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGameGroup.Enabled = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveManager.DoesSaveFileExist())
            {
                DisplayInventory();
            }
            else
            {
                MessageBox.Show("No existing save file found.");
            }      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("You must enter a name before continuing.");
            }
            else
            {

                Player p = new Player
                {
                    Name = nameBox.Text,
                    Set = new ArmorSet
                    {
                        Armor = new Armor[6]
                    },
                    Inventory = new List<Armor>(),
                    Tier = 1,
                    Turns = 8,
                    DellenCoin = 10
                };

                p.Items = new FillerQuest.Item[10];

                // start with 5 potions
                p.Items[0] = new FillerQuest.Item { Name = "Potion", ItemType = 0, Quantity = 5 };

                for (int i = 1; i < p.Items.Length; i++)
                {
                    p.Items[i] = new FillerQuest.Item { Name = $"{SkillManager.ElementToString(i - 1)} Elixer", ItemType = i, Quantity = 0 };
                }

                var r = new Random();

                for(int i = 0; i < p.Set.Armor.Length; i++)
                {
                    p.Set.Armor[i] = ArmorManager.GetRandomArmorPiece(p.Tier, i, r);
                }

                Visible = false;

                CharacterSelect cs = new CharacterSelect(p);
                cs.StartPosition = FormStartPosition.Manual;
                cs.Location = Location;
                cs.ShowDialog();

                Close();
            }
        }

        private void DisplayInventory()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                var inv = new Inventory();
                inv.StartPosition = FormStartPosition.Manual;
                inv.Location = Location;
                Application.Run(inv);
            }));

            thread.Start();
            Close();
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            ArmorManager.LoadArmorIntoMemory();
            SkillManager.LoadSkillsIntoMemory();
        }
    }
}
