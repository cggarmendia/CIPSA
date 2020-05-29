using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;

namespace CIPSA.M_XI.DomainService.Implementation.Exercise.Shop
{
    public class ArticleDomainService : DomainServiceBase<Article>, IArticleDomainService
    {
        public ArticleDomainService(IShopUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}