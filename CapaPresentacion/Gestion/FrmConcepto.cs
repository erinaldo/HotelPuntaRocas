using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Gestion
{
    public partial class FrmConcepto : Form
    {
        ConceptoNegocio _conceptoN;
        Concepto _conceptoE;
        bool flag;
        string _nombreConcepto = "";

        public FrmConcepto()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmConcepto _mFormDefInstance;
        public static FrmConcepto DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmConcepto();
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
            _conceptoN = new ConceptoNegocio();
            conceptoBindingSource.DataSource = _conceptoN.SelectList(item => item.estado_concepto == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtConcepto.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                conceptoBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    conceptoBindingSource.SuspendBinding();                    
                }
                txtConcepto.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Concepto Asignar()
        {
            _conceptoE = new Concepto()
            {
                descripcion_concepto = this.txtConcepto.Text,
                estado_concepto = true
            };
            if (flag) return _conceptoE;
            if (dgvConepto.CurrentRow != null)
                _conceptoE.id = int.Parse(dgvConepto.CurrentRow.Cells[0].Value.ToString());
            return _conceptoE;
        }
        #endregion

        #region CRUD 


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flag = true;
            ControlesFormulario(false);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvConepto.RowCount == 0)
            {
                MessageBox.Show("No existe ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            flag = false;
            ControlesFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            _conceptoN = new ConceptoNegocio();
            _conceptoE = new Concepto();

            //
            //productoBLL = new ProductoBLL();

            flag = false;
            if (dgvConepto.RowCount == 0)
            {
                MessageBox.Show("No hay ningún registro", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", ".::. Sistema Hotelero .::.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _conceptoE = Asignar();
                //if (productoBLL.categoriaAsignada(E.id_categoria) != 0)
                //{
                //    MessageBox.Show("Esta operación no se puede realizar.\nLa Categoria Producto ya fue asignada.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                _conceptoE.estado_concepto = false;
                _conceptoN.Update(_conceptoE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _conceptoN = new ConceptoNegocio();
            string nombreConcepto = (string.IsNullOrEmpty(this.txtConcepto.Text)) ? "" : this.txtConcepto.Text.Trim();
            if (nombreConcepto.Equals(""))
            {
                MessageBox.Show("Registre un concepto de egreso.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtConcepto.Focus();
                return;
            }


            if (flag)
            {
                if (_conceptoN.SelectCount(q => q.estado_concepto == true && q.descripcion_concepto == nombreConcepto) > 0)
                {
                    MessageBox.Show("El concepto de egreso ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtConcepto.Focus();
                    return;
                }
                _conceptoN.Insert(Asignar());
            }
            else
            {
                if (_nombreConcepto.Equals(nombreConcepto) == false)
                {
                    if (_conceptoN.SelectCount(q => q.estado_concepto == true && q.descripcion_concepto == nombreConcepto) > 0)
                    {
                        MessageBox.Show("El concepto de egreso ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtConcepto.Focus();
                        return;
                    }
                }
                _conceptoN.Update(Asignar());

            }
            MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvConepto.Select();
            ControlesFormulario(true);
            CargaDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvConepto.Select();
            ControlesFormulario(true);
            CargaDatos();
        }
        #endregion



        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
                if (dgvConepto.CurrentRow != null)
                    _nombreConcepto = dgvConepto.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) &&
                               (e.KeyChar != (char)Keys.Back) &&
                               (e.KeyChar != (char)Keys.Space) &&
                               (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void FrmConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
