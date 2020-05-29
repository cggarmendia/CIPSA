using Autofac;
using Autofac.Integration.WebApi;
using CIPSA.M_XI.DomainService.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.DomainService.AutofacModule.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Shop;
using CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Shop;
using System.Reflection;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            //// Register our modules
            builder.RegisterModule(new AgendaInfrastructureModule());
            builder.RegisterModule(new AgendaApplicationModule());
            builder.RegisterModule(new AgendaDomainServiceModule());
            builder.RegisterModule(new ShopInfrastructureModule());
            builder.RegisterModule(new ShopApplicationModule());
            builder.RegisterModule(new ShopDomainServiceModule());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}