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
            
            Console.WriteLine("BEFORE UPDATE");
            showItems(app.Items);
            app.UpdateQuality();
            Console.WriteLine("AFTER UPDATE");
            showItems(app.Items);
            Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var t in Items)
            {
                if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (t.Quality >= 0)
                    {
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            if (t.Quality > 0)
                            {
                                if (t.Name != "Conjured Mana Cake")
                                {
                                    t.Quality -= 1;
                                }
                                else
                                {
                                    t.Quality = ( t.Quality > 2 ) ? (t.Quality - 2) : 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;

                        if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (t.SellIn < 11)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality += 1;
                                }
                            }

                            if (t.SellIn < 6)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (t.Name != "Sulfuras, Hand of Ragnaros")
                {
                    if (t.SellIn > 0)
                    {
                        t.SellIn -= 1;
                    }
                }

                if (t.SellIn > 0) continue;
                if (t.Name != "Aged Brie")
                {
                    if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (t.Quality <= 0) continue;
                        if (t.Name == "Sulfuras, Hand of Ragnaros") continue;
                        if (t.Quality > 0)
                        {
                            t.Quality -= 1;
                        }
                    }
                    else
                    {
                        t.Quality = 0;

                    }
                }
                else
                {
                    if (t.Quality >= 50) continue;
                    if (t.Quality >= 0)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }
    }
}