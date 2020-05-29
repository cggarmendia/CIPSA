using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop
{
    public interface IGameApplicationService
    {
        IEnumerable<GameDto> GetAll();

        GameDto GetByPKs(params object[] keyValues);

        IEnumerable<GameDto> GetNonRentedGames();

        GameDto GetByName(string name);

        void Add(GameDto entity);

        void Update(GameDto entity);

        void Delete(int dtoId);
    }
}
