using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RxOutlet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{objectId}",
                defaults: new { controller = "ContactUS", action = "ContactUS", objectId = RouteParameter.Optional }
            );

           // routes.MapRoute(
           //    name: "Default2",
           //    url: "{controller}/{action}/{objectId}",
           //    defaults: new { controller = "Account", action = "Login", objectId = RouteParameter.Optional }
           //);


           // routes.MapRoute(
           //     name: "Default1",
           //     url: "{controller}/{action}/{objectId}/user/{userid}",
           //     defaults: new { controller = "Home", action = "MenuItemList", objectId = RouteParameter.Optional , userid= RouteParameter.Optional }
           // );


        }
    }
}
