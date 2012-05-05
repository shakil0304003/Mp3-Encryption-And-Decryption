using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MediaPlayer
{
    public static class EncryptionHelper
    {
        private const string cryptoKey = "cryptoKey";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public static byte[] Decrypt(byte[] buffer)
        {
            byte[] result;

            try
            {
                
                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length);
            }
            catch
            {
                throw;
            }

            return result;
        }
    }

}
