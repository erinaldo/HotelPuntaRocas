using System;
using System.Data;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmComprobante : Form
    {
        ComprobanteNegocio _comprobanteN;
        Comprobante _comprobanteE;
        bool flag;
        string _tipoComprobante = "";

        public FrmComprobante()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmComprobante _mFormDefInstance;
        public static FrmComprobante DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmComprobante();
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
            _comprobanteN = new ComprobanteNegocio();
            vistaComprobanteBindingSource.DataSource = _comprobanteN.SelectListView(item => item.estado_comprobante);
            CargarTipoComprobantes();
        }

        private void CargarTipoComprobantes()
        {
            DataTable dtTipoComprobantes = new DataTable("dtTipo_Comprobantes");
            dtTipoComprobantes.Columns.Add("tipo_comprobante", typeof(string));
            dtTipoComprobantes.Columns.Add("descripcion_comprobante", typeof(string));
            dtTipoComprobantes.Rows.Add("00", "OTROS DOCUMENTOS");
            dtTipoComprobantes.Rows.Add("01", "FACTURA ELECTRÓNICA");
            dtTipoComprobantes.Rows.Add("03", "BOLETA ELECTRÓNICA");
            DataView dwTipoComprobantes = new DataView(dtTipoComprobantes);
            cboTipoComprobante.DataSource = dwTipoComprobantes;
            cboTipoComprobante.DisplayMember = "descripcion_comprobante";
            cboTipoComprobante.ValueMember = "tipo_comprobante";
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            cboTipoComprobante.Enabled = !act;
            txtSerieComprobante.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                vistaComprobanteBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    vistaComprobanteBindingSource.SuspendBinding();                    
                }
                cboTipoComprobante.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Comprobante Asignar()
        {
            _comprobanteE = new Comprobante()
            {
                tipo_comprobante = cboTipoComprobante.SelectedValue.ToString(),
                serie_comprobante =  txtSerieComprobante.Text.Trim(),
                correlativo_comprobante = int.Parse(txtCorrelativo.Text.Trim()),
                estado_comprobante= true
            };
            if (flag) return _comprobanteE;
            if (dgvComprobante.CurrentRow != null)
                _comprobanteE.id = int.Parse(dgvComprobante.CurrentRow.Cells[0].Value.ToString());
            return _comprobanteE;
        }
        #endregion

        #region CRUD 


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flag = true;
            ControlesFormulario(false);
            txtCorrelativo.Text = "0";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvComprobante.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _comprobanteN = new ComprobanteNegocio();
            _comprobanteE= new Comprobante();

            flag = false;
            if (dgvComprobante.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _comprobanteE = Asignar();
                _comprobanteE.estado_comprobante = false;
                _comprobanteN.Update(_comprobanteE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _comprobanteN = new ComprobanteNegocio();
            string tipoComprobante = (string.IsNullOrEmpty(this.cboTipoComprobante.SelectedValue.ToString())) ? "" : this.cboTipoComprobante.SelectedValue.ToString();
            if (tipoComprobante.Equals(""))
            {
                MessageBox.Show("Registre un Tipo de Comprobante.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboTipoComprobante.Focus();
                return;
            }


            if (flag)
            {
                if (_comprobanteN.SelectCount(q => q.estado_comprobante == true && q.tipo_comprobante == tipoComprobante) > 0)
                {
                    MessageBox.Show("El Tipo de Comprobante ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.cboTipoComprobante.Focus();
                    return;
                }
                _comprobanteN.Insert(Asignar());
            }
            else
            {
                if (_tipoComprobante.Equals(tipoComprobante) == false)
                {
                    if (_comprobanteN.SelectCount(q => q.estado_comprobante == true && q.tipo_comprobante == tipoComprobante) > 0)
                    {
                        MessageBox.Show("El Tipo de Comprobante ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.cboTipoComprobante.Focus();
                        return;
                    }
                }
                _comprobanteN.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvComprobante.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvComprobante.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion



        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
                if (dgvComprobante.CurrentRow != null)
                    _tipoComprobante = dgvComprobante.CurrentRow.Cells[1].Value.ToString();
        }

        private void FrmComprobante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmComprobante_Load(object sender, EventArgs e)
        {
            dgvComprobante.Columns[0].Visible = false;
        }
    }
}
