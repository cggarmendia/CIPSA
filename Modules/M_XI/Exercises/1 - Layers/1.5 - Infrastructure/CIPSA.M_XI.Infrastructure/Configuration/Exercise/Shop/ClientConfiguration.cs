using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.Infrastructure.Extension;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Shop
{
    public class ClientConfiguration : DbContextBaseConfiguration<Client>
    {
        #region Ctor.
        public ClientConfiguration()
            : base()
        {
            ToTable("Client");

            HasKey(c => c.Id);

            Property(c => c.Name)
                .HasMaxLength(15)
                .IsRequired();
            Property(c => c.LastName)
                .HasMaxLength(30)
                .IsRequired();

            Property(c => c.Birthday)
                .HasColumnType("Date");

            Property(c => c.NIF)
                .HasMaxLength(9)
                .IsRequired()
                .HasUniqueIndexAnnotation("IX_Client_NIF", 0);
        }
        #endregion
    }
}
