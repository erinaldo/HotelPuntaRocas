using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using OfficeOpenXml;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaLiquidar : Form
    {
        private readonly int _idLiquidacion;
        private readonly int _idReserva;
        private LiquidacionNegocio _oLiquidacionN;
        private ReservaNegocio _oReservaN;

        private readonly bool _estado;
        private string _tipoComprobante;


        public FrmReservaLiquidar(int idLiquidacion, int idReserva, bool estado, string tipoComprobante)
        {
            InitializeComponent();
            _idLiquidacion = idLiquidacion;
            _idReserva = idReserva;
            _estado = estado;
            _tipoComprobante = tipoComprobante;

        }


        private void FrmReservaLiquidar_Load(object sender, EventArgs e)
        {

        }

        private void btnBoletear_Click(object sender, EventArgs e)
        {
            
            _oLiquidacionN = new LiquidacionNegocio();
            if (txtSerie.Text == "" || txtComprobante.Text == "")
            {
                MessageBox.Show("Debe de ingresar todos los datos", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (
                _oLiquidacionN.SelectCount(
                    item =>
                        item.serie_liquidacion == txtSerie.Text.Trim() &&
                        item.correlativo_liquidacion == txtComprobante.Text.Trim() &&
                        item.tipo_comprobante_liquidacion == _tipoComprobante &&
                        item.estado_liquidacion) > 0)
            {
                MessageBox.Show("Ya registro este número de comprobante " + txtSerie.Text.Trim() + "-" + txtComprobante.Text.Trim(), ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _oLiquidacionN.ActualizarComprobante(_idLiquidacion, txtSerie.Text.Trim(), txtComprobante.Text.Trim());
                MessageBox.Show("Se actualizó el comprobante: " + txtSerie.Text.Trim() + "-" + txtComprobante.Text.Trim(), ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _oReservaN = new ReservaNegocio();
                //if (_estado)
                //    _oReservaN.TerminarHospedaje(_idReserva);
                //else
                //    _oReservaN.PagoParcialHospedaje(_idReserva);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FrmReservaLiquidar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

}
