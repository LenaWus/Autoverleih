using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalService.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string title { get; set; }
        public int age { get; set; }
        public List<Car> rented { get; set; }
        public string notes { get; set; }

    }
}