using CIPSA.M_XI.Infrastructure.Context.Exercise.Shop;
using System.Data.Entity.Migrations;

namespace CIPSA.M_XI.Infrastructure.Migrations.Exercise.Shop
{
    internal sealed class ShopConfiguration : DbMigrationsConfiguration<ShopContext>
    {
        public ShopConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Exercise\Shop";
        }

        protected override void Seed(ShopContext context)
        {
        }
    }
}
