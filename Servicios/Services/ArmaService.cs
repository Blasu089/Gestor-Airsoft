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
        private readonly IAccionService<Accion> accionService;
        private readonly IColorService<Color> colorService;
        private readonly IDisparoService<Disparo> disparoService;

        public ArmaService(IRepositorio<int, Arma> repositorio, IAccionService<Accion> accionService,
            IColorService<Color> colorService, IDisparoService<Disparo> disparoService)
        {
            this.repositorio = repositorio;
            this.accionService = accionService;
            this.colorService = colorService;
            this.disparoService = disparoService;
        }

        public ICollection<Arma> GetAll()
        {
            var armas_list = new List<Arma>();

            var armas = repositorio.Get();

            foreach(var arma in armas)
            {
                gestionarAccion(accionService, arma, false);

                gestionarColor(colorService, arma, false);

                gestionarDisparos(disparoService, arma, false);

                armas_list.Add(arma);
            }

            return armas_list;
        }

        public Arma? GetById(int? id)
        {
            var arma= repositorio.Get(id).Where(a => a.Cod_Referencia == id).SingleOrDefault();
            if (arma != null)
            {
                gestionarAccion(accionService, arma, false);

                gestionarColor(colorService, arma, false);

                gestionarDisparos(disparoService, arma, false);

                return arma;
            }
            else
            {
                return arma;
            } 

        }

        public bool Post(Arma arma)
        {
            if (arma != null)
            {
                if(arma.Color_Id != null) gestionarColor(colorService, arma, true);

                if(arma.Accion_Id != null) gestionarAccion(accionService, arma, true);

                if (arma.Disparo_Id != null) gestionarDisparos(disparoService, arma, true);

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
                gestionarColor(colorService, arma, false);

                gestionarAccion(accionService, arma, false);

                gestionarDisparos(disparoService, arma, false);

                repositorio.Update(arma);

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Arma arma) => repositorio.Delete(arma.Cod_Referencia);

        #region metodos de gestion

        /**
         * Metodo para gestionar las Acciones del Arma
         */
        private void gestionarAccion(IAccionService<Accion> accionService, Arma arma, bool flag)
        {
            var acciones = accionService.GetAll();
            var accion = acciones.Where(c => c.Cod_Accion == arma.Accion_Id).FirstOrDefault();
            if (accion != null)
            {
                arma.Color_Id = accion.Cod_Accion;
                if (flag)
                {
                    if (accion.Armas == null) accion.Armas = new List<Arma> { arma };
                    else accion.Armas.Add(arma);
                }
            }
        }

        /**
        * Metodo para gestionar los Colores del Arma
        */
        private void gestionarColor(IColorService<Color> colorService, Arma entity, bool flag)
        {
            var colores = colorService.GetAll();
            var color = colores.Where(c => c.Cod_Color == entity.Color_Id).FirstOrDefault();
            if (color != null)
            {
                entity.Color_Id = color.Cod_Color;
                if (flag)
                {
                    if (color.Armas == null) color.Armas = new List<Arma> { entity };
                    else color.Armas.Add(entity);
                }
            }
        }

        /**
         * Metodo para gestionar los Disparos del Arma
         */
        private void gestionarDisparos(IDisparoService<Disparo> disparoService, Arma arma, bool flag)
        {
            var disparos = disparoService.GetAll();
            var disparo=disparos.Where(d=>d.Cod_Disparo == arma.Disparo_Id).FirstOrDefault();
            if (disparo != null)
            {
                arma.Disparo_Id = disparo.Cod_Disparo;
                if(flag)
                {
                    if (disparo.Armas == null) disparo.Armas = new List<Arma> { arma };
                    else disparo.Armas.Add(arma);
                }
            }
        }

        #endregion

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
            arma.Mira_Incluida= null;
            return arma;
        }

        private Arma crearFrancotirador(Arma arma)
        {
           arma.Cartuchos_Incluidos= null;
           arma.Capacidad_Cartucho= null;
           return arma;
        }
        #endregion
    }
}