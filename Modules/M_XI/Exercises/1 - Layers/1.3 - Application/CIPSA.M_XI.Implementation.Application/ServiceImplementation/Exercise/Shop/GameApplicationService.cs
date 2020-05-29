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
    public class GameApplicationService : BaseApplicationService<Game, GameDto>, IGameApplicationService
    {
        #region .: Properties :.

        private readonly IGameDomainService _gameDomainService;

        #endregion

        #region .: Constructor :.

        public GameApplicationService(IGameDomainService gameDomainService)
        {
            _gameDomainService = gameDomainService;
        }

        #endregion

        #region .: Public Methods :.

        public void Add(GameDto dto)
        {
            _gameDomainService.Add(MapFromDtoToEntity(dto, DtoToDomainEnum.Game));
            _gameDomainService.SaveChange();
        }

        public void Update(GameDto dto)
        {
            _gameDomainService.Update(MapFromDtoToEntity(dto, DtoToDomainEnum.Game));
            _gameDomainService.SaveChange();
        }

        public GameDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_gameDomainService.GetByPKs(dtoId), DomainToDtoEnum.Game);
        }

        public void Delete(int dtoId)
        {
            _gameDomainService.Delete(dtoId);
            _gameDomainService.SaveChange();
        }

        public IEnumerable<GameDto> GetAll()
        {
            return MapFromEntitiesToDtos(_gameDomainService.GetAll(), DomainToDtoEnum.Game);
        }

        public GameDto GetByName(string name)
        {
            return MapFromEntityToDto(
                _gameDomainService.GetByFilters(
                    movie => movie.Name.ToLower().Equals(name.ToLower())
                    ).ToList().FirstOrDefault(),
                DomainToDtoEnum.Game);
        }

        public IEnumerable<GameDto> GetNonRentedGames()
        {
            return MapFromEntitiesToDtos(_gameDomainService.GetNonRentedGames(), DomainToDtoEnum.Game);
        }

        #endregion
    }
}
