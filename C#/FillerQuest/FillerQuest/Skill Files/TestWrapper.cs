using AscendedRPG;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Skill_Files
{
    [ProtoContract(AsReferenceDefault = true)]
    public class TestWrapper
    {
        [ProtoMember(1)]
        public List<Skill> ActiveSkills { get; set; }

        [ProtoMember(2)]
        public List<Skill> PassiveVSkills { get; set; }

        [ProtoMember(3)]
        public List<Skill> PassiveBSkills { get; set; }

        public TestWrapper() { }
    }
}
