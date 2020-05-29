using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Agenda;
using System.Collections.Generic;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.Controllers
{
    public class AgendaController : ApiController
    {
        private readonly IEmployeeApplicationService _employeeApplicationService;

        public AgendaController(IEmployeeApplicationService employeeApplicationService)
        {
            _employeeApplicationService = employeeApplicationService;
        }

        public AgendaController()
        {
        }

        [HttpGet]
        public EmployeeDto FindEmployeeByDNI(string dni)
        {
            return _employeeApplicationService.GetByDNI(dni);
        }

        [HttpPost]
        public void AddEmployee([FromBody]EmployeeDto dto)
        {
            _employeeApplicationService.Add(dto);
        }

        [HttpPut]
        public void UpdateEmployee([FromBody]EmployeeDto dto)
        {
            _employeeApplicationService.Update(dto);
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            _employeeApplicationService.Delete(id);
        }
    }
}