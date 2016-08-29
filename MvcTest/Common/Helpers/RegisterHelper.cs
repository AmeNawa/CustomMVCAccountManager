using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Common.Helpers
{
    public static class RegisterHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static bool PasswordsInvalid { get; set; }

        /// <summary>
        /// Returns PasswordsInvalid and set it to false
        /// </summary>
        /// <returns></returns>
        public static bool GetPasswordsInvalid()
        {
            var temp = PasswordsInvalid;
            PasswordsInvalid = false;
            return temp;
        }

    }
}