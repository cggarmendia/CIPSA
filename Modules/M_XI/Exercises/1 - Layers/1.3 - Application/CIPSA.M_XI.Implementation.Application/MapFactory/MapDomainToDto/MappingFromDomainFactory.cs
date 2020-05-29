using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto
{
    internal class MappingFromDomainFactory
    {
        internal static MappingBase GetFor(DomainToDtoEnum domainToDto)
        {
            switch (domainToDto)
            {
                case DomainToDtoEnum.Employee:
                    return new FromEmployeeEntity();
                case DomainToDtoEnum.Movie:
                    return new FromMovieEntity();
                case DomainToDtoEnum.Client:
                    return new FromClientEntity();
                case DomainToDtoEnum.Game:
                    return new FromGameEntity();
                case DomainToDtoEnum.Rental:
                    return new FromRentalEntity();
                case DomainToDtoEnum.PendingRental:
                    return new FromRentalEntityToPendingRentalDto();
                case DomainToDtoEnum.RentalData:
                    return new FromRentalEntityToRentalDataDto();
                case DomainToDtoEnum.Article:
                    return new FromArticleEntity();
                case DomainToDtoEnum.LateRental:
                    return new FromRentalEntityToLateRentalDto();
                default:
                    throw new NotImplementedException(string.Format("Missing mapping for {0} in Vueling.ALM.ADOD.Impl.ServiceLibrary.MapFactories.MapDomainToDTO.", domainToDto.ToString()));
            }
        }
    }
}