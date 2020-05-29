using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromMovieEntity : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Movie;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new MovieDto()
            {
                Id = entity.Id,
                IsRented = entity.IsRented,
                IsAdult = entity.IsAdult,
                Device = entity.Device,
                Name = entity.Name
            } as TOutput;
        }
    }
}
