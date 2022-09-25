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
    public class ServicioHabitacionNegocio : GenericClass<SysHotelEntities, Servicio_habitacion>, IDisposable
    { 
        private SysHotelEntities _dataContext;

        public ServicioHabitacionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaPedidoList> SelectListView(Expression<Func<vistaPedidoList,
                                        bool>> predicate = null,
                                        bool detach = false)
        {
            var query = _dataContext.Set<vistaPedidoList>().AsQueryable();
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

        public void PagarServicio(int idServicio, int idUsuario, int idCajaDia, bool estado_factura)
        {
            _dataContext.pa_PagarServicio(idServicio, idUsuario, idCajaDia, estado_factura);
        }

        public void DescontarProducto(int id_producto, int cantidad)
        {
            _dataContext.pa_DescuentaStock(id_producto, cantidad);
        }
        public void RestaurarProducto(int id_producto, int cantidad)
        {
            _dataContext.pa_ActualizarStock(id_producto, cantidad);
        }

        public bool ExisteStock(int idProducto)
        {
            var oProducto = _dataContext.Producto.SingleOrDefault(item => item.id == idProducto);
            if (oProducto != null && oProducto.stock_producto > 0)
                return true;
            return false;
        }
    }
}
