using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TheGildedRose;
using TheGildedRose.ItemTypes.Interfaces;
using TheGildedRose.ItemTypes.Types;
using TheGildedRose.Repositories.SQLite;

namespace Tests
{
    public class ProgramTests
    {
        [Test]
        [TestCase("Depreciate", "+5 Dexterity Vest", 0, 0, 0, 0)]
        [TestCase("Depreciate", "+5 Dexterity Vest", 0, 20, 0, 18)]
        [TestCase("Depreciate", "+5 Dexterity Vest", 10, 20, 9, 19)]
        [TestCase("Appreciate", "Aged Brie", 5, 50, 4, 50)]
        [TestCase("Appreciate", "Aged Brie", 2, 0, 1, 1)]
        [TestCase("Depreciate", "Elixir of the Mongoose", 5, 7, 4, 6)]
        [TestCase("Depreciate", "Elixir of the Mongoose", 0, 2, 0, 0)]
        [TestCase("Legendary", "Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [TestCase("Legendary", "Sulfuras, Hand of Ragnaros", 1, 80, 1, 80)]
        [TestCase("Concert", "Backstage passes to a TAFKAL80ETC concert", 0, 20, 0, 0)]
        [TestCase("Concert", "Backstage passes to a TAFKAL80ETC concert", 5, 20, 4, 23)]
        [TestCase("Concert", "Backstage passes to a TAFKAL80ETC concert", 10, 20, 9, 22)]
        [TestCase("Concert", "Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [TestCase("Conjure", "Conjured Mana Cake", 3, 6, 2, 4)]
        public void TestUpdate(string dataType, string name, int sellIn, int quality, int expectedSellIn,
            int expectedQuality)
        {
            // Arrange
            var newItem = TypeFactory.BindType(new DataRow()
                {DataType = dataType, Name = name, Quality = quality, SellIn = sellIn});
            var items = new List<IUpdateableItem>() {newItem};

            // Act
            Transaction.UpdateQuality(ref items);

            // Assert
            var item = items.Last();

            item.Name.Should().Be(name);
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
    }
}