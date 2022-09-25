using System;
using System.Configuration;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Configuracion
{
    public partial class FrmConfCaja : Form
    {
        CajaNegocio _cajaN;
        readonly int _idCaja = int.Parse(ConfigurationManager.AppSettings["id_caja"]);
        public FrmConfCaja()
        {
            InitializeComponent();
            CargarCombo();
        }

        #region Abrir formulario solo una vez
        private static FrmConfCaja _mFormDefInstance;
        public static FrmConfCaja DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConfCaja();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void CargarCombo()
        {
            _cajaN = new CajaNegocio();
            if (_idCaja == 0)
                cajaBindingSource.DataSource = _cajaN.SelectList(item => item.estado_caja == true, true);
            else
            {
                cajaBindingSource.DataSource = _cajaN.SelectList(item => item.estado_caja == true, true);
                cboConcepto.SelectedValue = _idCaja;
            }
            
        }

        #region CRUD 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfig(int.Parse(cboConcepto.SelectedValue.ToString()), cboConcepto.Text);
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarCombo();
            Close();
        }

        private void GuardarConfig(int idCaja, string numero)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["id_caja"].Value = idCaja.ToString();
            config.AppSettings.Settings["numero_caja"].Value = numero;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion

        private void FrmConfCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
