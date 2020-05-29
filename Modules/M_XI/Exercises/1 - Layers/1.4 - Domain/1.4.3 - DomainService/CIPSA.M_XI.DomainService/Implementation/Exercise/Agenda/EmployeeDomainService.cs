using CIPSA.M_XI.Domain.Entities.Exercise.Agenda;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Agenda;
using CIPSA.M_XI.DomainService.Contract.Exercise.Agenda;

namespace CIPSA.M_XI.DomainService.Implementation.Exercise.Agenda
{
    public class EmployeeDomainService : DomainServiceBase<Employee>, IEmployeeDomainService
    {
        public EmployeeDomainService(IAgendaUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }
    }
}
