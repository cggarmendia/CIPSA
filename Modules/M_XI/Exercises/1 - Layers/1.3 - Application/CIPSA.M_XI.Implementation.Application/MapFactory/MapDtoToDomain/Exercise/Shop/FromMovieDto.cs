﻿using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Shop
{
    internal class FromMovieDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) { return default(TOutput); }

            var dto = source as MovieDto;

            if (dto == null) { throw new InvalidCastException(typeof(TInput).Name); }

            return new Movie()
            {
                Id = dto.Id,
                IsRented = dto.IsRented,
                IsAdult = dto.IsAdult,
                Device = dto.Device,
                Name = dto.Name
            } as TOutput;
        }
    }
}
