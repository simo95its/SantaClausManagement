using SantaClausManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaClausManagement.Models
{
    public class ModalViewModel
    {
        public string Kid { get; set; }
        public Status Status { get; set; }
        public List<Toy> Toys {get; set; }
        public DateTime RequestDate { get; set; }

        public ModalViewModel(Order order)
        {
            Kid = order.Kid;
            Status = order.Status;
            Toys = order.Toys;
            RequestDate = order.RequestDate;
        }
    }
}