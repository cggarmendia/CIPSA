using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameApplicationService _gameApplicationService;

        public GameController(IGameApplicationService gameApplicationService)
        {
            _gameApplicationService = gameApplicationService;
        }

        public GameController()
        {
        }

        [HttpGet]
        public GameDto FindGameById(int id)
        {
            return _gameApplicationService.GetByPKs(id);
        }

        [HttpGet]
        public GameDto FindGameByName(string name)
        {
            return _gameApplicationService.GetByName(name);
        }

        [HttpPost]
        public int AddGame([FromBody]GameDto dto)
        {
            _gameApplicationService.Add(dto);
            return _gameApplicationService.GetByName(dto.Name).Id;
        }
        
        [HttpPut]
        public void UpdateGame([FromBody]GameDto dto)
        {
            _gameApplicationService.Update(dto);
        }

        [HttpDelete]
        public void DeleteGame(int id)
        {
            _gameApplicationService.Delete(id);
        }

        [HttpGet]
        public IEnumerable<RentedArticleModel> GetRentedArticle()
        {
            return Mapper.Map<IEnumerable<GameDto>, IEnumerable<RentedArticleModel>>(_gameApplicationService.GetAll());
        }

        [HttpGet]
        public IEnumerable<RentedArticleModel> GetNonRentedArticle()
        {
            return Mapper.Map<IEnumerable<GameDto>, IEnumerable<RentedArticleModel>>(_gameApplicationService.GetNonRentedGames());
        }
    }
}