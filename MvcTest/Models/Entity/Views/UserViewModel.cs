using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTest.Models.Entity;

namespace MvcTest.Models.Views
{
    public class UserViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String RePassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AccessError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LoginTriesError { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public UserViewModel()
        {
            AccessError = false;
            LoginTriesError = false;
        }
    }
}