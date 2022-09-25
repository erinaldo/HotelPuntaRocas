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

namespace CapaPresentacion.Reserva
{
    public partial class FrmHPrincipalVer : Form
    {
        /*
         * Lista de Estados 
         * Guinda       Reservas            (108, 19, 43)       5
         * Azul         Ocupado             (0,0,255)           6
         * Crema        Prereserva          (240,230,140)       7
        */
        private HuespedNegocio _huespedN;

        private EmpresaNegocio _empresaN;

        private HabitacionTarifaNegocio _tarifaN;

        private ReservaNegocio _reservaN;

        private ReservaDetalleNegocio _detalleReservaN;

        private CalificacionNegocio _calificacionN;

        private Monto_A_Cuenta _montoACuenta;
        private MontoACuentaNegocio _montoACuentaN;
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

        private readonly int _idReserva;
        private readonly int _indice;
        private readonly int _idHabitacion;
        private readonly int _idGrupo;
        private readonly string _numeroHabitacion;

        private bool flag;
        public FrmHPrincipalVer(int idReserva, int idHabitacion, int indice, string numeroHabitacion)
        {
            InitializeComponent();
            _idReserva = idReserva;
            _idGrupo = Grupo();
            _idHabitacion = idHabitacion;
            _indice = indice;
            _numeroHabitacion = numeroHabitacion;
            fLabelBig1.Text += ": " + _numeroHabitacion;
            CargarTarifas(idHabitacion,true);
        }

        private int Grupo()
        {
            _reservaN = new ReservaNegocio();
            var reservaFecha = _reservaN.SelectSingle(item => item.id == _idReserva).grupo_reserva;
            if (reservaFecha != null) return reservaFecha.Value;
            return 0;
        }

