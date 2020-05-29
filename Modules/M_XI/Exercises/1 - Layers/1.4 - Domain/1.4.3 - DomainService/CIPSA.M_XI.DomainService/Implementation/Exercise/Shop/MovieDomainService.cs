using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.DomainService.Implementation.Exercise.Shop
{
    public class MovieDomainService : DomainServiceBase<Movie>, IMovieDomainService
    {
        public MovieDomainService(IShopUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Movie> GetNonRentedMovies()
        {
            var rentals = _unitOfWork.GetRepository<Rental>().AsQueryable();
            return AsQueryable().Where(movie => !rentals.Any(rental => rental.ArticleId.Equals(movie.Id)));
        }
    }
}