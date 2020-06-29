using TheGildedRose.ItemTypes.Interfaces;
using TheGildedRose.Repositories.SQLite;

namespace TheGildedRose.ItemTypes.Types
{
    public class ConcertType : BaseItemType, ICreatable<ConcertType>, IUpdateableItem
    {
        private ConcertType(string name, int quality, int sellIn) : base("Concert", name, quality, sellIn)
        {
        }

        public static ConcertType CreateType(DataRow data)
        {
            return new ConcertType(data.Name, data.Quality, data.SellIn);
        }

        public void Update()
        {
            int value;
            if (SellIn < 6)
            {
                value = -3;
            }
            else if (SellIn < 11)
            {
                value = -2;
            }
            else
            {
                value = -1;
            }

            UpdateProperties(value);
            Quality = SellIn == 0 ? 0 : Quality;
        }
    }
}