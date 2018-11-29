using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDatabase _applicationDatabase;

        public ImageRepository()
        {
            _applicationDatabase = new ApplicationDatabase();
        }

        public bool AddImage(Image image)
        {
            return _applicationDatabase.AddImage(image);
        }

        public List<Image> GetAllImages()
        {
            throw new System.NotImplementedException();
        }

        public Image GetImageById(int id)
        {
            return _applicationDatabase.GetImageById(id);
        }
        public bool RemoveImage(Image item)
        {
            return _applicationDatabase.RemoveItem(item);
        }
    }
}
