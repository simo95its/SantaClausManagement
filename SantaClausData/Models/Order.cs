using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SantaClausData.Models
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("kid")]
        public string Kid { get; set; }

        [BsonElement("status")]
        public int Status { get; set; }

        [BsonElement("toys")]
        public List<Toy> Toys { get; set; }

        [BsonElement("requestDate")]
        public DateTime RequestDate { get; set; }
    }
}