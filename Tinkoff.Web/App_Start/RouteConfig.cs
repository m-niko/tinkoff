using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tinkoff.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "ClickShortedUrl", url: "{shortedUrl}",
                defaults: new {controller = "Home", action = "ClickShortedUrl"});

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
