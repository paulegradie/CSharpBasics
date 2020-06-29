namespace TheGildedRose.ItemTypes.Interfaces
{
    public interface IItem
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int SellIn { get; set; }
    }
}