using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using CIPSA.M_XI.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieApplicationService _movieApplicationService;

        public MovieController(IMovieApplicationService movieApplicationService)
        {
            _movieApplicationService = movieApplicationService;
        }

        public MovieController()
        {
        }

        [HttpGet]
        public MovieDto FindMovieById(int id)
        {
            return _movieApplicationService.GetByPKs(id);
        }

        [HttpGet]
        public MovieDto FindMovieByName(string name)
        {
            return _movieApplicationService.GetByName(name);
        }

        [HttpPost]
        public int AddMovie([FromBody]MovieDto dto)
        {
            _movieApplicationService.Add(dto);
            return _movieApplicationService.GetByName(dto.Name).Id;
        }

        [HttpPut]
        public void UpdateMovie([FromBody]MovieDto dto)
        {
            _movieApplicationService.Update(dto);
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            _movieApplicationService.Delete(id);
        }

        [HttpGet]
        public IEnumerable<RentedArticleModel> GetRentedArticle()
        {
            return Mapper.Map<IEnumerable<MovieDto>, IEnumerable<RentedArticleModel>>(_movieApplicationService.GetAll());
        }

        [HttpGet]
        public IEnumerable<RentedArticleModel> GetNonRentedArticle()
        {
            return Mapper.Map<IEnumerable<MovieDto>, IEnumerable<RentedArticleModel>>(_movieApplicationService.GetNonRentedMovies());
        }
    }
}