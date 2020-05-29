using Autofac;
using CIPSA.M_XI.DomainService.Contract.Exercise.Agenda;
using CIPSA.M_XI.DomainService.Implementation.Exercise.Agenda;

namespace CIPSA.M_XI.DomainService.AutofacModule.Exercise.Agenda
{
    public class AgendaDomainServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region .: DomainService :.
            builder.RegisterType<EmployeeDomainService>().As<IEmployeeDomainService>().InstancePerRequest();
            #endregion
            
            base.Load(builder);
        }
    }
}
