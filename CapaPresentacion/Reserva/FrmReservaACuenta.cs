using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaACuenta : Form
    {
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        private Monto_A_Cuenta oMontoACuenta;
        private MontoACuentaNegocio oNegocio;
        private ReservaNegocio oReservaN;
        private string _habitacion;
        private int _grupo;
        public FrmReservaACuenta(string habitacion, int grupo)
        {
            _habitacion = habitacion;
            _grupo = grupo;
            InitializeComponent();
            fLabelBig1.Text = fLabelBig1.Text + ": " + habitacion;
        }

        private void FrmReservaACuenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            oNegocio = new MontoACuentaNegocio();
            paMontoACuentaResultBindingSource.DataSource = oNegocio.ListaPagosACuenta(_grupo).Where(item=>item.estado_acuenta.Value);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtMontoACuenta.Text == "" || decimal.Parse(txtMontoACuenta.Text) == 0)
            {
                MessageBox.Show("Debe de ingresar un monto a cuenta.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            oNegocio = new MontoACuentaNegocio();
            oNegocio.Insert(Asignar(txtMontoACuenta.Text, _grupo));
            MessageBox.Show("Monto asignado correctamente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMontoACuenta.Clear();
            txtMontoACuenta.Focus();
            CargarDatos();
        }

        private string ObtenerTipoPago()
        {
            if (rbtEfectivo.Checked)
                return "E";
            else
                return "T";
        }


        private Monto_A_Cuenta Asignar(string monto, int grupo)
        {
            oReservaN = new ReservaNegocio();
            var reserva = oReservaN.SelectViewHabitacionesAlquiladas(item => item.grupo_reserva == grupo).FirstOrDefault();
            if (reserva != null)
                oMontoACuenta = new Monto_A_Cuenta()
                {
                    codigo_reserva = reserva.codigo_reserva,
                    estado_acuenta = true,
                    monto_acuenta = decimal.Parse(monto),
                    id_habitacion = reserva.id_habitacion,
                    id_usuario = _idUsuario,
                    id_grupo = reserva.grupo_reserva,
                    id_caja_dia = _idCajaDia,
                    fecha_registro = DateTime.Now,
                    fecha_acuenta = DateTime.Now.Date,
                    caja_cerrada = false,
                    observacion_acuenta = "NF"
                };
            if (ObtenerTipoPago() == "E")
            {
                oMontoACuenta.referencia_acuenta = "";
                oMontoACuenta.ntarjeta_acuenta = "";
                oMontoACuenta.forma_pago_acuenta = "E";
            }
            else
            {
                oMontoACuenta.referencia_acuenta = txtReferencia.Text;
                oMontoACuenta.ntarjeta_acuenta = txtNTarjeta.Text;
                oMontoACuenta.forma_pago_acuenta = "T";
            }
            return oMontoACuenta;
        }

        private Monto_A_Cuenta AsignarParaEliminar()
        {
            oReservaN = new ReservaNegocio();
            if (dgvDatos.CurrentRow != null)
                oMontoACuenta = new Monto_A_Cuenta()
                {
                    id = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString()),
                    observacion_acuenta = "NF"
                };
            return oMontoACuenta;
        }

        private void eliminarMontoACuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarDatos();
            oNegocio = new MontoACuentaNegocio();
            oNegocio.Delete(AsignarParaEliminar());
            MessageBox.Show("Monto eliminado correctamente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }

        private void rbtEfectivo_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            txtNTarjeta.Text = "";
            txtReferencia.Text = "";
        }

        private void FrmReservaACuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
