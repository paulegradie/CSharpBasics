using System.Collections.Generic;
using System.Linq;
using ItemRepository.Interface;
using ItemTypes.Interface;

namespace ItemRepository.SQLite
{
    public class SQLiteRepository : IItemRepository
    {
        public List<IUpdateableItem> GetItems()
        {
            var database = SqLiteDbConnector.CreateDatabaseConnection();
            var items = database.RetrieveData().ToList();
            return items;
        }

        public IUpdateableItem GetItem(string id)
        {
            var database = SqLiteDbConnector.CreateDatabaseConnection();
            var item = database.RetrieveDataById(id);
            return item;
        }
    }
}