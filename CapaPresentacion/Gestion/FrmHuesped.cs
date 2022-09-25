using CapaPresentacion.Functions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Pop_up;

namespace CapaPresentacion.Gestion
{
    public partial class FrmHuesped : Form
    {
        HuespedNegocio _huespedN;
        Huesped _huespedE;

        bool _flag;

        string _dniHuesped = "";
        string _nombreHuesped = "";

        public FrmHuesped()
        {
            InitializeComponent();
            CargarRegistros();
            ControlesFormulario(true);
            dgvUsuario.Columns[0].Visible = false;
        }

        #region Abrir formulario solo una vez
        private static FrmHuesped _mFormDefInstance;
        public static FrmHuesped DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmHuesped();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void CargarRegistros()
        {
            _huespedN = new HuespedNegocio();
            vistaHuespedListBindingSource.DataSource = _huespedN.SelectListView(null, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtPaterno.Enabled = !act;
            txtMaterno.Enabled = !act;
            txtNombre.Enabled = !act;
            txtDNI.Enabled = !act;
            txtRazonSocial.Enabled = !act;
            txtCelular.Enabled = !act;
            txtCorreoElectronico.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;

            if (act)
            {
                vistaHuespedListBindingSource.ResumeBinding();
                CargarRegistros();
            }
            else
            {
                if (_flag)
                {
                    vistaHuespedListBindingSource.SuspendBinding();
                }
                txtPaterno.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Huesped Asignar()
        {
            _huespedE = new Huesped()
            {
                paterno_huesped = txtPaterno.Text.Trim().ToUpper(),
                materno_huesped = txtMaterno.Text.Trim().ToUpper(),
                nombre_huesped = txtNombre.Text.Trim().ToUpper(),
                dni_huesped =  txtDNI.Text,
                celular_huesped = txtCelular.Text,
                email_huesped = txtCorreoElectronico.Text.Trim().ToUpper(),
                estado_huesped = true
            };
            int idEmpresa = string.IsNullOrEmpty(txtIdEmpresa.Text) ? 0 : int.Parse(txtIdEmpresa.Text);
            if (idEmpresa != 0)
                _huespedE.id_empresa = int.Parse(txtIdEmpresa.Text);

            if (_flag) return _huespedE;

            if (dgvUsuario.CurrentRow != null)
                _huespedE.id = int.Parse(dgvUsuario.CurrentRow.Cells[0].Value.ToString());
            return _huespedE;
        }
        #endregion

        #region CRUD 
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            ControlesFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _huespedN = new HuespedNegocio();
            _huespedE = new Huesped();
            _flag = false;
            if (dgvUsuario.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _huespedE.estado_huesped = false;
                _huespedN.Update(_huespedE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _huespedN = new HuespedNegocio();
            string dniHuesped = txtDNI.Text.Trim();
            string nombreHuesped = txtNombre.Text.Trim() + " " + txtPaterno.Text.Trim() + " " + txtMaterno.Text.Trim();

            if (_flag)
            {
                if (_huespedN.SelectCount(q => q.dni_huesped == dniHuesped) > 0)
                {
                    MessageBox.Show("Ya existe el DNI del Cliente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDNI.Focus();
                    return;
                }
                if (_huespedN.SelectListView(q => q.completo_huesped == nombreHuesped).Count > 0)
                {
                    MessageBox.Show("Ya existe el cliente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPaterno.Focus();
                    return;
                }
                _huespedN.Insert(Asignar());
            }
            else
            {
                if (_dniHuesped.Equals(dniHuesped) == false)
                {
                    if (_huespedN.SelectCount(q => q.dni_huesped == dniHuesped) > 0)
                    {
                        MessageBox.Show("Ya existe el DNI del Cliente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDNI.Focus();
                        return;
                    }
                }
                if (_nombreHuesped.Equals(nombreHuesped) == false)
                {
                    if (_huespedN.SelectListView(q => q.completo_huesped == nombreHuesped).Count > 0)
                    {
                        MessageBox.Show("Ya existe el cliente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPaterno.Focus();
                        return;
                    }
                }
                _huespedN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvUsuario.Select();
            ControlesFormulario(true);
            CargarRegistros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvUsuario.Select();
            ControlesFormulario(true);
            CargarRegistros();
        }
        #endregion

        private void dgvAdministrativo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuario.CurrentRow == null) return;
                _dniHuesped = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
                _nombreHuesped = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            PopUpBusquedaEmpresa frm = new PopUpBusquedaEmpresa();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                int _id = string.IsNullOrEmpty(frm.IdEmpresa.ToString()) ? 0 : int.Parse(frm.IdEmpresa.ToString());

                if (_id == 0)
                {
                    return;
                }
                else
                {
                    txtIdEmpresa.Text = frm.IdEmpresa.ToString();
                    txtRazonSocial.Text = frm.RznSocial;
                }
            }
        }

        private void fRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (fRadioButton1.Checked)
            {
                lblBuscar.Text = @"Busqueda por DNI";
                txtBusqueda.Text = "";
            }
        }

        private void fRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (fRadioButton2.Checked)
            {
                lblBuscar.Text = @"Busqueda por Huesped";
                txtBusqueda.Text = "";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             _huespedN = new HuespedNegocio();
            if (fRadioButton2.Checked)
            {
                vistaHuespedListBindingSource.DataSource =
                    _huespedN.SelectListView(item => item.completo_huesped.Contains(txtBusqueda.Text.ToUpper()), true);
            }
            if (fRadioButton1.Checked)
            {
                vistaHuespedListBindingSource.DataSource = _huespedN.SelectListView(item => item.dni_huesped.Equals(txtBusqueda.Text.ToUpper()), true);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            _huespedN = new HuespedNegocio();
            vistaHuespedListBindingSource.DataSource = _huespedN.SelectListView(null, true);
        }

        private void FrmHuesped_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmHuesped_Load(object sender, EventArgs e)
        {

        }
    }
}
