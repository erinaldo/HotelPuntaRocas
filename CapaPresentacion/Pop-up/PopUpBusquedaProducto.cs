using System;
using System.Windows.Forms;
using CapaNegocio;
using Controles_Standar;

namespace CapaPresentacion.Pop_up
{
    public partial class PopUpProducto : Form
    {

        ProductoNegocio _productoN;
        public FDataGridView Dgvaux;
        bool _sw = false;

        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }

        public PopUpProducto()
        {
            InitializeComponent();
        }

        private void CargaBusqueda(string _texto)
        {
            _productoN = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _productoN.SelectListView(item => item.nombre_producto.Contains(_texto));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaBusqueda(txtBuscaPersona.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            _sw = false;
            CargarDatos();
        }


        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarDatos();
            }
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _sw = false;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (dgvDatos.RowCount > 0)
                {
                    _sw = false;
                    if (dgvDatos.CurrentRow != null)
                    {
                        IdProducto = int.Parse(dgvDatos.CurrentRow.Cells[0].Value.ToString());
                        NombreProducto = dgvDatos.CurrentRow.Cells[1].Value.ToString();
                    }

                    for (int i = 0; i < Dgvaux.RowCount; i++)
                    {

                        if (IdProducto == int.Parse(Dgvaux.Rows[i].Cells[0].Value.ToString()))
                        {
                            MessageBox.Show("El producto ya está agregada a la compra.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _sw = true;
                            break;
                        }
                    }

                    if (!_sw)
                    {

                        Dgvaux.Rows.Insert(Dgvaux.RowCount
                                    , IdProducto
                                    , NombreProducto
                                    , 1
                                    , 0
                                    , 0

                                    );

                        _sw = false;
                    }

                }
                else
                {
                    return;
                }
            }
            catch { }
        }

        private void PopUpArticulo_KeyUp(object sender, KeyEventArgs e)
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

        private void PopUpProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void PopUpProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
