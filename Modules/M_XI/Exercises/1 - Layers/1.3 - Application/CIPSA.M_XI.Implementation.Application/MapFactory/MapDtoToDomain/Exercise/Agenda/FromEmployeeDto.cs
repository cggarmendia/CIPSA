using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Domain.Entities.Exercise.Agenda;
using System;

namespace CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain.Exercise.Agenda
{
    internal class FromEmployeeDto : MappingBase
    {
        internal override TOutput Get<TInput, TOutput>(TInput source)
        {
            if (source == null) { return default(TOutput); }

            var dto = source as EmployeeDto;

            if (dto == null) { throw new InvalidCastException(typeof(TInput).Name); }

            return new Employee()
            {
                Id = dto.Id,
                Birthday = dto.Birthday,
                CreatedOn = dto.CreatedOn,
                DNI = dto.DNI,
                LastName = dto.LastName,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber
            } as TOutput;
        }
    }
}
