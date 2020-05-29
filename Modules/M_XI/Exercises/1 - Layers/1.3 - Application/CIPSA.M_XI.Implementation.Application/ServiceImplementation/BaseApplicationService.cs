using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain;
using System.Collections.Generic;

namespace CIPSA.M_XI.Implementation.Application.ServiceImplementation
{
    public abstract class BaseApplicationService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        #region .: Protected  Properties :.

        protected bool disposed = false;

        #endregion

        #region .: Protected  Methods :.

        protected TDto MapFromEntityToDto(TEntity entity, DomainToDtoEnum domainToDtoEnum)
        {
            var mapper = MappingFromDomainFactory.GetFor(domainToDtoEnum);
            return mapper.Get<TEntity, TDto>(entity);
        }

        protected AnotherDto MapFromEntityToDto<AnotherDto>(TEntity entity, DomainToDtoEnum domainToDtoEnum)
            where AnotherDto : class
        {
            var mapper = MappingFromDomainFactory.GetFor(domainToDtoEnum);
            return mapper.Get<TEntity, AnotherDto>(entity);
        }

        protected IEnumerable<TDto> MapFromEntitiesToDtos(IEnumerable<TEntity> entities, DomainToDtoEnum domainToDtoEnum)
        {
            var mapper = MappingFromDomainFactory.GetFor(domainToDtoEnum);
            return mapper.GetCollection<TEntity, TDto>(entities);
        }

        protected IEnumerable<AnotherDto> MapFromEntitiesToDtos<AnotherDto>(IEnumerable<TEntity> entities, DomainToDtoEnum domainToDtoEnum)
            where AnotherDto : class
        {
            var mapper = MappingFromDomainFactory.GetFor(domainToDtoEnum);
            return mapper.GetCollection<TEntity, AnotherDto>(entities);
        }

        protected TEntity MapFromDtoToEntity(TDto dto, DtoToDomainEnum DomainEnum)
        {
            var mapper = MappingToDomainFactory.GetFor(DomainEnum);
            return mapper.Get<TDto, TEntity>(dto);
        }
        #endregion
    }
}
