using CapaPresentacion.Functions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Seguridad
{
    public partial class FrmUsuario : Form
    {
        UsuarioNegocio _usuarioN;
        RolNegocio _rolN;
        Usuario _usuarioE;

        bool _flag;
        HashByte _md5;

        string _usuarioRegistro = "";

        public FrmUsuario()
        {
            InitializeComponent();
            CargarRegistros();
            CargaCombo();
            ControlesFormulario(true);
            CambiarPassword();
            dgvUsuario.Columns[0].Visible = false;
        }

        #region Abrir formulario solo una vez
        private static FrmUsuario _mFormDefInstance;
        public static FrmUsuario DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmUsuario();
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
            _usuarioN = new UsuarioNegocio();
            vistaUsuarioListBindingSource.DataSource = _usuarioN.SelectListView(null, true);
        }

        private void CargaCombo()
        {
            _rolN = new RolNegocio();
            rolBindingSource.DataSource = _rolN.SelectList(item => item.estado_rol, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtPaterno.Enabled = !act;
            txtMaterno.Enabled = !act;
            txtNombre.Enabled = !act;
            txtUsuario.Enabled = !act;
            txtContrasenia.Enabled = !act;
            cboRol.Enabled = !act;
            txtUsuario.Enabled = !act;
            ckbCambiaContrasenia.Enabled = !act;

            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;

            if (act)
            {
                vistaUsuarioListBindingSource.ResumeBinding();
                CargarRegistros();
            }
            else
            {
                if (_flag)
                {
                    vistaUsuarioListBindingSource.SuspendBinding();
                }
                txtPaterno.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Usuario Asignar()
        {
            _md5 = new HashByte();
            _usuarioN = new UsuarioNegocio();
            _usuarioE = new Usuario()
            {
                paterno_usuario = txtPaterno.Text.Trim().ToUpper(),
                materno_usuario = txtMaterno.Text.Trim().ToUpper(),
                nombre_usuario = txtNombre.Text.Trim().ToUpper(),
                id_rol = int.Parse(cboRol.SelectedValue.ToString()),
                login_usuario = txtUsuario.Text.Trim(),
                password_usuario = _md5.ConvertStringtoMD5(txtContrasenia.Text.Trim()),
                fecha_registro_usuario =  DateTime.Now,
                estado_usuario = true
            };

            if (!ckbCambiaContrasenia.Checked)
            {

                if (!_flag)
                {
                    if (dgvUsuario.CurrentRow != null)
                    {
                        int id = int.Parse(dgvUsuario.CurrentRow.Cells[0].Value.ToString());
                        byte[] password = _usuarioN.ObtenerPassword(id);
                        _usuarioE.password_usuario = password;
                    }
                }
            }
            if (_flag) return _usuarioE;
            if (dgvUsuario.CurrentRow != null)
                _usuarioE.id = int.Parse(dgvUsuario.CurrentRow.Cells[0].Value.ToString());
            return _usuarioE;
        }
        #endregion

        #region CRUD 
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            ControlesFormulario(false);
            ckbCambiaContrasenia.Checked = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            ckbCambiaContrasenia.Checked = true;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);

            _usuarioN = new UsuarioNegocio();
            _usuarioE = new Usuario();
            _flag = false;
            if (dgvUsuario.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _usuarioE = Asignar();
                if (_usuarioE.id == idUsuario)
                {
                    MessageBox.Show("La sesión esta ACTIVA. \nNo puede eliminarse el registro.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    _usuarioE.estado_usuario = false;
                    _usuarioN.Update(_usuarioE);
                    MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarRegistros();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _usuarioN = new UsuarioNegocio();
            string _usuarioTexto = txtUsuario.Text.Trim();

            if (cboRol.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un rol.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboRol.Focus();
                return;
            }

            if (_flag)
            {
                if (_usuarioN.SelectCount(q => q.login_usuario == _usuarioTexto) > 0)
                {
                    MessageBox.Show("Ya existe el nombre de usuario.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    return;
                }
                _usuarioN.Insert(Asignar());
            }
            else
            {
                if (_usuarioRegistro.Equals(_usuarioTexto) == false)
                {
                    if (_usuarioN.SelectCount(q => q.login_usuario == _usuarioTexto) > 0)
                    {
                        MessageBox.Show("Ya existe el nombre de usuario.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Focus();
                        return;
                    }
                }
                _usuarioN.Update(Asignar());
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

        private void ckbCambiaContrasenia_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenia.Enabled = ckbCambiaContrasenia.Checked;
        }

        private void CambiarPassword()
        {
            txtContrasenia.Enabled = ckbCambiaContrasenia.Checked;
        }

        private void dgvAdministrativo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuario.CurrentRow == null) return;
                _usuarioRegistro = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }
        }

        private void FrmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
