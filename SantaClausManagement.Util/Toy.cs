using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausManagement.Util
{
    public class Toy
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double? Cost { get; set; }

        public int? Amount { get; set; }
    }
}