using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AscendedRPG.Files
{
    public class EnemyManager
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended");

        private readonly string e_path = Path.Combine(PATH, "enemyNames", "enames.bin"); // enemies
        private readonly string b_path = Path.Combine(PATH, "enemyNames", "bnames.bin"); // bosses
        private readonly string bb_path = Path.Combine(PATH, "enemyNames", "bbnames.bin"); // bosses
        private readonly string inv_path = Path.Combine(PATH, "enemyNames", "invnames.bin"); // bosses
        private readonly string g_path = Path.Combine(PATH, "enemyNames", "gnames.bin"); // bosses

        private readonly string E_FOLDERS = "enemies";
        private readonly string B_FOLDER = "bosses";
        private readonly string INV_FOLDER = "invader";
        private readonly string BB_FOLDER = "bountyBoss";
        private readonly string EB_FOLDER = "elderbosses";

        private readonly string EX_FOLDER = "ex_enemies";
        private readonly string EXB_FOLDER = "ex_bosses";
        private readonly string EXINV_FOLDER = "ex_invaders";
        private readonly string EXBB_FOLDER = "ex_bountyBoss";

        private readonly string TITLECARD = "titleCards"; 

        private string[] enemies, bosses, bountyNames, inv_names, godNames;

        private WeaknessIndex weaknesses;

        public EnemyManager()
        {
            godNames = EncryptionManager.DeCrypt<string[]>(g_path);
            weaknesses = SaveManager.LoadWeaknessIndex();
            enemies = EncryptionManager.DeCrypt<string[]>(e_path);
            bosses = EncryptionManager.DeCrypt<string[]>(b_path);
            bountyNames = EncryptionManager.DeCrypt<string[]>(bb_path); // these names are always sorted
            inv_names = EncryptionManager.DeCrypt<string[]>(inv_path); // these names are always sorted
        }

        // Enemy / Boss Images
        public string RetrieveEnemyImages(int tier, Random rand)
        {
            var folders = Directory.GetDirectories(Path.Combine(PATH, E_FOLDERS));

            var files = GetEnemyImage(folders[(tier - 1) % folders.Length]);

            return files[rand.Next(files.Length)];
        }

        public string RetrieveEXEnemyImages(int tier, Random rand)
        {
            var files = GetEnemyImage(EX_FOLDER);

            return files[rand.Next(files.Length)];
        }

        public string RetreivePotOfGreed()
        {
            var files = GetEnemyImage("pog");
            return files[0];
        }

        public string RetrieveBossImage(Random rand)
        {
            var files = GetEnemyImage(B_FOLDER);

            return files[rand.Next(files.Length)];
        }

        public string RetrieveEXBossImage(Random rand)
        {
            var files = GetEnemyImage(EXB_FOLDER);

            return files[rand.Next(files.Length)];
        }

        public string RetreiveEBossImage(int tier)
        {
            var files = GetEnemyImage(EB_FOLDER);
            return files[(tier - 1) % files.Length];
        }

        public string RetrieveInvaderImage(int tier)
        {
            var files = GetEnemyImage(INV_FOLDER);
            return files[(tier - 1) % files.Length];
        }

        public string RetrieveEXInvaderImage(int tier)
        {
            var files = GetEnemyImage(EXINV_FOLDER);
            return files[(tier - 1) % files.Length];
        }

        public string RetrieveBountyBossImage(int v)
        {
            var files = GetEnemyImage(BB_FOLDER);
            return files[(v - 1) % files.Length];
        }

        public string RetrieveEXBountyBossImage(int v)
        {
            var files = GetEnemyImage(EXBB_FOLDER);
            return files[(v - 1) % files.Length];
        }

        public string RetrieveFinalBossImage()
        {
            var files = GetEnemyImage("finalBoss");
            return files[0];
        }

        private string[] GetEnemyImage(string path)
        {
            return Directory.GetFiles(Path.Combine(PATH, path), "*.png");
        }

        // Enemy / Boss Name

        public string RetrieveRandomBossName(Random r) => GetEnemyName(bosses, r.Next(0, bosses.Length));
        public string RetrieveInvaderName(int tier) => GetEnemyName(inv_names, (tier - 1) % inv_names.Length);
        public string RetrieveBountyName(int v) => GetEnemyName(bountyNames, (v - 1) % bountyNames.Length);
        public string RetrieveEName(int v) => GetEnemyName(godNames, (v - 1) % godNames.Length);
        public string RetrieveRandomEnemyName(Random r) => GetEnemyName(enemies, r.Next(0, enemies.Length));

        private string GetEnemyName(string[] names, int value) => names[value];

        // Boss / Enemy HP
        public int RetrieveEnemyHP(int tier, Random rand) => GetEnemyHP(tier);
        public int RetrieveEXEnemyHP(int tier, Random rand) => GetEXEnemyHP(tier);
        public int RetrieveBossHP(int tier) => BossHPCalc(GetEnemyHP(tier));
        public int RetrieveEXBossHP(int tier) => BossHPCalc(GetEXEnemyHP(tier));

        private int GetEnemyHP(int t)
        {
            var r = new Random();
            int[] mult = { 40, 50, 60 };
            int m = mult[r.Next(0, mult.Length)];
            return t * m;
        }

        private int GetEXEnemyHP(int t)
        {
            var r = new Random();
            int[] mult = { 80, 100, 120 };
            int m = mult[r.Next(0, mult.Length)];
            return t * m;
        }

        private int BossHPCalc(int hp)
        {
            return (int)((Math.Log(hp) * hp) + hp);
        }

        // Boss Turns
        public int RetrieveBossTurns(int tier)
        {
            var r = new Random();
            if(tier < 10)
            {
                return 2;
            }
            else if(tier >= 10 && tier <= 20)
            {
                return r.Next(2, 4);
            } else if(tier >= 20 && tier < 50)
            {
                return r.Next(3, 6);
            } else if(tier >= 50 && tier < 80)
            {
                return r.Next(4, 9);
            }
            else
            {
                return r.Next(6, 11);
            }
        }

        // Boss / Enemy Title Cards
        public string GetInvaderCard()
        {
            return Path.Combine(PATH, TITLECARD, "invaderCard.png");
        }

        public string GetEXInvaderCard()
        {
            return Path.Combine(PATH, TITLECARD, "exInvaderCard.png");
        }

        public string GetBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "bossCard.png");
        }

        public string GetEXBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "exBossCard.png");
        }

        public string GetEBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "elderBossCard.png");
        }

        public string GetBountyBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "bountyBossCard.png");
        }

        public string GetEXBountyBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "exBountyBossCard.png");
        }

        public string GetFinalBossCard()
        {
            return Path.Combine(PATH, TITLECARD, "finalBossCard.png");
        }

        // Skills + Misc.
        public void AddSkills(int tier, Enemy e, Random rand)
        {
            // number, floor, ceiling, multiplier limit
            int n, m;

            if (tier < 26)
            {
                m = 2;
                n = rand.Next(1, 4);
            }
            else if (tier >= 26 && tier < 51)
            {
                m = 3;
                n = rand.Next(3, 6);
            }
            else if (tier >= 51 && tier < 76)
            {
                m = 4;
                n = rand.Next(4, 7);
            } else
            {
                m = rand.Next(5, tier/10);
                n = rand.Next(7, 10);
            }

            SkillManager.GenerateEnemySkills(e, n, m, rand);
        }

        public void WeaknessFound(Enemy e, int element)
        {
            weaknesses.SetWeaknessPlayer(e.image, element);
            e.weakName = $"{e.name} {weaknesses.GetWeaknessStringPlayer(e.image)}";
            SaveManager.SaveWeaknessIndex(weaknesses);
        }

        public bool IsWeaknessNew(string image, int element)
        {
            return weaknesses.IsWeaknessNew(image, element);
        }

        public void AddWeaknesses(Enemy e, Random rand)
        { 
            // check the real index
            HashSet<int> temp = weaknesses.GetWeaknessSet(e.image);

            if(temp == null)
            {
                // no weakness entry was present in "Reality"
                int n = rand.Next(1, 3);

                for (int i = 0; i < n; i++)
                {
                    int w = rand.Next(0, 9);
                    while (e.weakness.Contains(w))
                    {
                        w = rand.Next(0, 9);
                    }
                    // set weakness in "Reality"
                    weaknesses.SetWeaknessGame(e.image, w);
                    e.weakness.Add(w);
                }

                SaveManager.SaveWeaknessIndex(weaknesses);
            }
            else
            {
                e.weakness = temp;
            }
            e.weakName = $"{e.name} {weaknesses.GetWeaknessStringPlayer(e.image)}";
        }

        public void UpdateEnemyName(Enemy e)
        {
            e.weakName = $"{e.name} {weaknesses.GetWeaknessStringPlayer(e.image)}";
        }

        private void GetDamageFloorDamageCeiling(int tier, int[] d)
        {
            if (tier < 26)
            {
                d[0] = 50;
                d[1] = 70;
            }
            else if (tier >= 26 && tier < 50)
            {
                d[0] = 70;
                d[1] = 97;
            }
            else
            {
                d[0] = 97;
                d[1] = 200;
            }
        }

        public WeaknessIndex GetWeaknessIndex()
        {
            return weaknesses;
        }
    }
}
