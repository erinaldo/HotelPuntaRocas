using System;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmEmpresa : Form
    {
        EmpresaNegocio _empresaN;
        Empresa _empresaE;

        bool _flag;
        string _rucEmpresa = "";
        string _nombreEmpresa = "";

        public FrmEmpresa()
        {
            InitializeComponent();
            CargarRegistros();
            controlesFormulario(true);
        }

        #region Abrir formulario solo una vez
        private static FrmEmpresa m_FormDefInstance;
        public static FrmEmpresa DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmEmpresa();
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
            _empresaN = new EmpresaNegocio();
            empresaBindingSource.DataSource = _empresaN.SelectList(item => item.estado_empresa == true, true);
        }

        #region Control de las acciones del formulario
        private void controlesFormulario(bool act)
        {
            txtRazonSocial.Enabled = !act;
            txtDireccion.Enabled = !act;
            txtRUC.Enabled  = !act;

            btnBuscar.Enabled = act;
            btnLimpiar.Enabled = act;
            txtBusqueda.Enabled = act;
            fRadioButton1.Enabled = act;
            fRadioButton2.Enabled = act;

            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                empresaBindingSource.ResumeBinding();
                CargarRegistros();
            }
            else
            {
                if (_flag)
                {
                    empresaBindingSource.SuspendBinding();                    
                }
                txtRazonSocial.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Empresa Asignar()
        {
            _empresaE = new Empresa()
            {
                nombre_empresa = this.txtRazonSocial.Text.Trim(),
                ruc_empresa = this.txtRUC.Text.Trim(),
                direccion_empresa = this.txtDireccion.Text .Trim(),
                estado_empresa = true
            };
            if (!_flag)
                if (dgvProveedor.CurrentRow != null)
                    _empresaE.id = int.Parse(dgvProveedor.CurrentRow.Cells[0].Value.ToString());
            return _empresaE;
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

            _empresaN = new EmpresaNegocio();
            _empresaE = new Empresa();
            _flag = false;
            if (dgvProveedor.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _empresaE.estado_empresa = false;
                _empresaN.Update(_empresaE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _empresaN = new EmpresaNegocio();
            string _numero_documento = this.txtRUC.Text.Trim();
            string _nombre_empresa = this.txtRazonSocial.Text.Trim();

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

            if (_flag)
            {
                if (_empresaN.SelectCount(q => q.estado_empresa == true && q.ruc_empresa == _numero_documento) > 0)
                {
                    MessageBox.Show("La empresa ya ha sido registrada con este RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_empresaN.SelectCount(q => q.estado_empresa == true && q.nombre_empresa == _nombre_empresa) > 0)
                {
                    MessageBox.Show("La empresa ya ha sido registrada con esta razón social.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtRazonSocial.Focus();
                    return;
                }
                _empresaN.Insert(Asignar());
            }
            else
            {
                if (_rucEmpresa.Equals(_numero_documento) == false)
                {
                    if (_empresaN.SelectCount(q => q.estado_empresa == true && q.ruc_empresa == _numero_documento) > 0)
                    {
                        MessageBox.Show("La empresa ya ha sido registrada con este RUC.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtRUC.Focus();
                        return;
                    }
                }
                if (_nombreEmpresa.Equals(_nombre_empresa) == false)
                {
                    if (_empresaN.SelectCount(q => q.estado_empresa == true && q.nombre_empresa == _nombre_empresa) > 0)
                    {
                        MessageBox.Show("La empresa ya ha sido registrada con esta razón social.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtRazonSocial.Focus();
                        return;
                    }
                }
                _empresaN.Update(Asignar());
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
                _rucEmpresa = dgvProveedor.CurrentRow == null ? "" : dgvProveedor.CurrentRow.Cells[2].Value.ToString();
                _nombreEmpresa = dgvProveedor.CurrentRow == null ? "" : dgvProveedor.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyNumbers(e))
                MessageBox.Show("Ingrese solo números.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (fRadioButton1.Checked)
            {
                lblBuscar.Text = "Busqueda por RUC";
                txtBusqueda.Text = "";
            }
        }

        private void fRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (fRadioButton2.Checked)
            {
                lblBuscar.Text = "Busqueda por Razón Social";
                txtBusqueda.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (fRadioButton1.Checked)
            {
                _empresaN = new EmpresaNegocio();
                empresaBindingSource.DataSource = _empresaN.SelectList(item => item.ruc_empresa == txtBusqueda.Text.Trim(), true);
                return;
            }
            if (fRadioButton2.Checked)
            {
                _empresaN = new EmpresaNegocio();
                empresaBindingSource.DataSource = _empresaN.SelectList(item => item.nombre_empresa.Contains(txtBusqueda.Text), true);
                return;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            _empresaN = new EmpresaNegocio();
            empresaBindingSource.DataSource = _empresaN.SelectList(null, true);
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void FrmEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
