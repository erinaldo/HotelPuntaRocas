using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Pop_up
{
    public partial class PopUpBusquedaEmpresa : Form
    {

        EmpresaNegocio _empresaN;

        public int IdEmpresa { get; set; }
        public string RznSocial { get; set; }
        
        public PopUpBusquedaEmpresa()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaBusqueda(txtBuscaPersona.Text);
        }

        private void CargaBusqueda(string texto)
        {
            _empresaN = new EmpresaNegocio();
            empresaBindingSource.DataSource = _empresaN.SelectList(item => item.nombre_empresa.Contains(texto));
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpresa.RowCount > 0)
            {
                if (dgvEmpresa.CurrentRow == null) return;
                IdEmpresa =int.Parse(dgvEmpresa.CurrentRow.Cells[0].Value.ToString());
                RznSocial = dgvEmpresa.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void dvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvEmpresa.RowCount <= 0) return;
                if (dgvEmpresa.CurrentRow != null)
                {
                    IdEmpresa = int.Parse(dgvEmpresa.CurrentRow.Cells[0].Value.ToString());
                    RznSocial = dgvEmpresa.CurrentRow.Cells[1].Value.ToString();
                }
                btnSeleccionar.PerformClick();
            }
        }

        private void dvCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvEmpresa.RowCount > 0)
            {
                if (dgvEmpresa.CurrentRow != null)
                {
                    IdEmpresa = int.Parse(dgvEmpresa.CurrentRow.Cells[0].Value.ToString());
                    RznSocial = dgvEmpresa.CurrentRow.Cells[1].Value.ToString();
                }
                btnSeleccionar.PerformClick();
            }
            else
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void PopUpProveedor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Dispose();
                    break;
            }
        }

        private void txtBuscaPersona_TextChanged(object sender, EventArgs e)
        {
            CargaBusqueda(txtBuscaPersona.Text);
        }

        private void PopUpBusquedaEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
