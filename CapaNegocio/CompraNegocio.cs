using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class CompraNegocio : GenericClass<SysHotelEntities, Compra>, IDisposable
    {
         private SysHotelEntities _dataContext;

         public CompraNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public int GrabarCompra(Compra entidad)
        {
            _dataContext.Compra.Add(entidad);
            _dataContext.SaveChanges();
            var id = entidad.id;
            return id;
        }
    }
}
