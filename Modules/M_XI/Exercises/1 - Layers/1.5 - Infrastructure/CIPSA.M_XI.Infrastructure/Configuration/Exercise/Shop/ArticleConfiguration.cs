using CIPSA.M_XI.Domain.Entities.Exercise.Shop;

namespace CIPSA.M_XI.Infrastructure.Configuration.Exercise.Shop
{
    public class ArticleConfiguration : DbContextBaseConfiguration<Article>
    {
        #region Ctor.
        public ArticleConfiguration()
            : base()
        {
            ToTable("Article");

            HasKey(a => a.Id);

            Property(a => a.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
        #endregion
    }
}
