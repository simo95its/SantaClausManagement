using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SantaClausManagement.Util
{
    public class User
    {
        public string Id { get; set; }
        
        public string ScreenName { get; set; }
        
        public string Email { get; set; }
        
        public bool IsAdmin { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordClearText { get; set; }
    }
}