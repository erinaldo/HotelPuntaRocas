using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ConfiguracionNegocio : GenericClass<SysHotelEntities, Configuracion>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public ConfiguracionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }
        public void CambiarConfiguracion()
        {
            _dataContext.pa_CambiarConfiguracion();
        }
    }
}
