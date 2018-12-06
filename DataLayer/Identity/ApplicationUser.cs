using KillerApp.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace KillerApp.DataLayer.Identity
{
    public class ApplicationUser : IIdentity
    {
        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name => User.Name;

        public User User { get; set; }

        public ApplicationUser(string type, bool isAuthenticated, User user)
        {
            AuthenticationType = type;
            IsAuthenticated = isAuthenticated;
            User = user;
        }
    }
}
