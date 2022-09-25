using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ediciones
{
    public partial class FrmFacturasEmitidas : Form
    {
        LiquidacionNegocio  oLiquidacion;
        public FrmFacturasEmitidas()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            Buscar();
        }

        #region Abrir formulario solo una vez
        private static FrmFacturasEmitidas m_FormDefInstance;
        public static FrmFacturasEmitidas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmFacturasEmitidas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        #endregion

        private void FrmAnularComprobante_Load(object sender, EventArgs e)
        {
            CargarDatos();
            estadoControles();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            try
            {
                oLiquidacion = new LiquidacionNegocio();
                if (rbtComprobante.Checked)
                {
                    paListaComprobantesLiquidacionResultBindingSource.DataSource = oLiquidacion.ConsultaLiquidacion(dtpInicio.Value, dtpFinal.Value)
                                                                                               .Where(item => item.Huesped.Contains(txtBusqueda.Text.Trim()) &&
                                                                                                               item.TipoComprobante == TipoComprobante()).ToList();
                }
                else
                {
                    paListaComprobantesLiquidacionResultBindingSource.DataSource = oLiquidacion.ConsultaLiquidacion(dtpInicio.Value, dtpFinal.Value)
                                                                                               .Where(item => item.RazonSocial.Contains(txtBusqueda.Text.Trim()) &&
                                                                                                               item.TipoComprobante == TipoComprobante()).ToList();
                }
            }
            catch (Exception)
            {

            }

        }

        private void estadoControles()
        {
            txtBusqueda.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            CargarDatos();
        }

        private void FrmAnularConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private string TipoComprobante()
        {
            if (rbtBoleta.Checked)
                return "BOLETA";
            else
                return "FACTURA";
        }

        private void rbtComprobante_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}

