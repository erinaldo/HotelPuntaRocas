using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmTarifaHabitacion : Form
    {
        TarifaHabitacionNegocio  _tarfiHabitacionN;
        Tarifa_habitacion _tarfiHabitacionE;
        bool flag;
        string _nombreTarifa = "";

        public FrmTarifaHabitacion()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmTarifaHabitacion _mFormDefInstance;
        public static FrmTarifaHabitacion DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmTarifaHabitacion();
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
            _tarfiHabitacionN = new TarifaHabitacionNegocio();
            tarifahabitacionBindingSource.DataSource = _tarfiHabitacionN.SelectList(item => item.estado_tarifa_habitacion == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtTarifa.Enabled = !act;
            txtPrecioTarifa.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                tarifahabitacionBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    tarifahabitacionBindingSource.SuspendBinding();                    
                }
                txtTarifa.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Tarifa_habitacion Asignar()
        {
            _tarfiHabitacionE = new Tarifa_habitacion()
            {
                nombre_tarifa_habitacion = this.txtTarifa.Text,
                precio_tarifa_habitacion =  decimal.Parse(this.txtPrecioTarifa.Text),
                estado_tarifa_habitacion = true
            };
            if (flag) return _tarfiHabitacionE;
            if (dgvTarifaHabitacion.CurrentRow != null)
                _tarfiHabitacionE.id = int.Parse(dgvTarifaHabitacion.CurrentRow.Cells[0].Value.ToString());
            return _tarfiHabitacionE;
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
            if (dgvTarifaHabitacion.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _tarfiHabitacionN = new TarifaHabitacionNegocio();
            _tarfiHabitacionE = new Tarifa_habitacion();

            //
            //productoBLL = new ProductoBLL();

            flag = false;
            if (dgvTarifaHabitacion.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _tarfiHabitacionE = Asignar();
                //if (productoBLL.categoriaAsignada(E.id_categoria) != 0)
                //{
                //    MessageBox.Show("Esta operación no se puede realizar.\nLa Categoria Producto ya fue asignada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                _tarfiHabitacionE.estado_tarifa_habitacion = false;
                _tarfiHabitacionN.Update(_tarfiHabitacionE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _tarfiHabitacionN = new TarifaHabitacionNegocio();
            string nombreTarifa = (string.IsNullOrEmpty(this.txtTarifa.Text)) ? "" : this.txtTarifa.Text.Trim();
            if (nombreTarifa.Equals(""))
            {
                MessageBox.Show("Registre la Tarifa de la Habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTarifa.Focus();
                return;
            }


            if (flag)
            {
                if (_tarfiHabitacionN.SelectCount(q => q.estado_tarifa_habitacion == true && q.nombre_tarifa_habitacion == nombreTarifa) > 0)
                {
                    MessageBox.Show("La Tarifa de la Habitación ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtTarifa.Focus();
                    return;
                }
                _tarfiHabitacionN.Insert(Asignar());
            }
            else
            {
                if (_nombreTarifa.Equals(nombreTarifa) == false)
                {
                    if (_tarfiHabitacionN.SelectCount(q => q.estado_tarifa_habitacion == true && q.nombre_tarifa_habitacion == nombreTarifa) > 0)
                    {
                        MessageBox.Show("La Tarifa de la Habitación ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtTarifa.Focus();
                        return;
                    }
                }
                _tarfiHabitacionN.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTarifaHabitacion.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvTarifaHabitacion.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion



        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
                if (dgvTarifaHabitacion.CurrentRow != null)
                    _nombreTarifa = dgvTarifaHabitacion.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtTarifa_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void FrmTarifaHabitacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
