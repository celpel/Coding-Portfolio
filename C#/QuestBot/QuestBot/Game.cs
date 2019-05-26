using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBot
{
    public class Game
    {
        private static List<Player> players = new List<Player>();
        private const string dblink = @"Server=localhost;uid=root;pwd=root;database=myschema";
        private static long[] xp = new long[1000];

        private static void InitGame()
        {
            int n = 1000;
            long initial = 50;
            int q = 0;
            for (int i = 1; i <= n; i++)
            {
                long j = initial * i;
                if (q > 0)
                {
                    long e = j + xp[q - 1];
                    if (e >= long.MaxValue)
                    {
                        xp[q] = long.MaxValue;
                    }
                    else
                    {
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

        // GM only
        public static void AddPlayer(string name)
        {
            if (xp[0] == 0)
            {
                Game.InitGame();
            }

            Player p = new Player();

            p.Name = name;
            p.Lvl = 1;
            p.Hp = 100;
            p.Mp = 100;
            p.Xp = 0;
            p.Attk = 3;
            p.Mgk = 3;
            p.HPDMG = p.Hp;
            p.MPDMG = p.Mp;

            players.Add(p);
        }

        // GM only
        public static string RemovePlayer(string name)
        {
            Player p = FindPlayer(name);
            try
            {
                players.Remove(p);
                var conn = new MySqlConnection(dblink);
                conn.Open();
                string q = $"DELETE FROM CURRENTPLAYERS WHERE CNAME = '{p.Name}'";
                MySqlCommand m = new MySqlCommand(q, conn);
                m.ExecuteNonQuery();
                conn.Close();
                return $"{p.Name} successfully removed.";
            }
            catch(Exception)
            {
                return "Remove unsuccessful. An error may have occurred.";
            }

        }


        // GM only
        public static string HealPlayerHP(string name, long amount)
        {
            Player p = FindPlayer(name);

            p.HPDMG += amount;
            if (p.HPDMG > p.Hp)
            {
                p.HPDMG = p.Hp;
            }

            players.Remove(FindPlayer(name));
            players.Add(p);
            return $"{p.Name} now has {p.HPDMG}HP";
        }

        // GM only
        public static string HealPlayerMP(string name, long amount)
        {
            Player p = FindPlayer(name);

            p.MPDMG += amount;
            if (p.MPDMG > p.Hp)
            {
                p.MPDMG = p.Mp;
            }

            players.Remove(FindPlayer(name));
            players.Add(p);
            return $"{p.Name} now has {p.MPDMG}MP";

        }

        // GM only
        public static string HealAllPlayerHP(long amount)
        {
            string str = "";
            foreach (Player p in players)
            {
                p.HPDMG += amount;
                if (p.HPDMG > p.Hp)
                {
                    p.HPDMG = p.Hp;
                }
                str += $"{p.Name} now has {p.HPDMG}HP" + '\n';
            }
            return str;
        }

        // GM only
        public static string HealAllPlayerMP(long amount)
        {
            string str = "";
            foreach (Player p in players)
            {

                p.MPDMG += amount;
                if (p.MPDMG > p.Mp)
                {
                    p.MPDMG = p.Mp;
                }
                str += $"{p.Name} now has {p.MPDMG}MP" + '\n';


            }

            return str;
        }

        public static void IncreaseDmgAll()
        {
            foreach(Player p in players)
            {
                if (p.Hp > p.Mp)
                {
                    p.Attk += 60;
                }
                else if (p.Hp < p.Mp)
                {
                    p.Mgk += 60;
                }
                else
                {
                    p.Attk += 30;
                    p.Mgk += 30;
                }
            }
        }

        // GM only
        public static string DeductPlayerHP(string name, long amount)
        {
            Player p = FindPlayer(name);

            p.HPDMG -= amount;
            if (p.HPDMG < 0)
            {
                p.HPDMG = 0;
            }

            players.Remove(FindPlayer(name));
            players.Add(p);
            return $"{p.Name} has lost {amount}HP lost -- {p.HPDMG}HP remaining.";

        }

        // GM only
        public static string DeductPlayerMP(string name, long amount)
        {
            Player p = FindPlayer(name);

            p.MPDMG -= amount;
            if (p.MPDMG < 0)
            {
                p.MPDMG = 0;
            }

            players.Remove(FindPlayer(name));
            players.Add(p);
            return $"{p.Name} has lost {amount}MP lost -- {p.MPDMG}MP remaining.";

        }

        // GM only
        public static string DeductAllPlayerHP(long amount)
        {
            string str = "";
            foreach (Player p in players)
            {

                p.HPDMG -= amount;
                if (p.HPDMG < 0)
                {
                    p.HPDMG = 0;
                }
                str += $"{p.Name} has lost {amount}hp. They are now at {p.HPDMG}" + '\n';

            }
            return str;
        }

        // GM only
        public static string AddXP(long amount)
        {
            string lvl = $"{amount} XP added to each player." + "\n";
            foreach (Player p in players)
            {
                p.Xp += amount;
                while (p.Xp >= xp[p.Lvl - 1])
                {
                    LevelUp(p);
                    lvl += $"{p.Name} leveled up! {p.Name} is now {p.Lvl}!" + '\n';
                }
            }

            return lvl;
        }

        private static void LevelUp(Player p)
        {
            p.Lvl++;
            p.Hp += 25;
            p.Mp += 25;

            if (p.Hp > p.Mp)
            {
                p.Attk += 2;

            }
            else if (p.Hp < p.Mp)
            {
                p.Mgk += 2;
            }

            p.Attk++;
            p.Mgk++;
            p.HPDMG = p.Hp;
            p.MPDMG = p.Mp;

        }

        // GM ONLY
        public static string PrioritizeAttk(string name)
        {
            Player p = FindPlayer(name);
            string retstr = "";
            if (p.Lvl == 1)
            {
                p.Hp += 50;
                p.Mp -= 30;
                p.Attk = 5;
                p.Mgk = 1;
                p.HPDMG = p.Hp;
                p.MPDMG = p.Mp;
                retstr = "Attack stat prioritized";
            }
            else
            {
                retstr = "Error: Player not lvl 1";
            }

            return retstr;
        }

        // GM ONLY
        public static string PrioritizeMgck(string name)
        {
            Player p = FindPlayer(name);
            string retstr = "";
            if (p.Lvl == 1)
            {
                p.Hp -= 30;
                p.Mp += 50;
                p.Attk = 1;
                p.Mgk = 5;
                p.HPDMG = p.Hp;
                p.MPDMG = p.Mp;
                retstr = "Magic stat prioritized";
            }
            else
            {
                retstr = "Error: Player not lvl 1";
            }

            return retstr;
        }

        private static Player FindPlayer(string name)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players.ElementAt(i).Name.Equals(name))
                {
                    return players.ElementAt(i);
                }
            }

            return null;
        }

        // Public
        public static string ViewStats(string name)
        {
            string stats = "Sorry, I couldn't find your stats. Maybe you're not in the player list?";

            Player p = FindPlayer(name);

            StringBuilder str = new StringBuilder();
            str.AppendLine(p.Name);
            str.AppendLine($"Level: {p.Lvl}");
            str.AppendLine($"HP: {p.HPDMG}/{p.Hp}");
            str.AppendLine($"MP: {p.MPDMG}/{p.Mp}");
            str.AppendLine($"Attack: {p.Attk}");
            str.AppendLine($"Magic: {p.Mgk}");
            str.AppendLine($"XP: {p.Xp}/{xp[p.Lvl - 1]}");
            stats = str.ToString();

            return stats;
        }

        public static string ViewAllStats()
        {
            string stats = "";

            foreach (Player p in players)
            {

                StringBuilder str = new StringBuilder();
                str.AppendLine(p.Name);
                str.AppendLine($"Level: {p.Lvl}");
                str.AppendLine($"HP: {p.HPDMG}/{p.Hp}");
                str.AppendLine($"MP: {p.MPDMG}/{p.Mp}");
                str.AppendLine($"Attack: {p.Attk}");
                str.AppendLine($"Magic: {p.Mgk}");
                str.AppendLine($"XP: {p.Xp}/{xp[p.Lvl - 1]}");
                stats += str.ToString() + '\n' + '\n';

            }

            return stats;
        }

        public static string SaveGame()
        {
            string dblink = @"Server=localhost;uid=root;pwd=root;database=myschema";
            try
            {
                var conn = new MySqlConnection(dblink);
                UpdateTable(conn, "CURRENTPLAYERS");
                UpdateTable(conn, "PLAYERS");
                return "Game saved.";
            }
            catch (MySqlException)
            {
                return "Save attempt failed.";
            }
        }

        private static void UpdateTable(MySqlConnection conn, string table)
        {

            List<string> names = QueryList(conn, table);
            foreach (Player p in players)
            {
                conn.Open();
                if (!names.Contains(p.Name))
                {
                    string query = $"INSERT INTO {table} VALUES ('{p.Name}', {p.Hp}, {p.Mp}, {p.Lvl}, {p.Xp}, {p.Attk}, {p.Mgk}, {p.HPDMG}, {p.MPDMG})";
                    MySqlCommand msqlc = new MySqlCommand(query, conn);
                    msqlc.ExecuteNonQuery();
                }
                else
                {
                    string query = $"UPDATE {table} SET HP = {p.Hp}," +
                                   $"MP = {p.Mp}," +
                                   $"LVL = {p.Lvl}," +
                                   $"EXP = {p.Xp}," +
                                   $"ATTK = {p.Attk}," +
                                   $"MGK = {p.Mgk}," +
                                   $"HPTEMP = {p.HPDMG}," +
                                   $"MPTEMP = {p.MPDMG}" +
                                   $" WHERE CNAME = '{p.Name}'";
                    MySqlCommand msqlc = new MySqlCommand(query, conn);
                    msqlc.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        public static string Load(string table)
        {
            if (xp[0] == 0)
            {
                InitGame();
            }
            players.Clear();

            try
            {
                var conn = new MySqlConnection(dblink);

                conn.Open();
                string q = $"SELECT * FROM {table}";
                MySqlCommand m = new MySqlCommand(q, conn);
                MySqlDataReader ms = m.ExecuteReader();

                while (ms.Read())
                {
                    players.Add(
                        new Player
                        {
                            Name = (string)ms["CNAME"],
                            Hp = (long)ms["HP"],
                            Mp = (long)ms["MP"],
                            Lvl = (long)ms["LVL"],
                            Xp = (long)ms["EXP"],
                            Attk = (long)ms["ATTK"],
                            Mgk = (long)ms["MGK"],
                            HPDMG = (long)ms["HPTEMP"],
                            MPDMG = (long)ms["MPTEMP"]
                        });
                }

                conn.Close();
                return "Load successful.";
            }
            catch (MySqlException)
            {
                return "Load attempt failed.";
            }

        }

        private static List<string> QueryList(MySqlConnection conn, string table)
        {
            conn.Open();
            string q = $"SELECT CNAME FROM {table}";
            MySqlCommand m = new MySqlCommand(q, conn);
            MySqlDataReader ms = m.ExecuteReader();
            List<string> names = new List<string>();

            while (ms.Read())
            {
                names.Add((string)ms["CNAME"]);
            }

            conn.Close();
            return names;
        }

    }
}
