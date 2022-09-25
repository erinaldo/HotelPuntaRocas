using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaPedido : Form
    {
        /*
         * Lista de Estados 
         * Guinda       Reservas            (108, 19, 43)       5
         * Azul         Ocupado             (0,0,255)           6
         * Crema        Prereserva          (240,230,140)       7
        */

        private readonly int _idDetalleReserva;
        private readonly int _idReserva;

        private Servicio_habitacion _servicioHabitacionE;
        private ServicioHabitacionNegocio _servicioHabitacionN;

        private LiquidacionNegocio _liquidacionN;
        private Liquidacion _liquidacion;

        private ProductoNegocio _producto;

        int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);

        public FrmReservaPedido(int idDetalle, int idReserva)
        {
            InitializeComponent();
            _idDetalleReserva = idDetalle;
            _idReserva = idReserva;
            CargarProductosPedidos(Grupo(_idReserva));
           
        }

        private int Grupo(int reserva)
        {
            ReservaNegocio _oReservaN = new ReservaNegocio();
            var reservaFecha = _oReservaN.SelectSingle(item => item.id == reserva).grupo_reserva;
            if (reservaFecha != null) return reservaFecha.Value;
            return 0;
        }

        private void CargarProductos()
        {
            _producto = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _producto.SelectListView(item => item.consumo == 1);
        }

        private void CargarProductosPedidos(int id)
        {
            _servicioHabitacionN = new ServicioHabitacionNegocio();
            vistaPedidoListBindingSource.DataSource = _servicioHabitacionN.SelectListView(item => item.id_grupo == id && item.fecha_pago_servicio_habitacion == null);
        }

        private void FrmReservacion_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CalcularMontos();
        }


        private Servicio_habitacion Asignar(bool flag)
        {
            int idProducto = 0;
            decimal precioProducto = 0;
            if (dgvListaProductos.CurrentRow != null)
            {
                idProducto = int.Parse(dgvListaProductos.CurrentRow.Cells[0].Value.ToString());
                precioProducto = decimal.Parse(dgvListaProductos.CurrentRow.Cells[2].Value.ToString());
            }
            _servicioHabitacionE = new Servicio_habitacion()
                {
                    id_detalle_reserva = _idDetalleReserva,
                    cantidad_servicio_habitacion = 1,
                    precio_servicio_habitacion = precioProducto,
                    id_usuario_atiende = _idUsuario,
                    id_producto = idProducto,
                    fecha_servicio_habitacion = DateTime.Now,
                    pago_servicio_habitacion = false,
                    estado_servicio_habitacion = true,
                    id_grupo = Grupo(_idReserva),
                    estado_factura = false
                };
            if(!flag)
                if (dgvPedidoReserva.CurrentRow != null)
                    _servicioHabitacionE.id = int.Parse(dgvPedidoReserva.CurrentRow.Cells[0].Value.ToString());
            return _servicioHabitacionE;
        }

        private void AgregarProducto()
        {
            if (dgvListaProductos.RowCount > 0)
            {
                _servicioHabitacionN = new ServicioHabitacionNegocio();
                _servicioHabitacionN.Insert(Asignar(true));
                var objEliminar = Asignar(false);
                _servicioHabitacionN.DescontarProducto(objEliminar.id_producto, objEliminar.cantidad_servicio_habitacion);
                //MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductosPedidos(Grupo(_idReserva));
            }
            else
            {
                MessageBox.Show("No existen productos.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularMontos();
            CargarProductos();
        }

        private void QuitarProducto()
        {
            if (dgvPedidoReserva.RowCount > 0)
            {
                _servicioHabitacionN = new ServicioHabitacionNegocio();
                if (dgvPedidoReserva.CurrentRow != null)
                {
                    int id = int.Parse(dgvPedidoReserva.CurrentRow.Cells[0].Value.ToString());
                    if (_servicioHabitacionN.SelectCount(item => item.id == id &&
                                                                 item.pago_servicio_habitacion == true) == 1)
                    {
                        MessageBox.Show("No puede eliminar un producto ya pagado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        _servicioHabitacionN.Delete(Asignar(false));
                        int idProducto = int.Parse(dgvPedidoReserva.CurrentRow.Cells[1].Value.ToString());
                        _servicioHabitacionN.RestaurarProducto(idProducto,1);
                    }
                }
                CargarProductosPedidos(Grupo(_idReserva));
                CalcularMontos();
            }
            else
            {
                MessageBox.Show("No existen productos.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CalcularMontos();
            CargarProductos();
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            _servicioHabitacionN = new ServicioHabitacionNegocio();
            if(dgvListaProductos.CurrentRow != null && _servicioHabitacionN.ExisteStock(int.Parse(dgvListaProductos.CurrentRow.Cells[0].Value.ToString())))
                AgregarProducto();
            else
            {
                MessageBox.Show("No existe el Stock suficiente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitarP_Click(object sender, EventArgs e)
        {
            QuitarProducto();
        }

        private void dgvListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AgregarProducto();
        }

        private void dgvPedidoReserva_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            QuitarProducto();
        }

        private void CalcularMontos()
        {
            _servicioHabitacionN = new ServicioHabitacionNegocio();
            int id = Grupo(_idReserva);
            var totalMonto = _servicioHabitacionN.SelectListView(item => item.id_grupo == id && item.fecha_pago_servicio_habitacion == null)
                    .Sum(item => item.precio_servicio_habitacion * item.cantidad_servicio_habitacion);
            fLabelMedium2.Text = "Monto Total S/." + totalMonto.ToString("F");
            fLabelMedium1.Text = "Hay " + dgvPedidoReserva.RowCount + " pedido(s)";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pagarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MontoACuentaNegocio _ACuentaN = new MontoACuentaNegocio();
            _liquidacionN = new LiquidacionNegocio();
            _servicioHabitacionN = new ServicioHabitacionNegocio();
            int grupoID = Grupo(_idReserva);
            decimal total = decimal.Parse(dgvPedidoReserva.CurrentRow.Cells[4].Value.ToString());
            int id = int.Parse(dgvPedidoReserva.CurrentRow.Cells[0].Value.ToString());
            var cuenta = _ACuentaN.SelectList(item => item.id_grupo == grupoID && item.observacion_acuenta.Contains("NF") && item.estado_acuenta == true);
            if (_servicioHabitacionN.SelectCount(item => item.id == id &&
                                             item.pago_servicio_habitacion == true) == 1)
            {
                MessageBox.Show("No puede volver a pagar un producto", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (dgvPedidoReserva.CurrentRow != null)
                    _servicioHabitacionN.PagarServicio(int.Parse(dgvPedidoReserva.CurrentRow.Cells[0].Value.ToString()), _idUsuario, _idCajaDia, false);
                CargarProductosPedidos(grupoID);

                MessageBox.Show("Producto Pagado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string montoEnCaja = "";
                bool cajaCerrada = true;
                if (cuenta.Count > 0)
                {
                    var montoACuenta = cuenta.SingleOrDefault();
                    if (montoACuenta != null) montoEnCaja = montoACuenta.observacion_acuenta;

                    if (montoACuenta != null && montoACuenta.caja_cerrada != null) cajaCerrada = (bool)montoACuenta.caja_cerrada;
                }
            }


            //_liquidacionN.Insert(Asignar(total,montoEnCaja, cajaCerrada));
            CalcularMontos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _producto = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _producto.SelectListView(item => item.consumo == 1 && item.nombre_producto.Contains(txtBusqueda.Text));
        }


        private Liquidacion Asignar(decimal total, string montoEnCaja, bool estadoCaja)
        {
            ReservaNegocio oReservaNegocio = new ReservaNegocio();
            HuespedNegocio oNegocio = new HuespedNegocio();
            var reserva = oReservaNegocio.SelectSingle(item => item.id == _idReserva).codigo_reserva;
            string dato = Convert.ToInt32(reserva).ToString("00000000");
            var huesped = oNegocio.SelectListView(item => item.dni_huesped == dato).SingleOrDefault();
            if (huesped != null)
            {

                _liquidacion = new Liquidacion()
                {
                    id_usuario = _idUsuario,
                    id_caja_dia = _idCajaDia,
                    id_detalle_reserva = _idDetalleReserva,
                    estado_liquidacion = true,
                    tipo_comprobante_liquidacion = "T",
                    forma_pago_liquidacion = "E",
                    concepto_liquidacion = "",
                    id_huesped = huesped.id,
                    cliente_liquidacion = huesped.completo_huesped,
                    descuento_liquidacion = 0,
                    fecha_liquidacion = DateTime.Now,
                    igv_liquidacion = 0,
                    total_liquidacion = 0,
                    sub_total_liquidacion = 0,
                    real_liquidacion = 0,
                    consumo_liquidacion = total,
                    aumento_liquidacion = 0,
                    ntarjeta_liquidacion = "",
                    referencia_liquidacion = "",
                    estado_tarjeta = false
                };
                _liquidacion.monto_en_caja = true;

            }

            return _liquidacion;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            _producto = new ProductoNegocio();
            vistaProductoListBindingSource.DataSource = _producto.SelectListView(item => item.consumo == 1 && item.nombre_producto.Contains(txtBusqueda.Text));

        }

        private void FrmReservaPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }

}
