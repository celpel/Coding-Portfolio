using AscendedRPG.Files;
using System;
using System.Collections.Generic;

namespace AscendedRPG
{
    public class Dungeon
    {
        private int fights, currentFight;

        public int maxEnemies, tier;

        private EnemyManager loader;

        public List<Enemy> enemies;

        public bool isBoss, isInvader, isEXBoss, isEXInvader, isBountyBoss, isElderGod, isFinalBoss;

        public int enemyTurns;

        public Dungeon(int t)
        {
            tier = t;
            fights = (t + 5)/2;
            currentFight = 1;
            isBountyBoss = false;
            isEXInvader = false;
            isFinalBoss = false;
            loader = new EnemyManager();
        }

        public void GenerateFight()
        {
            enemies = new List<Enemy>();
            if (tier == 500)
            {
                isBoss = true;
                isFinalBoss = true;
                fights = 1;
                GenerateFinalBoss();
            }
            else if (currentFight % 5 == 0)
            {
                isBoss = true;

                var r = new Random();

                int invader = r.Next(0, 100);

                if (invader < 10 && tier >= 20)
                {
                    isInvader = true;
                }
                else
                {
                    isInvader = false;
                }

                GenerateBoss();
            }
            else
            {
                isBoss = false;
                GenerateEnemies();
            }
        }

        private void GenerateFinalBoss()
        {
            var r = new Random();

            string name = "Rickeus Martinus: Ascended Lord";
            string image = loader.RetrieveFinalBossImage(); // get final boss image
            int hp = 30000000;
            enemyTurns = loader.RetrieveBossTurns(tier);
            string title = loader.GetFinalBossCard();

            Enemy b = new Enemy(image, name, hp, title, false);

            loader.AddSkills(tier, b, r);
            loader.AddWeaknesses(b, r);

            enemies.Add(b);

            maxEnemies = enemies.Count;
        }

        private void GenerateBoss()
        {
            var r = new Random();

            string image;
            string name;
            int hp;
            string title;

            int ex = r.Next(0, 100);
            bool isEx = false;

            if(isElderGod)
            {
                image = loader.RetreiveEBossImage(tier);

                name = loader.RetrieveEName(tier);

                hp = loader.RetrieveEXBossHP(tier) * 20;

                enemyTurns = loader.RetrieveBossTurns(tier) + 5;

                title = loader.GetEBossCard();

                isEx = false;
            }
            else if (isBountyBoss)
            {
                int v = r.Next(1, tier);

                name = loader.RetrieveBountyName(v);

                if (isEXInvader)
                {
                    image = loader.RetrieveEXBountyBossImage(v);
                    name = $"EX {name}";
                    hp = loader.RetrieveEXBossHP(tier) * 3;
                    enemyTurns = loader.RetrieveBossTurns(tier);
                    title = loader.GetEXBountyBossCard();
                    isEx = true;
                }
                else
                {
                    image = loader.RetrieveBountyBossImage(v);
                    hp = loader.RetrieveBossHP(tier) * 3;
                    enemyTurns = 4;
                    title = loader.GetBountyBossCard();
                }
            }
            else if (isInvader)
            {
                name = loader.RetrieveInvaderName(tier);
                if (ex < 5 && tier >= 30)
                {
                    image = loader.RetrieveEXInvaderImage(tier);
                    name = $"EX {name}";
                    hp = loader.RetrieveEXBossHP(tier) * 2;
                    enemyTurns = loader.RetrieveBossTurns(tier);
                    isEXInvader = true;
                    title = loader.GetEXInvaderCard();
                    isEx = true;
                }
                else
                {
                    image = loader.RetrieveInvaderImage(tier);
                    hp = loader.RetrieveBossHP(tier) * 2;
                    enemyTurns = 4;
                    title = loader.GetInvaderCard();
                }
            }
            else
            {
                name = loader.RetrieveRandomBossName(r);
                if (ex < 10 && tier >= 15)
                {
                    image = loader.RetrieveEXBossImage(r);
                    name = $"EX {name}";
                    hp = loader.RetrieveEXBossHP(tier);
                    enemyTurns = loader.RetrieveBossTurns(tier);
                    isEXBoss = true;
                    title = loader.GetEXBossCard();
                    isEx = true;
                }
                else
                {
                    image = loader.RetrieveBossImage(r);
                    hp = loader.RetrieveBossHP(tier);
                    enemyTurns = loader.RetrieveBossTurns(tier);
                    title = loader.GetBossCard();
                }

            }

            Enemy b = new Enemy(image, name, hp, title, isEx);

            loader.AddSkills(tier, b, r);
            loader.AddWeaknesses(b, r);

            enemies.Add(b);

            maxEnemies = enemies.Count;
        }

