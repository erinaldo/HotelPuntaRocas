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
    public partial class FrmReservaPedidoRegistro : Form
    {
        /*
         * Lista de Estados 
         * Guinda       Reservas            (108, 19, 43)       5
         * Azul         Ocupado             (0,0,255)           6
         * Crema        Prereserva          (240,230,140)       7
        */

        private readonly int _idDetalleReserva;
        private readonly int _idReserva;

        private Consumo_habitacion _ConsumoHabitacionE;
        private ConsumoHabitacionNegocio _ConsumoHabitacionN;

        private ConsumoLiquidacionNegocio _LiquidacionConsumoN;
        private Liquidacion_Consumo _LiquidacionConsumo;

        private EntradaFacturaElectronica vEntradaFacturaElectronica;
        private List<DocumentoBE> vListDocumentoBE;

        private ProductoNegocio _producto;
        int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly decimal _igvValor = decimal.Parse(ConfigurationManager.AppSettings["igv"]);

        private readonly string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
        private readonly string token = ConfigurationManager.AppSettings["token"].ToString();
        private readonly string filePath = ConfigurationManager.AppSettings["pathFiles"].ToString();

        private readonly string printerName = ConfigurationManager.AppSettings["nombre_impresora"].ToString();
        
        private string emailHuesped = "";

        public FrmReservaPedidoRegistro()
        {
            InitializeComponent();
            this.vListDocumentoBE = new List<DocumentoBE>();
        }

        #region Abrir formulario solo una vez
        private static FrmReservaPedidoRegistro _mFormDefInstance;
        public static FrmReservaPedidoRegistro DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmReservaPedidoRegistro();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion
        private void CargarProductos()
        {
            _producto = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _producto.SelectListView(item => item.consumo == 1);
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
            CargarProductos();
            ActivarControles();
            IniciarConfiguracion();
            IniciarEnvio();
            IniciarArchivo();
            TipoCorrelativo();
        }

        private void IniciarConfiguracion()
        {
            var vConexion = (ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            this.vEntradaFacturaElectronica = new EntradaFacturaElectronica("CALVARADO", vConexion, true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Liquidacion_Consumo Asignar(decimal total,bool caja, bool consolidado, bool sobreFacturar)
        {

            decimal subtotal = 0;
            decimal igv = 0;
            subtotal = Math.Round((total / _igvValor), 2);
            igv = total - subtotal;

            _LiquidacionConsumo = new Liquidacion_Consumo()
            {
                id_caja_dia = _idCajaDia,
                cliente_liquidacion = txtCliente.Text.ToUpper().Trim(),
                dni_liquidacion = txtDNI.Text.Trim(),
                ruc_liquidacion = txtRUC.Text.Trim(),
                direccion_liquidacion = txtDireccion.Text.ToUpper().Trim(),
                razon_social_liquidacion = txtRazonSocial.Text.ToUpper().Trim(),
                tipo_comprobante_liquidacion = Escoge(),
                serie_liquidacion = txtSerie.Text,
                correlativo_liquidacion = txtComprobante.Text,
                fecha_liquidacion = dtpFecha.Value,
                sub_total_liquidacion = subtotal,
                igv_liquidacion = igv,
                total_liquidacion = total,
                consumo_liquidacion =  total,
                estado_tarjeta = false,
                estado_liquidacion = true,
                caja_liquidacion = caja,
                consolidado_liquidacion = consolidado,
                sobre_factura_liquidacion = sobreFacturar 
            };
            if (FormaPago() == "T")
            {
                _LiquidacionConsumo.forma_pago_liquidacion = "T";
                _LiquidacionConsumo.ntarjeta_liquidacion = txtNTarjeta.Text;
                _LiquidacionConsumo.referencia_liquidacion = txtReferencia.Text;
                _LiquidacionConsumo.estado_tarjeta = true;
            }
            else
            {
                _LiquidacionConsumo.forma_pago_liquidacion = "E";
            }
            return _LiquidacionConsumo;
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

        private void btnPagar_Click(object sender, EventArgs e)
        {
            BillService rDocument = new BillService();
            Invoice rInvoice = new Invoice();
            Functions.FacturacionElectronica oFacturacionElectronica = new Functions.FacturacionElectronica();

            
            LiquidacionNegocio _oLiquidacionN = new LiquidacionNegocio();
            decimal subTotalGlobalComprobante = 0, igvGlobalComprobante = 0, totalGlobalComprobante = 0;


            int longitudTipoDocumento = txtRUC.TextLength;
            string tipoDocumento = "";
            string rTipoDocumentoId = "";
            string tipoPago = "O";
            string leyendaMontoLetras = "";
            var liquidacionConcepto = new LiquidacionConceptoNegocio();


            //if (emailHuesped.Length == 0 && Escoge() != "00")
            //{
            //    MessageBox.Show("Registre un correo electrónico.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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

            if(rbtFactura.Checked)
            {
                if(txtRUC.Text == "" || txtRUC.Text.Length != 11)
                {
                    MessageBox.Show("No puede generar una factura a un cliente sin RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (dgvConceptoFacturacion.Rows.Count == 0 && Escoge() != "00")
            {
                MessageBox.Show("Registre un concepto.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (decimal.Parse(lblTotal.Text)> 0)
            {
                _LiquidacionConsumoN = new ConsumoLiquidacionNegocio();
                _LiquidacionConsumo = new Liquidacion_Consumo();
                _LiquidacionConsumo = Asignar(decimal.Parse(lblTotal.Text), chkCaja.Checked, chkConsolidado.Checked, chkSobreFacturar.Checked);
                _LiquidacionConsumoN.Insert(_LiquidacionConsumo);

                if (Escoge() != "00")
                {
                    tipoDocumento = longitudTipoDocumento == 8 ? "1" : "6";

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
                }

                int idLiquidacion = _LiquidacionConsumo.id_liquidacion;
                if (idLiquidacion != 0)
                {
                    MessageBox.Show("Registro de Venta registrado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (DataGridViewRow row in dgvConceptoFacturacion.Rows)
                    {
                        var oLiquidacionConcepto = new Liquidacion_Concepto();

                        var totalUnitario = Convert.ToDecimal(row.Cells["totalConcepto"].Value.ToString());

                        var subTotalUnitario = Math.Round((totalUnitario / _igvValor), 2, MidpointRounding.ToEven);
                        var igvTotalUnitario = Math.Round((totalUnitario - subTotalUnitario), 2, MidpointRounding.ToEven);

                        oLiquidacionConcepto.id_concepto = 0;
                        oLiquidacionConcepto.id_liquidacion = idLiquidacion;
                        oLiquidacionConcepto.id_tipo_liquidacion = "02";        //01 => TIPO LIQUIDACION -> REGISTRO

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

                    if(chkAutomatica.Checked)
                    {
                        _oLiquidacionN.ActualizarComprobante(idLiquidacion, txtSerie.Text.Trim(), txtComprobante.Text.Trim());
                    }

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
                    string nombreDocumentoElectronico = "";

                    //factura = 01 , boleta = 03
                    if (tipoPago == "F")
                    {
                        rTipoDocumentoId = "01";
                        rInvoice.Cliente_NumeroDocumento = txtRUC.Text.Trim();            // numero de ruc del cliente
                        rInvoice.Cliente_TipoDocumento = "6";                             // tipo documento cliente RUC = 6 , Dni = 1 
                        rInvoice.Cliente_RazonSocial = txtRazonSocial.Text.Trim();        // razon social del cliente
                        nombreDocumentoElectronico = "FACTURA";
                    }
                    else if (tipoPago == "B")
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
                    rInvoice.FechaEmision = dtpFecha.Value;                                 // Fecha
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


                    oFacturacionElectronica.InsertarDatoTributario(rInvoice.Serie,
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


                    var lDetalleInvoice = new List<InvoiceLine>();

                    var detalleConceptos = liquidacionConcepto.SelectList(item => item.id_liquidacion == idLiquidacion);
                    int contador = 1;
                    foreach (var xRow in detalleConceptos)
                    {
                        var rDetalleInvoice = new InvoiceLine
                        {
                            Articulo_Codigo = string.Format("{0:000}", contador),
                            Articulo_Nombre = xRow.descripcion_concepto,
                            UnidadMedida_Codigo = "ZZ",
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

                /*
                try
                {

                    string rSerie = txtSerie.Text.Trim();
                    int rNumero = Convert.ToInt32(txtComprobante.Text.Trim());
                    DateTime date = dtpFecha.Value.Date;
                    DateTime date2 = dtpFecha.Value.Date;
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

                this.Close();
            }
            else
            {
                MessageBox.Show("Debe de registrar un concepto", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        private void CargarCorrelativo(string idTipoComprobante)
        {
            ReservaNegocio _oReservaN = new ReservaNegocio();
            var correlativos = _oReservaN.ObtenerCorrelativo(idTipoComprobante).SingleOrDefault();
            txtSerie.Text = correlativos.serie_comprobante;
            txtComprobante.Text = correlativos.correlativo;
        }

        public string Escoge()
        {
            if (rbtBoleta.Checked)
                return "03";
            if (rbtFactura.Checked)
                return "01";
            return "00";
        }
        private void fRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CargarCorrelativo(Escoge());
            ActivarControles();

        }     
        private void ActivarControles()
        {
            if (rbtFactura.Checked)
            {
                lblDireccion.Visible = true;
                txtDireccion.Visible = true;
                lblRuc.Visible = true;
                txtRUC.Visible = true;

            }
            else
            {
                lblDireccion.Visible = false;
                txtDireccion.Visible = false;
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
                MessageBox.Show("Existen Duplicado de DNI.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (huespedN.SelectCount(item => item.dni_huesped == dni) > 0)
                {
                    var objHuesped = huespedN.SelectListViewConsulta(item => item.dni_huesped == dni).SingleOrDefault();
                    if (objHuesped != null)
                    {
                        txtCliente.Text = objHuesped.paterno_huesped + ' ' + objHuesped.materno_huesped + ' ' + objHuesped.nombre_huesped;
                        txtDireccion.Text = objHuesped.celular_huesped == "" ? "" : objHuesped.celular_huesped;
                        txtRazonSocial.Text = objHuesped.razon_social;
                        txtRUC.Text = objHuesped.ruc;
                        emailHuesped = objHuesped.email_huesped;
                    }
                }
                else
                {
                    MessageBox.Show("No existe el cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActivarControles(true);
                }
            }

        }
        private void ActivarControles(bool flag)
        {
            txtCliente.Enabled = flag;
            txtDireccion.Enabled = flag;
            txtRazonSocial.Enabled = flag;
            txtRUC.Enabled = flag;
        }

        private void FrmReservaPedidoRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void rbtSinComprobante_CheckedChanged(object sender, EventArgs e)
        {
            ActivarControles();
            CargarCorrelativo(Escoge());
        }

        private void chkSobreFacturar_CheckedChanged(object sender, EventArgs e)
        {

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
            lblTotal.Text = sumatoria.ToString("F");
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

        private void chkAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            TipoCorrelativo();
        }

        private void TipoCorrelativo()
        {
            if (chkAutomatica.Checked)
            {
                txtSerie.Enabled = false;
                txtComprobante.Enabled = false;
                CargarCorrelativo(Escoge());
            }
            else
            {
                txtSerie.Enabled = true;
                txtComprobante.Enabled = true;
            }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (Convert.ToInt32(e.KeyChar) == 13)
                {
                    PadronEmpresasNegocio PadronEmpresas = new PadronEmpresasNegocio();
                    var padron = PadronEmpresas.ConsultaEmpresa(txtRUC.Text.Trim()).SingleOrDefault();
                    if (padron != null)
                    {
                        if (padron.ESTADO_CONTRIBUYENTE == "ACTIVO")
                        {
                            if (padron.CONDICION_CONTRIBUYENTE == "HABIDO")
                            {
                                txtRazonSocial.Text = padron.RAZON_SOCIAL;
                                txtDireccion.Text = padron.DIRECCION;
                            }
                            else
                            {
                                MessageBox.Show("Contribuyente :" + padron.CONDICION_CONTRIBUYENTE, ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contribuyente :" + padron.ESTADO_CONTRIBUYENTE, ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empresa no Registrada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
