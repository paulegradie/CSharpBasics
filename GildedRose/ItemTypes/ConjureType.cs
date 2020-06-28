using GildedRose.Data;

namespace GildedRose.ItemTypes
{
    public class ConjureType : BaseItemType, ICreatable<ConjureType>, IUpdateableItem
    {
        private ConjureType(string name, int quality, int sellIn) : base("Conjure", name, quality, sellIn)
        {
        }

        public void Update()
        {
            UpdateProperties(2);
        }

        public static ConjureType CreateType(DataRow data)
        {
            return new ConjureType(data.Name, data.Quality, data.SellIn);
        }
    }
}