using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class TarifaHabitacionNegocio : GenericClass<SysHotelEntities, Tarifa_habitacion>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public TarifaHabitacionNegocio()
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
