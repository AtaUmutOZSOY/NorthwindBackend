using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Core.Utilities.Security.Hashing
{
    public static class CryptographyHelpers
    {
        public static byte[] GenerateHashSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }

        public static byte[] GetSaltedHash(this string password, byte[] salt, KeyDerivationPrf keyDerivation)
        {
            return KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: keyDerivation,
            iterationCount: 100000,
            numBytesRequested: 256 / 8);
        }
    }
}
