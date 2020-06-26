using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var data = DbConnector.CreateDatabaseConnection("Items.sqlite");
            var items = data.RetrieveData();
            Transaction.UpdateQuality(items: ref items);
            showItems(items);
        }
        
        static void showItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}