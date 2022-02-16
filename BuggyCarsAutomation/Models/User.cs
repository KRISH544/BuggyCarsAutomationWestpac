using System;
using System.Collections.Generic;
using System.Text;

namespace BuggyCarsAutomation.Models
{
    public class User
    {
        public string Username { get; set;}
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string PasswordComfirmation { get; set; }
        public string NewPassword { get; set; }

    }
}
