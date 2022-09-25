namespace CapaPresentacion.Consulta
{
    partial class FrmUnificarFacturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnificarFacturas));
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.iDGRUPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completohuespedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pISODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCHECKINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCHECKOUTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RESERVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PEDIDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO_A_CUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paUnirFacturaResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paUnirFacturaResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(412, 41);
            this.fLabelBig1.TabIndex = 1;
            this.fLabelBig1.Text = "Listado de Pendientes de cobro";
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnFacturacion.ForeColor = System.Drawing.Color.Black;
            this.btnFacturacion.Image = global::CapaPresentacion.Properties.Resources.facturacion;
            this.btnFacturacion.Location = new System.Drawing.Point(684, 335);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(103, 34);
            this.btnFacturacion.TabIndex = 5;
            this.btnFacturacion.Text = "Facturación";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturacion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(793, 335);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDatos);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeColumns = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDGRUPODataGridViewTextBoxColumn,
            this.completohuespedDataGridViewTextBoxColumn,
            this.dNIDataGridViewTextBoxColumn,
            this.pISODataGridViewTextBoxColumn,
            this.tOTALDataGridViewTextBoxColumn,
            this.fCHECKINDataGridViewTextBoxColumn,
            this.fCHECKOUTDataGridViewTextBoxColumn,
            this.RESERVA,
            this.PEDIDO,
            this.MONTO_A_CUENTA});
            this.dgvDatos.DataSource = this.paUnirFacturaResultBindingSource;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(3, 16);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(873, 237);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // iDGRUPODataGridViewTextBoxColumn
            // 
            this.iDGRUPODataGridViewTextBoxColumn.DataPropertyName = "ID_GRUPO";
            this.iDGRUPODataGridViewTextBoxColumn.HeaderText = "ID_GRUPO";
            this.iDGRUPODataGridViewTextBoxColumn.Name = "iDGRUPODataGridViewTextBoxColumn";
            this.iDGRUPODataGridViewTextBoxColumn.ReadOnly = true;
            this.iDGRUPODataGridViewTextBoxColumn.Visible = false;
            // 
            // completohuespedDataGridViewTextBoxColumn
            // 
            this.completohuespedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.completohuespedDataGridViewTextBoxColumn.DataPropertyName = "completo_huesped";
            this.completohuespedDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.completohuespedDataGridViewTextBoxColumn.Name = "completohuespedDataGridViewTextBoxColumn";
            this.completohuespedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dNIDataGridViewTextBoxColumn
            // 
            this.dNIDataGridViewTextBoxColumn.DataPropertyName = "DNI";
            this.dNIDataGridViewTextBoxColumn.HeaderText = "DNI";
            this.dNIDataGridViewTextBoxColumn.Name = "dNIDataGridViewTextBoxColumn";
            this.dNIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pISODataGridViewTextBoxColumn
            // 
            this.pISODataGridViewTextBoxColumn.DataPropertyName = "PISO";
            this.pISODataGridViewTextBoxColumn.HeaderText = "PISO";
            this.pISODataGridViewTextBoxColumn.Name = "pISODataGridViewTextBoxColumn";
            this.pISODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tOTALDataGridViewTextBoxColumn
            // 
            this.tOTALDataGridViewTextBoxColumn.DataPropertyName = "TOTAL";
            this.tOTALDataGridViewTextBoxColumn.HeaderText = "POR PAGAR";
            this.tOTALDataGridViewTextBoxColumn.Name = "tOTALDataGridViewTextBoxColumn";
            this.tOTALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fCHECKINDataGridViewTextBoxColumn
            // 
            this.fCHECKINDataGridViewTextBoxColumn.DataPropertyName = "F_CHECKIN";
            this.fCHECKINDataGridViewTextBoxColumn.HeaderText = "F_CHECKIN";
            this.fCHECKINDataGridViewTextBoxColumn.Name = "fCHECKINDataGridViewTextBoxColumn";
            this.fCHECKINDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fCHECKOUTDataGridViewTextBoxColumn
            // 
            this.fCHECKOUTDataGridViewTextBoxColumn.DataPropertyName = "F_CHECKOUT";
            this.fCHECKOUTDataGridViewTextBoxColumn.HeaderText = "F_CHECKOUT";
            this.fCHECKOUTDataGridViewTextBoxColumn.Name = "fCHECKOUTDataGridViewTextBoxColumn";
            this.fCHECKOUTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RESERVA
            // 
            this.RESERVA.DataPropertyName = "RESERVA";
            this.RESERVA.HeaderText = "RESERVA";
            this.RESERVA.Name = "RESERVA";
            this.RESERVA.ReadOnly = true;
            this.RESERVA.Visible = false;
            // 
            // PEDIDO
            // 
            this.PEDIDO.DataPropertyName = "PEDIDO";
            this.PEDIDO.HeaderText = "CONSUMO";
            this.PEDIDO.Name = "PEDIDO";
            this.PEDIDO.ReadOnly = true;
            this.PEDIDO.Visible = false;
            // 
            // MONTO_A_CUENTA
            // 
            this.MONTO_A_CUENTA.DataPropertyName = "MONTO_A_CUENTA";
            this.MONTO_A_CUENTA.HeaderText = "MONTO_A_CUENTA";
            this.MONTO_A_CUENTA.Name = "MONTO_A_CUENTA";
            this.MONTO_A_CUENTA.ReadOnly = true;
            this.MONTO_A_CUENTA.Visible = false;
            // 
            // paUnirFacturaResultBindingSource
            // 
            this.paUnirFacturaResultBindingSource.DataSource = typeof(CapaEntidades.pa_UnirFactura_Result);
            // 
            // FrmUnificarFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 380);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFacturacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmUnificarFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUnificarFacturas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUnificarFacturas_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paUnirFacturaResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private System.Windows.Forms.Button btnFacturacion;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.BindingSource paUnirFacturaResultBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDGRUPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completohuespedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pISODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCHECKINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCHECKOUTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RESERVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEDIDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO_A_CUENTA;
    }
}