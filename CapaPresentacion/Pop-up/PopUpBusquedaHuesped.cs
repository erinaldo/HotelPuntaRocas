
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Gestion;

namespace CapaPresentacion.Pop_up
{
    public partial class PopUpBusquedaHuesped : Form
    {
        private Detalle_reserva _detalleReservaE;
        private ReservaDetalleNegocio _reservaDetalleN;

        private HuespedNegocio _huespedN;
        private readonly int _idReserva;

        public PopUpBusquedaHuesped(int idReserva)
        {
            InitializeComponent();
            this._idReserva = idReserva;
            InicializarControles();
            ListarHuespedes();
        }

        private void ListarHuespedes()
        {
            _huespedN = new HuespedNegocio();
            vistaHuespedListBindingSource.DataSource = _huespedN.SelectListView(null, true);
        }

        private Detalle_reserva Asignar()
        {
            if (dgvDatos.CurrentRow != null)
                _detalleReservaE = new Detalle_reserva()
                {
                    id_reserva = _idReserva,
                    id_huesped =  int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString())
                };
            return _detalleReservaE;
        }

        private void SeleccionarRegistro()
        {
            _reservaDetalleN = new ReservaDetalleNegocio();
            _reservaDetalleN.Insert(Asignar());
        }

        private string SeleccionarBusqueda()
        {
            return rbnDNI.Checked ? "1" : "2";
        }

        private void InicializarControles()
        {
            if (SeleccionarBusqueda() == "1")
            {
                this.txtBuscarDNI.Enabled = true;
                this.txtBuscarDNI.Clear();
                this.txtBuscaHuesped.Clear();
                this.txtBuscaHuesped.Enabled = false;
                this.txtBuscaHuesped.Focus();
            }
            else
            {
                this.txtBuscarDNI.Enabled = false;
                this.txtBuscarDNI.Clear();
                this.txtBuscaHuesped.Clear();
                this.txtBuscaHuesped.Enabled = true;
                this.txtBuscarDNI.Focus();

            }
        }

        private void rbnDNI_CheckedChanged(object sender, System.EventArgs e)
        {
            InicializarControles();
            this.txtBuscarDNI.Focus();
        }

        private void rbnNombre_CheckedChanged(object sender, System.EventArgs e)
        {
            InicializarControles();
            this.txtBuscaHuesped.Focus();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            _huespedN = new HuespedNegocio();
            vistaHuespedListBindingSource.DataSource = SeleccionarBusqueda() == "1" ? _huespedN.SelectListView(item=>item.dni_huesped.Contains(txtBuscarDNI.Text), true) 
                                                                                    : _huespedN.SelectListView(item => item.completo_huesped.Contains(txtBuscaHuesped.Text), true);
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            FrmHuesped frm = new FrmHuesped();
            frm.Show();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SeleccionarRegistro();
            this.Close();
        }

        private void PopUpBusquedaHuesped_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
