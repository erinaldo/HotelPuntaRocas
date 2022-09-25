using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class ReservaDetalleNegocio: GenericClass<SysHotelEntities, Detalle_reserva>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public ReservaDetalleNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public List<vistaHuespedReserva> SelectListView(Expression<Func<vistaHuespedReserva,
                                bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaHuespedReserva>().AsQueryable();
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

        public List<pa_PedidoPorDNI_Result> ListaPedidosPorDNI(int dni)
        {
            return new List<pa_PedidoPorDNI_Result>(_dataContext.pa_PedidoPorDNI(dni));
        }

        public List<pa_PagarHospedaje_Result> ListaHospedaje(int codigoReserva)
        {
            return new List<pa_PagarHospedaje_Result>(_dataContext.pa_PagarHospedaje(codigoReserva));
        }

        public List<pa_PagarHospedajeHistorico_Result> ListaHospedajeHistorico(int codigoReserva)
        {
            return new List<pa_PagarHospedajeHistorico_Result>(_dataContext.pa_PagarHospedajeHistorico(codigoReserva));
        }

        public List<vistaCabeceraFactura> SelectViewCabeceraFactura(Expression<Func<vistaCabeceraFactura,
                        bool>> predicate = null,
                        bool detach = false)
        {
            var query = _dataContext.Set<vistaCabeceraFactura>().AsQueryable();
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

        public List<vistaCabeceraBoleta> SelectViewCabeceraBoleta(Expression<Func<vistaCabeceraBoleta,
                bool>> predicate = null,
                bool detach = false)
        {
            var query = _dataContext.Set<vistaCabeceraBoleta>().AsQueryable();
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

        public ObjectResult<string> MontoLetras(decimal monto)
        {
            return _dataContext.pa_MontoLetras(monto);
        }
    }
}
