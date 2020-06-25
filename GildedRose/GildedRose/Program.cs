using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            static void showItems(IEnumerable<Item> items)
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            showItems(app.Items);

        }

        static void decrementQualityBy(Item item, int value = 1)
        {
            if (item.Quality >= (0 + value))
            {
                item.Quality -= (item.SellIn == 0) ? value * 2 : value;
            }
        }

        static void incrementQualityBy(Item item, int value = 1)
        {
            if (item.Quality <= (50 - value))
            {
                item.Quality += value;
            }
        }

        void DecrementSellInBy(Item item, int value = 1)
        {
            if (item.SellIn > (0 + value))
            {
                item.SellIn -= value;
            }
        }

        void updateSulfuras()
        {
        }

        void UpdateDexterityVest(Item item)
        {
            decrementQualityBy(item, 1);
            DecrementSellInBy(item, 1);
        }

        void UpdateManaCake(Item item)
        {
            decrementQualityBy(item, 2);
            DecrementSellInBy(item, 1);
        }

        void UpdateBackstagePass(Item item)
        {
            int value;
            if (item.SellIn < 6)
            {
                value = 3;
            }
            else if (item.SellIn < 11)
            {
                value = 2;
            }
            else
            {
                value = 1;
            }

            incrementQualityBy(item, value);
            DecrementSellInBy(item, 1);
            item.Quality = item.SellIn == 0 ? 0 : item.Quality;
        }

        void UpdateElixir(Item item)
        {
            decrementQualityBy(item, 1);
            DecrementSellInBy(item, 1);
        }

        void UpdateBrie(Item item)
        {
            incrementQualityBy(item, 1);
            DecrementSellInBy(item, 1);
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case ("Sulfuras, Hand of Ragnaros"):
                        updateSulfuras();
                        break;
                    case ("Backstage passes to a TAFKAL80ETC concert"):
                        UpdateBackstagePass(item);
                        break;
                    case ("+5 Dexterity Vest"):
                        UpdateDexterityVest(item);
                        break;
                    case ("Elixir of the Mongoose"):
                        UpdateElixir(item);
                        break;
                    case ("Aged Brie"):
                        UpdateBrie(item);
                        break;
                    case ("Conjured Mana Cake"):
                        UpdateManaCake(item);
                        break;
                }
            }
        }
    }
}