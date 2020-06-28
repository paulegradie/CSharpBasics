# Introduction

Welcome to my implementation of the Gilded Rose Kata refactor in C#!

This project is a quaint refactor challenge that seems to have no limit to how far you can take it.

The idea is simple - you maintain software for a magic shop called 'The Gilded Rose' and your job is to refactor the code - without modifying the Item class! - into something that works well, is potentially extendable, is definitely maintainable, and is hopefully easier to comprehend than the original.

### What the challenge is
 - A challenge intended to help you get better at refactoring in C#
 - A starting point you can use to explore various design patterns
 - A tool to help familiarize yourself with the C# language
 - A tool to help you understand the importance of unit testing
 - A tool to help you appreciate separation of concerns
 - A tool to help you understand the value of programming against interfaces (instead of concrete implementations)

### What the challenge is NOT
 - A bulk rewrite project

The whole point of this challenge is to teach you how to write meaningful tests that you can run frequently as you *incrementally* refactor the code. You can see my incremental approach on this project by reviewing my commit history in repo (which unfortunately is blended with other basics projects -- but fortunately was the first thing I did. See below for tips on how to review the commit range.) The last thing you want to do when refactoring is to tear down the world and try to rebuild it, because unless you are very skilled and very knowledgable about the code you are working in/with, you are prone to writing yourself into a hole that is very difficult to code your way out of without resorting to `git reset --hard orign/blah`.

The approach is thus:

1. Write a comprehensive set of unit tests to capture the behavior the given code (it is legacy, but it is assumed to be working correctly). You can use any testing framework, and any approach. I've decided to use basic NUnit, however you can use approval testing or anything else.

2. Do NOT, at any point, modify the Item class. This is forbodden. *However*, you may inherit from that class or use that class in your refactor.

3. Make incremental changes to the code to clean it up and make it more readable. You can take any approach you'd like. (I've decided to migrate our data to an sqlite database and update the database accordingly.)

4. Run the tests often during the refactor. In other words, make a small change that keeps the code working, and then run the tests to ensure you haven't missed anything.

5. Keep going until you've stretched the refactor to its extendible limit and try to use interesting patterns that reflect best practices in C# for organization, maintainability, and design.


### TODO
 - Create a new project to provide a Blazor React Portal to allow new items to be provided (Complete with login)
 - (And/Or) Create an API for users to use an API key to send updates to a running server.


# Original Starting Code
This is the original starting code taken from [The original Gilded Rose Kata Repo](https://github.com/NotMyself/GildedRose/blob/master/src/GildedRose.Console/Program.cs)
This repo provided a set of important rules for item type behavior that should be modeled in the program correctly. For posterity (and in case the original repo changes...) I've simply copied those rules here as well.

```
Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:

All items have a SellIn value which denotes the number of days we have to sell the item
All items have a Quality value which denotes how valuable the item is
At the end of each day our system lowers both values for every item
Pretty simple, right? Well this is where it gets interesting:

Once the sell by date has passed, Quality degrades twice as fast
The Quality of an item is never negative
"Aged Brie" actually increases in Quality the older it gets
The Quality of an item is never more than 50
"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
"Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
We have recently signed a supplier of conjured items. This requires an update to our system:

"Conjured" items degrade in Quality twice as fast as normal items
Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly. However, do not alter the Item class or Items property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
```

```
using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

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

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

```


## How to review the log of this project

The current commit range (from latest to oldest) you can use:

                        (newest commit)                                     (oldest commit)
    git log --oneline 1b57660fc2318f01732fb30d21d8e996fe1940c7 ^b1f54f7c777c2999ac6889f855916759a311a164
