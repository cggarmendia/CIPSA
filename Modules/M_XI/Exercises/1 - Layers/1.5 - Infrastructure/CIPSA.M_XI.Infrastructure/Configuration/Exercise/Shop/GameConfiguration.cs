using CIPSA.M_XI.Domain.Entities.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Shop
{
    public class GameConfiguration : DbContextBaseConfiguration<Game>
    {
        #region Ctor.
        public GameConfiguration()
            : base()
        {
            ToTable("Game");

            HasKey(g => g.Id);

            Property(g => g.Platform)
                .HasMaxLength(10)
                .IsRequired();
        }
        #endregion
    }
}
