using FillerQuest;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class Player
    {
        private const int HP = 100; // default HP, gets incremented upon by armor

        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public ArmorSet Set { get; set; }

        [ProtoMember(3, AsReference = true)]
        public List<Armor> Inventory { get; set; }

        [ProtoMember(4)]
        public int Tier { get; set; } // max tier of dungeon that can be explored

        [ProtoMember(5)]
        public int Turns { get; set; }

        [ProtoMember(6)]
        public long DellenCoin { get; set; }

        [ProtoMember(7)]
        public List<int> BountyKeys { get; set; } // set of TIERS

        [ProtoMember(8)]
        public List<int> EXBountyKeys { get; set; } // set of TIERS

        [ProtoMember(9, AsReference = true)]
        public List<Armor> ReserveArmor { get; set; }

        [ProtoMember(10)]
        public string Picture { get; set; }

        [ProtoMember(13, AsReference = true)]
        public Item[] Items { get; set; }

        [ProtoMember(14)]
        public int GodLordKeys { get; set; }

        // attack, defense, crits (turns listed above)
        public int[] stats = { 0, 0, 0, 0 };

        public byte[] elementalAttackModifier = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public int[] resistances = { 0, 0, 0, 0, 0, 0, 0, 0, 0};

        public Player()
        {
            if(Inventory == null)
            {
                Inventory = new List<Armor>();
            }

            if(ReserveArmor == null)
            {
                ReserveArmor = new List<Armor>();
            }

            if(BountyKeys == null)
            {
                BountyKeys = new List<int>();
            }

            if (EXBountyKeys == null)
            {
                EXBountyKeys = new List<int>();
            }
        }

        public void AddDellenCoin(long amount)
        {
            try
            {
                DellenCoin = checked(DellenCoin + amount);
            }
            catch (OverflowException)
            {
                DellenCoin = long.MaxValue;
            }
        }

        public int GetHP()
        {
            return HP;
        }

        public int GetItemCount()
        {
            int c = 0;
            foreach (Item i in Items)
            {
                c += i.Quantity;
            }
            return c;
        }

        public void ResetElementalMods()
        {
            for (int i = 0; i < elementalAttackModifier.Length; i++)
                elementalAttackModifier[i] = 0;
        }

    }
}
