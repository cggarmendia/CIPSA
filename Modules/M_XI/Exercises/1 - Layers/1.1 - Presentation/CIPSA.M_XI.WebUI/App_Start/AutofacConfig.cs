using Autofac;
using Autofac.Integration.Mvc;
using CIPSA.M_XI.DomainService.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.DomainService.AutofacModule.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Shop;
using CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Agenda;
using CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Shop;
using System.Web.Mvc;

namespace CIPSA.M_XI.WebUI.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our modules
            builder.RegisterModule(new AgendaInfrastructureModule());
            builder.RegisterModule(new AgendaApplicationModule());
            builder.RegisterModule(new AgendaDomainServiceModule());
            builder.RegisterModule(new ShopInfrastructureModule());
            builder.RegisterModule(new ShopApplicationModule());
            builder.RegisterModule(new ShopDomainServiceModule());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}