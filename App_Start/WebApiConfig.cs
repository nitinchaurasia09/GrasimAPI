using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GrasimAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "User",
               routeTemplate: "api/User/{UserId}",
               defaults: new { controller = "User" });

            config.Routes.MapHttpRoute(
               name: "UserLogin",
               routeTemplate: "api/User/{UserName}/{Password}",
               defaults: new { controller = "User" });

            config.Routes.MapHttpRoute(
               name: "Search",
               routeTemplate: "api/Search/SearchTailor/{TailorName}",
               defaults: new { controller = "Search", action = "SearchTailor" });

            config.Routes.MapHttpRoute(
               name: "SearchFeature",
               routeTemplate: "api/Search/SearchTailor/{Feature}/{Category}",
               defaults: new { controller = "Search", action = "SearchTailor" });

                        
            config.Routes.MapHttpRoute(
               name: "Utility",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
