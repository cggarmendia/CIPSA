namespace CIPSA.M_XI.Infrastructure.Migrations.Exercise.Agenda
{
    using CIPSA.M_XI.Infrastructure.Context.Exercise.Agenda;
    using System.Data.Entity.Migrations;

    internal sealed class AgendaConfiguration : DbMigrationsConfiguration<AgendaContext>
    {
        public AgendaConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Exercise\Agenda";
        }

        protected override void Seed(AgendaContext context)
        {
        }
    }
}
