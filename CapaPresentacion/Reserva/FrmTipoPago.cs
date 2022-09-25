using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reserva
{
    public partial class FrmTipoPago : Form
    {
        public string tipoPago;
        public FrmTipoPago()
        {
            InitializeComponent();
        }

        public string Escoge()
        {
            if (rbtBoleta.Checked)
                return "B";
            else if (rbtFactura.Checked)
                return "F";
            else
                return "T";
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            tipoPago = Escoge();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTipoPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
