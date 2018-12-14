using DataLayer;
using KillerApp.DataLayer.Interfaces;
using KillerApp.DataLayer.Models;
using MySql.Data.MySqlClient;
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

        public User VerifyUser(string username, string password)
        {
            
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                { "userName", username }
            };
            User user = applicationDatabase.ExecuteProcedureWithValues("VerifyUser", pairs, GetUser);

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
        private User GetUser(MySqlDataReader reader)
        {
            
            if (reader.HasRows)
            {
                return new User
                {
                    id = (int)reader["Id"],
                    Name = (string)reader["UserName"],
                    Password = (string)reader["HashedPassword"]
                };
            }
            return default;
        }
        public bool Register(string username, string hashedPassword)
        {
            Dictionary<string, object> pairs = new Dictionary<string, object>
            {
                { "name", username }    
            };
            if (applicationDatabase.ExecuteProcedureWithValues("CheckUserName", pairs, CheckBool))
            {
                return false;
            }
            var success = applicationDatabase.ExecuteProcedureWithValues("RegisterUser", pairs, CheckBool);

            return true;
        }

        private bool CheckBool(MySqlDataReader reader)
        {
            if (reader.HasRows)
            {
                var test = reader["bool"];
                if (Convert.ToBoolean(reader["bool"]) == true)
                {
                    return true;
                }
                else if (Convert.ToBoolean(reader["bool"]) == false)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
