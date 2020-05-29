using CIPSA.M_XI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CIPSA.M_XI.DomainService.Contract
{
     public interface IDomainServiceBase<TEntity>
       where TEntity : class, IEntity
    {
        IQueryable<TEntity> AsQueryable();

        void Delete(params object[] keyValues);

        IEnumerable<TEntity> GetByFilters(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null);

        List<TEntity> GetAll();

        TEntity GetByPKs(params object[] keyValues);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void SaveChange();
    }
}
