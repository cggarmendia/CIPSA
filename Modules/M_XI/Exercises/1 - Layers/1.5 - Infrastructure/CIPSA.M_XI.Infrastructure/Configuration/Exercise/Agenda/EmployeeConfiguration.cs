using CIPSA.M_XI.Domain.Entities.Exercise.Agenda;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Agenda
{
    public class EmployeeConfiguration : DbContextBaseConfiguration<Employee>
    {
        #region Ctor.
        public EmployeeConfiguration()
            : base()
        {
            ToTable("Employee");
            HasKey(c => c.Id);

            Property(c => c.Name).HasMaxLength(15)
                                     .IsRequired();
            Property(c => c.LastName).HasMaxLength(30)
                                     .IsRequired();

            Property(c => c.PhoneNumber).HasMaxLength(12)
                                        .IsRequired();

            Property(c => c.DNI).HasMaxLength(9)
                                        .IsRequired();
        }
        #endregion
    }
}
