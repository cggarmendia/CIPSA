using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.DomainService.Contract.Exercise.Shop
{
    public interface IGameDomainService : IDomainServiceBase<Game>
    {
        IEnumerable<Game> GetNonRentedGames();
    }
}