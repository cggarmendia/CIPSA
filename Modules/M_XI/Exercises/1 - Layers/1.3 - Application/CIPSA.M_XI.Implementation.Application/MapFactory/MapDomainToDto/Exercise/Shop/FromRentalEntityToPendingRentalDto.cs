using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop
{
    internal class FromRentalEntityToPendingRentalDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Rental;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new PendingRentalDto()
            {
                ArticleId = entity.ArticleId,
                ArticleName = entity.Article.Name,
                RentalDate = entity.Date.ToShortDateString()
            } as TOutput;
        }
    }
}
