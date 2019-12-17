using AscendedRPG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AscendedRPG.Files
{
    public static class SkillManager
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "skills");
        private static readonly string a_path = Path.Combine(PATH, "activeSkills.bin");
        private static readonly string pv_path = Path.Combine(PATH, "passiveVoids.bin");
        private static readonly string pb_path = Path.Combine(PATH, "passiveBuffs.bin");

        private static readonly string[] elements =  { "Fire", "Water", "Ice", "Shock", "Wind", "Nuke", "Dark", "Light", "Physical" };

        private static readonly string[] stats = { "Attack", "Defense", "Critical", "Turn" };

        private static List<Skill> ActiveSkills { get; set; }
        private static List<Skill> PassiveVoids { get; set; }
        private static List<Skill> PassiveBuffs { get; set; }

        public static void LoadSkillsIntoMemory()
        {
            ActiveSkills = EncryptionManager.DeCrypt<List<Skill>>(a_path);
            PassiveVoids = EncryptionManager.DeCrypt<List<Skill>>(pv_path);
            PassiveBuffs = EncryptionManager.DeCrypt<List<Skill>>(pb_path);
        }

        public static List<Skill> GetRandomArmorSkills(int tier, Random r)
        {
            List<Skill> skills = new List<Skill>();

            int sNum = r.Next(1, 3);

            for(int i = 0; i < sNum; i++)
            {
                Skill s = (Skill)ActiveSkills[r.Next(0, ActiveSkills.Count)].Clone();
                s.Damage = r.Next(20 + (tier * 5), 40 + (tier * 5));
                s.Multiplier = r.Next(1, ((tier / 5) + 1) + 1);
                skills.Add(s);
            }

            return skills;
        }

        public static string GetSkillInfoString(Skill skill)
        {
            return $"{skill.Name}*Damage: {CalculateDamage(skill.Damage, skill.Multiplier)}*Element: {elements[skill.Element]}*Multiplier: {skill.Multiplier}";
        }

        public static int CalculateDamage(int d, int m)
        {
            if (m == 1)
            {
                return d;
            }
            else
            {
                return d + (m * 5);
            }
        }

        public static string ElementToString(int element)
        {
            return elements[element];
        }

        public static string StatsToString(int stat)
        {
            return stats[stat];
        }

        public static Skill GetPassiveSkill(int type, Random r)
        {
           
            if(type == SkillType.PASSIVE_VOID)
            {
                return (Skill)PassiveVoids[r.Next(0, PassiveVoids.Count)].Clone();
            }
            else
            {
                return (Skill)PassiveBuffs[r.Next(0, PassiveBuffs.Count)].Clone();
            }
        }

        public static void GenerateEnemySkills(Enemy e, int n, int m, Random r)
        {
            for(int i = 0; i < n; i++)
            {
                Skill a = (Skill)ActiveSkills[r.Next(0, ActiveSkills.Count)].Clone();
                a.Multiplier = m;
                a.Damage = CalculateDamage(r.Next(70, 106), m);
                e.active.Add(a);
            }
        }
    }
}
