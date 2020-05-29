using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.DomainService.Implementation.Exercise.Shop
{
    public class GameDomainService : DomainServiceBase<Game>, IGameDomainService
    {
        public GameDomainService(IShopUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Game> GetNonRentedGames()
        {
            var rentals = _unitOfWork.GetRepository<Rental>().AsQueryable();
            return AsQueryable().Where(game => !rentals.Any(rental => rental.ArticleId.Equals(game.Id)));
        }
    }
}