using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.EditarTotales
{
    public partial class FrmRegistroEdicion : Form
    {
        public int idLiquidacion;
        public string serie, correlativo;
        public double total;

        int _idLiquidacion;
        public FrmRegistroEdicion()
        {
            InitializeComponent();

        }

        #region Abrir formulario solo una vez
        private static FrmRegistroEdicion _mFormDefInstance;
        public static FrmRegistroEdicion DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmRegistroEdicion();
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
            LiquidacionNegocio oNegocio = new LiquidacionNegocio();
            oNegocio.UpdateConsumoTotales(_idLiquidacion, double.Parse(lblSubTotal.Text), double.Parse(lblIGV.Text), double.Parse(lblTotal.Text));

            MessageBox.Show("Registro Editado", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmEditarLiquidacion_Load(object sender, EventArgs e)
        {
            lblTotal.Text = (Math.Round(total, 2, MidpointRounding.AwayFromZero)).ToString();
            lblIGV.Text = (Math.Round(total - (total / 1.10), 2, MidpointRounding.AwayFromZero)).ToString();
            lblSubTotal.Text = (Math.Round((total / 1.10), 2, MidpointRounding.AwayFromZero)).ToString();
            txtSerie.Text = serie.ToString();
            txtComprobante.Text = correlativo.ToString();

            _idLiquidacion = idLiquidacion;
           
        }

        private void lblTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double _total = double.Parse(lblTotal.Text);
                lblTotal.Text = (Math.Round(_total, 2, MidpointRounding.AwayFromZero)).ToString();
                lblIGV.Text = (Math.Round(_total - (_total / 1.10), 2, MidpointRounding.AwayFromZero)).ToString();
                lblSubTotal.Text = (Math.Round((_total / 1.10), 2, MidpointRounding.AwayFromZero)).ToString();
            }
        }

    }
}
