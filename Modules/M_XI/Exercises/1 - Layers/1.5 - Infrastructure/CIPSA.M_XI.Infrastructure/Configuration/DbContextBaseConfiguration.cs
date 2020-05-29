using CIPSA.M_XI.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CIPSA.M_XI.Infrastructure.Configuration
{
    public abstract class DbContextBaseConfiguration<T> : EntityTypeConfiguration<T>
        where T : class, IEntity
    {
        #region Public Constructors

        #endregion Public Constructors
    }
}
