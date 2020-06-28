namespace ItemTypes.Types
{
    /// <summary>
    /// Not allow to modify this class
    /// </summary>
    public class Item
    {
        public string Name { get; set; } // Since we are using auto-property, we don't need a backing field
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}