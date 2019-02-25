using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Repository.Repository
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private const bool TrueExpression = true;
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Dbset;

        public Repository(DbContext context)
        {
            Context = context;
            Dbset = Context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return Dbset.Add(entity).Entity;
        } 
      
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = Dbset.OfType<TEntity>();
            query = includes.Aggregate(query, (current, property) =>
            current.Include(property));
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await Dbset.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> Get(int id)
        {
            return await Dbset.FindAsync(id);
        }

        public async Task<TEntity> Get(params object[] keys)
        {
            return await Dbset.FindAsync(keys);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return await Find(x => TrueExpression, includes);
        }

        public string GetKeyField(Type type)
        {
            var allPropeties = type.GetProperties();
            var keyProperty = allPropeties.SingleOrDefault(
                p => p.IsDefined(typeof(KeyAttribute)));

            return keyProperty?.Name;
        }

        public object GetKeyValue(TEntity t)
        {
            var key = typeof(TEntity).GetProperties().FirstOrDefault(
                p => p.GetCustomAttributes(typeof(KeyAttribute)
                , true).Length != 0);
            return key?.GetValue(t, null);
        }

        public void Remove(TEntity entities)
        {
            Dbset.Remove(entities);
        }

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = Find(predicate);
            foreach (var obj in objects.Result)
            {
                Dbset.Remove(obj);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Dbset.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            var key = GetKeyValue(entity);

            Update(entity,key);
        }

        public void Update(TEntity entity, object key)
        {
            var originalEntity = Dbset.Find(key);
            Update(originalEntity, entity);
        }

        public void Update(TEntity originalEntity, TEntity newEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }

       
    }
}
