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
    public partial class FrmConsultaHistorico : Form
    {
        private Reserva_HistoricoNegocio oReserva;

        public FrmConsultaHistorico(string nombre)
        {
            InitializeComponent();
            Listar(nombre);
        }

        private void Listar(string nombre)
        {
            oReserva = new Reserva_HistoricoNegocio();
            paBusquedaHistoricoResultBindingSource.DataSource = oReserva.ListaHospedajeHistorico(nombre);
        }

        private void FrmConsultaTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
