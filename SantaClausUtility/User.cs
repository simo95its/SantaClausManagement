using System;

namespace SantaClausUtility
{
    public class User
    {
        public string ScreenName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public string PasswordClearText { get; set; }
    }
}
