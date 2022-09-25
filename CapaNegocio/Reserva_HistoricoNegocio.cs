using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class Reserva_HistoricoNegocio : GenericClass<SysHotelEntities, Reserva_Historica>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public Reserva_HistoricoNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<pa_BusquedaHistorico_Result> ListaHospedajeHistorico(string nombre)
        {
            return new List<pa_BusquedaHistorico_Result>(_dataContext.pa_BusquedaHistorico(nombre));
        }
    }
}