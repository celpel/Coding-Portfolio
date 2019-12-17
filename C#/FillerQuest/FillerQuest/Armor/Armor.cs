using ProtoBuf;
using System.Collections.Generic;
using System.Text;

namespace AscendedRPG
{
    [ProtoContract]
    public class Armor
    {
        [ProtoMember(1)]
        public int Piece { get; set; } // head, chest, arms, waist, legs
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Defense { get; set; }
        [ProtoMember(4, AsReference = true)]
        public List<Skill> ActiveSkills { get; set; }

        public Armor()
        {
            if(ActiveSkills == null)
            {
                ActiveSkills = new List<Skill>();
            }
        }

        public string SkillsAsString()
        {
            StringBuilder str = new StringBuilder();

            foreach (Skill s in ActiveSkills)
            {
                str.Append($"{s.ToString()}, ");
            }

            string ret = str.ToString().TrimEnd(' ');
            return ret.TrimEnd(',');
        }

        public override string ToString()
        {
            return $"[{Defense}] {Name}";
        }
    }
}