using GildedRose.Data;

namespace GildedRose.ItemTypes
{
    public class DeprecatingType : BaseItemType, ICreatable<DeprecatingType>, IUpdateableItem
    {
        private DeprecatingType(string name, int quality, int sellIn) : base("Depreciate", name, quality, sellIn)
        {
        }

        public static DeprecatingType CreateType(DataRow data)
        {
            return new DeprecatingType(data.Name, data.Quality, data.SellIn);
        }

        public void Update()

        {
            UpdateProperties(1);
        }
    }
}