        private void GenerateEnemies()
        {
            var rand = new Random();
            int num = rand.Next(1, 4);
            bool isEx = false;
            for (int n = 1; n <= num; n++)
            {
                string image;
                int hp;
                string name = loader.RetrieveRandomEnemyName(rand);

                int ex = rand.Next(0, 100);

                if (ex < 3 && tier >= 10)
                {
                    image = loader.RetrieveEXEnemyImages(tier, rand);
                    hp = loader.RetrieveEXEnemyHP(tier, rand);
                    name = $"EX {name}";
                    isEx = true;
                }
                else
                {
                    int pog = rand.Next(0, 100);
                    if(pog < 5)
                    {
                        image = loader.RetreivePotOfGreed();
                        name = "Pot of Greed";

                    }
                    else
                    {
                        image = loader.RetrieveEnemyImages(tier, rand);
                    }

                    hp = loader.RetrieveEnemyHP(tier, rand);
                }

                Enemy e = new Enemy(image, name, hp, string.Empty, isEx);

                loader.AddSkills(tier, e, rand);
                loader.AddWeaknesses(e, rand);

                enemies.Add(e);
            }

            enemyTurns = enemies.Count;
            maxEnemies = enemies.Count;
        }

        public bool IsNewWeakness(string image, int element)
        {
            return loader.IsWeaknessNew(image, element);
        }

        public void NewWeaknessFound(Enemy e, int element)
        {
            loader.WeaknessFound(e, element);
        }

        public void GetPlayerKnownWeaknesses(Enemy e)
        {
            loader.UpdateEnemyName(e);
        }

        public List<Armor> GetArmorRewards(int n, bool isEX, Random r)
        {
            List<Armor> rewards = new List<Armor>();

            for (int i = 0; i < n; i++)
            {
                rewards.Add(ArmorManager.GetRandomArmorPiece(tier, r.Next(0, 5), r));
            }

            if (isEX)
            {
                foreach (Armor armor in rewards)
                {
                    armor.Name = $"EX: {armor.Name}";
                    armor.Defense += 50;
                    foreach (Skill skill in armor.ActiveSkills)
                    {
                        skill.Name = $"EX: {skill.Name}";
                        skill.Multiplier++;
                        skill.Damage += 25;
                    }
                }
            }

            return rewards;
        }

        public List<Skill> GetPassiveReserveSkillRewards()
        {
            var r = new Random();

            int n = r.Next(1, 3);

            List<Skill> passives = new List<Skill>();

            int[] types = { SkillType.PASSIVE_BUFF, SkillType.PASSIVE_VOID };
            for (int i = 0; i < n; i++)
            {
                int type = r.Next(0, types.Length);
                Skill p = SkillManager.GetPassiveSkill(type, r);
                if (p.Name.Equals("Turn Boost"))
                {
                    p.Multiplier = 1;

                    if (isEXInvader)
                    {
                        p.Multiplier++;
                    }
                }
                else
                {
                    int min, max;
                    if (isEXInvader)
                    {
                        min = 3;
                        max = 4;
                    }
                    else
                    {
                        min = 1;
                        max = 2;
                    }

                    p.Multiplier = r.Next(min, max + 2);
                }

                passives.Add(p);

            }

            return passives;
        }

        public void EndFight()
        {
            fights--;
            currentFight++;
        }

        public bool IsDungeonComplete()
        {
            if (fights <= 0)
            {
                SaveManager.SaveWeaknessIndex(loader.GetWeaknessIndex());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ForceEnd()
        {
            fights = 0;
        }

        public int GetFights()
        {
            return fights;
        }

        public int GetCurrentFight()
        {
            return currentFight;
        }

        public bool CanUseBountyKey()
        {
            if (fights + currentFight % 5 == 0)
                return true;
            else
            {
                if (fights <= 4)
                    return false;
                else
                    return true;
            }
        }

    }
}
