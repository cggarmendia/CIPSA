using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Agenda;
using CIPSA.M_XI.Infrastructure.Context.Exercise.Agenda;

namespace CIPSA.M_XI.Infrastructure.UnitOfWorks.Exercise.Agenda
{
    public class AgendaUnitOfWork : UnitOfWorkBase, IAgendaUnitOfWork
    {
        #region Constructor

        public AgendaUnitOfWork()
        {
            this.context = new AgendaContext();
        }

        #endregion
    }
}
