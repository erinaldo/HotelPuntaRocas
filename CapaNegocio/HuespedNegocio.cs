using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Data.Entity.Core.Objects;

namespace CapaNegocio
{
    public class HuespedNegocio : GenericClass<SysHotelEntities, Huesped>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public HuespedNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaHuespedList> SelectListView(Expression<Func<vistaHuespedList,
            bool>> predicate = null,
                                        bool detach = false)
        {
            var query = _dataContext.Set<vistaHuespedList>().AsQueryable();
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

        public List<vistaConsultaHuesped> SelectListViewConsulta(Expression<Func<vistaConsultaHuesped,
    bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaConsultaHuesped>().AsQueryable();
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
        public ObjectResult<pa_HuespedRepetidos_Result> ListarDuplicados()
        {
            return _dataContext.pa_HuespedRepetidos();
        }

        public void RemoverHuesped(int _idHuesped)
        {
            _dataContext.pa_RemoverDuplicado(_idHuesped);
        }

        public ObjectResult<string> GenerarDNI()
        {
            return _dataContext.pa_GenerarDNI_Extranjero();
        }
    }
}
