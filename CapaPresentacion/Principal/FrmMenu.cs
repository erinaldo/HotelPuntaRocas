using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Compra;
using CapaPresentacion.Configuracion;
using CapaPresentacion.Consulta;
using CapaPresentacion.Cronograma;
using CapaPresentacion.Flujo_Caja;
using CapaPresentacion.Functions;
using CapaPresentacion.Gestion;
using CapaPresentacion.Reporte.Formularios;
using CapaPresentacion.Reporte.Rpts;
using CapaPresentacion.Reporte.VistaPrevia;
using CapaPresentacion.Reserva;
using CapaPresentacion.Seguridad;
using CrystalDecisions.CrystalReports.Engine;
using CapaPresentacion.Ediciones;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;

namespace CapaPresentacion.Principal
{
    public partial class FrmMenu : Form
    {
        private QueryServer _serverN;
        private readonly string _usuario;
        private readonly DateTime _fechaActual = DateTime.Now.Date;
        private int _contador = 0;
        private string _permiso;
        int idUsuario;

        public FrmMenu(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void cargarPermiso()
        {
            RolNegocio oRolN = new RolNegocio();
            Rol oRol;
            UsuarioNegocio oUsuarioN = new UsuarioNegocio();
            int rol = oUsuarioN.SelectSingle(item => item.id == idUsuario).id_rol;
            oRol = oRolN.SelectSingle(q => q.estado_rol.Equals(true) && q.id_rol == rol);
            HabilitarPermisos(oRol.permiso_rol);

        }

        private void CargarParametros(string usuarioActivo)
        {
            _serverN = new QueryServer();
            lblFecha.Text = _serverN.GetTimeServer().ToLongDateString().ToUpper();
            lblHora.Text = _serverN.GetTimeServer().ToLongTimeString().ToUpper();
            lblUsuario.Text = usuarioActivo.ToUpper();
            lblImpresora.Text = ConfigurationManager.AppSettings["nombre_impresora"];
            lblCajaNumero.Text = ConfigurationManager.AppSettings["numero_caja"];
            idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        }

        #region CargarPermiso

        private void ActivarDesactivarMenu(ToolStripItemCollection item)
        {
            try
            {
                foreach (ToolStripItem i in item)
                {
                    // i.Enabled = false;
                    if (i is ToolStripMenuItem)
                    {
                        //*** Evaluamos condición para ver si se activa o no el control***
                        if ((_permiso.Substring(_contador, 1) == "1"))
                        {
                            i.Enabled = true;
                        }
                        else
                        {
                            i.Enabled = false;
                        }

                        //**********************
                        _contador++; //sumamos la cantidad de menus hijos 
                        if (((ToolStripMenuItem)i).DropDownItems.Count > 0)
                        {
                            ActivarDesactivarMenu(((ToolStripMenuItem)i).DropDownItems);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se agregó un nuevo menú, favor de configurarlo.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HabilitarPermisos(string _permiso)
        {
            this._permiso = _permiso;
            // Desactivo todos los menus
            foreach (ToolStripMenuItem tool in menuStrip1.Items)
            {
                //*** Evaluamos condición para ver si se activa o no el control***
                if ((this._permiso.Substring(_contador, 1) == "1"))
                {
                    tool.Enabled = true;
                }
                else
                {
                    tool.Enabled = false;
                }

                //**********************
                _contador++; //sumamos a la cuenta los menu padre
                if (tool.DropDownItems.Count > 0)
                {
                    ActivarDesactivarMenu(tool.DropDownItems);
                }
            }
        }

        #endregion

        private void AperturarCaja()
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (cajaDiaN.SelectCount(q => q.usuario_apertura == idUsuario &&
                                          q.id_caja == idCaja &&
                                          q.estado_apertura_caja_dia == true &&
                                          q.fecha_cierre == null) == 0)
            {
                MessageBox.Show("Debe de Aperturar caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                FrmApertura.DefInstance.MdiParent = this;
                FrmApertura.DefInstance.Show();
            }
            else
            {
                MessageBox.Show("La Caja ya ha sido aperturada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            CargarParametros(_usuario);
            cargarPermiso();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
            if (cajaDiaN.SelectCount(q => q.usuario_apertura == idUsuario &&
                                          q.id_caja == idCaja &&
                                          q.estado_apertura_caja_dia == true &&
                                          q.fecha_cierre == null) != 0)
            {
                MessageBox.Show("Existe una caja aperturada. No olvide cerrarla.", ".::. Sistema Hotelero .::.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (
                MessageBox.Show("¿Desea salir del sistema?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void TickSecond_Tick(object sender, EventArgs e)
        {
            CargarParametros(_usuario);
        }

        private void tsmUsuario_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmUsuario.DefInstance.MdiParent = this;
            FrmUsuario.DefInstance.Show();
        }

        private void stmHabitacion_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmHabitacion.DefInstance.MdiParent = this;
            FrmHabitacion.DefInstance.Show();
        }

        private void tsmProveedor_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmProveedor.DefInstance.MdiParent = this;
            FrmProveedor.DefInstance.Show();
        }

        private void tsmCategoriaProducto_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmCategoriaProducto.DefInstance.MdiParent = this;
            FrmCategoriaProducto.DefInstance.Show();
        }

        private void tsmProducto_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmProducto.DefInstance.MdiParent = this;
            FrmProducto.DefInstance.Show();
        }

        private void tsmNuevaCompra_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmCompra.DefInstance.MdiParent = this;
            FrmCompra.DefInstance.Show();
        }

        private void tsmApertura_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            AperturarCaja();
        }

        private void tsmCierre_Click(object sender, EventArgs e)
        {
            FrmConsultaReserva.DefInstance.Close();
            FrmReservaPanel.DefInstance.Close();

            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            UsuarioNegocio usuarioN = new UsuarioNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
            int idUsuarioApertura = 0;
            try
            {
                idUsuarioApertura = cajaDiaN.SelectSingle(q => q.estado_apertura_caja_dia == true &&
                                                   q.usuario_apertura == idUsuario &&
                                                   q.fecha_cierre == null).usuario_apertura;

            }
            catch (Exception)
            {
                MessageBox.Show("Aperture Caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string loginUsuario = usuarioN.SelectSingle(q => q.id == idUsuarioApertura).login_usuario;

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (idUsuario == idUsuarioApertura)
            {
                FrmCierre.DefInstance.MdiParent = this;
                FrmCierre.DefInstance.Show();
                
            }
            else
            {
                MessageBox.Show("La Caja no puede ser cerrada, pues el usuario " + loginUsuario +" fue quien aperturo.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmCajaMantenimiento_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmCaja.DefInstance.MdiParent = this;
            FrmCaja.DefInstance.Show();
        }

        private void tsmConcepto_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmConcepto.DefInstance.MdiParent = this;
            FrmConcepto.DefInstance.Show();
        }

        private void tsmTarifaHabitacion_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmTarifaHabitacion.DefInstance.MdiParent = this;
            FrmTarifaHabitacion.DefInstance.Show();
        }

        private void tsmRol_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmRol.DefInstance.MdiParent = this;
            FrmRol.DefInstance.Show();
        }

        private void tsmNuevaReserva_Click(object sender, EventArgs e)
        {
            FrmConsultaReserva.DefInstance.Close();
            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (cajaDiaN.SelectCount(q => q.usuario_apertura == idUsuario &&
                                      q.id_caja == idCaja &&
                                      q.estado_apertura_caja_dia == true &&
                                      q.fecha_cierre == null) == 0)
            {
                MessageBox.Show("Debe de Aperturar caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmApertura.DefInstance.MdiParent = this;
                FrmApertura.DefInstance.Show();
            }
            else
            {
                ReservaNegocio reservaN = new ReservaNegocio();
                int mes = DateTime.Now.Month;
                int filasGeneradas = reservaN.SelectCount(item=>item.fecha_hotelera.Value.Month ==mes);
                if (filasGeneradas > 0)
                {
                    FrmReservaPanel.DefInstance.MdiParent = this;
                    FrmReservaPanel.DefInstance.Show();
                }
                else
                {
                    MessageBox.Show("Debe de generar las reservas del mes ACTUAL.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmGenerar.DefInstance.MdiParent = this;
                    FrmGenerar.DefInstance.Show();
                }
            }
        }

        private void tsmEmpresa_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmEmpresa.DefInstance.MdiParent = this;
            FrmEmpresa.DefInstance.Show();
        }

        private void hUESPEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmHuesped.DefInstance.MdiParent = this;
            FrmHuesped.DefInstance.Show();
        }

        private void tsmConfigEgresos_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmConfCaja.DefInstance.MdiParent = this;
            FrmConfCaja.DefInstance.Show();
        }

        private void tsmConfigImpresora_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmConfImpresora.DefInstance.MdiParent = this;
            FrmConfImpresora.DefInstance.Show();

        }

        private void tsmCajaChica_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (cajaDiaN.SelectCount(q => q.usuario_apertura == idUsuario &&
                                      q.id_caja == idCaja &&
                                      q.estado_apertura_caja_dia == true &&
                                      q.fecha_cierre == null) == 0)
            {
                MessageBox.Show("Debe de Aperturar caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmApertura.DefInstance.MdiParent = this;
                FrmApertura.DefInstance.Show();
            }
            else
            {
                FrmEgreso.DefInstance.MdiParent = this;
                FrmEgreso.DefInstance.Show();
            }
        }

        private void tsmAperturarMes_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmGenerar.DefInstance.MdiParent = this;
            FrmGenerar.DefInstance.Show();
        }

        private void menuPagoTarjetas_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmConsultaTarjeta.DefInstance.MdiParent = this;
            FrmConsultaTarjeta.DefInstance.Show();
        }

        private void menuCheckInOut_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmConfCheck.DefInstance.MdiParent = this;
            FrmConfCheck.DefInstance.Show();
        }

        private void menuHabitaciones_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmHabitacionTarifa.DefInstance.MdiParent = this;
            FrmHabitacionTarifa.DefInstance.Show();
        }

