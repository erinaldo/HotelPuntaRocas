namespace CapaPresentacion.Consulta
{
    partial class FrmAnularComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnularComprobante));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fDataGridView1 = new Controles_Standar.FDataGridView();
            this.idliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriecomprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formapagoliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocomprobanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaLiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAnular = new System.Windows.Forms.Button();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.rbtComprobante = new Controles_Standar.FRadioButton();
            this.rbtFecha = new Controles_Standar.FRadioButton();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.dtpInicio = new Controles_Standar.FDateTimePicker();
            this.btnLimpiar = new Controles_Standar.FButtonLimpiar();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.txtBusqueda = new Controles_Standar.FTextBox();
            this.lblBuscar = new Controles_Standar.FLabelMedium();
            this.btnBajaComprobante = new System.Windows.Forms.Button();
            this.btnEditar = new Controles_Standar.FButtonEditar();
            this.fButtonCancelar1 = new Controles_Standar.FButtonCancelar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaLiquidacionBindingSource)).BeginInit();
            this.fGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fDataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(20, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 305);
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
            this.clienteliquidacionDataGridViewTextBoxColumn,
            this.seriecomprobanteDataGridViewTextBoxColumn,
            this.formapagoliquidacionDataGridViewTextBoxColumn,
            this.tipocomprobanteDataGridViewTextBoxColumn,
            this.fechaliquidacionDataGridViewTextBoxColumn,
            this.totalliquidacionDataGridViewTextBoxColumn});
            this.fDataGridView1.DataSource = this.vistaLiquidacionBindingSource;
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
            this.fDataGridView1.Size = new System.Drawing.Size(804, 286);
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
            // clienteliquidacionDataGridViewTextBoxColumn
            // 
            this.clienteliquidacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clienteliquidacionDataGridViewTextBoxColumn.DataPropertyName = "cliente_liquidacion";
            this.clienteliquidacionDataGridViewTextBoxColumn.HeaderText = "HUESPED";
            this.clienteliquidacionDataGridViewTextBoxColumn.Name = "clienteliquidacionDataGridViewTextBoxColumn";
            this.clienteliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seriecomprobanteDataGridViewTextBoxColumn
            // 
            this.seriecomprobanteDataGridViewTextBoxColumn.DataPropertyName = "serie_comprobante";
            this.seriecomprobanteDataGridViewTextBoxColumn.HeaderText = "# SERIE";
            this.seriecomprobanteDataGridViewTextBoxColumn.Name = "seriecomprobanteDataGridViewTextBoxColumn";
            this.seriecomprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriecomprobanteDataGridViewTextBoxColumn.Width = 74;
            // 
            // formapagoliquidacionDataGridViewTextBoxColumn
            // 
            this.formapagoliquidacionDataGridViewTextBoxColumn.DataPropertyName = "forma_pago_liquidacion";
            this.formapagoliquidacionDataGridViewTextBoxColumn.HeaderText = "FORMA PAGO";
            this.formapagoliquidacionDataGridViewTextBoxColumn.Name = "formapagoliquidacionDataGridViewTextBoxColumn";
            this.formapagoliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.formapagoliquidacionDataGridViewTextBoxColumn.Width = 110;
            // 
            // tipocomprobanteDataGridViewTextBoxColumn
            // 
            this.tipocomprobanteDataGridViewTextBoxColumn.DataPropertyName = "tipo_comprobante";
            this.tipocomprobanteDataGridViewTextBoxColumn.HeaderText = "TIPO COMPROBANTE";
            this.tipocomprobanteDataGridViewTextBoxColumn.Name = "tipocomprobanteDataGridViewTextBoxColumn";
            this.tipocomprobanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocomprobanteDataGridViewTextBoxColumn.Width = 154;
            // 
            // fechaliquidacionDataGridViewTextBoxColumn
            // 
            this.fechaliquidacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_liquidacion";
            this.fechaliquidacionDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechaliquidacionDataGridViewTextBoxColumn.Name = "fechaliquidacionDataGridViewTextBoxColumn";
            this.fechaliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaliquidacionDataGridViewTextBoxColumn.Width = 70;
            // 
            // totalliquidacionDataGridViewTextBoxColumn
            // 
            this.totalliquidacionDataGridViewTextBoxColumn.DataPropertyName = "total_liquidacion";
            this.totalliquidacionDataGridViewTextBoxColumn.HeaderText = "TOTAL";
            this.totalliquidacionDataGridViewTextBoxColumn.Name = "totalliquidacionDataGridViewTextBoxColumn";
            this.totalliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalliquidacionDataGridViewTextBoxColumn.Width = 67;
            // 
            // vistaLiquidacionBindingSource
            // 
            this.vistaLiquidacionBindingSource.DataSource = typeof(CapaEntidades.vistaLiquidacion);
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Image = global::CapaPresentacion.Properties.Resources.money_cancel;
            this.btnAnular.Location = new System.Drawing.Point(687, 450);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(143, 37);
            this.btnAnular.TabIndex = 6;
            this.btnAnular.Text = "Eliminar Comprobante";
            this.btnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(525, 41);
            this.fLabelBig1.TabIndex = 2;
            this.fLabelBig1.Text = "Listado de Comprobantes en Hospedaje";
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.rbtComprobante);
            this.fGroupBox4.Controls.Add(this.rbtFecha);
            this.fGroupBox4.Controls.Add(this.fLabelMedium1);
            this.fGroupBox4.Controls.Add(this.dtpInicio);
            this.fGroupBox4.Controls.Add(this.btnLimpiar);
            this.fGroupBox4.Controls.Add(this.btnBuscar);
            this.fGroupBox4.Controls.Add(this.txtBusqueda);
            this.fGroupBox4.Controls.Add(this.lblBuscar);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(20, 53);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(810, 81);
            this.fGroupBox4.TabIndex = 9;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Búsqueda Comprobante";
            // 
            // rbtComprobante
            // 
            this.rbtComprobante.AutoSize = true;
            this.rbtComprobante.BackColor = System.Drawing.Color.Transparent;
            this.rbtComprobante.Checked = true;
            this.rbtComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtComprobante.Location = new System.Drawing.Point(19, 27);
            this.rbtComprobante.Name = "rbtComprobante";
            this.rbtComprobante.Size = new System.Drawing.Size(106, 19);
            this.rbtComprobante.TabIndex = 10;
            this.rbtComprobante.TabStop = true;
            this.rbtComprobante.Text = "# Comprobante";
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
            this.rbtFecha.Size = new System.Drawing.Size(54, 19);
            this.rbtFecha.TabIndex = 11;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "Fecha";
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
            this.fLabelMedium1.Size = new System.Drawing.Size(53, 21);
            this.fLabelMedium1.TabIndex = 9;
            this.fLabelMedium1.Text = "Fecha ";
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
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(714, 35);
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
            this.btnBuscar.Location = new System.Drawing.Point(618, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 34);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
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
            this.lblBuscar.Size = new System.Drawing.Size(184, 21);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Número de Comprobante";
            // 
            // btnBajaComprobante
            // 
            this.btnBajaComprobante.BackColor = System.Drawing.Color.SkyBlue;
            this.btnBajaComprobante.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajaComprobante.Image = global::CapaPresentacion.Properties.Resources.money_cancel;
            this.btnBajaComprobante.Location = new System.Drawing.Point(481, 450);
            this.btnBajaComprobante.Name = "btnBajaComprobante";
            this.btnBajaComprobante.Size = new System.Drawing.Size(200, 37);
            this.btnBajaComprobante.TabIndex = 10;
            this.btnBajaComprobante.Text = "Baja de Comprobante despúes de Informar a Sunat";
            this.btnBajaComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajaComprobante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBajaComprobante.UseVisualStyleBackColor = false;
            this.btnBajaComprobante.Click += new System.EventHandler(this.btnBajaComprobante_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(321, 450);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(154, 37);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "&Editar Totales";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // fButtonCancelar1
            // 
            this.fButtonCancelar1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fButtonCancelar1.Image = ((System.Drawing.Image)(resources.GetObject("fButtonCancelar1.Image")));
            this.fButtonCancelar1.Location = new System.Drawing.Point(214, 450);
            this.fButtonCancelar1.Name = "fButtonCancelar1";
            this.fButtonCancelar1.Size = new System.Drawing.Size(101, 37);
            this.fButtonCancelar1.TabIndex = 14;
            this.fButtonCancelar1.Text = "Rechazar";
            this.fButtonCancelar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fButtonCancelar1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.fButtonCancelar1.UseVisualStyleBackColor = true;
            this.fButtonCancelar1.Click += new System.EventHandler(this.fButtonCancelar1_Click);
            // 
            // FrmAnularComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 499);
            this.Controls.Add(this.fButtonCancelar1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnBajaComprobante);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmAnularComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAnularComprobante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAnularComprobante_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaLiquidacionBindingSource)).EndInit();
            this.fGroupBox4.ResumeLayout(false);
            this.fGroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FDataGridView fDataGridView1;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridViewTextBoxColumn idliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriecomprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formapagoliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocomprobanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vistaLiquidacionBindingSource;
        private Controles_Standar.FGroupBox fGroupBox4;
        private Controles_Standar.FButtonLimpiar btnLimpiar;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FTextBox txtBusqueda;
        private Controles_Standar.FLabelMedium lblBuscar;
        private Controles_Standar.FRadioButton rbtComprobante;
        private Controles_Standar.FRadioButton rbtFecha;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FDateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnBajaComprobante;
        private Controles_Standar.FButtonEditar btnEditar;
        private Controles_Standar.FButtonCancelar fButtonCancelar1;
    }
}