using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RxOutlet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi1",
                routeTemplate: "api/{controller}/{action}/{objectid}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "DefaultApi2",
              routeTemplate: "api/{controller}/{action}/{objectid}/{userid}",
              defaults: new { id = RouteParameter.Optional }
          );

        }
    }
}
