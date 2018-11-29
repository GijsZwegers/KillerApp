using KillerApp.DataLayer.Models;
using System.Collections.Generic;

namespace KillerApp.DataLayer.Interfaces
{
    public interface IImageRepository
    {
        Image GetImageById(int id);
        bool RemoveImage(Image image);
        List<Image> GetAllImages();
        bool AddImage(Image image);
    }
}
 