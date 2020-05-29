using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using System.Collections.Generic;

namespace CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Agenda
{
    public interface IEmployeeApplicationService
    {
        IEnumerable<EmployeeDto> GetAll();

        EmployeeDto GetByPKs(params object[] keyValues);

        EmployeeDto GetByDNI(string dni);

        void Add(EmployeeDto entity);

        void Update(EmployeeDto entity);

        void Delete(int dtoId);
    }
}
