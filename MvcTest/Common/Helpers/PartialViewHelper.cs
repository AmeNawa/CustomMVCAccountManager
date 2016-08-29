using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Controllers;
using MvcTest.Models;
using MvcTest.Common.Enums;

namespace MvcTest.Common
{
    public class PartialViewHelper
    {

        /// <summary>
        /// Return logged info string
        /// </summary>
        /// <returns></returns>
        public static String LoggedAs()
        {
            string fullName = String.Empty;
            string loggedAs = String.Empty;

            if (isLogged())
            {
                fullName = BaseController.Authorization.User.GetFullName();
                loggedAs = String.Format("You're logged as : {0} ({1})", fullName, BaseController.Authorization.User.Email);
                return loggedAs;
            }
            else
            {
                loggedAs = "You're not logged";
                return loggedAs;
            }
        }

        /// <summary>
        /// If client is logged, return true
        /// </summary>
        /// <returns></returns>
        public static Boolean isLogged()
        {
            try
            {
                if (BaseController.Authorization.LoginStatus != (int)ELoginStatus.NO_LOGGED)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}