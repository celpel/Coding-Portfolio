using AscendedRPG.Files;
using ProtoBuf;
using System;

namespace AscendedRPG
{
    [ProtoContract]
    public class Skill : ICloneable
    {
        [ProtoMember(1)]
        public int S_Type { get; set; } // what type of skill you're working with (will help with DB lookups)
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Multiplier { get; set; }
        [ProtoMember(4)]
        public int Element { get; set; }
        [ProtoMember(5)]
        public int Damage { get; set; }

        public Skill() { }

        public override string ToString()
        {
            if(Damage > 0)
            {
                return $"[{SkillManager.CalculateDamage(Damage, Multiplier)}] {Name} +{Multiplier}";
            }
            else
            {
                return $"{Name} +{Multiplier}";
            }
            
        }

        public object Clone()
        {
            return new Skill { S_Type = S_Type, Damage = Damage, Name = Name, Multiplier = Multiplier, Element = Element };
        }
    }
}