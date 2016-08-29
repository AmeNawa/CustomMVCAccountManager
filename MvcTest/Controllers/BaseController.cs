using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models.Entity;
using MvcTest.Models;
using MvcTest.Common.Enums;

namespace MvcTest.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Current user
        /// </summary>
        public static Authorization Authorization { get; set; }

        /// <summary>
        /// Does current controller requires being logged, not used yet
        /// </summary>
        public bool LogedRequirement { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public BaseController()
        {
            LogedRequirement = true;

            if (Authorization == null)
            try
            {
                Authorization = Session["Authorization"] as Authorization;
            }
            catch
            {
                Authorization = new Authorization();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void Update(User user)
        {
            Authorization.SetUser(user);
        }


        /// <summary>
        /// Depends on login status required and login status, method
        /// re-directs or stays on current controller
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Action"></param>
        /// <param name="Controller"></param>
        /// <param name="reqLogin"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ActionResult RouteTo(object model, string Action, string Controller, bool reqLogin)
        {
            bool status = false;
            if (Authorization.LoginStatus != (int)ELoginStatus.NO_LOGGED)
                status = true;

            if (reqLogin && status)
            {
                return RedirectToAction(Action, Controller);
            }

            if (reqLogin && !status)
            {
                return View();
            }

            if(!reqLogin && status)
            {
                return View();
            }

            if(!reqLogin && !status)
            {
                return RedirectToAction(Action, Controller);
            }

            return View(model);
        }


        /// <summary>
        /// If user is not logged then method returns him to Home
        /// </summary>
        /// <returns></returns>
        public ActionResult RouteTo(object model = null)
        {
            bool status = false;
            if (Authorization.LoginStatus != (int)ELoginStatus.NO_LOGGED)
                status = true;

            if (!status)
                return RedirectToAction("Login", "Home");
            return View(model);
        }
    }
}