using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public class Order
    {
        public string Kid { get; set; }
        public int Status { get; set; }
        public List<Toy> Toys { get; set; }
        public DateTime RequestDate { get; set; } //TODO requestDate is  in stringFormat
    }
}
