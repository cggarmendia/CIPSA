using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.DomainService.Contract.Exercise.Shop
{
    public interface IMovieDomainService : IDomainServiceBase<Movie>
    {
        IEnumerable<Movie> GetNonRentedMovies();
    }
}