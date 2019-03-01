using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EF_TestConcept
{
    public interface IRepositoryQuery<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity item);

        void AddRange(List<TEntity> list);

        void Modify(TEntity item);

        void Remove(TEntity item);

        void Merge(TEntity persisted, TEntity current);

        TEntity Get(object keyValues);

        void SaveChange();

        List<TEntity> GetAll(List<string> includes);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<string> includeProperties = null, bool asNoTracking = false, string estadoRegistro = "1");

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<string> includeProperties = null, bool asNoTracking = false, string estadoRegistro = "1");


    }
}
