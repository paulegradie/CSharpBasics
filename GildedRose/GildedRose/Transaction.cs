using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Transaction
    {
        private static void DecrementQualityBy(Item item, int value)
        {
            if (item.Quality >= (0 + value) && item.Quality <= (50 - Math.Abs(value)))
            {
                item.Quality -= (item.SellIn == 0) ? value * 2 : value;
            }
        }

        private static void DecrementSellInBy(Item item, int value)
        {
            if (item.SellIn > (0 + value))
            {
                item.SellIn -= value;
            }
        }

        private static void UpdateProperties(Item item, int qualityChange, int sellInChange = 1)
        {
            DecrementQualityBy(item, qualityChange);
            DecrementSellInBy(item, sellInChange);
        }

        private static void UpdateBackstagePass(Item item)
        {
            int value;
            if (item.SellIn < 6)
            {
                value = -3;
            }
            else if (item.SellIn < 11)
            {
                value = -2;
            }
            else
            {
                value = -1;
            }

            UpdateProperties(item, value);
            item.Quality = item.SellIn == 0 ? 0 : item.Quality;
        }

  
        public static void UpdateQuality(ref List<Item> items)
        {
            foreach (var item in items)
            {
                switch (item.Name)
                {
                    case ("Sulfuras, Hand of Ragnaros"):
                        // updateSulfuras();
                        break;
                    case ("Backstage passes to a TAFKAL80ETC concert"):
                        UpdateBackstagePass(item);
                        break;
                    case ("+5 Dexterity Vest"):
                        UpdateProperties(item, 1);
                        break;
                    case ("Elixir of the Mongoose"):
                        UpdateProperties(item, 1);
                        break;
                    case ("Aged Brie"):
                        UpdateProperties(item, -1);
                        break;
                    case ("Conjured Mana Cake"):
                        UpdateProperties(item, 2);
                        break;
                }
            }
        }
    }
}