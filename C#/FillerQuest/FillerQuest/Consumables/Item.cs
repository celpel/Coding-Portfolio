using ProtoBuf;
using System;

namespace FillerQuest
{
    [ProtoContract]
    public class Item
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int ItemType { get; set; }

        [ProtoMember(3)]
        public int Quantity { get; set; }

        public Item() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
