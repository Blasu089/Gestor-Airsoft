using ApiAirsoft.Modelos;
using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;
using ApiAirsoft.Util.Enumerados;

namespace ApiAirsoft.Servicios.Services
{
    public class ArmaService : IArmaService<Arma>
    {
        private readonly IRepositorio<int, Arma> repositorio;

        public ArmaService(IRepositorio<int, Arma> repositorio)
        {
            this.repositorio = repositorio;
        }

        public ICollection<Arma> GetAll() => repositorio.Get().ToList();


        public Arma? GetById(int? id) => repositorio.Get(id).Where(a => a.Cod_Referencia == id).SingleOrDefault();

        public bool Post(Arma arma)
        {
            if (arma != null)
            {
                var armaTipada = gestionarTipoArma(arma);

                repositorio.Add(armaTipada);
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO - Review gestionarEntity with flag for put request
        public bool Put(Arma arma)
        {
            if (arma != null)
            {
                repositorio.Update(arma);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Arma arma) => repositorio.Delete(arma.Cod_Referencia);

        

        #region metodos gestionTipoArma y creacion de estas
        private Arma gestionarTipoArma(Arma arma)
        {
            Arma armaTipada = new Arma();

            switch (arma.TipoArma)
            {
                case TipoArma.PISTOLA:
                    armaTipada = crearArma(arma);
                    break;
                case TipoArma.FUSIL:
                    armaTipada = crearArma(arma);
                    break;
                case TipoArma.SUBFUSIL:
                    armaTipada = crearArma(arma);
                    break;
                case TipoArma.ESCOPETA:
                    armaTipada = crearEscopeta(arma);
                    break;
                case TipoArma.FRANCOTIRADOR:
                    armaTipada = crearFrancotirador(arma);
                    break;
            }

            return armaTipada;
        }

        private Arma crearArma(Arma arma)
        {
            arma.Bipode_Incluido = null;
            arma.Mira_Incluida = null;
            arma.Cartuchos_Incluidos = null;
            arma.Capacidad_Cartucho = null;
            return arma;
        }
        private Arma crearEscopeta(Arma arma)
        {
            arma.Bipode_Incluido = null;
            arma.Mira_Incluida = null;
            return arma;
        }

        private Arma crearFrancotirador(Arma arma)
        {
            arma.Cartuchos_Incluidos = null;
            arma.Capacidad_Cartucho = null;
            return arma;
        }
        #endregion
    }
}