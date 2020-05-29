using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop
{
    public interface IMovieApplicationService
    {
        IEnumerable<MovieDto> GetAll();

        IEnumerable<MovieDto> GetNonRentedMovies();

        MovieDto GetByPKs(params object[] keyValues);

        MovieDto GetByName(string name);

        void Add(MovieDto entity);

        void Update(MovieDto entity);

        void Delete(int dtoId);
    }
}
