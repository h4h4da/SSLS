using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSLS.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new { controller = "Book", action = "List", categoryId = 0, page = 1 });

            routes.MapRoute(null, "page{page}", new { controller = "Book", action = "List", categoryId = 0 }, new { page = @"\d+" });

            routes.MapRoute(null, "cid{categoryId}", new { controller = "Book", action = "List", page = 1 }, new { categoryId = @"\d+" });

            routes.MapRoute(null, "cid{categoryId}/page{page}", new { controller = "Book", action = "List" }, new { categoryId = @"\d+", page = @"\d+" });
            routes.MapRoute(
               name: null,
               url: "page{page}",
               defaults: new { controller = "Book", action = "List" }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
