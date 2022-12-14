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
    public class EgresoNegocio : GenericClass<SysHotelEntities, Egreso>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public EgresoNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaEgresoList> SelectListView(Expression<Func<vistaEgresoList,
                                        bool>> predicate = null,
                                        bool detach = false)
        {
            var query = _dataContext.Set<vistaEgresoList>().AsQueryable();
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
        public void InsertarEgreso(int idUsuario, int idConcepto, int idCajaDia, decimal montoEgreso)
        {
            _dataContext.pa_InsertarConcepto(idUsuario, idConcepto, idCajaDia, montoEgreso);
        }
    }
}
