using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Gestion
{
    public partial class FrmCategoriaProducto : Form
    {
        CategoriaProductoNegocio _categoriaProductoN;
        Categoria_producto _categoriaProductoE;
        bool flag;
        string _nombreCategoria = "";

        //
        //ProductoBLL productoBLL;

        public FrmCategoriaProducto()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmCategoriaProducto _mFormDefInstance;
        public static FrmCategoriaProducto DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmCategoriaProducto();
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
            _categoriaProductoN = new CategoriaProductoNegocio();
            categoriaproductoBindingSource.DataSource = _categoriaProductoN.SelectList(item => item.estado_categoria_producto == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtCategoria.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                categoriaproductoBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    categoriaproductoBindingSource.SuspendBinding();                    
                }
                txtCategoria.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Categoria_producto Asignar()
        {
            _categoriaProductoN = new CategoriaProductoNegocio();
            _categoriaProductoE = new Categoria_producto()
            {
                nombre_categoria_producto = this.txtCategoria.Text.Trim(),
                estado_categoria_producto = true
            };
            if (flag) return _categoriaProductoE;
            if (dgvCategoria.CurrentRow != null)
                _categoriaProductoE.id = int.Parse(dgvCategoria.CurrentRow.Cells[0].Value.ToString());
            return _categoriaProductoE;
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
            if (dgvCategoria.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _categoriaProductoN = new CategoriaProductoNegocio();
            _categoriaProductoE = new Categoria_producto();

            //
            //productoBLL = new ProductoBLL();

            flag = false;
            if (dgvCategoria.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _categoriaProductoE = Asignar();
                //if (productoBLL.categoriaAsignada(E.id_categoria) != 0)
                //{
                //    MessageBox.Show("Esta operación no se puede realizar.\nLa Categoria Producto ya fue asignada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                _categoriaProductoE.estado_categoria_producto = false;
                _categoriaProductoN.Update(_categoriaProductoE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _categoriaProductoN = new CategoriaProductoNegocio();
            string nombreCategoria = (string.IsNullOrEmpty(this.txtCategoria.Text)) ? "" : this.txtCategoria.Text.Trim();
            if (nombreCategoria.Equals(""))
            {
                MessageBox.Show("Registre una categoria.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCategoria.Focus();
                return;
            }


            if (flag)
            {
                if (_categoriaProductoN.SelectCount(q => q.estado_categoria_producto == true && q.nombre_categoria_producto == nombreCategoria) > 0)
                {
                    MessageBox.Show("La categoria ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCategoria.Focus();
                    return;
                }
                _categoriaProductoN.Insert(Asignar());
            }
            else
            {
                if (_nombreCategoria.Equals(nombreCategoria) == false)
                {
                    if (_categoriaProductoN.SelectCount(q => q.estado_categoria_producto == true && q.nombre_categoria_producto == nombreCategoria) > 0)
                    {
                        MessageBox.Show("La categoria ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtCategoria.Focus();
                        return;
                    }
                }
                _categoriaProductoN.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCategoria.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvCategoria.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
                if (dgvCategoria.CurrentRow != null)
                    _nombreCategoria = dgvCategoria.CurrentRow.Cells[1].Value.ToString();
        }

        private void FrmCategoriaProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
