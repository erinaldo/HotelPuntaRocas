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
    public partial class FrmEdicionConsumo : Form
    {
        LiquidacionNegocio  oLiquidacion;
        public FrmEdicionConsumo()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            Buscar(Estado());
        }

        #region Abrir formulario solo una vez
        private static FrmEdicionConsumo m_FormDefInstance;
        public static FrmEdicionConsumo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmEdicionConsumo();
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
            Buscar(Estado());
        }
        private void Buscar(string anulados)
        {
            try
            {
                oLiquidacion = new LiquidacionNegocio();
                if (Estado() == "A")
                {
                    if (rbtFecha.Checked)
                    {
                        paListaComprobantesConsumoResultBindingSource.DataSource = oLiquidacion.ConsultaConsumo(dtpInicio.Value, dtpFinal.Value).Where(item => item.TipoComprobante == TipoComprobante() &&
                                                                                                                                                                item.ESTADO == "A").ToList();
                    }
                    if (rbtComprobante.Checked)
                    {
                        paListaComprobantesConsumoResultBindingSource.DataSource = oLiquidacion.ConsultaConsumo(dtpInicio.Value, dtpFinal.Value).Where(item => item.NComprobante.Contains(txtBusqueda.Text.Trim()) &&
                                                                                                                                                               item.TipoComprobante == TipoComprobante() &&
                                                                                                                                                               item.ESTADO == "A").ToList();
                    }
                }
                else
                {
                    if (rbtFecha.Checked)
                    {
                        paListaComprobantesConsumoResultBindingSource.DataSource = oLiquidacion.ConsultaConsumo(dtpInicio.Value, dtpFinal.Value).Where(item => item.TipoComprobante == TipoComprobante()).ToList();
                    }
                    if (rbtComprobante.Checked)
                    {
                        paListaComprobantesConsumoResultBindingSource.DataSource = oLiquidacion.ConsultaConsumo(dtpInicio.Value, dtpFinal.Value).Where(item => item.NComprobante.Contains(txtBusqueda.Text.Trim()) &&
                                                                                                                                                             item.TipoComprobante == TipoComprobante()).ToList();
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void rbtComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtComprobante.Checked)
            {
                txtBusqueda.Enabled = true;
            }
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFecha.Checked)
            {
                txtBusqueda.Enabled = false;
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

        private void fDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmEditarConsumo oFrm = new FrmEditarConsumo();
            oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
          
            oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[7].Value.ToString());
            oFrm.serie = (fDataGridView1.CurrentRow.Cells[8].Value.ToString());
            oFrm.correlativo = (fDataGridView1.CurrentRow.Cells[9].Value.ToString());

            oFrm.tipo_comprobante = (fDataGridView1.CurrentRow.Cells[6].Value.ToString());
            oFrm.referencia = (fDataGridView1.CurrentRow.Cells[10].Value.ToString());
            oFrm.numero_tarjeta = (fDataGridView1.CurrentRow.Cells[11].Value.ToString()); 

            oFrm.ShowDialog();
            Buscar(Estado());
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarConsumo oFrm = new FrmEditarConsumo();
            oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());

            oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[7].Value.ToString());
            oFrm.serie = (fDataGridView1.CurrentRow.Cells[8].Value.ToString());
            oFrm.correlativo = (fDataGridView1.CurrentRow.Cells[9].Value.ToString());

            oFrm.tipo_comprobante = (fDataGridView1.CurrentRow.Cells[6].Value.ToString());
            oFrm.referencia = (fDataGridView1.CurrentRow.Cells[10].Value.ToString());
            oFrm.numero_tarjeta = (fDataGridView1.CurrentRow.Cells[11].Value.ToString());

            oFrm.ShowDialog();
            Buscar(Estado());
        }

        private void fCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Buscar(Estado());
        }

        private string Estado()
        {
            if (fCheckBox1.Checked)
                return "A";
            return "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(fDataGridView1.CurrentRow.Cells[7].Value) != 0)
            {
                MessageBox.Show("Primero debe de anular el comprobante", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oLiquidacion = new LiquidacionNegocio();
                oLiquidacion.BorrarComsumo(int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("Registro borrado del sistema.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar(Estado());
            }
        }
    }
}

