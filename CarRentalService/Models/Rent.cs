using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalService.Models
{
    public class Rent
    {
        public int CustomerID { get; set; }
        public int CarID { get; set; }
        public DateTime beginOfRenting { get; set; }
        public DateTime endOfRenting { get; set; }
        public bool done { get; set; }


        /*public override bool Equals(object obj)
        {
            if (!(obj is Rents))
            {
                return false;
            }
            Rents other = obj as Rents;
            return this.Id == other.Id;
        }*/
    }
}