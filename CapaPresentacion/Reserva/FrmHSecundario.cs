using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Reserva
{
    public partial class FrmHSecundario : Form
    {
        /*
         * Lista de Estados 
         * Guinda       Reservas            (108, 19, 43)       5
         * Azul         Ocupado             (0,0,255)           6
         * Crema        Prereserva          (240,230,140)       7
        */

        private Huesped _huespedE;
        private HuespedNegocio _huespedN;

        private Empresa _empresaE;
        private EmpresaNegocio _empresaN;

        private HabitacionTarifaNegocio _tarifaN;

        private CapaEntidades.Reserva _reservaE;
        private ReservaNegocio _reservaN;

        private Detalle_reserva _detalleReservaE;
        private ReservaDetalleNegocio _detalleReservaN;

        private CalificacionNegocio _calificacionN;

        private readonly int _idReserva;
        private readonly int _indice;
        private readonly int _idHabitacion;
        private readonly int _idGrupo;

        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        public FrmHSecundario(int idReserva, int idHabitacion, int indice, string numeroHabitacion)
        {
            InitializeComponent();
            _idReserva = idReserva;
            _idGrupo = Grupo();
            _indice = indice;
            fLabelBig1.Text += ": " + numeroHabitacion;
            _idHabitacion = idHabitacion;
            CargarTarifas(_idHabitacion);
        }

        private int Grupo()
        {
            _reservaN = new ReservaNegocio();
            var reservaFecha = _reservaN.SelectSingle(item => item.id == _idReserva).grupo_reserva;
            if (reservaFecha != null) return reservaFecha.Value;
            return 0;
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
                //var paUltimaObservacionResult = calificacion.SingleOrDefault();
                //if (paUltimaObservacionResult != null)
                //    txtObservacion.Text = paUltimaObservacionResult.comentario_calificacion;
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
            _huespedN = new HuespedNegocio();
            int idHuesped = 0;
            var objDetalleR = _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva &&
                                                                    item.indice == _indice);
            if (objDetalleR == null)
            {
                txtDNI.Text = "";
            }
            else
            {
                idHuesped = _detalleReservaN.SelectSingle(item => item.id_reserva == _idReserva &&
                                                         item.indice == _indice).id_huesped.Value;
                var dniHuesped = _huespedN.SelectSingle(item => item.id == idHuesped).dni_huesped;
                txtDNI.Text = dniHuesped;
            }
            var objReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            if (objReserva.id_tarifa_habitacion != null)
            {
                int tarifa = (int)objReserva.id_tarifa_habitacion;
                CargarTarifas(tarifa);
                FechasPorDefecto();
            }
        }

        private void CargarTarifas(int idHabitacion)
        {
            _tarifaN = new HabitacionTarifaNegocio();
            vistaHabitacionTarifaBindingSource.DataSource = _tarifaN.SelectListView(item => item.id == idHabitacion);
        }
        private void FechasPorDefecto()
        {
            //dtpCalendario.SelectionStart = inicio.Date;
            //dtpCalendario.SelectionEnd = fin.Date;

            _reservaN = new ReservaNegocio();
            var reservaFecha = _reservaN.SelectViewHabitacionesAlquiladas(item => item.id_habitacion == _idHabitacion && item.estado_reserva.Value && item.grupo_reserva == _idGrupo);

            dtpCalendario.SelectionStart = reservaFecha.Min(item => item.fecha_hotelera.Value);
            dtpCalendario.SelectionEnd = reservaFecha.Max(item => item.fecha_hotelera.Value);
        }
        private void dtpCalendario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
            var reserva = _reservaN.SelectSingle(item => item.id == _idReserva && item.estado_habitacion_reserva == "6").codigo_reserva;
            if (reserva != null)
            {
                var reservaFecha = _reservaN.SelectViewHabitacionesAlquiladas(item => item.id_habitacion == _idHabitacion && item.estado_reserva.Value &&
                                                                                  item.grupo_reserva == _idGrupo);
                string fechaIn = "", fechaOut = "";
                fechaIn = "Check In " + reservaFecha.Min(item => item.fecha_ingreso);
                fechaOut = "Check Out " + reservaFecha.Max(item => item.fecha_checkOut);
                label1.Text = fechaIn + @" - " + fechaOut;


            }
        }
        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            CargarReserva();
            ActivarControlesHuesped(false);
            txtDNI.Focus();
        }
        private void MostrarDetalles()
        {
            lblInicio.Text = dtpCalendario.SelectionStart.ToShortDateString();
            lblFin.Text = dtpCalendario.SelectionEnd.AddDays(1).ToShortDateString();
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
            _huespedE = new Huesped()
            {
                paterno_huesped = txtPaterno.Text.Trim().ToUpper(),
                materno_huesped = txtMaterno.Text.Trim().ToUpper(),
                nombre_huesped = txtNombre.Text.Trim().ToUpper(),
                dni_huesped = txtDNI.Text,
                celular_huesped =  txtCelular.Text,
                estado_huesped = true
            };
            var idEmpresa = string.IsNullOrEmpty(txtIdEmpresa.Text) ? 0 : int.Parse(txtIdEmpresa.Text);
            if (idEmpresa != 0)
                _huespedE.id_empresa = int.Parse(txtIdEmpresa.Text); ;
            if (idEmpresa == 0 && txtRUC.Text != "")
                _huespedE.id_empresa = EmpresaGraba();
            var idHuesped = string.IsNullOrEmpty(txtIdHuesped.Text) ? 0 : int.Parse(txtIdHuesped.Text);
            if (idHuesped != 0)
                _huespedE.id = int.Parse(txtIdHuesped.Text);
            return _huespedE;
        }
        private Empresa RegistrarEmpresa()
        {
            _empresaE = new Empresa()
            {
                nombre_empresa = this.txtRazonSocial.Text.Trim(),
                ruc_empresa = this.txtRUC.Text.Trim(),
                direccion_empresa = this.txtDireccion.Text .Trim(),
                estado_empresa = true
            };
            int idEmpresa = string.IsNullOrEmpty(txtIdEmpresa.Text) ? 0 : int.Parse(txtIdEmpresa.Text);
            if (idEmpresa != 0)
                _empresaE.id = int.Parse(txtIdEmpresa.Text);
            return _empresaE;
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
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                BuscarHuesped(txtDNI.Text);
            }
            PintarEstrellas(txtDNI.Text);
        }
        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                BuscarEmpresa(txtRUC.Text);
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

        private int EmpresaGraba()
        {
            _empresaE = new Empresa();
            _empresaE = RegistrarEmpresa();
            if (_empresaE.id == 0)
            {
                _empresaN = new EmpresaNegocio();
                _empresaN.Insert(_empresaE);
            }
            return _empresaE.id;
        }

        private int HuespedGraba()
        {
            _huespedE = new Huesped();
            _huespedE = RegistrarHuesped();
            if (_huespedE.id == 0)
            {
                _huespedN = new HuespedNegocio();
                _huespedN.Insert(_huespedE);
            }
            return _huespedE.id;
        }

        private Detalle_reserva AsignarDetalle(int i)
        {
            _detalleReservaE = new Detalle_reserva()
            {
                id_huesped = HuespedGraba(),
                id_reserva =  _idReserva + i,
                indice =  _indice,
                estado =  true,
                dni_huesped = int.Parse(txtDNI.Text),
                id_habitacion = _idHabitacion,
                id_grupo =  _idGrupo
            };
            return _detalleReservaE;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _reservaN = new ReservaNegocio();
            int dias = (dtpCalendario.SelectionEnd.Subtract(dtpCalendario.SelectionStart).Days + 1);
            for (int i = 0; i < dias; i++)
            {
                _detalleReservaN.Insert(AsignarDetalle(i));
            }
            if (ckbPago.Checked)
                PagoACuenta();
            MessageBox.Show("Se asigno otro huesped a la Habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ckbPago_CheckedChanged(object sender, EventArgs e)
        {
            txtAdelanto.Visible = ckbPago.Checked;
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
                id_habitacion = _idHabitacion,
                id_grupo = _idReserva
            };
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            objN.Insert(objE);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            HuespedGraba();
            EmpresaGraba();
            txtCelular.Enabled = false;
            txtMaterno.Enabled = false;
            txtPaterno.Enabled = false;
            txtNombre.Enabled = false;

            txtDireccion.Enabled = false;
            txtRazonSocial.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDNI.Text.Trim();
            txtDNI.Enabled = false;
            txtCelular.Enabled = true;
            txtMaterno.Enabled = true;
            txtPaterno.Enabled = true;
            txtNombre.Enabled = true;

            txtDireccion.Enabled = true;
            txtRazonSocial.Enabled = true;
        }

        private void FrmHSecundario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
