using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Flujo_Caja
{
    public partial class FrmEgreso : Form
    {
        EgresoNegocio _egresoN;
        Egreso _egresoE;
        ConceptoNegocio _conceptoN;

        readonly int _idUsuario = int.Parse(ConfigurationManager.AppSettings["id_usuario"]);
        readonly int _idCajaDia = int.Parse(ConfigurationManager.AppSettings["id_caja_dia"]);

        bool _flag;

        public FrmEgreso()
        {
            InitializeComponent();
            CargarRegistros();
            CargarCombo();
            ControlesFormulario(true);
            dgvEgresos.Columns[0].Visible = false;
        }

        #region Abrir formulario solo una vez
        private static FrmEgreso _mFormDefInstance;
        public static FrmEgreso DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmEgreso();
                return _mFormDefInstance;
            }
            set
            {
                _mFormDefInstance = value;
            }
        }
        #endregion

        private void CargarRegistros()
        {
            _egresoN = new EgresoNegocio();
            vistaEgresoListBindingSource.DataSource = _egresoN.SelectListView(item => item.id_usuario == _idUsuario, true);
        }

        private void CargarCombo()
        {
            _conceptoN = new ConceptoNegocio();
            conceptoBindingSource.DataSource = _conceptoN.SelectList(item => item.estado_concepto, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            cboConcepto.Enabled = !act;
            txtMonto.Enabled  = !act;

            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                vistaEgresoListBindingSource.ResumeBinding();
                CargarRegistros();
            }
            else
            {
                if (_flag)
                {
                    vistaEgresoListBindingSource.SuspendBinding();                    
                }
                cboConcepto.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Egreso Asignar()
        {
            _egresoE = new Egreso()
            {
                id_usuario = _idUsuario,
                id_caja_dia = _idCajaDia,
                id_concepto =  int.Parse(cboConcepto.SelectedValue.ToString()),
                monto_egreso = decimal.Parse(this.txtMonto.Text.Trim()),
                fecha_registro_egreso = DateTime.Now,
                estado_egreso = true
            };
            if (!_flag)
                if (dgvEgresos.CurrentRow != null)
                    _egresoE.id = int.Parse(dgvEgresos.CurrentRow.Cells[0].Value.ToString());
            return _egresoE;
        }
        #endregion

        #region CRUD         
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _flag = true;
            ControlesFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEgresos.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _egresoN = new EgresoNegocio();
            _egresoE = new Egreso();
            _flag = false;
            if (dgvEgresos.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _egresoE.estado_egreso = false;
                _egresoN.Update(_egresoE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRegistros();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _egresoN = new EgresoNegocio();

            if(this.txtMonto.Text == "")
            {
                MessageBox.Show("Debe monto de egreso.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMonto.Focus();
                return;
            }

            if (_flag)
            {
                _egresoN.Insert(Asignar());
            }
            else
            {
                _egresoN.Update(Asignar());
            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvEgresos.Select();
            ControlesFormulario(true);
            CargarRegistros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvEgresos.Select();
            ControlesFormulario(true);
            CargarRegistros();
        }
        #endregion
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.OnlyDecimal(sender, e, '.');
        }

        private void FrmEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
