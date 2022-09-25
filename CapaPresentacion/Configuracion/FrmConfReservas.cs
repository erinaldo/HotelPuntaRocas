using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Configuracion
{
    public partial class FrmConfReservas : Form
    {
        ConfiguracionNegocio _configuracionN;
        CapaEntidades.Configuracion _configuracionE;

        public FrmConfReservas()
        {
            InitializeComponent();
            CargaDatos(); 
        }

        #region Abrir formulario solo una vez
        private static FrmConfReservas _mFormDefInstance;
        public static FrmConfReservas DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConfReservas();
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
            _configuracionN = new ConfiguracionNegocio();
            configuracionBindingSource.DataSource = _configuracionN.SelectList(item => item.estado_configuracion == true, true);
        }

        #region Asignacion de la entidad
        private CapaEntidades.Configuracion Asignar()
        {
            _configuracionE = new CapaEntidades.Configuracion()
            {
                precio_delivery = decimal.Parse(this.txtPrecioDelivery.Text),
                igv_actual = decimal.Parse(this.txtIGVActual.Text),
                porcentaje_sobre_factura = decimal.Parse(this.txtSobreFactura.Text),
                estado_configuracion = true
            };
            return _configuracionE;
        }
        #endregion

        #region CRUD 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _configuracionN = new ConfiguracionNegocio();
           
            if (_configuracionN.SelectCount(item => item.estado_configuracion == true) > 0)
            {
                if (MessageBox.Show("¿Desea cambiar la configuración?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _configuracionN.CambiarConfiguracion();
                }
                else
                {
                    return;
                }
            }
            _configuracionN.Insert(Asignar());

            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargaDatos();
            this.Close();
        }
        #endregion

        private void txtPrecioDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtPrecioDelivery, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtIGVActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtIGVActual, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSobreFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtSobreFactura, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmConfReservas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
