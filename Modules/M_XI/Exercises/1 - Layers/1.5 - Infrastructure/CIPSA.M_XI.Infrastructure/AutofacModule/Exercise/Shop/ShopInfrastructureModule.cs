using Autofac;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.Infrastructure.UnitOfWorks.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Shop
{
    public class ShopInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: UnitOfWork :.
            builder.RegisterType<ShopUnitOfWork>().As<IShopUnitOfWork>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}
