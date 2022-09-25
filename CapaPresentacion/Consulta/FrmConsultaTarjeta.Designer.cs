namespace CapaPresentacion.Consulta
{
    partial class FrmConsultaTarjeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaTarjeta));
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerPendienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.dgvDatos = new Controles_Standar.FDataGridView();
            this.id_liquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencialiquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ntarjetaliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaliquidacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paValidarTarjetasResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.dtpFinal = new Controles_Standar.FDateTimePicker();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.dtpInicio = new Controles_Standar.FDateTimePicker();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.cmsMenu.SuspendLayout();
            this.fGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paValidarTarjetasResultBindingSource)).BeginInit();
            this.fGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerPendienteToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(178, 26);
            // 
            // removerPendienteToolStripMenuItem
            // 
            this.removerPendienteToolStripMenuItem.Name = "removerPendienteToolStripMenuItem";
            this.removerPendienteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.removerPendienteToolStripMenuItem.Text = "Remover Pendiente";
            this.removerPendienteToolStripMenuItem.Click += new System.EventHandler(this.removerPendienteToolStripMenuItem_Click);
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.dgvDatos);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(12, 164);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(532, 267);
            this.fGroupBox2.TabIndex = 3;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Lista de Registros";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_liquidacion,
            this.clienteliquidacionDataGridViewTextBoxColumn,
            this.referencialiquidacionDataGridViewTextBoxColumn,
            this.ntarjetaliquidacionDataGridViewTextBoxColumn,
            this.totalliquidacionDataGridViewTextBoxColumn,
            this.fechaliquidacionDataGridViewTextBoxColumn});
            this.dgvDatos.ContextMenuStrip = this.cmsMenu;
            this.dgvDatos.DataSource = this.paValidarTarjetasResultBindingSource;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(3, 19);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(526, 245);
            this.dgvDatos.TabIndex = 0;
            // 
            // id_liquidacion
            // 
            this.id_liquidacion.DataPropertyName = "id_liquidacion";
            this.id_liquidacion.HeaderText = "id_liquidacion";
            this.id_liquidacion.Name = "id_liquidacion";
            this.id_liquidacion.ReadOnly = true;
            this.id_liquidacion.Visible = false;
            this.id_liquidacion.Width = 78;
            // 
            // clienteliquidacionDataGridViewTextBoxColumn
            // 
            this.clienteliquidacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clienteliquidacionDataGridViewTextBoxColumn.DataPropertyName = "cliente_liquidacion";
            this.clienteliquidacionDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.clienteliquidacionDataGridViewTextBoxColumn.Name = "clienteliquidacionDataGridViewTextBoxColumn";
            this.clienteliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // referencialiquidacionDataGridViewTextBoxColumn
            // 
            this.referencialiquidacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.referencialiquidacionDataGridViewTextBoxColumn.DataPropertyName = "referencia_liquidacion";
            this.referencialiquidacionDataGridViewTextBoxColumn.HeaderText = "REFERENCIA";
            this.referencialiquidacionDataGridViewTextBoxColumn.Name = "referencialiquidacionDataGridViewTextBoxColumn";
            this.referencialiquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.referencialiquidacionDataGridViewTextBoxColumn.Width = 96;
            // 
            // ntarjetaliquidacionDataGridViewTextBoxColumn
            // 
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.DataPropertyName = "ntarjeta_liquidacion";
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.HeaderText = "NÚM. TARJ.";
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.Name = "ntarjetaliquidacionDataGridViewTextBoxColumn";
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.ntarjetaliquidacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // totalliquidacionDataGridViewTextBoxColumn
            // 
            this.totalliquidacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.totalliquidacionDataGridViewTextBoxColumn.DataPropertyName = "total_liquidacion";
            this.totalliquidacionDataGridViewTextBoxColumn.HeaderText = "TOTAL";
            this.totalliquidacionDataGridViewTextBoxColumn.Name = "totalliquidacionDataGridViewTextBoxColumn";
            this.totalliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalliquidacionDataGridViewTextBoxColumn.Width = 62;
            // 
            // fechaliquidacionDataGridViewTextBoxColumn
            // 
            this.fechaliquidacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_liquidacion";
            this.fechaliquidacionDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechaliquidacionDataGridViewTextBoxColumn.Name = "fechaliquidacionDataGridViewTextBoxColumn";
            this.fechaliquidacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaliquidacionDataGridViewTextBoxColumn.Width = 66;
            // 
            // paValidarTarjetasResultBindingSource
            // 
            this.paValidarTarjetasResultBindingSource.AllowNew = true;
            this.paValidarTarjetasResultBindingSource.DataSource = typeof(CapaEntidades.pa_ValidarTarjetas_Result);
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.btnBuscar);
            this.fGroupBox1.Controls.Add(this.fLabelMedium2);
            this.fGroupBox1.Controls.Add(this.dtpFinal);
            this.fGroupBox1.Controls.Add(this.fLabelMedium1);
            this.fGroupBox1.Controls.Add(this.dtpInicio);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(12, 64);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(532, 94);
            this.fGroupBox1.TabIndex = 2;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos de la Búsqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(387, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 34);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(236, 24);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(83, 21);
            this.fLabelMedium2.TabIndex = 9;
            this.fLabelMedium2.Text = "Fecha Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(240, 48);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(128, 23);
            this.dtpFinal.TabIndex = 8;
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(72, 24);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(90, 21);
            this.fLabelMedium1.TabIndex = 7;
            this.fLabelMedium1.Text = "Fecha Inicial";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(76, 48);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(128, 23);
            this.dtpInicio.TabIndex = 6;
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(216, 41);
            this.fLabelBig1.TabIndex = 1;
            this.fLabelBig1.Text = "Consulta Tarjeta";
            // 
            // FrmConsultaTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 443);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmConsultaTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaTarjeta_KeyDown);
            this.cmsMenu.ResumeLayout(false);
            this.fGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paValidarTarjetasResultBindingSource)).EndInit();
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FDateTimePicker dtpFinal;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FDataGridView dgvDatos;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem removerPendienteToolStripMenuItem;
        private System.Windows.Forms.BindingSource paValidarTarjetasResultBindingSource;
        private Controles_Standar.FDateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_liquidacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencialiquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ntarjetaliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalliquidacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaliquidacionDataGridViewTextBoxColumn;
    }
}