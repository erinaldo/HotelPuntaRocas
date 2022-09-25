using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace CapaNegocio
{
    public class LiquidacionNegocio : GenericClass<SysHotelEntities, Liquidacion>, IDisposable
    {
        private SysHotelEntities _dataContext;

        public LiquidacionNegocio()
        {
            _dataContext = new SysHotelEntities();
        }

        public void Dispose()
        {
            if (_dataContext == null) return;
            _dataContext.Dispose();
            _dataContext = null;
        }
        public void ActualizarComprobante(int idLiquidacion, string serieLiquidacion, string correlativoLiquidacion)
        {
            _dataContext.pa_UpdateComprobante(idLiquidacion, serieLiquidacion, correlativoLiquidacion);
        }

        public ObjectResult<pa_ValidarTarjetas_Result> Listar(DateTime f_inicio, DateTime f_final)
        {
            return _dataContext.pa_ValidarTarjetas(f_inicio,f_final);
        }

        public void RemueveTarjeta(int idLiquidacion)
        {
            _dataContext.pa_RemueveTarjeta(idLiquidacion);
        }

        public ObjectResult<pa_ReporteContador_Result> GenerarReporte(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dataContext.pa_ReporteContador(fechaInicial, fechaFinal);
        }

        public ObjectResult<pa_ReporteContadorEntregable_Result> ReporteContadorEntregable(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dataContext.pa_ReporteContadorEntregable(fechaInicial, fechaFinal);
        }

        public List<pa_ReporteBalance_Result> GenerarBalance(int anio, string mostrar)
        {
            return _dataContext.pa_ReporteBalance(anio, mostrar).ToList();
        }

        public List<pa_ReporteBalanceResumen_Result> GenerarBalanceResumen(int anio, decimal dolar)
        {
            return _dataContext.pa_ReporteBalanceResumen(anio, dolar).ToList();
        }

        public ObjectResult<pa_ListaComprobantesLiquidacion_Result> ConsultaLiquidacion(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dataContext.pa_ListaComprobantesLiquidacion(fechaInicial, fechaFinal);
        }
    
        public ObjectResult<pa_ListaComprobantesConsumo_Result> ConsultaConsumo(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dataContext.pa_ListaComprobantesConsumo(fechaInicial, fechaFinal);
        }
        public ObjectResult<pa_ListaComprobantesTarjetas_Result> ConsultaTarjeta(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dataContext.pa_ListaComprobantesTarjetas(fechaInicial, fechaFinal);
        }
        public  void UpdateLiquidacion( int idLiquidacion, string tipoComprobante,
                                        string serieComprobante, string correlativo,
                                        string formaPago, double subTotal, double IGV,
                                        double total, string referencia, string tarjeta)
        {
            _dataContext.UpdateLiquidacion(idLiquidacion, tipoComprobante, serieComprobante, correlativo, formaPago, Convert.ToDecimal(subTotal), Convert.ToDecimal(IGV), Convert.ToDecimal(total), referencia, tarjeta);
        }
        public void UpdateLiquidacionBoleta(string nombre, int idLiquidacion, string tipoComprobante,
                                string serieComprobante, string correlativo,
                                string formaPago, double subTotal, double IGV,
                                double total, string referencia, string tarjeta)
        {
            _dataContext.UpdateLiquidacion_BOLETA(nombre, idLiquidacion, tipoComprobante, serieComprobante, correlativo, formaPago, Convert.ToDecimal(subTotal), Convert.ToDecimal(IGV), Convert.ToDecimal(total), referencia, tarjeta);
        }

        public void UpdateConsumo(int idLiquidacion, string tipoComprobante,
                                string serieComprobante, string correlativo,
                                string formaPago, double subTotal, double IGV,
                                double total, string referencia, string tarjeta)
        {
            _dataContext.UpdateConsumo(idLiquidacion, tipoComprobante, serieComprobante, correlativo, formaPago, Convert.ToDecimal(subTotal), Convert.ToDecimal(IGV), Convert.ToDecimal(total), referencia, tarjeta);
        }

        //AGREGADO PARA LA EDICION DE MONTOS TOTALES
        public void UpdateConsumoTotales(int idLiquidacion, double subTotal, double IGV, double total)
        {
            _dataContext.UpdateConsumoTotales(idLiquidacion, Convert.ToDecimal(subTotal), Convert.ToDecimal(IGV), Convert.ToDecimal(total));
        }
        public void UpdateLiquidacionTotales(int idLiquidacion, double subTotal, double IGV, double total)
        {
            _dataContext.UpdateLiquidacionTotales(idLiquidacion, Convert.ToDecimal(subTotal), Convert.ToDecimal(IGV), Convert.ToDecimal(total));
        }
        //FIN AGREGADO

        public void UpdateTarjeta(int id, string formaPago, double total, string referencia, string tarjeta)
        {
            _dataContext.UpdateMontoTarjeta(id, formaPago, Convert.ToDecimal(total), referencia, tarjeta);
        }

        public void BorrarComsumo(int id)
        {
            _dataContext.pa_BorrarContadorConsumo(id);
        }
        public void BorrarLiquidacion(int id)
        {
            _dataContext.pa_BorrarContadorLiquidacion(id);
        }

        public void GenerarBK()
        {
            _dataContext.GenerarBk();
        }

        public List<vistaLiquidacion> AnularComprobante(Expression<Func<vistaLiquidacion,
                        bool>> predicate = null,
                        bool detach = false)
        {
            var query = _dataContext.Set<vistaLiquidacion>().AsQueryable();
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
        public void Anular(int idLiquidacion)
        {
            _dataContext.pa_Anular_Comprobante(idLiquidacion);
        }

        public string CompruebaEstado(string tipoDocumentoId, string serieDocumento, int correlativoDocumento)
        {
            return _dataContext.pa_ObtieneEstadoComprobante(tipoDocumentoId, serieDocumento, correlativoDocumento).Max(item => item.EstadoId);
        }

        public void EliminarComprobante(string tipoDocumentoId, string serieDocumento, int correlativoDocumento)
        {
            _dataContext.pa_EliminarComprobante(tipoDocumentoId, serieDocumento, correlativoDocumento);
        }

        public ObjectResult<pa_UnirFactura_Result> UnirFactura()
        {
            return _dataContext.pa_UnirFactura();
        }

        public List<vistaUnirFactura> UnirComprobante(Expression<Func<vistaUnirFactura,
                bool>> predicate = null,
                bool detach = false)
        {
            var query = _dataContext.Set<vistaUnirFactura>().AsQueryable();
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

        public void RechazarDocumento_Hospedaje(int idLiquidacion)
        {
            _dataContext.RechazarDocumentoHospedaje(idLiquidacion);
        }
    }
}
