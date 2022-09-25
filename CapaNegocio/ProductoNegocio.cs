using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ProductoNegocio : GenericClass<SysHotelEntities, Producto>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public ProductoNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaProductoList> SelectListView(Expression<Func<vistaProductoList,
                                               bool>> predicate = null,
                                               bool detach = false)
        {
            var query = _dataContext.Set<vistaProductoList>().AsQueryable();
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

        public void ActualizarProducto(int id_producto, int cantidad)
        {
            _dataContext.pa_ActualizarStock(id_producto, cantidad);
        }
    }
}
