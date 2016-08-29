using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTest.Models.Entity;
using Ninject;
using MvcTest.Repositories;
using MvcTest.Common.Infrastructure;
using MvcTest.Common.Helpers;
using MvcTest.Common.Enums;
using MvcTest.Common.Consts;
using MvcTest.Models.Views;

namespace MvcTest.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
            LogedRequirement = false;

        }


        //
        // GET: Home/Login
        public ActionResult Login()
        {
            return RouteTo(null, "Index", "Profile", true);
        }


        // Logout
        // Get: Home/Login
        public ActionResult Logout()
        {
            Update(null);
            return RouteTo();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            IKernel kernel = Factory.CreateKernel();
            IUserRepository userRepository = kernel.Get<IUserRepository>();
            var model = new Models.Views.UserViewModel();
            model.User = user;
            LoginManager.AccessError = false;

            if (!LoginManager.GetLoginDisableStatus())
            {
                LoginManager.AccessError = false;
                if (userRepository.VerifyAccount(user.Email, user.Password))
                {
                    user = userRepository.GetByEmail(user.Email);
                    userRepository.SignIn(user.Email, user.Password);

                    Update(user);
                    return RedirectToAction("Index", "Profile");
                }
                else if (LoginManager.LastLoginDisableStatus)
                {
                    LoginManager.LoginTries++;
                    LoginManager.AccessError = true;
                }
            }
            model.LoginTriesError = LoginManager.GetLoginDisableStatus();
            model.AccessError = LoginManager.GetAccessError();
            return View();

        }


        //
        // GET: Home/Register
        public ActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            return RouteTo(model, "Index", "Profile", true);
        }


        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            IKernel kernel = Factory.CreateKernel();
            IUserRepository userRepository = kernel.Get<IUserRepository>();
            if (ModelState.IsValid)
            {
                // If password or re-password is null then return with error message
                if (userViewModel.RePassword == null || userViewModel.User.Password == null)
                {
                    RegisterHelper.PasswordsInvalid = true;
                    return View();
                }

                // If password and re-password arent same then return with error message
                if (userViewModel.RePassword != userViewModel.User.Password)
                {
                    RegisterHelper.PasswordsInvalid = true;
                    return View();
                }
                User user = userViewModel.User;

                // If everything is correct, create an account
                if (userRepository.SignUp(user.Email))
                {
                    userRepository.SignUp(user);
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}