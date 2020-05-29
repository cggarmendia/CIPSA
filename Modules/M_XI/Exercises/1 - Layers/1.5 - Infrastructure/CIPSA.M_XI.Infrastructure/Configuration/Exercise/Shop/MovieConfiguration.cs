using CIPSA.M_XI.Domain.Entities.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Shop
{
    public class MovieConfiguration : DbContextBaseConfiguration<Movie>
    {
        #region Ctor.
        public MovieConfiguration()
            : base()
        {
            ToTable("Movie");

            HasKey(m => m.Id);

            Property(m => m.Device)
                .HasMaxLength(10)
                .IsRequired();
        }
        #endregion
    }
}
