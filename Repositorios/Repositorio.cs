using ApiAirsoft.Excepciones;
using ApiAirsoft.Util;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ObjectiveC;

namespace ApiAirsoft.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly AirsoftDbContext airsoftDbContext;
        private readonly DbSet<TEntity> entity;

        public Repositorio(AirsoftDbContext airsoftDbContext, DbSet<TEntity> entity)
        {
            this.airsoftDbContext = airsoftDbContext;
            this.entity = entity;
        }
        public IQueryable<TEntity> Get()
        {
            var entities = entity.AsNoTracking();
            return entities;
        }

        public IQueryable<TEntity> Get(int id)
        {
            var entities = entity.AsNoTracking();
            return entities;
        }

        public TEntity Get(TEntity item, params Expression<Func<TEntity, IEnumerable<object>>>[] includes)
        {
            var entities = entity.Find(item);

            if (entities != default)
            {
                foreach (var include in includes)
                    airsoftDbContext.Entry(entities).Collection(include).Load();
            }

            return entities;
        }

        public IQueryable<TEntity> Where()
        {
            var query = airsoftDbContext.Set<TEntity>().AsQueryable();
            return query;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var query = airsoftDbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public bool Add(TEntity item)
        {
            airsoftDbContext.Set<TEntity>().Add(item);
           var cont = airsoftDbContext.SaveChanges();
            return cont > 0;
        }

        public bool Update(TEntity item)
        {
            var cont = 0;
            if (item != default)
            {
                airsoftDbContext.Entry(item).State = EntityState.Modified;
                airsoftDbContext.Set<TEntity>().Update(item); 
                cont = airsoftDbContext.SaveChanges();
            }
            return cont > 0;
            
        }

        public bool Delete(TEntity item)
        {
            var model = Get(item);
            if (model == null)
                throw new EntityNotFoundException(item,typeof(TEntity));
            entity.Remove(model);
            var cont = airsoftDbContext.SaveChanges();
            return cont > 0;
        }
    }
}