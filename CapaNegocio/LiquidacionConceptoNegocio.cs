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
    public class LiquidacionConceptoNegocio : GenericClass<SysHotelEntities, Liquidacion_Concepto>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public LiquidacionConceptoNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public ObjectResult<string> Numeros_a_Letras(decimal montoTotalComprobante)
        {
            return _dataContext.pa_NumberToLetters(montoTotalComprobante);
        }
    }
}
