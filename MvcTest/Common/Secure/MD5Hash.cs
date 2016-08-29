using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MvcTest.Common.Secure
{
    public class MD5Hash : ICrypt
    {
        /// <summary>
        /// Cannot be decrypted
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public string Decrypt(string toDecrypt)
        {
            throw new Exception("No decrypt method for this crypt");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public string Encrypt(string toEncrypt)
        {   
            try
            {

                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(toEncrypt));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("X2"));
                }

                return sBuilder.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }


        /// <summary>
        /// Create new hash and compare it to existing
        /// </summary>
        /// <param name="value1">string do shaszowania</param>
        /// <param name="encryptedValue">hash</param>
        /// <returns></returns>
        public bool VerfifyCrypted(string toCompare, string encryptedValue)
        {
            string newHash = Encrypt(toCompare);
            newHash.CompareTo(encryptedValue);

            return !Convert.ToBoolean(newHash.CompareTo(encryptedValue));
        }

    }
}