using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Configuracion
{
    public partial class FrmConfDolar : Form
    {
        DolarNegocio _dolarN;
        Dolar _dolarE;
        bool _tipoOperacion;

        public FrmConfDolar()
        {
            InitializeComponent();
            CargaDatos(); 
        }

        #region Abrir formulario solo una vez
        private static FrmConfDolar _mFormDefInstance;
        public static FrmConfDolar DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConfDolar();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void CargaDatos()
        {
            _dolarN = new DolarNegocio();
            dolarBindingSource.DataSource = _dolarN.SelectList(item => item.estado_dolar == true, true);
        }

        #region Asignacion de la entidad
        private Dolar Asignar()
        {
            _dolarE = new Dolar()
            {
                anio_dolar  = this.txtAnioRegistro.Text,
                valor_dolar = decimal.Parse(this.txtDolarActual.Text),
                estado_dolar = true
            };
            if (_tipoOperacion)
            {
                if (dgv_datos.CurrentRow != null)
                    _dolarE.id = int.Parse(dgv_datos.CurrentRow.Cells[0].Value.ToString());
            }
            return _dolarE;
        }
        #endregion

        #region CRUD 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _dolarN = new DolarNegocio();

            if (_tipoOperacion)
            {
                _dolarN.Insert(Asignar());
            }
            else
            {
                _dolarN.Update(Asignar());
            }
 
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargaDatos();
            this.Close();
        }
        #endregion



        private void txtIGVActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyNumbers(e))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _tipoOperacion = true;
            ControlesFormulario(false);
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv_datos.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _tipoOperacion = false;
            ControlesFormulario(false);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtAnioRegistro.Enabled = !act;
            txtDolarActual.Enabled = !act;

            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnGuardar.Enabled = !act;
            if (act)
            {
                dolarBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (_tipoOperacion)
                {
                    dolarBindingSource.SuspendBinding();
                }
                txtAnioRegistro.Focus();
            }
        }
        #endregion

        private void FrmConfDolar_Load(object sender, EventArgs e)
        {
            ControlesFormulario(true);
        }

        private void txtDolarActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Validations.OnlyDecimal(txtAnioRegistro, e, '.'))
                MessageBox.Show("Ingrese solo decimales.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmConfDolar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
