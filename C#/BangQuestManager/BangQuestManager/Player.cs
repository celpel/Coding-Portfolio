namespace BangQuestManager
{
    public class Player
    {
        public string Name { get; set; }
        public long Hp { get; set; }
        public long Mp { get; set; }     public long Lvl { get; set; }
        public long Xp { get; set; }
        public long Attk { get; set; }
        public long Mgk { get; set; }
        public long HPDMG { get; set; }
        public long MPDMG { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}