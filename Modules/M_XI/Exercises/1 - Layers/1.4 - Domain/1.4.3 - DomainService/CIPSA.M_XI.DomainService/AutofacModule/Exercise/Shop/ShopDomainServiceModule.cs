using Autofac;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using CIPSA.M_XI.DomainService.Implementation.Exercise.Shop;

namespace CIPSA.M_XI.DomainService.AutofacModule.Exercise.Shop
{
    public class ShopDomainServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: DomainService :.
            builder.RegisterType<RentalDomainService>().As<IRentalDomainService>().InstancePerRequest();
            builder.RegisterType<ArticleDomainService>().As<IArticleDomainService>().InstancePerRequest();
            builder.RegisterType<MovieDomainService>().As<IMovieDomainService>().InstancePerRequest();
            builder.RegisterType<GameDomainService>().As<IGameDomainService>().InstancePerRequest();
            builder.RegisterType<ClientDomainService>().As<IClientDomainService>().InstancePerRequest();
            builder.RegisterType<ArticleDomainService>().As<IArticleDomainService>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}
