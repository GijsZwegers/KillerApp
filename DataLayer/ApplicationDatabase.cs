using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    /// <summary>
    /// Horen eigenlijk queries te zijn naar een database. (dit is als voorbeeld even)
    /// </summary>
    internal class ApplicationDatabase
    {
        private const string connectionString = "sdsjda";
        private List<Image> Items { get; set; }

        internal ApplicationDatabase()
        {
            Items = new List<Image>
            {
                new Image { Id = 1, Name = "Tandenborstel", Price = 5.99 },
                new Image { Id = 2, Name = "Tandpasta", Price = 2.99 },
                new Image { Id = 3, Name = "Tandenborstelhouder", Price = 15.99 }
            };
        }

        //select * from db.items; idk
        internal List<Image> GetAllItems()
        {
            return Items;
        }
        internal Image GetItemById(int id)
        {
            return Items.Single(item => item.Id.Equals(id));
        }
        internal bool AddItem(Image item)
        {
            if(Items.Any(itemInItems => itemInItems.Id.Equals(item.Id)))
            {
                return false;
            }
            Items.Add(item);
            return true;
        }
        internal bool RemoveItem(Image item)
        {
            if (Items.Any(itemInItems => itemInItems.Equals(item)))
            {
                return Items.Remove(item);
            }
            return false;
        }
    }
}
