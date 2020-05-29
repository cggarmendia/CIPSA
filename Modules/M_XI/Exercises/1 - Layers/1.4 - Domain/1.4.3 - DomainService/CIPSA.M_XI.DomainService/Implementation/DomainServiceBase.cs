using CIPSA.M_XI.Domain.Entities;
using CIPSA.M_XI.Domain.Repository;
using CIPSA.M_XI.Domain.UnitOfWork;
using CIPSA.M_XI.DomainService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CIPSA.M_XI.DomainService.Implementation
{
    public class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity>
       where TEntity : class, IEntity
    {
        #region .: Properties :.

        protected IRepository<TEntity> repository
        {
            get
            {
                return _unitOfWork.GetRepository<TEntity>();
            }
        }

        public IUnitOfWork _unitOfWork { get; }

        #endregion Properties

        #region .: Constructor :.
        public DomainServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region .: Public Methods :.

        public void Delete(params object[] keyValues)
        {
            var entity = GetByPKs(keyValues);

            OnDelete(entity);

            repository.Delete(entity);
        }

        public void Add(TEntity entity)
        {
            // Extensibility Point
            OnAdd(entity);

            repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            // Extensibility Point
            OnUpdate(entity);

            repository.Update(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return repository.AsQueryable();
        }

        public List<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetByPKs(params object[] keyValues)
        {
            return repository.GetByPKs(keyValues);
        }

        public virtual IEnumerable<TEntity> GetByFilters(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
        {
            return repository.GetByFilters(filter, orderBy, includeProperties);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
        #endregion Methods

        #region .: Protected Methods :.

        protected virtual void OnDelete(TEntity entity)
        {
        }

        protected virtual void OnAdd(TEntity entity)
        {
        }

        protected virtual void OnUpdate(TEntity entity)
        {
        }

        #endregion Protected Methods
    }
}
