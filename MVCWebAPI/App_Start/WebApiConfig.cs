using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVCWebAPI
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // remove xml response and get Json response formate - by default xml formate data
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
