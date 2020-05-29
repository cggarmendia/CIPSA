using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.WebAPI.Models;

namespace CIPSA.M_XI.WebAPI.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MovieDto, RentedArticleModel>()
                   .ForMember(model => model.ArticleId,
                              opt => opt.MapFrom(dto => dto.Id))
                   .ForMember(model => model.ArticleName,
                              opt => opt.MapFrom(dto => dto.Name));

                cfg.CreateMap<GameDto, RentedArticleModel>()
                   .ForMember(model => model.ArticleId,
                              opt => opt.MapFrom(dto => dto.Id))
                   .ForMember(model => model.ArticleName,
                              opt => opt.MapFrom(dto => dto.Name));
            });
        }
    }
}