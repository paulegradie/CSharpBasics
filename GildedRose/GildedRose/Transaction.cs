using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.ItemTypes;

namespace GildedRose
{
    public static class Transaction
    {
        /// <summary>
        /// Method to update item values
        /// </summary>
        /// <param name="items">
        /// A reference parameter containing a List of Items. Ref since this method will update the object in place.
        /// b/c pass through mutation is gross - better to treat this method like a sea urchin (they eat, then throw up)</param>
        public static void UpdateQuality(ref List<IUpdateableItem> items)
        {
            foreach (var item in items)
            {
                var previousData = DataChange.Record(item);
                item.Update();
                var newData = DataChange.Record(item);
                PrintChange(previousData, newData);
            }
        }

        private static void PrintChange(DataChange previousData, DataChange newData)
        {
            Console.WriteLine(Environment.NewLine + $"Item Name: {previousData.Name}");
            for (int i = 0; i < previousData.Properties.Count(); i++)
            {
                var previous = previousData.Properties[i];
                var current = newData.Properties[i];
                var key = previous.Keys.Last();

                Console.WriteLine($"{key,10}: {previous[key],-2} => {current[key],-2}");
            }
        }

        internal class DataChange
        {
            private DataChange(List<Dictionary<string, object>> propVals, string name)
            {
                Properties = propVals;
                Name = name;
            }

            public string Name { get; set; }
            public List<Dictionary<string, object>> Properties { get; private set; }

            public static DataChange Record(IUpdateableItem item)
            {
                var props = item.GetType().GetProperties();

                var propVals = new List<Dictionary<string, object>>();
                foreach (var prop in props)
                {
                    var newDict = new Dictionary<string, object>();
                    var property = typeof(Item).GetProperty(prop.Name)?.GetValue(item, null);
                    if (prop.Name == "Name") continue;

                    newDict.Add(prop.Name, property);
                    propVals.Add(newDict);
                }

                var name = (string) typeof(Item).GetProperty("Name")?.GetValue(item, null);
                return new DataChange(propVals, name);
            }
        }
    }
}