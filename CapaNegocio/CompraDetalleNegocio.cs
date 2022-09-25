using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class CompraDetalleNegocio : GenericClass<SysHotelEntities, Detalle_compra>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public CompraDetalleNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public object[] GrabarCompraDetalle(Detalle_compra entidad)
        {
            _dataContext.Detalle_compra.Add(entidad);
            _dataContext.SaveChanges();
            var id = entidad.id;
            var cantidad = entidad.cantidad_detalle_compra;
            var idProducto = entidad.id_producto;
            var array = new object[] { id, cantidad, idProducto };
            return array;
        }

    }
}
