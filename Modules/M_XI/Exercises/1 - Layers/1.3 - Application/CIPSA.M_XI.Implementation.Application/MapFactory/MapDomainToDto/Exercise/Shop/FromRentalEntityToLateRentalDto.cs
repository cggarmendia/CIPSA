using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromRentalEntityToLateRentalDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Rental;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new LateRentalDto()
            {
                ArticleId = entity.Article.Id,
                ArticleName = entity.Article.Name,
                ClientId = entity.Client.Id,
                ClientNIF = entity.Client.NIF,
                ClientName = entity.Client.Name,
                ClientLastName = entity.Client.LastName,
                RentalDate = entity.Date.ToShortDateString(),
                LateRentalTotalDays = (int)(DateTime.Now - entity.Date).TotalDays
            } as TOutput;
        }
    }
}
