using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Reserva
{
    public partial class FrmHCalificacionConsulta : Form
    {
        private readonly int _idDetalleReserva;
        private Calificacion _calificacionE;
        private CalificacionNegocio _calificacionN;
        private ReservaDetalleNegocio _reservaDetalleN;
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        bool _flag;
        private string _codigoReserva;

        public FrmHCalificacionConsulta(int idDetalleReserva, string codigo_reserva)
        {
            InitializeComponent();
            _idDetalleReserva = idDetalleReserva;
            CargaDatos();
            HuespedCalificacion();
            ControlesFormulario(true);
            _codigoReserva = codigo_reserva;
        }

        private void HuespedCalificacion()
        {
            _reservaDetalleN = new ReservaDetalleNegocio();
            var vistaHuespedReserva = _reservaDetalleN.SelectListView(item => item.id == _idDetalleReserva).FirstOrDefault();
            if (vistaHuespedReserva != null)
                lblHuesped.Text = string.Format("HUESPED: {0}", vistaHuespedReserva.completo_huesped);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtComentario.Enabled = !act;
            nudPuntaje.Enabled = !act;
            btnCancelar.Enabled = act;
            if (act)
            {
                vistaClasificacionBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (_flag)
                {
                    vistaClasificacionBindingSource.SuspendBinding();
                }
                txtComentario.Focus();
            }
        }
        #endregion

        private Calificacion Asignar()
        {
            _calificacionE = new Calificacion()
            {
                fecha_calificacion = DateTime.Now,
                id_usuario = _idUsuario,
                comentario_calificacion = txtComentario.Text,
                id_detalle_reserva = _idDetalleReserva,
                puntos_calificacion = int.Parse(nudPuntaje.Text)
            };
            if (_flag) return _calificacionE;
            if (dgvCalificacion.CurrentRow != null)
                _calificacionE.id = int.Parse(dgvCalificacion.CurrentRow.Cells[0].Value.ToString());
            return _calificacionE;
        }

        private void CargaDatos()
        {
            _calificacionN = new CalificacionNegocio();
            vistaClasificacionBindingSource.DataSource = _calificacionN.SelectListViewHuesped(item => item.dni_huesped == _codigoReserva);
        }

        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            CargaDatos();
            PintarEstrellas(int.Parse(nudPuntaje.Text));
        }

        private void PintarEstrellas(int est)
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
        
        private void nudPuntaje_KeyDown(object sender, KeyEventArgs e)
        {
            PintarEstrellas(Convert.ToInt32(nudPuntaje.Value));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            ControlesFormulario(false);
            this.txtComentario.Focus();
            PintarEstrellas(0);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCalificacion.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _calificacionN = new CalificacionNegocio();
            _calificacionE = new Calificacion();
            _flag = false;
            if (dgvCalificacion.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _calificacionE = Asignar();
                _calificacionN.Delete(_calificacionE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PintarEstrellas(0);
            dgvCalificacion.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _calificacionN = new CalificacionNegocio();
            if (_flag)
            {
                _calificacionN.Insert(Asignar());
            }
            else
            {
                _calificacionN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCalificacion.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void nudPuntaje_ValueChanged(object sender, EventArgs e)
        {
            PintarEstrellas(Convert.ToInt32(nudPuntaje.Value));
        }

        private void FrmHCalificacionConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

}
