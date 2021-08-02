using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMobileWeb.Models
{
    public class Car
    {
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public long Mileage { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public Status Status { get; set; }
        public string CarStatus { get; set; }
        public string CarColor { get; set; }

    }
    public enum Color
    {
        None = 0,
        Siver = 1,
        Gray = 2,
        Red = 3,
        Blue = 4,
        Black = 5
    }
    public enum Status
    {
        Active = 1,
        InActive = 2
    }
}
