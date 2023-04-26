using ApiAirsoft.Modelos.Armas;
using ApiAirsoft.Repositorios;
using ApiAirsoft.Servicios.IServices;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiAirsoft.Servicios.Services
{
    public class AccionService : IAccionService<Accion>
    {
        private readonly IRepositorio<int, Accion> repositorio;
        private readonly IArmaService<Arma> armaService;

        public AccionService(IRepositorio<int, Accion> repositorio, IArmaService<Arma> armaService)
        {
            this.repositorio = repositorio;
            this.armaService = armaService;
        }

        public ICollection<Accion> GetAll()
        {
            var acciones_list = new List<Accion>();
            var acciones = repositorio.Get();
            foreach (var accion in acciones)
            {
                gestionarArma(armaService, accion);
                acciones_list.Add(accion);
            }
            return acciones_list;
        }

        public Accion? GetById(int? id)
        {
            var accion = repositorio.Where(c => c.Cod_Accion == id).SingleOrDefault();
            if (accion != null)
            {
                gestionarArma(armaService, accion);
                return accion;
            }
            else return accion;
        }

        public bool Post(Accion entity)
        {
            if (entity != null)
            {
                gestionarArma(armaService, entity);
                return repositorio.Add(entity);
            }
            else return false;
        }

        public bool Put(Accion entity)
        {
            if (entity != null)
            {
                gestionarArma(armaService, entity);
                return repositorio.Update(entity);
            }
            else return false;
        }

        public bool Delete(Accion entity) => repositorio.Delete(entity.Cod_Accion);

        public void gestionarArma(IArmaService<Arma> armaService, Accion accion)
        {
            var armas = armaService.GetAll().Where(a => a.Accion_Id == accion.Cod_Accion);
            if (armas != null)
            {
                foreach (var arma in armas)
                {
                    if (accion.Armas == null) accion.Armas = new List<Arma> { arma };
                    else accion.Armas.Add(arma);
                }
            }
        }
    }
}