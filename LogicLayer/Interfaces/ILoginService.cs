using KillerApp.DataLayer.Models;
using Microsoft.AspNetCore.Http;

namespace KillerApp.LogicLayer.Interfaces
{
    public interface ILoginService
    {
        bool Login(HttpContext httpContext, string username, string password);
        bool Register(string username, string password, string passwordConfirm);
    }
}