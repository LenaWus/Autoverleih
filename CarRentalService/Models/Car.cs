using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalService.Models
{
    public class Car
    {
        public int id { get; set; }
        public string make { get; set; }
        public string name { get; set; }
        public decimal pricePerHour { get; set; }
        public string colour { get; set; }
    }
}