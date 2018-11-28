using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IItemRepository
    {
        Image GetItemById(int id);
        bool RemoveItem(Image item);
        List<Image> GetAllItems();
        bool AddItem(Image item);
    }
}
 