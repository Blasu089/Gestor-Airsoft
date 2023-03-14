namespace ApiAirsoft.Servicios.IServices
{
    public interface ICrudService<T>
    {
        T? GetById(int id);
        ICollection<T> GetAll();
        bool Put(T entity);
        bool Post(T entity);
        bool Delete(T entity);
    }
}