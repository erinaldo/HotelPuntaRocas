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
    public partial class FrmConsultaDNI : Form
    {
        private HuespedNegocio oHuespedN;

        public FrmConsultaDNI()
        {
            InitializeComponent();
            Listar();
        }

        #region Abrir formulario solo una vez
        private static FrmConsultaDNI _mFormDefInstance;
        public static FrmConsultaDNI DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConsultaDNI();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void Listar()
        {
            oHuespedN = new HuespedNegocio();
            paHuespedRepetidosResultBindingSource.DataSource = oHuespedN.ListarDuplicados();
        }

        private void removerPendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oHuespedN = new HuespedNegocio();
            int idHuesped = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("¿Desea remover el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oHuespedN.RemoverHuesped(idHuesped);
                Listar();
            }
        }

        private void FrmConsultaTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
