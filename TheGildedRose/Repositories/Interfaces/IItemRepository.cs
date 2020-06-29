using System.Collections.Generic;
using TheGildedRose.ItemTypes.Interfaces;

namespace TheGildedRose.Repositories.Interfaces
{
    public interface IItemRepository
    {
        List<IUpdateableItem> GetItems();
        IUpdateableItem GetItem(string id);
    }
}