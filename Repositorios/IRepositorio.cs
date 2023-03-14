using System.Linq.Expressions;

namespace ApiAirsoft.Repositorios
{
    public interface IRepositorio<TEntity>
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(int id);
        TEntity Get(TEntity item, params Expression<Func<TEntity, IEnumerable<object>>>[] includes);
        IQueryable<TEntity> Where();
        IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}