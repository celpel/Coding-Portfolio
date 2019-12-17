using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    [ProtoContract]
    public class WeaknessSaveFile
    {
        [ProtoMember(1)]
        public List<string> Index { get; set; }
        [ProtoMember(2)]
        public List<string> Reality { get; set; }

        public WeaknessSaveFile()
        {
            if(Index == null)
            {
                Index = new List<string>();
            }
           
            if(Reality == null)
            {
                Reality = new List<string>();
            }
            
        }
    }
}
