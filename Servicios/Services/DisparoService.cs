using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;

namespace ApiAirsoft.Servicios.Services
{
    public class DisparoService : IDisparoService<Disparo>
    {
        private readonly IRepositorio<int, Disparo> repositorio;
        private readonly IArmaService<Arma> armaService;

        public DisparoService(IRepositorio<int, Disparo> repositorio, IArmaService<Arma> armaService)
        {
            this.repositorio = repositorio;
            this.armaService = armaService;
        }

        public ICollection<Disparo> GetAll()
        {
            var disparos_list = new List<Disparo>();
            var disparos = repositorio.Get();
            foreach (var disparo in disparos)
            {
                gestionarArmas(armaService, disparo);
                disparos_list.Add(disparo);
            }
            return disparos_list;
        }

        public Disparo? GetById(int? id)
        {
            var disparo = repositorio.Where(c => c.Cod_Disparo == id).SingleOrDefault();
            if (disparo != null)
            {
                gestionarArmas(armaService, disparo);
                return disparo;
            }
            else return disparo;
        }

        public bool Post(Disparo entity)
        {
            if (entity != null)
            {
                gestionarArmas(armaService, entity);
                return repositorio.Add(entity);
            }
            else return false;
        }

        public bool Put(Disparo entity)
        {
            if (entity != null)
            {
                gestionarArmas(armaService, entity);
                return repositorio.Update(entity);
            }
            else return false;
        }

        public bool Delete(Disparo entity) => repositorio.Delete(entity.Cod_Disparo);

        public void gestionarArmas(IArmaService<Arma> armaService, Disparo disparo)
        {
            var armas = armaService.GetAll().Where(a => a.Disparo_Id == disparo.Cod_Disparo);
            if (armas != null)
            {
                foreach (var arma in armas)
                {
                    if (disparo.Armas == null) disparo.Armas = new List<Arma> { arma };
                    else disparo.Armas.Add(arma);
                }
            }
        }
    }
}