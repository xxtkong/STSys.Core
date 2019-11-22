using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common.Utility
{
    public class Cryptographer
    {
        public static string CreateSalt()
        {
            byte[] array = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(array);
            return Convert.ToBase64String(array);
        }

        public static string EncodePassword(string pass, int passwordFormat, string salt)
        {
            return EncodePassword(pass, salt);
        }

        private static string EncodePassword(string pass, string salt)
        {
            pass = salt + pass;
            byte[] bytes = Encoding.Default.GetBytes(pass);
            byte[] inArray = null;
            inArray = HashAlgorithm.Create("SHA256").ComputeHash(bytes);
            return ToHexString(inArray);
        }
        public static string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
    }
}
