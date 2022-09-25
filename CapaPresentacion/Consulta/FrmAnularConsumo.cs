using CapaNegocio;
using CapaPresentacion.EditarTotales;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Consulta
{
    public partial class FrmAnularConsumo : Form
    {
        ConsumoLiquidacionNegocio oLiquidacion;
        public FrmAnularConsumo()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            oLiquidacion = new ConsumoLiquidacionNegocio();
            vistaLiquidacionConsumoBindingSource.DataSource = oLiquidacion.SelectListViewLiquidacion( );
            
        }

        #region Abrir formulario solo una vez
        private static FrmAnularConsumo m_FormDefInstance;
        public static FrmAnularConsumo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmAnularConsumo();
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

        private void btnAnular_Click(object sender, EventArgs e)
        {


            LiquidacionNegocio oLiquidacion = new LiquidacionNegocio();

            string tipoDocumento = fDataGridView1.CurrentRow.Cells[5].Value.ToString();
            string idTipoDocumento = "";

            string datoComprobante = fDataGridView1.CurrentRow.Cells[3].Value.ToString();
            string serieComprobante = datoComprobante.Substring(0, 4);
            int numeroComprobante = Convert.ToInt32(datoComprobante.Substring(5, 8));


            if (tipoDocumento == "FACTURA")
            {
                idTipoDocumento = "01";
            }
            else if (tipoDocumento == "BOLETA")
            {
                idTipoDocumento = "03";
            }
            else
            {
                MessageBox.Show("No puede dar de baja un TICKET", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string estadoComprobante = oLiquidacion.CompruebaEstado(idTipoDocumento, serieComprobante, numeroComprobante);

            if (estadoComprobante == "02")
            {            //int id = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
                if (
                    MessageBox.Show("¿Desea eliminar el documento seleccionado?", ".::. Sistema Hotelero .::.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oLiquidacion.EliminarComprobante(idTipoDocumento, serieComprobante, numeroComprobante);
                    btnBuscar_Click(sender, e);

                    MessageBox.Show("Operación realizada con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No puede eliminar un comprobante enviado a SUNAT.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oLiquidacion = new ConsumoLiquidacionNegocio();
            DateTime fecha = dtpInicio.Value.Date;
            if (rbtFecha.Checked)
            {
                vistaLiquidacionConsumoBindingSource.DataSource =
                    oLiquidacion.SelectListViewLiquidacion(item => item.FECHA_COMPARA == fecha, true);
            }
            if (rbtComprobante.Checked)
            {
                vistaLiquidacionConsumoBindingSource.DataSource = oLiquidacion.SelectListViewLiquidacion(item => item.NSERIE.Contains(txtBusqueda.Text), true);
            }
        }

        private void rbtComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtComprobante.Checked)
            {
                txtBusqueda.Enabled = true;
                dtpInicio.Enabled = false;
            }
        }

        private void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFecha.Checked)
            {
                dtpInicio.Enabled = true;
                txtBusqueda.Enabled = false;
            }
        }

        private void estadoControles()
        {
            txtBusqueda.Enabled = true;
            dtpInicio.Enabled = false;
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

        private void btnBajaComprobante_Click(object sender, EventArgs e)
        {
            oLiquidacion = new ConsumoLiquidacionNegocio();
            int id = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (
                MessageBox.Show("¿Desea anular el comprobante seleccionado?", ".::. Sistema Hotelero .::.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oLiquidacion.AnularLiquidacion(id);
                btnBuscar_Click(sender, e);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmRegistroEdicion oFrm = new FrmRegistroEdicion();
            string datoComprobante = fDataGridView1.CurrentRow.Cells[3].Value.ToString();
            string serieComprobante = datoComprobante.Substring(0, 4);
            int numeroComprobante = Convert.ToInt32(datoComprobante.Substring(5, 8));

            oFrm.serie = serieComprobante;
            oFrm.correlativo = numeroComprobante.ToString();
            oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
            oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[6].Value.ToString());

            oFrm.ShowDialog();
            btnBuscar_Click(sender, e);
        }

        private void fButtonCancelar1_Click(object sender, EventArgs e)
        {
            oLiquidacion = new ConsumoLiquidacionNegocio();
            int id = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (
                MessageBox.Show("¿Desea marcar como rechazo el comprobante seleccionado?", ".::. Sistema Hotelero .::.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oLiquidacion.RechazarDocumento_Liquidacion(id);
                btnBuscar_Click(sender, e);
            }
        }
    }
}

