using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class CalificacionNegocio : GenericClass<SysHotelEntities, Calificacion>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public CalificacionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaClasificacion> SelectListView(Expression<Func<vistaClasificacion,
                                        bool>> predicate = null,
                                        bool detach = false)
        {
            var query = _dataContext.Set<vistaClasificacion>().AsQueryable();
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

        public List<vistaTotalPuntos> SelectListViewPuntos(Expression<Func<vistaTotalPuntos,
                                bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaTotalPuntos>().AsQueryable();
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

        public List<pa_UltimaObservacion_Result> UltimaObservacion(string _dni)
        {
            return _dataContext.pa_UltimaObservacion(_dni).ToList();
        }

        public List<vistaClasificacionHuesped> SelectListViewHuesped(Expression<Func<vistaClasificacionHuesped,
                                bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaClasificacionHuesped>().AsQueryable();
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
