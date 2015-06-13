using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RapID.ClassLibrary
{
    public static class Crypt
    {
        #region DES
        private static class DES
        {
            public static string Decrypt(string pToDecrypt, string sKey)
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] buffer = new byte[pToDecrypt.Length / 2];
                for (int i = 0; i < (pToDecrypt.Length / 2); i++)
                {
                    int num2 = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num2;
                }

                provider.Key = Encodes.UTF8NoBOM.GetBytes(sKey);
                provider.IV = Encodes.UTF8NoBOM.GetBytes(sKey);

                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                new StringBuilder();
                return Encodes.UTF8NoBOM.GetString(stream.ToArray());
            }

            public static string Encrypt(string pToEncrypt, string sKey)
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encodes.UTF8NoBOM.GetBytes(pToEncrypt);
                provider.Key = Encodes.UTF8NoBOM.GetBytes(sKey);
                provider.IV = Encodes.UTF8NoBOM.GetBytes(sKey);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                StringBuilder builder = new StringBuilder();
                foreach (byte num in stream.ToArray())
                {
                    builder.AppendFormat("{0:X2}", num);
                }

                return builder.ToString();
            }
        }
        #endregion
        public static string Encrypt(string source, string key = "RapIDK01")
        {
            return DES.Encrypt(source, key);
        }
        public static string Decrypt(string ciphertext, string key = "RapIDK01")
        {
            return DES.Decrypt(ciphertext, key);
        }
        /*
         * Based on Rap-ID Encryption Key Generation Specification v1.0-draft3
         */
        public static string GenerateKey(string originalKey)
        {
            var result = originalKey;
            result = GetMD5Hash(originalKey);
            var epoch = Math.Floor((double)(GetEpoch() / 60));
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Epoch: " + epoch);
#endif
            result += GetMD5Hash(GetMD5Hash(Convert.ToString(epoch)));
            result = GetMD5Hash(result).Substring(0, 8);
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Generated key: " + result);
#endif
            return result;
        }
        public static string GeneratePairKey()
        {
            const string originalKey = "CF166A138A5B6AD5";
            return GenerateKey(originalKey);
        }
        /*
         * (C)2010 @wonsoft from CSDN
         * Original Post: http://blog.csdn.net/wonsoft/article/details/5913572
         */
        public static string GetMD5Hash(string original)
        {
            byte[] result = Encodes.UTF8NoBOM.GetBytes(original);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        /*
         * (C) pocketdigi.com
         * Original Post: http://www.pocketdigi.com/20120306/696.html
         */
        public static long GetEpoch()
        {
            DateTime Epoch = new DateTime(1970, 1, 1);
            return (long)(DateTime.UtcNow - Epoch).TotalSeconds;
        }
    }
}
