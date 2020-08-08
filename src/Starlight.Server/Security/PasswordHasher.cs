using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Starlight.Server.Security
{
    public class PasswordHasher
    {
        public byte[] GenerateSalt() {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public GeneratedPassword HashPassword(string password) {
            var salt = GenerateSalt();

            var passwordHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8);

            return new GeneratedPassword(
                salt: Convert.ToBase64String(salt),
                passwordHash: Convert.ToBase64String(passwordHash));
        }
    }
}
