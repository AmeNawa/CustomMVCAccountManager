using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MvcTest.Common.Consts
{
    public static class AppConst
    {
        /// <summary>
        /// 
        /// </summary>
        public const int MIN_PASSWORD_LENGTH = 5;

        /// <summary>
        /// 
        /// </summary>
        public const int MAX_TRY_LOGIN_NUMBER = 3;


        /// <summary>
        /// 
        /// </summary>
        public const int LOGIN_FAILURE_TIME = 1;

        /// <summary>
        /// 
        /// </summary>
        public const String FILES_STORE_LOCATION = @"E:\Projects\CustomAccountSystem";
    }
}