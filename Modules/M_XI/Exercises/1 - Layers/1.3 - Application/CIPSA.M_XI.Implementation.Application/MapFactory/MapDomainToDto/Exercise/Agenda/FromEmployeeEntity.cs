using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Domain.Entities.Exercise.Agenda;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto.Exercise.Agenda
{
    internal class FromEmployeeEntity : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) return default(TOutput);
            var entity = source as Employee;

            if (entity == null) throw new InvalidCastException(typeof(TInput).Name);

            return new EmployeeDto()
            {
                Id = entity.Id,
                Birthday = entity.Birthday,
                CreatedOn = entity.CreatedOn,
                DNI = entity.DNI,
                LastName = entity.LastName,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber
            } as TOutput;
        }
    }
}
