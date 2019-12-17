using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillerQuest.GUIs
{
    public partial class HelpGUI : Form
    {
        private const int NUMHELP = 9;
        private string[] help;
        
        public HelpGUI()
        {
            help = new string[NUMHELP];
            InitializeComponent();
        }


        private void HelpGUI_Load(object sender, EventArgs e)
        {
            help[0] = "~Inventory~*Left click armor to view its skills.*Right armor to equip it.*Click Delete Selected to permanently delete the armor you're currently selecting.*Filter your armor by clicking the \"H, T, A, W, L, C\" radio buttons. For example, to see all Torso pieces you have, click T. If you want to go back to view your whole inventory, click \"Unfilter.\"*Armor is presented as \"[Defense] Name.\"*Skills are presented as \"[Damage] Name +Multiplier.\"";
            help[1] = "~Equipment~*Left click armor to view its skills.*Left click on a skill under \"Equipped Skills\" to get more info on it.*Armor is presented as \"[Defense] Name.\"*Skills are presented as \"[Damage] Name +Multiplier.\"";
            help[2] = "~Relics~*Unlock at Tier 20*Click \"Relics\" in your Inventory screen to view the Relic screen. If you want to go back, click \"Inventory\" to go back to your Inventory.*Right click armor in your Inventory to move it over to the Relic screen.*Click Craft to make a new Relic out of the elements present on your armor.*Click Meld to meld armor into 1 point of damage for your Relic.*Right click on a relic to set it as your active relic.";
            help[3] = "~Tiers~*Tiers represent the current floor you're on. The further you go, the harder enemies will get.";
            help[4] = "~Dellen Coins~*A type of currency used at the shop.";
            help[5] = "~Shop~*Unlocks at Tier 10*The only place you can obtain Charms, Keys, and Items from.*Charms are just another piece of armor with extra elements on it.*Bounty Keys and EX Bounty Keys summon Bounty Bosses and EX Bounty Bosses. Killing them gives you a guaranteed passive. The multiplier on the passive varies based on whether or not the boss is EX.*Elder Keys summon Elder Gods that you can kill to instantly complete the floor.*Items include Potions and Elixers. Potions boost your HP, Elixers boost the damage of the element they correspond to.";
            help[6] = "~Enemies~*Normal Enemies: Reward money.*Pot of Greed: Rewards 1-2 pieces of armor on death. You don't lose this armor when you die.*EX Enemies: 3% chance of replacing an enemy with an EX Enemy. Drops EX Armor with EX Skills on death. You do not lose this armor when you die or run away.*Normal Bosses: Health glutton enemies. Reward money on death.*EX Bosses: Very rare. Rewards passives on death. You do not lose these if you die or run away.*Invaders: Unlock on Tier 20 with a 10% chance of replacing a boss. Rewards passives on death. You do not lose these if you die or run away.*EX Invader: Unlocks on Tier 30. 5% chance of replacing an Invader with an EX Invader. Rewards boosted passives on death. You do not lose these if you die or run away.*Bounty Bosses: Unlocks when you use a Bounty Key. Replaces the next boss you fight with a Bounty Boss. Rewards passives on death. You do not lose these if you die or run away.*EX Bounty Bosses: Same as Bounty Bosses, except you need an EX Bounty Boss Key to unlock them and their passives are better.*Elder God: Unlocked when you use an Elder Key. Killing one will instantly end the floor you're on and will allow you to progress to the next.";
            help[7] = "~Skills~*Active Skills: Only found on armor and are used to attack enemies. If you have 2 skills with the exact same name, their multipliers will combine to boost your damage.*Passive Skills: These are skills you get as you play. They come in 2 flavors: Void and Boost. Void skills reduce the damage of an attack of the corresponding element by their multiplier. Boost skills amp your Attack, Defense, Critical Damage, and the amount of Turns you can use.";
            help[8] = "~Combat~*It's Turn Press: Lazy Edition.*Hit an enemy with a normal attack = 1 full turn ({00}).*Hit an enemy's weakness or hit for critical damage = 1 half turn ({0)*Crits and Weaknesses do x2 damage. They can both be stacked such that you have (hit x 2 [crit]) x 2 [weakness].*Click on a skill and either click the \"Use Skill\" button or press Spacebar to use it.*Click on an item and either click the \"Use Item\" button or press E to use it.*Click on the \"Use Relic\" button or press F to use your Relic.";
        }

        private void HelpItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = HelpItems.SelectedIndex;
                HelpDisplay.Text = "";
                string h = help[index];
                foreach (string s in h.Split('*'))
                    AppendLine(s);
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        private void AppendLine(string line)
        {
            HelpDisplay.AppendText(line);
            HelpDisplay.AppendText(Environment.NewLine);
            HelpDisplay.AppendText(Environment.NewLine);
        }

    }
}
