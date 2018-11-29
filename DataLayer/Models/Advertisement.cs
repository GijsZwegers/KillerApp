using System;
using System.Collections.Generic;

namespace KillerApp.DataLayer.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public List<Image> Image { get; set; }
        public DateTime Insertdate { get; set; }
        public DateTime Changedate { get; set; }
        //public User User { get; set; }
        public Double Price { get; set; }
        public bool BiddingEnabled { get; set; }
        public double BiddingFrom { get; set; }

    }
}
