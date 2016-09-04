using RFramework.Filter;
using RFramework.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RCMS.Center.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.RemoveXmlFormatter();
            config.EnableCors();

          //  config.Filters.Add(new AuthTokenAttribute());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                 name: "ServiceApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
