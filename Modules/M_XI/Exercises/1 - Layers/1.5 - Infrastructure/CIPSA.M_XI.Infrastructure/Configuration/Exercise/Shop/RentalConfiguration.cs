using CIPSA.M_XI.Domain.Entities.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Shop
{
    public class RentalConfiguration : DbContextBaseConfiguration<Rental>
    {
        #region Ctor.
        public RentalConfiguration()
            : base()
        {
            ToTable("Rental");

            HasKey(r => new { r.ArticleId, r.ClientId });

            HasRequired(r => r.Client)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.ClientId);

            HasRequired(r => r.Article)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.ArticleId);

            Property(r => r.Date)
                .HasColumnType("Date");
        }
        #endregion
    }
}
