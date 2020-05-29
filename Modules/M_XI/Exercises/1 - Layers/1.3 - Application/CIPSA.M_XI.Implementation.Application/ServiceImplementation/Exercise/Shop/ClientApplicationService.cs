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
    public class ClientApplicationService : BaseApplicationService<Client, ClientDto>, IClientApplicationService
    {
        #region .: Properties :.

        private readonly IClientDomainService _clientDomainService;

        #endregion

        #region .: Constructor :.

        public ClientApplicationService(IClientDomainService clientDomainService)
        {
            _clientDomainService = clientDomainService;
        }

        #endregion

        #region .: Public Methods :.

        public void Add(ClientDto dto)
        {
            _clientDomainService.Add(MapFromDtoToEntity(dto, DtoToDomainEnum.Client));
            _clientDomainService.SaveChange();
        }

        public void Update(ClientDto dto)
        {
            _clientDomainService.Update(MapFromDtoToEntity(dto, DtoToDomainEnum.Client));
            _clientDomainService.SaveChange();
        }

        public ClientDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_clientDomainService.GetByPKs(dtoId), DomainToDtoEnum.Client);
        }

        public void Delete(int dtoId)
        {
            _clientDomainService.Delete(dtoId);
            _clientDomainService.SaveChange();
        }

        public IEnumerable<ClientDto> GetAll()
        {
            return MapFromEntitiesToDtos(_clientDomainService.GetAll(), DomainToDtoEnum.Client);
        }

        public ClientDto GetByNIF(string nif)
        {
            return MapFromEntityToDto(
                _clientDomainService.GetByFilters(
                    client => client.NIF.Equals(nif)
                    ).FirstOrDefault(),
                DomainToDtoEnum.Client);
        }

        public IEnumerable<string> GetClientsNIF()
        {
            return _clientDomainService.GetClientsNIF();
        }
        #endregion
    }
}
