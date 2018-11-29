using DataLayer;
using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using System.Collections.Generic;

namespace KillerApp.DataLayer.Repositories
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
            throw new System.NotImplementedException();
        }

        public bool RemoveImage(Image image)
        {
            throw new System.NotImplementedException();
        }

        //public bool AddImage(Image image)
        //{
        //    return _applicationDatabase.AddImage(image);
        //}

        //public List<Image> GetAllImages()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Image GetImageById(int id)
        //{
        //    return _applicationDatabase.GetImageById(id);
        //}
        //public bool RemoveImage(Image image)
        //{
        //    return _applicationDatabase.RemoveItem(image);
        //}

        //List<Image> IImageRepository.GetAllImages()
        //{
        //    throw new System.NotImplementedException();
        //}

        //Image IImageRepository.GetImageById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
