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
    public class HabitacionTarifaNegocio : GenericClass<SysHotelEntities, HabitacionTarifa>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public HabitacionTarifaNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaHabitacionTarifa> SelectListView(Expression<Func<vistaHabitacionTarifa,
            bool>> predicate = null,
                        bool detach = false)
        {
            var query = _dataContext.Set<vistaHabitacionTarifa>().AsQueryable();
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
