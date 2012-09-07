using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Interation.Utility
{
    public class DESEncryptor
    {
        private DESEncryptor() { }
        private DESEncryptor(string encryptKey) { this.encryptKey = encryptKey; }

        private string encryptKey = "25a3s35e";
        private byte[] rgbIV = { 100, 110, 120, 130, 100, 110, 120, 130 };

        public string Encrypt(string plaintext)
        {
            using (var memoryStream = new MemoryStream())
            {
                var rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                var cryptoServiceProvider = new DESCryptoServiceProvider();
                var byteArray = Encoding.UTF8.GetBytes(plaintext);
                var cryptoTransform = cryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV);

                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(byteArray, 0, byteArray.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public string Decrypt(string ciphertext)
        {
            using (var memoryStream = new MemoryStream())
            {
                var rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                var cryptoServiceProvider = new DESCryptoServiceProvider();
                var byteArray = Convert.FromBase64String(ciphertext);
                var cryptoTransform = cryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV);

                using (var CryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    CryptoStream.Write(byteArray, 0, byteArray.Length);
                    CryptoStream.FlushFinalBlock();
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
        }

        public static DESEncryptor Instance(string encryptKey)
        {
            return new DESEncryptor(encryptKey);
        }
    }
}
