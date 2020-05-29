using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Shop
{
    internal class FromClientDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) { return default(TOutput); }

            var dto = source as ClientDto;

            if (dto == null) { throw new InvalidCastException(typeof(TInput).Name); }

            return new Client()
            {
                Id = dto.Id,
                Birthday = dto.Birthday,
                NIF = dto.NIF,
                LastName = dto.LastName,
                Name = dto.Name
            } as TOutput;
        }
    }
}
