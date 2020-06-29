using System;
using TheGildedRose.Repositories.Interfaces;
using TheGildedRose.Repositories.SQLite;

namespace TheGildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI! & Welcome to the Gilded Rose!" + Environment.NewLine);
            Console.WriteLine("This was today's inventory change!" + Environment.NewLine);
            
            IItemRepository repository = new SqLiteRepository();
            var items = repository.GetItems();
            
            Transaction.UpdateQuality(ref items);
            //TODO database.Update() --> keep separate IO & pure logic
        }
    }
}