using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Jacaranda.Data;
using Jacaranda.Api.Infrastructure.Filters;
using System.Web.Compilation;

namespace Jacaranda.Api
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
        }

        public static void Configure(HttpConfiguration config)
        {
            // Remove xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            #region Autofac configuration

            // Load referenced assemblies
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            var builder = new ContainerBuilder();
            // Register api controllers in current assemblies
            builder.RegisterApiControllers(assemblies.ToArray());
            // Register autofac api filter providers
            builder.RegisterWebApiFilterProvider(config);
            // Register all services to its associated interface
            builder.RegisterAssemblyTypes(assemblies.ToArray())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerRequest();
            // Register db context
            builder.RegisterType<JacarandaDbContext>().AsSelf();
            // Register exception filter to the root controller
            builder.Register(c => new ExceptionLogger(c.Resolve<IErrorLoggerService>()))
                   .AsWebApiExceptionFilterFor<ApiController>()
                   .InstancePerRequest();
            // Build the container
            var container = builder.Build();
            // Replace the default denpendency resolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            #endregion
        }
    }
}
