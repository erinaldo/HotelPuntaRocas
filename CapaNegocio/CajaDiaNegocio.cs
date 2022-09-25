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
    public class CajaDiaNegocio : GenericClass<SysHotelEntities, Caja_dia>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public CajaDiaNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<pa_CajaPedidos_Result> PedidosDelDia(int idCajaDia, DateTime fechaCierre)
        {
            return new List<pa_CajaPedidos_Result>(_dataContext.pa_CajaPedidos(idCajaDia, fechaCierre));
        }

        public int CierreCaja(int idCajaDia, int idUsuarioCierre, decimal saldoFinal, decimal saldoDiferencia, decimal saldoEgreso)
        {
            return _dataContext.pa_CierreCajaDia(idCajaDia, idUsuarioCierre, saldoFinal, saldoDiferencia, saldoEgreso);
        }

        public ObjectResult<decimal?> TotalEgresoByIdCajaDia(int idCajaDia)
        {
            return _dataContext.pa_TotalEgresoByIdCajaDia(idCajaDia);
        }
        public ObjectResult<pa_TotalHotelByIdCajaDia_Result> TotalHotelByIdCajaDia(int idCajaDia)
        {
            return _dataContext.pa_TotalHotelByIdCajaDia(idCajaDia);
        }
        public ObjectResult<decimal?> TotalMontoACuentaByIdCajaDia(int idCajaDia)
        {
            return _dataContext.pa_TotalMontoACuentaByIdCajaDia(idCajaDia);
        }

        public ObjectResult<pa_TotalServiciosByIdCajaDia_Result> TotalServiciosByIdCajaDia(int idCajaDia)
        {
            return _dataContext.pa_TotalServiciosByIdCajaDia(idCajaDia);
        }
        public ObjectResult<decimal?> TotalDescuentoByIdCajaDia(int idCajaDia)
        {
            return _dataContext.pa_TotalDescuentoByIdCajaDia(idCajaDia);
        }
    }
}
