using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromRentalEntityToRentalDataDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Rental;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new RentalDataDto()
            {
                NIF = entity.Client.NIF,
                Name = entity.Client.Name,
                LastName = entity.Client.LastName,
                RentalDate = entity.Date.ToShortDateString()
            } as TOutput;
        }
    }
}
