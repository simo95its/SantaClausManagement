﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SantaClausUtility
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("screenname")]
        public string ScreenName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("password_clear_text")]
        public string PasswordClearText { get; set; }
    }
}
