using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ProgramTests
    {

        [Test]
        [TestCase("+5 Dexterity Vest", 0, 0, 0, 0)]
        [TestCase("+5 Dexterity Vest", 0, 20, 0, 18)]
        [TestCase("+5 Dexterity Vest", 10, 20, 9, 19)]
        [TestCase("Aged Brie", 5, 50, 4, 50)]
        [TestCase("Aged Brie", 2, 0, 1, 1)]
        [TestCase("Elixir of the Mongoose", 5, 7, 4, 6)]
        [TestCase("Elixir of the Mongoose", 0, 2, 0, 0)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [TestCase("Sulfuras, Hand of Ragnaros", 1, 80, 1, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 20, 0, 0)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [TestCase("Conjured Mana Cake", 3, 6, 2, 4)]
        public void TestUpdate(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var newItem = new Item {Name = name, SellIn = sellIn, Quality = quality};
            var items = new List<Item>() {newItem};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            item.Name.Should().Be(name);
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
    }
}