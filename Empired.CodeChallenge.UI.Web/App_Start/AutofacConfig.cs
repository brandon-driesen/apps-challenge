using System.Collections.Specialized;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Empired.CodeChallenge.Repositories;
using Empired.CodeChallenge.Repositories.Contexts;
using Empired.CodeChallenge.Repositories.Interfaces;
using Empired.CodeChallenge.UI.Interfaces;
using Empired.CodeChallenge.UI.Services;

namespace Empired.CodeChallenge.UI.Web
{
    public static class AutofacConfig
    {

        public static void Register(HttpConfiguration config)
        {
            var container = CreateContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.MapHttpAttributeRoutes();

        }
       

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(x => ConfigurationManager.AppSettings)
                .As<NameValueCollection>();

            builder.RegisterType<SettingsService>()
                .As<ISettingsService>()
                .SingleInstance();

            builder.RegisterType<AnimalService>()
                .As<IAnimalService>();

            builder.RegisterType<AnimalDbContext>()
                .As<IAnimalDbContext>()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(string),
                    (pi, ctx) => ctx.Resolve<ISettingsService>().ConnectionString))
                .InstancePerLifetimeScope()
                .ExternallyOwned();

            builder.RegisterType<AnimalRepository>()
                .As<IAnimalRepository>();

            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            return builder.Build();
        }

    }
}