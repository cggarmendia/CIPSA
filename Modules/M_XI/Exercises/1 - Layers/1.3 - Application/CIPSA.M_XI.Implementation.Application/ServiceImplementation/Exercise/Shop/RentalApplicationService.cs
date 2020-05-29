using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Shop
{
    public class RentalApplicationService : BaseApplicationService<Rental, RentalDto>, IRentalApplicationService
    {
        #region .: Properties :.

        private readonly IRentalDomainService _rentalDomainService;
        private readonly IArticleDomainService _articleDomainService;
        private readonly IClientDomainService _clientDomainService;

        #endregion

        #region .: Constructor :.

        public RentalApplicationService(IRentalDomainService rentalDomainService,
            IArticleDomainService articleDomainService,
            IClientDomainService clientDomainService)
        {
            _rentalDomainService = rentalDomainService;
            _articleDomainService = articleDomainService;
            _clientDomainService = clientDomainService;
        }

        #endregion

        #region .: Public Methods :.

        public void Add(RentalDto dto)
        {
            _rentalDomainService.Add(MapFromDtoToEntity(dto, DtoToDomainEnum.Rental));
            _rentalDomainService.SaveChange();
        }

        public void Update(RentalDto dto)
        {
            _rentalDomainService.Update(MapFromDtoToEntity(dto, DtoToDomainEnum.Rental));
            _rentalDomainService.SaveChange();
        }

        public RentalDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_rentalDomainService.GetByPKs(dtoId), DomainToDtoEnum.Rental);
        }

        public void Delete(params object[] dtoId)
        {
            _rentalDomainService.Delete(dtoId);
            _rentalDomainService.SaveChange();
        }

        public void DeleteByArticleId(int articleId)
        {
            var rentalByArticle = _rentalDomainService
                                    .GetByFilters(rental=>rental.ArticleId.Equals(articleId))
                                    .FirstOrDefault();
            _rentalDomainService.Delete(rentalByArticle.ArticleId, rentalByArticle.ClientId);
            _rentalDomainService.SaveChange();
        }

        public IEnumerable<RentalDto> GetAll()
        {
            return MapFromEntitiesToDtos(_rentalDomainService.GetAll(), DomainToDtoEnum.Rental);
        }

        public IEnumerable<PendingRentalDto> GetByClientId(int clientId)
        {
            return MapFromEntitiesToDtos<PendingRentalDto>(_rentalDomainService.GetByFilters( rental => rental.ClientId.Equals(clientId)), DomainToDtoEnum.PendingRental);
        }

        public RentalDataDto GetByArticleId(int articleId)
        {
            return MapFromEntityToDto<RentalDataDto>(_rentalDomainService.GetByFilters(rental => rental.ArticleId.Equals(articleId)).FirstOrDefault(), DomainToDtoEnum.RentalData);
        }

        public bool IsPossibleToRent(int articleId, int clientId)
        {
            var isPossibleToRent = true;
            var article = _articleDomainService.GetByPKs(articleId);
            if (article.IsAdult)
                isPossibleToRent = _clientDomainService.IsAdult(clientId);
            return isPossibleToRent;
        }

        public int RentedTime(int articleId)
        {
            var rentalByArticleId = _rentalDomainService
                                .GetByFilters(rental => rental.ArticleId.Equals(articleId));
            var rentalDate = rentalByArticleId?.FirstOrDefault()?.Date;
            return rentalDate != null 
                ? (int)(DateTime.Now - rentalDate.Value).TotalDays
                : 0;
        }

        public IEnumerable<LateRentalDto> GetLateRentals(int lateDays)
        {
            var dateNowWithLateDays = DateTime.Now.AddDays(lateDays);
            return MapFromEntitiesToDtos<LateRentalDto>(
                _rentalDomainService.GetByFilters(rental => rental.Date < dateNowWithLateDays), DomainToDtoEnum.LateRental);
        }
        #endregion
    }
}
