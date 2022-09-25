using System;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmProveedor : Form
    {
        ProveedorNegocio _proveedorN;
        Proveedor _proveedorE;

        //CompraBLL compraBLL;


        bool _flag;
        string _rucProveedor = "";
        string _nombreProveedor = "";

        public FrmProveedor()
        {
            InitializeComponent();
            CargarRegistros();
            controlesFormulario(true);
        }

        #region Abrir formulario solo una vez
        private static FrmProveedor m_FormDefInstance;
        public static FrmProveedor DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmProveedor();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        #endregion

        private void CargarRegistros()
        {
            _proveedorN = new ProveedorNegocio();
            proveedorBindingSource.DataSource = _proveedorN.SelectList(item => item.estado_proveedor == true, true).OrderBy(item => item.razons_proveedor);
        }

        #region Control de las acciones del formulario
        private void controlesFormulario(bool act)
        {
            txtRazonSocial.Enabled = !act;
            txtDireccion.Enabled = !act;
            txtRUC.Enabled  = !act;
            txtCelular.Enabled = !act;
            txtTelefono.Enabled = !act;

            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                proveedorBindingSource.ResumeBinding();
                CargarRegistros();
            }
            else
            {
                if (_flag)
                {
                    proveedorBindingSource.SuspendBinding();                    
                }
                txtRazonSocial.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Proveedor Asignar()
        {
            _proveedorN = new ProveedorNegocio();
            _proveedorE = new Proveedor()
            {
                razons_proveedor = this.txtRazonSocial.Text.Trim(),
                ruc_proveedor = this.txtRUC.Text.Trim(),
                celular_proveedor = this.txtCelular.Text.Trim(),
                telefono_proveedor = this.txtTelefono.Text.Trim(),
                direccion_proveedor = this.txtDireccion.Text .Trim(),
                fregistro_proveedor = DateTime.Now,
                estado_proveedor = true
            };
            if (!_flag)
                _proveedorE.id_proveedor = int.Parse(dgvProveedor.CurrentRow.Cells[0].Value.ToString());
            return _proveedorE;
        }
        #endregion

        #region CRUD         
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            controlesFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            controlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _proveedorN = new ProveedorNegocio();
            _proveedorE = new Proveedor();
            //compraBLL = new CompraBLL();
            _flag = false;
            if (dgvProveedor.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //E = Asignar();
                //if (compraBLL.proveedorCompro(E.id_proveedor) != 0)
                //{
                //    MessageBox.Show("Esta operación no se puede realizar.\nEl Proveedor ya fue registrado en las compras..", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                _proveedorE.estado_proveedor = false;
                _proveedorN.Update(_proveedorE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _proveedorN = new ProveedorNegocio();
            string _numero_documento = this.txtRUC.Text.Trim();
            string _nombre_proveedor = this.txtRazonSocial.Text.Trim();

            if (this.txtRazonSocial.Text == "")
            {
                MessageBox.Show("Debe ingresar la Razón Social.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(this.txtRUC.Text == "")
            {
                MessageBox.Show("Debe ingresar el RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtRUC.Focus();
                return;
            }
            if (this.txtDireccion.Text == "")
            {
                MessageBox.Show("Debe ingresar la dirección.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDireccion.Focus();
                return;
            }
            if (this.txtCelular.Text == "")
            {
                MessageBox.Show("Debe ingresar el celular.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCelular.Focus();
                return;
            }


            if (_flag)
            {
                if (_proveedorN.SelectCount(q => q.estado_proveedor == true && q.ruc_proveedor == _numero_documento) > 0)
                {
                    MessageBox.Show("El proveedor ya ha sido registrado con este RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_proveedorN.SelectCount(q => q.estado_proveedor == true && q.razons_proveedor == _nombre_proveedor) > 0)
                {
                    MessageBox.Show("El proveedor ya ha sido registrado con esta razón social.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtRazonSocial.Focus();
                    return;
                }
                _proveedorN.Insert(Asignar());
            }
            else
            {
                if (_rucProveedor.Equals(_numero_documento) == false)
                {
                    if (_proveedorN.SelectCount(q => q.estado_proveedor == true && q.ruc_proveedor == _numero_documento) > 0)
                    {
                        MessageBox.Show("El proveedor ya ha sido registrado con este RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtRUC.Focus();
                        return;
                    }
                }
                if (_nombreProveedor.Equals(_nombre_proveedor) == false)
                {
                    if (_proveedorN.SelectCount(q => q.estado_proveedor == true && q.razons_proveedor == _nombre_proveedor) > 0)
                    {
                        MessageBox.Show("El proveedor ya ha sido registrado con esta razón social.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtRazonSocial.Focus();
                        return;
                    }
                }
                _proveedorN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvProveedor.Select();
            controlesFormulario(true);
            CargarRegistros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvProveedor.Select();
            controlesFormulario(true);
            CargarRegistros();
        }
        #endregion

        private void dgvPersona_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                _rucProveedor = dgvProveedor.CurrentRow == null ? "" : dgvProveedor.CurrentRow.Cells[2].Value.ToString();
                _nombreProveedor = dgvProveedor.CurrentRow == null ? "" : dgvProveedor.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyNumbers(e))
                MessageBox.Show("Ingrese solo números.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyNumbers(e))
                MessageBox.Show("Ingrese solo números.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyNumbers(e))
                MessageBox.Show("Ingrese solo números.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
