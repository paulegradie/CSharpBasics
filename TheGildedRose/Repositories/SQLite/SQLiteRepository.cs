using System.Collections.Generic;
using System.Linq;
using TheGildedRose.ItemTypes.Interfaces;
using TheGildedRose.Repositories.Interfaces;

namespace TheGildedRose.Repositories.SQLite
{
    public class SqLiteRepository : IItemRepository
    {
        private static IDbConnector Database => SqLiteDbConnector.CreateDatabaseConnection();
        
        public List<IUpdateableItem> GetItems()
        {
            var items = Database.RetrieveData().ToList();
            return items;
        }

        public IUpdateableItem GetItem(string id)
        {
            var item = Database.RetrieveDataById(id);
            return item;
        }
    }
}