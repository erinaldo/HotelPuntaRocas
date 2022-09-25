using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Flujo_Caja
{
    public partial class FrmCierre : Form
    {
        private CajaDiaNegocio _oCajaDiaN;
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        private decimal _efectivo = 0;
        private decimal _tarjeta = 0;
        private decimal _adicional = 0;
        private decimal _consumo = 0;
        private decimal _hospedaje = 0;
        public FrmCierre()
        {
            InitializeComponent();
            CalcularTotal();
            CalcularEgreso();
            CalcularDiferencia();
            CalcularAdelanto();
            Cargar();
        }



        #region Abrir formulario solo una vez
        private static FrmCierre _mFormDefInstance;
        public static FrmCierre DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmCierre();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion


        private void Cargar()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            _efectivo = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalEfectivo;
            _tarjeta = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalTarjeta;

            _adicional = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalAdicional;

            _consumo = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalConsumo;
            _hospedaje = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalReal;

            lblAdelantos.Text = @"S/. " + CalcularAdelanto().ToString("F");
            lblEgresos.Text = @"S/. " + CalcularEgreso().ToString("F");
            lblDescuentos.Text = @"S/. " + CalcularDescuento().ToString("F");
            lblEfectivo.Text = @"S/. " + (_efectivo + _consumo).ToString("F");
            lblTarjeta.Text = @"S/. " + _tarjeta.ToString("F");
            txtApertura.Text = @"S/. " + Apertura().ToString("F");
            lblAdicional.Text = @"S/. " + _adicional.ToString("F");
            lblHospedaje.Text = @"S/. " + (_efectivo + _tarjeta + _adicional + CalcularAdelanto()).ToString("F");
            lblConsumo.Text = @"S/. " + (_consumo).ToString("F");
            txtCierre.Text = @"S/. " + (CalcularTotal() - CalcularDescuento() - CalcularEgreso() + Apertura() + CalcularAdelanto()).ToString("F");
            lblTotalDia.Text = @"S/. " + (_efectivo + _consumo + _tarjeta + _adicional + CalcularAdelanto() - CalcularDescuento()).ToString("F");
        }

        private decimal CalcularTotal()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            decimal efectivo = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalEfectivo ;
            decimal tarjeta = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalTarjeta;
            decimal adicional = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalAdicional;
            decimal consumo = (decimal)_oCajaDiaN.TotalHotelByIdCajaDia(_idCajaDia).SingleOrDefault().TotalConsumo ;
            decimal total = efectivo + tarjeta + adicional + consumo;
            return total;
        }
        private decimal CalcularEgreso()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            decimal egreso = _oCajaDiaN.TotalEgresoByIdCajaDia(_idCajaDia).SingleOrDefault().Value;
            return egreso;
        }

        private decimal CalcularDescuento()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            decimal descuento = _oCajaDiaN.TotalDescuentoByIdCajaDia(_idCajaDia).SingleOrDefault().Value;
            return descuento;
        }
        private decimal CalcularDiferencia()
        {
            decimal total = CalcularTotal() - CalcularEgreso();
            return total;
        }
        private decimal CalcularAdelanto()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            decimal montoACuenta = _oCajaDiaN.TotalMontoACuentaByIdCajaDia(_idCajaDia).SingleOrDefault().Value;
            return montoACuenta;
        }

        private decimal Apertura()
        {
            _oCajaDiaN = new CajaDiaNegocio();
            decimal montoApertura = _oCajaDiaN.SelectSingle(item => item.id == _idCajaDia).saldo_inicial;
            return montoApertura;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _oCajaDiaN = new CajaDiaNegocio();
            _oCajaDiaN.CierreCaja(_idCajaDia, _idUsuario, CalcularTotal(), CalcularDiferencia(), CalcularEgreso());
            MessageBox.Show("Cierre de Caja realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblAdicional_Click(object sender, EventArgs e)
        {

        }

        private void FrmCierre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
