using System;
using System.Security.Cryptography;
using System.Text;

namespace Interation.Utility
{
    public class MD5Encryptor
    {
        public static string Encrypt(string plaintext)
        {
            var cryptoServiceProvider = new MD5CryptoServiceProvider();
            var bytes = cryptoServiceProvider.ComputeHash(UTF8Encoding.Default.GetBytes(plaintext));
            var ciphertext = BitConverter.ToString(bytes).Replace("-", "");

            return ciphertext;
        }
    }
}
