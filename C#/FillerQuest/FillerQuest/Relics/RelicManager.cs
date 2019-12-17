using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillerQuest.Relics
{
    [ProtoContract]
    public class RelicManager
    {
        [ProtoMember(1)]
        public Relic Current { get; set; }

        [ProtoMember(2, AsReference = true)]
        public List<Relic> ReserveRelics { get; set; }

        public RelicManager()
        {
            if(ReserveRelics == null)
            {
                ReserveRelics = new List<Relic>();
            }
        }
    }
}
