using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Uploads",
                "Uploads/{action}",
                 new { controller = "Uploads", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "About",
                "About/{action}",
                 new { controller = "About", action = "Info", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                "Profile",
                "Profile/{action}",
                 new { controller = "Profile", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
