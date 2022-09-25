using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmHabitacionTarifa : Form
    {
        HabitacionTarifaNegocio _habitacionTarifaNegocio;
        HabitacionTarifa _habitacionTarifa;

        HabitacionNegocio _habitacionNegocio;
        TarifaHabitacionNegocio _tarifaHabitacionNegocio;

        bool flag;

        public FrmHabitacionTarifa()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);
            CargarCombos();
        }

        #region Abrir formulario solo una vez
        private static FrmHabitacionTarifa _mFormDefInstance;
        public static FrmHabitacionTarifa DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmHabitacionTarifa();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void CargaDatos()
        {
            _habitacionTarifaNegocio = new HabitacionTarifaNegocio();
            vistaHabitacionTarifaBindingSource.DataSource = _habitacionTarifaNegocio.SelectListView(null, true);
        }

        private void CargarCombos()
        {
            _habitacionNegocio = new HabitacionNegocio();
            vistaHabitacionBindingSource.DataSource = _habitacionNegocio.SelectListView(null, true);

            _tarifaHabitacionNegocio = new TarifaHabitacionNegocio();
            tarifahabitacionBindingSource.DataSource =
                _tarifaHabitacionNegocio.SelectList(item => item.estado_tarifa_habitacion);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            cboHabitacion.Enabled = !act;
            cboTarifa.Enabled = !act;
            cboTarifa.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                vistaHabitacionBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    vistaHabitacionBindingSource.SuspendBinding();                    
                }
            }
        }
        #endregion

        #region Asignacion de la entidad
        private HabitacionTarifa Asignar()
        {
            _habitacionTarifa = new HabitacionTarifa()
            {
                id_habitacion = int.Parse(cboHabitacion.SelectedValue.ToString()),
                id_tarifa = int.Parse(cboTarifa.SelectedValue.ToString()),
                fecha_creacion = DateTime.Now,
                estado = true
            };
            if (flag) return _habitacionTarifa;
            if (dgvDatos.CurrentRow != null)
                _habitacionTarifa.id = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            return _habitacionTarifa;
        }
        #endregion

        #region CRUD 


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flag = true;
            ControlesFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _habitacionTarifaNegocio = new HabitacionTarifaNegocio();
            _habitacionTarifa = new HabitacionTarifa();

            flag = false;
            if (dgvDatos.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _habitacionTarifa = Asignar();
                _habitacionTarifa.estado = false;
                _habitacionTarifaNegocio.Update(_habitacionTarifa);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _habitacionTarifaNegocio = new HabitacionTarifaNegocio();

            int habitacion = int.Parse(cboHabitacion.SelectedValue.ToString());
            int tarifa = int.Parse(cboTarifa.SelectedValue.ToString());

            if (flag)
            {
                if (_habitacionTarifaNegocio.SelectCount(q => q.id_habitacion == habitacion && q.id_tarifa == tarifa && q.estado == true) > 0)
                {
                    MessageBox.Show("Ya existe una tarifa asignada a esa habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cboHabitacion.Focus();
                    return;
                }
                _habitacionTarifaNegocio.Insert(Asignar());
            }
            else
            {
                _habitacionTarifaNegocio.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDatos.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvDatos.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion

        private void FrmHabitacionTarifa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
