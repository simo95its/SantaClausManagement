using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaClausData.Models
{
    public class Toy
    {
        [BsonId]
        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("cost")]
        [BsonIgnoreIfNull]
        public double? Cost { get; set; }

        [BsonElement("amount")]
        [BsonIgnoreIfNull]
        public int? Amount { get; set; }
    }
}