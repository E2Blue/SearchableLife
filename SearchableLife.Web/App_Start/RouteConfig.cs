using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SearchableLife.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "admin",
                "admin/{action}/{slug}",
                new { controller = "Admin", action = "Index", slug = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{slug}",
                defaults: new { controller = "Content", action = "Content", slug = UrlParameter.Optional }
            );
        }
    }
}