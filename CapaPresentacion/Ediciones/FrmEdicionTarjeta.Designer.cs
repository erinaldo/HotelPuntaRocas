namespace CapaPresentacion.Ediciones
{
    partial class FrmEdicionTarjeta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdicionTarjeta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fDataGridView1 = new Controles_Standar.FDataGridView();
            this.idliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaEmisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huespedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonSocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoComprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ntarjeta_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativo_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paListaComprobantesTarjetaResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.dtpFinal = new Controles_Standar.FDateTimePicker();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.dtpInicio = new Controles_Standar.FDateTimePicker();
            this.btnLimpiar = new Controles_Standar.FButtonLimpiar();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnEditar = new Controles_Standar.FButtonEditar();
            this.lblTotalTarjetas = new Controles_Standar.FLabelMedium();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaComprobantesTarjetaResultBindingSource)).BeginInit();
            this.fGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fDataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(20, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 305);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // fDataGridView1
            // 
            this.fDataGridView1.AllowUserToAddRows = false;
            this.fDataGridView1.AllowUserToDeleteRows = false;
            this.fDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.fDataGridView1.AutoGenerateColumns = false;
            this.fDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.fDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.fDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.fDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.fDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idliquidacionDataGridViewTextBoxColumn,
            this.fechaEmisionDataGridViewTextBoxColumn,
            this.huespedDataGridViewTextBoxColumn,
            this.razonSocialDataGridViewTextBoxColumn,
            this.tipoComprobanteDataGridViewTextBoxColumn,
            this.ntarjeta_liquidacion,
            this.referencia_liquidacion,
            this.totalliquidacionDataGridViewTextBoxColumn,
            this.serie_liquidacion,
            this.correlativo_liquidacion});
            this.fDataGridView1.DataSource = this.paListaComprobantesTarjetaResultBindingSource;
            this.fDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fDataGridView1.EnableHeadersVisualStyles = false;
            this.fDataGridView1.Location = new System.Drawing.Point(3, 16);
            this.fDataGridView1.MultiSelect = false;
            this.fDataGridView1.Name = "fDataGridView1";
            this.fDataGridView1.ReadOnly = true;
            this.fDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.fDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.fDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fDataGridView1.Size = new System.Drawing.Size(1142, 286);
            this.fDataGridView1.TabIndex = 0;
            this.fDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fDataGridView1_CellDoubleClick);
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
            this.tipoComprobanteDataGridViewTextBoxColumn.HeaderText = "HABITACION";
            this.tipoComprobanteDataGridViewTextBoxColumn.Name = "tipoComprobanteDataGridViewTextBoxColumn";
            this.tipoComprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoComprobanteDataGridViewTextBoxColumn.Width = 103;
            // 
            // ntarjeta_liquidacion
            // 
            this.ntarjeta_liquidacion.DataPropertyName = "ntarjeta_liquidacion";
            this.ntarjeta_liquidacion.HeaderText = "TARJETA";
            this.ntarjeta_liquidacion.Name = "ntarjeta_liquidacion";
            this.ntarjeta_liquidacion.ReadOnly = true;
            this.ntarjeta_liquidacion.Width = 78;
            // 
            // referencia_liquidacion
            // 
            this.referencia_liquidacion.DataPropertyName = "referencia_liquidacion";
            this.referencia_liquidacion.HeaderText = "REFERENCIA";
            this.referencia_liquidacion.Name = "referencia_liquidacion";
            this.referencia_liquidacion.ReadOnly = true;
            this.referencia_liquidacion.Width = 101;
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
            // paListaComprobantesTarjetaResultBindingSource
            // 
            this.paListaComprobantesTarjetaResultBindingSource.AllowNew = true;
            this.paListaComprobantesTarjetaResultBindingSource.DataSource = typeof(CapaEntidades.pa_ListaComprobantesTarjetas_Result);
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.fLabelMedium2);
            this.fGroupBox4.Controls.Add(this.dtpFinal);
            this.fGroupBox4.Controls.Add(this.fLabelMedium1);
            this.fGroupBox4.Controls.Add(this.dtpInicio);
            this.fGroupBox4.Controls.Add(this.btnLimpiar);
            this.fGroupBox4.Controls.Add(this.btnBuscar);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(20, 53);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(548, 81);
            this.fGroupBox4.TabIndex = 9;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Búsqueda Comprobante";
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(166, 21);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(83, 21);
            this.fLabelMedium2.TabIndex = 13;
            this.fLabelMedium2.Text = "Fecha Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(170, 49);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(128, 23);
            this.dtpFinal.TabIndex = 12;
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(16, 21);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(88, 21);
            this.fLabelMedium1.TabIndex = 9;
            this.fLabelMedium1.Text = "Fecha Inicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(20, 49);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(128, 23);
            this.dtpInicio.TabIndex = 8;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(434, 38);
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
            this.btnBuscar.Location = new System.Drawing.Point(338, 38);
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
            this.fLabelBig1.Size = new System.Drawing.Size(452, 41);
            this.fLabelBig1.TabIndex = 2;
            this.fLabelBig1.Text = "Edición de Comprobantes - Tarjeta";
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(1078, 453);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 34);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblTotalTarjetas
            // 
            this.lblTotalTarjetas.AutoSize = true;
            this.lblTotalTarjetas.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTarjetas.ForeColor = System.Drawing.Color.Black;
            this.lblTotalTarjetas.Location = new System.Drawing.Point(19, 453);
            this.lblTotalTarjetas.Name = "lblTotalTarjetas";
            this.lblTotalTarjetas.Size = new System.Drawing.Size(44, 21);
            this.lblTotalTarjetas.TabIndex = 11;
            this.lblTotalTarjetas.Text = "Total:";
            // 
            // FrmEdicionTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1193, 499);
            this.Controls.Add(this.lblTotalTarjetas);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmEdicionTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAnularComprobante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAnularConsumo_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaComprobantesTarjetaResultBindingSource)).EndInit();
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
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FDateTimePicker dtpInicio;
        private System.Windows.Forms.BindingSource paListaComprobantesTarjetaResultBindingSource;
        private Controles_Standar.FButtonEditar btnEditar;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FDateTimePicker dtpFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaEmisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn huespedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonSocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoComprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ntarjeta_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativo_liquidacion;
        private Controles_Standar.FLabelMedium lblTotalTarjetas;
    }
}