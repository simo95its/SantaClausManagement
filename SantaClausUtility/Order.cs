using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
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
        public DateTime RequestDate { get; set; } //TODO requestDate is  in stringFormat
    }
}
