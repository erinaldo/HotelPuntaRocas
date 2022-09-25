using System;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Pop_up;
using CapaPresentacion.Properties;
using CapaPresentacion.Reserva;

namespace CapaPresentacion.Consulta
{
    public partial class FrmConsultaReserva : Form
    {
        ReservaNegocio _reservaN;
        HabitacionNegocio _habitacionN;
        ReservaDetalleNegocio _detalleReservaN;

        public FrmConsultaReserva()
        {
            InitializeComponent();
            ListarHabitaciones(true, dtpConsulta.Value.Date);
            //ListarHabitaciones(false, dtpConsulta.Value.Date);
        }

        private static FrmConsultaReserva _mFormDefInstance;
        public static FrmConsultaReserva DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConsultaReserva();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }

        private void ListarHabitaciones(bool flag, DateTime fecha)
        {
            int x, y;
            panelListaHabitaciones.Controls.Clear();
            int count = 1;
            if (flag)
            {
                x = 80;
                y = -147;
            }
            else
            {
                //x = 280;
                //y = 300;
                x = 142;
                y = 22;
            }

            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             */

            _habitacionN = new HabitacionNegocio();
            if (_habitacionN.ListarHabitacionesPorFecha(fecha).Count > 0)
            {
                foreach (var items in _habitacionN.ListarHabitacionesPorFecha(fecha))
                {


                    int[] rgbDetalle = { 61, 61, 61 };
                    panelListaHabitaciones.Controls.Add(BotonHabitacion(items.id, x, y, PintaEstados(items.id),
                                                                                                     items.estado_habitacion_reserva,
                                                                                                     items.piso_habitacion.Trim() +
                                                                                                     items.numero_habitacion));
                    int axu = y;
                    for (int j = 1; j < items.capacidad_habitacion; j++)
                    {
                        if (items.capacidad_habitacion == 4)
                        {
                            panelListaHabitaciones.Controls.Add(BotonDetalleHabitaciones(items.id, x + 80, axu, rgbDetalle, j));
                            axu += 33;
   
                        }
                        else
                        {
                            panelListaHabitaciones.Controls.Add(BotonDetalleHabitaciones(items.id, x + 80, axu, rgbDetalle, j));
                            axu += 33;
                            panelListaHabitaciones.Controls.Add(BotonAuto(items.id, x + 80, axu + 72));
                            panelListaHabitaciones.Controls.Add(BotonCambioEstado(items.id, x + 80, axu + 102));
                        }
                    }
                    if (items.capacidad_habitacion == 4)
                    {
                        if (flag)
                        {
                            panelListaHabitaciones.Controls.Add(BotonAuto(items.id, x + 80, axu + 5));
                            panelListaHabitaciones.Controls.Add(BotonCambioEstado(items.id, x + 80, axu + 35));
                        }
                        else
                        {
                            panelListaHabitaciones.Controls.Add(BotonAuto(items.id, x + 80, axu + 5));
                            panelListaHabitaciones.Controls.Add(BotonCambioEstado(items.id, x + 80, axu + 35));
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
                            y = 22;
                            //y = 300;
                        count = 1;
                    }

                }

            }
            else
            {
                MessageBox.Show("Día terminado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
            FrmHPrincipalConsulta frm = new FrmHPrincipalConsulta(idReserva, reservaE.id_habitacion, 1, btn.Text);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    btnActualizar_Click(null, null);
        }
        private Button BotonDetalleHabitaciones(int idReserva, int x, int y, int[] rgb, int indice)
        {
            Button btn = new Button();
            _detalleReservaN = new ReservaDetalleNegocio();
            if (_detalleReservaN.SelectCount(item => item.id_reserva == idReserva && item.estado == true && item.indice > 1) > 0)
                btn.BackColor = Color.FromArgb(0, 0, 255);
            else
                btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.FlatAppearance.BorderSize = 0;
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
            btn.Click += new EventHandler(button_Auto_Click);
            btn.Visible = true;
            btn.Tag = indice+1;
            return btn;
        }

        private void button_Auto_Click(object sender, EventArgs e)
        {

        }

        private void button_Detalle_Habitacion_Click(object sender, EventArgs e)
        {

        }

        private Button BotonAuto (int idReserva, int x, int y)
        {
            Button btn = new Button();
            _detalleReservaN = new ReservaDetalleNegocio();
            if (_detalleReservaN.SelectCount(item => item.id_reserva == idReserva && item.estado == true && item.indice > 1) > 0)
                btn.BackColor = Color.FromArgb(0, 0, 255);
            else
                btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_a" + idReserva;
            btn.Size = new Size(25, 30);
            btn.Image = Resources.Car_02;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            btn.Click += new EventHandler(button_Detalle_Habitacion_Click);
            btn.Visible = true;
            return btn;
        }

        private Button BotonCambioEstado(int idReserva, int x, int y)
        {
            Button btn = new Button();
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Anchor = AnchorStyles.None;
            btn.BackColor = Color.FromArgb(70, 61, 61);
            btn.Font = new Font("Segoe UI", 10.25F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Name = "btn_e" + idReserva;
            btn.Size = new Size(100, 30);
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Top = x;
            btn.Left = y;
            btn.Text = "Estado";
            btn.Click += new EventHandler(button_cambio_estado_Click);
            btn.Visible = true;
            return btn;
        }

        private void button_cambio_estado_Click(object sender, EventArgs e)
        {

        }

        private int[] PintaEstados(int idReserva)
        {
            _reservaN = new ReservaNegocio();
            var oReserva = _reservaN.SelectSingle(item => item.id == idReserva).grupo_reserva;
            string estadoHabitacion;
            if (oReserva != null)
            {
                estadoHabitacion = "2";
            }
            else
            {
                estadoHabitacion = "1";
            }
            int[] rgbCuarto = new int[3];
            switch (estadoHabitacion)
            {
                case "1":
                    //Mantenimiento
                    rgbCuarto[0] = 0;
                    rgbCuarto[1] = 128;
                    rgbCuarto[2] = 0;
                    break;
                case "2":
                    //Disponibilidad
                    rgbCuarto[0] = 0;
                    rgbCuarto[1] = 0;
                    rgbCuarto[2] = 0;
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
            RedimensionarInterfaz();
        }

        private void RedimensionarInterfaz()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            fLabelBig1.Text = "Consulta de Reservas : " +dtpConsulta.Value.ToShortDateString();
            ListarHabitaciones(false, dtpConsulta.Value.Date);
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

        private void dtpConsulta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmConsultaReserva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmConsultaHistorico ofrm = new FrmConsultaHistorico(txtHuesped.Text);
            ofrm.ShowDialog();
        }
    }
}
