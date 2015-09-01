using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnS.Functions
{
    class RSA
    {
        private static string privateKey;
        private static string publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();

        public static void generateRSAKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            privateKey = rsa.ToXmlString(true);
            publicKey = rsa.ToXmlString(false);
            GlobalVariables.user.public_key = publicKey;
        }

        public static string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public static string Encrypt(string data, string key)
        {
            byte[] keyBytes = System.Convert.FromBase64String(key);
            key = Encoding.UTF8.GetString(keyBytes);
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(key);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }

        public static string getPublicKey(){
            //var aux = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey));
            //byte[] keyBytes = System.Convert.FromBase64String(aux);
            //var axu2 = Encoding.UTF8.GetString(keyBytes);
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey));
        }

        public static string getPrivateKey()
        {
            return System.Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKey));
        }

        public static void setPrivateKey(string key)
        {
            byte[] keyBytes = System.Convert.FromBase64String(key);
            key = Encoding.UTF8.GetString(keyBytes);
            privateKey = key;
        }

    }
}
