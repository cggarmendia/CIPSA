using CIPSA.M_XI.Domain.Entities;
using CIPSA.M_XI.Domain.Repository;
using CIPSA.M_XI.Domain.UnitOfWork;
using CIPSA.M_XI.Infrastructure.Context;
using CIPSA.M_XI.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace CIPSA.M_XI.Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWorkBase : IUnitOfWork, IDisposable
    {
        #region Members

        private bool disposed = false;
        private object lockRepo = new object();
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion

        #region Properties

        public DBContextBase context { get; set; }

        #endregion

        #region Constructor

        public UnitOfWorkBase()
        {
        }

        #endregion

        #region Public Methods

        public void Commit()
        {
            context.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IEntity
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                lock (lockRepo)
                {
                    if (!repositories.ContainsKey(typeof(T)))
                        repositories.Add(typeof(T), new RepositoryBase<T>(context));
                }
            }
            return (IRepository<T>)repositories[typeof(T)];
        }

        public virtual void Rollback()
        {
            context.Rollback();
        }

        #endregion

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    context = null;
                }
            }
            this.disposed = true;
        }

        #endregion
    }
}
