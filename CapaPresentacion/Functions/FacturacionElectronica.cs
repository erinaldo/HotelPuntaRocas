using Facturacion.Electronica.Aplicacion.BE;
using Facturacion.Electronica.Aplicacion.UI;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Functions
{
    public class FacturacionElectronica
    {
        public void InsertarDatoTributario(string pSerie, string pNumero, string pTipoDocumento, string pRuc, string pRazonSocial, string pTipoDocumentoDescrp, string pDestinoOperacion, string pDestinoOperacionDescrp, DateTime pFechaEmision,
                                           string pCodigoMoneda, string pUsuarioId, string pTipoDocumentoRef, string pTipoDocumentoRefDescrp, string pSerieRef, int pNumeroRef, DateTime pFechaEmisionRef, string pTipoVenta, string pTipoVentaDescrp,
                                           string pTipoNota, string pTipoNotaDescrp, string pMotivoNota, decimal pMontoTotal)
        {
            var rLoc_Numero_Documento = pSerie + pNumero + pTipoDocumento;
            int rNumero = Convert.ToInt32(pNumero);
            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("API_DatosTributariosVenta_Insert",
                rLoc_Numero_Documento,
                pRuc,
                pRazonSocial,
                pTipoDocumento,
                pTipoDocumentoDescrp,
                pDestinoOperacion,
                pDestinoOperacionDescrp,
                pSerie,
                pNumero,
                pFechaEmision,
                pCodigoMoneda,
                pUsuarioId,
                pUsuarioId,
                pTipoDocumentoRef,
                pTipoDocumentoRefDescrp,
                pSerieRef,
                pNumeroRef,
                pFechaEmisionRef,
                rNumero,
                pNumeroRef,
                 pTipoVenta,
                pTipoVentaDescrp,
                pTipoNota,
                pTipoNotaDescrp,
                pMotivoNota,
                pMontoTotal))
            {
                //uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);

            }
        }

        public void InsertarCabecera(
            short pSopType, //3
            string pSerie,
            string pNumero,
            string pTipoDocumento,
            DateTime pDocdate,
            string pRuc,
            string pRazonSocial,
            string pDireccion,
            decimal pTotalDescuento,//TotDsctoComercialOriginal
            decimal pTipoCambio, //XCHGRATE
            decimal pSubtotal,//SubTotalOriginal
            decimal pIgv,//TotImpuestosOriginal
            decimal pTotal, //TotOriginal
            string pMoneda,
            string pUsuario)
        {
            var rSopNumbe = pSerie + pNumero + pTipoDocumento;
            var rTRDISAMT = pTotalDescuento * pTipoCambio; //TotDsctoComercialFuncional
            var rSUBTOTAL = pSubtotal * pTipoCambio; //SubTotalFuncional
            var rTAXAMNT = pIgv * pTipoCambio; //TotImpuestosFuncional
            var rDOCAMNT = pTotal * pTipoCambio;//TotFuncional
            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("API_DocumentoCabeceraAbierto_Insert",

                pSopType,
                rSopNumbe,
                pDocdate,
                pRuc,
                pRazonSocial,
                pDireccion,
                pTotalDescuento,
                rTRDISAMT,
                pSubtotal,
                rSUBTOTAL,
                pIgv,
                rTAXAMNT,
                pTotal,
                rDOCAMNT,
                pMoneda,
                pTipoCambio,
                pUsuario
            ))
            {
                // uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);

            }
        }



        public void InsertarDetalle(
             short pSopType, //3
            string pSerie,
            string pNumero,
            string pTipoDocumento,
            int pLinea,
            string pItem,
            string pDescripcionItem,
            string pUnidadMedida,
            decimal pCantidad,
            decimal pPrecio,
            decimal pTipoCambio,
            decimal pImporte, //Importe Original
            decimal pDescuento //DSCTO original
                )
        {
            var rSopNumbe = pSerie + pNumero + pTipoDocumento;
            var rUNITPRCE = pPrecio * pTipoCambio;
            var rXTNDPRCE = pImporte * pTipoCambio; //Importe funcional
            var rMRKDNAMT = pDescuento * pTipoCambio; //DSCTO funcional ;
            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("API_DocumentoDetalleAbierto_Insert",

                pSopType,
                rSopNumbe,
                pLinea,
                pItem,
                pDescripcionItem,
                pUnidadMedida,
                pCantidad,
                pPrecio,
                rUNITPRCE,
                pImporte,
                rXTNDPRCE,
                pDescuento,
                rMRKDNAMT
            ))
            {
                // uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);

            }
        }

        public void InsertarImpuesto(
            short pSopType, //3
            string pSerie,
            string pNumero,
            string pTipoDocumento,
            decimal pIgv,
            decimal pTipoCambio,
            decimal pSubTotal
            )
        {

            var rSopNumbe = pSerie + pNumero + pTipoDocumento;
            var rSTAXAMNT = pIgv * pTipoCambio;
            var rTAXDTSLS = pSubTotal * pTipoCambio;

            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("API_DocumentoImpuesto_Insert",
                pSopType,
                rSopNumbe,
                pIgv,
                rSTAXAMNT,
                pSubTotal,
                rTAXDTSLS
            ))
            {
                // uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);
            }
        }

        //post =  true
        public void InsertarFE(string pUsuarioGpId, string pTipoDocumentoId, string pSerie, int pNumero, bool pPost, int pTiempoEspera)
        {

            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("ERP_FeSpGetEstado_Generar", new object[]
          {
                pUsuarioGpId,
                pTipoDocumentoId,
                pSerie,
                pNumero,
                pPost
          }))
            {
                // uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);

            }

        }

        public void InsertarEstado(string pUsuarioGpId, string pTipoDocumentoId, string pSerie, int pNumero, string pFileName, string pOuterXml, byte[] pArrayByte, string pSummaryValue, string pSignatureValue, string pBarcodeText, byte[] pBarcode, byte[] pReport, string pResponseCode, string pResponseDescription, int pTiempoEspera)
        {
            SqlDatabase rsqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            using (DbCommand uDbCommand = rsqlDatabase.GetStoredProcCommand("ERP_FeSpGetEstado_Firmar", new object[]
            {
                pUsuarioGpId,
                pTipoDocumentoId,
                pSerie,
                pNumero,
                pFileName,
                pOuterXml,
                pArrayByte,
                pSummaryValue,
                pSignatureValue,
                pBarcodeText,
                pBarcode,
                pReport,
                pResponseCode,
                pResponseDescription
            }))
            {
                // uDbCommand.CommandTimeout = Convert.ToInt32(ERP.DynamicsGP.Addin.Xml.GetAttribute("Detraccion_Timeout", false));
                rsqlDatabase.ExecuteNonQuery(uDbCommand);

            }
        }

        public void ImprimirDocumento(EntradaFacturaElectronica vEntradaFacturaElectronica, List<DocumentoBE> plist_DocumentoBE)
        {
            if (vEntradaFacturaElectronica == null)
            {
                throw new Exception("No se logró obtener la configuración.");
            }

            if (plist_DocumentoBE.Count == 0)
            {
                throw new Exception("Debe seleccionar un documento.");
            }
            if (plist_DocumentoBE.Exists((DocumentoBE p) => p.EstadoId == "" || p.EstadoId == "01"))
            {
                throw new Exception("No debe seleccionar un documento sin firmar.");
            }

            //string text = string.Format("¿Desea imprimir el documento? Se imprimira(n) {0} documento(s).\nSi (Imprimir) No (Vista Previa).", plist_DocumentoBE.Count);
            //DialogResult dialogResult = MessageBox.Show(text, "Entrada de factura electrónica", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //if (dialogResult == DialogResult.Cancel)
            //{
            //    return;
            //}
            //bool pVistaPrevia = dialogResult == DialogResult.No;

            vEntradaFacturaElectronica.ImprimirDocumento(plist_DocumentoBE, false);
        }

        public void EnviarCorreo(EntradaFacturaElectronica vEntradaFacturaElectronica, List<DocumentoBE> plistDocumentoBe, ComboBox cboArchivo, ComboBox cboEnvio)
        {
            if (vEntradaFacturaElectronica == null)
            {
                throw new Exception("No se logró obtener la configuración.");
            }

            ArchivoBE archivoBE = cboArchivo.SelectedItem as ArchivoBE;
            if (archivoBE == null)
            {
                throw new Exception("Debe seleccionar un archivo.");
            }

            EnvioBE envioBE = cboEnvio.SelectedItem as EnvioBE;
            if (envioBE == null)
            {
                throw new Exception("Debe seleccionar un envío.");
            }
            
            if (plistDocumentoBe.Count == 0)
            {
                throw new Exception("Debe seleccionar un documento.");
            }

            vEntradaFacturaElectronica.EnviarDocumento(plistDocumentoBe, archivoBE, envioBE, new Action<object>(this.ActualizarDocumento), delegate (object p)
            {
            }, false);
        }

        private void ActualizarDocumento(object pArgument)
        {
            //Mandamos vacío
        }

        public List<ArchivoBE> GetArchivo(string pTipo)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConfigurationManager.ConnectionStrings["FAC"].ConnectionString);
            DataSet dataSet = sqlDatabase.ExecuteDataSet("ERP_FeSpGetArchivo", new object[]
            {
                pTipo
            });
            DataTable dataTable = dataSet.Tables[0];
            List<ArchivoBE> list = new List<ArchivoBE>();
            foreach (DataRow pDataRow in dataTable.Rows)
            {
                list.Add(this.CreateArchivo(pDataRow));
            }
            return list;
        }

        private ArchivoBE CreateArchivo(DataRow pDataRow)
        {
            return new ArchivoBE
            {
                Tipo = Convert.ToString(pDataRow["Tipo"]).Trim(),
                Id = Convert.ToString(pDataRow["Id"]).Trim(),
                Nombre = Convert.ToString(pDataRow["Nombre"]).Trim(),
                EstadoId = Convert.ToString(pDataRow["EstadoId"]).Trim(),
                Campo = Convert.ToString(pDataRow["Campo"]).Trim(),
                Extension = Convert.ToString(pDataRow["Extension"]).Trim(),
                Campo_Two = Convert.ToString(pDataRow["Campo_Two"]).Trim(),
                Extension_Two = Convert.ToString(pDataRow["Extension_Two"]).Trim()
            };
        }
    }
}
