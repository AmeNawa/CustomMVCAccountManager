using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTest.Common.Secure
{
    public interface ICrypt 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        string Encrypt(string toEncrypt);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        string Decrypt(string toDecrypt);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toCompare"></param>
        /// <param name="encryptedValue"></param>
        /// <returns></returns>
        bool VerfifyCrypted(string toCompare, string encryptedValue);
    }
}
