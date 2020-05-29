using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromClientEntity : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Client;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new ClientDto()
            {
                Id = entity.Id,
                Birthday = entity.Birthday,
                NIF = entity.NIF,
                LastName = entity.LastName,
                Name = entity.Name
            } as TOutput;
        }
    }
}
