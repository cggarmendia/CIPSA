using Autofac;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Shop;

namespace CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Shop
{
    public class ShopApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: ApplicationService :.
            builder.RegisterType<ClientApplicationService>().As<IClientApplicationService>().InstancePerRequest();
            builder.RegisterType<GameApplicationService>().As<IGameApplicationService>().InstancePerRequest();
            builder.RegisterType<MovieApplicationService>().As<IMovieApplicationService>().InstancePerRequest();
            builder.RegisterType<RentalApplicationService>().As<IRentalApplicationService>().InstancePerRequest();
            builder.RegisterType<ArticleApplicationService>().As<IArticleApplicationService>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}
