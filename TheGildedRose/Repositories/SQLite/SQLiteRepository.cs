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
            return Database.RetrieveData().ToList();
        }

        public IUpdateableItem GetItem(string id)
        {
            return Database.RetrieveDataById(id);

        }
    }
}