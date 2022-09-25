using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Pop_up
{
    public partial class PopUpProveedor : Form
    {

        ProveedorNegocio _proveedorN;

        int _idProveedor;
        public int Id_proveedor
        {
            get { return _idProveedor; }
            set { _idProveedor = value; }
        }

        string _ruc;
        public string Ruc
        {
            get { return _ruc; }
            set { _ruc = value; }
        }

        string _rznSocial;
        public string Rzn_Social
        {
            get { return _rznSocial; }
            set { _rznSocial = value; }
        }

        string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        public PopUpProveedor()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaBusqueda(txtBuscaPersona.Text);
        }

        private void CargaBusqueda(string texto)
        {
            _proveedorN = new ProveedorNegocio();
            proveedorBindingSource.DataSource = _proveedorN.SelectList(item => item.razons_proveedor.Contains(texto));
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.RowCount > 0)
            {
                if (dgvProveedor.CurrentRow == null) return;
                _idProveedor =int.Parse(dgvProveedor.CurrentRow.Cells[0].Value.ToString());
                _ruc = dgvProveedor.CurrentRow.Cells[2].Value.ToString();
                _rznSocial = dgvProveedor.CurrentRow.Cells[1].Value.ToString();
                _direccion = dgvProveedor.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void dvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvProveedor.RowCount <= 0) return;
                if (dgvProveedor.CurrentRow != null)
                {
                    _idProveedor = int.Parse(dgvProveedor.CurrentRow.Cells[0].Value.ToString());
                    _ruc = dgvProveedor.CurrentRow.Cells[2].Value.ToString();
                    _rznSocial = dgvProveedor.CurrentRow.Cells[1].Value.ToString();
                    _direccion = dgvProveedor.CurrentRow.Cells[3].Value.ToString();
                }
                btnSeleccionar.PerformClick();
            }
        }

        private void dvCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvProveedor.RowCount > 0)
            {
                if (dgvProveedor.CurrentRow != null)
                {
                    _idProveedor = int.Parse(dgvProveedor.CurrentRow.Cells[0].Value.ToString());
                    _ruc = dgvProveedor.CurrentRow.Cells[2].Value.ToString();
                    _rznSocial = dgvProveedor.CurrentRow.Cells[1].Value.ToString();
                    _direccion = dgvProveedor.CurrentRow.Cells[3].Value.ToString();
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

        private void PopUpProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
