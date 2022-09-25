using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Ediciones
{
    public partial class FrmEditarTarjeta : Form
    {
        public int idLiquidacion;
        public string serie, correlativo, tipo_comprobante;
        public double total;
        public string referencia, numero_tarjeta;

        int _idLiquidacion;
        public FrmEditarTarjeta()
        {
            InitializeComponent();

        }

        #region Abrir formulario solo una vez
        private static FrmEditarTarjeta _mFormDefInstance;
        public static FrmEditarTarjeta DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmEditarTarjeta();
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
            oNegocio.UpdateTarjeta(_idLiquidacion, TipoPago(),  double.Parse(lblTotal.Text),txtReferencia.Text,txtNTarjeta.Text);
            MessageBox.Show("Registro Editado", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        public string TipoPago()
        {
            if (rbtTarjeta.Checked)
                return "T";
            else
                return "";
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
            if (tipo_comprobante == "T")
            {
                rbtTarjeta.Checked = true;
                txtReferencia.Text = referencia;
                txtNTarjeta.Text = numero_tarjeta;
            }
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

        private void rbtEfectivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            txtNTarjeta.Visible = true;
            txtReferencia.Visible = true;

            lblNTarjeta.Visible = true;
            lblReferencia.Visible = true;
        }

    }
}
