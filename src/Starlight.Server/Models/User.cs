using System.Collections.Generic;

namespace Starlight.Server.Models
{
    public class User : AbstractModel
    {
        public string Username { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public List<Character> Characters { get; set; }
    }
}
