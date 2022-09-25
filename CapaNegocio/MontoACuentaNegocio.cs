using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class MontoACuentaNegocio : GenericClass<SysHotelEntities, Monto_A_Cuenta>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public MontoACuentaNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<pa_MontoACuenta_Result> ListaPagosACuenta(int idGrupo)
        {
            return _dataContext.pa_MontoACuenta(idGrupo).ToList();
        }
        public void MontoEnCaja(int idMontoCuenta)
        {
            _dataContext.pa_MontoACuentaEnCaja(idMontoCuenta);
        }
    }
}
