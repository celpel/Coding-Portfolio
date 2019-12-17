using AscendedRPG.Files;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillerQuest.Relics
{
    [ProtoContract]
    public class Relic
    {
        private readonly string[] types = { "Lifesteal", "x2 Hit", "100% Crit" };

        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public int Damage { get; set; }
        [ProtoMember(3, AsReference = true)]
        public List<int> Elements { get; set; }
        [ProtoMember(4)]
        public int RelicType { get; set; }

        public Relic()
        {
            if(Elements == null)
            {
                Elements = new List<int>();
            }
        }

        public string GetRelicType()
        {
            return types[RelicType];
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            foreach (int e in Elements)
                str.Append($"[{SkillManager.ElementToString(e)}]");

            str.Append($"[{types[RelicType]}]");
            return str.ToString();
        }
    }
}
