using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using CapaNegocio;

namespace CapaNegocio
{
    public class QueryServer : ClassServer<SysHotelEntities>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public QueryServer()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }
    }
}
