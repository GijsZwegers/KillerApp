using KillerApp.DataLayer.Identity;
using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using KillerApp.LogicLayer.Interfaces;

namespace KillerApp.LogicLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;

        public LoginService(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        public bool Login(HttpContext httpContext, string username, string password)
        {
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            User user = userRepository.VerifyUser(username, hashedpassword);

            if (!user.Equals(default))
            {
                httpContext.User = new ClaimsPrincipal(new ApplicationUser("Bcrypt", true, user));
                return true;
            }
            return false;
        }

        public bool Register(string username, string password, string passwordConfirm)
        {
            if (password == passwordConfirm && password != "")
            {
                string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password);
            }

            return false;
        }
    }
}
