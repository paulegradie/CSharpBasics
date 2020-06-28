using System.Collections.Generic;
using ItemTypes.Interface;

namespace ItemRepository.Interface
{
    public interface IItemRepository
    {
        List<IUpdateableItem> GetItems();
        IUpdateableItem GetItem(string id);
    }
}