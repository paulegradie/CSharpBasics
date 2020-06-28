using System;
using ItemRepository.Interface;
using ItemRepository.SQLite;

namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI! & Welcome to the Gilded Rose!" + Environment.NewLine);
            Console.WriteLine("This was today's inventory change!" + Environment.NewLine);

            // var database = DbConnector.CreateDatabaseConnection("Items.sqlite");
            // var items = database.RetrieveData();

            IItemRepository repository = new SQLiteRepository();
            var items = repository.GetItems();
            
            Transaction.UpdateQuality(ref items);
            //TODO database.Update() --> keep separate IO & pure logic
        }
    }
}