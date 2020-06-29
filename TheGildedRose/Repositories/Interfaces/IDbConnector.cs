using System.Collections.Generic;
using TheGildedRose.ItemTypes.Interfaces;

namespace TheGildedRose.Repositories.Interfaces
{
    public interface IDbConnector
    {
        public IEnumerable<IUpdateableItem> RetrieveData();
        public IUpdateableItem RetrieveDataById(string id);
    }
}