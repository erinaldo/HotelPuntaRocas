using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaNegocioExternos;
using OfficeOpenXml;
using Facturacion.Electronica.Aplicacion.UI;
using Facturacion.Electronica.Principal.Client;
using Facturacion.Electronica.Aplicacion.BE;
using Facturacion.Electronica.Aplicacion.BL;
using FE_CEMAFE.Service;
using FE_CEMAFE.Service.Model;
using PDFtoPrinter;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaPedidoFacturacion : Form
    {
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly decimal _igvValor = decimal.Parse(ConfigurationManager.AppSettings["igv"]);

        private readonly string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
        private readonly string token = ConfigurationManager.AppSettings["token"].ToString();
        private readonly string filePath = ConfigurationManager.AppSettings["pathFiles"].ToString();

        private readonly string printerName = ConfigurationManager.AppSettings["nombre_impresora"].ToString();        

        private ReservaDetalleNegocio _oReservaDetalleN;
        private Liquidacion _oLiquidacion;
        private LiquidacionNegocio _oLiquidacionN;
        private ReservaNegocio _oReservaN;
        private MontoACuentaNegocio _ACuentaN;
        private Monto_A_Cuenta oCuenta;

        private EntradaFacturaElectronica vEntradaFacturaElectronica;
        private List<DocumentoBE> vListDocumentoBE;

        private decimal _pago = 0, _noPago = 0;
        private readonly int _codigoReserva;
        private readonly int _idDetalleReserva;
        private readonly int _idHabitacion;
        private readonly int _idReserva;
        private readonly int _idGrupo;
        private readonly string _numeroHabitacion;
        private readonly int _DNI;
        private decimal consumoHabitacion = 0;
        private decimal hospedajeHabitacion = 0;

        private decimal totalOperacion = 0;
        private string emailHuesped = "";

        public FrmReservaPedidoFacturacion(int idDetalleReserva, int codigoReserva, int idHabitacion, int idReserva,
            string numeroHabitacion, int dni, DateTime fechaHotelera)
        {
            InitializeComponent();
            _idDetalleReserva = idDetalleReserva;
            _codigoReserva = codigoReserva;
            _idReserva = idReserva;
            _numeroHabitacion = numeroHabitacion;
            _idGrupo = Grupo();
            _idHabitacion = idHabitacion;
            CargarDatosPedidos(_codigoReserva, fechaHotelera);
            CargarDatosHotel(codigoReserva);
            CargarMontoACuenta(codigoReserva);
            DatosPersonalesHuesped(dni.ToString());
            Totales();
            this.vListDocumentoBE = new List<DocumentoBE>();
        }

        private void IniciarConfiguracion()
        {
            var vConexion = (ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            this.vEntradaFacturaElectronica = new EntradaFacturaElectronica("CALVARADO", vConexion, true);
        }

        private void DatosPersonalesHuesped(string _dniHuesped)
        {
            HuespedNegocio _huespedN = new HuespedNegocio();
            EmpresaNegocio _empresaN = new EmpresaNegocio();
            string dniHuesped = _dniHuesped;
            if (dniHuesped.Length == 7)
                dniHuesped = "0" + dniHuesped;
            else if (dniHuesped.Length == 6)
                dniHuesped = "00" + dniHuesped;
            else if (dniHuesped.Length == 5)
                dniHuesped = "000" + dniHuesped;
            else if (dniHuesped.Length == 4)
                dniHuesped = "0000" + dniHuesped;
            else if (dniHuesped.Length == 3)
                dniHuesped = "00000" + dniHuesped;
            else if (dniHuesped.Length == 2)
                dniHuesped = "000000" + dniHuesped;
            else if (dniHuesped.Length == 1)
                dniHuesped = "0000000" + dniHuesped;
            else
                dniHuesped = _dniHuesped;

            if (_huespedN.SelectCount(item => item.dni_huesped == dniHuesped) > 0)
            {
                var objHuesped = _huespedN.SelectSingle(item => item.dni_huesped == dniHuesped);

                txtCliente.Text = objHuesped.nombre_huesped + " " + objHuesped.paterno_huesped + " " +
                                  objHuesped.materno_huesped;
                txtDNI.Text = objHuesped.dni_huesped;

                emailHuesped = objHuesped.email_huesped;

                var idEmpresa = string.IsNullOrEmpty(objHuesped.id_empresa.ToString())
                    ? 0
                    : int.Parse(objHuesped.id_empresa.ToString());
                if (idEmpresa != 0)
                {
                    var objEmpresa = _empresaN.SelectSingle(item => item.id == idEmpresa);
                    txtRUC.Text = objEmpresa.ruc_empresa;
                    txtRazonSocial.Text = objEmpresa.nombre_empresa;
                    txtDireccion.Text = objEmpresa.direccion_empresa;
                }
            }

        }

        private void Totales()
        {
            if(chkConsumo.Checked)
            {
                txtTotalAPagar.Text = double.Parse(txtTotalConsumo.Text).ToString("F2");
            }
            else
            {
                txtTotalAPagar.Text = (double.Parse(txtTotalConsumo.Text) + double.Parse(txtTotalHospedaje.Text) - double.Parse(txtTotalACuenta.Text)).ToString("F2");
            }

            TotalFacturacion(double.Parse(txtTotalAPagar.Text));
        }

        private void TotalFacturacion(double totalAPagar)
        {
            double total, igv, subtotal;

            total = totalAPagar;
            subtotal = total / Convert.ToDouble(_igvValor);
            igv = Math.Round((total - subtotal), 2);

            txtTotalPedido.Text = total.ToString("F2");
            txtIGVPedido.Text = igv.ToString("F2");
            txtSubtotalPedido.Text = subtotal.ToString("F2");
        }

        private void TotalFacturacionGlobal(double totalAPagar)
        {
            double total, igv, subtotal;

            total = totalAPagar;
            subtotal = total / Convert.ToDouble(_igvValor);
            igv = Math.Round((total - subtotal), 2);

            txtTotalComprobante.Text = total.ToString("F2");
            txtIGVComprobante.Text = igv.ToString("F2");
            txtSubtotalComprobante.Text = subtotal.ToString("F2");
        }

        private int Grupo()
        {
            _oReservaN = new ReservaNegocio();
            var reservaFecha = _oReservaN.SelectSingle(item => item.id == _idReserva).grupo_reserva;
            if (reservaFecha != null) return reservaFecha.Value;
            return 0;
        }

        private void CargarDatosPedidos(int id, DateTime fechaHospedaje)
        {
            _oReservaDetalleN = new ReservaDetalleNegocio();
            var oPedidos = _oReservaDetalleN.ListaPedidosPorDNI(id).Where(item => item.id_habitacion == _idHabitacion);
            var sumPago = oPedidos.Sum(item => item.Pago);
            var sumNoPago = oPedidos.Sum(item => item.Debe);
            if (sumPago != null) _pago = (decimal) sumPago;
            if (sumNoPago != null) _noPago = (decimal) sumNoPago;
            txtTotalConsumo.Text = sumNoPago.ToString();
            consumoHabitacion = (decimal) sumNoPago;
        }

        private void CargarDatosHotel(int codigoReserva)
        {
            _oReservaDetalleN = new ReservaDetalleNegocio();
            var oDias = _oReservaDetalleN.ListaHospedaje(codigoReserva);
            var diasHospedaje =
                oDias.Count(item => item.id_habitacion == _idHabitacion && item.grupo_reserva == _idGrupo);
            var paPagarHospedajeResult = oDias.FirstOrDefault(item => item.grupo_reserva == _idGrupo);
            if (paPagarHospedajeResult != null)
            {
                var tarifa = paPagarHospedajeResult.precio_tarifa_habitacion;
                lblDiasDeHospedaje.Text = @"" + diasHospedaje;
                lblMontoTarifa.Text = tarifa.ToString();
                txtTotalHospedaje.Text = (diasHospedaje * tarifa).ToString();
                hospedajeHabitacion = Convert.ToDecimal(txtTotalHospedaje.Text);
            }
        }

        private void CargarMontoACuenta(int codigoReserva)
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            var estado = objN.SelectList(item => item.codigo_reserva == codigoReserva &&
                                                 item.id_habitacion == _idHabitacion);
            decimal monto = 0;
            foreach (var item in estado)
            {
                if (!item.observacion_acuenta.Contains("RETIRADO"))
                {
                    monto = monto + decimal.Parse(item.monto_acuenta.ToString());
                }
            }
            txtTotalACuenta.Text = monto.ToString();
        }

        private decimal CargarMontoACuentaPendiente(int codigoReserva)
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            var estado = objN.SelectList(item => item.codigo_reserva == codigoReserva &&
                                                 item.id_habitacion == _idHabitacion && 
                                                 item.estado_acuenta == true);
            decimal monto = 0;
            foreach (var item in estado)
            {
                if (!item.observacion_acuenta.Contains("RETIRADO"))
                {
                    monto = monto + decimal.Parse(item.monto_acuenta.ToString());
                }
            }
            return monto;
        }

        private string FormaPago()
        {
            return rbtTarjeta.Checked ? "T" : "E";
        }

        #region "Para el envio de correo electrónico"
        private void IniciarEnvio()
        {
            this.cboEnvio.ValueMember = "Codigo";
            this.cboEnvio.DisplayMember = "Nombre";
            List<EnvioBE> envio = ElectronicaBL.Instancia.GetEnvio();
            EnvioBE selectedItem = envio.FirstOrDefault<EnvioBE>();
            this.cboEnvio.DataSource = envio;
            this.cboEnvio.SelectedItem = selectedItem;
        }
        private void IniciarArchivo()
        {
            Functions.FacturacionElectronica oFacturacionElectronica = new Functions.FacturacionElectronica();
            this.cboArchivo.ValueMember = "Id";
            this.cboArchivo.DisplayMember = "Nombre";
            List<ArchivoBE> archivo = oFacturacionElectronica.GetArchivo("Bill");
            ArchivoBE selectedItem = archivo.FirstOrDefault<ArchivoBE>();
            this.cboArchivo.DataSource = archivo;
            this.cboArchivo.SelectedItem = selectedItem;
            cboArchivo.SelectedIndex = 5;
        }
        #endregion



        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            ActivarControles();
            CalcularMontoPago();
            IniciarConfiguracion();
            IniciarEnvio();
            IniciarArchivo();
            totalOperacion = CargarMontoACuentaPendiente(_codigoReserva) + consumoHabitacion;
            CargarTotalOperacion();
        }

        private void CargarTotalOperacion()
        {
            if(chkHospedaje.Checked)
            {
                txtTotalOperacion.Text = (CargarMontoACuentaPendiente(_codigoReserva)  - Convert.ToDecimal(txtDescuento.Text) + Convert.ToDecimal(txtSobreFactura.Text)).ToString();
            }
            else if (chkConsumo.Checked)
            {
                txtTotalOperacion.Text = (consumoHabitacion - Convert.ToDecimal(txtDescuento.Text) + Convert.ToDecimal(txtSobreFactura.Text)).ToString();
            }
            else
            {
                txtTotalOperacion.Text = (CargarMontoACuentaPendiente(_codigoReserva) + consumoHabitacion - Convert.ToDecimal(txtDescuento.Text) + Convert.ToDecimal(txtSobreFactura.Text)).ToString();
            }
        }

        private void CargarCorrelativo(string idTipoComprobante)
        {
            _oReservaN = new ReservaNegocio();
            var correlativos = _oReservaN.ObtenerCorrelativo(idTipoComprobante).SingleOrDefault();
            txtSerie.Text = correlativos.serie_comprobante;
            txtComprobante.Text = correlativos.correlativo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEfectivo.Checked)
            {
                lblReferencia.Visible = false;
                lblNTarjeta.Visible = false;
                txtReferencia.Visible = false;
                txtNTarjeta.Visible = false;

                txtReferencia.Text = "";
                txtNTarjeta.Text = "";
            }
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTarjeta.Checked)
            {
                lblReferencia.Visible = true;
                lblNTarjeta.Visible = true;
                txtReferencia.Visible = true;
                txtNTarjeta.Visible = true;
                txtReferencia.Text = "";
                txtNTarjeta.Text = "";
            }
        }

        private void fRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ActivarControles();
            CargarCorrelativo(Escoge());
        }

        public string Escoge()
        {
            if (rbtBoleta.Checked)
                return "03";
            if (rbtFactura.Checked)
                return "01";
            return "00";
        }

        private void ActivarControles()
        {
            if (rbtFactura.Checked)
            {
                lblDireccion.Visible = true;
                txtDireccion.Visible = true;
                lblRuc.Visible = true;
                txtRUC.Visible = true;
                lblRazonSocial.Visible = true;
                txtRazonSocial.Visible = true;
            }
            else
            {
                lblDireccion.Visible = false;
                txtDireccion.Visible = false;
                lblRazonSocial.Visible = false;
                txtRazonSocial.Visible = false;
                lblRuc.Visible = false;
                txtRUC.Visible = false;
            }
        }

        private void rbtBoleta_CheckedChanged(object sender, EventArgs e)
        {
            ActivarControles();
            CargarCorrelativo(Escoge());
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarHuesped(txtDNI.Text);
            }
        }

        private void BuscarHuesped(string dni)
        {
            HuespedNegocio huespedN = new HuespedNegocio();
            if (huespedN.SelectListViewConsulta(item => item.dni_huesped == dni).Count > 1)
            {
                MessageBox.Show("Existen Duplicado de DNI.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (huespedN.SelectCount(item => item.dni_huesped == dni) > 0)
            {
                var objHuesped = huespedN.SelectListViewConsulta(item => item.dni_huesped == dni).SingleOrDefault();
                if (objHuesped != null)
                {
                    txtCliente.Text = objHuesped.paterno_huesped + ' ' + objHuesped.materno_huesped + ' ' +
                                      objHuesped.nombre_huesped;
                    txtDireccion.Text = objHuesped.celular_huesped == "" ? "" : objHuesped.celular_huesped;
                    txtRazonSocial.Text = objHuesped.razon_social;
                    txtRUC.Text = objHuesped.ruc;
                }
            }
            else
            {
                MessageBox.Show("No existe el cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ActivarControles(true);
            }
        }

        private void ActivarControles(bool flag)
        {
            txtCliente.Enabled = flag;
            txtDireccion.Enabled = flag;
            txtRazonSocial.Enabled = flag;
            txtRUC.Enabled = flag;
        }

        private void FrmReservaPedidoFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void rbtSinComprobante_CheckedChanged(object sender, EventArgs e)
        {
            CargarCorrelativo(Escoge());
        }


        private void btnAgregaConcepto_Click(object sender, EventArgs e)
        {
            if (txtConcepto.Text == "" || txtConcepto.TextLength == 0)
            {
                MessageBox.Show("Registre correctamente un concepto.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtMonto.Text == "" || txtMonto.TextLength == 0)
            {
                MessageBox.Show("Registre correctamente el monto del concepto.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToDouble(txtMonto.Text) <= 0)
            {
                MessageBox.Show("Registre una cantidad mayor a 0.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idConcepto = 0;
            string descripcionConcepto = txtConcepto.Text.Trim().ToUpper();
            int cantidadConcepto = Convert.ToInt32(txtCantidad.Text.Trim());
            decimal montoConcepto = Convert.ToDecimal(txtMonto.Text);

            double sumatoria = 0;

            //if (dgvConceptoFacturacion.Rows.Count == 0)
            //{
            //    sumatoria += Convert.ToDouble(txtMonto.Text);
            //}

            foreach (DataGridViewRow row in dgvConceptoFacturacion.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells["totalConcepto"].Value);
            }

            sumatoria = sumatoria + Convert.ToDouble(txtMonto.Text);

            //if (sumatoria > Convert.ToDouble(txtTotalComprobante.Text))
            //{
            //    MessageBox.Show("Esta excediendo el monto total a pagar", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
                dgvConceptoFacturacion.Rows.Add(new Object[] { idConcepto, descripcionConcepto, cantidadConcepto, montoConcepto, (cantidadConcepto * montoConcepto) });
                sumatoria = 0;
                foreach (DataGridViewRow row in dgvConceptoFacturacion.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["totalConcepto"].Value);
                }
                lblTotalMonto.Text = "Monto Total S/." + sumatoria.ToString("F");
                lblTotalPedidos.Text = "Hay " + dgvConceptoFacturacion.RowCount + " concepto(s)";
            //}
            LimpiarIngreso();
        }

        private void LimpiarIngreso()
        {
            txtMonto.Text = "0";
            txtCantidad.Text = "1";
            txtConcepto.Text = "";
        }

        private void btnEliminarConcepto_Click(object sender, EventArgs e)
        {
            if (dgvConceptoFacturacion.RowCount > 0)
            {
                dgvConceptoFacturacion.Rows.RemoveAt(dgvConceptoFacturacion.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("No existen conceptos registrados.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double sumatoria = 0;
            foreach (DataGridViewRow row in dgvConceptoFacturacion.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells["TOTAL"].Value);
            }
            lblTotalMonto.Text = "Monto Total S/." + sumatoria.ToString("F");
            lblTotalPedidos.Text = "Hay " + dgvConceptoFacturacion.RowCount + " concepto(s)";
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
        public Liquidacion_Concepto AsignarConcepto(Liquidacion_Concepto xRow, int idLiquidacion)
        {
            var oLiquidacionConcepto = new Liquidacion_Concepto()
            {
                id_concepto = 0,
                id_liquidacion = idLiquidacion,
                id_tipo_liquidacion = xRow.id_tipo_liquidacion,
                descripcion_concepto =  xRow.descripcion_concepto,
                cantidad_concepto = xRow.cantidad_concepto,
                subtotal_precio_concepto = xRow.subtotal_precio_concepto,
                igv_precio_concepto = xRow.igv_precio_concepto,
                total_precio_concepto =  xRow.total_precio_concepto
            };
            return oLiquidacionConcepto;
        }
        private Liquidacion AsignarLiquidacion(decimal total, decimal real, decimal consumo, decimal descuento, decimal adicional,
                                       string montoEnCaja, bool estadoCaja, string _tipoDocumento)
        {

            total = total - descuento + consumo;
            real = real - descuento + consumo;

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
                tipo_comprobante_liquidacion = Escoge(),
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
            decimal sobreFactura = 0;
            bool liquidar = true;
            int grupoID = Grupo();

            string montoEnCaja = "";
            bool cajaCerrada = true;

            if (chkConsumo.Checked)
            {
                real = 0;
                total = 0;
                consumo = decimal.Parse(txtTotalConsumo.Text);
                descuento = 0; ;                

                _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, montoEnCaja, cajaCerrada, _tipoDocumento);
                _oLiquidacionN.Insert(_oLiquidacion);
            }
            else
            {
                var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);

                if (cuenta.Count > 0)
                {
                    real = decimal.Parse(txtTotalACuenta.Text);
                    total = decimal.Parse(txtTotalACuenta.Text);
                    descuento = decimal.Parse(txtDescuento.Text);
                    consumo = decimal.Parse(txtTotalConsumo.Text);

                    if (chkSobreFactura.Checked)
                    {
                        sobreFactura = decimal.Parse(txtSobreFactura.Text);
                        adicional = decimal.Parse(txtMontoSobreFactura.Text);
                        real = decimal.Parse(txtTotalACuenta.Text) + adicional;
                        total = decimal.Parse(txtTotalACuenta.Text) + decimal.Parse(txtSobreFactura.Text);
                    }
                }
                else
                {
                    if (decimal.Parse(txtTotalACuenta.Text) == 0)
                    {
                        real = decimal.Parse(txtTotalComprobante.Text);
                        total = decimal.Parse(txtTotalComprobante.Text);
                        descuento = decimal.Parse(txtDescuento.Text);
                        consumo = decimal.Parse(txtTotalConsumo.Text);
                    }


                    if (chkSobreFactura.Checked)
                    {
                        if (_tipoDocumento != "F")
                        {
                            MessageBox.Show("No puede realizar esta operacion.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (decimal.Parse(txtTotalACuenta.Text) == 0)
                        {
                            adicional = decimal.Parse(txtMontoSobreFactura.Text);
                            real = decimal.Parse(txtIngresoReal.Text) - adicional;
                        }
                    }
                }

                if (cuenta.Count == 1 && decimal.Parse(txtTotalACuenta.Text) != 0)
                {
                    foreach (var item in cuenta)
                    {
                        total = Convert.ToDecimal(item.monto_acuenta) + sobreFactura;
                        real = Convert.ToDecimal(item.monto_acuenta) + adicional;

                        if (item.monto_acuenta != null)
                            _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                    }

                    if (cuenta.Count > 0)
                    {
                        var montoACuenta = cuenta.SingleOrDefault();
                        if (montoACuenta != null) montoEnCaja = montoACuenta.observacion_acuenta;

                        if (montoACuenta != null && montoACuenta.caja_cerrada != null) cajaCerrada = (bool)montoACuenta.caja_cerrada;
                    }

                    _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, montoEnCaja, cajaCerrada, _tipoDocumento);
                    _oLiquidacionN.Insert(_oLiquidacion);

                    var singleOrDefault = cuenta.SingleOrDefault();
                    if (singleOrDefault != null) _ACuentaN.MontoEnCaja(singleOrDefault.id);
                }
                else
                {
                    if (cuenta.Count >= 1)
                    {
                        total = 0;
                        real = 0;
                        decimal auxTotal = 0;
                        decimal auxReal = 0;
                        foreach (var item in cuenta)
                        {
                            total = Convert.ToDecimal(item.monto_acuenta);
                            real = Convert.ToDecimal(item.monto_acuenta);
                            auxTotal = auxTotal + total;
                            auxReal = auxReal + total;
                            if (item.monto_acuenta != null)
                                _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                        }

                        total = auxTotal + decimal.Parse(txtMontoSobreFactura.Text);
                        real = auxReal + adicional;

                        _oLiquidacion = AsignarLiquidacion(total, real, consumo, descuento, adicional, "PRUEBA", true, _tipoDocumento);
                        _oLiquidacionN.Insert(_oLiquidacion);
                    }
                    else
                    {
                        decimal totalAcum = 0;
                        decimal realAcum = 0;
                        if (Escoge() != "O" && total != 0)
                        {
                            var cuentaPago = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("F") && item.estado_acuenta == false);
                            if (cuentaPago.Count > 0)
                            {
                                if (chkConsumo.Checked)
                                {
                                    totalAcum = decimal.Parse(txtTotalConsumo.Text);
                                    realAcum = decimal.Parse(txtTotalConsumo.Text);
                                    consumo = 0;
                                    _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoDocumento);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }
                                else
                                {
                                    consumo = 0;
                                    descuento = decimal.Parse(txtDescuento.Text);
                                    adicional = 0;

                                    foreach (var item in cuenta)
                                    {
                                        total = Convert.ToDecimal(item.monto_acuenta);
                                        real = Convert.ToDecimal(item.monto_acuenta);

                                        totalAcum = totalAcum + total;
                                        realAcum = realAcum + real;

                                        if (item.monto_acuenta != null)
                                            _ACuentaN.Update(Asignar(item.id, item.monto_acuenta.Value, grupoID, true));
                                    }

                                    totalAcum = totalAcum + decimal.Parse(txtMontoSobreFactura.Text);
                                    realAcum = realAcum;
                                    _oLiquidacion = AsignarLiquidacion(totalAcum, realAcum, consumo, descuento, adicional, "PRUEBA", false, _tipoDocumento);
                                    _oLiquidacionN.Insert(_oLiquidacion);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Operación Invalida, ingrese el monto a facturar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Operación Invalida, ya se realizo el cobro.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }          
        }

        private Monto_A_Cuenta Asignar(decimal monto, int grupo, bool flag)
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
                    referencia_acuenta = acuenta.referencia_acuenta,
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
                    fecha_registro = cajaCerrada.fecha_registro,
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
        private void btnPagar_Click(object sender, EventArgs e)
        {
            BillService rDocument = new BillService();
            Invoice rInvoice = new Invoice();
            Functions.FacturacionElectronica oFacturacionElectronica = new Functions.FacturacionElectronica();
        
            decimal subTotalGlobalComprobante = 0, igvGlobalComprobante = 0, totalGlobalComprobante = 0;
            string tipoDocumento = "";
            string rTipoDocumentoId = "";
            string tipoPago = "O";
            string leyendaMontoLetras = "";

            //if (emailHuesped.Length == 0 && Escoge() != "00") 
            //{

            //    MessageBox.Show("Registre un correo electrónico.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            int grupoID = Grupo();
            int idLiquidacion;

            var liquidacionConcepto = new LiquidacionConceptoNegocio();

            _oLiquidacionN = new LiquidacionNegocio();

            _oReservaN = new ReservaNegocio();
            _oLiquidacion = new Liquidacion();


            if (dgvConceptoFacturacion.Rows.Count == 0 && Escoge() != "00")
            {
                MessageBox.Show("Registre un concepto.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbtFactura.Checked)
            {
                if (txtRUC.Text == "" || txtRUC.Text.Length != 11)
                {
                    MessageBox.Show("No puede generar una factura a un cliente sin RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtCliente.Text == "")
            {
                MessageBox.Show("Ingrese el nombre del cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSerie.Text == "")
            {
                MessageBox.Show("Ingrese la serie del comprobante", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtComprobante.Text == "")
            {
                MessageBox.Show("Ingrese el número del comprobante", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Escoge() != "00")
            {
                if (Escoge() == "01")
                {
                    //FACTURA
                    tipoPago = "F";
                }

                if (Escoge() == "03")
                {
                    //BOLETA
                    tipoPago = "B";
                }
                PagarHospedaje(tipoPago);
                idLiquidacion = _oLiquidacion.id_liquidacion;
            }
            else
            {
                PagarHospedaje(tipoPago);
                idLiquidacion = _oLiquidacion.id_liquidacion;

                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _oLiquidacionN.ActualizarComprobante(idLiquidacion, txtSerie.Text.Trim(), txtComprobante.Text.Trim());

                if (Convert.ToDecimal(txtTotalConsumo.Text) != 0)
                {
                    if (MessageBox.Show("¿Desea cancelar el consumo?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                        var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                        foreach (var item in servicio)
                        {
                            oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                        }
                    }
                }

                if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _oReservaN.CancelarHospedaje(_idReserva);

                }
                this.Close();
                return;
            }


            if (idLiquidacion != 0)
            {
                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (DataGridViewRow row in dgvConceptoFacturacion.Rows)
                {
                    var oLiquidacionConcepto = new Liquidacion_Concepto();

                    var totalUnitario = Convert.ToDecimal(row.Cells["totalConcepto"].Value.ToString());
                    var cantidadUnitario = Convert.ToInt32(row.Cells["cantidadConcepto"].Value.ToString());

                    var subTotalUnitario = Math.Round((totalUnitario / _igvValor), 2, MidpointRounding.ToEven);
                    var igvTotalUnitario = Math.Round((totalUnitario - subTotalUnitario), 2, MidpointRounding.ToEven);

                    oLiquidacionConcepto.id_concepto = 0;
                    oLiquidacionConcepto.id_liquidacion = idLiquidacion;
                    oLiquidacionConcepto.id_tipo_liquidacion = "01";        //01 => TIPO LIQUIDACION -> HOTEL

                    oLiquidacionConcepto.descripcion_concepto = row.Cells["descripcionConcepto"].Value.ToString();
                    oLiquidacionConcepto.cantidad_concepto = Convert.ToInt32(row.Cells["cantidadConcepto"].Value.ToString());
                    oLiquidacionConcepto.subtotal_precio_concepto = subTotalUnitario;
                    oLiquidacionConcepto.igv_precio_concepto = totalUnitario - subTotalUnitario;
                    oLiquidacionConcepto.total_precio_concepto = totalUnitario;


                    subTotalGlobalComprobante += subTotalUnitario;
                    igvGlobalComprobante += igvTotalUnitario;
                    totalGlobalComprobante += totalUnitario;

                    liquidacionConcepto.Insert(oLiquidacionConcepto);
                }

                leyendaMontoLetras = liquidacionConcepto.Numeros_a_Letras(totalGlobalComprobante).SingleOrDefault();

                _oLiquidacionN.ActualizarComprobante(idLiquidacion, txtSerie.Text.Trim(), txtComprobante.Text.Trim());

                /*
                 * Nueva Version del Facturador
                 */
                var invoice = new InvoiceService();
                var cliente = new Cliente()
                {
                    NombreCliente = tipoPago == "F" ? txtRazonSocial.Text.Trim() : txtCliente.Text.Trim(),
                    //CodigoUbigeo = "-",
                    Correo = (emailHuesped.Length != 0 && Escoge() != "00") ? emailHuesped : "",
                    Direccion = txtDireccion.Text.Trim(),
                    NumeroDocumento = tipoPago == "F" ? txtRUC.Text.Trim() : txtDNI.Text.Trim(),
                    Telefono = "-",
                    TipoDocumentoIdentidad = tipoPago == "F" ? "6" : "1"
                };

                var documento = new Documento()
                {
                    SerieDocumento = txtSerie.Text.Trim(),
                    NumeroDocumento = Convert.ToInt32(txtComprobante.Text.Trim()).ToString(),
                    FechaEmision = DateTime.Now,
                    FormatoPDF = "a4",
                    EnviarCorreo = (emailHuesped.Length != 0 && Escoge() != "00"),
                    TipoDocumento = tipoPago == "F" ? "01" : "03",
                    RutaArchivoGenerado = filePath,
                    NumeroOrdenCompra = txtOrdenCompra.Text.Trim()
                };

                var productos = new List<FE_CEMAFE.Service.Model.Producto>();

                var conceptos = liquidacionConcepto.SelectList(item => item.id_liquidacion == idLiquidacion);
                int count = 1;
                foreach (var item in conceptos)
                {
                    var producto = new FE_CEMAFE.Service.Model.Producto()
                    {
                        CodigoInterno = string.Format("{0:000}", count),
                        Cantidad = item.cantidad_concepto,
                        ImpuestoICBPER = 0,
                        NombreProducto = item.descripcion_concepto,
                        PrecioUnitario = Convert.ToDouble(item.total_precio_concepto),
                        UnidadMedida = "ZZ"
                    };
                    productos.Add(producto);
                    count += 1;
                }

                var externalID = invoice.EnviarDocumentoSunat(baseUrl, token, cliente, documento, productos);

                if (externalID != "")
                {
                    var fileName = documento.SerieDocumento + '-' + documento.NumeroDocumento + ".pdf";
                    MessageBox.Show("Se genero correctamente el ExternalID " + externalID);

                    var pathPrint = String.Format("{0}/{1}", filePath, fileName);
                    var networkPrinterName = printerName;
                    var printTimeout = new TimeSpan(0, 30, 0);
                    var printer = new PDFtoPrinterPrinter();
                    printer.Print(new PrintingOptions(networkPrinterName, pathPrint), printTimeout);
                }
                /*
                 * Fin Nueva Version del Facturador
                 */

                /*
                //factura = 01 , boleta = 03
                if (tipoPago == "F")
                {
                    rTipoDocumentoId = "01";
                    rInvoice.Cliente_NumeroDocumento = txtRUC.Text.Trim();            // numero de ruc del cliente
                    rInvoice.Cliente_TipoDocumento = "6";                             // tipo documento cliente RUC = 6 , Dni = 1 
                    rInvoice.Cliente_RazonSocial = txtRazonSocial.Text.Trim();        // razon social del cliente
                    nombreDocumentoElectronico = "FACTURA";
                }
                else if(tipoPago == "B")
                {
                    rTipoDocumentoId = "03";
                    rInvoice.Cliente_NumeroDocumento = txtDNI.Text.Trim();            // numero de ruc del cliente
                    rInvoice.Cliente_TipoDocumento = "1";                             // tipo documento cliente RUC = 6 , Dni = 1 
                    rInvoice.Cliente_RazonSocial = txtCliente.Text.Trim();            // razon social del cliente
                    nombreDocumentoElectronico = "BOLETA";
                }                
                
                rInvoice.TipoDocumento = rTipoDocumentoId;
                rInvoice.Serie = txtSerie.Text.Trim();                                // Serie
                rInvoice.Numero = Convert.ToInt32(txtComprobante.Text.Trim());        // Correlativo
                rInvoice.FechaEmision = DateTime.Now;                                 // Fecha
                rInvoice.CodigoMoneda = "PEN";
                rInvoice.Leyenda_MontoLetra = leyendaMontoLetras;                     // Monto total
                rInvoice.Cliente_Direccion = txtDireccion.Text.Trim();                // Dirección del cliente
                rInvoice.TipoVenta = "01";                                            // Combo Tipo Venta

                rInvoice.TotalValorVentaOperacionGravada = subTotalGlobalComprobante; // TOTAL - IGV
                rInvoice.TotalValorVentaOperacionExonerada = 0M;
                rInvoice.TotalValorVentaOperacionInafecta = 0M;

                rInvoice.SumatoriaIGV = igvGlobalComprobante;                         // Igv
                rInvoice.PorcentajeIGV = 18M;                                         // Porcentaje del IGV
                rInvoice.ImporteTotalVenta = totalGlobalComprobante;                  // Total venta


                oFacturacionElectronica.InsertarDatoTributario( rInvoice.Serie,
                                                                rInvoice.Numero.ToString(),
                                                                rInvoice.TipoDocumento,
                                                                rInvoice.Cliente_NumeroDocumento,
                                                                rInvoice.Cliente_RazonSocial,
                                                                nombreDocumentoElectronico,
                                                                "001",                              // CodigoDestinoOperacion = "001"
                                                                "AFECTO",                           // DestinoOperacion = "AFECTO"
                                                                rInvoice.FechaEmision,
                                                                rInvoice.CodigoMoneda,
                                                                "sa",
                                                                "",
                                                                "",
                                                                "",
                                                                0,
                                                                DateTime.Now,
                                                                "01",                               // CodigoTipoVenta
                                                                "Normal",                           // TipoVenta
                                                                "",
                                                                "",
                                                                "",
                                                                rInvoice.ImporteTotalVenta);
                
                var rSubtotal = rInvoice.ImporteTotalVenta - rInvoice.SumatoriaIGV;
                oFacturacionElectronica.InsertarCabecera(3, rInvoice.Serie, rInvoice.Numero.ToString(), rInvoice.TipoDocumento, rInvoice.FechaEmision, 
                                                         rInvoice.Cliente_NumeroDocumento, rInvoice.Cliente_RazonSocial, rInvoice.Cliente_Direccion, rInvoice.TotalDescuento, 1, rSubtotal, rInvoice.SumatoriaIGV, rInvoice.ImporteTotalVenta, "PEN", "sa");

                */



                /*
                var lDetalleInvoice = new List<InvoiceLine>();            

                var detalleConceptos = liquidacionConcepto.SelectList(item => item.id_liquidacion == idLiquidacion);
                int contador = 1;
                foreach (var xRow in detalleConceptos)
                {
                    var rDetalleInvoice = new InvoiceLine
                    {
                        Articulo_Codigo = string.Format("{0:000}", contador),
                        Articulo_Nombre = xRow.descripcion_concepto,
                        UnidadMedida_Codigo = "ZZ",                                                // KGM
                        Cantidad = xRow.cantidad_concepto,
                        TipoAfectacionIGV = "10",

                        ValorVentaItem = xRow.subtotal_precio_concepto,
                        PrecioUnitario = xRow.total_precio_concepto,
                        ValorUnitario = (xRow.subtotal_precio_concepto / xRow.cantidad_concepto),
                        MontoIGVLinea = xRow.igv_precio_concepto
                    };
                    lDetalleInvoice.Add(rDetalleInvoice);
                    contador += 1;
                }
                rInvoice.Array_InvoiceLine = lDetalleInvoice.ToArray();

                foreach (var item in rInvoice.Array_InvoiceLine)
                {                    
                    oFacturacionElectronica.InsertarDetalle(3, 
                                                            rInvoice.Serie, 
                                                            rInvoice.Numero.ToString(), 
                                                            rInvoice.TipoDocumento, 
                                                            1, 
                                                            item.Articulo_Codigo,
                                                            item.Articulo_Nombre,
                                                            item.UnidadMedida_Codigo,
                                                            item.Cantidad,
                                                            item.ValorUnitario, 
                                                            1,
                                                            item.ValorVentaItem,
                                                            item.DescuentoItem);

                }
                oFacturacionElectronica.InsertarImpuesto(3, rInvoice.Serie, rInvoice.Numero.ToString(), rInvoice.TipoDocumento, rInvoice.SumatoriaIGV, 1, rSubtotal);

                //Firmar XML
                oFacturacionElectronica.InsertarFE("sa", rInvoice.TipoDocumento, rInvoice.Serie, rInvoice.Numero, true, 60);

                var rReturnValue = rDocument.Send_Bill(rInvoice, false, true, "");

                oFacturacionElectronica.InsertarEstado("sa", rInvoice.TipoDocumento, rInvoice.Serie, rInvoice.Numero, rReturnValue.XmlSignature_Request.FileNameZip, rReturnValue.XmlSignature_Request.OuterXml, rReturnValue.XmlSignature_Request.Document, rReturnValue.XmlSignature_Request.SummaryValue, rReturnValue.XmlSignature_Request.SignatureValue, rReturnValue.XmlSignature_Request.BarcodeText, rReturnValue.XmlSignature_Request.Barcode, null, rReturnValue.ResponseCode, rReturnValue.ResponseDescription, 60);
                //Firmar XML
                */
            }

            if (Convert.ToDecimal(txtTotalConsumo.Text) != 0)
            {
                if (MessageBox.Show("¿Desea cancelar el consumo?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                    var servicio = oServicio.SelectList(item => item.id_grupo == grupoID && item.estado_servicio_habitacion == true);
                    foreach (var item in servicio)
                    {
                        oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                    }
                }
            } 

            if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _oReservaN.CancelarHospedaje(_idReserva);

            }

            /*
            try
            {

                string rSerie = txtSerie.Text.Trim();
                int rNumero = Convert.ToInt32(txtComprobante.Text.Trim());
                DateTime date = DateTime.Now;
                DateTime date2 = DateTime.Now;
                List<DocumentoBE> documento = ElectronicaBL.Instancia.GetDocumento(date, date2, "", "", "", "", rTipoDocumentoId, rSerie, "", false, 60);

                this.vListDocumentoBE.Clear();
                this.vListDocumentoBE.AddRange(documento);

                List<DocumentoBE> list = (
                    from p in this.vListDocumentoBE
                    where p.Numero == rNumero
                    select p).ToList<DocumentoBE>();

                oFacturacionElectronica.ImprimirDocumento(vEntradaFacturaElectronica, list);

                if (emailHuesped.Length != 0 && Escoge() != "00")
                {
                    list[0].CorreoElectronico = emailHuesped;
                    list[0].MailCc = "puntarocashuacho@hotmail.com";
                    list[0].Marcado = true;
                    oFacturacionElectronica.EnviarCorreo(vEntradaFacturaElectronica, list, cboArchivo, cboEnvio);
                }
            }
            catch (Exception)
            {

                throw;
            }
            */
            Close();
        }

        private void chkConsumo_CheckedChanged(object sender, EventArgs e)
        {            
            if (chkConsumo.Checked)
            {
                if (Convert.ToDecimal(txtTotalConsumo.Text) == 0)
                {

                    MessageBox.Show("No existen consumos que cobrar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkConsumo.Checked = false;
                    return;
                }
                chkSobreFactura.Enabled = false;
                chkSobreFactura.Checked = false;

                chkAplicarDescuento.Enabled = false;
                chkAplicarDescuento.Checked = false;

                chkHospedaje.Enabled = false;
                chkHospedaje.Checked = false;

                txtTotalHospedaje.Text = "0";

                txtTotalOperacion.Text = consumoHabitacion.ToString();
            }
            else
            {
                chkSobreFactura.Checked = false;
                chkSobreFactura.Enabled = true;

                chkAplicarDescuento.Checked = false;
                chkAplicarDescuento.Enabled = true;

                chkHospedaje.Checked = false;
                chkHospedaje.Enabled = true;

                txtTotalHospedaje.Text = hospedajeHabitacion.ToString();
                CargarTotalOperacion();
            }

        }

        private void CalcularMontoPago()
        {
            try
            {
                if (Convert.ToDecimal(txtSobreFactura.Text) < 0)
                {
                    MessageBox.Show("Registre un monto mayor a 0.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSobreFactura.Text = "0";
                    return;
                }

                if (Convert.ToDecimal(txtDescuento.Text) < 0)
                {
                    MessageBox.Show("Registre un monto mayor a 0.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescuento.Text = "0";
                    return;
                }


                if (Convert.ToDecimal(txtSobreFactura.Text) > 0)
                {
                    txtTotalComprobante.Text = (Convert.ToDecimal(txtSobreFactura.Text) + Convert.ToDecimal(txtTotalAPagar.Text)).ToString("##.###");
                    txtMontoSobreFactura.Text = (Convert.ToDecimal(txtSobreFactura.Text) * Convert.ToDecimal("0.20")).ToString("##.###");
                    txtIngresoReal.Text = (Convert.ToDecimal(txtTotalAPagar.Text) + Convert.ToDecimal(txtMontoSobreFactura.Text)).ToString("##.###");
                }
                else if (Convert.ToDecimal(txtDescuento.Text) > 0)
                {

                    if (Convert.ToDecimal(txtTotalAPagar.Text) - Convert.ToDecimal(txtDescuento.Text) == 0)
                    {
                        txtTotalComprobante.Text = "0";
                    }
                    else
                    {
                        txtTotalComprobante.Text = (Convert.ToDecimal(txtTotalAPagar.Text) - Convert.ToDecimal(txtDescuento.Text)).ToString("##.###");
                    }
                }
                else
                {
                    txtTotalComprobante.Text = txtTotalAPagar.Text;
                    txtSobreFactura.Text = "0";
                    txtMontoSobreFactura.Text = "0";
                    txtDescuento.Text = "0";
                    txtIngresoReal.Text = txtTotalAPagar.Text;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                txtSobreFactura.Text = "0";
                txtDescuento.Text = "0";
                txtTotalComprobante.Text = txtTotalAPagar.Text;
            }
        }

        private void txtSobreFactura_TextChanged(object sender, EventArgs e)
        {
            CalcularMontoPago();
            CargarTotalOperacion();
        }

        private void txtTotalComprobante_TextChanged(object sender, EventArgs e)
        {
            TotalFacturacionGlobal(Convert.ToDouble(txtTotalComprobante.Text));
        }

        private void chkAplicarDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAplicarDescuento.Checked)
            {
                txtDescuento.Enabled = true;
                chkSobreFactura.Enabled = false;
                chkConsumo.Enabled = false;
                chkHospedaje.Enabled = false;
            }
            else
            {
                txtDescuento.Enabled = false;
                txtDescuento.Text = "0";
                chkAplicarDescuento.Checked = false;
                chkAplicarDescuento.Enabled = true;

                chkSobreFactura.Enabled = true;
                chkConsumo.Enabled = true;

                chkHospedaje.Checked = false;
                chkHospedaje.Enabled = true;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularMontoPago();
            CargarTotalOperacion();
        }

        private void chkHospedaje_CheckedChanged(object sender, EventArgs e)
        {

            if(chkHospedaje.Checked)
            {
                chkConsumo.Enabled = false;
                chkConsumo.Checked = false;
                txtTotalConsumo.Text = "0";
            }
            else
            {
                chkConsumo.Enabled = true;
                chkConsumo.Checked = false;
                txtTotalConsumo.Text = consumoHabitacion.ToString(); ;
            }
            CargarTotalOperacion();
        }

        private void txtTotalConsumo_TextChanged(object sender, EventArgs e)
        {
            Totales();
            txtTotalComprobante.Text = txtTotalPedido.Text;
        }

        private void txtTotalHospedaje_TextChanged(object sender, EventArgs e)
        {
            Totales();
            txtTotalComprobante.Text = txtTotalPedido.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        
        private void chkSobreFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSobreFactura.Checked)
            {
                txtSobreFactura.Enabled = true;
                chkConsumo.Checked = false;
                chkConsumo.Enabled = false;

                chkAplicarDescuento.Checked = false;
                chkAplicarDescuento.Enabled = false;

                txtMontoSobreFactura.Visible= true;
                lblMontoSobreFactura.Visible = true;

                txtIngresoReal.Visible = true;
                lblIngresoReal.Visible = true;
            }
            else
            {
                txtSobreFactura.Enabled = false;
                txtSobreFactura.Text = "0";

                txtIngresoReal.Text = "0";

                chkConsumo.Checked = false;
                chkConsumo.Enabled = true;

                chkAplicarDescuento.Checked = false;
                chkAplicarDescuento.Enabled = true;

                txtMontoSobreFactura.Visible = false;
                lblMontoSobreFactura.Visible = false;

                txtIngresoReal.Visible = false;
                lblIngresoReal.Visible = false;
            }
        }
    }
}