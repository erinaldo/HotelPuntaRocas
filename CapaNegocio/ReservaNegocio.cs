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
    public class ReservaNegocio : GenericClass<SysHotelEntities, Reserva>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public ReservaNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }

        public void RegistrarReservacion(int id, int idTarifaHabitacion, int idUsuario, 
                                         bool estadoPagoReserva, string estadoHabitacionReserva,
                                         int dia, int codigoReserva, int grupoReserva, string observacion, DateTime fechaSalida)
        {
            _dataContext.pa_RegistroReservacion(id, idTarifaHabitacion, idUsuario, estadoPagoReserva,
                                                estadoHabitacionReserva, dia, codigoReserva, grupoReserva, observacion, fechaSalida);
        }

        public void RegistrarReservacionMismo(int id, int idTarifaHabitacion, int idUsuario,
                                 bool estadoPagoReserva, string estadoHabitacionReserva,
                                 int dia, int codigoReserva, DateTime fecha, int grupoReserva, string observacion)
        {
            _dataContext.pa_RegistroReservacionMismo(id, idTarifaHabitacion, idUsuario, estadoPagoReserva,
                                                estadoHabitacionReserva, dia, codigoReserva, fecha, grupoReserva, observacion);
        }

        public void RegistrarReservacionOut(int id, int idUsuario, string estado)
        {
            _dataContext.pa_RegistroReservacionOut(id, idUsuario, estado);
        }

        public void CambiaEstado(int idReserva, string idEstado)
        {
            _dataContext.pa_CambiarEstado(idReserva, idEstado);
        }


        public void CambiarEstadoGrupo(int idGrupo, string idEstado)
        {
            _dataContext.pa_CambiarEstadoGrupo(idGrupo, idEstado);
        }

        public void CambiarEstadoGrupo_2(int idGrupo, string idEstado)
        {
            _dataContext.pa_CambiarEstadoGrupo_2(idGrupo, idEstado);
        }

        public void CambiarEstadoSinHuesped(int idReserva, string idEstado)
        {
            _dataContext.pa_CambiarEstadoSinHuesped(idReserva, idEstado);
        }

        public void GenerarMes(int idHabitacion, int i, string mes, string anio, string hIn, string hOut)
        {
            _dataContext.pa_GenerarMes(idHabitacion, i, mes, anio, hIn, hOut);
        }
        public bool ExisteGenerado(int mes, int anio)
        {
            var mesCreado = _dataContext.Reserva.Count(item => item.fecha_hotelera.Value.Month == mes && item.fecha_hotelera.Value.Year == anio);
            return mesCreado > 0;
        }

        public int ObtenerReserva(int idhabitacion, DateTime fecha)
        {
            var singleOrDefault = _dataContext.Reserva.SingleOrDefault(
                item => item.id_habitacion == idhabitacion && item.fecha_hotelera == fecha);
            return singleOrDefault != null ? singleOrDefault.id : 0;
        }

        public void CambiarHabitacion(int idHabitacionDe,int idHabitacionA,int idReservaDe,int idReservaA, DateTime fecha)
        {
            _dataContext.pa_CambiarHabitacion(idHabitacionDe, idHabitacionA, idReservaDe, idReservaA, fecha);
        }

        public void MovimientoEstados(int idReserva,int idUsuario,DateTime fechaMovimiento, int dniHuesped, string estadoHabitacionReserva)
        {
            _dataContext.pa_MovimientoEstados(idReserva, idUsuario, fechaMovimiento, dniHuesped, estadoHabitacionReserva);
        }

        public void RegistraAuto(int idReserva)
        {
            _dataContext.pa_RegistraAuto(idReserva);
        }

        public void DesregistraAuto(int idReserva)
        {
            _dataContext.pa_DesregistraAuto(idReserva);
        }

        public void CancelarHospedaje(int idReserva)
        {
            _dataContext.pa_CancelarHospedaje(idReserva);
        }

        public void ActualizaObservacion(int idReserva, string observacion)
        {
            _dataContext.pa_Observacion(idReserva, observacion);
        }
        public void EditarTarifa(int idGrupo, int idTarifa)
        {
            _dataContext.pa_EditarTarifa(idGrupo, idTarifa);
        }

        public ObjectResult<pa_ObtieneCorrelativo_Result> ObtenerCorrelativo(string idTipoComprobante)
        {
            return _dataContext.pa_ObtieneCorrelativo(idTipoComprobante);
        }
        public List<vistaHabitacionesAlquiladas> SelectViewHabitacionesAlquiladas(Expression<Func<vistaHabitacionesAlquiladas, bool>> predicate = null,
                                bool detach = false)
        {
            var query = _dataContext.Set<vistaHabitacionesAlquiladas>().AsQueryable();
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

        public List<vistaHabitacionHistoricas> SelectViewHabitacionesHistoricas(Expression<Func<vistaHabitacionHistoricas, bool>> predicate = null,
                        bool detach = false)
        {
            var query = _dataContext.Set<vistaHabitacionHistoricas>().AsQueryable();
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

        public List<vistaBusquedaReservas> SelectViewBusquedaReservas(Expression<Func<vistaBusquedaReservas, bool>> predicate = null,
                        bool detach = false)
        {
            var query = _dataContext.Set<vistaBusquedaReservas>().AsQueryable();
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

        public List<vistaReservaHistorica> SelectViewReservaHistoricas(Expression<Func<vistaReservaHistorica, bool>> predicate = null,
                 bool detach = false)
        {
            var query = _dataContext.Set<vistaReservaHistorica>().AsQueryable();
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

        public void LimpiarChantada(int idReserva)
        {
            this._dataContext.pa_QuitarReserva(new int?(idReserva));
        }
    }
}
