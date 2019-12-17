using AscendedRPG;
using AscendedRPG.Files;
using FillerQuest.GUIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class ShopRoom : Form
    {
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "shopKeepers");

        private int tier;

        private int vendor;

        private List<string[]> vendorDialog;
        // intro, when you buy something
        private string[] vendor1 = { "Welcome! Please enjoy your stay.", "Good choice. I was thinking about getting one for myself, too.", "You need more money if you want to buy that."};
        private string[] vendor2 = { "Haa haa, yuhhhhhh... Yuhhhhhh baby. Feel it.", "Ha ha, your money causes ripples in my soul. Very nice...", "Bruh, come on. You get the cash, you get the stash."};
        private string[] vendor3 = { "BAAAAAASSSSSSEEDDDD!", "You don't have to buy things to give me money, my guy. But, it's still very genki either way.", "This isn't a charity. Get the money, or get out."};
        private string[] vendor4 = { "STEALING IS HARD WORK. HARD WORK DEMANDS MONEY. COMMENSE TRANSACTIONS THIS INSTANT.", "YOUR PURCHASE IS NOTED. YOUR DATE OF DESPAIR WILL BE EXTENDED OUTWARD TO ANOTHER TIME.", "YOU ARE TRYING MY PATIENCE WITH YOUR LACK OF CURRENCY."};
        private string[] vendor5 = { "Don't tell anyone about this. Got it?", "If anyone asks, you didn't see me.", "I can't go givin' this out for free... You either pay the price or get out."};
        private string[] vendor6 = { "Another has appeared! Brothers, it is time to feast on gold once more!", "YES, YES! *gargling noises* FEAST...! FEAST!!!", "[THE FOOLISH ONE LACKS MONEY. HE IS OF NO USE TO US]"};

        Player p;

        private List<Armor> charms;
        private List<FillerQuest.Item> items;
        private List<string> wares_charms;
        private List<string> wares_items;
        private List<string> wares_keys;
        private List<string> current;
        Dictionary<string, long> costs;

        public bool UserClosing { get; set; }

        public ShopRoom(Player player)
        {
            tier = player.Tier;
            p = player;
            vendorDialog = new List<string[]>();
            InitializeComponent();
        }

        private void ShopRoom_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(PATH, "*.png");
            vendor = (tier - 1) % files.Length;
            VendorPicture.Image = Image.FromFile(Path.Combine(PATH, files[vendor]));

            vendorDialog.Add(vendor1);
            vendorDialog.Add(vendor2);
            vendorDialog.Add(vendor3);
            vendorDialog.Add(vendor4);
            vendorDialog.Add(vendor5);
            vendorDialog.Add(vendor6);

            VendorTextBox.Text = vendorDialog[vendor][0];

            RollWares();

            UpdatePlayerCoins(p.DellenCoin);
        }

        private void RollWares()
        {
            charms = new List<Armor>();
            wares_charms = new List<string>();
            wares_items = new List<string>();
            wares_keys = new List<string>();
            costs = new Dictionary<string, long>();
            items = new List<FillerQuest.Item>();

            var r = new Random();

            int n = r.Next(15, 31);

            for (int i = 0; i < n; i++)
            {
                int type = r.Next(0, 100);
                if (type >= 25 && type < 75)
                {
                    Armor charm = ArmorManager.GetRandomArmorPiece(p.Tier - 1, ArmorPiece.CHARM, r);

                    wares_charms.Add(charm.ToString());
                    charms.Add(charm);
                    AddCost(charm.ToString(), r.Next(tier * 1000, tier * 2000));
                }
                else if (type < 25)
                {
                    FillerQuest.Item item = new FillerQuest.Item();
                    int t = r.Next(0, 2);

                    if (t == 0)
                    {
                        item.Name = "Potion";
                        item.ItemType = 0;
                    }
                    else
                    {
                        int element = r.Next(0, 9);
                        item.Name = $"{SkillManager.ElementToString(element)} Elixer";
                        item.ItemType = element + 1;
                    }

                    item.Quantity = 1;

                    wares_items.Add(item.ToString());
                    items.Add(item);
                    AddCost(item.ToString(), r.Next(tier * 500, tier * 1000));
                }
                else
                {
                    int ex = 0;
                    int bountyKey;
                    if (tier > 478)
                    {
                        bountyKey = r.Next(479, 499);
                    }
                    else
                    {
                        bountyKey = r.Next(p.Tier, p.Tier + 20);
                    }

                    string bk = $"Bounty Key: Tier {bountyKey}";
                    if (r.Next(0, 100) < 25)
                    {
                        bk = $"EX {bk}";
                        ex += 1000;
                    }
                    wares_keys.Add(bk);
                    AddCost(bk, r.Next(tier * 2000, tier * 2500) + ex);
                }
            }

            string ek = $"Elder Key";
            wares_keys.Add(ek);
            AddCost(ek, r.Next(tier * 8000, tier * 10000));
            UpdateVendorDisplay();
        }

        private void UpdateVendorDisplay()
        {
            if (charmRadio.Checked)
            {
                current = wares_charms;
            }
            else if (keyRadio.Checked)
            {
                current = wares_keys;
            }
            else if (itemRadio.Checked)
            {
                current = wares_items;
            }
            else
            {
                current = new List<string>();
                current.AddRange(wares_charms);
                current.AddRange(wares_keys);
                current.AddRange(wares_items);
            }

            UpdateVendorWares();
        }

        private void AddCost(string k, int v)
        {
            if(costs.ContainsKey(k))
            {
                costs[k] = v;
            }
            else
            {
                costs.Add(k, v);
            }
        }

        private void VendorWares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VendorWares.SelectedItem != null)
            {
                string selected = VendorWares.SelectedItem.ToString();
                long cost = costs[selected];
                InformationBox.Text = "";
                if (selected.Contains("Charm"))
                {
                    UpdateInfoBoxCharm(selected, cost);
                }
                else if (selected.Contains("Elixer") || selected.Contains("Potion"))
                {
                    UpdateInfoElixerElixer(selected, cost);
                }
                else if(selected.Contains("Elder Key"))
                {
                    UpdateInfoBoxEKey(cost);
                }
                else if (selected.Contains("EX"))
                {
                    UpdateInfoEXBoxKey(selected, cost);
                }
                else
                {
                    UpdateInfoBoxKey(selected, cost);
                }
            }
        }

        private void UpdateInfoBoxCharm(string s, long cost)
        {
            foreach(Armor charm in charms)
            {
                if(charm.ToString().Equals(s))
                {
                    AppendToBox($"{charm.Name} -- D${cost}");
                    AppendToBox($"Grants {charm.Defense} defense.");
                    AppendToBox("Contains:");
                    foreach (Skill skill in charm.ActiveSkills)
                    {
                        AppendToBox(skill.ToString());
                    }
                    break;
                }
            }
        }

        private void UpdateInfoElixerElixer(string s, long cost)
        {
            foreach(FillerQuest.Item i in items)
            {
                if(i.ToString().Equals(s))
                {
                    AppendToBox($"{i.Name} -- D${cost}");
                    if (i.ItemType == 0)
                    {
                        AppendToBox("Heals for 15% of your health.");
                    }
                    else
                    {
                        
                        AppendToBox($"Boosts {SkillManager.ElementToString(i.ItemType - 1)} damage by 25%");
                    }
                    break;
                }
            }
        }

        private void UpdateInfoBoxEKey(long cost)
        {
            AppendToBox($"Elder Key -- D${cost}");
            AppendToBox("");
            AppendToBox($"Unlocks the Elder God on the current tier you're on. Once it's killed, you will auto-complete the floor.");
        }

        private void UpdateInfoBoxKey(string s, long cost)
        {
            string[] temp = s.Split(' ');
            int tier = Int32.Parse(temp[temp.Length - 1]);
            AppendToBox($"Bounty Key [{tier}] -- D${cost}");
            AppendToBox("");
            AppendToBox($"Unlocks the Bounty Boss on Tier {tier}.");
        }

        private void UpdateInfoEXBoxKey(string s, long cost)
        {
            InformationBox.Text = "";
            string[] temp = s.Split(' ');
            int tier = Int32.Parse(temp[temp.Length - 1]);
            AppendToBox($"EX Bounty Key [{tier}] -- D${cost}");
            AppendToBox("");
            AppendToBox($"Unlocks the EX Bounty Boss on Tier {tier}.");
        }

        private void UpdateVendorWares()
        {
            VendorWares.DataSource = null;
            VendorWares.DataSource = current;
        }

        private void UpdatePlayerCoins(long amount)
        {
            PlayerCoins.Text = $"D.Coin: {amount}";
        }

        private void AppendToBox(string text)
        {
            InformationBox.AppendText(text);
            InformationBox.AppendText(Environment.NewLine);
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.SaveGame(p);
            UserClosing = true;
            Close();
        }

        private void ShopRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!UserClosing)
                {
                    Application.Exit();
                }
            }
        }

        private void PurchaseButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string selected = VendorWares.SelectedItem.ToString();
                long cost = costs[selected];

                if (p.DellenCoin - cost < 0)
                {
                    VendorTextBox.Text = vendorDialog[vendor][2];
                }
                else
                {
                    p.DellenCoin -= cost;
                    if (selected.Contains("Charm"))
                    {
                        BuyCharm(selected);
                    }
                    else if (selected.Contains("Elixer") || selected.Contains("Potion"))
                    {
                        BuyElixer(selected);
                    }
                    else if(selected.Contains("Elder Key"))
                    {
                        BuyElderKey(selected);
                    }
                    else if (selected.Contains("EX"))
                    {
                        BuyBountyKey(selected, true);
                    }
                    else
                    {
                        BuyBountyKey(selected, false);
                    }
                    VendorTextBox.Text = vendorDialog[vendor][1];
                    UpdatePlayerCoins(p.DellenCoin);
                    UpdateVendorDisplay();
                }
            }
            catch (NullReferenceException)
            {
                allRadio.Checked = true;
            }
        }

        private void BuyCharm(string s)
        {
            foreach (Armor charm in charms)
            {
                if (charm.ToString().Equals(s))
                {
                    if (p.Inventory.Count == 100)
                        p.ReserveArmor.Add(charm);
                    else
                        p.Inventory.Add(charm);

                    charms.Remove(charm);
                    wares_charms.Remove(s);
                    break;
                }
            }
        }

        private void BuyElixer(string s)
        {
            foreach (FillerQuest.Item i in items)
            {
                if (i.ToString().Equals(s))
                {
                    p.Items[i.ItemType].Quantity++;
                    items.Remove(i);
                    wares_items.Remove(s);
                    break;
                }
            }
        }

        private void BuyElderKey(string s)
        {
            InformationBox.Text = "";
            p.GodLordKeys++;
            wares_keys.Remove(s);
        }

        private void BuyBountyKey(string s, bool ex)
        {
            InformationBox.Text = "";
            string[] temp = s.Split(' ');
            int tier = Int32.Parse(temp[temp.Length - 1]);
            if (ex)
            {
                p.EXBountyKeys.Add(tier);
            }
            else
            {
                p.BountyKeys.Add(tier);
            }
            wares_keys.Remove(s);
        }

        private void charmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(charmRadio.Checked)
            {
                current = wares_charms;
                UpdateVendorWares();
            }
        }

        private void keyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(keyRadio.Checked)
            {
                current = wares_keys;
                UpdateVendorWares();
            }
        }

        private void itemRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(itemRadio.Checked)
            {
                current = wares_items;
                UpdateVendorWares();
            }
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(allRadio.Checked)
            {
                current = new List<string>();
                current.AddRange(wares_charms);
                current.AddRange(wares_keys);
                current.AddRange(wares_items);
                UpdateVendorWares();
            }
        }

        private void reRollWaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RollWares();
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
