using AscendedRPG.Files;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscendedRPG
{
    [ProtoContract]
    public class ArmorSet
    {
        [ProtoMember(1, AsReference = true)]
        public Armor[] Armor { get; set; }

        [ProtoMember(2, AsReference = true)]
        public List<Skill> ActiveSkills { get; set; }

        [ProtoMember(3, AsReference = true)]
        public List<Skill> ReserveSkills { get; set; }

        public ArmorSet()
        {
            if(ActiveSkills == null)
            {
                ActiveSkills = new List<Skill>();
            }

            if(ReserveSkills == null)
            {
                ReserveSkills = new List<Skill>();
            }
        }

        public void SetSkillLists()
        {
            Dictionary<string, Skill> playerSkills = new Dictionary<string, Skill>(); // dictionary of skill name + skill

            foreach (Armor armor in Armor)
            {
                foreach (Skill skill in armor.ActiveSkills)
                {
                    if (playerSkills.ContainsKey(skill.Name))
                    {
                        playerSkills[skill.Name].Multiplier += skill.Multiplier;
                    }
                    else
                    {
                        playerSkills.Add(skill.Name, new Skill
                        {
                            Name = skill.Name,
                            S_Type = skill.S_Type,
                            Damage = skill.Damage,
                            Element = skill.Element,
                            Multiplier = skill.Multiplier
                        });
                    }
                }
            }

            ActiveSkills = new List<Skill>();

            ActiveSkills.AddRange(playerSkills.Values);

            ActiveSkills = ActiveSkills.OrderByDescending(a => SkillManager.CalculateDamage(a.Damage, a.Multiplier)).ToList();

            playerSkills = new Dictionary<string, Skill>();

            // this is editting the ReserveSkill passive itself. if you want to have it
            // so you can unequip/equip these skills, you need to have playerSkills.Add(passive.name, new Skill {...});
            foreach(Skill passive in ReserveSkills)
            {
                if(playerSkills.ContainsKey(passive.Name))
                {
                    playerSkills[passive.Name].Multiplier += passive.Multiplier;
                }
                else
                {
                    playerSkills.Add(passive.Name, passive);
                }
            }

            ReserveSkills = new List<Skill>();

            foreach(KeyValuePair<string, Skill> kvp in playerSkills)
            {
                ReserveSkills.Add(kvp.Value);
            }
        }

        public int GetDefense()
        {
            int def = 0;
            foreach(Armor armor in Armor)
            {
                def += armor.Defense;
            }
            return def;
        }
    }
}