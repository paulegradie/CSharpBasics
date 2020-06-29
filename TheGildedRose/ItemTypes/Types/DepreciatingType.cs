using TheGildedRose.ItemTypes.Interfaces;

namespace TheGildedRose.ItemTypes.Types
{
    public class DeprecatingType : BaseItemType, ICreatable<DeprecatingType>, IUpdateableItem
    {
        private DeprecatingType(string name, int quality, int sellIn) : base("Depreciate", name, quality, sellIn)
        {
        }

        public static DeprecatingType CreateType(IDataRow data)
        {
            return new DeprecatingType(data.Name, data.Quality, data.SellIn);
        }

        public void Update()

        {
            UpdateProperties(1);
        }
    }
}