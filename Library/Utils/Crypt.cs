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

        public const string key = "MKY%x!T%";
        public static string Encrypt(string source)
        {
            return DES.Encrypt(source, key);
        }
        public static string Decrypt(string ciphertext)
        {
            return DES.Decrypt(ciphertext, key);
        }
    }
}
