using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaPresentacion.Reporte.VistaPrevia
{
    public partial class FrmVistaPrevia : Form
    {
        ReportDocument rpt;


        public FrmVistaPrevia(ReportDocument _rpt)
        {
            InitializeComponent();
            rpt = _rpt;
            CargarReporte();
        }
        private void CargarReporte()
        {
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
