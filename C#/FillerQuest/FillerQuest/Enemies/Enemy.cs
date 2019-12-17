using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class Enemy
    {
        public string image;
        public string name;
        public string weakName;
        public int hp;
        public List<Skill> active;
        public HashSet<int> weakness;
        public string titleCard;
        public bool isEx;

        public Enemy(string i, string n, int h, string tc, bool ex)
        {
            image = i;
            name = n;
            weakName = string.Empty;
            hp = h;
            titleCard = tc;
            active = new List<Skill>();
            weakness = new HashSet<int>();
            isEx = ex;
        }
    }
}
