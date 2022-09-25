using System;
using System.Configuration;
using System.Data.Entity.Core;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using OfficeOpenXml;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaFacturacion : Form
    {
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly decimal _igvValor = decimal.Parse(ConfigurationManager.AppSettings["igv"]);

        private ReservaDetalleNegocio _oReservaDetalleN;
        private Liquidacion _oLiquidacion;
        private LiquidacionNegocio _oLiquidacionN;
        private ReservaNegocio _oReservaN;
        private MontoACuentaNegocio _ACuentaN;
        private Monto_A_Cuenta oCuenta;

        private decimal _pago = 0, _noPago = 0;
        private readonly int _codigoReserva;
        private readonly int _idDetalleReserva;
        private readonly int _idHabitacion;
        private readonly int _idReserva;
        private readonly int _idGrupo;
        private readonly string _numeroHabitacion;
        private readonly int _DNI;

        string _tipoPago = "";
        private void cargarFormaPago()
        {
            _ACuentaN = new MontoACuentaNegocio();
            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == _idGrupo && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);
            var montoACuenta = cuenta.LastOrDefault();
            if (montoACuenta != null && montoACuenta.forma_pago_acuenta == "T")
            {
                groupBox2.Enabled = false;
                rbtEfectivo.Checked = false;
                rbtTarjeta.Checked = true;
                txtNTarjeta.Text = montoACuenta.ntarjeta_acuenta;
                txtReferencia.Text = montoACuenta.referencia_acuenta;
                txtNTarjeta.Enabled = false;
                txtReferencia.Enabled = false;
            }
            else
            {
                var singleOrDefault = cuenta.LastOrDefault();
                if (singleOrDefault != null && singleOrDefault.forma_pago_acuenta == "E")
                {
                    groupBox2.Enabled = false;
                    rbtEfectivo.Checked = true;
                    rbtTarjeta.Checked = false;
                }
            }
        }

        private Liquidacion AsignarLiquidacion(decimal total, decimal real, decimal consumo, decimal descuento, decimal adicional,
                                               string montoEnCaja, bool estadoCaja, string _tipoDocumento)
        {
            if (descuento > 0)
            {
                total = total - descuento;
            }
            decimal subtotal = 0;
            decimal igv = 0;
            subtotal = Math.Round((total / (decimal)1.10), 2);
            igv = total - subtotal;

            _oLiquidacion = new Liquidacion()
            {
                id_usuario = _idUsuario,
                id_caja_dia = _idCajaDia,
                id_detalle_reserva = _idDetalleReserva,
                estado_liquidacion = true,
                tipo_comprobante_liquidacion = _tipoDocumento,
                forma_pago_liquidacion = FormaPago(),
                concepto_liquidacion = "",
                id_huesped = IdHuesped(_codigoReserva),
                cliente_liquidacion = Cliente(_codigoReserva),
                descuento_liquidacion = descuento == 0 ? 0 : descuento,
                fecha_liquidacion = DateTime.Now,
                igv_liquidacion = igv,
                total_liquidacion = total,
                sub_total_liquidacion = subtotal,
                real_liquidacion = real,
                consumo_liquidacion = consumo,
                aumento_liquidacion = adicional,
                ntarjeta_liquidacion = txtNTarjeta.Text,
                referencia_liquidacion = txtReferencia.Text,
            };
            if (chkSoloFactura.Checked)
                _oLiquidacion.aumento_liquidacion = Adicional();

            if (rbtTarjeta.Checked)
                _oLiquidacion.estado_tarjeta = true;
            else
                _oLiquidacion.estado_tarjeta = false;

            if (estadoCaja == false)
            {
                _oLiquidacion.monto_en_caja = true;
            }
            else
            {
                if (montoEnCaja == "")
                    _oLiquidacion.monto_en_caja = true;
                else
                    _oLiquidacion.monto_en_caja = false;
            }


            return _oLiquidacion;
        }


        private Liquidacion Asignar(decimal total, string montoEnCaja, bool estadoCaja, string _tipoDocumento)
        {
            total = decimal.Parse(lblHospedaje.Text);
            decimal real ;
            decimal consumo = decimal.Parse(lblConsumoTotal.Text);
            
            if (chkAumento.Checked)
            {
                real = decimal.Parse(lblTotal.Text);
            }
            else
            {
                if (chkSoloFactura.Checked)
                {
                    real = 0;
                }
                else
                {
                    real = total;
                } 
            }
            
            decimal adicional = 0;
            decimal lavanderia = decimal.Parse(txtLavanderia.Text);
            if (chkHospedaje.Checked)
            {
                consumo = 0;
                adicional = 0;
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblSaldoPago.Text);
            }

            if (chkAumento.Checked) 
            {
                consumo = 0;
                adicional = 0;
 
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblConsumoTotal.Text);
                total = decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text);
            }
            if (chkSoloFactura.Checked)
            {
                adicional = 0;
                adicional = total * decimal.Parse("0.20");
            }
            if (lavanderia > 0)
            {
                consumo = 0;
                adicional = 0;
                real = 0;
                real = total;
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblSaldoPago.Text);
                total = real+ lavanderia;
            }
            decimal subtotal = 0;
            decimal igv = 0;
            subtotal = Math.Round((total / (decimal)1.10), 2);
            igv = total - subtotal;

            _oLiquidacion = new Liquidacion()
            {
                id_usuario = _idUsuario,
                id_caja_dia = _idCajaDia ,
                id_detalle_reserva = _idDetalleReserva,
                estado_liquidacion = true,
                tipo_comprobante_liquidacion = _tipoDocumento,
                forma_pago_liquidacion = FormaPago(),
                concepto_liquidacion = "",
                id_huesped = IdHuesped(_codigoReserva),
                cliente_liquidacion = Cliente(_codigoReserva),
                descuento_liquidacion = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text),
                fecha_liquidacion = DateTime.Now,
                igv_liquidacion = igv,
                total_liquidacion = total,
                sub_total_liquidacion = subtotal,
                real_liquidacion = real,
                consumo_liquidacion = consumo,
                aumento_liquidacion = adicional,
                ntarjeta_liquidacion = txtNTarjeta.Text ,
                referencia_liquidacion = txtReferencia .Text,
            };
            if (chkSoloFactura.Checked)
                _oLiquidacion.aumento_liquidacion = Adicional();

            if (rbtTarjeta.Checked)
                _oLiquidacion.estado_tarjeta = true;
            else
                _oLiquidacion.estado_tarjeta = false;

            if (estadoCaja == false)
            {
                _oLiquidacion.monto_en_caja = true;
            }
            else
            {
                if (montoEnCaja == "")
                    _oLiquidacion.monto_en_caja = true;
                else
                    _oLiquidacion.monto_en_caja = false;
            }


            return _oLiquidacion;
        }

        private Monto_A_Cuenta Asignar(decimal monto, int grupo,bool flag)
        {
            _oReservaN = new ReservaNegocio();
            _ACuentaN = new MontoACuentaNegocio();
            
            var reserva = _oReservaN.SelectViewHabitacionesAlquiladas(item => item.grupo_reserva == grupo).LastOrDefault();
            var acuenta = _ACuentaN.SelectList(item => item.id_grupo == grupo).LastOrDefault();
            var cajaCerrada = _ACuentaN.SelectList(item => item.id_grupo == grupo).LastOrDefault().id_caja_dia;
            if (reserva != null)
                 oCuenta = new Monto_A_Cuenta()
                {
                    id = acuenta.id,
                    codigo_reserva = reserva.codigo_reserva,
                    estado_acuenta = false,
                    monto_acuenta = monto,
                    id_habitacion = reserva.id_habitacion,
                    id_usuario = _idUsuario,
                    id_grupo = reserva.grupo_reserva,
                    id_caja_dia = _idCajaDia,
                    fecha_registro = acuenta.fecha_registro,
                    fecha_acuenta = acuenta.fecha_acuenta,
                    ntarjeta_acuenta = acuenta.ntarjeta_acuenta,
                    referencia_acuenta =  acuenta.referencia_acuenta,
                    forma_pago_acuenta = acuenta.forma_pago_acuenta
                };
            if (flag)
                oCuenta.observacion_acuenta = "F";
            else
                oCuenta.observacion_acuenta = "NF";

            if (_idCajaDia == cajaCerrada)
                oCuenta.caja_cerrada = false;
            else
                oCuenta.caja_cerrada = true;
            return oCuenta;
        }

        private Monto_A_Cuenta Asignar(int idCuenta, decimal monto, int grupo, bool flag)
        {
            _oReservaN = new ReservaNegocio();
            _ACuentaN = new MontoACuentaNegocio();

            var reserva = _oReservaN.SelectViewHabitacionesAlquiladas(item => item.grupo_reserva == grupo).LastOrDefault();
            var cajaCerrada = _ACuentaN.SelectList(item => item.id == idCuenta).SingleOrDefault();
            if (reserva != null)
                oCuenta = new Monto_A_Cuenta()
                {
                    id = idCuenta,
                    codigo_reserva = reserva.codigo_reserva,
                    estado_acuenta = false,
                    monto_acuenta = monto,
                    id_habitacion = reserva.id_habitacion,
                    id_usuario = _idUsuario,
                    id_grupo = reserva.grupo_reserva,
                    id_caja_dia = _idCajaDia,
                    fecha_registro = cajaCerrada.fecha_registro ,
                    fecha_acuenta = cajaCerrada.fecha_acuenta,
                    ntarjeta_acuenta = cajaCerrada.ntarjeta_acuenta,
                    referencia_acuenta = cajaCerrada.referencia_acuenta,
                    forma_pago_acuenta = cajaCerrada.forma_pago_acuenta
                };

            if (flag)
                oCuenta.observacion_acuenta = "F";
            else
                oCuenta.observacion_acuenta = "NF";

            if (_idCajaDia == cajaCerrada.id_caja_dia)
                oCuenta.caja_cerrada = false;
            else
                oCuenta.caja_cerrada = true;
            return oCuenta;
        }
        private int Grupo()
        {
            _oReservaN = new ReservaNegocio();
            var reservaFecha = _oReservaN.SelectSingle(item => item.id == _idReserva).grupo_reserva;
            if (reservaFecha != null) return reservaFecha.Value;
            return 0;
        }

        private string TipoComprobate()
        {
            if (rbtBoleta.Checked)
                return "B";
            else if (rbtFactura.Checked)
                return "F";
            else
                return "T";
        }

        private string FormaPago()
        {
            return rbtTarjeta.Checked ? "T" : "E";
        }

        private int IdHuesped(int dni)
        {
            int id;
            string dniH = dni.ToString("00000000");
            HuespedNegocio huespedN = new HuespedNegocio();
            id = huespedN.SelectSingle(item => item.dni_huesped == dniH).id;
            return id;
        }

        private string Cliente(int dni)
        {
            var huespedN = new HuespedNegocio();
            var huesped = "";
            string dniH = dni.ToString("00000000");
            var vistaHuespedList = huespedN.SelectListView(item => item.dni_huesped == dniH);
            if (vistaHuespedList.Count() > 1)
            {
                MessageBox.Show("Existen Duplicado de DNI.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                if (vistaHuespedList != null)
                    huesped = vistaHuespedList.SingleOrDefault().completo_huesped;
            }
            return huesped;
        }

        public FrmReservaFacturacion(int idDetalleReserva, int codigoReserva, int idHabitacion, int idReserva, string numeroHabitacion, int dni, DateTime fechaHospedaje)
        {
            InitializeComponent();
            _idDetalleReserva = idDetalleReserva;
            _codigoReserva = codigoReserva;
            _idReserva = idReserva;
            _numeroHabitacion = numeroHabitacion;
            _idGrupo = Grupo();
            _idHabitacion = idHabitacion;
            _DNI = dni;
            CargarDatosPedidos(_codigoReserva, fechaHospedaje);
            CargarDatosHotel(codigoReserva);
            CargarMontoACuenta(codigoReserva);
            Totales();
        }

        private void CargarDatosPedidos(int id, DateTime fechaHospedaje)
        {
            //Pagar este detalle para jalar el detallado por Idcajadia
            _oReservaDetalleN = new ReservaDetalleNegocio();
            var oPedidos = _oReservaDetalleN.ListaPedidosPorDNI(id).Where(item=> item.id_habitacion == _idHabitacion && item.fecha_atencion == fechaHospedaje);
            var sumPago = oPedidos.Sum(item => item.Pago);
            var sumNoPago = oPedidos.Sum(item => item.Debe);
            if (sumPago != null) _pago = (decimal) sumPago;
            if (sumNoPago != null) _noPago = (decimal)sumNoPago;
            lblConsumoPago.Text = sumPago.ToString();
            lblConsumoTotal.Text = (sumPago + sumNoPago).ToString();
            lblSaldoPago.Text = sumNoPago.ToString();
        }

        private void CargarDatosHotel(int codigoReserva)
        {
            _oReservaDetalleN = new ReservaDetalleNegocio();
            var oDias = _oReservaDetalleN.ListaHospedaje(codigoReserva);
            string dniHuesped = "";
            var diasHospedaje = oDias.Count(item => item.id_habitacion == _idHabitacion && item.grupo_reserva == _idGrupo);
            if(oDias.Select(item=>item.codigo_reserva).ToString().Length < 8)
            {
                if (codigoReserva.ToString().Length == 7)
                dniHuesped = "0" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 6)
                    dniHuesped = "00" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 5)
                    dniHuesped = "000" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 4)
                    dniHuesped = "0000" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 3)
                    dniHuesped = "00000" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 2)
                    dniHuesped = "000000" + codigoReserva.ToString();
                else if (codigoReserva.ToString().Length == 1)
                    dniHuesped = "0000000" + codigoReserva.ToString();
                else
                    dniHuesped = codigoReserva.ToString();
            }
            else
            {
                dniHuesped = codigoReserva.ToString();
            }


            var paPagarHospedajeResult = oDias.FirstOrDefault(item => item.grupo_reserva == _idGrupo);
            if (paPagarHospedajeResult != null)
            {
                var tarifa = paPagarHospedajeResult.precio_tarifa_habitacion;
                lblDiasDeHospedaje.Text = @"" + diasHospedaje;
                lblMontoTarifa.Text = tarifa.ToString();
                lblHospedaje.Text = (diasHospedaje * tarifa).ToString();
            }
        }
        
        private void CargarMontoACuenta(int codigoReserva)
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            var estado = objN.SelectList(item => item.codigo_reserva == codigoReserva && item.id_habitacion == _idHabitacion);
            decimal monto = 0;
            foreach (var item in estado)
            {
                if (!item.observacion_acuenta.Contains("RETIRADO"))
                {
                    monto = monto + decimal.Parse(item.monto_acuenta.ToString());
                }
            }


            //var oMonto = objN.SelectList(item => item.codigo_reserva == codigoReserva && item.id_habitacion == _idHabitacion);

            //var montoACuenta = oMonto.Sum(item => item.monto_acuenta);
            lblACuenta.Text = monto.ToString();
        }

        private void Totales()
        {
            try
            {
                lblTotal.Text = (DevuelveNumero(lblSaldoPago.Text) + DevuelveNumero(lblHospedaje.Text)).ToString();
                lblNeto.Text = (DevuelveNumero(lblTotal.Text) - DevuelveNumero(lblACuenta.Text)).ToString();
            }
            catch (Exception)
            {

            }

        }

        private decimal DevuelveNumero(string texto)
        {
            return decimal.Parse(texto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAumento.Checked)
            {
                txtAumento.Visible = true;
                chkSoloFactura.Enabled = false;
            }
            else
            {
                txtAumento.Visible = false;
                chkSoloFactura.Enabled = true;
            }

        }

        private void rbtEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            txtNTarjeta.Visible = false;
            txtReferencia.Visible = false;

            lblNTarjeta.Visible = false;
            lblReferencia.Visible = false;
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            //txtNTarjeta.Visible = true;
            //txtReferencia.Visible = true;

            //lblNTarjeta.Visible = true;
            //lblReferencia.Visible = true;
        }

        private void  LiquidarExcelFactura(int idGrupo, bool soloHospedaje ,decimal hospedaje, decimal consumo, decimal aumento,
                                                                    decimal lavanderia, decimal descuento, decimal acuenta,bool liquidar)
        {
            DirectoryInfo outputDir = new DirectoryInfo(@"D:\Excel");
            if (!outputDir.Exists) throw new Exception("Directorio de salida no existe");
            string output = "";
            FileInfo templateFile = new FileInfo(outputDir.FullName + @"\factura.xlsx");
            FileInfo newFile = new FileInfo(outputDir.FullName + @"\facturaGenerada.xlsx");
            decimal totalMonto = 0;
            if (chkHospedaje.Checked)
                consumo = 0;
            if (!chkAumento.Checked)
                aumento = 0;
 
            if (liquidar)
                totalMonto = hospedaje + consumo + lavanderia - descuento + aumento;
            else
                totalMonto = acuenta;

            if (chkConsumo.Checked)
                totalMonto = consumo;

            if (chkHospedaje.Checked)
                totalMonto = hospedaje - descuento + aumento;

            _oReservaDetalleN = new ReservaDetalleNegocio();

            var cabecera = _oReservaDetalleN.SelectViewCabeceraFactura(item => item.id_grupo == idGrupo).FirstOrDefault();
            var montoLetras = _oReservaDetalleN.MontoLetras(totalMonto).SingleOrDefault();

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(outputDir.FullName + @"\facturaGenerada.xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                if (cabecera != null)
                {
                    worksheet.Cells["B4"].Value = cabecera.nombre_empresa;
                    worksheet.Cells["B5"].Value = cabecera.direccion_empresa;
                    worksheet.Cells["H6"].Value = cabecera.ruc_empresa;
                    
                }
                worksheet.Cells["B17"].Value = montoLetras;
                if (soloHospedaje)
                {
                    worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                    if (liquidar)
                        worksheet.Cells["M9"].Value = hospedaje + consumo + lavanderia - descuento + aumento;
                    else
                        worksheet.Cells["M9"].Value = acuenta;
                    if (lavanderia > 0)
                    {
                        worksheet.Cells["B10"].Value = "POR LAVANDERIA";
                        worksheet.Cells["M10"].Value = lavanderia;
                    }
                }
                else
                {
                    if (consumo > 0)
                    {
                        if (aumento > 0)
                        {
                            worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                            worksheet.Cells["M9"].Value = hospedaje + aumento;
                        }
                        else
                        {
                            if (chkConsumo.Checked)
                            {
                                worksheet.Cells["B9"].Value = "POR CONSUMO";
                                worksheet.Cells["M9"].Value = consumo;
                            }
                            else
                            {
                                worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                                worksheet.Cells["M9"].Value = hospedaje;
                            }

                        }
                        if (!chkConsumo.Checked)
                        {
                            worksheet.Cells["B10"].Value = "POR CONSUMO";
                            worksheet.Cells["M10"].Value = consumo;
                        }

                        if (lavanderia > 0)
                        {
                            worksheet.Cells["B11"].Value = "POR LAVANDERIA";
                            worksheet.Cells["M11"].Value = lavanderia;
                        }
                    }
                    else
                    {
                        worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                        if (liquidar)
                            worksheet.Cells["M9"].Value = hospedaje - descuento + aumento;
                        else
                            worksheet.Cells["M9"].Value = acuenta;
                        if (lavanderia > 0)
                        {
                            worksheet.Cells["B10"].Value = "POR LAVANDERIA";
                            worksheet.Cells["M10"].Value = lavanderia;
                        }

                    }
                }

                worksheet.View.PageLayoutView = false;

                package.Save();
            }
        }

        private void LiquidarExcelBoleta(int idGrupo, bool soloHospedaje, decimal hospedaje, decimal consumo, decimal aumento,
                                                            decimal lavanderia, decimal descuento, decimal acuenta, bool liquidar)
        {
            DirectoryInfo outputDir = new DirectoryInfo(@"D:\Excel");
            if (!outputDir.Exists) throw new Exception("Directorio de salida no existe");
            string output = "";
            FileInfo templateFile = new FileInfo(outputDir.FullName + @"\boleta.xlsx");
            FileInfo newFile = new FileInfo(outputDir.FullName + @"\boletaGenerada.xlsx");
            decimal totalMonto = 0;
            if (chkHospedaje.Checked)
                consumo = 0;
            if (!chkAumento.Checked)
                aumento = 0;

            if (liquidar)
                totalMonto = hospedaje + consumo + lavanderia - descuento + aumento;
            else
                totalMonto = acuenta;

            if (chkConsumo.Checked)
                totalMonto = consumo;

            if (chkHospedaje.Checked)
                totalMonto = hospedaje - descuento + aumento;

            _oReservaDetalleN = new ReservaDetalleNegocio();
            var cabecera = _oReservaDetalleN.SelectViewCabeceraBoleta(item => item.id_grupo == idGrupo).FirstOrDefault();
            var montoLetras = _oReservaDetalleN.MontoLetras(totalMonto).SingleOrDefault();

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(outputDir.FullName + @"\boletaGenerada.xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                if (cabecera != null)
                {
                    worksheet.Cells["B4"].Value = cabecera.nombre_empresa;
                    worksheet.Cells["B5"].Value = cabecera.direccion_empresa;
                    worksheet.Cells["H6"].Value = cabecera.ruc_empresa;

                }
                worksheet.Cells["B17"].Value = montoLetras;
                if (soloHospedaje)
                {
                    worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                    if (liquidar)
                        worksheet.Cells["M9"].Value = hospedaje + consumo + lavanderia - descuento + aumento;
                    else
                        worksheet.Cells["M9"].Value = acuenta;
                    if (lavanderia > 0)
                    {
                        worksheet.Cells["B10"].Value = "POR LAVANDERIA";
                        worksheet.Cells["M10"].Value = lavanderia;
                    }
                }
                else
                {
                    if (consumo > 0)
                    {
                        if (aumento > 0)
                        {
                            worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                            worksheet.Cells["M9"].Value = hospedaje + aumento;
                        }
                        else
                        {
                            if (chkConsumo.Checked)
                            {
                                worksheet.Cells["B9"].Value = "POR CONSUMO";
                                worksheet.Cells["M9"].Value = consumo;
                            }
                            else
                            {
                                worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                                worksheet.Cells["M9"].Value = hospedaje;
                            }

                        }
                        if (!chkConsumo.Checked)
                        {
                            worksheet.Cells["B10"].Value = "POR CONSUMO";
                            worksheet.Cells["M10"].Value = consumo;
                        }

                        if (lavanderia > 0)
                        {
                            worksheet.Cells["B11"].Value = "POR LAVANDERIA";
                            worksheet.Cells["M11"].Value = lavanderia;
                        }
                    }
                    else
                    {
                        worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                        if (liquidar)
                            worksheet.Cells["M9"].Value = hospedaje - descuento + aumento;
                        else
                            worksheet.Cells["M9"].Value = acuenta;
                        if (lavanderia > 0)
                        {
                            worksheet.Cells["B10"].Value = "POR LAVANDERIA";
                            worksheet.Cells["M10"].Value = lavanderia;
                        }

                    }
                }

                worksheet.View.PageLayoutView = false;

                package.Save();
            }
        }

        static void OpenMicrosoftExcel(string path)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "EXCEL.EXE";
            startInfo.Arguments = path;
            Process.Start(startInfo);
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            _oLiquidacionN = new LiquidacionNegocio();
            _oReservaN = new ReservaNegocio();
            _oLiquidacion = new Liquidacion();
            _ACuentaN = new MontoACuentaNegocio();
            decimal total = 0;
            decimal descuento = 0;
            decimal aumento = 0;
            bool liquidar = true;

            int grupoID = Grupo();
            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);

            FrmTipoPago frmTipoPago = new FrmTipoPago();
            if (frmTipoPago.ShowDialog(this) == DialogResult.OK)
            {
                _tipoPago = frmTipoPago.tipoPago;

            }

            if (_tipoPago == "F")
            {
                //LiquidarExcelFactura(_idGrupo, chkHospedaje.Checked, _total, decimal.Parse(lblConsumoTotal.Text), decimal.Parse(txtAumento.Text),
                //                                decimal.Parse(txtLavanderia.Text), decimal.Parse(txtDescuento.Text), montoCuenta, liquidar);
                
                //OpenMicrosoftExcel(@"D:\Excel\facturaGenerada.xlsx");

                if (MessageBox.Show("¿Desea continuar con el proceso de facturación? ", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PagarHospedaje(_tipoPago);
                    int idLiquidacion = _oLiquidacion.id_liquidacion;
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, true, TipoComprobate());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!chkConsumo.Checked)
                        {
                            ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                            var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                            foreach (var item in servicio)
                            {
                                oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                            }
                        }

                        if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _oReservaN.CancelarHospedaje(_idReserva);
                        }
                        else
                        {
                            if (chkConsumo.Checked)
                            {
                                ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                                var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                                foreach (var item in servicio)
                                {
                                    oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                                }
                            }
                        }



                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Proceso Detenido.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            else if (_tipoPago == "B")
            {
                decimal montoCuenta = 0;
                decimal _total = 0;

                if (cuenta.Count > 0 && decimal.Parse(lblNeto.Text) == 0)
                    montoCuenta = total;
                else
                    montoCuenta = decimal.Parse(lblACuenta.Text);


                var sum = cuenta.Sum(item => item.monto_acuenta);
                if (cuenta.Count == 0)
                    _total = decimal.Parse(lblHospedaje.Text);
                else
                    _total = sum.Value;

                LiquidarExcelBoleta(_idGrupo, chkHospedaje.Checked, _total, decimal.Parse(lblConsumoTotal.Text), decimal.Parse(txtAumento.Text),
                                decimal.Parse(txtLavanderia.Text), decimal.Parse(txtDescuento.Text), montoCuenta, liquidar);
                OpenMicrosoftExcel(@"D:\Excel\boletaGenerada.xlsx");

                if (MessageBox.Show("¿Desea continuar con el proceso? ", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PagarHospedaje(_tipoPago);
                    int idLiquidacion = _oLiquidacion.id_liquidacion;
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, true, TipoComprobate());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (!chkConsumo.Checked)
                        {
                            ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                            var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                            foreach (var item in servicio)
                            {
                                oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                            }
                        }

                        if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _oReservaN.CancelarHospedaje(_idReserva);
                        }
                        if (chkConsumo.Checked)
                        {
                            ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                            var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                            foreach (var item in servicio)
                            {
                                oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                            }
                        }
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Proceso Detenido.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            else
            {
                if (MessageBox.Show("¿Desea continuar con el proceso? ", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PagarHospedaje(_tipoPago);
                    MessageBox.Show("Operación realizada con éxito", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (!chkConsumo.Checked)
                    {
                        ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                        var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                        foreach (var item in servicio)
                        {
                            oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                        }
                    }

                    if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _oReservaN.CancelarHospedaje(_idReserva);
                    }
                    if (chkConsumo.Checked)
                    {
                        ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                        var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                        foreach (var item in servicio)
                        {
                            oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                        }
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("Proceso Detenido.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            if (decimal.Parse(lblNeto.Text) == 0 && TipoComprobate() == "T")
            {
                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


        }
        private decimal Adicional()
        {
            decimal adicional = 0;
            if (chkSoloFactura.Checked)
                adicional = decimal.Parse(lblNeto.Text)* decimal.Parse("0.20");
            return adicional;
        }

        private decimal IGV()
        {
            decimal subtotal = (DevuelveNumero(lblNeto.Text) / decimal.Parse("1.10"));
            decimal igv = DevuelveNumero(lblNeto.Text) - subtotal;
            return igv;
        }

        private decimal Subtotal()
        {
            decimal subtotal = (DevuelveNumero(lblNeto.Text) / decimal.Parse("1.10"));
            return subtotal;
        }

        private void txtAumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (chkAumento.Checked)
                {
                    if (chkHospedaje.Checked)
                    {
                        decimal nuevoTotal = DevuelveNumero(lblHospedaje.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                        lblNeto.Text = nuevoTotal.ToString();
                        lblTotal.Text = nuevoTotal.ToString();
                    }
                    else
                    {
                        decimal nuevoTotal = DevuelveNumero(lblHospedaje.Text) + decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                        lblNeto.Text = nuevoTotal.ToString();
                        lblTotal.Text = nuevoTotal.ToString();
                    }

                }
                else
                {
                    Totales();
                    decimal nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                    lblNeto.Text = nuevoTotal.ToString();
                }

            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _ACuentaN = new MontoACuentaNegocio();
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Totales();
                int grupo = Grupo();
                decimal nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);

                if (DevuelveNumero(lblNeto.Text) == 0)
                {
                    if (DevuelveNumero(txtDescuento.Text) == 0)
                    {
                        //(-1)*
                        decimal aDecimal = (decimal)_ACuentaN.SelectList(null, true).LastOrDefault(item => item.id_grupo == grupo && item.observacion_acuenta == "F").monto_acuenta;
                        _ACuentaN.Insert(Asignar(aDecimal, Grupo(), false));
                        lblNeto.Text = nuevoTotal.ToString();
                    }
                    else
                    {
                        decimal descuento = (-1) * DevuelveNumero(txtDescuento.Text);
                        _ACuentaN.Insert(Asignar(descuento, grupo, true));
                        lblNeto.Text = nuevoTotal.ToString();
                    }
                    CargarMontoACuenta(_codigoReserva);
                    Totales();
                }
                else
                {
                    nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                    lblNeto.Text = Math.Abs(nuevoTotal).ToString();
                }
            }
        }

        private void chkHuesped_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalSaldoPago = decimal.Parse(lblSaldoPago.Text);
            decimal totalNeto = decimal.Parse(lblNeto.Text);
            
            if (chkHospedaje.Checked)
            {
                lblNeto.Text = (totalNeto - totalSaldoPago).ToString();
                lblTotal.Text = (totalNeto - totalSaldoPago).ToString();
            }
            else
            {
                lblNeto.Text = (totalNeto + totalSaldoPago).ToString();
                lblTotal.Text = (totalNeto + totalSaldoPago).ToString();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            //_ACuentaN = new MontoACuentaNegocio();
            //int grupoID = Grupo();
            //var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);
            //if (cuenta.Count > 0)
            //{
            //    decimal montoACuenta = (decimal)cuenta.Sum(item => item.monto_acuenta);

            //    _oLiquidacionN = new LiquidacionNegocio();
            //    _oReservaN = new ReservaNegocio();
            //    _oLiquidacion = new Liquidacion();
                
            //    _oLiquidacion = Asignar(montoACuenta);
            //    _oLiquidacion.real_liquidacion = 0;
            //    _oLiquidacionN.Insert(_oLiquidacion);
  
            //    if (TipoComprobate() == "F")
            //    {
            //        ParcialExcel(_idGrupo, montoACuenta);
            //        OpenMicrosoftExcel(@"D:\Excel\facturaGenerada.xlsx");

            //        int idLiquidacion = _oLiquidacion.id_liquidacion;
            //        MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, false, TipoComprobate());
            //        if (frm.ShowDialog(this) == DialogResult.OK)
            //        {
            //            MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            if (DevuelveNumero(lblNeto.Text) == 0)
            //            {
            //                if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                {
            //                    _oReservaN.CancelarHospedaje(_idReserva);
            //                }
            //            }

            //            Close();
            //        }
            //    }
            //    else if (TipoComprobate() == "B")
            //    {
            //        int idLiquidacion = _oLiquidacion.id_liquidacion;
            //        MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, false, TipoComprobate());
            //        if (frm.ShowDialog(this) == DialogResult.OK)
            //        {
            //            MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            if (DevuelveNumero(lblNeto.Text) == 0)
            //            {
            //                if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //                {
            //                    _oReservaN.CancelarHospedaje(_idReserva);
            //                }
            //            }
            //            Close();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        if (DevuelveNumero(lblNeto.Text) == 0)
            //        {
            //            if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                _oReservaN.CancelarHospedaje(_idReserva);
            //            }
            //        }
            //        Close(); 
            //    }

            //}
            //else
            //{
            //    if(chkSoloFactura.Checked)
            //        MessageBox.Show("No puede realizar esta acción.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    else
            //        MessageBox.Show("No existen pagos parcial que facturar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //_oReservaN.CancelarHospedaje(_idReserva);
            //    Close();
            //}
        }

        private void FrmReservaFacturacion_Load(object sender, EventArgs e)
        {
            cargarFormaPago();
        }

        private void chkSoloFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoloFactura.Checked)
            {
                chkAumento.Enabled = false;
                chkHospedaje.Enabled = false;
            }
            else
            {
                chkAumento.Enabled = true;
                chkHospedaje.Enabled = true;
            }
        }

        private void rbtBoleta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PagarHospedaje(string _tipoDocumento)
        {
             _oLiquidacionN = new LiquidacionNegocio();
            _oReservaN = new ReservaNegocio();
            _oLiquidacion = new Liquidacion();
            _ACuentaN = new MontoACuentaNegocio();
            decimal real = 0;
            decimal total = 0;
            decimal adicional = 0;
            decimal descuento = 0;
            decimal consumo = 0;
            bool liquidar = true;
            int grupoID = Grupo();

            string montoEnCaja = "";
            bool cajaCerrada = true;

            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);
            #region Factura
            if (_tipoDocumento == "F")
            {
                if (chkSoloFactura.Checked)
                {
                    consumo = 0;
                    descuento = 0;
                    adicional = decimal.Parse(lblTotal.Text) * decimal.Parse("0.20");
                    real = 0;
                    total = decimal.Parse(lblTotal.Text);
                }
                else if (chkAumento.Checked)
                {
                    if (chkHospedaje.Checked)
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                        total =  decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text);
                    }
                    else
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                        total = decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text);
                    }

                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkHospedaje.Checked)
                {
                    consumo = decimal.Parse(lblConsumoTotal.Text);
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = decimal.Parse(lblTotal.Text) + adicional;
                    total = decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text) -decimal.Parse(txtDescuento.Text);
                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkConsumo.Checked)
                {
                    //SOLO CONSUMO
                    consumo = 0;
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = 0;
                    total = decimal.Parse(lblConsumoTotal.Text);
                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    consumo = decimal.Parse(lblConsumoTotal.Text);
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = decimal.Parse(lblHospedaje.Text) - descuento;
                    total = decimal.Parse(lblHospedaje.Text) - descuento + consumo + adicional;
                }
            }
            #endregion

            #region Boleta
            if (_tipoDocumento == "B")
            {
                if (chkAumento.Checked)
                {
                    if (chkHospedaje.Checked)
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);;
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text);
                        total = decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                    }
                    else
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text);
                        total = decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                    }

                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkHospedaje.Checked)
                {
                    consumo = decimal.Parse(lblConsumoTotal.Text); 
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text) + adicional;
                    total = decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text) -
                            decimal.Parse(txtDescuento.Text);
                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (chkConsumo.Checked)
                {
                    consumo = 0;
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = 0;
                    total = decimal.Parse(lblConsumoTotal.Text); ;
                    if (chkSoloFactura.Checked)
                    {
                        MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    consumo = decimal.Parse(lblConsumoTotal.Text);
                    descuento = decimal.Parse(txtDescuento.Text);
                    adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                    real = decimal.Parse(lblHospedaje.Text) - descuento;
                    total = decimal.Parse(lblHospedaje.Text) - descuento + consumo + adicional;
                }
            }
            #endregion

            #region Sin Comprobante
            if (_tipoDocumento == "T")
            {
                if (cuenta.Count == 0)
                {
                    if (decimal.Parse(lblNeto.Text) == 0)
                    {
                        consumo = 0;
                        descuento = 0;
                        adicional = 0;
                        real = 0;
                        total = 0;
                    }
                    else
                    {
                        if (chkConsumo.Checked)
                        {
                            consumo = decimal.Parse(lblConsumoTotal.Text);
                            descuento = 0;
                            adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                            real = 0;
                            total = consumo;
                        }
                        else
                        {
                            consumo = decimal.Parse(lblConsumoTotal.Text);
                            descuento = decimal.Parse(txtDescuento.Text);
                            adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                            real = decimal.Parse(lblHospedaje.Text) - descuento;
                            total = decimal.Parse(lblHospedaje.Text) - descuento + consumo + adicional;
                        }
                    }
                }
                else
                {
                    if (chkHospedaje.Checked)
                    {
                        consumo = 0;
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblTotal.Text) - decimal.Parse(txtDescuento.Text) + adicional;
                        total = decimal.Parse(lblTotal.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                        if (chkSoloFactura.Checked)
                        {
                            MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if (chkConsumo.Checked)
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = 0;
                        total = consumo;
                        if (chkSoloFactura.Checked)
                        {
                            MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        consumo = decimal.Parse(lblConsumoTotal.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                        real = decimal.Parse(lblHospedaje.Text) - descuento;
                        total = decimal.Parse(lblHospedaje.Text) - descuento + consumo + adicional;
                    }
                }

            }
            #endregion

            #region Esto SI funciona
            if (cuenta.Count == 1 && decimal.Parse(lblNeto.Text) == 0)
            {
                if (!chkAumento.Checked)
                {
                    var sum = cuenta.Sum(item => item.monto_acuenta);
                    if (sum != null)
                    {
                        total = sum.Value;
                        real = sum.Value;
                    }
                    _ACuentaN.Update(Asignar(total, grupoID, true));
                }

                if (cuenta.Count > 0)
                {
                    var montoACuenta = cuenta.SingleOrDefault();
                    if (montoACuenta != null) montoEnCaja = montoACuenta.observacion_acuenta;

                    if (montoACuenta != null && montoACuenta.caja_cerrada != null) cajaCerrada = (bool)montoACuenta.caja_cerrada;
                }

                _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, montoEnCaja, cajaCerrada, _tipoPago);
                _oLiquidacionN.Insert(_oLiquidacion);

                var singleOrDefault = cuenta.SingleOrDefault();
                if (singleOrDefault != null) _ACuentaN.MontoEnCaja(singleOrDefault.id);
            }
            else
            {
                if (cuenta.Count == 1)
                {
                    total = 0;
                    real = 0;
                    foreach (var item in cuenta)
                    {
                        total = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text);
                        real = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text);
                        if (item.monto_acuenta != null)
                            _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                    }

                    if (chkHospedaje.Checked)
                    {
                        total = total + decimal.Parse(txtAumento.Text);
                        real = real + adicional;
                    }
                    else
                    {
                        total = total + consumo + decimal.Parse(txtAumento.Text);
                        real = real + consumo + adicional;
                    }

                    _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, "PRUEBA", true, _tipoPago);
                    _oLiquidacionN.Insert(_oLiquidacion);
                }
                else
                {
                    decimal totalAcum = 0;
                    decimal realAcum = 0;
                    if (TipoComprobate() != "T" && total != 0)
                    {
                        total = 0;
                        real = 0;
                        var cuentaPago = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("F") && item.estado_acuenta == false);
                        if (cuentaPago.Count > 0)
                        {
                            if (chkConsumo.Checked)
                            {
                                totalAcum = decimal.Parse(lblConsumoTotal.Text);
                                realAcum = decimal.Parse(lblConsumoTotal.Text);
                                consumo = 0;
                                _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                _oLiquidacionN.Insert(_oLiquidacion);
                            }
                            else
                            {
                                consumo = 0;
                                descuento = decimal.Parse(txtDescuento.Text);
                                adicional = 0;
                                real = 0;
                                total = 0;

                                foreach (var item in cuenta)
                                {
                                    total = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text);
                                    real = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text);
                                    totalAcum = totalAcum + total;
                                    realAcum = realAcum + real;
                                    if (item.monto_acuenta != null)
                                        _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                                }
                                if (chkSoloFactura.Checked)
                                {
                                    consumo = 0;
                                    descuento = 0;
                                    adicional = decimal.Parse(lblHospedaje.Text) * decimal.Parse("0.20");
                                    real = decimal.Parse(lblHospedaje.Text);
                                    total = decimal.Parse(lblHospedaje.Text);
                                    _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }
                                else
                                {
                                    totalAcum = totalAcum + decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text);
                                    realAcum = realAcum + decimal.Parse(lblConsumoTotal.Text);
                                    _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in cuenta)
                            {
                                total = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text);
                                real = Convert.ToDecimal(item.monto_acuenta);// +decimal.Parse(lblConsumoTotal.Text);
                                totalAcum = totalAcum + total;
                                realAcum = realAcum + real;
                                if (item.monto_acuenta != null)
                                    _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                            }
                            if (chkSoloFactura.Checked)
                            {
                                consumo = 0;
                                descuento = 0;
                                adicional = decimal.Parse(lblHospedaje.Text) * decimal.Parse("0.20");
                                real = decimal.Parse(lblHospedaje.Text);
                                total = decimal.Parse(lblHospedaje.Text);
                                _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                _oLiquidacionN.Insert(_oLiquidacion);
                            }
                            else
                            {
                                if (chkHospedaje.Checked)
                                {
                                    consumo = 0;
                                    totalAcum = totalAcum + decimal.Parse(txtAumento.Text);
                                    realAcum = realAcum + decimal.Parse(lblConsumoTotal.Text);
                                    _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }
                                else
                                {
                                    totalAcum = totalAcum + decimal.Parse(lblConsumoTotal.Text) + decimal.Parse(txtAumento.Text);
                                    realAcum = realAcum + decimal.Parse(lblConsumoTotal.Text);
                                    _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoPago);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }

                            }
                        }
                    }
                }
            }
            #endregion

        }

        private void chkConsumo_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalSaldoPago = decimal.Parse(lblSaldoPago.Text);
            decimal hospedaje = decimal.Parse(lblHospedaje.Text);

            if (chkConsumo.Checked)
            {
                lblNeto.Text = (totalSaldoPago).ToString();
                lblTotal.Text = (totalSaldoPago).ToString();
            }
            else
            {
                lblNeto.Text = (hospedaje + totalSaldoPago).ToString();
                lblTotal.Text = (hospedaje + totalSaldoPago).ToString();
            }
        }

        private void btnMontoACuenta_Click(object sender, EventArgs e)
        {
            //FrmReservaACuenta frm = new FrmReservaACuenta(_numeroHabitacion, _idGrupo);
            //frm.ShowDialog();
            //lblACuenta.Text = MontoACuenta().ToString();
            //cargarFormaPago();
        }

        private decimal MontoACuenta()
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            int dni = _DNI;
            decimal monto = 0;
            var lista = objN.SelectList(item => item.id_grupo == _idGrupo && item.estado_acuenta == true && item.codigo_reserva == dni);
            foreach (var q in lista)
            {
                monto += decimal.Parse(q.monto_acuenta.ToString());
            }
            return monto;
        }

        private void lblACuenta_TextChanged(object sender, EventArgs e)
        {
            decimal neto = lblNeto.Text == "" ? 0 : decimal.Parse(lblNeto.Text) ;
            lblNeto.Text = (decimal.Parse(lblACuenta.Text) - neto).ToString();
        }

        private void FrmReservaFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void fGroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
