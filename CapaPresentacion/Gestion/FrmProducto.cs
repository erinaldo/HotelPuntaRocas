using System;
using System.Drawing.Design;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmProducto : Form
    {
        ProductoNegocio _productoN;
        CategoriaProductoNegocio _categoriaProductoN;
        Producto _productoE;

        bool _flag;
        string _nombreProducto = "";

        public FrmProducto()
        {
            InitializeComponent();
            CargaDatos();
            CargaCombo();
            ControlesFormulario(true);
            dgvProducto.Columns[0].Visible = false;
        }

        #region Abrir formulario solo una vez
        private static FrmProducto _mFormDefInstance;
        public static FrmProducto DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmProducto();
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
            _productoN = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _productoN.SelectListView(null, true);
        }

        private void CargaCombo()
        {
            _categoriaProductoN = new CategoriaProductoNegocio();
            categoriaproductoBindingSource.DataSource = _categoriaProductoN.SelectList(item => item.estado_categoria_producto == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtProducto.Enabled = !act;
            cboCategoriaProducto.Enabled = !act;
            txtPrecioCosto.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                vistaProductoListBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (_flag)
                {
                    vistaProductoListBindingSource.SuspendBinding();
                }
                cboCategoriaProducto.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Producto Asignar()
        {
            _productoE = new Producto
            {
                id_categoria = int.Parse(this.cboCategoriaProducto.SelectedValue.ToString()),
                nombre_producto = this.txtProducto.Text.Trim(),
                precio_producto = decimal.Parse(this.txtPrecioCosto.Text.Trim()),
                tipo_producto = TipoProducto(),
                stock_producto = 0,
                estado_producto = true
            };
            if (_flag) return _productoE;
            if (dgvProducto.CurrentRow != null)
            {
                _productoE.id = int.Parse(dgvProducto.CurrentRow.Cells[0].Value.ToString());
                _productoE.stock_producto = int.Parse(txtStock.Text);
            }
            return _productoE;
        }
        #endregion

        #region CRUD


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            ControlesFormulario(false);
            this.txtProducto.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProducto.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _productoN = new ProductoNegocio();
            _productoE = new Producto();
            _flag = false;
            if (dgvProducto.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _productoE = Asignar();
                _productoE.estado_producto = false;
                _productoN.Update(_productoE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _productoN = new ProductoNegocio();
            string _nombre_producto = this.txtProducto.Text.Trim();

            if (this.cboCategoriaProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una categoria.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboCategoriaProducto.Focus();
                return;
            }
            if (decimal.Parse(this.txtPrecioCosto.Text) < 0)
            {
                MessageBox.Show("El costo del producto no puede ser menor a 0.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPrecioCosto.Focus();
                return;
            }
            if (_flag)
            {
                if (_productoN.SelectCount(q => q.estado_producto == true && q.nombre_producto == _nombre_producto) > 0)
                {
                    MessageBox.Show("El producto ya ha sido registrado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtProducto.Focus();
                    return;
                }
                _productoN.Insert(Asignar());
            }
            else
            {
                if (_nombreProducto.Equals(_nombre_producto) == false)
                {
                    if (_productoN.SelectCount(q => q.estado_producto == true && q.nombre_producto == _nombre_producto) > 0)
                    {
                        MessageBox.Show("El producto ya ha sido registrado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtProducto.Focus();
                        return;
                    }
                }
                _productoN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvProducto.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvProducto.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) &&
                (e.KeyChar != (char)Keys.Back) &&
                (e.KeyChar != (char)Keys.Space) &&
                (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dgvProducto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                _nombreProducto = dgvProducto.CurrentRow == null ? "" : dgvProducto.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtPrecioCosto, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string TipoProducto()
        {
            string tipoProducto = null;
            if (rbtCompraInterna.Checked)
                tipoProducto = "1";
            if (rbtConsumo.Checked)
                tipoProducto = "2";

            return tipoProducto;
        }

        private void FrmProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
