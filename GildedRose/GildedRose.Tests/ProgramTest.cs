using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 20, 0, 18)]
        [TestCase(10, 20, 9, 19)]
        public void TestDexterityVest(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var dexterityItem = new Item {Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality};
            var items = new List<Item>() {dexterityItem};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("+5 Dexterity Vest");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Test]
        [TestCase(5, 50, 4, 50)]
        [TestCase(2, 0, 1, 1)]
        public void TestAgedBrie(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var agedBrieItem = new Item {Name = "Aged Brie", SellIn = sellIn, Quality = quality};

            var items = new List<Item>() {agedBrieItem};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("Aged Brie");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Test]
        [TestCase(5, 7, 4, 6)]
        [TestCase(0, 2, 0, 0)]
        public void TestMongooseElixir(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var mongooseElixir = new Item {Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality};

            var items = new List<Item>() {mongooseElixir};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("Elixir of the Mongoose");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Test]
        [TestCase(0, 80, 0, 80)]
        [TestCase(1, 80, 1, 80)]
        public void TestSulfurasOfRagnoros(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var SulfurasOfRagnoros = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality};

            var items = new List<Item>() {SulfurasOfRagnoros};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("Sulfuras, Hand of Ragnaros");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
        
        [Test]
        [TestCase(0, 20, 0, 0)]
        [TestCase(5, 20, 4, 23)]
        [TestCase(10, 20, 9, 22)]
        [TestCase(15, 20, 14, 21)]
        public void TestBackstagePass(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var backstagePassItem = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality};

            var items = new List<Item>() {backstagePassItem};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("Backstage passes to a TAFKAL80ETC concert");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
         
        [Test]
        [TestCase(3, 6, 2, 4)]
        public void TestConjuredManaCake(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var backstagePassItem = new Item {Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality};

            var items = new List<Item>() {backstagePassItem};
            var program = new Program()
            {
                Items = items
            };

            // Act
            program.UpdateQuality();
            
            // Assert
            var item = program.Items[0];
            program.Items.Count.Should().Be(1);
            item.Name.Should().Be("Conjured Mana Cake");
            item.SellIn.Should().Be(expectedSellIn);
            item.Quality.Should().Be(expectedQuality);
        }
        
    }
}