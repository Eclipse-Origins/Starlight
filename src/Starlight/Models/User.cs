using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class User : CoreDataModel
    {
        public string Username { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public List<Character> Characters { get; set; }
    }
}
