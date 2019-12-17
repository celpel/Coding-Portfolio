using AscendedRPG.Files;
using FillerQuest.Relics;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class SaveManager
    {
        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "player.bin");

        private static readonly string wPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "weaknessIndex.bin");

        private static readonly string rPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "relicManager.bin");

        public static bool DoesSaveFileExist()
        {
            return File.Exists(path);
        }

        public static bool DoesWeakFileExist()
        {
            return File.Exists(wPath);
        }

        public static bool DoesRelicFileExist()
        {
            return File.Exists(rPath);
        }

        public static void SaveGame(Player p)
        {
            EncryptionManager.EncryptFile(path, p);
        }

        public static Player LoadGame()
        {
            Player p;

            p = EncryptionManager.DeCrypt<Player>(path);

            return p;
        }

        public static void SaveRelicManager(RelicManager rm)
        {
            EncryptionManager.EncryptFile(rPath, rm);
        }

        public static RelicManager LoadRelicManager()
        {
            return EncryptionManager.DeCrypt<RelicManager>(rPath);
        }


        public static void SaveWeaknessIndex(WeaknessIndex w)
        {
            WeaknessSaveFile wsf = new WeaknessSaveFile();

            if(w.Index.Count > 0)
                StoreWeaknessKVPs(w.Index, wsf.Index);

            if(w.Reality.Count > 0)
                StoreWeaknessKVPs(w.Reality, wsf.Reality);

            EncryptionManager.EncryptFile(wPath, wsf);
        }

        public static WeaknessIndex LoadWeaknessIndex()
        {
            WeaknessIndex w = new WeaknessIndex();

            WeaknessSaveFile wsf = new WeaknessSaveFile();

            wsf = EncryptionManager.DeCrypt<WeaknessSaveFile>(wPath);

            w.Index = RetrieveWeaknessKVPs(wsf.Index, wsf);

            w.Reality = RetrieveWeaknessKVPs(wsf.Reality, wsf);

            return w;
        }

        private static void StoreWeaknessKVPs(Dictionary<string, HashSet<int>> D, List<string> L)
        {
            foreach (KeyValuePair<string, HashSet<int>> kvp in D)
            {
                StringBuilder str = new StringBuilder();
                str.Append($"{kvp.Key}%");
                foreach (int i in kvp.Value)
                {
                    str.Append($"{i},");
                }
                L.Add(str.ToString().TrimEnd(','));
            }
        }

        private static Dictionary<string, HashSet<int>> RetrieveWeaknessKVPs(List<string> L, WeaknessSaveFile wsf)
        {
            Dictionary<string, HashSet<int>> D = new Dictionary<string, HashSet<int>>();

            foreach (string entry in L)
            {
                string[] kvp = entry.Split('%');

                string key = kvp[0];

                if(!D.ContainsKey(kvp[0]))
                {
                    D.Add(key, new HashSet<int>());
                }

                string[] values = kvp[1].Split(',');

                foreach(string v in values)
                {
                    D[key].Add(Int32.Parse(v));
                }
            }

            return D;
        }
    }
}
