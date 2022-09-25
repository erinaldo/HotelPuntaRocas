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
    public partial class FrmEdicionTarjeta : Form
    {
        LiquidacionNegocio  oLiquidacion;
        public FrmEdicionTarjeta()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            Buscar();
        }

        #region Abrir formulario solo una vez
        private static FrmEdicionTarjeta m_FormDefInstance;
        public static FrmEdicionTarjeta DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmEdicionTarjeta();
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
                var lista = oLiquidacion.ConsultaTarjeta(dtpInicio.Value, dtpFinal.Value).ToList();
                paListaComprobantesTarjetaResultBindingSource.DataSource = lista; //oLiquidacion.ConsultaTarjeta(dtpInicio.Value, dtpFinal.Value).ToList();
                var sum = lista.Sum(item => item.total_liquidacion);
                if (sum != null)
                    lblTotalTarjetas.Text = "Monto Total: "+sum.Value.ToString();
            }
            catch (Exception)
            {

            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmAnularConsumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void fDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmEditarTarjeta oFrm = new FrmEditarTarjeta();
            if (fDataGridView1.CurrentRow != null)
            {
                oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
          
                oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[7].Value.ToString());

                oFrm.tipo_comprobante = "T";
                oFrm.referencia = (fDataGridView1.CurrentRow.Cells[6].Value.ToString());
                oFrm.numero_tarjeta = (fDataGridView1.CurrentRow.Cells[5].Value.ToString());
            }

            oFrm.ShowDialog();
            Buscar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarTarjeta oFrm = new FrmEditarTarjeta();
            if (fDataGridView1.CurrentRow != null)
            {
                oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());

                oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[7].Value.ToString());

                oFrm.tipo_comprobante = "T";
                oFrm.referencia = (fDataGridView1.CurrentRow.Cells[6].Value.ToString());
                oFrm.numero_tarjeta = (fDataGridView1.CurrentRow.Cells[5].Value.ToString());
            }

            oFrm.ShowDialog();
            Buscar();
        }
    }
}

