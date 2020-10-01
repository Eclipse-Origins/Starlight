namespace Starlight.Server.Security
{
    public class GeneratedPassword
    {
        public string Salt { get; set; }
        public string PasswordHash { get; set; }

        public GeneratedPassword(string salt, string passwordHash)
        {
            this.Salt = salt;
            this.PasswordHash = passwordHash;
        }
    }
}
