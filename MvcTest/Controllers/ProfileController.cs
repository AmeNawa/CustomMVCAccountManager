using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class ProfileController : BaseController
    {
        public ProfileController()
        {
            LogedRequirement = true;
        }


        //
        // GET: Profile/Index
        public ActionResult Index()
        {
            return RouteTo();
        }


    }
}