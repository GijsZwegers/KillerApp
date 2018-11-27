using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDatabase _applicationDatabase;

        public ItemRepository()
        {
            _applicationDatabase = new ApplicationDatabase();
        }

        public bool AddItem(Image item)
        {
            return _applicationDatabase.AddItem(item);
        }

        public List<Image> GetAllItems()
        {
           return _applicationDatabase.GetAllItems();
        }

        public Image GetItemById(int id)
        {
            return _applicationDatabase.GetItemById(id);
        }

        public bool RemoveItem(Image item)
        {
            return _applicationDatabase.RemoveItem(item);
        }
    }
}
