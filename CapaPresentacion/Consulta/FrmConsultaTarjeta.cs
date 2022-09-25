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
using CapaNegocio;

namespace CapaPresentacion.Consulta
{
    public partial class FrmConsultaTarjeta : Form
    {
        private LiquidacionNegocio oLiquiaLiquidacionN;

        public FrmConsultaTarjeta()
        {
            InitializeComponent();
        }

        #region Abrir formulario solo una vez
        private static FrmConsultaTarjeta _mFormDefInstance;
        public static FrmConsultaTarjeta DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConsultaTarjeta();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime _fInicio = dtpInicio.Value.Date;
            DateTime _fFinal = dtpFinal.Value.Date;
            Listar(_fInicio, _fFinal);
        }

        private void Listar(DateTime finicio, DateTime ffinal)
        {
            oLiquiaLiquidacionN = new LiquidacionNegocio();
            paValidarTarjetasResultBindingSource.DataSource = oLiquiaLiquidacionN.Listar(finicio, ffinal);
        }

        private void removerPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                oLiquiaLiquidacionN = new LiquidacionNegocio();
                int idLiquidacion = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
                oLiquiaLiquidacionN.RemueveTarjeta(idLiquidacion);
            }
            MessageBox.Show("Operación realizada con Éxito", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            DateTime _fInicio = dtpInicio.Value.Date;
            DateTime _fFinal = dtpFinal.Value.Date;
            Listar(_fInicio, _fFinal);
        }

        private void FrmConsultaTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
