using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Shop;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain
{
    internal class MappingToDomainFactory
    {
        internal static MappingBase GetFor(DtoToDomainEnum dtoToDomain)
        {
            switch (dtoToDomain)
            {
                case DtoToDomainEnum.Employee:
                    return new FromEmployeeDto();
                case DtoToDomainEnum.Client:
                    return new FromClientDto();
                case DtoToDomainEnum.Game:
                    return new FromGameDto();
                case DtoToDomainEnum.Movie:
                    return new FromMovieDto();
                case DtoToDomainEnum.Rental:
                    return new FromRentalDto();
                default:
                    throw new NotImplementedException(string.Format("The mapping for type {0} is not implemented.", dtoToDomain));
            }
        }
    }
}
