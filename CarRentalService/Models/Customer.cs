using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public List<Car> Rented { get; set; }
        public string Notes { get; set; }

    }
}