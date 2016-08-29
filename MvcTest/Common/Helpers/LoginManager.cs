using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Common.Consts;

namespace MvcTest.Common.Helpers
{
    public static class LoginManager
    {
        /// <summary>
        /// Try to login counter
        /// </summary>
        private static int _LoginTries;
        public static int LoginTries
        {
            get
            {
                return _LoginTries;
            }
            set
            {
                _LoginTries = value;
            }
        }

        /// <summary>
        /// False if login or password is invalid
        /// </summary>
        public static bool AccessError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool LoginDisableStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static bool LastLoginDisableStatus { get; set; }

        /// <summary>
        /// Returns whenever user can login or not
        /// </summary>
        /// <returns></returns>
        public static void LoginDisable()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("ppp");
            if (LoginTries >= AppConst.MAX_TRY_LOGIN_NUMBER)
            {
                if (cookie == null || cookie.Value != "True")
                {
                    cookie = new HttpCookie("ppp");
                    cookie.Expires = DateTime.Now.AddMinutes(AppConst.LOGIN_FAILURE_TIME);
                    cookie.Value = "True";
                    HttpContext.Current.Response.Cookies.Set(cookie);
                    _LoginTries = 0;
                    LastLoginDisableStatus = true;
                }

                AccessError = false;
                LoginDisableStatus = true;
            }

            else if (cookie == null)
                LoginDisableStatus = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool GetAccessError()
        {
            try
            {
                return AccessError;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool GetLoginDisableStatus()
        {
            try
            {
                LoginDisable();
                return LoginDisableStatus;
            }
            catch
            {
                return false;
            }
        }
    }
}