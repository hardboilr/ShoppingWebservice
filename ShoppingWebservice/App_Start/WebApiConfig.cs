using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ShoppingWebservice.ErrorHandling;

namespace ShoppingWebservice {
    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ShoppingApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // global exception handler
            config.Services.Replace(typeof(IExceptionHandler), new ServerExceptionHandler());

            config.Filters.Add(new SqlExceptionFilterAttribute());

            // avoid stackoverflow exceptions on entities with loop refs
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // camelcase json responses
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // remove support for XML responses
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // ignore null values 
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
