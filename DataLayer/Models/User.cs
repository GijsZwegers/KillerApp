using System.Collections.Generic;

namespace DataLayer.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Advertisement> Advertisements { get; set; }
    }
}