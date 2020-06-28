using System.Collections.Generic;
using ItemTypes.Interface;

namespace ItemRepository.Interface
{
    public interface IDbConnector
    {
        public IEnumerable<IUpdateableItem> RetrieveData();
        public IUpdateableItem RetrieveDataById(string id);
    }
}