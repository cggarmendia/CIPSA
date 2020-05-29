using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop
{
    public interface IClientApplicationService
    {
        IEnumerable<ClientDto> GetAll();

        ClientDto GetByPKs(params object[] keyValues);

        ClientDto GetByNIF(string nif);

        void Add(ClientDto entity);

        void Update(ClientDto entity);

        void Delete(int dtoId);

        IEnumerable<string> GetClientsNIF();
    }
}
