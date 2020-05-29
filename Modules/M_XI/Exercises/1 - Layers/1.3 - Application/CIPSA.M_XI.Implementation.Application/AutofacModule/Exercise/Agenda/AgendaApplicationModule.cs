using Autofac;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Agenda;
using CIPSA.M_XI.Implementation.Application.ServiceImplementation.Exercise.Agenda;

namespace CIPSA.M_XI.Implementation.Application.AutofacModule.Exercise.Agenda
{
    public class AgendaApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: ApplicationService :.
            builder.RegisterType<EmployeeApplicationService>().As<IEmployeeApplicationService>().InstancePerRequest();
            #endregion

            base.Load(builder);
        }
    }
}
