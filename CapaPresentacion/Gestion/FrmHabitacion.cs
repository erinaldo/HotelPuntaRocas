using CapaEntidades;
using System;
using System.Configuration;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Gestion
{
    public partial class FrmHabitacion : Form
    {
        //QueryBLL query;
        //ReservaBLL ObjReserva;
        //Detalle_tarifaBLL ObjDetalleTarifa;
        HabitacionNegocio _habitacionN;
        Habitacion _habitacionE;

        bool _flag;
        string _NHabitacion = "";
        string _Piso = "";

        public FrmHabitacion()
        {
            InitializeComponent();
            CargaRegistros();
            controlesFormulario(true);
        }

        #region Abrir formulario solo una vez
        private static FrmHabitacion m_FormDefInstance;
        public static FrmHabitacion DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmHabitacion();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        #endregion

        private void CargaRegistros()
        {
            _habitacionN = new HabitacionNegocio();
            habitacionBindingSource.DataSource = _habitacionN.SelectList(null, true);
        }

        #region Control de las acciones del formulario
        private void controlesFormulario(bool act)
        {
            txtNHabitacion.Enabled = !act;
            txtPHabitacion.Enabled = !act;
            txtCapacidadMaxima.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                habitacionBindingSource.ResumeBinding();
                CargaRegistros();
            }
            else
            {
                if (_flag)
                {
                    habitacionBindingSource.SuspendBinding();                    
                }
                txtPHabitacion.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Habitacion Asignar()
        {
            _habitacionE = new Habitacion()
            {
                numero_habitacion = txtNHabitacion.Text.Trim(),
                piso_habitacion = txtPHabitacion.Text .Trim(),
                capacidad_habitacion = int.Parse(txtCapacidadMaxima.Text.Trim()),
                estado_habitacion = true
            };
            if (!_flag)
                if (dgvHabitacion.CurrentRow != null)
                    _habitacionE.id = int.Parse(dgvHabitacion.CurrentRow.Cells[0].Value.ToString());
            return _habitacionE;
        }

        //private Reserva Reserva(int ID_HABITACION, int ID_DETALLE_TARIFA)
        //{
        //    query = new QueryBLL();

        //    Reserva Reserva = new Reserva()
        //    {
        //        id_caja_dia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]),
        //        id_cliente = 1,
        //        id_administrativo = int.Parse(ConfigurationManager.AppSettings["id_administrativo"]),
        //        id_detalle_tarifa = ID_DETALLE_TARIFA,
        //        id_habitacion = ID_HABITACION,
        //        id_estado = 1,
        //        id_tipo_reserva = 1,
        //        precio_reserva = 0,
        //        pago_reserva = 0,
        //        pedido_reserva = 0,
        //        articulo_reserva = 0,
        //        total_reserva = 0,
        //        fecha_reserva = query.FechaHoraServer(),
        //        fecha_fin = query.FechaHoraServer(),
        //        observacion_reserva = ""
        //    };
        //    return Reserva;
        //}
        #endregion

        #region CRUD
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            controlesFormulario(false);
            txtPHabitacion.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvHabitacion.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            controlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            _habitacionN = new HabitacionNegocio();
            _habitacionE = new Habitacion();
            _flag = false;
            if (dgvHabitacion.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _habitacionE = Asignar();
                _habitacionE.estado_habitacion = false;
                _habitacionN.Update(_habitacionE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _habitacionN = new HabitacionNegocio();
            string _piso = this.txtPHabitacion.Text.Trim();
            string _habitacion = this.txtNHabitacion.Text.Trim();

            if(int.Parse(txtCapacidadMaxima.Text) >4)
            {
                MessageBox.Show("La capacidad máxima es 4 personas por habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCapacidadMaxima.Focus();
                return;
            }

            if (_flag)
            {
                if (_habitacionN.SelectCount(q => q.estado_habitacion == true && q.piso_habitacion == _piso && q.numero_habitacion == _habitacion) > 0)
                {
                    MessageBox.Show("La Habitación ya ha sido registrada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPHabitacion.Focus();
                    return;
                }
                //ObjReserva = new ReservaBLL();
                //ObjDetalleTarifa = new Detalle_tarifaBLL();
                //int ID_HABITACION = BLL.Registrar(Asignar());
                //int ID_DETALLE_TARIFA = ObjDetalleTarifa.SelectList(q => q.id_categoria_habitacion == _categoria).First().id_detalle_tarifa;
                //ObjReserva.Insert(Reserva(ID_HABITACION, ID_DETALLE_TARIFA));
                _habitacionN.Insert(Asignar());
            }
            else
            {
                if (_NHabitacion.Equals(_habitacion) == false)
                {
                    if (_habitacionN.SelectCount(q => q.estado_habitacion == true &&
                                             q.numero_habitacion == _habitacion &&
                                             q.piso_habitacion == _piso) > 0)
                        {
                            MessageBox.Show("La Habitación ya ha sido registrada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtNHabitacion.Focus();
                            return;
                        }                  
                }
                if (_Piso.Equals(_piso) == false)
                {
                    if (_habitacionN.SelectCount(q => q.estado_habitacion == true &&
                                             q.numero_habitacion == _habitacion &&
                                             q.piso_habitacion == _piso) > 0)
                    {
                        MessageBox.Show("La Habitación ya ha sido registrada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtNHabitacion.Focus();
                        return;
                    }
                }
                _habitacionN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHabitacion.Select();
            controlesFormulario(true);
            CargaRegistros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvHabitacion.Select();
            controlesFormulario(true);
            CargaRegistros();
        }
        #endregion

        private void dgvHabitacion_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvHabitacion.CurrentRow != null)
                {
                    _Piso = dgvHabitacion.CurrentRow.Cells[2].Value.ToString().Trim();
                    _NHabitacion = dgvHabitacion.CurrentRow.Cells[1].Value.ToString().Trim();
                }
            }
            catch { }
        }

        private void FrmHabitacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
