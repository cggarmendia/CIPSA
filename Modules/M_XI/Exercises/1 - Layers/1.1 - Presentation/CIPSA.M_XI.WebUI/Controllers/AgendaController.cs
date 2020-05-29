using AutoMapper;
using CIPSA.M_XI.Contract.Application.DTO.Exercise.Agenda;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Agenda;
using CIPSA.M_XI.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CIPSA.M_XI.WebUI.Controllers
{
    public class AgendaController : Controller
    {
        public IEmployeeApplicationService _employeeApplicationService { get; }

        public AgendaController(IEmployeeApplicationService employeeApplicationService)
        {
            _employeeApplicationService = employeeApplicationService;
        }

        public ActionResult Persons()
        {
            return View(Mapper.Map<IEnumerable<EmployeeDto>, IEnumerable<EmployeeModel>>(_employeeApplicationService.GetAll()));
        }

        public ActionResult FindPerson()
        {
            return View();
        }

        public ActionResult EmployeeManagement() {
            return View(Mapper.Map<IEnumerable<EmployeeDto>, IEnumerable<EmployeeManagementModel>>(_employeeApplicationService.GetAll()));
        }
    }
}