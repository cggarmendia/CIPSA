using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Shop
{
    public class MovieApplicationService : BaseApplicationService<Movie, MovieDto>, IMovieApplicationService
    {
        #region .: Properties :.

        private readonly IMovieDomainService _movieDomainService;

        #endregion

        #region .: Constructor :.

        public MovieApplicationService(IMovieDomainService MovieDomainService)
        {
            _movieDomainService = MovieDomainService;
        }

        #endregion

        #region .: Public Methods :.
        public void Add(MovieDto dto)
        {
            _movieDomainService.Add(MapFromDtoToEntity(dto, DtoToDomainEnum.Movie));
            _movieDomainService.SaveChange();
        }

        public void Update(MovieDto dto)
        {
            _movieDomainService.Update(MapFromDtoToEntity(dto, DtoToDomainEnum.Movie));
            _movieDomainService.SaveChange();
        }

        public MovieDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_movieDomainService.GetByPKs(dtoId), DomainToDtoEnum.Movie);
        }

        public void Delete(int dtoId)
        {
            _movieDomainService.Delete(dtoId);
            _movieDomainService.SaveChange();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return MapFromEntitiesToDtos(_movieDomainService.GetAll(), DomainToDtoEnum.Movie);
        }

        public MovieDto GetByName(string name)
        {
            return MapFromEntityToDto(
                _movieDomainService.GetByFilters(
                    movie => movie.Name.ToLower().Equals(name.ToLower())
                    ).ToList().FirstOrDefault(),
                DomainToDtoEnum.Movie);
        }

        public IEnumerable<MovieDto> GetNonRentedMovies()
        {
            return MapFromEntitiesToDtos(_movieDomainService.GetNonRentedMovies(), DomainToDtoEnum.Movie);
        }
        #endregion
    }
}
