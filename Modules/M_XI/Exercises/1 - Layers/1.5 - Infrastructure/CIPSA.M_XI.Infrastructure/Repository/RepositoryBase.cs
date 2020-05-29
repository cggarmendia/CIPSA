using CIPSA.M_XI.Domain.Entities;
using CIPSA.M_XI.Domain.Repository;
using CIPSA.M_XI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace CIPSA.M_XI.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
    {
        #region Properties
        protected DBContextBase dbContext;
        protected DbSet<TEntity> dbSet;
        #endregion Members

        #region Ctor.
        internal RepositoryBase(DBContextBase context)
        {
            this.dbContext = context;
            this.dbSet = context.Set<TEntity>();
        }
        #endregion Constructor

        #region Public Methods

        public IQueryable<TEntity> AsQueryable()
        {
            return this.dbSet;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
        }

        public virtual IEnumerable<TEntity> GetByFilters(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            List<TEntity> list = new List<TEntity>();

            var tmpList = this.dbSet.ToList();

            if (tmpList != null)
                list.AddRange(tmpList);

            return list;
        }

        public virtual TEntity GetByPKs(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.AddOrUpdate(entity);
        }

        #endregion Public Methods
    }
}
