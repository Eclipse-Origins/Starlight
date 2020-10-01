using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Starlight.Server.Security
{
    public class PasswordHasher
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public GeneratedPassword HashPassword(string password)
        {
            var salt = GenerateSalt();

            var passwordHash = HashPassword(password, salt);

            return new GeneratedPassword(
                salt: Convert.ToBase64String(salt),
                passwordHash: Convert.ToBase64String(passwordHash));
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);
        }

        public bool VerifyPassword(string actualPassword, string salt, string testPassword)
        {
            var saltBytes = Convert.FromBase64String(salt);

            var actualPasswordBytes = Convert.FromBase64String(actualPassword);
            var testPasswordBytes = HashPassword(testPassword, saltBytes);

            return CryptographicOperations.FixedTimeEquals(actualPasswordBytes, testPasswordBytes);
        }
    }
}
