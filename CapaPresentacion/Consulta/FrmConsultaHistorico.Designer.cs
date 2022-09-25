namespace CapaPresentacion.Consulta
{
    partial class FrmConsultaHistorico
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
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.dgvDatos = new Controles_Standar.FDataGridView();
            this.paBusquedaHistoricoResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.completohuespedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacheckinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechachecoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_hospedaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBusquedaHistoricoResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.dgvDatos);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(12, 81);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(965, 350);
            this.fGroupBox2.TabIndex = 3;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Lista de Registros";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.completohuespedDataGridViewTextBoxColumn,
            this.habitacionDataGridViewTextBoxColumn,
            this.fechacheckinDataGridViewTextBoxColumn,
            this.fechachecoutDataGridViewTextBoxColumn,
            this.Tarifa,
            this.dias,
            this.total_hospedaje,
            this.consumo});
            this.dgvDatos.DataSource = this.paBusquedaHistoricoResultBindingSource;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.EnableHeadersVisualStyles = false;
            this.dgvDatos.Location = new System.Drawing.Point(3, 19);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDatos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(959, 328);
            this.dgvDatos.TabIndex = 0;
            // 
            // paBusquedaHistoricoResultBindingSource
            // 
            this.paBusquedaHistoricoResultBindingSource.DataSource = typeof(CapaEntidades.pa_BusquedaHistorico_Result);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(322, 41);
            this.fLabelBig1.TabIndex = 1;
            this.fLabelBig1.Text = "Consulta de Hospedajes";
            // 
            // completohuespedDataGridViewTextBoxColumn
            // 
            this.completohuespedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.completohuespedDataGridViewTextBoxColumn.DataPropertyName = "completo_huesped";
            this.completohuespedDataGridViewTextBoxColumn.HeaderText = "HUESPED";
            this.completohuespedDataGridViewTextBoxColumn.Name = "completohuespedDataGridViewTextBoxColumn";
            this.completohuespedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // habitacionDataGridViewTextBoxColumn
            // 
            this.habitacionDataGridViewTextBoxColumn.DataPropertyName = "habitacion";
            this.habitacionDataGridViewTextBoxColumn.HeaderText = "HABITACION";
            this.habitacionDataGridViewTextBoxColumn.Name = "habitacionDataGridViewTextBoxColumn";
            this.habitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.habitacionDataGridViewTextBoxColumn.Width = 98;
            // 
            // fechacheckinDataGridViewTextBoxColumn
            // 
            this.fechacheckinDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fechacheckinDataGridViewTextBoxColumn.DataPropertyName = "fecha_checkin";
            this.fechacheckinDataGridViewTextBoxColumn.HeaderText = "CHECK IN";
            this.fechacheckinDataGridViewTextBoxColumn.Name = "fechacheckinDataGridViewTextBoxColumn";
            this.fechacheckinDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechacheckinDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechachecoutDataGridViewTextBoxColumn
            // 
            this.fechachecoutDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fechachecoutDataGridViewTextBoxColumn.DataPropertyName = "fecha_checout";
            this.fechachecoutDataGridViewTextBoxColumn.HeaderText = "CHECK OUT";
            this.fechachecoutDataGridViewTextBoxColumn.Name = "fechachecoutDataGridViewTextBoxColumn";
            this.fechachecoutDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechachecoutDataGridViewTextBoxColumn.Width = 91;
            // 
            // Tarifa
            // 
            this.Tarifa.DataPropertyName = "Tarifa";
            this.Tarifa.HeaderText = "TARIFA";
            this.Tarifa.Name = "Tarifa";
            this.Tarifa.ReadOnly = true;
            this.Tarifa.Width = 67;
            // 
            // dias
            // 
            this.dias.DataPropertyName = "dias";
            this.dias.HeaderText = "DIAS";
            this.dias.Name = "dias";
            this.dias.ReadOnly = true;
            this.dias.Width = 56;
            // 
            // total_hospedaje
            // 
            this.total_hospedaje.DataPropertyName = "total_hospedaje";
            this.total_hospedaje.HeaderText = "HOSPEDAJE";
            this.total_hospedaje.Name = "total_hospedaje";
            this.total_hospedaje.ReadOnly = true;
            this.total_hospedaje.Width = 94;
            // 
            // consumo
            // 
            this.consumo.DataPropertyName = "consumo";
            this.consumo.HeaderText = "CONSUMO";
            this.consumo.Name = "consumo";
            this.consumo.ReadOnly = true;
            this.consumo.Width = 89;
            // 
            // FrmConsultaHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 443);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmConsultaHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaTarjeta_KeyDown);
            this.fGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBusquedaHistoricoResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FDataGridView dgvDatos;
        private System.Windows.Forms.BindingSource paBusquedaHistoricoResultBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn completohuespedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacheckinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechachecoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_hospedaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
    }
}