namespace CapaPresentacion.Compra
{
    partial class FrmCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.lblCantidadProducto = new System.Windows.Forms.ToolStripLabel();
            this.lblProducto = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.lblSub = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.lblIGV = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripLabel();
            this.fGroupBox7 = new Controles_Standar.FGroupBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.fGroupBox5 = new Controles_Standar.FGroupBox();
            this.rbCredito = new Controles_Standar.FRadioButton();
            this.rbContado = new Controles_Standar.FRadioButton();
            this.fGroupBox6 = new Controles_Standar.FGroupBox();
            this.btnLimpiar = new Controles_Standar.FButtonEliminar();
            this.btnAgregar = new Controles_Standar.FButtonNuevo();
            this.btnQuitar = new Controles_Standar.FButtonEditar();
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.dgvArticulo = new Controles_Standar.FDataGridView();
            this.ID_PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.txtDireccion = new Controles_Standar.FTextBoxRequerido();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.txtRznSocial = new Controles_Standar.FTextBoxRequerido();
            this.txtRuc = new Controles_Standar.FTextBoxIntRequerido();
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.txtCorrelativo = new Controles_Standar.FTextBoxRequerido();
            this.txtSerie = new Controles_Standar.FTextBoxRequerido();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.rbOtro = new Controles_Standar.FRadioButton();
            this.rbBoleta = new Controles_Standar.FRadioButton();
            this.rbFactura = new Controles_Standar.FRadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.fGroupBox7.SuspendLayout();
            this.fGroupBox5.SuspendLayout();
            this.fGroupBox6.SuspendLayout();
            this.fGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).BeginInit();
            this.fGroupBox3.SuspendLayout();
            this.fGroupBox2.SuspendLayout();
            this.fGroupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 55);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 22F);
            this.label1.Location = new System.Drawing.Point(29, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Compra";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.White;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCantidadProducto,
            this.lblProducto,
            this.toolStripLabel5,
            this.lblSub,
            this.toolStripLabel6,
            this.lblIGV,
            this.toolStripLabel8,
            this.lblTotal});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip3.Location = new System.Drawing.Point(24, 419);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(524, 35);
            this.toolStrip3.TabIndex = 8;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // lblCantidadProducto
            // 
            this.lblCantidadProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCantidadProducto.Name = "lblCantidadProducto";
            this.lblCantidadProducto.Size = new System.Drawing.Size(147, 32);
            this.lblCantidadProducto.Text = "Número de Productos:";
            // 
            // lblProducto
            // 
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(27, 32);
            this.lblProducto.Text = "0";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel5.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(67, 32);
            this.toolStripLabel5.Text = "Subtotal: ";
            // 
            // lblSub
            // 
            this.lblSub.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(56, 32);
            this.lblSub.Text = "0.00";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel6.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(39, 32);
            this.toolStripLabel6.Text = "IGV: ";
            // 
            // lblIGV
            // 
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(56, 32);
            this.lblIGV.Text = "0.00";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel8.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(45, 32);
            this.toolStripLabel8.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 18F);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 32);
            this.lblTotal.Text = "0.00";
            // 
            // fGroupBox7
            // 
            this.fGroupBox7.Controls.Add(this.dtpFecha);
            this.fGroupBox7.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox7.Location = new System.Drawing.Point(616, 58);
            this.fGroupBox7.Name = "fGroupBox7";
            this.fGroupBox7.Size = new System.Drawing.Size(230, 51);
            this.fGroupBox7.TabIndex = 4;
            this.fGroupBox7.TabStop = false;
            this.fGroupBox7.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(9, 19);
            this.dtpFecha.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(208, 23);
            this.dtpFecha.TabIndex = 0;
            // 
            // fGroupBox5
            // 
            this.fGroupBox5.Controls.Add(this.rbCredito);
            this.fGroupBox5.Controls.Add(this.rbContado);
            this.fGroupBox5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox5.Location = new System.Drawing.Point(448, 58);
            this.fGroupBox5.Name = "fGroupBox5";
            this.fGroupBox5.Size = new System.Drawing.Size(160, 51);
            this.fGroupBox5.TabIndex = 3;
            this.fGroupBox5.TabStop = false;
            this.fGroupBox5.Text = "Tipo de pago";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.BackColor = System.Drawing.Color.Transparent;
            this.rbCredito.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredito.Location = new System.Drawing.Point(92, 20);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(62, 19);
            this.rbCredito.TabIndex = 1;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = false;
            // 
            // rbContado
            // 
            this.rbContado.AutoSize = true;
            this.rbContado.BackColor = System.Drawing.Color.Transparent;
            this.rbContado.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContado.Location = new System.Drawing.Point(16, 20);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(69, 19);
            this.rbContado.TabIndex = 0;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "Contado";
            this.rbContado.UseVisualStyleBackColor = false;
            // 
            // fGroupBox6
            // 
            this.fGroupBox6.Controls.Add(this.btnLimpiar);
            this.fGroupBox6.Controls.Add(this.btnAgregar);
            this.fGroupBox6.Controls.Add(this.btnQuitar);
            this.fGroupBox6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox6.Location = new System.Drawing.Point(18, 112);
            this.fGroupBox6.Name = "fGroupBox6";
            this.fGroupBox6.Size = new System.Drawing.Size(180, 51);
            this.fGroupBox6.TabIndex = 5;
            this.fGroupBox6.TabStop = false;
            this.fGroupBox6.Text = "Acciones de la Compra";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(123, 16);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 30);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(18, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 30);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.Location = new System.Drawing.Point(72, 16);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(40, 30);
            this.btnQuitar.TabIndex = 1;
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.btnCancelar);
            this.fGroupBox4.Controls.Add(this.btnGuardar);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(599, 403);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(247, 57);
            this.fGroupBox4.TabIndex = 9;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Acciones del Formulario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(151, 16);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(55, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvArticulo
            // 
            this.dgvArticulo.AllowUserToAddRows = false;
            this.dgvArticulo.AllowUserToDeleteRows = false;
            this.dgvArticulo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvArticulo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArticulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArticulo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvArticulo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvArticulo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_PRODUCTO,
            this.PRODUCTO,
            this.CANTIDAD,
            this.COSTO,
            this.TOTAL});
            this.dgvArticulo.EnableHeadersVisualStyles = false;
            this.dgvArticulo.Location = new System.Drawing.Point(18, 179);
            this.dgvArticulo.MultiSelect = false;
            this.dgvArticulo.Name = "dgvArticulo";
            this.dgvArticulo.ReadOnly = true;
            this.dgvArticulo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvArticulo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulo.Size = new System.Drawing.Size(828, 216);
            this.dgvArticulo.TabIndex = 7;
            this.dgvArticulo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulo_CellEndEdit);
            this.dgvArticulo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulo_CellValueChanged);
            this.dgvArticulo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvArticulo_EditingControlShowing);
            this.dgvArticulo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvArticulo_RowsAdded);
            this.dgvArticulo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvArticulo_RowsRemoved);
            this.dgvArticulo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvArticulo_KeyUp);
            // 
            // ID_PRODUCTO
            // 
            this.ID_PRODUCTO.HeaderText = "ID_ARTICULO";
            this.ID_PRODUCTO.Name = "ID_PRODUCTO";
            this.ID_PRODUCTO.ReadOnly = true;
            this.ID_PRODUCTO.Visible = false;
            this.ID_PRODUCTO.Width = 86;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRODUCTO.HeaderText = "PRODUCTO";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.HeaderText = "CANTIDAD";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 93;
            // 
            // COSTO
            // 
            this.COSTO.HeaderText = "P. UNITARIO";
            this.COSTO.Name = "COSTO";
            this.COSTO.ReadOnly = true;
            this.COSTO.Width = 97;
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 67;
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.txtDireccion);
            this.fGroupBox3.Controls.Add(this.btnBuscar);
            this.fGroupBox3.Controls.Add(this.txtRznSocial);
            this.fGroupBox3.Controls.Add(this.txtRuc);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(214, 112);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(632, 51);
            this.fGroupBox3.TabIndex = 6;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Proveedor";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(310, 20);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(257, 23);
            this.txtDireccion.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(576, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(43, 34);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtRznSocial
            // 
            this.txtRznSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRznSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRznSocial.Enabled = false;
            this.txtRznSocial.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRznSocial.Location = new System.Drawing.Point(93, 20);
            this.txtRznSocial.Name = "txtRznSocial";
            this.txtRznSocial.Size = new System.Drawing.Size(211, 23);
            this.txtRznSocial.TabIndex = 1;
            // 
            // txtRuc
            // 
            this.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRuc.Enabled = false;
            this.txtRuc.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuc.Location = new System.Drawing.Point(10, 20);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(77, 23);
            this.txtRuc.TabIndex = 0;
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.txtCorrelativo);
            this.fGroupBox2.Controls.Add(this.txtSerie);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(259, 58);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(181, 51);
            this.fGroupBox2.TabIndex = 2;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Comprobante";
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorrelativo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorrelativo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrelativo.Location = new System.Drawing.Point(58, 19);
            this.txtCorrelativo.MaxLength = 9;
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(110, 23);
            this.txtCorrelativo.TabIndex = 1;
            this.txtCorrelativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorrelativo_KeyPress);
            // 
            // txtSerie
            // 
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(13, 19);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(38, 23);
            this.txtSerie.TabIndex = 0;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.rbOtro);
            this.fGroupBox1.Controls.Add(this.rbBoleta);
            this.fGroupBox1.Controls.Add(this.rbFactura);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(18, 58);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(234, 51);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Tipo Comprobante";
            // 
            // rbOtro
            // 
            this.rbOtro.AutoSize = true;
            this.rbOtro.BackColor = System.Drawing.Color.Transparent;
            this.rbOtro.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOtro.Location = new System.Drawing.Point(166, 20);
            this.rbOtro.Name = "rbOtro";
            this.rbOtro.Size = new System.Drawing.Size(54, 19);
            this.rbOtro.TabIndex = 2;
            this.rbOtro.TabStop = true;
            this.rbOtro.Text = "Otros";
            this.rbOtro.UseVisualStyleBackColor = false;
            this.rbOtro.CheckedChanged += new System.EventHandler(this.rbOtro_CheckedChanged);
            // 
            // rbBoleta
            // 
            this.rbBoleta.AutoSize = true;
            this.rbBoleta.BackColor = System.Drawing.Color.Transparent;
            this.rbBoleta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBoleta.Location = new System.Drawing.Point(92, 20);
            this.rbBoleta.Name = "rbBoleta";
            this.rbBoleta.Size = new System.Drawing.Size(57, 19);
            this.rbBoleta.TabIndex = 1;
            this.rbBoleta.TabStop = true;
            this.rbBoleta.Text = "Boleta";
            this.rbBoleta.UseVisualStyleBackColor = false;
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.BackColor = System.Drawing.Color.Transparent;
            this.rbFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFactura.Location = new System.Drawing.Point(16, 20);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(61, 19);
            this.rbFactura.TabIndex = 0;
            this.rbFactura.TabStop = true;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(320, 17);
            this.toolStripStatusLabel1.Text = "F2 : Agregar Produccto  F3 : Quitar Producto   F4 : Limpiar";
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 492);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.fGroupBox7);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.fGroupBox5);
            this.Controls.Add(this.fGroupBox6);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.dgvArticulo);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCompra_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCompra_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.fGroupBox7.ResumeLayout(false);
            this.fGroupBox5.ResumeLayout(false);
            this.fGroupBox5.PerformLayout();
            this.fGroupBox6.ResumeLayout(false);
            this.fGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulo)).EndInit();
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox3.PerformLayout();
            this.fGroupBox2.ResumeLayout(false);
            this.fGroupBox2.PerformLayout();
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FRadioButton rbOtro;
        private Controles_Standar.FRadioButton rbBoleta;
        private Controles_Standar.FRadioButton rbFactura;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FGroupBox fGroupBox3;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FTextBoxRequerido txtRznSocial;
        private Controles_Standar.FTextBoxIntRequerido txtRuc;
        private Controles_Standar.FTextBoxRequerido txtCorrelativo;
        private Controles_Standar.FTextBoxRequerido txtSerie;
        private Controles_Standar.FDataGridView dgvArticulo;
        private Controles_Standar.FGroupBox fGroupBox4;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private System.Windows.Forms.Label label1;
        private Controles_Standar.FButtonEliminar btnLimpiar;
        private Controles_Standar.FButtonEditar btnQuitar;
        private Controles_Standar.FButtonNuevo btnAgregar;
        private Controles_Standar.FGroupBox fGroupBox6;
        private Controles_Standar.FGroupBox fGroupBox5;
        private Controles_Standar.FRadioButton rbCredito;
        private Controles_Standar.FRadioButton rbContado;
        private Controles_Standar.FTextBoxRequerido txtDireccion;
        internal System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel lblSub;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel lblIGV;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripLabel lblTotal;
        private Controles_Standar.FGroupBox fGroupBox7;
        private System.Windows.Forms.ToolStripLabel lblCantidadProducto;
        private System.Windows.Forms.ToolStripLabel lblProducto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
    }
}