        private void CargarInformacion()
        {
            int codigoReserva = int.Parse(txtDNI.Text.Trim());
            var reservaFecha = _reservaN.SelectViewHabitacionesAlquiladas(item => item.codigo_reserva == codigoReserva && 
                                                                                  item.id_habitacion == _idHabitacion && item.estado_reserva.Value &&
                                                                                  item.grupo_reserva == _idGrupo);
            if (reservaFecha.Max(item => item.estado_habitacion_reserva == "6"))
            {
                if (reservaFecha != null)
                {
                    string fechaIn = "", fechaOut = "";
                    fechaIn = "Check In " + reservaFecha.Min(item => item.fecha_ingreso);
                    fechaOut = "Check Out " + reservaFecha.Max(item => item.fecha_checkOut);
                    label1.Text = fechaIn + @" - " + fechaOut;
                    fButtonAceptar1.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnCkeckOut.Enabled = true;
                    btnCkeckOut.Text = "Check Out";
                    btnFacturacion.Enabled = true;
                    btnObservacion.Enabled = true;
                    btnPedido.Enabled = true;
                }
            }
            else
            {
                if (reservaFecha != null)
                {
                    string fechaIn = "", fechaOut = "";
                    fechaIn = "Aún no registra Ingreso";
                    fechaOut = "Check Out " + reservaFecha.Max(item => item.fecha_checkOut);
                    label1.Text = fechaIn + @" - " + fechaOut;
                    fButtonAceptar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    if (reservaFecha.Max(item => item.estado_habitacion_reserva == "5"))
                    {
                        btnFacturacion.Enabled = true;
                        btnObservacion.Enabled = true;
                        btnCkeckOut.Enabled = true;
                        btnCkeckOut.Text = "Retirar";
                    }
                    else
                    {
                        btnFacturacion.Enabled = false;
                        btnObservacion.Enabled = false;
                        btnCkeckOut.Enabled = false;
                        btnCkeckOut.Text = "Check Out";
                    }
                    btnPedido.Enabled = false;
                }
            }

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
        private void CargarReserva()
        {
            _reservaN = new ReservaNegocio();
            _detalleReservaN = new ReservaDetalleNegocio();
            HuespedNegocio huespedNegocio = new HuespedNegocio();

            int idHuesped = _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva && item.indice == 1 && item.estado.Value).id_huesped.Value;
            string dniHuesped = huespedNegocio.SelectSingle(item => item.id == idHuesped).dni_huesped;
            int dni = int.Parse(dniHuesped);
            var sinEstado = _reservaN.SelectViewHabitacionesAlquiladas(item => item.id == _idReserva && 
                                                                               item.grupo_reserva == _idGrupo &&
                                                                               item.codigo_reserva == dni).SingleOrDefault();
            if (sinEstado.id_tarifa_habitacion != null)
            {

                if (sinEstado.id_tarifa_habitacion != null)
                {
                    int tarifa = (int)sinEstado.id_tarifa_habitacion;
                    CargarTarifas(tarifa,true);
                }
                txtDNI.Text = dniHuesped;
                txtObservacion.Text = sinEstado.observacion_reserva;
                FechasPorDefecto();
            }
        }
        private void CargarTarifas(int idHabitacion, bool estado)
        {
            _tarifaN = new HabitacionTarifaNegocio();
            if(estado)
                vistaHabitacionTarifaBindingSource.DataSource = _tarifaN.SelectListView(item => item.id == idHabitacion);
            else
                vistaHabitacionTarifaBindingSource.DataSource = _tarifaN.SelectListView(item => item.id_habitacion == idHabitacion);
        }
        private void FechasPorDefecto()
        {
            _reservaN = new ReservaNegocio();
            int codigoReserva = int.Parse(txtDNI.Text);
            var reservaFecha = _reservaN.SelectViewHabitacionesAlquiladas(item => item.codigo_reserva == codigoReserva && item.id_habitacion == _idHabitacion && item.estado_reserva.Value && item.grupo_reserva == _idGrupo);
            
            dtpCalendario.SelectionStart = reservaFecha.Min(item => item.fecha_hotelera.Value);
            dtpCalendario.SelectionEnd = reservaFecha.Max(item => item.fecha_hotelera.Value);
        }
        private void dtpCalendario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }
        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            var estadoPagoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            var UsuarioDato = usuarioNegocio.SelectSingle(item => item.id == estadoPagoReserva.id_usuario.Value);
            string NombreCompleto = UsuarioDato.nombre_usuario + ' ' + UsuarioDato.paterno_usuario + ' ' + UsuarioDato.materno_usuario;
            lblUsuarioRealizaReserva.Text = "Reserva realizada por: " + NombreCompleto;
            bool estadoPago = estadoPagoReserva.estado_pago_reserva != null && (bool)estadoPagoReserva.estado_pago_reserva;
            if (estadoPagoReserva.estado_habitacion_reserva == "8")
            {
                MessageBox.Show("Cambie a estado disponible.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
            else
            {
                CargarReserva();
                ActivarControlesHuesped(false);
                txtDNI.Focus();
                lblMontoCuenta.Text = MontoACuenta();
                CargarInformacion();
            }


        }
        private void MostrarDetalles()
        {
            lblInicio.Text = dtpCalendario.SelectionStart.ToShortDateString();
            lblFin.Text = dtpCalendario.SelectionEnd.AddDays(1).Date.ToShortDateString();
            lblDias.Text = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1).ToString();
            lblTotal.Text = string.Format("{0:c}", (double.Parse(lblMonto.Text.Equals("") ? "0" : lblMonto.Text) *
                                                    double.Parse(lblDias.Text.Equals("") ? "0" : lblDias.Text)));

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
        private void BuscarHuesped(string dni)
        {
            _huespedN = new HuespedNegocio();
            _empresaN = new EmpresaNegocio();
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
                txtIdEmpresa.Text = "0";
            }
        }

        private Monto_A_Cuenta Asignar(string monto, int grupo)
        {
            _reservaN = new ReservaNegocio();
            var reserva = _reservaN.SelectList(item => item.grupo_reserva == grupo).FirstOrDefault();
            if (reserva != null)
                _montoACuenta = new Monto_A_Cuenta()
                {
                    codigo_reserva = reserva.codigo_reserva,
                    estado_acuenta = true,
                    monto_acuenta = (-1) * decimal.Parse(monto),
                    id_habitacion = reserva.id_habitacion,
                    id_usuario = _idUsuario,
                    id_grupo = reserva.grupo_reserva,
                    id_caja_dia = _idCajaDia,
                    fecha_registro = DateTime.Now,
                    fecha_acuenta = DateTime.Now.Date,
                    caja_cerrada = false,
                    observacion_acuenta = "NF",
                    referencia_acuenta = "",
                    ntarjeta_acuenta = "",
                    forma_pago_acuenta = "E"
                };
            return _montoACuenta;
        }

