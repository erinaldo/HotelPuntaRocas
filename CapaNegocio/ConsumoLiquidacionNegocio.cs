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
    public class ConsumoLiquidacionNegocio: GenericClass<SysHotelEntities, Liquidacion_Consumo>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public ConsumoLiquidacionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaConsumoLiquidacion> SelectListView(Expression<Func<vistaConsumoLiquidacion,
                                       bool>> predicate = null,
                                       bool detach = false)
        {
            var query = _dataContext.Set<vistaConsumoLiquidacion>().AsQueryable();
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

        public List<vistaLiquidacionConsumo> SelectListViewLiquidacion(Expression<Func<vistaLiquidacionConsumo,
                               bool>> predicate = null,
                               bool detach = false)
        {
            var query = _dataContext.Set<vistaLiquidacionConsumo>().AsQueryable();
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

        public void AnularLiquidacion(int id)
        {
            _dataContext.pa_Anular_LiquidacionConsumo(id);
        }

        public void RechazarDocumento_Liquidacion(int idLiquidacion)
        {
            _dataContext.RechazarDocumentoConsumo(idLiquidacion);
        }
    }
}
