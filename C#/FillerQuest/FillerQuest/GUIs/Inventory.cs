using AscendedRPG.Files;
using AscendedRPG.GUIs;
using FillerQuest.GUIs;
using FillerQuest.Relics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class Inventory : Form
    {
        private Player p;
        private MusicManager mm;
        private Armor selectedArmor;
        private RelicManager rm;

        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            p = SaveManager.LoadGame();
            rm = SaveManager.LoadRelicManager();

            if (p.BountyKeys.Count > 0 || p.EXBountyKeys.Count > 0)
            {
                checkKeysToolStripMenuItem.Enabled = true;
            }

            if(p.Tier >= 20)
            {
                relicsToolStripMenuItem.Visible = true;
            }

            mm = new MusicManager();
            mm.SetIdleTheme(p.Tier);
            musicBot.RunWorkerAsync();
            UpdateInventory();
        }

        private void UpdateInventory()
        {
            p.Set.SetSkillLists();

            string hp = (p.GetHP() + p.Set.GetDefense()).ToString();

            if(rm.Current != null)
                DefenseBox.Text = $"[{rm.Current.GetRelicType()}] {p.Name} -- HP: {hp}";
            else
                DefenseBox.Text = $"[None] {p.Name} -- HP: {hp}";

            CoinBox.Text = $"D${p.DellenCoin}";
            KeyBox.Text = $"B. Keys: {p.BountyKeys.Count + p.EXBountyKeys.Count} - E. Keys: {p.GodLordKeys}";
            ItemCount.Text = $"Items: {p.GetItemCount()}";
            TierBox.Text = $"Tier {p.Tier}";

            UpdateEquipment();

            UpdateSkillBox();

            UncheckRadioBoxes();

            ResetInventory(1);

            if(p.Tier >= 10)
            {
                shopToolStripMenuItem.Enabled = true;
            }
        }

        private void UpdateEquipment()
        {
            EquipmentBox.Items.Clear();
            EquipmentBox.Items.Add("- Equipment -");

            foreach(Armor a in p.Set.Armor)
            {
                EquipmentBox.Items.Add(a);
            }
        }

        // update the skill display box on start and when new items are equipped
        private void UpdateSkillBox()
        {
            ActiveSkillBox.Items.Clear();
            ActiveSkillBox.Items.Add("- Equipped Skills -");
            foreach (Skill s in p.Set.ActiveSkills)
            {
                ActiveSkillBox.Items.Add(s);
            }

            ReserveSkillList.Items.Clear();
            ReserveSkillList.Items.Add("- Passive Skills -");
            foreach (Skill s in p.Set.ReserveSkills)
            {
                ReserveSkillList.Items.Add(s);
            }
        }

        private void EquipmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Armor selected = EquipmentBox.SelectedItem as Armor;
                SelectedArmorSkill.Text = selected.SkillsAsString();
            }
            catch (NullReferenceException)
            {
                SelectedArmorSkill.Text = "";
            }

        }

        private void InventoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Armor selected = InventoryList.SelectedItem as Armor;
                SelectedInventorySkill.Text = selected.SkillsAsString();
                
            }
            catch (NullReferenceException)
            {
                SelectedInventorySkill.Text = "";
            }
        }

        private void ActiveSkillBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ActiveSkillBox.SelectedIndex = ActiveSkillBox.IndexFromPoint(e.Location);
                if (ActiveSkillBox.SelectedIndex != -1)
                {
                    SkillDisplayBox.Text = string.Empty;
                    Skill skill = ActiveSkillBox.Items[ActiveSkillBox.SelectedIndex] as Skill;

                    string info = SkillManager.GetSkillInfoString(skill);

                    string[] display = info.Split('*');
                    UpdateSkillBox(info);
                }
            }
            catch (NullReferenceException) { }

        }

        private void ReserveSkillList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ReserveSkillList.SelectedIndex = ReserveSkillList.IndexFromPoint(e.Location);
                if (ReserveSkillList.SelectedIndex != -1)
                {
                    SkillDisplayBox.Text = string.Empty;
                    Skill s = ReserveSkillList.Items[ReserveSkillList.SelectedIndex] as Skill;

                    string info;

                    if (s.S_Type == SkillType.PASSIVE_VOID)
                    {
                        info = $"{s.Name}*Reduces {SkillManager.ElementToString(s.Element)} damage by {s.Multiplier}.";
                    }
                    else
                    {
                        info = $"{s.Name}*Boosts {SkillManager.StatsToString(s.Element)} by {s.Multiplier}.";
                    }

                    UpdateSkillBox(info);
                }
            }
            catch (NullReferenceException) { }
        }

        private void InventoryList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    InventoryList.SelectedIndex = InventoryList.IndexFromPoint(e.Location);
                    if (InventoryList.SelectedIndex != -1)
                    {
                        Armor selected = InventoryList.Items[InventoryList.SelectedIndex] as Armor;
                        if (relicsToolStripMenuItem.Text.Equals("Relics"))
                        {
                            // change equipment
                            Armor old = p.Set.Armor[selected.Piece];
                            p.Set.Armor[selected.Piece] = selected;
                            p.Inventory.Add(old);
                            p.Inventory.Remove(selected);

                            if (selectedArmor != null && selectedArmor.Name.Equals(selected.Name))
                            {
                                selectedArmor = null;
                                SelectedArmor.Text = "";
                                SelectedSkills.Text = "";
                            }

                            UpdateInventory();
                        }
                        else
                        {
                            // place in group for relic creation
                            UpdateRelicSkillDisplay(selected);
                        }
                    }
                }
                catch (NullReferenceException) { }

            }
        }


        private void Relics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    Relics.SelectedIndex = Relics.IndexFromPoint(e.Location);
                    if (Relics.SelectedIndex != -1)
                    {
                        Relic selected = rm.ReserveRelics[Relics.SelectedIndex - 1];
                        rm.Current = selected;
                        UpdateCurrentRelic(selected);
                    }
                }
                catch (ArgumentOutOfRangeException) {}

            }
        }

        private void UpdateSkillBox(string info)
        {
            string[] display = info.Split('*');
            for (int d = 0; d < display.Length - 1; d++)
            {
                SkillDisplayBox.AppendText(display[d]);
                SkillDisplayBox.AppendText(Environment.NewLine);
            }
            SkillDisplayBox.AppendText(display[display.Length - 1]);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            p.Set.SetSkillLists();
            SaveManager.SaveGame(p);
            SaveManager.SaveRelicManager(rm);
            MessageBox.Show("Save successful.");
        }

        private void EmbarkMenuItem_Click(object sender, EventArgs e)
        {
            if(p.ReserveArmor.Count == 0)
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        p.Set.SetSkillLists();

                        SaveManager.SaveGame(p);
                        SaveManager.SaveRelicManager(rm);

                        relicsToolStripMenuItem.Text = "Relics";
                        RelicGroup.Visible = false;
                        Visible = false;
                        SelectDungeon sd = new SelectDungeon(p, mm);
                        sd.StartPosition = FormStartPosition.Manual;
                        sd.Location = Location;
                        sd.ShowDialog();
                        Visible = true;

                        p = SaveManager.LoadGame();
                        UpdateInventory();
                    }
                    catch (ObjectDisposedException) {}
                }
            }
            else
            {
                MessageBox.Show("You need to clear out more space in your Inventory before you can return to the dungeon.");
            }

        }

        private void musicBot_DoWork(object sender, DoWorkEventArgs e)
        {
            mm.PlayIdleSong();
        }

        private void head_CheckedChanged(object sender, EventArgs e)
        {
            if(head.Checked)
            {
                FilterPieces(ArmorPiece.HEAD);
            }
        }

        private void torso_CheckedChanged(object sender, EventArgs e)
        {
            if (torso.Checked)
            {
                FilterPieces(ArmorPiece.TORSO);
            }
        }

        private void arms_CheckedChanged(object sender, EventArgs e)
        {
            if (arms.Checked)
            {
                FilterPieces(ArmorPiece.ARMS);
            }
        }

        private void waist_CheckedChanged(object sender, EventArgs e)
        {
            if (waist.Checked)
            {
                FilterPieces(ArmorPiece.WAIST);
            }
        }

        private void legs_CheckedChanged(object sender, EventArgs e)
        {
            if (legs.Checked)
            {
                FilterPieces(ArmorPiece.LEGS);
            }
        }


        private void charms_CheckedChanged(object sender, EventArgs e)
        {
            if (charms.Checked)
            {
                FilterPieces(ArmorPiece.CHARM);
            }
        }


        private void FilterPieces(int piece)
        {
            List<Armor> filter = new List<Armor>();

            foreach (Armor armor in p.Inventory)
            {
                if(armor.Piece == piece)
                {
                    filter.Add(armor);
                }
            }

            filter = filter.OrderByDescending(armor => armor.Defense).ToList();

            InventoryList.Items.Clear();

            InventoryList.Items.Add($"- Inventory [{p.Inventory.Count}/100] -- Reserves [{p.ReserveArmor.Count}] -");

            foreach (Armor a in filter)
            {
                InventoryList.Items.Add(a);
            }
        }

        private void UncheckRadioBoxes()
        {
            head.Checked = false;
            torso.Checked = false;
            arms.Checked = false;
            waist.Checked = false;
            legs.Checked = false;
            charms.Checked = false;
        }

        private void ResetInventory(int index)
        {
            InventoryList.Items.Clear();

            p.Inventory = p.Inventory.OrderByDescending(armor => armor.Defense).ToList();

            InventoryList.Items.Add($"- Inventory [{p.Inventory.Count}/100] -- Reserves [{p.ReserveArmor.Count}] -");

            foreach(Armor a in p.Inventory)
            {
                InventoryList.Items.Add(a);
            }

            if (head.Checked)
                FilterPieces(ArmorPiece.HEAD);
            else if (torso.Checked)
                FilterPieces(ArmorPiece.TORSO);
            else if (arms.Checked)
                FilterPieces(ArmorPiece.ARMS);
            else if (waist.Checked)
                FilterPieces(ArmorPiece.WAIST);
            else if (legs.Checked)
                FilterPieces(ArmorPiece.LEGS);
            else if (charms.Checked)
                FilterPieces(ArmorPiece.CHARM);
            else
                UncheckRadioBoxes();

            if (InventoryList.Items.Count > 1)
            {
                try
                {
                    InventoryList.SelectedIndex = index;
                }
                catch (ArgumentOutOfRangeException)
                {
                    InventoryList.SelectedIndex = InventoryList.Items.Count - 1;
                }
            }
        }

        private void DeleteSelectedInventory_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(InventoryList.SelectedIndex > 0)
                {
                    Armor removeThis = InventoryList.SelectedItem as Armor;
                    DeleteSelectedArmor(removeThis);

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have nothing in your inventory to delete.");
            }
        }

        private void DeleteSelectedArmor(Armor removeThis)
        {
            p.Inventory.Remove(removeThis);

            if (p.ReserveArmor.Count > 0)
            {
                p.Inventory.Add(p.ReserveArmor[0]);
                p.ReserveArmor.RemoveAt(0);
            }

            if (selectedArmor != null && removeThis.Name.Equals(selectedArmor.Name))
            {
                selectedArmor = null;
                SelectedArmor.Text = "";
                SelectedSkills.Text = "";
            }

            ResetInventory(InventoryList.SelectedIndex);
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;

            ShopRoom sm = new ShopRoom(p);
            sm.StartPosition = FormStartPosition.Manual;
            sm.Location = Location;
            sm.ShowDialog();

            Visible = true;

            p = SaveManager.LoadGame();

            if (p.BountyKeys.Count > 0 || p.EXBountyKeys.Count > 0)
            {
                checkKeysToolStripMenuItem.Enabled = true;
            }

            UpdateInventory();
        }

        private void UnfilterButton_MouseClick(object sender, MouseEventArgs e)
        {
            UncheckRadioBoxes();
            ResetInventory(InventoryList.SelectedIndex);
        }

        private void checkKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BountyKeyGUI bkg = new BountyKeyGUI(p);
            bkg.StartPosition = FormStartPosition.Manual;
            bkg.Location = Location;
            bkg.ShowDialog();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            foreach(FillerQuest.Item i in p.Items)
            {
                if(i.Quantity > 0)
                    str.AppendLine($"{i.Name} = {i.Quantity}");
            }

            string show = str.ToString();
            if (show.Equals(string.Empty))
                show = "None";

            MessageBox.Show(show);
        }

        private void relicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(relicsToolStripMenuItem.Text.Equals("Relics"))
            {
                RelicGroup.Visible = true;
                relicsToolStripMenuItem.Text = "Inventory";
                UpdateRelics();
                selectedArmor = null;
                if (rm.Current != null)
                    UpdateCurrentRelic(rm.Current);
                
            }
            else
            {
                RelicGroup.Visible = false;
                relicsToolStripMenuItem.Text = "Relics";
            }

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(rm.ReserveRelics.Count < 50)
                {
                    var v = new Random();
                    RelicInformation.Text = "";

                    Relic r = new Relic();

                    r.Name = "";
                    r.Damage = 0;
                    r.Elements = new List<int>();
                    r.RelicType = v.Next(0, 3);

                    foreach (Skill s in selectedArmor.ActiveSkills)
                    {
                        r.Name += $"[{SkillManager.ElementToString(s.Element)}]";
                        r.Damage += (int)(SkillManager.CalculateDamage(s.Damage, s.Multiplier) * .05);
                        r.Elements.Add(s.Element);
                    }

                    r.Damage = r.Damage / 2;

                    rm.Current = r;
                    rm.ReserveRelics.Add(rm.Current);

                    UpdateCurrentRelic(r);

                    DeleteArmorInRelicDisplay();

                    UpdateRelics();
                }
                else
                {
                    MessageBox.Show("Unable to create new relic. You have too many already.");
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You need to select armor first before you can craft a relic.");
            }
        }

        private void MeldCharm_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                foreach(Skill s in selectedArmor.ActiveSkills)
                {
                    rm.Current.Damage += 1;
                }

                UpdateCurrentRelic(rm.Current);

                DeleteArmorInRelicDisplay();

                UpdateRelics();
            }
            catch (NullReferenceException)
            {
               MessageBox.Show("You need to select armor first before you can meld it into a relic.");
            }
        }

        private void UpdateRelicSkillDisplay(Armor selected)
        {
            SelectedSkills.Text = "";

            SelectedArmor.Text = selected.Name;
            foreach (Skill skill in selected.ActiveSkills)
            {
                SelectedSkills.AppendText($"[{SkillManager.ElementToString(skill.Element)}] {skill.ToString()}");
                SelectedSkills.AppendText(Environment.NewLine);
            }
            selectedArmor = selected;
        }

        private void UpdateRelics()
        {
            Relics.Items.Clear();

            Relics.Items.Add($"- Relics {rm.ReserveRelics.Count}/50 -");

            foreach (Relic r in rm.ReserveRelics)
                Relics.Items.Add(r);

            if (Relics.Items.Count > 1)
                Relics.SelectedIndex = 1;
        }

        private void DeleteArmorInRelicDisplay()
        {
            DeleteSelectedArmor(selectedArmor);

            try
            {
                Armor selected = InventoryList.Items[InventoryList.SelectedIndex] as Armor;
                UpdateRelicSkillDisplay(selected);
            }
            catch (ArgumentOutOfRangeException)
            {
                selectedArmor = null;

                SelectedArmor.Text = "";
                SelectedSkills.Text = "";
            }
        }

        private void UpdateCurrentRelic(Relic r)
        {
            string hp = (p.GetHP() + p.Set.GetDefense()).ToString();
            DefenseBox.Text = $"[{rm.Current.GetRelicType()}] {p.Name} -- HP: {hp}";
            RelicInformation.Text = "";
            RelicInformation.AppendText($"{r.Name} Relic");
            RelicInformation.AppendText(Environment.NewLine);
            RelicInformation.AppendText($"Damage: {r.Damage}");
            RelicInformation.AppendText(Environment.NewLine);
            RelicInformation.AppendText($"Type: {r.GetRelicType()}");
        }

        private void DeleteRelic_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (Relics.SelectedIndex > 0)
                {
                    Relic r = Relics.SelectedItem as Relic;

                    rm.ReserveRelics.Remove(r);

                    if (rm.Current.Equals(r))
                    {
                        rm.Current = Relics.Items[1] as Relic;
                    }

                    UpdateRelics();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have nothing in your relics to delete.");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpGUI help = new HelpGUI();
            help.StartPosition = FormStartPosition.Manual;
            help.Location = Location;
            help.ShowDialog();
        }

        private void checkElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("~ Equipped Elements ~");
            byte[] elements = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for(int i = 1; i < EquipmentBox.Items.Count; i++)
            {
                Armor armor = EquipmentBox.Items[i] as Armor;
                foreach(Skill skill in armor.ActiveSkills)
                {
                    elements[skill.Element] = 1;
                }
            }

            int count = 0;
            for(int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == 1)
                {
                    str.AppendLine(SkillManager.ElementToString(i));
                    count++;
                } 
            }
            str.AppendLine("---------");
            str.AppendLine($"{count}/9 Elements in use.");
            MessageBox.Show(str.ToString());
        }
    }
}
