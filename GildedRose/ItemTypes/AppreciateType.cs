using GildedRose.Data;

namespace GildedRose.ItemTypes
{
    public class AppreciateType : BaseItemType, ICreatable<AppreciateType>, IUpdateableItem
    {
        private AppreciateType(string name, int quality, int sellIn) : base("Appreciate", name, quality, sellIn)
        {
        }

        public static AppreciateType CreateType(DataRow data)
        {
            return new AppreciateType(data.Name, data.Quality, data.SellIn);
        }

        public void Update()
        {
            UpdateProperties(-1);
        }
    }
}