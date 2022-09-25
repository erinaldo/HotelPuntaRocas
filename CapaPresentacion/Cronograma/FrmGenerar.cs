using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;
using CapaPresentacion.Gestion;

namespace CapaPresentacion.Cronograma
{
    public partial class FrmGenerar : Form
    {
        private ReservaNegocio _reservaN;
        private HabitacionNegocio _habitacionN;
        string _hInt = ConfigurationManager.AppSettings["HCheckIN"] + ":" + ConfigurationManager.AppSettings["MCheckIN"] + ":00.000";
        string _hOut = ConfigurationManager.AppSettings["HCheckOUT"] + ":" + ConfigurationManager.AppSettings["MCheckOUT"] + ":00.000";
        string _anioHotel = ConfigurationManager.AppSettings["AnioHotel"];
        public FrmGenerar()
        {
            InitializeComponent();
        }

        #region Abrir formulario solo una vez
        private static FrmGenerar _mFormDefInstance;
        public static FrmGenerar DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmGenerar();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private int SeleccionarMes(string mes)
        {
            switch (mes)
            {
                case "Enero":
                    return 1;
                case "Febrero":
                    return 2;
                case "Marzo":
                    return 3;
                case "Abril":
                    return 4;
                case "Mayo":
                    return 5;
                case "Junio":
                    return 6;
                case "Julio":
                    return 7;
                case "Agosto":
                    return 8;
                case "Setiembre":
                    return 9;
                case "Octubre":
                    return 10;
                case "Noviembre":
                    return 11;
                case "Diciembre":
                    return 12;
                default:
                    return 0;
            }
        }

        private void ValidarFecha()
        {
            _reservaN = new ReservaNegocio();
            _habitacionN = new HabitacionNegocio();
            var listHabitacion = _habitacionN.SelectList(null, true);
            int anio = int.Parse(_anioHotel);
            int mes = SeleccionarMes(fComboBox1.Text);
            if (_reservaN.ExisteGenerado(mes, anio))
            {
                MessageBox.Show("Ya genero el mes.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int numeroDias = DateTime.DaysInMonth(anio, mes);
                foreach (var item in listHabitacion)
                {
                    for (int i = 0; i < numeroDias; i++)
                    {
                        _reservaN.GenerarMes(item.id, i, mes.ToString(), anio.ToString(), _hInt, _hOut);
                        CargaProgress(numeroDias);
                    }
                }
                MessageBox.Show("Mes generado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (fComboBox1.Text != "")
                ValidarFecha();
            else
                MessageBox.Show("Seleccione el mes a generar", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void CargaProgress(int _max)
        {
            pgbProceso.Maximum = _max;
            pgbProceso.Minimum = 0;
            pgbProceso.Value = 0;
            pgbProceso.Step = 1;
            for (int i = pgbProceso.Minimum; i < pgbProceso.Maximum; i = i + pgbProceso.Step)
            {
                pgbProceso.PerformStep();
            }
        }

        private void fGroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGenerar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
