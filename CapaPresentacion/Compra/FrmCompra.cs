using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;
using CapaPresentacion.Pop_up;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Compra
{
    public partial class FrmCompra : Form
    {
        #region Variables
        ProveedorNegocio _proveedorN;
        ProductoNegocio _productoN;
        CompraNegocio _compraN;
        AlmacenNegocio _almacenN;
        CompraDetalleNegocio _compraDetalleN;
        public decimal MontoTotal = 0;
        public decimal MontoIgv = 0;
        public decimal MontoBase = 0;


        public DataGridViewTextBoxEditingControl DText = null;
        int _idProveedor = 0;
        readonly ToolTip _stip = new ToolTip();

        #endregion

        public FrmCompra()
        {
            InitializeComponent();
            dtpFecha.MaxDate = DateTime.Today;
            rbFactura.Checked = true;
            rbContado.Checked = true;
            _stip.SetToolTip(btnAgregar, "Cargar");
            _stip.SetToolTip(btnQuitar, "Quitar");
            _stip.SetToolTip(btnLimpiar, "Limpiar");
        }

        #region Abrir formulario solo una vez
        private static FrmCompra _mFormDefInstance;
        public static FrmCompra DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmCompra();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        #region LOAD
        private void FrmCompra_Load(object sender, EventArgs e)
        {
            Loading();
        }
        #endregion

        #region Tipo de pago
        private string TipoPago()
        {
            string tipopago = "";
            if (rbCredito.Checked)
                tipopago = "K";
            if (rbContado.Checked)
                tipopago = "C";
            return tipopago;
        }
        #endregion

        #region Limpiar
        private void Limpiar()
        {

            dgvArticulo.Rows.Clear();
            lblTotal.Text = "0.00";
            lblIGV.Text = "0.00";
            lblSub.Text = "0.00";
            lblCantidadProducto.Text = "Producto: 0";

            txtDireccion.Clear();
            txtRznSocial.Clear();
            txtRuc.Clear();

            rbBoleta.Checked = true;
            rbContado.Checked = true;

            dtpFecha.Value = DateTime.Today;

            txtCorrelativo.Clear();
            txtSerie.Clear();


            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnLimpiar.Enabled = true;
        }
        #endregion

        #region Buscar Proveedor
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PopUpProveedor frm = new PopUpProveedor();
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _proveedorN = new ProveedorNegocio();
                _idProveedor = string.IsNullOrEmpty(frm.Id_proveedor.ToString()) ? 0 : int.Parse(frm.Id_proveedor.ToString());

                if (_idProveedor == 0)
                {
                    return;
                }
                else
                {
                    _idProveedor = frm.Id_proveedor;
                    txtRuc.Text = frm.Ruc;
                    txtRznSocial.Text = frm.Rzn_Social;
                    txtDireccion.Text = frm.Direccion;
                }
            }
        }
        #endregion

        #region Eventos
        private void rbOtro_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtro.Checked)
            {
                txtSerie.Enabled = false;
                txtCorrelativo.Enabled = false;
                btnBuscar.Enabled = false;
                _idProveedor = int.Parse(ConfigurationManager.AppSettings["id_proveedor"]);
            }
            else
            {
                txtSerie.Enabled = true;
                txtCorrelativo.Enabled = true;
                btnBuscar.Enabled = true;

            }

        }
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtSerie != null)
            {
                string _auxserie = txtSerie.Text;
                _auxserie = "0000".Substring(0, 4 - _auxserie.Length) + _auxserie;
                txtSerie.Text = _auxserie;
                txtCorrelativo.Focus();
            }

            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        private string SubstringSerie()
        {
            string auxserie = txtSerie.Text;
            auxserie = "0000".Substring(0, 4 - auxserie.Length) + auxserie;
            return auxserie;
        }

        private string SubstringCorrelativo()
        {
            string auxnumeracion = txtCorrelativo.Text;
            auxnumeracion = "000000000".Substring(0, 9 - auxnumeracion.Length) + auxnumeracion;
            return auxnumeracion;
        }

        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtCorrelativo.Text != null)
            {
                string auxnumeracion = txtCorrelativo.Text;
                auxnumeracion = "000000000".Substring(0, 9 - auxnumeracion.Length) + auxnumeracion;
                txtCorrelativo.Text = auxnumeracion;
                dtpFecha.Focus();
            }
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }

        #endregion

        #region Botones compra

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PopUpProducto frm = new PopUpProducto();
            frm.Dgvaux = this.dgvArticulo;
            frm.ShowDialog(this);
            this.dgvArticulo.Select();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.RowCount == 0)
                return;
            if (MessageBox.Show("Desea eliminar producto del listado de Compra?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (dgvArticulo.CurrentRow != null) dgvArticulo.Rows.RemoveAt(dgvArticulo.CurrentRow.Index);
            this.dgvArticulo.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dgvArticulo.RowCount > 0)
            {
                MessageBox.Show("No hay productos cargados", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Desea limpiar todo el listado de compra?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgvArticulo.Rows.Clear();
            this.dgvArticulo.Select();
        }
        #endregion

        #region Métodos del Formulario

        public static string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        #endregion

        #region Producto Cesta

        private bool VerificarGrilla()
        {
            for (int i = 0; i < dgvArticulo.RowCount; i++)
            {
                if (int.Parse(dgvArticulo.Rows[i].Cells["CANTIDAD"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Existe un producto con cantidad 0 en la lista de compra.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }

                if (decimal.Parse(dgvArticulo.Rows[i].Cells["COSTO"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Existe un producto con costo de compra 0 en la lista de compra.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }

                if (decimal.Parse(dgvArticulo.Rows[i].Cells["TOTAL"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Existe un producto con precio total de compra 0 en la lista de compra.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }
            }
            return false;
        }

        private void Loading()
        {
            Validations.GrillaReadOnly(this.dgvArticulo);
            var dataGridViewColumn = this.dgvArticulo.Columns["CANTIDAD"];
            if (dataGridViewColumn != null) dataGridViewColumn.ReadOnly = false;
            var gridViewColumn = this.dgvArticulo.Columns["COSTO"];
            if (gridViewColumn != null) gridViewColumn.ReadOnly = false;
            var viewColumn = this.dgvArticulo.Columns["TOTAL"];
            if (viewColumn != null) viewColumn.ReadOnly = false;
            this.dgvArticulo.Select();
        }

        private decimal CalcularTotal(decimal costo, decimal cantidad)
        {
            string total = "0";
            total = ((costo * cantidad)).ToString("0.0");
            return decimal.Parse(total);
        }
        private void CalcularMontos()
        {
            try
            {
                decimal cantidad = 0;
                decimal costo = 0;
                decimal total = 0;
                decimal totalcompra = 0;

                for (int i = 0; i < dgvArticulo.RowCount; i++)
                {
                    cantidad = decimal.Parse(dgvArticulo.Rows[i].Cells["CANTIDAD"].Value.ToString());
                    costo = decimal.Parse(dgvArticulo.Rows[i].Cells["COSTO"].Value.ToString());
                    total = decimal.Parse(dgvArticulo.Rows[i].Cells["TOTAL"].Value.ToString());

                    dgvArticulo.Rows[i].Cells["CANTIDAD"].Value = cantidad;
                    dgvArticulo.Rows[i].Cells["COSTO"].Value = costo.ToString("0.00");
                    dgvArticulo.Rows[i].Cells["TOTAL"].Value = CalcularTotal(costo, cantidad).ToString("0.00");

                    totalcompra += decimal.Parse(dgvArticulo.Rows[i].Cells["TOTAL"].Value.ToString());
                }
                if (dgvArticulo.RowCount > 1)
                {
                    lblCantidadProducto.Text = "Productos: ";
                    lblProducto.Text = dgvArticulo.RowCount.ToString();
                }
                else
                {
                    lblCantidadProducto.Text = "Producto: ";
                    lblProducto.Text = dgvArticulo.RowCount.ToString();
                }

                if (totalcompra > 0)
                {
                    lblTotal.Text = totalcompra.ToString("0.00");
                }
                else
                {
                    lblTotal.Text = "0.00";
                }

                decimal MONTO_TOTAL = totalcompra;
                //  int IGV = FrmPrincipal.igv;
                int IGV = 18;
                decimal igv_p = decimal.Parse("0." + IGV);
                decimal igv_d = decimal.Parse("1." + IGV);
                decimal MONTO_BASE = MONTO_TOTAL / igv_d;
                decimal MONTO_IGV = MONTO_BASE * igv_p;
                lblSub.Text = MONTO_BASE.ToString("0.00");
                lblIGV.Text = MONTO_IGV.ToString("0.00");

            }
            catch { }
        }
        #endregion

        #region Tipo Comprobante
        private string tipoCompra()
        {
            var _tipoCompra = "";
            if (rbBoleta.Checked)
            { _tipoCompra = "B"; }
            if (rbFactura.Checked)
            { _tipoCompra = "F"; }
            if (rbOtro.Checked)
            { _tipoCompra = "O"; }
            return _tipoCompra;
        }
        #endregion

        #region Eventos
        private void dgvArticulo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = dgvArticulo.CurrentCell.ColumnIndex;

            if (dgvArticulo.Columns[columnIndex].Name == "CANTIDAD")
                DText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            if (dgvArticulo.Columns[columnIndex].Name == "COSTO")
                DText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
            if (dgvArticulo.Columns[columnIndex].Name == "TOTAL")
                DText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);

            if (dgvArticulo.CurrentRow != null && (dgvArticulo.CurrentRow.Cells["CANTIDAD"].Value == null || dgvArticulo.CurrentRow.Cells["CANTIDAD"].Value == ""))
                dgvArticulo.CurrentRow.Cells["CANTIDAD"].Value = 1;
            if (dgvArticulo.CurrentRow != null && (dgvArticulo.CurrentRow.Cells["COSTO"].Value == null || dgvArticulo.CurrentRow.Cells["COSTO"].Value == ""))
                dgvArticulo.CurrentRow.Cells["COSTO"].Value = 1;
            if (dgvArticulo.CurrentRow != null && (dgvArticulo.CurrentRow.Cells["TOTAL"].Value == null || dgvArticulo.CurrentRow.Cells["TOTAL"].Value == ""))
                dgvArticulo.CurrentRow.Cells["TOTAL"].Value = 0.00;

            CalcularMontos();
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = Thread.CurrentThread.CurrentCulture;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (Char)Keys.Back || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvArticulo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ValidarCesta(e);
            CalcularMontos();
        }

        private void ValidarCesta(DataGridViewCellEventArgs e)
        {
            switch (this.dgvArticulo.Columns[e.ColumnIndex].Name)
            {
                case "TOTAL":
                    try
                    {
                        if (dgvArticulo.CurrentRow != null)
                        {
                            decimal result = decimal.Parse(dgvArticulo.Rows[dgvArticulo.CurrentRow.Index].Cells["TOTAL"].Value.ToString());
                        }
                    }
                    catch 
                    {
                        if (dgvArticulo.CurrentRow != null) dgvArticulo.CurrentRow.Cells["TOTAL"].Value = 0.00;
                    }
                    break;

                case "COSTO":
                    try
                    {
                        if (dgvArticulo.CurrentRow != null)
                        {
                            decimal result = decimal.Parse(dgvArticulo.Rows[dgvArticulo.CurrentRow.Index].Cells["COSTO"].Value.ToString());
                        }
                    }
                    catch {
                        if (dgvArticulo.CurrentRow != null) dgvArticulo.CurrentRow.Cells["COSTO"].Value = 0.00;
                    }
                    break;

                case "CANTIDAD":
                    try
                    {
                    }
                    catch {
                        if (dgvArticulo.CurrentRow != null) dgvArticulo.CurrentRow.Cells["CANTIDAD"].Value = 1;
                    }
                    break;
            }
        }

        private void dgvArticulo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dgvArticulo.CurrentCell.ColumnIndex;
            if (dgvArticulo.Columns[columnIndex].Name == "CANTIDAD")
            {
                DText = (DataGridViewTextBoxEditingControl)e.Control;
                DText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
            if (dgvArticulo.Columns[columnIndex].Name == "COSTO")
            {
                DText = (DataGridViewTextBoxEditingControl)e.Control;
                DText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
            if (dgvArticulo.Columns[columnIndex].Name == "TOTAL")
            {
                DText = (DataGridViewTextBoxEditingControl)e.Control;
                DText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }
        }

        private void dgvArticulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnQuitar_Click(null, null);
        }

        private void dgvArticulo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularMontos();
        }

        private void dgvArticulo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalcularMontos();
        }
  

        #endregion

        #region Guardar Compra
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Checkout();
            if (dgvArticulo.RowCount == 0)
            {
                MessageBox.Show("No hay productos cargados", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscar.Focus();
                return;
            }

            if (rbOtro.Checked != true)
            {
                if (txtSerie.Text == string.Empty || txtCorrelativo.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese la serie y numeración para la operación", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSerie.Focus();
                    return;
                }

                if (txtRuc.Text == string.Empty || txtRznSocial.Text == string.Empty)
                {
                    MessageBox.Show("Seleccione un proveedor", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRuc.Focus();
                    return;
                }

                if ((_idProveedor <= 0) && !string.IsNullOrEmpty(txtRuc.Text))
                {
                    MessageBox.Show("Seleccione un proveedor", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRuc.Focus();
                    return;
                }
            }

            if (decimal.Parse(lblTotal.Text) == 0)
            {
                MessageBox.Show("El monto total de la compra no puede ser cero", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvArticulo.Select();
                return;
            }

            // VALILDAR PROVEEDOR Y COMPROBANTE
            _compraN = new CompraNegocio() ;
            int id_proveedor = _idProveedor;
            string serie_compra = txtSerie.Text.Trim();
            string contador_compra = txtCorrelativo.Text.Trim();
            string tipo_comprobante = tipoCompra();

            if (id_proveedor > 1 && _compraN.SelectCount(q => q.id_proveedor == id_proveedor && q.serie_compra == serie_compra && q.correlativo_compra == contador_compra && q.estado_compra == true) > 0)
            {
                MessageBox.Show("El comprobante " + serie_compra + " - " + contador_compra + " para el proveedor " + txtRznSocial.Text + " ya está registrado", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCorrelativo.Focus();
                return;
            }

            // VALIDAR CANTIDAD Y TOTAL DE CADA PRODUCTO
            if (VerificarGrilla())
                return;

            // FORMATO DE DATOS
            MontoTotal = decimal.Parse(lblTotal.Text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty).Trim());
            MontoIgv = decimal.Parse(lblIGV.Text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty).Trim());
            MontoBase = decimal.Parse(lblSub.Text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, string.Empty).Trim());

            if (MessageBox.Show("¿Desea realizar la operación?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GuardarCompra();
                
                //_egresoN.InsertarEgreso(_idUsuario, _idConcepto, _idCajaDia, MontoTotal);

            }
            else
            {
                return;
            }
        }



        private void GuardarCompra()
        {
            int id_compra = Guardar();
            MessageBox.Show("La compra se realizó correctamente", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpiar();
            FrmCompra_Load(null, null);

        }

        #endregion

        #region Guardar Detalle y dirige al Almacen
        public int Guardar()
        {
            _compraN = new CompraNegocio();
            _compraDetalleN = new CompraDetalleNegocio();
            _almacenN = new AlmacenNegocio();
            _productoN = new ProductoNegocio();

            var idCompra = _compraN.GrabarCompra(Asignar());

            for (int i = 0; i < dgvArticulo.RowCount; i++)
            {
                var array = _compraDetalleN.GrabarCompraDetalle(DetalleCompra(idCompra, i));
                Almacen almacenE = new Almacen()
                {
                    id_detalle_compra = int.Parse(array[0].ToString()),
                    cantidad_compra = int.Parse(array[1].ToString()),
                    stock_producto = int.Parse(array[1].ToString()),
                    fecha_ingreso_almacen = DateTime.Now
                };
                _productoN.ActualizarProducto(int.Parse(array[2].ToString()),int.Parse(array[1].ToString()));
                _almacenN.Insert(almacenE);
            }


            return idCompra;

        }
        #endregion

        #region Entidad Compra y Detalle
        private CapaEntidades.Compra Asignar()
        {
            CapaEntidades.Compra compra = new CapaEntidades.Compra()
            {
                id_proveedor = _idProveedor,
                id_usuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]),
                fecha_compra = dtpFecha.Value.Date,
                serie_compra = SubstringSerie(),
                correlativo_compra = SubstringCorrelativo(),
                tipo_comprobante = tipoCompra(),
                igv_compra = MontoIgv,
                subtotal_compra = MontoBase,
                total_compra = MontoTotal,
                fecha_registro = DateTime.Now,
                estado_compra = true
            };
            return compra;
        }

        private Detalle_compra DetalleCompra(int idCompra, int i)
        {
            Detalle_compra detalleCompra = new Detalle_compra()
            {
                id_compra = idCompra,
                id_producto = int.Parse(dgvArticulo.Rows[i].Cells[0].Value.ToString()),
                cantidad_detalle_compra = decimal.Parse(dgvArticulo.Rows[i].Cells[2].Value.ToString()),
                precio_detalle_compra = decimal.Parse(dgvArticulo.Rows[i].Cells[3].Value.ToString()),
                total_detalle_compra = decimal.Parse(dgvArticulo.Rows[i].Cells[4].Value.ToString())
            };
            return detalleCompra;
        }

        #endregion

        #region CheckOut
        private void Checkout()
        {
            for (int i = 0; i < dgvArticulo.RowCount; i++)
            {
                int totalUnidad = int.Parse(dgvArticulo.Rows[i].Cells["CANTIDAD"].Value.ToString());
                if (totalUnidad == 0)
                {
                    dgvArticulo.Rows.RemoveAt(dgvArticulo.Rows[i].Index);
                    i--;
                }
            }
        }
        #endregion

        private void FrmCompra_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAgregar_Click(null, null);
                    break;
                case Keys.F3:
                    btnQuitar_Click(null, null);
                    break;
                case Keys.F4:
                    btnLimpiar_Click(null, null);
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FrmCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
