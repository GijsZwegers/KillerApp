using KillerApp.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KillerApp.DataLayer.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User VerifyUser(string username, string hashedPassword);
        bool Register(string username, string hashedPassword);
    }
}