namespace CapaPresentacion.Ediciones
{
    partial class FrmFacturasEmitidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturasEmitidas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fDataGridView1 = new Controles_Standar.FDataGridView();
            this.idliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEmisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huespedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapagoliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativo_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ntarjeta_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paListaComprobantesLiquidacionResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.dtpFinal = new Controles_Standar.FDateTimePicker();
            this.rbtComprobante = new Controles_Standar.FRadioButton();
            this.rbtFecha = new Controles_Standar.FRadioButton();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.dtpInicio = new Controles_Standar.FDateTimePicker();
            this.txtBusqueda = new Controles_Standar.FTextBox();
            this.lblBuscar = new Controles_Standar.FLabelMedium();
            this.btnLimpiar = new Controles_Standar.FButtonLimpiar();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.rbtFactura = new Controles_Standar.FRadioButton();
            this.rbtBoleta = new Controles_Standar.FRadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaComprobantesLiquidacionResultBindingSource)).BeginInit();
            this.fGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fDataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(20, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 348);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // fDataGridView1
            // 
            this.fDataGridView1.AllowUserToAddRows = false;
            this.fDataGridView1.AllowUserToDeleteRows = false;
            this.fDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.fDataGridView1.AutoGenerateColumns = false;
            this.fDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.fDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.fDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.fDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.fDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idliquidacionDataGridViewTextBoxColumn,
            this.fechaEmisionDataGridViewTextBoxColumn,
            this.huespedDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.tipoComprobanteDataGridViewTextBoxColumn,
            this.nComprobanteDataGridViewTextBoxColumn,
            this.formapagoliquidacionDataGridViewTextBoxColumn,
            this.totalliquidacionDataGridViewTextBoxColumn,
            this.serie_liquidacion,
            this.correlativo_liquidacion,
            this.referencia_liquidacion,
            this.ntarjeta_liquidacion});
            this.fDataGridView1.DataSource = this.paListaComprobantesLiquidacionResultBindingSource;
            this.fDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fDataGridView1.EnableHeadersVisualStyles = false;
            this.fDataGridView1.Location = new System.Drawing.Point(3, 16);
            this.fDataGridView1.MultiSelect = false;
            this.fDataGridView1.Name = "fDataGridView1";
            this.fDataGridView1.ReadOnly = true;
            this.fDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.fDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.fDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fDataGridView1.Size = new System.Drawing.Size(1142, 329);
            this.fDataGridView1.TabIndex = 0;
            // 
            // idliquidacionDataGridViewTextBoxColumn
            // 
            this.idliquidacionDataGridViewTextBoxColumn.DataPropertyName = "id_liquidacion";
            this.idliquidacionDataGridViewTextBoxColumn.HeaderText = "id_liquidacion";
            this.idliquidacionDataGridViewTextBoxColumn.Name = "idliquidacionDataGridViewTextBoxColumn";
            this.idliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idliquidacionDataGridViewTextBoxColumn.Visible = false;
            this.idliquidacionDataGridViewTextBoxColumn.Width = 87;
            // 
            // fechaEmisionDataGridViewTextBoxColumn
            // 
            this.fechaEmisionDataGridViewTextBoxColumn.DataPropertyName = "FechaEmision";
            this.fechaEmisionDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechaEmisionDataGridViewTextBoxColumn.Name = "fechaEmisionDataGridViewTextBoxColumn";
            this.fechaEmisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaEmisionDataGridViewTextBoxColumn.Width = 70;
            // 
            // huespedDataGridViewTextBoxColumn
            // 
            this.huespedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.huespedDataGridViewTextBoxColumn.DataPropertyName = "Huesped";
            this.huespedDataGridViewTextBoxColumn.HeaderText = "HUESPED";
            this.huespedDataGridViewTextBoxColumn.Name = "huespedDataGridViewTextBoxColumn";
            this.huespedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // razonSocialDataGridViewTextBoxColumn
            // 
            this.razonSocialDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.razonSocialDataGridViewTextBoxColumn.DataPropertyName = "RazonSocial";
            this.razonSocialDataGridViewTextBoxColumn.HeaderText = "RAZON SOCIAL";
            this.razonSocialDataGridViewTextBoxColumn.Name = "razonSocialDataGridViewTextBoxColumn";
            this.razonSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoComprobanteDataGridViewTextBoxColumn
            // 
            this.tipoComprobanteDataGridViewTextBoxColumn.DataPropertyName = "TipoComprobante";
            this.tipoComprobanteDataGridViewTextBoxColumn.HeaderText = "TIPO COMPROBANTE";
            this.tipoComprobanteDataGridViewTextBoxColumn.Name = "tipoComprobanteDataGridViewTextBoxColumn";
            this.tipoComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoComprobanteDataGridViewTextBoxColumn.Width = 154;
            // 
            // nComprobanteDataGridViewTextBoxColumn
            // 
            this.nComprobanteDataGridViewTextBoxColumn.DataPropertyName = "NComprobante";
            this.nComprobanteDataGridViewTextBoxColumn.HeaderText = "N° COMPROBANTE";
            this.nComprobanteDataGridViewTextBoxColumn.Name = "nComprobanteDataGridViewTextBoxColumn";
            this.nComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nComprobanteDataGridViewTextBoxColumn.Width = 141;
            // 
            // formapagoliquidacionDataGridViewTextBoxColumn
            // 
            this.formapagoliquidacionDataGridViewTextBoxColumn.DataPropertyName = "forma_pago_liquidacion";
            this.formapagoliquidacionDataGridViewTextBoxColumn.HeaderText = "TIPO PAGO";
            this.formapagoliquidacionDataGridViewTextBoxColumn.Name = "formapagoliquidacionDataGridViewTextBoxColumn";
            this.formapagoliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.formapagoliquidacionDataGridViewTextBoxColumn.Width = 95;
            // 
            // totalliquidacionDataGridViewTextBoxColumn
            // 
            this.totalliquidacionDataGridViewTextBoxColumn.DataPropertyName = "total_liquidacion";
            this.totalliquidacionDataGridViewTextBoxColumn.HeaderText = "TOTAL";
            this.totalliquidacionDataGridViewTextBoxColumn.Name = "totalliquidacionDataGridViewTextBoxColumn";
            this.totalliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalliquidacionDataGridViewTextBoxColumn.Width = 67;
            // 
            // serie_liquidacion
            // 
            this.serie_liquidacion.DataPropertyName = "serie_liquidacion";
            this.serie_liquidacion.HeaderText = "serie_liquidacion";
            this.serie_liquidacion.Name = "serie_liquidacion";
            this.serie_liquidacion.ReadOnly = true;
            this.serie_liquidacion.Visible = false;
            this.serie_liquidacion.Width = 122;
            // 
            // correlativo_liquidacion
            // 
            this.correlativo_liquidacion.DataPropertyName = "correlativo_liquidacion";
            this.correlativo_liquidacion.HeaderText = "correlativo_liquidacion";
            this.correlativo_liquidacion.Name = "correlativo_liquidacion";
            this.correlativo_liquidacion.ReadOnly = true;
            this.correlativo_liquidacion.Visible = false;
            this.correlativo_liquidacion.Width = 153;
            // 
            // referencia_liquidacion
            // 
            this.referencia_liquidacion.DataPropertyName = "referencia_liquidacion";
            this.referencia_liquidacion.HeaderText = "referencia_liquidacion";
            this.referencia_liquidacion.Name = "referencia_liquidacion";
            this.referencia_liquidacion.ReadOnly = true;
            this.referencia_liquidacion.Visible = false;
            this.referencia_liquidacion.Width = 151;
            // 
            // ntarjeta_liquidacion
            // 
            this.ntarjeta_liquidacion.DataPropertyName = "ntarjeta_liquidacion";
            this.ntarjeta_liquidacion.HeaderText = "ntarjeta_liquidacion";
            this.ntarjeta_liquidacion.Name = "ntarjeta_liquidacion";
            this.ntarjeta_liquidacion.ReadOnly = true;
            this.ntarjeta_liquidacion.Visible = false;
            this.ntarjeta_liquidacion.Width = 137;
            // 
            // paListaComprobantesLiquidacionResultBindingSource
            // 
            this.paListaComprobantesLiquidacionResultBindingSource.AllowNew = true;
            this.paListaComprobantesLiquidacionResultBindingSource.DataSource = typeof(CapaEntidades.pa_ListaComprobantesLiquidacion_Result);
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.fLabelMedium2);
            this.fGroupBox4.Controls.Add(this.dtpFinal);
            this.fGroupBox4.Controls.Add(this.rbtComprobante);
            this.fGroupBox4.Controls.Add(this.rbtFecha);
            this.fGroupBox4.Controls.Add(this.fLabelMedium1);
            this.fGroupBox4.Controls.Add(this.dtpInicio);
            this.fGroupBox4.Controls.Add(this.txtBusqueda);
            this.fGroupBox4.Controls.Add(this.lblBuscar);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(20, 53);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(915, 81);
            this.fGroupBox4.TabIndex = 9;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Búsqueda Comprobante";
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(607, 20);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(83, 21);
            this.fLabelMedium2.TabIndex = 13;
            this.fLabelMedium2.Text = "Fecha Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(611, 48);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(128, 23);
            this.dtpFinal.TabIndex = 12;
            // 
            // rbtComprobante
            // 
            this.rbtComprobante.AutoSize = true;
            this.rbtComprobante.BackColor = System.Drawing.Color.Transparent;
            this.rbtComprobante.Checked = true;
            this.rbtComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtComprobante.Location = new System.Drawing.Point(19, 27);
            this.rbtComprobante.Name = "rbtComprobante";
            this.rbtComprobante.Size = new System.Drawing.Size(70, 19);
            this.rbtComprobante.TabIndex = 10;
            this.rbtComprobante.TabStop = true;
            this.rbtComprobante.Text = "Huesped";
            this.rbtComprobante.UseVisualStyleBackColor = false;
            this.rbtComprobante.CheckedChanged += new System.EventHandler(this.rbtComprobante_CheckedChanged);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.BackColor = System.Drawing.Color.Transparent;
            this.rbtFecha.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFecha.Location = new System.Drawing.Point(19, 48);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(69, 19);
            this.rbtFecha.TabIndex = 11;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "Empresa";
            this.rbtFecha.UseVisualStyleBackColor = false;
            this.rbtFecha.CheckedChanged += new System.EventHandler(this.rbtFecha_CheckedChanged);
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(457, 20);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(88, 21);
            this.fLabelMedium1.TabIndex = 9;
            this.fLabelMedium1.Text = "Fecha Inicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(461, 48);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(128, 23);
            this.dtpInicio.TabIndex = 8;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(141, 48);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(297, 23);
            this.txtBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.Black;
            this.lblBuscar.Location = new System.Drawing.Point(137, 24);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(144, 21);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Huesped o Empresa";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(1071, 98);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 34);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(975, 98);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 34);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(453, 41);
            this.fLabelBig1.TabIndex = 2;
            this.fLabelBig1.Text = "Búsqueda Comprobantes Emitidos";
            // 
            // rbtFactura
            // 
            this.rbtFactura.AutoSize = true;
            this.rbtFactura.BackColor = System.Drawing.Color.Transparent;
            this.rbtFactura.Checked = true;
            this.rbtFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFactura.Location = new System.Drawing.Point(1016, 68);
            this.rbtFactura.Name = "rbtFactura";
            this.rbtFactura.Size = new System.Drawing.Size(74, 19);
            this.rbtFactura.TabIndex = 16;
            this.rbtFactura.TabStop = true;
            this.rbtFactura.Text = "FACTURA";
            this.rbtFactura.UseVisualStyleBackColor = false;
            // 
            // rbtBoleta
            // 
            this.rbtBoleta.AutoSize = true;
            this.rbtBoleta.BackColor = System.Drawing.Color.Transparent;
            this.rbtBoleta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtBoleta.Location = new System.Drawing.Point(1096, 67);
            this.rbtBoleta.Name = "rbtBoleta";
            this.rbtBoleta.Size = new System.Drawing.Size(65, 19);
            this.rbtBoleta.TabIndex = 17;
            this.rbtBoleta.TabStop = true;
            this.rbtBoleta.Text = "BOLETA";
            this.rbtBoleta.UseVisualStyleBackColor = false;
            // 
            // FrmFacturasEmitidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1193, 499);
            this.Controls.Add(this.rbtFactura);
            this.Controls.Add(this.rbtBoleta);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmFacturasEmitidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAnularComprobante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAnularConsumo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaComprobantesLiquidacionResultBindingSource)).EndInit();
            this.fGroupBox4.ResumeLayout(false);
            this.fGroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FDataGridView fDataGridView1;
        private Controles_Standar.FGroupBox fGroupBox4;
        private Controles_Standar.FButtonLimpiar btnLimpiar;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FTextBox txtBusqueda;
        private Controles_Standar.FLabelMedium lblBuscar;
        private Controles_Standar.FRadioButton rbtComprobante;
        private Controles_Standar.FRadioButton rbtFecha;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FDateTimePicker dtpInicio;
        private System.Windows.Forms.BindingSource paListaComprobantesLiquidacionResultBindingSource;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FDateTimePicker dtpFinal;
        private Controles_Standar.FRadioButton rbtFactura;
        private Controles_Standar.FRadioButton rbtBoleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEmisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn huespedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapagoliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativo_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ntarjeta_liquidacion;
    }
}