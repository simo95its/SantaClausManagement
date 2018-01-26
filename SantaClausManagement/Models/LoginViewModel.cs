using SantaClausManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaClausManagement.Models
{
    public class LoginViewModel
    {
        public string ScreenName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public string Password { get; set; }

        /*
        public LoginViewModel(User user)
        {
            ScreenName = user.ScreenName;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
            Password = user.Password;
        }
        */
    }
}