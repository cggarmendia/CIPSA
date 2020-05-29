using CIPSA.M_XI.Domain.Entities;
using CIPSA.M_XI.Domain.Repository;
using System;

namespace CIPSA.M_XI.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IRepository<T> GetRepository<T>()
            where T : class, IEntity;

        void Rollback();
    }
}
