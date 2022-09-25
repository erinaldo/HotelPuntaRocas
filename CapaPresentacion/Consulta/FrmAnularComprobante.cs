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
using CapaEntidades;
using CapaPresentacion.Ediciones;
using CapaPresentacion.EditarTotales;

namespace CapaPresentacion.Consulta
{
    public partial class FrmAnularComprobante : Form
    {
        LiquidacionNegocio oLiquidacion;
        public FrmAnularComprobante()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            oLiquidacion = new LiquidacionNegocio();
            vistaLiquidacionBindingSource.DataSource = oLiquidacion.AnularComprobante();
            
        }

        #region Abrir formulario solo una vez
        private static FrmAnularComprobante m_FormDefInstance;
        public static FrmAnularComprobante DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmAnularComprobante();
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
            oLiquidacion = new LiquidacionNegocio();

            string tipoDocumento = fDataGridView1.CurrentRow.Cells[4].Value.ToString();
            string idTipoDocumento = "";

            string datoComprobante = fDataGridView1.CurrentRow.Cells[2].Value.ToString();
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
            oLiquidacion = new LiquidacionNegocio();
            DateTime fecha = dtpInicio.Value.Date;
            if (rbtFecha.Checked)
            {
                vistaLiquidacionBindingSource.DataSource =
                    oLiquidacion.AnularComprobante(item => item.fecha_liquidacion == fecha, true);
            }
            if (rbtComprobante.Checked)
            {
                vistaLiquidacionBindingSource.DataSource = oLiquidacion.AnularComprobante(item => item.serie_comprobante.Contains(txtBusqueda.Text), true);
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

        private void FrmAnularComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBajaComprobante_Click(object sender, EventArgs e)
        {
            oLiquidacion = new LiquidacionNegocio();
            int id = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (
                MessageBox.Show("¿Desea anular el comprobante seleccionado?", ".::. Sistema Hotelero .::.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oLiquidacion.Anular(id);
                btnBuscar_Click(sender, e);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmRegistroLiquidacion oFrm = new FrmRegistroLiquidacion();

            string datoComprobante = fDataGridView1.CurrentRow.Cells[2].Value.ToString();
            string serieComprobante = datoComprobante.Substring(0, 4);
            int numeroComprobante = Convert.ToInt32(datoComprobante.Substring(5, 8));

            oFrm.idLiquidacion = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());

            oFrm.total = double.Parse(fDataGridView1.CurrentRow.Cells[6].Value.ToString());
            oFrm.serie = serieComprobante;
            oFrm.correlativo = numeroComprobante.ToString();
            
            oFrm.ShowDialog();
            btnBuscar_Click(sender, e);
        }

        private void fButtonCancelar1_Click(object sender, EventArgs e)
        {
            oLiquidacion = new LiquidacionNegocio();
            int id = int.Parse(fDataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (
                MessageBox.Show("¿Desea marcar como rechazo el comprobante seleccionado?", ".::. Sistema Hotelero .::.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oLiquidacion.RechazarDocumento_Hospedaje(id);
                btnBuscar_Click(sender, e);
            }
        }
    }
}

