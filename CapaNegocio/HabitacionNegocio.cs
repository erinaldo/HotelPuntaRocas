using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class HabitacionNegocio : GenericClass<SysHotelEntities, Habitacion>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public HabitacionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }
        public List<pa_ListaHabitacionesPorFecha_Result> ListarHabitacionesPorFecha(DateTime fecha)
        {
            return _dataContext.pa_ListaHabitacionesPorFecha(fecha).ToList();
        }
        public List<pa_ListaHabitacionesPorEstado_Result> ListarHabitacionesPorEstado(DateTime fecha, string estado)
        {
            return _dataContext.pa_ListaHabitacionesPorEstado(fecha, estado).ToList();
        }

        public List<vistaHabitacion> SelectListView(Expression<Func<vistaHabitacion,
                                bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaHabitacion>().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            var entityList = query.ToList();
            if (entityList.Count <= 0 || !detach) return entityList;
            foreach (var e in entityList)
            {
                ((IObjectContextAdapter)_dataContext).ObjectContext.Detach(e);
            }
            return entityList;
        }
    }
}
