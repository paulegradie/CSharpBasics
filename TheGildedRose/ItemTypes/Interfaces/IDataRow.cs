namespace TheGildedRose.ItemTypes.Interfaces
{
    public interface IDataRow
    {
        public string Name { get; set; }
        public int Quality { get; set; }
        public int SellIn { get; set; }
        public string DataType { get; set; }
    }
}