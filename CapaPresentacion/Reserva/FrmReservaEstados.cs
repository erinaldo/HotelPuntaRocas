using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Reserva
{
    public partial class FrmReservaEstados : Form
    {
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
        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        private readonly int _idReserva;

        ReservaNegocio _reservaN;

        public FrmReservaEstados(int idReserva)
        {
            InitializeComponent();
            _idReserva = idReserva;
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */

            _reservaN = new ReservaNegocio();
            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;
            if (estado == "6")
            {
                MessageBox.Show("No puede poner en mantenimiento una habitación \n que esta ocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "7")
            {
                MessageBox.Show("No puede poner en mantenimiento una habitación \n que esta prelimpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "3")
            {
                MessageBox.Show("No puede poner en mantenimiento una habitación \n que esta en salida.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "1")
            {
                return;
            }
            if (estado == "5")
            {
                MessageBox.Show("No puede poner en Mantenimiento una habitación \n que ha sido marcada como Reserva.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (estado == "8")
            {
                MessageBox.Show("No puede Supervisar esta habitación pues \n aún no han marcado proceso de limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (codigoReserva.codigo_reserva != null)
            {
                _reservaN.CambiaEstado(_idReserva, "1");
                int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "1");
            }
            else
            {
                _reservaN.CambiarEstadoSinHuesped(_idReserva, "1");
            }
        }

        private void btnDisponible_Click(object sender, EventArgs e)
        {

            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */

            _reservaN = new ReservaNegocio();
            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;
            if (estado == "5")
            {
                MessageBox.Show("No puede poner en disponible una habitación \n reservada, retire la habitación antes.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "7")
            {
                MessageBox.Show("No puede poner en disponible una habitación \n en pre-reserva.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "6")
            {
                MessageBox.Show("No puede poner en disponible una habitación \n que esta ocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "2")
            {
                return;
            }
            if (estado == "3")
            {
                MessageBox.Show("No puede poner en Disponible una habitación \n que ha sido marcada como CheckOut.",
                    ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (estado == "4")
            {
                MessageBox.Show("No puede poner en disponible una habitación \n en proceso de limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (codigoReserva.codigo_reserva != null)
            {
                _reservaN.CambiaEstado(_idReserva, "2");
                int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "2");
            }
            else
            {
                _reservaN.CambiarEstadoSinHuesped(_idReserva, "2");
            }
        }

        private void btnSupervisado_Click(object sender, EventArgs e)
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */

            _reservaN = new ReservaNegocio();
          
            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;
            if (estado == "6")
            {
                MessageBox.Show("No puede poner en Proceso de Limpieza una habitación \n que no ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "2")
            {
                MessageBox.Show("No puede poner en Proceso de Limpieza una habitación \n que no ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "7")
            {
                MessageBox.Show("No puede poner en Proceso de Limpieza una habitación \n que no ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (estado == "1")
            //{
            //    MessageBox.Show("No puede poner en Proceso de Limpieza una habitación \n que no ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (estado == "4")
            {
                return;
            }

            if (estado == "5")
            {
                MessageBox.Show("No puede poner en Mantenimiento una habitación \n que ha sido marcada como Reserva.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "8")
            {
                MessageBox.Show("No puede Supervisar esta habitación pues \n aún no han marcado proceso de limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (codigoReserva.codigo_reserva != null)
            {
                _reservaN.CambiaEstado(_idReserva, "4");
                int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "4");
            }
            else
            {
                _reservaN.CambiarEstadoSinHuesped(_idReserva, "4");
            }
        }

        private void btnOcupado_Click(object sender, EventArgs e)
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */
            _reservaN = new ReservaNegocio();

            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;
            if (estado == "7" && codigoReserva.codigo_reserva == null)
            {
                MessageBox.Show("No puede poner en Ocupado una habitación.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "6")
            {
                return;
            }
            if (estado == "3")
            {
                MessageBox.Show("No puede poner en Ocupado una habitación \n que ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "4")
            {
                MessageBox.Show("No puede poner en Ocupado una habitación \n que ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "2")
            {
                MessageBox.Show("No puede poner en Ocupado una habitación \n que ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "8")
            {
                MessageBox.Show("No puede Supervisar esta habitación pues \n aún no han marcado proceso de limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (codigoReserva.codigo_reserva != null)
            {
                int grupo = (int)codigoReserva.grupo_reserva;
                if(estado == "5")
                    _reservaN.CambiarEstadoGrupo(grupo, "6");
                else if(estado == "7")
                    _reservaN.CambiarEstadoGrupo_2(grupo, "6");

                int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "6");
            }
            else
            {
                MessageBox.Show("No puede poner ocupada esta habitación pues \n áún no ha registrado huesped.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreLimpieza_Click(object sender, EventArgs e)
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */
            _reservaN = new ReservaNegocio();
            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;
            if (estado == "6" && codigoReserva.codigo_reserva == null)
            {
                MessageBox.Show("No puede poner en Pre de Limpieza una habitación \n que ha sido marcada como Ocupada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "3")
            {
                MessageBox.Show("No puede poner en Pre de Limpieza una habitación \n que ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "4" && codigoReserva.codigo_reserva == null)
            {
                MessageBox.Show("No puede poner en Pre de Limpieza una habitación \n que ha sido marcada como CheckOut.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (estado == "7")
            {
                return;
            }

            if (estado == "5")
            {
                MessageBox.Show("No puede poner en Mantenimiento una habitación \n que ha sido marcada como Reserva.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (codigoReserva.codigo_reserva != null)
            {
                if (estado != "4")
                {
                    _reservaN.CambiaEstado(_idReserva, "7");
                    int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "7");
                }
                else
                {
                    MessageBox.Show("No puede poner pre-limpieza en esta habitación pues \n áún no ha registrado huesped.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No puede poner en pre-limpieza en esta habitación pues \n áún no ha registrado huesped.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupervisar_Click(object sender, EventArgs e)
        {
            /*
             * Lista de Estados 
             * Rojo         Mantenimiento       (255,0,0)           1
             * Verde        Disponibilidad      (0,128,0)           2
             * Anaranjado   Salida              (255,165,0)         3
             * Blanco       Supervisando        (255,255,255)       4
             * Guinda       Reservas            (108, 19, 43)       5
             * Azul         Ocupado             (0,0,255)           6
             * Canela       PreLimpieza         (240,230,140)       7
             */

            _reservaN = new ReservaNegocio();

            var codigoReserva = _reservaN.SelectSingle(item => item.id == _idReserva);
            string estado = codigoReserva.estado_habitacion_reserva;

            if (estado == "4")
            {
                if (codigoReserva.codigo_reserva != null)
                {
                    _reservaN.CambiaEstado(_idReserva, "8");
                    int dni = int.Parse(codigoReserva.codigo_reserva.ToString());
                    _reservaN.MovimientoEstados(_idReserva, _idUsuario, DateTime.Now, dni, "8");
                    return;
                }
                else
                {
                    _reservaN.CambiarEstadoSinHuesped(_idReserva, "8");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No puede Supervisar esta habitación pues \n aún no han marcado proceso de limpieza.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmReservaEstados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}