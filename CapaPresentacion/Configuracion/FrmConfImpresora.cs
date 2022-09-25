using System;
using System.Configuration;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion.Configuracion
{
    public partial class FrmConfImpresora : Form
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public FrmConfImpresora()
        {
            InitializeComponent();
            cargaDatos();
            cargar();
        }

        #region Abrir formulario solo una vez
        private static FrmConfImpresora _mFormDefInstance;
        public static FrmConfImpresora DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConfImpresora();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void cargaDatos()
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(strPrinter.ToUpper());
            }
        }

        private void cargar()
        {
            try
            {
                cboPrinter.SelectedItem = ConfigurationManager.AppSettings["nombre_impresora"];
            }
            catch
            {
                MessageBox.Show(this, "No hay impresora pre-determinada", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            config.AppSettings.Settings["nombre_impresora"].Value = cboPrinter.SelectedItem.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FrmConfImpresora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
