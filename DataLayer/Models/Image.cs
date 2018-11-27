using System;

namespace DataLayer.Models
{
    /// <summary>
    /// For later use 
    /// </summary>
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime EditDate { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentType { get; set; }

    }
}