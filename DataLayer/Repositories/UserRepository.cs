using DataLayer;
using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDatabase applicationDatabase;

        public UserRepository()
        {
            this.applicationDatabase = new ApplicationDatabase();
        }

        public List<User> GetUsers()
        {
            var reader = applicationDatabase.ExecuteProcedure("readUsers");
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User
                {
                    id = (int)reader["id"],
                    Name = (string)reader["Name"]
                });
            }

            return users;
        }

        public User VerifyUser(string username, string hashedPassword)
        {
            
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                { "username", username },
                { "passwordhash", hashedPassword }
            };
            var reader = applicationDatabase.ExecuteProcedureWithValues("VerifyUser", pairs);
            reader.Read();
            if (reader.HasRows)
            {
                return new User
                {
                    id = (int)reader["Id"],
                    Name = (string)reader["UserName"],
                    Password = (string)reader["HashesPassword"]
                };
            }
            return default;
        }

        public bool Register(string username, string hashedPassword)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                { "username", username }
            };
            var reader = applicationDatabase.ExecuteProcedureWithValues("CheckUserNameExists", pairs);
            reader.Read();
            if (reader.HasRows)
            {
                return false;
            }

            return true;
        }
    }
}
