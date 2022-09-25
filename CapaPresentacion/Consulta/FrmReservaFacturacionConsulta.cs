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
    public partial class FrmReservaFacturacionConsulta : Form
    {
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly decimal _igvValor = decimal.Parse(ConfigurationManager.AppSettings["igv"]);

        private ReservaDetalleNegocio _oReservaDetalleN;
        private Liquidacion _oLiquidacion;
        private LiquidacionNegocio _oLiquidacionN;
        private ReservaNegocio _oReservaN;
        private MontoACuentaNegocio _ACuentaN;

        private decimal _pago = 0, _noPago = 0;
        private readonly int _codigoReserva;
        private readonly int _idDetalleReserva;
        private readonly int _idHabitacion;
        private readonly int _idReserva;
        private readonly int _idGrupo;

        private Liquidacion Asignar(decimal total)
        {
            decimal subtotal = 0;
            decimal igv = 0;
            subtotal = Math.Round((total/ _igvValor),2);
            igv = total - subtotal;

            decimal real = 0;
            decimal solo = 0;
            if (chkSoloFactura.Checked)
                real = (-1) * total;
            else
                if (chkHospedaje.Checked)
                    real = decimal.Parse(lblSaldoPago.Text) + decimal.Parse(txtLavanderia.Text);

            _oLiquidacion = new Liquidacion()
            {
                id_usuario = _idUsuario,
                id_caja_dia = _idCajaDia ,
                id_detalle_reserva = _idDetalleReserva,
                estado_liquidacion = true,
                tipo_comprobante_liquidacion = TipoComprobate(),
                forma_pago_liquidacion = FormaPago(),
                concepto_liquidacion = "",
                id_huesped = IdHuesped(_codigoReserva),
                cliente_liquidacion = Cliente(_codigoReserva),
                descuento_liquidacion = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text),
                fecha_liquidacion = DateTime.Now,
                igv_liquidacion = igv,
                total_liquidacion = total,
                sub_total_liquidacion = subtotal,
                real_liquidacion = total + real,
                ntarjeta_liquidacion = txtNTarjeta.Text ,
                referencia_liquidacion = txtReferencia .Text,
            };
            if (chkAumento.Checked)
                _oLiquidacion.aumento_liquidacion = Adicional();
            else if (chkSoloFactura.Checked)
                _oLiquidacion.aumento_liquidacion = Adicional();
            else
                _oLiquidacion.aumento_liquidacion = 0;
            if (rbtTarjeta.Checked)
                _oLiquidacion.estado_tarjeta = true;
            else
                _oLiquidacion.estado_tarjeta = false;
            return _oLiquidacion;
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
            var huesped = "";
            var huespedN = new HuespedNegocio();
            var vistaHuespedList = huespedN.SelectListView(item => item.dni_huesped == dni.ToString()).SingleOrDefault();
            if (vistaHuespedList != null)
                huesped = vistaHuespedList.completo_huesped;
            return huesped;
        }

        public FrmReservaFacturacionConsulta(int idDetalleReserva, int codigoReserva, int idHabitacion, int idReserva)
        {
            InitializeComponent();
            _idDetalleReserva = idDetalleReserva;
            _codigoReserva = codigoReserva;
            _idReserva = idReserva;
            _idGrupo = Grupo();
            _idHabitacion = idHabitacion;
            CargarDatosPedidos(_codigoReserva);
            CargarDatosHotel(codigoReserva);
            CargarMontoACuenta(codigoReserva);
            Totales();
        }

        private void CargarDatosPedidos(int id)
        {
            _oReservaDetalleN = new ReservaDetalleNegocio();
            var oPedidos = _oReservaDetalleN.ListaPedidosPorDNI(id).Where(item=> item.id_habitacion == _idHabitacion);
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
            var oDias = _oReservaDetalleN.ListaHospedajeHistorico(codigoReserva);
            string dniHuesped = "";
            var diasHospedaje = oDias.Count(item => item.id_habitacion == _idHabitacion && item.grupo_reserva == _idGrupo);
            if (codigoReserva.ToString().Length == 7)
                dniHuesped = "0" + codigoReserva.ToString();
            else
                dniHuesped = codigoReserva.ToString();
            var paPagarHospedajeResult = oDias.FirstOrDefault(item => item.codigo_reserva == dniHuesped &&
                                                                      item.id_habitacion == _idHabitacion && item.grupo_reserva == _idGrupo);
            if (paPagarHospedajeResult != null)
            {
                var tarifa = paPagarHospedajeResult.precio_tarifa_habitacion;
                lblDiasDeHospedaje.Text = @"        " + diasHospedaje;
                lblMontoTarifa.Text = tarifa.ToString();
                lblHospedaje.Text = (diasHospedaje * tarifa).ToString();
            }
        }
        
        private void CargarMontoACuenta(int codigoReserva)
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            var oMonto = objN.SelectList(item => item.codigo_reserva == codigoReserva && item.id_habitacion == _idHabitacion && item.estado_acuenta == true);
            var montoACuenta = oMonto.Sum(item => item.monto_acuenta);
            lblACuenta.Text = montoACuenta.ToString();
            Totales();
        }

        private void Totales()
        {
            lblTotal.Text = (DevuelveNumero(lblSaldoPago.Text) +DevuelveNumero(lblHospedaje.Text)).ToString();
            lblNeto.Text =(DevuelveNumero(lblTotal.Text) - DevuelveNumero(lblACuenta.Text)).ToString();
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
                txtAumento.Visible = true;
            else
                txtAumento.Visible = false;
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
            txtNTarjeta.Visible = true;
            txtReferencia.Visible = true;

            lblNTarjeta.Visible = true;
            lblReferencia.Visible = true;
        }

        private void LiquidarExcel(int idGrupo, bool soloHospedaje ,decimal hospedaje, decimal consumo, decimal aumento,
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
                totalMonto = hospedaje + consumo + lavanderia - descuento - acuenta + aumento;
            else
                totalMonto = acuenta;

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
                        worksheet.Cells["M9"].Value = hospedaje + consumo + lavanderia - descuento - acuenta + aumento;
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
                        worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                        worksheet.Cells["M9"].Value = hospedaje;
                        worksheet.Cells["B10"].Value = "POR CONSUMO";
                        worksheet.Cells["M10"].Value = consumo;
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
                            worksheet.Cells["M9"].Value = hospedaje + consumo + lavanderia - descuento - acuenta + aumento;
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
        private void ParcialExcel(int idGrupo, decimal hospedaje)
        {
            DirectoryInfo outputDir = new DirectoryInfo(@"D:\Excel");
            if (!outputDir.Exists) throw new Exception("Directorio de salida no existe");
            string output = "";
            FileInfo templateFile = new FileInfo(outputDir.FullName + @"\factura.xlsx");
            FileInfo newFile = new FileInfo(outputDir.FullName + @"\facturaGenerada.xlsx");

            decimal totalMonto = hospedaje;

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
                    worksheet.Cells["B17"].Value = montoLetras;
                }
                worksheet.Cells["B9"].Value = "POR HOSPEDAJE";
                worksheet.Cells["M9"].Value = hospedaje;
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
            _ACuentaN = new MontoACuentaNegocio();
            int grupoID = Grupo();
            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);



            if (chkSoloFactura.Checked)
            {
                if (TipoComprobate() == "F")
                {
                    total = decimal.Parse(lblNeto.Text);
                }
                else
                    return;
            }
            else
            {
                if (decimal.Parse(txtDescuento.Text) > 0)
                {
                    descuento = decimal.Parse(txtDescuento.Text);
                }

                if (chkAumento.Checked)
                {
                    aumento = decimal.Parse((txtAumento.Text));
                }

                if (_ACuentaN.SelectCount(item => item.id_grupo == _idGrupo && item.estado_acuenta == true) > 0)
                {
                    if (chkHospedaje.Checked)
                    {
                        total = decimal.Parse(lblTotal.Text) - decimal.Parse(lblSaldoPago.Text) -
                                decimal.Parse(lblACuenta.Text) - descuento + aumento;
                    }
                    else
                    {
                        total = decimal.Parse(lblTotal.Text) - decimal.Parse(lblACuenta.Text) - descuento + aumento;
                    }
                }
                else
                {
                    if (chkHospedaje.Checked)
                    {
                        total = decimal.Parse(lblTotal.Text) - decimal.Parse(lblSaldoPago.Text) -
                                decimal.Parse(lblACuenta.Text) - descuento + aumento;
                    }
                    else
                    {
                        total = decimal.Parse(lblTotal.Text) - decimal.Parse(lblACuenta.Text) - descuento + aumento;
                    }
                }
            }

            if (cuenta.Count > 0 && decimal.Parse(lblNeto.Text) == 0)
            {
                total = decimal.Parse(lblACuenta.Text);
                liquidar = false;
            }

            //if (lblNeto.Text == "0")


            if (decimal.Parse(lblNeto.Text) == 0 && TipoComprobate() != "F")
            {
                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _oLiquidacion = Asignar(total);
                _oLiquidacionN.Insert(_oLiquidacion);
                _oReservaN.CancelarHospedaje(_idReserva);
                Close();
                return;
            }
            _oLiquidacion = Asignar(total);
            _oLiquidacionN.Insert(_oLiquidacion);

            

            if (TipoComprobate() == "F")
            {
                LiquidarExcel(_idGrupo, chkHospedaje.Checked, decimal.Parse(lblHospedaje.Text), decimal.Parse(lblSaldoPago.Text), decimal.Parse(txtAumento.Text),
                                                decimal.Parse(txtLavanderia.Text), decimal.Parse(txtDescuento.Text), decimal.Parse(lblACuenta.Text), liquidar);
                OpenMicrosoftExcel(@"D:\Excel\facturaGenerada.xlsx");

                int idLiquidacion = _oLiquidacion.id_liquidacion;
                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, true, TipoComprobate());
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oReservaN.CancelarHospedaje(_idReserva);
                    Close();
                }
            }
            else if (TipoComprobate() == "B")
            {
                int idLiquidacion = _oLiquidacion.id_liquidacion;
                MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, true, TipoComprobate());
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oReservaN.CancelarHospedaje(_idReserva);
                    Close();
                }
            }


        }
        private decimal Adicional()
        {
            decimal adicional = 0;
            if (chkSoloFactura.Checked)
                adicional = decimal.Parse(lblNeto.Text)* decimal.Parse("0.20");
            else
                adicional = decimal.Parse(txtAumento.Text)* decimal.Parse("0.20");
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
                Totales();
                decimal nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                lblNeto.Text = nuevoTotal.ToString();
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Totales();
                decimal nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                lblNeto.Text = nuevoTotal.ToString();
            }
        }

        private void chkHuesped_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalSaldoPago = decimal.Parse(lblSaldoPago.Text);
            decimal totalNeto = decimal.Parse(lblNeto.Text);
            
            if (chkHospedaje.Checked)
            {
                lblNeto.Text = (totalNeto - totalSaldoPago).ToString();
            }
            else
            {
                lblNeto.Text = (totalNeto + totalSaldoPago).ToString();
            }
        }

        private void FrmReservaFacturacionConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            _ACuentaN = new MontoACuentaNegocio();
            int grupoID = Grupo();
            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);
            if (cuenta.Count > 0)
            {
                decimal montoACuenta = (decimal)cuenta.Sum(item => item.monto_acuenta);

                _oLiquidacionN = new LiquidacionNegocio();
                _oReservaN = new ReservaNegocio();
                _oLiquidacion = new Liquidacion();


                _oLiquidacion = Asignar(montoACuenta);
                _oLiquidacionN.Insert(_oLiquidacion);
  
                if (TipoComprobate() == "F")
                {
                    ParcialExcel(_idGrupo, montoACuenta);
                    OpenMicrosoftExcel(@"D:\Excel\facturaGenerada.xlsx");

                    int idLiquidacion = _oLiquidacion.id_liquidacion;
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, false, TipoComprobate());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_oReservaN.CancelarHospedaje(_idReserva);
                        Close();
                    }
                }
                else if (TipoComprobate() == "B")
                {
                    int idLiquidacion = _oLiquidacion.id_liquidacion;
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idReserva, false, TipoComprobate());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_oReservaN.CancelarHospedaje(_idReserva);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //_oReservaN.CancelarHospedaje(_idReserva);
                    Close();
                }

            }
            else
            {
                if(chkSoloFactura.Checked)
                    MessageBox.Show("No puede realizar esta acción.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("No existen pagos parcial que facturar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //_oReservaN.CancelarHospedaje(_idReserva);
                Close();
            }
        }
    }

}
