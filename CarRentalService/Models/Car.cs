using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalService.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public string Colour { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Car))
            {
                return false;
            }
            Car other = obj as Car;
            return this.Id == other.Id;
        }
    }
}