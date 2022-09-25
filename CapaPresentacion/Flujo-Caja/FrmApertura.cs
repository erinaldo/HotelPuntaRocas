using System;
using System.Configuration;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Flujo_Caja
{
    public partial class FrmApertura : Form
    {
        CajaDiaNegocio _cajaDiaN;
        Caja_dia _cajaDiaE;
        CajaNegocio _cajaN;
        UsuarioNegocio _usuarioN;
        readonly Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        readonly int _idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        string _numeroCaja = "";

        string _usuario = "";
        public FrmApertura()
        {
            InitializeComponent();
            preCarga();
        }

        private void preCarga()
        {
            _cajaN = new CajaNegocio();
            _usuarioN = new UsuarioNegocio();
            _numeroCaja = _cajaN.SelectSingle(q => q.id_caja == _idCaja).numero_caja;
            _usuario = _usuarioN.SelectSingle(q => q.id == _idUsuario).login_usuario;
            lblCaja.Text = "Número de Caja N° " + _numeroCaja;
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy hh:mm:ss tt");
        }

        #region Abrir formulario solo una vez
        private static FrmApertura _mFormDefInstance;
        public static FrmApertura DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmApertura();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _cajaDiaN = new CajaDiaNegocio();
            if (string.IsNullOrEmpty(txtMontoApertura.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                _cajaDiaN.Insert(Asignar());
                MessageBox.Show("La Caja N° " + _numeroCaja + " fue aperturada con éxitos por el usuario " + _usuario + ".", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _config.AppSettings.Settings["id_caja_dia"].Value = _cajaDiaE.id.ToString();
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Asignacion de la entidad
        private Caja_dia Asignar()
        {
            _cajaDiaE = new Caja_dia()
            {
                id = 0,
                id_caja = _idCaja,
                usuario_apertura = _idUsuario,
                estado_apertura_caja_dia = true,
                saldo_inicial = decimal.Parse(txtMontoApertura.Text),
                fecha_apertura =  DateTime.Now,
                fapertura_caja_dia = DateTime.Now.Date,
                estado_caja_dia = true
            };
            return _cajaDiaE;
        }
        #endregion

        private void txtMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtMontoApertura, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmApertura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
