using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Functions
{
    class AES
    {
        public static string key = "qgtfhkbghe75yth38gik39go2h6onm42";
        public static string IV = "qsefthukolijygrd";

        public static string encrypt(string text)
        {
            byte[] plaintext= System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plaintext, 0, plaintext.Length);

            crypto.Dispose();

            return Convert.ToBase64String(encrypted);
        }

        public static string decrypt(string text)
        {
            byte[] encryptedtext = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;

            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] decrypted = crypto.TransformFinalBlock(encryptedtext, 0, encryptedtext.Length);
            crypto.Dispose();

            return System.Text.ASCIIEncoding.ASCII.GetString(decrypted);
        }
    }
}
