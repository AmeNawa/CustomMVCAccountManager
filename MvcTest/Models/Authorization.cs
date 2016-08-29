using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Common.Enums;
using MvcTest.Models.Entity;

namespace MvcTest.Models
{
    /// <summary>
    /// Ustanawia poziom uprawnień klienta
    /// </summary>
    public class Authorization
    {
        /// <summary>
        /// Current user
        /// </summary>
        public int LoginStatus { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public User User { get; private set; }


        /// <summary>
        /// If 0 then client is not logged
        /// </summary>
        /// <param name="status"></param>
        public void SetLoginStatus(ELoginStatus status)
        {
            this.LoginStatus = (int)status;
        }


        /// <summary>
        /// Set user to current session
        /// </summary>
        /// <param name="user"></param>
        public void SetUser(User user)
        {
            this.User = user;
            if(this.User != null)
                this.SetLoginStatus(ELoginStatus.USER);
            else
                this.SetLoginStatus(ELoginStatus.NO_LOGGED);
        }


        /// <summary>
        /// 
        /// </summary>
        public Authorization()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        public Authorization(ELoginStatus status)
        {
            SetLoginStatus(status);
        }
    }
}