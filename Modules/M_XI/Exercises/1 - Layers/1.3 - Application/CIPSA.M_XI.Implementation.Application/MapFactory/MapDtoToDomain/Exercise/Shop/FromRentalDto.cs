using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Shop
{
    internal class FromRentalDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) { return default(TOutput); }

            var dto = source as RentalDto;

            if (dto == null) { throw new InvalidCastException(typeof(TInput).Name); }

            return new Rental()
            {
                ArticleId = dto.ArticleId,
                ClientId = dto.ClientId,
                Date = dto.Date
            } as TOutput;
        }
    }
}
