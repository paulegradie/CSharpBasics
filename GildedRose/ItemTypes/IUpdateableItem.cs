namespace GildedRose.ItemTypes
{
    public interface IUpdateable
    {
        void Update();
    }

    public interface IItem
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int SellIn { get; set; }
    }

    public interface IUpdateableItem : IUpdateable, IItem
    {
    }
}