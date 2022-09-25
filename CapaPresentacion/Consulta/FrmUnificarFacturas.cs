using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Reserva;

namespace CapaPresentacion.Consulta
{
    public partial class FrmUnificarFacturas : Form
    {
        private LiquidacionNegocio oLiquidar;
        Monto_A_Cuenta oMontoACuenta;
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);
        public FrmUnificarFacturas()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            oLiquidar = new LiquidacionNegocio();
            paUnirFacturaResultBindingSource.DataSource = oLiquidar.UnirFactura().Where(item=>item.TOTAL != 0).OrderBy(item=>item.PISO).ToList();
        }

        private void FrmUnificarFacturas_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        private void btnFacturacion_Click(object sender, System.EventArgs e)
        {

            if (dgvDatos.RowCount > 0)
            {
                
                int dni = int.Parse(dgvDatos.CurrentRow.Cells[2].Value.ToString());
                decimal hospedaje = 0;//decimal.Parse(dgvDatos.CurrentRow.Cells[4].Value.ToString());
                decimal consumo = 0;//decimal.Parse(dgvDatos.CurrentRow.Cells[8].Value.ToString());
                int[] idGrupo = new int[dgvDatos.SelectedRows.Count];
                decimal[] montos = new decimal[dgvDatos.SelectedRows.Count];
                int contador = 0;
                foreach (DataGridViewRow item in dgvDatos.SelectedRows)
                {
                    hospedaje = hospedaje + decimal.Parse(item.Cells[7].Value.ToString()) - decimal.Parse(item.Cells[9].Value.ToString());
                    consumo = consumo + decimal.Parse(item.Cells[8].Value.ToString());
                    idGrupo[contador] = int.Parse(item.Cells[0].Value.ToString());
                    montos[contador] = (decimal.Parse(item.Cells[7].Value.ToString()) - decimal.Parse(item.Cells[9].Value.ToString()));
                    contador ++;
                }

                FrmReservaUneFacturacion oFrm = new FrmReservaUneFacturacion(idGrupo, dni, hospedaje, consumo, montos);
                oFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmUnificarFacturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
