﻿using System.Collections.Generic;

namespace DataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Image> Items { get; set; }
    }
}
