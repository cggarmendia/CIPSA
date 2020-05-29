using Autofac;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Agenda;
using CIPSA.M_XI.Infrastructure.UnitOfWorks.Exercise.Agenda;

namespace CIPSA.M_XI.Infrastructure.AutofacModule.Exercise.Agenda
{
    public class AgendaInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: UnitOfWork :.
            builder.RegisterType<AgendaUnitOfWork>().As<IAgendaUnitOfWork>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}