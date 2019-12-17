using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    public class WeaknessIndex
    {
        public Dictionary<string, HashSet<int>> Index { get; set; } // what's known by the player
        public Dictionary<string, HashSet<int>> Reality { get; set; } // what's known by the game

        public WeaknessIndex()
        {
            if(Index == null)
            {
                Index = new Dictionary<string, HashSet<int>>();
            }

            if(Reality == null)
            {
                Reality = new Dictionary<string, HashSet<int>>();
            }
        }

        public bool IsWeaknessNew(string image, int element)
        {
            if(Index.ContainsKey(image))
            {
                if (Index[image].Contains(element))
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }

        // set the actual weaknesses of the mob
        public void SetWeaknessGame(string image, int element)
        {
            if(Reality.ContainsKey(image))
            {
                Reality[image].Add(element);
            }
            else
            {
                Reality.Add(image, new HashSet<int>());
                Reality[image].Add(element);
            }
        }

        // setting a weakness from the player's perspective
        public void SetWeaknessPlayer(string image, int element)
        {
            if(Index.ContainsKey(image))
            {
                if(!Index[image].Contains(element))
                {
                    Index[image].Add(element);
                }
            }
            else
            {
                Index.Add(image, new HashSet<int>());
                Index[image].Add(element);
            }
        }

        // weaknesses YOU are aware of
        public string GetWeaknessStringPlayer(string image)
        {
            StringBuilder weak = new StringBuilder();

            weak.Append("[");

            int num = Reality[image].Count;

            if(Index.ContainsKey(image))
            {
                HashSet<int> w = Index[image];

                foreach(int i in w)
                {
                    weak.Append($"{SkillManager.ElementToString(i)}, ");
                }

                while(num > w.Count)
                {
                    weak.Append("???, ");
                    num--;
                }
            }
            else
            {
                Console.WriteLine("here");
                for(int i = 0; i < num; i++)
                {
                    weak.Append("???, ");
                }
            }

            string result = $"{weak.ToString().TrimEnd(' ').TrimEnd(',')}]";

            return result;
        }

        public HashSet<int> GetWeaknessSet(string image)
        {
            if(Reality.ContainsKey(image))
            {
                return Reality[image];
            }
            else
            {
                return null;
            }
        }

    }
}
