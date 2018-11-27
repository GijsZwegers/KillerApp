using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Advertention
    {
        public int Id { get; set; }
        public List<Image> Image { get; set; }
        public DateTime Insertdate { get; set; }
        public DateTime Changedate { get; set; }
        public User User { get; set; }

    }
}