        private void menuReservaHistoricas_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.MdiParent = this;
            FrmConsultaReserva.DefInstance.Show();
        }

        private void menuContador_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmReporteContador.DefInstance.MdiParent = this;
            FrmReporteContador.DefInstance.Show();
        }

        private void aNULARCOMPROBANTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmAnularComprobante.DefInstance.MdiParent = this;
            FrmAnularComprobante.DefInstance.Show();
        }

        private void menuConsolidado_Click(object sender, EventArgs e)
        {
            DolarNegocio oDolarNegocio = new DolarNegocio();
            int anio = int.Parse(ConfigurationManager.AppSettings["AnioHotel"]);

            var dolarValor = oDolarNegocio.SelectList(item => item.anio_dolar == anio.ToString() && item.estado_dolar).LastOrDefault().valor_dolar;
            var oLiquidacionNegocio = new LiquidacionNegocio();
            ReportDocument rpt = new ReporteBalance();
            if (oLiquidacionNegocio.GenerarBalance(anio, "1").ToList().Count > 0)
            {
                var oLista = ConvertToDataTable(oLiquidacionNegocio.GenerarBalance(anio, "1").OrderBy(item => item.NUMERO_MES).ToList());

                rpt.Database.Tables["DataTable1"].SetDataSource(oLiquidacionNegocio.GenerarBalance(anio, "1").OrderBy(item => item.NUMERO_MES));
                rpt.Database.Tables["DataTable2"].SetDataSource(oLiquidacionNegocio.GenerarBalanceResumen(anio, dolarValor).OrderBy(item => item.NUMERO_MES));
                rpt = FReportDocument.DocumentoReport(rpt, anio.ToString(), dolarValor);
                FrmVistaPrevia frm = new FrmVistaPrevia(rpt);
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen registros en la consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> list)
        {
            DataTable td = new DataTable();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.Name.Contains("FECHA"))
                {
                    td.Columns.Add(prop.Name, typeof(DateTime));
                }
                else
                {
                    td.Columns.Add(prop.Name);
                }
            }

            foreach (T item in list)
            {
                DataRow row = td.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                td.Rows.Add(row);
            }

            return td;
        }

        private void menuRegistroConsumo_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmReservaPedidoRegistro.DefInstance.MdiParent = this;
            FrmReservaPedidoRegistro.DefInstance.Show();
        }

        private void menuListadoMenu_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmAnularConsumo.DefInstance.MdiParent = this;
            FrmAnularConsumo.DefInstance.Show();
        }

        private void toolStripStatusLabel11_Click(object sender, EventArgs e)
        {
            FrmConfDolar.DefInstance.MdiParent = this;
            FrmConfDolar.DefInstance.Show();
        }

        private void FrmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void menuComprobanteConsumo_Click(object sender, EventArgs e)
        {
            FrmEdicionConsumo.DefInstance.MdiParent = this;
            FrmEdicionConsumo.DefInstance.Show();
        }

        private void menuComprobanteLiquidacion_Click(object sender, EventArgs e)
        {
            FrmEdicionLiquidacion.DefInstance.MdiParent = this;
            FrmEdicionLiquidacion.DefInstance.Show();
        }

        private void menuBackups_Click(object sender, EventArgs e)
        {
            LiquidacionNegocio oNegocio = new LiquidacionNegocio();
            oNegocio.GenerarBK();
            MessageBox.Show("Respaldo de Base de Datos generado con éxito.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuDNI_Duplicados_Click(object sender, EventArgs e)
        {
            FrmConsultaDNI.DefInstance.MdiParent = this;
            FrmConsultaDNI.DefInstance.Show();
        }

        private void menuEditarTarjetas_Click(object sender, EventArgs e)
        {
            FrmEdicionTarjeta.DefInstance.MdiParent = this;
            FrmEdicionTarjeta.DefInstance.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FrmConsultaReserva.DefInstance.Close();
            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (cajaDiaN.SelectCount(q => q.usuario_apertura == idUsuario &&
                                      q.id_caja == idCaja &&
                                      q.estado_apertura_caja_dia == true &&
                                      q.fecha_cierre == null) == 0)
            {
                MessageBox.Show("Debe de Aperturar caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmApertura.DefInstance.MdiParent = this;
                FrmApertura.DefInstance.Show();
            }
            else
            {
                ReservaNegocio reservaN = new ReservaNegocio();
                int mes = DateTime.Now.Month;
                int filasGeneradas = reservaN.SelectCount(item => item.fecha_hotelera.Value.Month == mes);
                if (filasGeneradas > 0)
                {
                    FrmReservaPanel.DefInstance.MdiParent = this;
                    FrmReservaPanel.DefInstance.Show();
                }
                else
                {
                    MessageBox.Show("Debe de generar las reservas del mes ACTUAL.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FrmGenerar.DefInstance.MdiParent = this;
                    FrmGenerar.DefInstance.Show();
                }
            }
        }

        private void menuFacturasEmitidas_Click(object sender, EventArgs e)
        {
            FrmFacturasEmitidas.DefInstance.MdiParent = this;
            FrmFacturasEmitidas.DefInstance.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            UsuarioNegocio oUsuario = new UsuarioNegocio();
            if (oUsuario.SelectSingle(item => item.id == idUsuario).id_rol == 2)
            {
                DolarNegocio oDolarNegocio = new DolarNegocio();
                int anio = int.Parse(ConfigurationManager.AppSettings["AnioHotel"]);

                var dolarValor = oDolarNegocio.SelectList(item => item.anio_dolar == anio.ToString() && item.estado_dolar).LastOrDefault().valor_dolar;
                var oLiquidacionNegocio = new LiquidacionNegocio();
                ReportDocument rpt = new ReporteBalance();
                if (oLiquidacionNegocio.GenerarBalance(anio, "1").ToList().Count > 0)
                {
                    rpt.Database.Tables["DataTable1"].SetDataSource(oLiquidacionNegocio.GenerarBalance(anio, "1").OrderBy(item => item.NUMERO_MES));
                    rpt.Database.Tables["DataTable2"].SetDataSource(oLiquidacionNegocio.GenerarBalanceResumen(anio, dolarValor).OrderBy(item => item.NUMERO_MES));
                    rpt = FReportDocument.DocumentoReport(rpt, anio.ToString(), dolarValor);
                    FrmVistaPrevia frm = new FrmVistaPrevia(rpt);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No existen registros en la consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Usted no posee acceso para esta opción.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmReporteContador.DefInstance.MdiParent = this;
            FrmReporteContador.DefInstance.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            FrmReservaPedidoRegistro.DefInstance.MdiParent = this;
            FrmReservaPedidoRegistro.DefInstance.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.MdiParent = this;
            FrmConsultaReserva.DefInstance.Show();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            FrmEdicionTarjeta.DefInstance.MdiParent = this;
            FrmEdicionTarjeta.DefInstance.Show();
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            FrmReservaPanel.DefInstance.Close();
            FrmConsultaReserva.DefInstance.Close();
            AperturarCaja();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            FrmConsultaReserva.DefInstance.Close();
            FrmReservaPanel.DefInstance.Close();

            CajaDiaNegocio cajaDiaN = new CajaDiaNegocio();
            UsuarioNegocio usuarioN = new UsuarioNegocio();
            int idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
            int idUsuarioApertura = 0;
            try
            {
                idUsuarioApertura = cajaDiaN.SelectSingle(q => q.estado_apertura_caja_dia == true &&
                                                   q.usuario_apertura == idUsuario &&
                                                   q.fecha_cierre == null).usuario_apertura;

            }
            catch (Exception)
            {
                MessageBox.Show("Aperture Caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string loginUsuario = usuarioN.SelectSingle(q => q.id == idUsuarioApertura).login_usuario;

            if (idCaja == 0)
            {
                MessageBox.Show("Asigne la caja a trabajar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmConfCaja.DefInstance.MdiParent = this;
                FrmConfCaja.DefInstance.Show();
                return;
            }

            if (idUsuario == idUsuarioApertura)
            {
                FrmCierre.DefInstance.MdiParent = this;
                FrmCierre.DefInstance.Show();

            }
            else
            {
                MessageBox.Show("La Caja no puede ser cerrada, pues el usuario " + loginUsuario + " fue quien aperturo.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cOMPROBANTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComprobante.DefInstance.MdiParent = this;
            FrmComprobante.DefInstance.Show();
        }
    }

}
