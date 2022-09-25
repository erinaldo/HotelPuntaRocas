using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaNegocioExternos;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace CapaPresentacion.Reserva
{
    public partial class FrmHPrincipal : Form
    {
        /*
         * Lista de Estados 
         * Guinda       Reservas            (108, 19, 43)       5
         * Azul         Ocupado             (0,0,255)           6
        */

        private Huesped _huespedE;
        private HuespedNegocio _huespedN;

        private Empresa _empresaE;
        private EmpresaNegocio _empresaN;

        private HabitacionTarifaNegocio _tarifaN;

        private ReservaNegocio _reservaN;

        private Detalle_reserva _detalleReservaE;
        private ReservaDetalleNegocio _detalleReservaN;

        private CalificacionNegocio _calificacionN;

        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly string _horaOtroDia = ConfigurationManager.AppSettings["hora_otro_dia"];

        private readonly int _idReserva;
        private readonly int _idHabitacion;
        private readonly int _indice;
        private bool flag;
        public FrmHPrincipal(int idReserva, int idHabitacion, int indice, string numeroHabitacion)
        {
            InitializeComponent();
            _idReserva = idReserva;
            _idHabitacion = idHabitacion;
            _indice = indice;;
            fLabelBig1.Text += ": " + numeroHabitacion;
            FechasPorDefecto();
            CargarTarifas(idHabitacion);
        }

        private void PintarEstrellas(string dni)
        {
            _calificacionN = new CalificacionNegocio();

            if (_calificacionN.UltimaObservacion(dni).Count > 0)
            {
                var calificacion = _calificacionN.UltimaObservacion(dni).ToList();
                var ultimaObservacionResult = calificacion.SingleOrDefault();
                if (ultimaObservacionResult != null)
                    PintaEstrellas(ultimaObservacionResult.puntos_calificacion);
                var paUltimaObservacionResult = calificacion.SingleOrDefault();
                if (paUltimaObservacionResult != null)
                    txtUltimoComentario.Text = paUltimaObservacionResult.comentario_calificacion;
            }
            else
            {
                PintaEstrellas(0);
                //txtObservacion.Text = "AÚN NO HA SIDO CALIFICADA SU ESTANCIA.";
            }
        }
        private void PintaEstrellas(int est)
        {
            switch (est)
            {
                case 0:
                    s1.Visible = false;
                    s2.Visible = false;
                    s3.Visible = false;
                    s4.Visible = false;
                    s5.Visible = false;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 1:
                    s1.Visible = true;
                    s2.Visible = false;
                    s3.Visible = false;
                    s4.Visible = false;
                    s5.Visible = false;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 2:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = false;
                    s4.Visible = false;
                    s5.Visible = false;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 3:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = false;
                    s5.Visible = false;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 4:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = false;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 5:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = false;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 6:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = true;
                    s7.Visible = false;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 7:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = true;
                    s7.Visible = true;
                    s8.Visible = false;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 8:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = true;
                    s7.Visible = true;
                    s8.Visible = true;
                    s9.Visible = false;
                    s10.Visible = false;
                    break;
                case 9:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = true;
                    s7.Visible = true;
                    s8.Visible = true;
                    s9.Visible = true;
                    s10.Visible = false;
                    break;
                case 10:
                    s1.Visible = true;
                    s2.Visible = true;
                    s3.Visible = true;
                    s4.Visible = true;
                    s5.Visible = true;
                    s6.Visible = true;
                    s7.Visible = true;
                    s8.Visible = true;
                    s9.Visible = true;
                    s10.Visible = true;
                    break;
            };
        }
        private void CargarTarifas( int idHabitacion)
        {
            _tarifaN = new HabitacionTarifaNegocio();
            vistaHabitacionTarifaBindingSource.DataSource = _tarifaN.SelectListView(item => item.id_habitacion == idHabitacion);
        }
        private void FechasPorDefecto()
        {
            _reservaN = new ReservaNegocio();
            var reservaFecha = _reservaN.SelectSingle(item => item.id == _idReserva);
            dtpCalendario.SelectionStart = reservaFecha.fecha_hotelera.Value.Date;
            dtpCalendario.SelectionEnd = reservaFecha.fecha_hotelera.Value.Date;
        }
        private void btnReservar_Click(object sender, EventArgs e)
        {
            int reserva = 0;
            _detalleReservaN = new ReservaDetalleNegocio();
            _reservaN = new ReservaNegocio();
            DateTime fecha = dtpCalendario.SelectionStart.Date;
            int dias = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1);

            if (rbtNacion.Checked)
            {
                if (txtDNI.Text == "")
                {
                    MessageBox.Show("Debe de ingresar un DNI", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                if (txtExtranjero.Text == "")
                {
                    MessageBox.Show("Debe de ingresar un CARNET O PASAPORTE", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }

            ///
            /// Bloque para evitar la montada de las reservas
            /// 

            int dniHuesped = 0;
            if (rbtExtranjero.Checked)
                dniHuesped = int.Parse(txtExtranjero.Text.Trim());

            if (rbtNacion.Checked)
                dniHuesped = int.Parse(txtDNI.Text.Trim());

            for (int i = 0; i < dias; i++)
            {
                var fechaHotelera = fecha.AddDays(i);
                var reservaExiste = _reservaN.SelectCount(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fechaHotelera && item.fecha_ingreso == null && item.estado_habitacion_reserva == "2");
                if (reservaExiste == 0)
                {
                    MessageBox.Show("No puede registrar el hospedaje, habitación con fecha: " + fechaHotelera.Date.ToShortDateString() + " esta reservada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            for (int i = 0; i < dias; i++)
            {
                var fecha1 = fecha.AddDays(i);
                DateTime fechaSalida = DateTime.Parse(fecha1.AddDays(1).ToShortDateString() + " " + "12:00:00.000");
                reserva = _reservaN.SelectSingle(item => item.id_habitacion == _idHabitacion &&
                                                         item.fecha_hotelera == fecha1).id;
                _reservaN.RegistrarReservacion(reserva, int.Parse(cboTarifa.SelectedValue.ToString()), _idUsuario,
                                           false, "5",
                                           0, int.Parse(txtDNI.Text), _idReserva, txtObservacion.Text, fechaSalida);
                _detalleReservaN.Insert(AsignarDetalle(reserva));
                //Observacion(reserva, txtObservacion.Text.ToUpper().Trim());
            }
            if (txtAdelanto.Text != "")
                PagoACuenta();

            MessageBox.Show("Habitacion Reservada éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dtpCalendario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }
        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            ActivarControlesHuesped(false);
            txtDNI.Focus();
        }
        private void MostrarDetalles()
        {
            if (dtpCalendario.SelectionStart.Date < DateTime.Now.Date.AddDays(-1))
            {
                FechasPorDefecto();
                return;
            }

            lblInicio.Text = dtpCalendario.SelectionStart.ToShortDateString();
            lblFin.Text = dtpCalendario.SelectionEnd.AddDays(1).ToShortDateString();
            lblDias.Text = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1).ToString();
            lblTotal.Text = string.Format("{0:c}", (double.Parse(lblMonto.Text.Equals("") ? "0" : lblMonto.Text) * double.Parse(lblDias.Text.Equals("") ? "0" : lblDias.Text)));

        }
        private void cboTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }
        private void lblMonto_TextChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }

        private void ActivarControlesEmpresa(bool flag)
        {
            txtRUC.Enabled = flag;
            txtDireccion.Enabled = !flag;
            txtRazonSocial.Enabled = !flag;
        }
        private void ActivarControlesHuesped(bool flag)
        {
            txtNombre.Enabled = flag;
            txtPaterno.Enabled = flag;
            txtMaterno.Enabled = flag;
            txtCelular.Enabled = flag;
            txtRUC.Enabled = flag;
            txtDireccion.Enabled = flag;
            txtRazonSocial.Enabled = flag;
            txtCorreoElectronico.Enabled = flag;
        }
        private void LimpiarControlesHuesped()
        {
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtCelular.Clear();

        }

        private void LimpiarControlesEmpresa()
        {
            txtIdEmpresa.Clear();
            txtRUC.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
        }
        private Huesped RegistrarHuesped()
        {
            Huesped huespedE = new Huesped()
            {
                paterno_huesped = txtPaterno.Text.Trim().ToUpper(),
                materno_huesped = txtMaterno.Text.Trim().ToUpper(),
                nombre_huesped = txtNombre.Text.Trim().ToUpper(),
                dni_huesped = txtDNI.Text,
                celular_huesped = txtCelular.Text,
                email_huesped = txtCorreoElectronico.Text.Trim(),
                estado_huesped = true
            };

            _huespedN = new HuespedNegocio();
            EmpresaNegocio oEmpresaN = new EmpresaNegocio();

            if (_huespedN.SelectCount(item => item.dni_huesped == huespedE.dni_huesped) != 0)
            {
                var oHuesped = _huespedN.SelectSingle(item => item.dni_huesped == huespedE.dni_huesped);
                huespedE.id = oHuesped.id;
                txtIdEmpresa.Text = oHuesped.id_empresa.ToString();
            }
            var idEmpresa = 0;
            var dato = oEmpresaN.SelectCount(item => item.ruc_empresa == txtRUC.Text.Trim());
            if (dato != 0)
                idEmpresa = oEmpresaN.SelectSingle(item => item.ruc_empresa == txtRUC.Text.Trim()).id;

            if (idEmpresa != 0 && dato != 0)
            {
                huespedE.id_empresa = oEmpresaN.SelectSingle(item => item.ruc_empresa == txtRUC.Text).id;
                if (!flag)
                    EmpresaGraba(idEmpresa);
            }
            if (idEmpresa == 0 && txtRUC.Text != "")
            {
                txtIdEmpresa.Text = "";
                huespedE.id_empresa = EmpresaGraba(0);
            }

            var idHuesped = string.IsNullOrEmpty(txtIdHuesped.Text) ? 0 : int.Parse(txtIdHuesped.Text);

            return huespedE;
        }
        private Empresa RegistrarEmpresa(int id)
        {
            Empresa empresaE = new Empresa()
            {
                nombre_empresa = this.txtRazonSocial.Text.Trim(),
                ruc_empresa = this.txtRUC.Text.Trim(),
                direccion_empresa = this.txtDireccion.Text.Trim(),
                estado_empresa = true
            };
            int idEmpresa = id;
            if (idEmpresa != 0)
                empresaE.id = id;
            else
                empresaE.id = 0;
            return empresaE;
        }
        private void BuscarHuesped(string dni)
        {
            _huespedN = new HuespedNegocio();
            _empresaN = new EmpresaNegocio();
            if (rbtNacion.Checked)
            {
                if (_huespedN.SelectCount(item => item.dni_huesped == dni) > 0)
                {
                    var objHuesped = _huespedN.SelectSingle(item => item.dni_huesped == dni);
                    txtPaterno.Text = objHuesped.paterno_huesped;
                    txtMaterno.Text = objHuesped.materno_huesped;
                    txtNombre.Text = objHuesped.nombre_huesped;
                    txtCelular.Text = objHuesped.celular_huesped == "" ? "" : objHuesped.celular_huesped;
                    txtIdHuesped.Text = objHuesped.id.ToString();
                    txtCorreoElectronico.Text = objHuesped.email_huesped.ToString();
                    var idEmpresa = string.IsNullOrEmpty(objHuesped.id_empresa.ToString()) ? 0 : int.Parse(objHuesped.id_empresa.ToString());
                    if (idEmpresa != 0)
                    {

                        var objEmpresa = _empresaN.SelectSingle(item => item.id == idEmpresa);
                        txtIdEmpresa.Text = objEmpresa.id.ToString();
                        txtRUC.Text = objEmpresa.ruc_empresa;
                        txtRazonSocial.Text = objEmpresa.nombre_empresa;
                        txtDireccion.Text = objEmpresa.direccion_empresa;
                        ckbEmpresa.Checked = true;
                        ActivarControlesHuesped(false);
                    }
                    else
                    {

                        if (MessageBox.Show("¿Desea vincular el huesped a una Empresa?", ".::. Sistema Hotelero .::.",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ckbEmpresa.Checked = true;
                            LimpiarControlesEmpresa();
                            ActivarControlesEmpresa(true);
                            txtRUC.Focus();
                        }
                    }
                }
                else
                {
                    ckbEmpresa.Checked = false;
                    MessageBox.Show("No existe el cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActivarControlesHuesped(true);
                    ActivarControlesEmpresa(false);
                    LimpiarControlesHuesped();
                    LimpiarControlesEmpresa();
                    txtPaterno.Focus();
                }
            }
            else
            {
                if (_huespedN.SelectCount(item => item.documento_extranjero == txtExtranjero.Text.Trim()) > 0)
                {
                    dni = _huespedN.SelectSingle(item => item.documento_extranjero == txtExtranjero.Text.Trim()).dni_huesped;
                    if (_huespedN.SelectCount(item => item.dni_huesped == dni) > 0)
                    {
                        var objHuesped = _huespedN.SelectSingle(item => item.dni_huesped == dni);
                        txtPaterno.Text = objHuesped.paterno_huesped;
                        txtMaterno.Text = objHuesped.materno_huesped;
                        txtNombre.Text = objHuesped.nombre_huesped;
                        txtCelular.Text = objHuesped.celular_huesped == "" ? "" : objHuesped.celular_huesped;
                        txtIdHuesped.Text = objHuesped.id.ToString();
                        txtDNI.Text = objHuesped.dni_huesped.ToString();
                        var idEmpresa = string.IsNullOrEmpty(objHuesped.id_empresa.ToString()) ? 0 : int.Parse(objHuesped.id_empresa.ToString());
                        if (idEmpresa != 0)
                        {

                            var objEmpresa = _empresaN.SelectSingle(item => item.id == idEmpresa);
                            txtIdEmpresa.Text = objEmpresa.id.ToString();
                            txtRUC.Text = objEmpresa.ruc_empresa;
                            txtRazonSocial.Text = objEmpresa.nombre_empresa;
                            txtDireccion.Text = objEmpresa.direccion_empresa;                            
                            ckbEmpresa.Checked = true;
                            ActivarControlesHuesped(false);
                        }
                        else
                        {

                            if (MessageBox.Show("¿Desea vincular el huesped a una Empresa?", ".::. Sistema Hotelero .::.",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ckbEmpresa.Checked = true;
                                LimpiarControlesEmpresa();
                                ActivarControlesEmpresa(true);
                                txtRUC.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe el cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActivarControlesHuesped(true);
                        ActivarControlesEmpresa(false);
                        LimpiarControlesHuesped();
                        LimpiarControlesEmpresa();
                        txtPaterno.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No existe el cliente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActivarControlesHuesped(true);
                    ActivarControlesEmpresa(false);
                    LimpiarControlesHuesped();
                    LimpiarControlesEmpresa();
                    txtPaterno.Focus();
                }
            }
        }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                if (txtDNI.Text.Length == 8)
                {
                    BuscarHuesped(txtDNI.Text);
                    PintarEstrellas(txtDNI.Text);
                }
                else
                {
                    MessageBox.Show("Ingrese 8 digitos por favor.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
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
        private void BuscarEmpresa(string ruc)
        {
            _empresaN = new EmpresaNegocio();
            if (_empresaN.SelectCount(item => item.ruc_empresa == ruc) > 0)
            {
                var objEmpresa = _empresaN.SelectSingle(item => item.ruc_empresa == ruc);
                txtIdEmpresa.Text = objEmpresa.id.ToString();
                txtRUC.Text = objEmpresa.ruc_empresa;
                txtRazonSocial.Text = objEmpresa.nombre_empresa;
                txtDireccion.Text = objEmpresa.direccion_empresa;
                ActivarControlesEmpresa(false);
            }
            else
            {
                MessageBox.Show("No existe la empresa.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRazonSocial.Clear();
                txtDireccion.Clear();
                txtIdEmpresa.Clear();
                txtRazonSocial.Focus();
                ActivarControlesEmpresa(false);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpCalendario.SelectionStart.Date;
            DateTime ultimoDia = dtpCalendario.SelectionEnd.Date;
            _reservaN = new ReservaNegocio();
            _detalleReservaN = new ReservaDetalleNegocio();

            DateTime fecha_checkIn = DateTime.Now;
            string fecha_In  = DateTime.Now.Date.ToShortDateString();
            DateTime fecha_compara = DateTime.Parse(fecha_In + " " + "04:59:59 am");// _horaOtroDia);
            int diferencia = DateTime.Compare(fecha_checkIn, fecha_compara);

            var diasGenerados = _reservaN.SelectCount(item => item.fecha_hotelera == ultimoDia);



            if (rbtNacion.Checked)
            {
                if (txtDNI.Text == "")
                {
                    MessageBox.Show("Debe de ingresar un DNI", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                if (txtExtranjero.Text == "")
                {
                    MessageBox.Show("Debe de ingresar un CARNET O PASAPORTE", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }

            if (diasGenerados == 0)
            {
                MessageBox.Show("No se puede realizar la operación. Día no generado..", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ///
            /// Bloque para evitar la montada de las reservas
            /// 
            int dias_validacion = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1);
            int dniHuesped = 0;

            dniHuesped = int.Parse(txtDNI.Text.Trim());

            for (int i = 0; i < dias_validacion; i++)
            {
                var fechaHotelera = fecha.AddDays(i);
                var reservaExiste = _reservaN.SelectCount(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fechaHotelera && item.fecha_ingreso == null && item.estado_habitacion_reserva == "2");
                if (reservaExiste != 1)
                {
                    MessageBox.Show("No puede registrar el hospedaje, habitación con fecha: " + fechaHotelera.Date.ToShortDateString() + " esta reservada.", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            if (diferencia < 0)
            {
                //6 ocupado
                //if (dtpCalendario.SelectionEnd.Date == DateTime.Now.Date)
                //{
                    int dias = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1);
                    for (int i = 0; i < dias; i++)
                    {
                        var fecha1 = fecha.AddDays(i);
                        DateTime fechaSalida = DateTime.Parse(fecha_In + " " + "12:00:00.000");
                        var reserva =
                            _reservaN.SelectSingle(
                                item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fecha1).id;

                        _reservaN.RegistrarReservacionMismo(reserva, int.Parse(cboTarifa.SelectedValue.ToString()), _idUsuario,
                            false, "6", 0, int.Parse(txtDNI.Text), fechaSalida, _idReserva, txtObservacion.Text);

                        _detalleReservaN.Insert(AsignarDetalle(reserva));
                        _reservaN.MovimientoEstados(reserva, _idUsuario, DateTime.Now, int.Parse(txtDNI.Text), "6");
                    }

                if (txtAdelanto.Text != "")
                    PagoACuenta();

                    MessageBox.Show("Habitación Ocupada con Éxito", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Solo puede realizar el CheckIn el mismo día..", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            else
            {
                //6 ocupado
                //if (dtpCalendario.SelectionEnd.Date == DateTime.Now.Date)
                //{

                int dias = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1);

                //for (int i = 0; i < dias; i++)
                //{
                //    var fecha1 = fecha.AddDays(i);

                //    var reservaExiste = _reservaN.SelectCount(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fecha1 && item.codigo_reserva == null);
                //    if (reservaExiste == 0)
                //    {
                //        MessageBox.Show("No puede registrar el hospedaje, habitación con fecha: " + fecha1.Date + " esta reservada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                
                for (int i = 0; i < dias; i++)
                    {
                        var fecha1 = fecha.AddDays(i);

                        var reserva = _reservaN.SelectSingle(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fecha1).id;

                        DateTime fechaSalida = DateTime.Parse(fecha1.AddDays(1).ToShortDateString() + " " + "12:00:00.000");

                        _reservaN.RegistrarReservacion(reserva, int.Parse(cboTarifa.SelectedValue.ToString()), _idUsuario,
                            false, "6", 0, int.Parse(txtDNI.Text), _idReserva, txtObservacion.Text, fechaSalida);

                        _detalleReservaN.Insert(AsignarDetalle(reserva));
                        _reservaN.MovimientoEstados(reserva, _idUsuario, DateTime.Now, int.Parse(txtDNI.Text), "6");

                    }
                    if (txtAdelanto.Text != "")
                    PagoACuenta();

                    MessageBox.Show("Habitación Ocupada con Éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Solo puede realizar el CheckIn el mismo día..", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
 
            }

        }

        private void ckbEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if (txtIdEmpresa.Text == "" && ckbEmpresa.Checked)          
            {
                ActivarControlesEmpresa(true);
            }
            else
            {
                ActivarControlesEmpresa(false);
            }
        }

        private int EmpresaGraba(int id)
        {
            Empresa empresaE = new Empresa();
            empresaE = RegistrarEmpresa(id);
            if (empresaE.id == 0)
            {
                if (txtRUC.Text == "")
                {
                    return 0;
                }
                _empresaN = new EmpresaNegocio();
                _empresaN.Insert(empresaE);
            }
            else
            {
                _empresaN.Update(empresaE);
            }
            return empresaE.id;
        }

        private int HuespedGraba()
        {
            _huespedE = new Huesped();
            _huespedN = new HuespedNegocio();
            _huespedE = RegistrarHuesped();
            if (_huespedE.id == 0)
            {
                if (rbtNacion.Checked)
                {
                    _huespedN.Insert(_huespedE);
                }
                else
                {
                    txtDNI.Text =  _huespedN.GenerarDNI().SingleOrDefault();
                    _huespedE.dni_huesped = txtDNI.Text;
                    _huespedE.documento_extranjero = txtExtranjero.Text.Trim();
                    _huespedN.Insert(_huespedE);
                }

            }
            else
            {
                if (rbtNacion.Checked)
                {
                    _huespedN.Update(_huespedE);
                }
                else
                {
                    _huespedE.dni_huesped = txtDNI.Text;
                    _huespedE.documento_extranjero = txtExtranjero.Text.Trim();
                    _huespedN.Update(_huespedE);
                }
            }
            return _huespedE.id;
        }


        private Detalle_reserva AsignarDetalle(int idReserva)
        {
            _detalleReservaE = new Detalle_reserva()
            {
                id_huesped = HuespedGraba(),
                id_reserva = idReserva,
                indice = _indice,
                estado = true,
                dni_huesped = int.Parse(txtDNI.Text),
                id_habitacion = _idHabitacion,
                id_grupo = _idReserva
            };
            return _detalleReservaE;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbPago_CheckedChanged(object sender, EventArgs e)
        {

            //rbtEfectivo.Visible = ckbPago.Checked;
            //rbtTarjeta.Visible = ckbPago.Checked;
            //if (rbtTarjeta.Checked)
            //{
            //    txtNTarjeta.Visible = ckbPago.Checked;
            //    txtReferencia.Visible = ckbPago.Checked;
            //    lblNTarjeta.Visible = ckbPago.Checked;
            //    lblReferencia.Visible = ckbPago.Checked;
            //}

            
        }

        private string ObtenerTipoPago()
        {
            if (rbtEfectivo.Checked)
                return "E";
            else
                return "T";
        }
        private void PagoACuenta()
        {
            Monto_A_Cuenta objE = new Monto_A_Cuenta()
            {
                fecha_registro = DateTime.Now,
                fecha_acuenta = DateTime.Now.Date,
                id_caja_dia = _idCajaDia,
                id_usuario = _idUsuario,
                estado_acuenta = true,
                monto_acuenta = decimal.Parse(txtAdelanto.Text),
                codigo_reserva = int.Parse(txtDNI.Text),
                id_habitacion =  _idHabitacion,
                id_grupo =  _idReserva,
                caja_cerrada = false,
                observacion_acuenta =  "NF"
                
            };
            if (ObtenerTipoPago() == "E")
            {
                objE.referencia_acuenta = "";
                objE.ntarjeta_acuenta = "";
                objE.forma_pago_acuenta = "E";
            }
            else
            {
                objE.referencia_acuenta = txtReferencia.Text;
                objE.ntarjeta_acuenta = txtNTarjeta.Text;
                objE.forma_pago_acuenta = "T";
            }
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            objN.Insert(objE);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            txtDNI.Enabled = false;
            txtDNI.Text.Trim();
            txtCelular.Enabled = true;
            txtMaterno.Enabled = true;
            txtPaterno.Enabled = true;
            txtNombre.Enabled = true;
           
            txtDireccion.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtCorreoElectronico.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCorreoElectronico.Text.Length != 0)
            {
                if (Functions.Validations.EmailIsValid(txtCorreoElectronico.Text.Trim()) == false)
                {
                    MessageBox.Show("Registre un email válido.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            HuespedGraba();
            //EmpresaGraba();
            txtCelular.Enabled = false;
            txtMaterno.Enabled = false;
            txtPaterno.Enabled = false;
            txtNombre.Enabled = false;

            txtDireccion.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCorreoElectronico.Enabled = false;
            MessageBox.Show("Registro Cliente guardado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Observacion(int id, string texto)
        {
            _reservaN = new ReservaNegocio();
            _reservaN.ActualizaObservacion(id, texto);
            MessageBox.Show("Registro de Observacion guardado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rbtEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEfectivo.Checked)
            {
                txtAdelanto.Visible = true;
            }
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTarjeta.Checked)
            {
                txtAdelanto.Visible = true;

                txtNTarjeta.Text = "";
                txtReferencia.Text = "";
            }
        }

        private void txtDNI_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void FrmHPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void rbtNacion_CheckedChanged(object sender, EventArgs e)
        {
            txtExtranjero.Visible = false;
            lblCarnet.Visible = false;

            txtDNI.Visible = true;
            fLabelMedium12.Visible = true;
        }

        private void rbtExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            txtExtranjero.Visible = true;
            lblCarnet.Visible = true;

            txtDNI.Visible = false;
            fLabelMedium12.Visible = false;
        }

        private void txtExtranjero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) != 13)
                return;
            this.BuscarHuesped(this.txtDNI.Text);
            this.PintarEstrellas(this.txtDNI.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ReservaNegocio().LimpiarChantada(this._idReserva);
            int num = (int)MessageBox.Show("Se Libero la habitación ya puedes seguir con sus operaciones.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void txtRUC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
