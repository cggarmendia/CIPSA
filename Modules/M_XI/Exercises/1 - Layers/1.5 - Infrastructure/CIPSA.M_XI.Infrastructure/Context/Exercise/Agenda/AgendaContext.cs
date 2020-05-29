using CIPSA.M_XI.Infrastructure.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace CIPSA.M_XI.Infrastructure.Context.Exercise.Agenda
{
    public class AgendaContext : DBContextBase
    {
        public AgendaContext() 
            : base("name=AgendaContext")
        {
        }

        #region Entities
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            LoadEntityTypeConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void LoadEntityTypeConfiguration(DbModelBuilder modelBuilder)
        {
            // Carga todas las EntityTypeConfiguration por reflection.
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type != typeof(DbContextBaseConfiguration<>) &&
                               type.Namespace.Contains("Agenda") &&
                               (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>) ||
                                type.BaseType.GetGenericTypeDefinition() == typeof(DbContextBaseConfiguration<>)));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
        }
    }
}
