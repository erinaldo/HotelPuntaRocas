using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Functions;
using CapaPresentacion.Reporte.Rpts;
using CapaPresentacion.Reporte.VistaPrevia;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace CapaPresentacion.Reporte.Formularios
{
    public partial class FrmReporteContador : Form
    {
        private LiquidacionNegocio oLiquidacionNegocio;
        public FrmReporteContador()
        {
            InitializeComponent();
        }

        #region Abrir formulario solo una vez
        private static FrmReporteContador m_FormDefInstance;
        public static FrmReporteContador DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmReporteContador();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        #endregion

        private void FrmReporteContador_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            oLiquidacionNegocio = new LiquidacionNegocio();
            DateTime de = dtpInicial.Value;
            DateTime hasta = dtpFinal.Value;
           

            if (oLiquidacionNegocio.GenerarReporte(de, hasta).ToList().Count > 0)
            {
                if (fCheckBox1.Checked)
                {
                    ReportDocument rpt = new ReporteContador();
                    rpt.Database.Tables["DataTable1"].SetDataSource(oLiquidacionNegocio.GenerarReporte(de, hasta).ToList());
                    rpt = FReportDocument.DocumentoReport(rpt, "");
                    FrmVistaPrevia frm = new FrmVistaPrevia(rpt);
                    frm.Show();
                }
                else
                {
                    ReportDocument rpt = new ReporteEntregable();
                    rpt.Database.Tables["DataTable1"].SetDataSource(oLiquidacionNegocio.ReporteContadorEntregable(de, hasta).ToList());
                    rpt = FReportDocument.DocumentoReport(rpt, "");
                    FrmVistaPrevia frm = new FrmVistaPrevia(rpt);
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("No existen registros en la consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void FrmReporteContador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void fCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
