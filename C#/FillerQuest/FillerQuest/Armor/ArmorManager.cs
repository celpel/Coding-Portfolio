using AscendedRPG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    public static class ArmorManager
    {
        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "armor.bin");

        private static readonly string[] pieces = { "Head", "Torso", "Arms", "Waist", "Legs", "Charm" };

        private static string[] armorNames;

        public static void LoadArmorIntoMemory()
        {
            armorNames = EncryptionManager.DeCrypt<string[]>(path);
        }

        public static Armor GetRandomArmorPiece(int tier, int piece, Random r)
        {
            Armor armor = new Armor();

            armor.Name = $"{armorNames[r.Next(0, armorNames.Length)]} {pieces[piece]}";
            armor.Piece = piece;
            armor.Defense = r.Next(tier * 10, (tier + 10) * 10);
            armor.ActiveSkills = new List<Skill>();
            armor.ActiveSkills.AddRange(SkillManager.GetRandomArmorSkills(tier, r));

            return armor;
        }
    }
}
