using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Seguridad
{
    public partial class FrmPermisos : Form
    {
        public Rol oRol;
        public RolNegocio oRolN;
        public int contador = 0;
        public string permiso, cadenapermisos = "";
        public int _id_rol = 0;

        public FrmPermisos(int _id, string _nombre)
        {
            InitializeComponent();
            lblPermisos.Text += ": " + _nombre;
            try
            {
                _id_rol = _id;
                AsignarEntidad(_id);
                CargarParametros();
            }
            catch { }
            btnSalir.Select();
            btnSalir.Focus();
        }

        public void AsignarEntidad(int id)
        {
            oRolN = new RolNegocio();
            oRol = new Rol();
            oRol = oRolN.SelectSingle(item => item.id_rol.Equals(id));
        }

        private void CargarParametros()
        {
            permiso = oRol.permiso_rol;
            this.treeViewMantenimientos.ExpandAll();
            this.treeViewCompras.ExpandAll();
            this.treeViewReservas.ExpandAll();
            this.treeViewCaja.ExpandAll();
            this.treeViewConsumo.ExpandAll();
            this.treeViewConsulta.ExpandAll();
            this.treeViewReportes.ExpandAll();
            

            ListarTreeView(treeViewMantenimientos);
            ListarTreeView(treeViewCompras);
            ListarTreeView(treeViewReservas);
            ListarTreeView(treeViewCaja);
            ListarTreeView(treeViewConsumo);
            ListarTreeView(treeViewConsulta);
            ListarTreeView(treeViewReportes);   
        }

        public void ListarTreeView(TreeView nombreArbol)
        {
            foreach (TreeNode tool in nombreArbol.Nodes)
            {
                if ((permiso.Substring(contador, 1) == "0"))
                {
                    tool.Checked = false;
                }
                else
                {
                    tool.Checked = true;
                }
                contador++;
                if (tool.Nodes.Count > 0)
                {
                    ChekMenu(tool.Nodes);
                }
            }
        }

        private void ChekMenu(TreeNodeCollection item)
        {
            foreach (TreeNode i in item)
            {
                if (i is TreeNode)
                {

                    if ((permiso.Substring(contador, 1) == "0"))
                    {
                        i.Checked = false;
                    }
                    else
                    {
                        i.Checked = true;
                    }
                    contador++;
                    if (((TreeNode)i).Nodes.Count > 0)
                    {

                        ChekMenu(((TreeNode)i).Nodes);
                    }
                }
            }
        }

        private void CheckChildNode(TreeNode currNode)
        {
            bool checkStatus = currNode.Checked;
            foreach (TreeNode node in currNode.Nodes)
            {
                node.Checked = checkStatus;
                CheckChildNode(node);
            }
        }

        private void CheckParentNode(TreeNode currNode)
        {
            TreeNode parentNode = currNode.Parent;
            if ((parentNode == null))
            {
                return;
            }
            parentNode.Checked = false;
            foreach (TreeNode node in parentNode.Nodes)
            {
                if (node.Checked)
                {
                    parentNode.Checked = true;
                    break;
                }
            }
            CheckParentNode(parentNode);
        }

        private void RecorrerNodos(TreeNode objNode)
        {
            TreeNode Nodo;
            Nodo = objNode;
            foreach (TreeNode node in Nodo.Nodes)
            {
                if ((node.Checked == true))
                {
                    cadenapermisos += "1";
                }
                else
                {
                    cadenapermisos += "0";
                }
                RecorrerNodos(node);
            }
        }

        private void treeViewMantenimientos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewMantenimientos.AfterCheck -= new TreeViewEventHandler(treeViewMantenimientos_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewMantenimientos.AfterCheck += new TreeViewEventHandler(treeViewMantenimientos_AfterCheck);
        }

        private void treeViewCompras_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewCompras.AfterCheck -= new TreeViewEventHandler(treeViewCompras_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewCompras.AfterCheck += new TreeViewEventHandler(treeViewCompras_AfterCheck);
        }

        private void treeViewReservas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewReservas.AfterCheck -= new TreeViewEventHandler(treeViewReservas_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewReservas.AfterCheck += new TreeViewEventHandler(treeViewReservas_AfterCheck);
        }

        private void treeViewCaja_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewCaja.AfterCheck -= new TreeViewEventHandler(treeViewCaja_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewCaja.AfterCheck += new TreeViewEventHandler(treeViewCaja_AfterCheck);
        }

        private void treeViewConsulta_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewConsulta.AfterCheck -= new TreeViewEventHandler(treeViewConsulta_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewConsulta.AfterCheck += new TreeViewEventHandler(treeViewConsulta_AfterCheck);
        }

        private void treeViewReportes_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewReportes.AfterCheck -= new TreeViewEventHandler(treeViewReportes_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewReportes.AfterCheck += new TreeViewEventHandler(treeViewReportes_AfterCheck);
        }
        private void treeViewConsumo_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewConsumo.AfterCheck -= new TreeViewEventHandler(treeViewConsumo_AfterCheck);
            CheckChildNode(e.Node);
            CheckParentNode(e.Node);
            treeViewConsumo.AfterCheck += new TreeViewEventHandler(treeViewConsumo_AfterCheck);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((treeViewMantenimientos.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewMantenimientos.Nodes[0]);

            if ((treeViewCompras.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewCompras.Nodes[0]);

            if ((treeViewReservas.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewReservas.Nodes[0]);

            if ((treeViewCaja.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewCaja.Nodes[0]);

            if ((treeViewConsumo.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewConsumo.Nodes[0]);

            if ((treeViewConsulta.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewConsulta.Nodes[0]);

            if ((treeViewReportes.Nodes[0].Checked == true))
                cadenapermisos += "1";
            else
                cadenapermisos += "0";
            RecorrerNodos(treeViewReportes.Nodes[0]);
            
            oRolN = new RolNegocio();

            oRolN.ActualizarPermisos(_id_rol, cadenapermisos);
            MessageBox.Show("Permisos de " + oRol.nombre_rol + " asignados correctamente.", ".::. Sistema Hotelero .::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cadenapermisos = "";
            this.Close();
        }

        private void FrmPermisos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void FrmPermisos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


    }

}
