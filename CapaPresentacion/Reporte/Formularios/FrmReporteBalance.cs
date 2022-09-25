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
using CapaNegocio;
using CapaPresentacion.Functions;
using CapaPresentacion.Reporte.Rpts;
using CapaPresentacion.Reporte.VistaPrevia;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaPresentacion.Reporte.Formularios
{
    public partial class FrmReporteBalance : Form
    {
        private LiquidacionNegocio oLiquidacionNegocio;
        readonly int anio = int.Parse(ConfigurationManager.AppSettings["AnioHotel"]);
        public FrmReporteBalance()
        {
            InitializeComponent();
        }

        #region Abrir formulario solo una vez
        private static FrmReporteBalance m_FormDefInstance;
        public static FrmReporteBalance DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FrmReporteBalance();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        #endregion

        private void FrmReporteBalance_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            oLiquidacionNegocio = new LiquidacionNegocio();
            ReportDocument rpt = new ReporteBalance();
            if (oLiquidacionNegocio.GenerarBalance(anio, TipoReporte()).ToList().Count > 0)
            {
                rpt.Database.Tables["DataTable1"].SetDataSource(oLiquidacionNegocio.GenerarBalance(anio, TipoReporte()).OrderBy(item=>item.NUMERO_MES));
                rpt = FReportDocument.DocumentoReport(rpt,anio.ToString());
                FrmVistaPrevia frm = new FrmVistaPrevia(rpt);
                frm.Show();
            }
            else
            {
                MessageBox.Show("No existen registros en la consulta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private string TipoReporte()
        {
            if (rbtConsumo.Checked)
                return "1";
            else
                return "2";
        }
    }
}
