using System;
using System.Configuration;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Configuracion
{
    public partial class FrmConfCheck : Form
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public FrmConfCheck()
        {
            InitializeComponent();
            CargarConfig();
        }

        #region Abrir formulario solo una vez
        private static FrmConfCheck _mFormDefInstance;
        public static FrmConfCheck DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConfCheck();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        #region CRUD 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfig();
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void GuardarConfig()
        {
            config.AppSettings.Settings["HCheckIN"].Value = nupHoraCkI.Value.ToString("00");
            config.AppSettings.Settings["MCheckIN"].Value = nuMinutoCkI.Value.ToString("00");
            config.AppSettings.Settings["HCheckOUT"].Value = nupHoraCkO.Value.ToString("00");
            config.AppSettings.Settings["MCheckOUT"].Value = nuMinutoCkO.Value.ToString("00");
            config.AppSettings.Settings["AnioHotel"].Value = txtAnio.Text;
            config.AppSettings.Settings["hora_otro_dia"].Value = txtHora.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void CargarConfig()
        {
            nupHoraCkI.Value = decimal.Parse(config.AppSettings.Settings["HCheckIN"].Value);
            nuMinutoCkI.Value = decimal.Parse(config.AppSettings.Settings["MCheckIN"].Value);
            nupHoraCkO.Value = decimal.Parse(config.AppSettings.Settings["HCheckOUT"].Value);
            nuMinutoCkO.Value = decimal.Parse(config.AppSettings.Settings["MCheckOUT"].Value);
            txtHora.Text = (config.AppSettings.Settings["hora_otro_dia"].Value);
            txtAnio.Text = config.AppSettings.Settings["AnioHotel"].Value;
        }

        #endregion

        private void FrmConfCheck_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
