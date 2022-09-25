using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Consulta;
using CapaPresentacion.Gestion;
using CapaPresentacion.Pop_up;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaPanel : Form
    {
        ReservaNegocio _reservaN;
        HabitacionNegocio _habitacionN;
        ReservaDetalleNegocio _detalleReservaN;
        
        public FrmReservaPanel()
        {
            InitializeComponent();
            ListarHabitaciones(true, dtpConsulta.Value.Date);
        }

        private void CargarComboDe()
        {
            _habitacionN = new HabitacionNegocio();
            if (_habitacionN.ListarHabitacionesPorEstado(dtpConsulta.Value.Date, "6").Count != 0)
                paListaHabitacionesPorEstadoResultBindingSource_1.DataSource = _habitacionN.ListarHabitacionesPorEstado(dtpConsulta.Value.Date, "6").OrderBy(item => item.id);
        }

        private void CargarComboPara()
        {
            _habitacionN = new HabitacionNegocio();
            if (_habitacionN.ListarHabitacionesPorEstado(dtpConsulta.Value.Date, "6").Count != 0)
                paListaHabitacionesPorEstadoResultBindingSource_2.DataSource = _habitacionN.ListarHabitacionesPorEstado(dtpConsulta.Value.Date, "2").OrderBy(item => item.id); ;
        }

        private static FrmReservaPanel _mFormDefInstance;
        public static FrmReservaPanel DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmReservaPanel();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }

        private void ListarHabitaciones(bool flag, DateTime fecha)
        {
            RedimensionarInterfaz();
            int x, y;
            panel8.Controls.Clear();
            int count = 1;
            if (flag)
            {
                x = 80;
                y = -147;
            }
            else
            {
                x = 280;
                y = 300;
                //x = 142; 
                //y = 22;
            }

            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       Prereserva          (240,230,140)       7
             */
            _reservaN = new ReservaNegocio();
            _habitacionN = new HabitacionNegocio();
            if (_habitacionN.ListarHabitacionesPorFecha(fecha).Count > 0)
            {
                foreach (var items in _habitacionN.ListarHabitacionesPorFecha(fecha))
                {

                    DateTime fechaHotelera = items.fecha_creacion.Date.AddDays(-1);
                    int habitacion = items.id_habitacion;
                    var dato =_reservaN.SelectSingle(item => item.id_habitacion == habitacion && item.fecha_hotelera == fechaHotelera);

                    int[] rgbDetalle = { 61, 61, 61 };


                    if (dato.id_habitacion == 1036)
                    {
                        //panel8.Controls.Add(BotonHabitacion(items.id, x, y, PintaEstados("1"), items.estado_habitacion_reserva, items.piso_habitacion.Trim() + items.numero_habitacion));
                        panel8.Controls.Add(BotonHabitacion(items.id, x, y, PintaEstados(items.estado_habitacion_reserva), items.estado_habitacion_reserva, items.piso_habitacion.Trim() + items.numero_habitacion));

                    }
                    else
                    {
                        panel8.Controls.Add(BotonHabitacion(items.id, x, y, PintaEstados(items.estado_habitacion_reserva), items.estado_habitacion_reserva, items.piso_habitacion.Trim() + items.numero_habitacion));
                    }

                    int axu = y;
                    for (int j = 1; j < items.capacidad_habitacion; j++)
                    {
                        if (items.capacidad_habitacion == 4)
                        {
                            panel8.Controls.Add(BotonDetalleHabitaciones(items.id, x + 82, axu, rgbDetalle, j));
                            axu += 33;
   
                        }
                        else
                        {
                            panel8.Controls.Add(BotonDetalleHabitaciones(items.id, x + 82, axu, rgbDetalle, j));
                            axu += 33;
                            panel8.Controls.Add(BotonAuto(items.id, x + 82, axu + 72));
                            panel8.Controls.Add(BotonCambioEstado(items.id, x + 82, axu + 102, dato.estado_habitacion_reserva));
                            axu += 25;
                            panel8.Controls.Add(BotonDiaAnterior(dato.id, x + 82, axu + 132, PintaEstados(dato.estado_habitacion_reserva), dato.estado_habitacion_reserva));
                        }
                    }
                    if (items.capacidad_habitacion == 4)
                    {
                        if (flag)
                        {
                            panel8.Controls.Add(BotonAuto(items.id, x + 82, axu + 5));
                            panel8.Controls.Add(BotonCambioEstado(items.id, x + 82, axu + 35, dato.estado_habitacion_reserva));
                            axu += 25;
                            panel8.Controls.Add(BotonDiaAnterior(dato.id, x + 82, axu + 65, PintaEstados(dato.estado_habitacion_reserva), dato.estado_habitacion_reserva));
                        }
                        else
                        {
                            panel8.Controls.Add(BotonAuto(items.id, x + 82, axu + 5));
                            panel8.Controls.Add(BotonCambioEstado(items.id, x + 82, axu + 35, dato.estado_habitacion_reserva));
                            axu += 25;
                            panel8.Controls.Add(BotonDiaAnterior(dato.id, x + 82, axu + 65, PintaEstados(dato.estado_habitacion_reserva), dato.estado_habitacion_reserva));
                        }
                    }
                    count++;
                    if (count < 6)
                        y += 270;
                    else
                    {
                        x += 120;
                        if (flag)
                            y = -147;
                        else
                            //y = 22;
                            y = 300;
                        count = 1;
                    }

                }

            }
            else
            {
                //MessageBox.Show("Día terminado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private Button BotonDiaAnterior(int idReserva, int x, int y, int[] rgb, string estado )
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * xxxxxx       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       Prereserva          (240,230,140)       7
             */
            string texto = "";

            if (estado == "6")
                texto = "O";
            if (estado == "4")
                texto = "P";
            if (estado == "8")
                texto = "S";
            if (estado == "1")
                texto = "M";
            if (estado == "5")
                texto = "R";
            if (estado == "7")
                texto = "P";
            if (estado == "3")
                texto = "S";

            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_da" + idReserva;
            btn.Size = new Size(45, 30);
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            btn.Text = texto;
            btn.Tag = idReserva.ToString();
            btn.Click += new EventHandler(button_dia_anterior_Click);
            if (estado != "2")
                btn.Visible = true;
            else
                btn.Visible = false;
            return btn;
        }

        private void button_dia_anterior_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idReserva = int.Parse(btn.Tag.ToString());
            _reservaN = new ReservaNegocio();
            var reservaE = _reservaN.SelectSingle(item => item.id == idReserva);
            //if (reservaE.Tarifa_habitacion == null)
            //{
            //    MessageBox.Show("No puede cambiar el estado.\nNo agregó huesped(es) a esta reserva aún.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (reservaE.estado_habitacion_reserva == "2" )
            //{
            //    MessageBox.Show("No puede cambiar el estado.\nNo agregó huesped(es) a esta reserva aún.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            var frm = new FrmReservaEstadoDiaAnterio(idReserva);
            if (frm.ShowDialog((this)) == DialogResult.OK)
                btnActualizar_Click(null, null);
        }

        private Button BotonHabitacion(int idReserva, int x, int y, int[] rgb, string estado, string text)
        {
            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
            btn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_h" + idReserva;
            btn.Size = new Size(235, 80);
            btn.Text = text;
            btn.Top = x;
            btn.Left = y;
            btn.Click += button_Habitacion_Click;
            btn.Visible = true;
            btn.FlatAppearance.BorderColor = Color.White;
            return btn;
        }

        private void button_Habitacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idReserva = int.Parse(btn.Name.Substring(5));
            _reservaN = new ReservaNegocio();
            var reservaE = _reservaN.SelectSingle(item => item.id == idReserva);
            if (reservaE.estado_habitacion_reserva == "2")
            {
                FrmHPrincipal frm = new FrmHPrincipal(idReserva, reservaE.id_habitacion, 1, btn.Text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    btnActualizar_Click(null, null);
            }
            else
            {
                var estado = _reservaN.SelectSingle(item => item.id == idReserva);
                if (estado.estado_habitacion_reserva == "1")
                {
                    MessageBox.Show("Habitación en mantenimiento. Cambie a estado Limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (estado.estado_habitacion_reserva == "3")
                {
                    MessageBox.Show("Habitación Desocupada. Cambie a estado Limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (estado.estado_habitacion_reserva == "4")
                {
                    MessageBox.Show("Habitación en Proceso de Limpieza. Cambie a estado Disponible.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                FrmHPrincipalVer frm = new FrmHPrincipalVer(idReserva, reservaE.id_habitacion, 1, btn.Text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    btnActualizar_Click(null, null);
            }

        }
        private Button BotonDetalleHabitaciones(int idReserva, int x, int y, int[] rgb, int indice)
        {
            Button btn = new Button();
            _detalleReservaN = new ReservaDetalleNegocio();
            if (_detalleReservaN.SelectCount(item => item.id_reserva == idReserva && item.estado == true && item.indice > 1) > 0)
                btn.BackColor = Color.FromArgb(0, 0, 255);
            else
                btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_d" + idReserva;
            btn.Size = new Size(25, 30);
            btn.Image = Resources.persona;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            btn.DialogResult = DialogResult.OK;
            //btn.Click += new EventHandler(button_Detalle_Habitacion_Click);
            btn.Visible = true;
            btn.Tag = indice+1;
            return btn;
        }
        private void button_Auto_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idReserva = int.Parse(btn.Name.Substring(5));
            _reservaN = new ReservaNegocio();            
            var reservaE = _reservaN.SelectSingle(item => item.id == idReserva);
            //if (reservaE.estado_habitacion_reserva == "6")
            //{
                if (reservaE.estado_auto == null)
                {
                    _reservaN.RegistraAuto(idReserva);
                    MessageBox.Show("Hueesped ingresa con Auto", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

                else
                {
                    _reservaN.DesregistraAuto(idReserva);
                    MessageBox.Show("Huesped se retira.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            //}
            //else
            //{
            //    MessageBox.Show("No puede registrar auto, sin tener la habitacion ocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            ListarHabitaciones(false, dtpConsulta.Value.Date);
        }
        private void button_Detalle_Habitacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idReserva = int.Parse(btn.Name.Substring(5));
            _reservaN = new ReservaNegocio();
            _detalleReservaN = new ReservaDetalleNegocio();
            var reservaE = _reservaN.SelectSingle(item => item.id == idReserva);
            string habitacion = reservaE.Habitacion.piso_habitacion.Trim() + reservaE.Habitacion.numero_habitacion;
            if (reservaE.HabitacionTarifa == null)
            {
                MessageBox.Show("No puede agregar huesped(es) a esta reserva aún.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((reservaE.estado_habitacion_reserva != "6" && reservaE.fecha_hotelera.Value.Date == DateTime.Now.Date))
            {
                MessageBox.Show("No puede agregar huesped(es) a esta reserva aún.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int indice = int.Parse(btn.Tag.ToString());
            if (_detalleReservaN.SelectCount(item => item.id_reserva == idReserva && item.indice == indice) == 0)
            {
                if (reservaE.estado_habitacion_reserva == "6")
                {
                    FrmHSecundario frm = new FrmHSecundario(idReserva, reservaE.id_habitacion, indice, habitacion);
                    if (frm.ShowDialog(this) == DialogResult.OK)
                        btnActualizar_Click(null, null);
                }
            }
            else
            {
                FrmHSecundarioVer frm = new FrmHSecundarioVer(idReserva, reservaE.id_habitacion, indice, habitacion);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    btnActualizar_Click(null, null);
            }

        }
        private Button BotonAuto (int idReserva, int x, int y)
        {
            Button btn = new Button();
            _reservaN = new ReservaNegocio();
            if (_reservaN.SelectCount(item => item.id == idReserva && item.estado_auto == true) > 0)
                btn.BackColor = Color.FromArgb(0, 0, 255);
            else
                btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_a" + idReserva;
            btn.Size = new Size(27, 30);
            btn.Image = Resources.Car_02;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            btn.Click += new EventHandler(button_Auto_Click);
            btn.Visible = true;
            return btn;
        }
        private Button BotonCambioEstado(int idReserva, int x, int y, string estado)
        {
            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_e" + idReserva;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            if (estado != "2")
            {
                btn.Size = new Size(50, 30);
                btn.Text = "E";

            }
            else
            {
                btn.Size = new Size(100, 30);
                btn.Text = "Estado";
            }
            btn.Click += new EventHandler(button_cambio_estado_Click);
            btn.Visible = true;
            return btn;
        }
        private void button_cambio_estado_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idReserva = int.Parse(btn.Name.Substring(5));
            _reservaN = new ReservaNegocio();
            var reservaE = _reservaN.SelectSingle(item => item.id == idReserva);
            var frm = new FrmReservaEstados(idReserva);
            if(frm.ShowDialog((this)) == DialogResult.OK)
                btnActualizar_Click(null,null);
        }

        private int[] PintaEstados(string estadoHabitacion)
        {
            int[] rgbCuarto = new int[3];
            switch (estadoHabitacion)
            {
                case "1":
                    //Mantenimiento
                    rgbCuarto[0] = 255;
                    rgbCuarto[1] = 0;
                    rgbCuarto[2] = 0;
                    break;
                case "2":
                    //Disponibilidad
                    rgbCuarto[0] = 0;
                    rgbCuarto[1] = 128;
                    rgbCuarto[2] = 0;
                    break;
                case "3":
                    //Salida
                    rgbCuarto[0] = 255;
                    rgbCuarto[1] = 165;
                    rgbCuarto[2] = 0;
                    break;
                case "4":
                    //Supervisando
                    rgbCuarto[0] = 100;
                    rgbCuarto[1] = 149;
                    rgbCuarto[2] = 237;
                    break;
                case "5":
                    //Reservas
                    rgbCuarto[0] = 108;
                    rgbCuarto[1] = 19;
                    rgbCuarto[2] = 43;
                    break;
                case "6":
                    //Ocupado
                    rgbCuarto[0] = 0;
                    rgbCuarto[1] = 0;
                    rgbCuarto[2] = 255;
                    break;
                case "7":
                    //PreLimpieza
                    rgbCuarto[0] = 128;
                    rgbCuarto[1] = 128;
                    rgbCuarto[2] = 0;
                    break;
                case "8":
                    //PreLimpieza
                    rgbCuarto[0] = 47;
                    rgbCuarto[1] = 79;
                    rgbCuarto[2] = 79;
                    break;
            }
            return rgbCuarto;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarHabitaciones(false, dtpConsulta.Value.Date);
        }

        private void FrmReservaPanel_Load(object sender, EventArgs e)
        {
            //dtpConsulta.MinDate = DateTime.Now.AddDays(-1);

            RedimensionarInterfaz();
            CargarComboDe();
        }

        private void RedimensionarInterfaz()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListarHabitaciones(false, dtpConsulta.Value.Date);
            CargarComboDe();
        }

        private void FrmReservaPanel_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //var f = this.ParentForm;
                //Form principal = (Form)f;
                //principal.MdiChildren.Count();   
            }
            finally { }
            this.WindowState = FormWindowState.Maximized;
        }

        private void cboDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboPara();
        }

        private void btnCambiarHabitacion_Click(object sender, EventArgs e)
        {
            _reservaN = new ReservaNegocio();
            if (cboDe.Text == "" || cboA.Text == "")
            {
                MessageBox.Show("No existen habitaciones para cambiar.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var idHabitacionDe = int.Parse(cboDe.SelectedValue.ToString());
            var idHabitacionPara = int.Parse(cboA.SelectedValue.ToString());
            var fecha = dtpConsulta.Value.Date;

            var idReservaDe = _reservaN.ObtenerReserva(idHabitacionDe, fecha);
            var idReservaPara = _reservaN.ObtenerReserva(idHabitacionPara, fecha);

            if (idReservaDe == 0 || idReservaPara == 0)
            {
                MessageBox.Show("Error de la Operación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _reservaN.CambiarHabitacion(idHabitacionDe, idHabitacionPara,idReservaDe, idReservaPara, fecha);
            }
            ListarHabitaciones(false, dtpConsulta.Value.Date);
            CargarComboDe();
        }

        private void cboDe_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarComboPara();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusquedaReserva oFrm = new FrmBusquedaReserva(txtHuesped.Text);
            oFrm.ShowDialog();
        }

        private void fButtonBuscar1_Click(object sender, EventArgs e)
        {
            FrmUnificarFacturas oFrm = new FrmUnificarFacturas();
            oFrm.ShowDialog();
        }

        private void fButtonBuscar2_Click(object sender, EventArgs e)
        {
            FrmHuesped form = new FrmHuesped();
            form.ShowDialog();
        }

        private void FrmReservaPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void fButtonBuscar3_Click(object sender, EventArgs e)
        {
            FrmEmpresa form = new FrmEmpresa();
            form.ShowDialog();
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            ListarHabitaciones(false, DateTime.Today.Date);
            dtpConsulta.Value = DateTime.Today.Date;
            CargarComboDe();
        }

        private void btnAyer_Click(object sender, EventArgs e)
        {
            ListarHabitaciones(false, DateTime.Today.Date.AddDays(-1));
            DateTime dia = DateTime.Now.AddDays(-1);
            dtpConsulta.MinDate = dia.Date;
            dtpConsulta.Value = dia.Date;
            CargarComboDe();
        }
    }
}
