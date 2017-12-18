using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClausUtility
{
    public class Toy
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("cost")]
        [BsonIgnoreIfNull]
        public double? Cost { get; set; } //One of the data in db is an int

        [BsonElement("amount")]
        [BsonIgnoreIfNull]
        public int? Amount { get; set; }
    }
}
