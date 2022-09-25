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
    public partial class FrmReservaUneFacturacion : Form
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

        private int[] _idGrupo;
        private decimal[] _monto;
        private decimal _hospedaje = 0;
        private decimal _consumo = 0;
        private int _dni;
        private Liquidacion Asignar(decimal total, int detalle, string montoEnCaja, bool estadoCaja)
        {
            
            decimal consumo = decimal.Parse(lblConsumo.Text);
            decimal adicional = 0;
            decimal lavanderia = decimal.Parse(txtLavanderia.Text);
            decimal real = total - consumo;
            if (chkHospedaje.Checked)
            {
                real = total;
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblConsumo.Text);
            }

            if (chkAumento.Checked)
            {
                real = total;
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblConsumo.Text);
                total = total + decimal.Parse(txtAumento.Text);
            }
            if (lavanderia > 0)
            {
                real = total + lavanderia;
                adicional = decimal.Parse(txtAumento.Text) * decimal.Parse("0.20");
                consumo = decimal.Parse(lblSaldoPago.Text);
                total = real;
            }

            decimal subtotal = 0;
            decimal igv = 0;
            subtotal = Math.Round((total / (decimal)1.10), 2);
            igv = total - subtotal;
            
            _oLiquidacion = new Liquidacion()
            {
                id_usuario = _idUsuario,
                id_caja_dia = _idCajaDia ,
                id_detalle_reserva = detalle,
                estado_liquidacion = true,
                tipo_comprobante_liquidacion = TipoComprobate(),
                forma_pago_liquidacion = FormaPago(),
                concepto_liquidacion = "",
                id_huesped = IdHuesped(_dni),
                cliente_liquidacion = Cliente(_dni),
                descuento_liquidacion = txtDescuento.Text == "" ? 0 : decimal.Parse(txtDescuento.Text),
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

        private Monto_A_Cuenta AsignarAcuenta(decimal monto, int grupo)
        {
            _oReservaN = new ReservaNegocio();
            var reserva = _oReservaN.SelectViewHabitacionesAlquiladas(item => item.grupo_reserva == grupo).FirstOrDefault();
            var acuenta = _ACuentaN.SelectList(item => item.id_grupo == grupo);
            Monto_A_Cuenta cajaCerrada = null;
            var montoACuenta = acuenta.SingleOrDefault();
            int _id = 0;
            if (montoACuenta != null)
            {
                _id = montoACuenta.id;
                cajaCerrada = _ACuentaN.SelectList(item => item.id == _id).SingleOrDefault();
            }
            if (reserva != null)
                
                 oCuenta = new Monto_A_Cuenta()
                {
                    id = _id,
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
                oCuenta.observacion_acuenta = "F";

                if (_idCajaDia == cajaCerrada.id_caja_dia)
                    oCuenta.caja_cerrada = false;
                else
                    oCuenta.caja_cerrada = true;
                return oCuenta;
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

        public FrmReservaUneFacturacion(int[] idGrupo, int dni, decimal hospedaje, decimal consumo, decimal[] montos )
        {
            InitializeComponent();
            _idGrupo = idGrupo;
            _monto = montos;
            _dni = dni;
            _hospedaje = hospedaje;
            _consumo = consumo;
            CargarDatos();
            Totales();
        }

        private void CargarDatos()
        {
            lblConsumo.Text = (_consumo).ToString("F");
            lblHospedaje.Text = _hospedaje.ToString("F");
            lblSaldoPago.Text = (_hospedaje + _consumo).ToString("F");
            lblNeto.Text = (_hospedaje + _consumo).ToString("F");
            txtDescuento.Text = 0.ToString("F");
        }


        private void Totales()
        {
            
            lblNeto.Text = (DevuelveNumero(lblSaldoPago.Text) - DevuelveNumero(txtDescuento.Text)+ DevuelveNumero(txtAumento.Text)).ToString();
        }

        private decimal DevuelveNumero(string texto)
        {
            try
            {
                return decimal.Parse(texto);
            }
            catch (Exception)
            {

                return 0;
            }

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
                                                                    decimal lavanderia, decimal descuento, bool liquidar)
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
                totalMonto = hospedaje;

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
                        worksheet.Cells["M9"].Value = hospedaje + consumo + lavanderia + aumento;
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
                        worksheet.Cells["M9"].Value = hospedaje+descuento-consumo;
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
                            worksheet.Cells["M9"].Value = hospedaje + lavanderia;
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

            if (TipoComprobate() == "F")
            {
                LiquidarExcel(_idGrupo[0], chkHospedaje.Checked, decimal.Parse(lblNeto.Text),
                    decimal.Parse(lblConsumo.Text), decimal.Parse(txtAumento.Text),
                    decimal.Parse(txtLavanderia.Text), decimal.Parse(txtDescuento.Text), true);
                OpenMicrosoftExcel(@"D:\Excel\facturaGenerada.xlsx");

                if (MessageBox.Show("¿Desea continuar con el proceso de facturación? ", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _oReservaDetalleN = new ReservaDetalleNegocio();
                    _oLiquidacionN = new LiquidacionNegocio();
                    _oReservaN = new ReservaNegocio();
                    _oLiquidacion = new Liquidacion();
                    _ACuentaN = new MontoACuentaNegocio();
                    decimal total = DevuelveNumero(lblNeto.Text);
                    decimal descuento = DevuelveNumero(txtDescuento.Text);
                    decimal aumento = DevuelveNumero(txtAumento.Text );
                    int grupoDetalle = _idGrupo[0];
                    int idDetalleReserva = _oReservaDetalleN.SelectList(item => item.id_grupo == grupoDetalle).FirstOrDefault().id;
                    var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoDetalle && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);

 
                    string montoEnCaja = "";
                    bool cajaCerrada = true;
                    if (cuenta.Count > 0)
                    {
                        var montoACuenta = cuenta.SingleOrDefault();
                        if (montoACuenta != null) montoEnCaja = montoACuenta.observacion_acuenta;

                        if (montoACuenta != null && montoACuenta.caja_cerrada != null) cajaCerrada = (bool)montoACuenta.caja_cerrada;
                    }

                    _oLiquidacion = Asignar(total - aumento, idDetalleReserva, montoEnCaja, cajaCerrada);
                    _oLiquidacionN.Insert(_oLiquidacion);

                    int idLiquidacion = _oLiquidacion.id_liquidacion;
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmReservaLiquidar frm = new FrmReservaLiquidar(idLiquidacion, _idGrupo[0], true, TipoComprobate());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        MessageBox.Show("Comprobante actualizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (MessageBox.Show("¿Desea Liquidar la habitación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{

                        for (int i = 0; i < _idGrupo.Length; i++)
                        {
                            //_oReservaN.CancelarHospedaje(_idGrupo[i]);
                            ServicioHabitacionNegocio oServicio = new ServicioHabitacionNegocio();
                            _ACuentaN = new MontoACuentaNegocio();
                            int grupo = _idGrupo[i];
                            decimal monto = _monto[i];
                            var servicio = oServicio.SelectList(item => item.id_grupo == grupo  && 
                                                                        item.estado_servicio_habitacion == true 
                                );                              
                            _ACuentaN.Update(AsignarAcuenta(monto, _idGrupo[i]));
                            foreach (var item in servicio)
                            {
                                oServicio.PagarServicio(item.id, _idUsuario, _idCajaDia, true);
                            }
                        }


                        //}
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Proceso Detenido.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        private decimal Adicional()
        {
            decimal adicional = 0;
            if (chkAumento.Checked)
                adicional = decimal.Parse(txtAumento.Text)* decimal.Parse("0.20");
            return adicional;
        }


        private void txtAumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Totales();
                decimal nuevoTotal = DevuelveNumero(lblSaldoPago.Text) + decimal.Parse(txtAumento.Text) - decimal.Parse(txtDescuento.Text);
                lblNeto.Text = nuevoTotal.ToString();
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            _ACuentaN = new MontoACuentaNegocio();
           if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Totales();
                decimal nuevoTotal = DevuelveNumero(lblNeto.Text) + decimal.Parse(txtAumento.Text);// - decimal.Parse(txtDescuento.Text);


                    if (DevuelveNumero(txtDescuento.Text) == 0)
                    {
                        CargarDatos();
                        return;
                    }

            }
        }

        private void chkHuesped_CheckedChanged(object sender, EventArgs e)
        {
            decimal totalConsumo = decimal.Parse(lblConsumo.Text);
            decimal totalNeto = decimal.Parse(lblNeto.Text);
            
            if (chkHospedaje.Checked)
            {
                lblNeto.Text = (totalNeto - totalConsumo).ToString();
            }
            else
            {
                lblNeto.Text = (totalNeto).ToString();
            }
        }

       private void FrmReservaFacturacion_Load(object sender, EventArgs e)
        {

        }

        private void FrmReservaUneFacturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

}
