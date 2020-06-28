using System;

namespace GildedRose.ItemTypes
{
    public class BaseItemType : Item
    {
        private string ItemType { get; }

        protected BaseItemType(string itemType, string name, int quality, int sellIn)
        {
            ItemType = itemType;
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        private void DecrementQualityBy(int value)
        {
            if (Quality >= (0 + value) && Quality <= (50 - Math.Abs(value)))
            {
                Quality -= (SellIn == 0) ? value * 2 : value;
            }
        }

        private void DecrementSellInBy(int value)
        {
            if (SellIn > (0 + value))
            {
                SellIn -= value;
            }
        }

        internal void UpdateProperties(int qualityChange, int sellInChange = 1)
        {
            DecrementQualityBy(qualityChange);
            DecrementSellInBy(sellInChange);
        }

        public override string ToString()
        {
            return $"Name: {Name}{Environment.NewLine}SellIn: {SellIn}{Environment.NewLine}Quality: {Quality}";
        }
    }
}