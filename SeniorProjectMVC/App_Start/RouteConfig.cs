using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeniorProjectMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "product/{id}"
            );

            routes.MapRoute(
                name: "EditProduct",
                url:"Admin/Product/{action}",
                defaults: new { controller = "Products", action = "Index"}
            );

            routes.MapRoute(
                name:"ProductPages",
                url:"Product/{*productid}",
                defaults: new {controller = "Products", action = "GetProduct"}
            );

            routes.MapRoute(
                name:"OrderRoute",
                url:"Orders/{action}/",
                defaults: new { controller= "Order", action="Index"}
                );
        }
    }
}
