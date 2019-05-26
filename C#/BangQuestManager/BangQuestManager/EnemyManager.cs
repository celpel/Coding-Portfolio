using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangQuestManager
{
    public class EnemyManager
    {
        private long[] xp;
        private long[] hp;

        public EnemyManager()
        {
            long n = 1000;
            hp = new long[n];
            xp = new long[n];
            long initial = 50;
            long q = 0;
            for (long i = 1; i <= n; i++)
            {
                long j = initial * i;
                if (q > 0)
                {
                    long e = j + xp[q - 1];
                    if (e >= long.MaxValue)
                    {
                        xp[q] = long.MaxValue;
                        hp[q] = i;
                    }
                    else
                    {
                        Console.WriteLine(q - 1);
                        xp[q] = j + xp[q - 1];
                    }

                }
                else
                {
                    xp[q] = j;
                }

                initial += 50;
                q++;
            }
        }

        public long[] EnemyHP(long[] enemyLevels, long pcount)
        {
            long[] ehp = new long[enemyLevels.Length];
            for(long i = 0; i < ehp.Length; i++)
            {
                ehp[i] = (enemyLevels[i] * 10) + (pcount * 5);
            }
            return ehp;
        }

        public long BossHP(long enemyLevel, long pcount)
        {
            return (enemyLevel * 100) + (pcount * 10);
        }

        public long EarnedXP(long[] enemyLevels, bool boss, long pcount)
        {
            long total = 0;
            long non_zeroes = 0;
            for (long i = 0; i < enemyLevels.Length; i++)
            {
                if (!boss)
                {
                    if (enemyLevels[i] != 0)
                    {
                        non_zeroes++;
                    }
                    total += EnemyXP(enemyLevels[i], pcount);
                }
                else
                {
                    total += BossXP(enemyLevels[i]);
                }

            }

            if (non_zeroes == 0)
            {
                total = total / enemyLevels.Length;
            }
            else
            {
                total = total / non_zeroes;
            }

            return total;
        }

        private long EnemyXP(long enemyLevel, long pcount)
        {
            // enemyLevel = the level of the enemies
            long min, max = 0;

            // xp rate changes based on level & player count
            if (enemyLevel < 30)
            {
                min = (xp[enemyLevel] / 20) + pcount;
                max = (xp[enemyLevel] / 5) + pcount;
            }
            else if (enemyLevel <= 60 && enemyLevel >= 30)
            {
                min = (xp[enemyLevel] / 45) + pcount;
                max = (xp[enemyLevel] / 15) + pcount;
            }
            else
            {
                min = (xp[enemyLevel] / 75) + pcount;
                max = (xp[enemyLevel] / 20) + pcount;
            }

            var z = new Random();
            long exp = z.NextLong(min, max);
            return exp;
        }

        private long BossXP(long level)
        {
            long max = 0;

            if (level < 30)
            {
                max = xp[level] / 5;
            }
            else if (level <= 60 && level >= 30)
            {
                max = xp[level] / 15;
            }
            else
            {
                max = xp[level] / 20;
            }

            return max;
        }
    }
}

