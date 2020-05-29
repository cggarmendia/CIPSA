using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.Infrastructure.Context.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.UnitOfWorks.Exercise.Shop
{
    public class ShopUnitOfWork : UnitOfWorkBase, IShopUnitOfWork
    {
        #region Constructor

        public ShopUnitOfWork()
        {
            this.context = new ShopContext();
        }

        #endregion
    }
}
