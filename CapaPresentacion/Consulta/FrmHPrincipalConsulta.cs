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
    public partial class FrmHPrincipalConsulta : Form
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

        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

        private readonly int _idReserva;
        private readonly int _indice;
        private readonly int _idHabitacion;
        private readonly int _idGrupo;
        private readonly string _numeroHabitacion;

        private bool flag;
        public FrmHPrincipalConsulta(int idReserva, int idHabitacion, int indice, string numeroHabitacion)
        {
            InitializeComponent();
            _idReserva = idReserva;
            _idGrupo = Grupo();
            _idHabitacion = idHabitacion;
            _indice = indice;
            _numeroHabitacion = numeroHabitacion;
            fLabelBig1.Text += ": " + _numeroHabitacion;
            CargarTarifas(idHabitacion);
        }

        private int Grupo()
        {
            try
            {
                _reservaN = new ReservaNegocio();
                Reserva_HistoricoNegocio oRHN = new Reserva_HistoricoNegocio();
                DateTime fechaIn = new DateTime();
                TimeSpan horaIn = new TimeSpan();
                var reservaFecha = _reservaN.SelectSingle(item => item.id == _idReserva).grupo_reserva;

                var reservaHistorica = _reservaN.SelectList(item => item.grupo_reserva == reservaFecha).FirstOrDefault();

                if (reservaHistorica != null)
                {
                    fechaIn = reservaHistorica.fecha_checkIn.Value.Date;
                }

                var firstOrDefault = oRHN.SelectList(item => item.id_grupo == reservaFecha).FirstOrDefault();
                if (firstOrDefault != null)
                {
                    horaIn = firstOrDefault.fecha_in.Value.TimeOfDay;
                }

                In.Text = fechaIn.Date.ToString().Substring(0,10) + " " + horaIn.ToString().Substring(0,8);

                var lastOrDefault = oRHN.SelectList(item => item.id_grupo == reservaFecha).FirstOrDefault();
                if (lastOrDefault != null)
                {
                    Out.Text = lastOrDefault.fecha_out.ToString();
                }
                else
                {
                    return 0;
                }

                if (reservaFecha != null) return reservaFecha.Value;
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
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
            }
            else
            {
                PintaEstrellas(0);
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
        private bool CargarReserva()
        {
            _reservaN = new ReservaNegocio();
            _detalleReservaN = new ReservaDetalleNegocio();
            HuespedNegocio huespedNegocio = new HuespedNegocio();
            var detalleReserva = _detalleReservaN.SelectList(item => item.id_grupo == _idGrupo && item.indice == 1 && item.estado == false).FirstOrDefault();
            if (detalleReserva != null)
            {
                int idHuesped = detalleReserva.id_huesped.Value;
                string dniHuesped = huespedNegocio.SelectSingle(item => item.id == idHuesped).dni_huesped;
                int dni = int.Parse(dniHuesped);
                var sinEstado = _reservaN.SelectViewHabitacionesHistoricas(item => item.id == _idReserva &&
                                                                                   item.grupo_reserva == _idGrupo &&
                                                                                   item.codigo_reserva == dni)
                    .SingleOrDefault();
                if (sinEstado.id_tarifa_habitacion != null)
                {

                    if (sinEstado.id_tarifa_habitacion != null)
                    {
                        int tarifa = (int) sinEstado.id_tarifa_habitacion;
                        CargarTarifas(tarifa);
                    }
                    txtDNI.Text = dniHuesped;
                    txtObservacion.Text = sinEstado.observacion_reserva;
                    FechasPorDefecto();
                }
                return true;
            }
            else
            {
                MessageBox.Show("El huesped aún no se ha retirado del hotel.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
        private void CargarTarifas(int idHabitacion)
        {
            _tarifaN = new HabitacionTarifaNegocio();
            vistaHabitacionTarifaBindingSource.DataSource = _tarifaN.SelectListView(item => item.id == idHabitacion);
        }
        private void FechasPorDefecto()
        {
            _reservaN = new ReservaNegocio();
            int codigoReserva = int.Parse(txtDNI.Text);
            var reservaFecha = _reservaN.SelectViewHabitacionesHistoricas(item => item.codigo_reserva == codigoReserva && item.id_habitacion == _idHabitacion && item.estado_reserva.Value && item.grupo_reserva == _idGrupo);
            
            dtpCalendario.SelectionStart = reservaFecha.Min(item => item.fecha_hotelera.Value);
            dtpCalendario.SelectionEnd = reservaFecha.Max(item => item.fecha_hotelera.Value);
        }
        private void dtpCalendario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalles();
        }
        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            bool estado = CargarReserva();
            ActivarControlesHuesped(false);
            txtDNI.Focus();
            if (estado)
                lblMontoCuenta.Text = lblMontoCuenta.Text + ": S/." +MontoACuenta();
            else
            {
             this.Close();   
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
            BuscarHuesped(txtDNI.Text);
            PintarEstrellas(txtDNI.Text);
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
                _detalleReservaN.SelectList(item => item.id_grupo == _idGrupo && item.indice == _indice && item.estado == false).FirstOrDefault().id;
                FrmReservaPedidoConsulta frm = new FrmReservaPedidoConsulta(idDetalleReserva, _idReserva);
                frm.Show();
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            _detalleReservaN = new ReservaDetalleNegocio();
            int idDetalleReserva =
                _detalleReservaN.SelectList(item => item.id_grupo == _idGrupo && item.indice == _indice && item.estado == false).FirstOrDefault().id;
            FrmHCalificacionConsulta frm = new FrmHCalificacionConsulta(idDetalleReserva, txtDNI.Text);
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
                int idDetalleReserva = _detalleReservaN.SelectList(item => item.id_grupo == _idGrupo && item.indice == _indice && item.estado == false).FirstOrDefault().id;
                FrmReservaFacturacionConsulta frm = new FrmReservaFacturacionConsulta(idDetalleReserva, int.Parse(txtDNI.Text), _idHabitacion, _idReserva);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    PintarEstrellas(txtDNI.Text);
            }

            lblMontoCuenta.Text = "A Cuenta";
            lblMontoCuenta.Text = lblMontoCuenta.Text + ": S/." + MontoACuenta();
        }

        private string MontoACuenta()
        {
            MontoACuentaNegocio objN = new MontoACuentaNegocio();
            int dni = int.Parse(txtDNI.Text);
            decimal monto = 0;
            var lista = objN.SelectList(item => item.id_grupo == _idGrupo && item.estado_acuenta == false && item.codigo_reserva == dni);
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
            lblMontoCuenta.Text = "A Cuenta";
            lblMontoCuenta.Text = lblMontoCuenta.Text + ": S/." + MontoACuenta();
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            HuespedGraba();
            //EmpresaGraba();
            txtCelular.Enabled = false;
            txtMaterno.Enabled = false;
            txtPaterno.Enabled = false;
            txtNombre.Enabled = false;
            txtRUC.Enabled = false;

            txtDireccion.Enabled = false;
            txtRazonSocial.Enabled = false;
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
                BuscarEmpresa(txtRUC.Text);
            }
        }

        private void Out_Click(object sender, EventArgs e)
        {

        }

        private void FrmHPrincipalConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
