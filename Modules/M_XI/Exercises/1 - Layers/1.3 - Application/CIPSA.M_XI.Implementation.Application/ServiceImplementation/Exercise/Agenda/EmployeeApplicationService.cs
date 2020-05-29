using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Agenda;
using CIPSA.M_XI.Domain.Entities.Exercise.Agenda;
using CIPSA.M_XI.DomainService.Contract.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDomainToDto;
using CIPSA.M_XI.Implementation.Application.MapFactory.MapDtoToDomain;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Agenda
{
    public class EmployeeApplicationService : BaseApplicationService<Employee, EmployeeDto>, IEmployeeApplicationService
    {
        #region .: Properties :.

        private readonly IEmployeeDomainService _employeeDomainService;

        #endregion

        #region .: Constructor :.

        public EmployeeApplicationService(IEmployeeDomainService employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        #endregion

        #region .: Public Methods :.

        public void Add(EmployeeDto dto)
        {
            _employeeDomainService.Add(MapFromDtoToEntity(dto, DtoToDomainEnum.Employee));
            _employeeDomainService.SaveChange();
        }

        public void Update(EmployeeDto dto)
        {
            _employeeDomainService.Update(MapFromDtoToEntity(dto, DtoToDomainEnum.Employee));
            _employeeDomainService.SaveChange();
        }

        public EmployeeDto GetByPKs(params object[] dtoId)
        {
            return MapFromEntityToDto(_employeeDomainService.GetByPKs(dtoId), DomainToDtoEnum.Employee);
        }

        public void Delete(int dtoId)
        {
            _employeeDomainService.Delete(dtoId);
            _employeeDomainService.SaveChange();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            return MapFromEntitiesToDtos(_employeeDomainService.GetAll(), DomainToDtoEnum.Employee);
        }

        public EmployeeDto GetByDNI(string dni)
        {
            return MapFromEntityToDto(
                _employeeDomainService.GetByFilters(
                    employee => employee.DNI.Equals(dni)
                    ).ToList().FirstOrDefault(), 
                DomainToDtoEnum.Employee);
        }
        #endregion
    }
}