        private void btnCkeckOut_Click(object sender, EventArgs e)
        {
            //3 salida
            Reserva_HistoricoNegocio oReservaHN = new Reserva_HistoricoNegocio();
            Reserva_Historica oReservaH = new Reserva_Historica();
            _reservaN = new ReservaNegocio();
            _montoACuentaN = new MontoACuentaNegocio();
            var estadoPagoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);

            var fecha_inicio = _reservaN.SelectList(item => item.grupo_reserva == _idGrupo).FirstOrDefault().fecha_ingreso;
            bool estadoPago = estadoPagoReserva.estado_pago_reserva != null && (bool)estadoPagoReserva.estado_pago_reserva;
            if (estadoPagoReserva.estado_habitacion_reserva == "5")
            {
                _montoACuentaN.Insert(Asignar(lblMontoCuenta.Text, _idGrupo));
                _reservaN.RegistrarReservacionOut(_idReserva, _idUsuario, "2");
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, int.Parse(txtDNI.Text), "2");
                MessageBox.Show("Reserva retirada con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (estadoPago && estadoPagoReserva.estado_habitacion_reserva == "6")
            {
                //TENER EN CUENTA QUE PUEDEN SER VARIOS DIAS... USAR UN METODO PARA CANCELAR EN BLOQUE
                if (fecha_inicio != null) oReservaH.fecha_in = fecha_inicio.Value;
                oReservaH.fecha_out = DateTime.Now;
                oReservaH.id_reserva = _idReserva;
                oReservaH.id_grupo = estadoPagoReserva.grupo_reserva;
                oReservaH.id_huesped = int.Parse(txtIdHuesped.Text);

                _reservaN.RegistrarReservacionOut(_idReserva, _idUsuario, "3");
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, int.Parse(txtDNI.Text), "3");
                oReservaHN.Insert(oReservaH);

                MessageBox.Show("Habitación Desocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No puede realizar Check-Out si no ha pagado el hospedaje.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            var huespedN = new HuespedNegocio();
            string dniH = txtDNI.Text;
            var vistaHuespedList = huespedN.SelectListView(item => item.dni_huesped == dniH);
            if (vistaHuespedList.Count() > 1)
            {
                MessageBox.Show("Existen Duplicado de DNI.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            else
            {
                BuscarHuesped(txtDNI.Text);
                PintarEstrellas(txtDNI.Text);
            }

        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            _detalleReservaN = new ReservaDetalleNegocio();
            _reservaN = new ReservaNegocio();
            var estadoPagoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            bool estadoPago = estadoPagoReserva.estado_pago_reserva != null && (bool)estadoPagoReserva.estado_pago_reserva;
            if (estadoPago)
            {
                MessageBox.Show("Ya se realizo la facturacion de esta habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int idDetalleReserva =
                _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva && item.indice == _indice && item.estado == true).id;
                FrmReservaPedido frm = new FrmReservaPedido(idDetalleReserva, _idReserva);
                frm.Show();
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            _detalleReservaN = new ReservaDetalleNegocio();
            int idDetalleReserva =
                _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva && item.indice == _indice && item.estado == true).id;
            FrmHCalificacion frm = new FrmHCalificacion(idDetalleReserva, txtDNI.Text);
            if (frm.ShowDialog(this) == DialogResult.OK)
                PintarEstrellas(txtDNI.Text);
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            _detalleReservaN = new ReservaDetalleNegocio();
            _reservaN = new ReservaNegocio();
            var estadoPagoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            bool estadoPago = estadoPagoReserva.estado_pago_reserva != null && (bool)estadoPagoReserva.estado_pago_reserva;
            if (estadoPago)
            {
                MessageBox.Show("Ya se realizo la facturacion de esta habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var detalleReserva = _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva && item.indice == _indice && item.estado == true);

                int idDetalleReserva = detalleReserva.id;
                DateTime fechaHospedaje = detalleReserva.Reserva.fecha_hotelera.Value.Date;
                FrmReservaFacturacion frm = new FrmReservaFacturacion(idDetalleReserva, int.Parse(txtDNI.Text), _idHabitacion, _idReserva, _numeroHabitacion, int.Parse(txtDNI.Text), fechaHospedaje);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    PintarEstrellas(txtDNI.Text);
            }

            lblMontoCuenta.Text = MontoACuenta();
        }

        private string MontoACuenta()
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            int dni = int.Parse(txtDNI.Text);
            decimal monto = 0;
            var lista = objN.SelectList(item => item.id_grupo == _idGrupo && item.estado_acuenta == true && item.codigo_reserva == dni);
            foreach (var q in lista)
            {
                monto += decimal.Parse(q.monto_acuenta.ToString());
            }
            return monto.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fButtonAceptar1_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpCalendario.SelectionStart.Date;
            _reservaN = new ReservaNegocio();
            _detalleReservaN = new ReservaDetalleNegocio();
            if (MessageBox.Show("¿Desea agregar un día de hospedaje?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DateTime fecha_checkIn = DateTime.Now;
                string fecha_In = DateTime.Now.Date.ToShortDateString();
                DateTime fecha_compara = DateTime.Parse(fecha_In + " " + "07:59:59 am");
                int diferencia = DateTime.Compare(fecha_checkIn, fecha_compara);
                int dias = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1) + 1;
                int dniHuesped = Convert.ToInt32(txtDNI.Text.Trim());


                ///
                /// Bloque para evitar la montada de las reservas
                ///
                
                for (int i = dias - 1; i <= dias-1; i++)
                {
                    var fechaHotelera = fecha.AddDays(i);
                    var reservaExiste = _reservaN.SelectCount(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fechaHotelera && item.codigo_reserva != null);


                    if (reservaExiste == 1)
                    {
                        var datosReserva = _reservaN.SelectList(item => item.id_habitacion == _idHabitacion && 
                                                                                 item.fecha_hotelera == fechaHotelera &&
                                                                                 item.estado_habitacion_reserva == "2");
                        if (datosReserva.Count() == 0)
                        {
                            MessageBox.Show("No puede registrar el hospedaje, habitación con fecha: " + fechaHotelera.Date.ToShortDateString() + " esta reservada u ocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }


                for (int i = 0; i < dias; i++)
                {
                    var fecha1 = fecha.AddDays(i);
                    DateTime fechaSalida = DateTime.Parse(fecha1.AddDays(1).ToShortDateString() + " " + "12:00:00.000");
                    var reserva = _reservaN.SelectSingle(item => item.id_habitacion == _idHabitacion && item.fecha_hotelera == fecha1);
                    var idReservaObtiene = reserva.id;
                    var estadoHabitacion = reserva.estado_habitacion_reserva;
                    bool estadoPago = reserva.estado_pago_reserva != null && reserva.estado_pago_reserva.Value;
                    if (estadoHabitacion == "2")
                    {
                        _reservaN.RegistrarReservacion(idReservaObtiene, int.Parse(cboTarifa.SelectedValue.ToString()),
                            _idUsuario, estadoPago, "6", 0, int.Parse(txtDNI.Text), _idGrupo, txtObservacion.Text, fechaSalida);

                        _detalleReservaN.Insert(AsignarDetalle(idReservaObtiene));
                        _reservaN.MovimientoEstados(idReservaObtiene, _idUsuario, DateTime.Now, int.Parse(txtDNI.Text), "6");
                    }
                }
                MessageBox.Show("Día agregado con Éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Operación Cancelada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Detalle_reserva AsignarDetalle(int idReserva)
        {
            Detalle_reserva detalleReservaE = new Detalle_reserva()
            {
                id_huesped = HuespedGraba(),
                id_reserva = idReserva,
                indice = _indice,
                estado = true,
                dni_huesped = int.Parse(txtDNI.Text),
                id_habitacion =  _idHabitacion,
                id_grupo = _idGrupo
            };
            return detalleReservaE;
        }

        private int HuespedGraba()
        {
            Huesped _huespedE;
            _huespedN = new HuespedNegocio();
            _huespedE = RegistrarHuesped();
            if (_huespedE.id == 0)
            {
                _huespedN.Insert(_huespedE);
            }
            else
            {
                _huespedN.Update(_huespedE);
            }
            return _huespedE.id;
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
            var dato = oEmpresaN.SelectCount(item=>item.ruc_empresa == txtRUC.Text.Trim());
            if (dato != 0)
                idEmpresa = oEmpresaN.SelectSingle(item => item.ruc_empresa == txtRUC.Text.Trim()).id;

            if (idEmpresa != 0 && dato != 0)
            {
                huespedE.id_empresa = oEmpresaN.SelectSingle(item => item.ruc_empresa == txtRUC.Text).id;
                if(!flag)
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

        private void btnMontoACuenta_Click(object sender, EventArgs e)
        {
            FrmReservaACuenta frm = new FrmReservaACuenta(_numeroHabitacion, _idGrupo);
            frm.ShowDialog();
            lblMontoCuenta.Text = MontoACuenta();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            flag = false;

            txtDNI.Enabled = false;
            txtDNI.Text.Trim();
            txtCelular.Enabled = true;
            txtMaterno.Enabled = true;
            txtPaterno.Enabled = true;
            txtNombre.Enabled = true;

            txtDireccion.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtRUC.Enabled = true;
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
            txtRUC.Enabled = false;

            txtDireccion.Enabled = false;
            txtRazonSocial.Enabled = false;
            txtCorreoElectronico.Enabled = false;

            MessageBox.Show("Registro Cliente guardado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void fButtonEditar1_Click(object sender, EventArgs e)
        {
            txtObservacion.ReadOnly = false;
            txtObservacion.Focus();
        }

        private void fButtonGuardar1_Click(object sender, EventArgs e)
        {
            Observacion(_idReserva, txtObservacion.Text.Trim().ToUpper());
        }

        private void Observacion(int id, string texto)
        {
            _reservaN = new ReservaNegocio();
            _reservaN.ActualizaObservacion(id, texto);
            MessageBox.Show("Registro de Observacion guardado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtObservacion.ReadOnly = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int idTarifa = int.Parse(cboTarifa.SelectedValue.ToString());
            if (checkBox1.Checked)
            {
                cboTarifa.Enabled = true;
                CargarTarifas(_idHabitacion,false);

                _reservaN.EditarTarifa(_idGrupo, idTarifa);
                MostrarDetalles();
            }
            else
            {
                 cboTarifa.Enabled = false;
                 _reservaN.EditarTarifa(_idGrupo, idTarifa);
                MostrarDetalles();
            }
        }

        private void FrmHPrincipalVer_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Escape)
               this.Close();
        }

        private void btnFacturacionHuesped_Click(object sender, EventArgs e)
        {
            _detalleReservaN = new ReservaDetalleNegocio();
            _reservaN = new ReservaNegocio();
            var estadoPagoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            bool estadoPago = estadoPagoReserva.estado_pago_reserva != null && (bool)estadoPagoReserva.estado_pago_reserva;

            if (estadoPago)
            {
                MessageBox.Show("Ya se realizo la facturacion de esta habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var detalleReserva = _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva && item.indice == _indice && item.estado == true);

                int idDetalleReserva = detalleReserva.id;
                DateTime fechaHospedaje = detalleReserva.Reserva.fecha_hotelera.Value.Date;

                FrmReservaPedidoFacturacion oFrm = new FrmReservaPedidoFacturacion(idDetalleReserva, int.Parse(txtDNI.Text), _idHabitacion, _idReserva, _numeroHabitacion, int.Parse(txtDNI.Text), fechaHospedaje);
                if (oFrm.ShowDialog(this) == DialogResult.OK)
                    PintarEstrellas(txtDNI.Text);
            }
            lblMontoCuenta.Text = MontoACuenta();
        }
    }
}
