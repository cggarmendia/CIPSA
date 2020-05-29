using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromGameEntity : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Game;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new GameDto()
            {
                Id = entity.Id,
                IsRented = entity.IsRented,
                IsAdult = entity.IsAdult,
                Platform = entity.Platform,
                Name = entity.Name
            } as TOutput;
        }
    }
}
