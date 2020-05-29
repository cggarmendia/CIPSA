using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.WebUI.Models;
using System;

namespace CIPSA.M_XI.WebUI.App_Start
{
    public static class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeeDto, EmployeeModel>()
                    .ForMember(model => model.Birthday,
                               opt => opt.MapFrom(dto => dto.Birthday.ToShortDateString()));

                cfg.CreateMap<EmployeeDto, EmployeeManagementModel>();

                cfg.CreateMap<MovieDto, MovieManagementModel>()
                    .ForMember(model => model.IsAdult,
                               opt => opt.MapFrom(dto => dto.IsAdult ? "SI": "NO"))
                    .ForMember(model => model.IsRented,
                               opt => opt.MapFrom(dto => dto.IsRented ? "SI" : "NO"));

                cfg.CreateMap<MovieDto, RentedArticleModel>()
                   .ForMember(model => model.ArticleId,
                              opt => opt.MapFrom(dto => dto.Id))
                   .ForMember(model => model.ArticleName,
                              opt => opt.MapFrom(dto => dto.Name));

                cfg.CreateMap<GameDto, GameManagementModel>()
                    .ForMember(model => model.IsAdult,
                               opt => opt.MapFrom(dto => dto.IsAdult ? "SI" : "NO"))
                    .ForMember(model => model.IsRented,
                               opt => opt.MapFrom(dto => dto.IsRented ? "SI" : "NO"));

                cfg.CreateMap<GameDto, RentedArticleModel>()
                   .ForMember(model => model.ArticleId,
                              opt => opt.MapFrom(dto => dto.Id))
                   .ForMember(model => model.ArticleName,
                              opt => opt.MapFrom(dto => dto.Name));

                cfg.CreateMap<ClientDto, ClientManagementModel>()
                    .ForMember(model => model.Birthday,
                               opt => opt.MapFrom(dto => dto.Birthday.ToShortDateString()));

            });
        }
    }
}