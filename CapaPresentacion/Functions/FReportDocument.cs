using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace CapaPresentacion.Functions
{
    public class FReportDocument
    {
        public static ReportDocument DocumentoReport(ReportDocument rp, string cabecera, decimal dolar)
        {
            rp.SetParameterValue("@cabecera", cabecera);
            rp.SetParameterValue("@pie", "Hotel Punta Rocas - Reporte Generado por Sistema Hotelero V 1.0");
            rp.SetParameterValue("@dolar", dolar);
            return rp;
        }
        public static ReportDocument DocumentoReport(ReportDocument rp, string cabecera)
        {
            rp.SetParameterValue("@cabecera", cabecera);
            rp.SetParameterValue("@pie", "Hotel Punta Rocas - Reporte Generado por Sistema Hotelero V 1.0");
            return rp;
        }
        /// <summary>
    }
}
