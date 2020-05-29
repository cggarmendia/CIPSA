using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.Controllers
{
    [RoutePrefix("api/rental")]
    public class RentalController : ApiController
    {
        private readonly IRentalApplicationService _rentalApplicationService;

        public RentalController(IRentalApplicationService RentalApplicationService)
        {
            _rentalApplicationService = RentalApplicationService;
        }

        public RentalController()
        {
        }

        [HttpGet]
        [Route("article/{articleId}/client/{clientId}")]
        public RentalDto FindRentalByIds(int articleId, int clientId)
        {
            return _rentalApplicationService.GetByPKs(articleId, clientId);
        }

        [HttpGet]
        [Route("client/{clientId}")]
        public IEnumerable<PendingRentalDto> FindRentalByClientId(int clientId)
        {
            return _rentalApplicationService.GetByClientId(clientId);
        }

        [HttpGet]
        [Route("article/{article}")]
        public RentalDataDto FindRentalByArticleId(int articleId)
        {
            return _rentalApplicationService.GetByArticleId(articleId);
        }

        [HttpGet]
        [Route("article/{articleId}/rentedTime")]
        public int RentedTime(int articleId)
        {
            return _rentalApplicationService.RentedTime(articleId);
        }

        [HttpGet]
        [Route("isPossibleToRent/article/{articleId}/client/{clientId}")]
        public bool IsPossibleToRent(int articleId, int clientId)
        {
            return _rentalApplicationService.IsPossibleToRent(articleId, clientId);
        }

        [HttpPost]
        public void AddRental([FromBody]RentalDto dto)
        {
            dto.Date = DateTime.Now;
            _rentalApplicationService.Add(dto);
        }

        [HttpPut]
        public void UpdateRental([FromBody]RentalDto dto)
        {
            _rentalApplicationService.Update(dto);
        }

        [HttpDelete]
        public void DeleteByArticle(int articleId)
        {
            _rentalApplicationService.DeleteByArticleId(articleId);
        }
    }
}