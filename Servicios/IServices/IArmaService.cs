

namespace ApiAirsoft.Servicios.IServices
{
    public interface IArmaService<T>
    {
        ICollection<T> GetAll();

        T GetById(int id);

        void Delete(int id);
    }
}
