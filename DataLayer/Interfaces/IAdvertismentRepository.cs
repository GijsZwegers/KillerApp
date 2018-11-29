using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IAdvertismentRepository
    {
        Advertisement GetAdvertisementById(int id);
        List<Advertisement> GetAdvertisements();
        bool RemoveAdvertisment(Advertisement advertisement);
        bool AddAdvertisment(Advertisement advertisement);
        bool AddImageToAdvertisment(int id, Image image);
        bool RemoveImageFromAdvertisement(int id, int idImage);

    }

}
