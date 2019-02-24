using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Repository.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(params object[] keys);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Update(TEntity entity, object key);
        void Update(TEntity originalEntity, TEntity newEntity);

        void Remove(TEntity entities);
        void Remove(Expression<Func<TEntity, bool>> predicate);
        void RemoveRange(IEnumerable<TEntity> entities);

        object GetKeyValue(TEntity t);
        string GetKeyField(Type type);

    }
}
