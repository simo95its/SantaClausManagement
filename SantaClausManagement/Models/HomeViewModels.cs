using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SantaClausUtility;

namespace SantaClausManagement.Models
{
    public class HomeIndexViewModel
    {
        public List<Toy> Toys { get; set; }
        public List<Order> Orders { get; set; }
    }
}