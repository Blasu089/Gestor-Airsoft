using ApiAirsoft.Util;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiAirsoft.Repositorios
{
    public class Repositorio<TKey, TEntity> : IRepositorio<TKey, TEntity> where TEntity : class
    {
        private readonly DbContext DbContext;
        private readonly DbSet<TEntity> entity;

        public Repositorio(AirsoftDbContext airsoftDbContext)
        {
            this.DbContext = airsoftDbContext;
            entity = airsoftDbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Get()
        {
            var entities = entity.AsNoTracking();
            return entities;
        }

        public IQueryable<TEntity> Get(int? id)
        {
            var entities = entity.AsNoTracking();
            return entities;
        }

        public TEntity? Get(TKey? item, params Expression<Func<TEntity, IEnumerable<object>>>[] includes)
        {
            var entities = entity.Find(item);

            if (entities != default)
            {
                foreach (var include in includes)
                    DbContext.Entry(entities).Collection(include).Load();
            }

            return entities;
        }

        public IQueryable<TEntity> Where()
        {
            var query = DbContext.Set<TEntity>().AsQueryable();
            return query;
        }

        /**
         * Metodo para poner condiciones en la busqueda de datos
         */
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var query = DbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public bool Add(TEntity item)
        {
            DbContext.Set<TEntity>().Add(item);
            var cont = DbContext.SaveChanges();
            return cont > 0;
        }

        public bool Update(TEntity item)
        {
            var cont = 0;
            if (item != default)
            {
                DbContext.Entry(item).State = EntityState.Modified;
                DbContext.Set<TEntity>().Update(item); 
                cont = DbContext.SaveChanges();
            }
            return cont > 0;
            
        }

        public bool Delete(TKey item)
        {
            var model = Get(item);
            if (model == null)
                throw new NullReferenceException();
            entity.Remove(model);
            var cont = DbContext.SaveChanges();
            return cont > 0;
        }
    }
}