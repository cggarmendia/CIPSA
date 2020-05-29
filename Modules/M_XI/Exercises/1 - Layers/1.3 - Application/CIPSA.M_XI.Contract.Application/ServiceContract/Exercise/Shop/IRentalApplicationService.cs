using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop
{
    public interface IRentalApplicationService
    {
        IEnumerable<RentalDto> GetAll();

        IEnumerable<PendingRentalDto> GetByClientId(int clientId);

        IEnumerable<LateRentalDto> GetLateRentals(int lateDays);

        RentalDataDto GetByArticleId(int articleId);

        RentalDto GetByPKs(params object[] keyValues);

        void Add(RentalDto entity);

        void Update(RentalDto entity);

        void Delete(params object[] dtoId);

        void DeleteByArticleId(int articleId);

        bool IsPossibleToRent(int articleId, int clientId);

        int RentedTime(int articleId);
    }
}
