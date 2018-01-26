using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausManagement.Util
{
    public class Order
    {
        public string Id { get; set; }
        
        public string Kid { get; set; }
        
        public Status Status { get; set; }
        
        public List<Toy> Toys { get; set; }
        
        public DateTime RequestDate { get; set; }
    }
}
