using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmCaja : Form
    {
        CajaNegocio _cajaN;
        Caja _cajaE;
        bool flag;
        string _nombreCaja = "";

        public FrmCaja()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmCaja _mFormDefInstance;
        public static FrmCaja DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmCaja();
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
            _cajaN = new CajaNegocio();
            cajaBindingSource.DataSource = _cajaN.SelectList(item => item.estado_caja == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtCaja.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                cajaBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    cajaBindingSource.SuspendBinding();                    
                }
                txtCaja.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Caja Asignar()
        {
            _cajaE = new Caja()
            {
                numero_caja = this.txtCaja.Text.Trim(),
                estado_caja = true
            };
            if (flag) return _cajaE;
            if (dgvCaja.CurrentRow != null)
                _cajaE.id_caja = int.Parse(dgvCaja.CurrentRow.Cells[0].Value.ToString());
            return _cajaE;
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
            if (dgvCaja.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _cajaN = new CajaNegocio();
            _cajaE = new Caja();

            //
            //productoBLL = new ProductoBLL();

            flag = false;
            if (dgvCaja.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cajaE = Asignar();
                //if (productoBLL.categoriaAsignada(E.id_categoria) != 0)
                //{
                //    MessageBox.Show("Esta operación no se puede realizar.\nLa Categoria Producto ya fue asignada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                _cajaE.estado_caja = false;
                _cajaN.Update(_cajaE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _cajaN = new CajaNegocio();
            string nombreCaja = (string.IsNullOrEmpty(this.txtCaja.Text)) ? "" : this.txtCaja.Text.Trim();
            if (nombreCaja.Equals(""))
            {
                MessageBox.Show("Registre un número de caja.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCaja.Focus();
                return;
            }


            if (flag)
            {
                if (_cajaN.SelectCount(q => q.estado_caja == true && q.numero_caja == nombreCaja) > 0)
                {
                    MessageBox.Show("El número de caja ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCaja.Focus();
                    return;
                }
                _cajaN.Insert(Asignar());
            }
            else
            {
                if (_nombreCaja.Equals(nombreCaja) == false)
                {
                    if (_cajaN.SelectCount(q => q.estado_caja == true && q.numero_caja == nombreCaja) > 0)
                    {
                        MessageBox.Show("El número de caja ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtCaja.Focus();
                        return;
                    }
                }
                _cajaN.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCaja.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvCaja.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion



        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
                if (dgvCaja.CurrentRow != null)
                    _nombreCaja = dgvCaja.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.OnlyNumbers(e);
        }

        private void FrmCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
