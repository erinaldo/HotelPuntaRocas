using System;
using System.Configuration;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Functions;

namespace CapaPresentacion.Seguridad
{
    public partial class FrmRol : Form
    {
        RolNegocio _rolN;
        Rol _rolE;
        bool flag;
        string _nombreConcepto = "";

        public FrmRol()
        {
            InitializeComponent();
            CargaDatos();
            ControlesFormulario(true);        
        }

        #region Abrir formulario solo una vez
        private static FrmRol _mFormDefInstance;
        public static FrmRol DefInstance
        {
            get
            {
                if (_mFormDefInstance == null || _mFormDefInstance.IsDisposed)
                    _mFormDefInstance = new FrmRol();
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
            _rolN = new RolNegocio();
            rolBindingSource.DataSource = _rolN.SelectList(item => item.estado_rol == true, true);
        }

        #region Control de las acciones del formulario
        private void ControlesFormulario(bool act)
        {
            txtRol.Enabled = !act;
            btnNuevo.Enabled = act;
            btnEditar.Enabled = act;
            btnEliminar.Enabled = act;
            btnGuardar.Enabled = !act;
            btnCancelar.Enabled = !act;
            if (act)
            {
                rolBindingSource.ResumeBinding();
                CargaDatos();
            }
            else
            {
                if (flag)
                {
                    rolBindingSource.SuspendBinding();                    
                }
                txtRol.Focus();
            }
        }
        #endregion

        #region Asignacion de la entidad
        private Rol Asignar()
        {
            _rolE = new Rol()
            {
                nombre_rol = this.txtRol.Text,
                permiso_rol = "11111111111111111111111111111111111111111111",
                estado_rol = true
            };
            if (flag) return _rolE;
            if (dgvConepto.CurrentRow != null)
                _rolE.id_rol = int.Parse(dgvConepto.CurrentRow.Cells[0].Value.ToString());
            return _rolE;
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
            _rolN = new RolNegocio();
            _rolE = new Rol();
            int _rol = int.Parse(dgvConepto.CurrentRow.Cells[0].Value.ToString());


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
                _rolE = Asignar();
                if (_rolN.SelectCount(item => item.id_rol == _rol) != 0)
                {
                    MessageBox.Show("Esta operación no se puede realizar.\nEl rol "+ _rolE.nombre_rol.ToUpper() +"ya ha sido asignado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _rolE.estado_rol = false;
                _rolN.Update(_rolE);
                MessageBox.Show("Proceso realizado con éxito.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _rolN = new RolNegocio();
            string nombreConcepto = (string.IsNullOrEmpty(this.txtRol.Text)) ? "" : this.txtRol.Text.Trim();
            if (nombreConcepto.Equals(""))
            {
                MessageBox.Show("Registre un Rol.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtRol.Focus();
                return;
            }


            if (flag)
            {
                if (_rolN.SelectCount(q => q.estado_rol == true && q.nombre_rol == nombreConcepto) > 0)
                {
                    MessageBox.Show("El rol ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtRol.Focus();
                    return;
                }
                _rolN.Insert(Asignar());
            }
            else
            {
                if (_nombreConcepto.Equals(nombreConcepto) == false)
                {
                    if (_rolN.SelectCount(q => q.estado_rol == true && q.nombre_rol == nombreConcepto) > 0)
                    {
                        MessageBox.Show("El rol ya ha sido creado.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtRol.Focus();
                        return;
                    }
                }
                _rolN.Update(Asignar());

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

        private void txtRol_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            int idRol = int.Parse(_nombreConcepto = dgvConepto.CurrentRow.Cells[0].Value.ToString());
            string nombreRol = _nombreConcepto = dgvConepto.CurrentRow.Cells[1].Value.ToString();
            FrmPermisos oFrm = new FrmPermisos(idRol, nombreRol);
            oFrm.Show();
        }

        private void FrmRol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
