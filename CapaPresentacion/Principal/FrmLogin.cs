using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Principal
{
    public partial class FrmLogin : Form
    {
        int _intentos = 3;
        public bool _open = true;
        Usuario _usuarioE;
        UsuarioNegocio _usuarioN;
        CajaDiaNegocio _cajaDiaN;
        HashByte _md5;

        public FrmLogin()
        {
            //if (_open)
            //{
            //    try
            //    {
            //        //Administrativo u = new Administrativo();
            //        //AdministrativoBLL us = new AdministrativoBLL();
            //        ////u = us.ListarUno(q => q.estado_usuario.Equals(true) && q.user_usuario.Equals("support"));
            //        ////Thread t = new Thread(new ThreadStart(SplashStart));
            //        ////t.Start();
            //        ////Thread.Sleep(4000);
            //        ////t.Abort();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Error al cargar la BD.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}            
            InitializeComponent();
            this.txtUsuario.CharacterCasing = CharacterCasing.Normal;
            this.txtPassword.CharacterCasing = CharacterCasing.Normal;
            this.txtPassword.PasswordChar = '•';
            txtUsuario.Focus();
        }

        #region
        public void SplashStart()
        {
            //try
            //{
            //    Application.Run(new Splash());
            //}
            //catch { }
        }
        #endregion

        private void Logeo(string _login, string _password)
        {
            _usuarioE = new Usuario();
            _usuarioN = new UsuarioNegocio();
            _cajaDiaN = new CajaDiaNegocio();

            _md5 = new HashByte();
            int idCajaDia = 0;
            _usuarioE = _usuarioN.SelectSingle(q => q.estado_usuario == true && q.login_usuario == _login);
            if (_cajaDiaN.SelectCount(item => item.usuario_apertura == _usuarioE.id && item.estado_apertura_caja_dia) > 0)
            {
                idCajaDia = _cajaDiaN.SelectSingle(item => item.usuario_apertura == _usuarioE.id && item.estado_apertura_caja_dia).id;
            }


            byte[] password = _md5.ConvertStringtoMD5(_password);
            if (_usuarioE != null)
            {
                if (_usuarioE.password_usuario.SequenceEqual(password))
                {
                    string _usuarioActivo = _usuarioE.nombre_usuario + ", " + _usuarioE.paterno_usuario + " " +
                                            _usuarioE.materno_usuario;
                    MessageBox.Show(this, "BIENVENIDO: "+ _usuarioE.login_usuario, ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMenu frm = new FrmMenu(_usuarioActivo);
                    _intentos = 3;
                    GuardarConfig(_usuarioE.id, idCajaDia);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    _intentos--;
                    MessageBox.Show(this, string.Format("Contraseña incorrecta. Quedan {0} intentos", _intentos), ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarFormulario();
                }
            }
            else
            {
                _intentos--;
                MessageBox.Show(this, string.Format("Usuario no existe. Quedan {0} intentos", _intentos), ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarFormulario();
            }

            if (_intentos == 0)
            {
                Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show(this, "Ingresse un Usuario", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show(this, "Ingresse un Contraseña", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                Logeo(txtUsuario.Text.Trim(), txtPassword.Text.Trim());
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.Select();
                btnIngresar_Click(null, null);
            }
        }

        private void GuardarConfig(int idUsuario, int idCajaDia)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["id_usuario"].Value = idUsuario.ToString();
            config.AppSettings.Settings["id_caja_dia"].Value = idCajaDia.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtUsuario.Focus();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
