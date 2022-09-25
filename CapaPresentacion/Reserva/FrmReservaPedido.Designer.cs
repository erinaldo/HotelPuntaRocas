namespace CapaPresentacion.Reserva
{
    partial class FrmReservaPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReservaPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.dgvPedidoReserva = new Controles_Standar.FDataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreproductoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioserviciohabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaserviciohabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaPedidoListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.txtBusqueda = new Controles_Standar.FTextBox();
            this.dgvListaProductos = new Controles_Standar.FDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreproductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioproductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockproductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaProductoListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnQuitarP = new System.Windows.Forms.Button();
            this.btnAgregarP = new System.Windows.Forms.Button();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pagarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoReserva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaPedidoListBindingSource)).BeginInit();
            this.fGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaProductoListBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(615, 374);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(93, 21);
            this.fLabelMedium2.TabIndex = 6;
            this.fLabelMedium2.Text = "Monto Total:";
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(430, 374);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(117, 21);
            this.fLabelMedium1.TabIndex = 5;
            this.fLabelMedium1.Text = "Total de Pedidos";
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.dgvPedidoReserva);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(434, 58);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(639, 302);
            this.fGroupBox1.TabIndex = 2;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Pedido Realizado";
            // 
            // dgvPedidoReserva
            // 
            this.dgvPedidoReserva.AllowUserToAddRows = false;
            this.dgvPedidoReserva.AllowUserToDeleteRows = false;
            this.dgvPedidoReserva.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPedidoReserva.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPedidoReserva.AutoGenerateColumns = false;
            this.dgvPedidoReserva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPedidoReserva.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPedidoReserva.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvPedidoReserva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPedidoReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoReserva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.id_producto,
            this.nombreproductoDataGridViewTextBoxColumn1,
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn,
            this.precioserviciohabitacionDataGridViewTextBoxColumn,
            this.fechaserviciohabitacionDataGridViewTextBoxColumn,
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn});
            this.dgvPedidoReserva.DataSource = this.vistaPedidoListBindingSource;
            this.dgvPedidoReserva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPedidoReserva.EnableHeadersVisualStyles = false;
            this.dgvPedidoReserva.Location = new System.Drawing.Point(3, 19);
            this.dgvPedidoReserva.MultiSelect = false;
            this.dgvPedidoReserva.Name = "dgvPedidoReserva";
            this.dgvPedidoReserva.ReadOnly = true;
            this.dgvPedidoReserva.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPedidoReserva.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPedidoReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoReserva.Size = new System.Drawing.Size(633, 280);
            this.dgvPedidoReserva.TabIndex = 0;
            this.dgvPedidoReserva.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidoReserva_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Visible = false;
            this.idDataGridViewTextBoxColumn1.Width = 21;
            // 
            // id_producto
            // 
            this.id_producto.DataPropertyName = "id_producto";
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            this.id_producto.Width = 73;
            // 
            // nombreproductoDataGridViewTextBoxColumn1
            // 
            this.nombreproductoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreproductoDataGridViewTextBoxColumn1.DataPropertyName = "nombre_producto";
            this.nombreproductoDataGridViewTextBoxColumn1.HeaderText = "PRODUCTO";
            this.nombreproductoDataGridViewTextBoxColumn1.Name = "nombreproductoDataGridViewTextBoxColumn1";
            this.nombreproductoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadserviciohabitacionDataGridViewTextBoxColumn
            // 
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn.DataPropertyName = "cantidad_servicio_habitacion";
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn.HeaderText = "CANTIDAD";
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn.Name = "cantidadserviciohabitacionDataGridViewTextBoxColumn";
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadserviciohabitacionDataGridViewTextBoxColumn.Width = 88;
            // 
            // precioserviciohabitacionDataGridViewTextBoxColumn
            // 
            this.precioserviciohabitacionDataGridViewTextBoxColumn.DataPropertyName = "precio_servicio_habitacion";
            this.precioserviciohabitacionDataGridViewTextBoxColumn.HeaderText = "PRECIO";
            this.precioserviciohabitacionDataGridViewTextBoxColumn.Name = "precioserviciohabitacionDataGridViewTextBoxColumn";
            this.precioserviciohabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioserviciohabitacionDataGridViewTextBoxColumn.Width = 70;
            // 
            // fechaserviciohabitacionDataGridViewTextBoxColumn
            // 
            this.fechaserviciohabitacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_servicio_habitacion";
            this.fechaserviciohabitacionDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechaserviciohabitacionDataGridViewTextBoxColumn.Name = "fechaserviciohabitacionDataGridViewTextBoxColumn";
            this.fechaserviciohabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaserviciohabitacionDataGridViewTextBoxColumn.Width = 66;
            // 
            // fechapagoserviciohabitacionDataGridViewTextBoxColumn
            // 
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_pago_servicio_habitacion";
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn.HeaderText = "FECHA PAGO";
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn.Name = "fechapagoserviciohabitacionDataGridViewTextBoxColumn";
            this.fechapagoserviciohabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vistaPedidoListBindingSource
            // 
            this.vistaPedidoListBindingSource.DataSource = typeof(CapaEntidades.vistaPedidoList);
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.btnBuscar);
            this.fGroupBox3.Controls.Add(this.txtBusqueda);
            this.fGroupBox3.Controls.Add(this.dgvListaProductos);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(19, 58);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(338, 302);
            this.fGroupBox3.TabIndex = 1;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Lista de Productos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(299, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 34);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(6, 22);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(287, 23);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dgvListaProductos
            // 
            this.dgvListaProductos.AllowUserToAddRows = false;
            this.dgvListaProductos.AllowUserToDeleteRows = false;
            this.dgvListaProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvListaProductos.AutoGenerateColumns = false;
            this.dgvListaProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvListaProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreproductoDataGridViewTextBoxColumn,
            this.precioproductoDataGridViewTextBoxColumn,
            this.stockproductoDataGridViewTextBoxColumn});
            this.dgvListaProductos.DataSource = this.vistaProductoListBindingSource;
            this.dgvListaProductos.EnableHeadersVisualStyles = false;
            this.dgvListaProductos.Location = new System.Drawing.Point(6, 59);
            this.dgvListaProductos.MultiSelect = false;
            this.dgvListaProductos.Name = "dgvListaProductos";
            this.dgvListaProductos.ReadOnly = true;
            this.dgvListaProductos.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListaProductos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaProductos.Size = new System.Drawing.Size(326, 237);
            this.dgvListaProductos.TabIndex = 2;
            this.dgvListaProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaProductos_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 21;
            // 
            // nombreproductoDataGridViewTextBoxColumn
            // 
            this.nombreproductoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreproductoDataGridViewTextBoxColumn.DataPropertyName = "nombre_producto";
            this.nombreproductoDataGridViewTextBoxColumn.HeaderText = "PRODUCTO";
            this.nombreproductoDataGridViewTextBoxColumn.Name = "nombreproductoDataGridViewTextBoxColumn";
            this.nombreproductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioproductoDataGridViewTextBoxColumn
            // 
            this.precioproductoDataGridViewTextBoxColumn.DataPropertyName = "precio_producto";
            this.precioproductoDataGridViewTextBoxColumn.HeaderText = "PRECIO";
            this.precioproductoDataGridViewTextBoxColumn.Name = "precioproductoDataGridViewTextBoxColumn";
            this.precioproductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioproductoDataGridViewTextBoxColumn.Width = 70;
            // 
            // stockproductoDataGridViewTextBoxColumn
            // 
            this.stockproductoDataGridViewTextBoxColumn.DataPropertyName = "stock_producto";
            this.stockproductoDataGridViewTextBoxColumn.HeaderText = "STOCK";
            this.stockproductoDataGridViewTextBoxColumn.Name = "stockproductoDataGridViewTextBoxColumn";
            this.stockproductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockproductoDataGridViewTextBoxColumn.Width = 64;
            // 
            // vistaProductoListBindingSource
            // 
            this.vistaProductoListBindingSource.DataSource = typeof(CapaEntidades.vistaProductoList);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(266, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Registro de Pedidos";
            // 
            // btnQuitarP
            // 
            this.btnQuitarP.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnQuitarP.Image = global::CapaPresentacion.Properties.Resources.checkOut;
            this.btnQuitarP.Location = new System.Drawing.Point(371, 224);
            this.btnQuitarP.Name = "btnQuitarP";
            this.btnQuitarP.Size = new System.Drawing.Size(53, 34);
            this.btnQuitarP.TabIndex = 4;
            this.btnQuitarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnQuitarP.UseVisualStyleBackColor = true;
            this.btnQuitarP.Click += new System.EventHandler(this.btnQuitarP_Click);
            // 
            // btnAgregarP
            // 
            this.btnAgregarP.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnAgregarP.Image = global::CapaPresentacion.Properties.Resources.checkIn;
            this.btnAgregarP.Location = new System.Drawing.Point(371, 157);
            this.btnAgregarP.Name = "btnAgregarP";
            this.btnAgregarP.Size = new System.Drawing.Size(53, 34);
            this.btnAgregarP.TabIndex = 3;
            this.btnAgregarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregarP.UseVisualStyleBackColor = true;
            this.btnAgregarP.Click += new System.EventHandler(this.btnAgregarP_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(980, 369);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagarProductoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // pagarProductoToolStripMenuItem
            // 
            this.pagarProductoToolStripMenuItem.Name = "pagarProductoToolStripMenuItem";
            this.pagarProductoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pagarProductoToolStripMenuItem.Text = "Pagar Producto";
            this.pagarProductoToolStripMenuItem.Click += new System.EventHandler(this.pagarProductoToolStripMenuItem_Click);
            // 
            // FrmReservaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1105, 417);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.fLabelMedium2);
            this.Controls.Add(this.fLabelMedium1);
            this.Controls.Add(this.btnQuitarP);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.btnAgregarP);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReservaPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Generar Pedido .::.";
            this.Load += new System.EventHandler(this.FrmReservacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReservaPedido_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoReserva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaPedidoListBindingSource)).EndInit();
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaProductoListBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox3;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FDataGridView dgvListaProductos;
        private System.Windows.Forms.Button btnAgregarP;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FDataGridView dgvPedidoReserva;
        private System.Windows.Forms.Button btnQuitarP;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreproductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioproductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockproductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vistaProductoListBindingSource;
        private System.Windows.Forms.BindingSource vistaPedidoListBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pagarProductoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreproductoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadserviciohabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioserviciohabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaserviciohabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapagoserviciohabitacionDataGridViewTextBoxColumn;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FTextBox txtBusqueda;
    }
}