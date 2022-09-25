namespace CapaPresentacion.Consulta
{
    partial class FrmConsultaBusqueda
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
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fDataGridView1 = new Controles_Standar.FDataGridView();
            this.completohuespedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoreservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechahoteleraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombretarifahabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciotarifahabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaBusquedaReservasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTexto = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaBusquedaReservasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(15, 63);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(71, 21);
            this.fLabelMedium1.TabIndex = 1;
            this.fLabelMedium1.Text = "Señor(a):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fDataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(19, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 256);
            this.groupBox1.TabIndex = 2;
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
            this.completohuespedDataGridViewTextBoxColumn,
            this.codigoreservaDataGridViewTextBoxColumn,
            this.pisoDataGridViewTextBoxColumn,
            this.fechahoteleraDataGridViewTextBoxColumn,
            this.nombretarifahabitacionDataGridViewTextBoxColumn,
            this.preciotarifahabitacionDataGridViewTextBoxColumn,
            this.loginusuarioDataGridViewTextBoxColumn});
            this.fDataGridView1.DataSource = this.vistaBusquedaReservasBindingSource;
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
            this.fDataGridView1.Size = new System.Drawing.Size(804, 237);
            this.fDataGridView1.TabIndex = 0;
            // 
            // completohuespedDataGridViewTextBoxColumn
            // 
            this.completohuespedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.completohuespedDataGridViewTextBoxColumn.DataPropertyName = "completo_huesped";
            this.completohuespedDataGridViewTextBoxColumn.HeaderText = "HUESPED";
            this.completohuespedDataGridViewTextBoxColumn.Name = "completohuespedDataGridViewTextBoxColumn";
            this.completohuespedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoreservaDataGridViewTextBoxColumn
            // 
            this.codigoreservaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codigoreservaDataGridViewTextBoxColumn.DataPropertyName = "codigo_reserva";
            this.codigoreservaDataGridViewTextBoxColumn.HeaderText = "DNI";
            this.codigoreservaDataGridViewTextBoxColumn.Name = "codigoreservaDataGridViewTextBoxColumn";
            this.codigoreservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoreservaDataGridViewTextBoxColumn.Width = 53;
            // 
            // pisoDataGridViewTextBoxColumn
            // 
            this.pisoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pisoDataGridViewTextBoxColumn.DataPropertyName = "piso";
            this.pisoDataGridViewTextBoxColumn.HeaderText = "# HAB";
            this.pisoDataGridViewTextBoxColumn.Name = "pisoDataGridViewTextBoxColumn";
            this.pisoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pisoDataGridViewTextBoxColumn.Width = 68;
            // 
            // fechahoteleraDataGridViewTextBoxColumn
            // 
            this.fechahoteleraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fechahoteleraDataGridViewTextBoxColumn.DataPropertyName = "fecha_hotelera";
            this.fechahoteleraDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechahoteleraDataGridViewTextBoxColumn.Name = "fechahoteleraDataGridViewTextBoxColumn";
            this.fechahoteleraDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechahoteleraDataGridViewTextBoxColumn.Width = 70;
            // 
            // nombretarifahabitacionDataGridViewTextBoxColumn
            // 
            this.nombretarifahabitacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombretarifahabitacionDataGridViewTextBoxColumn.DataPropertyName = "nombre_tarifa_habitacion";
            this.nombretarifahabitacionDataGridViewTextBoxColumn.HeaderText = "TARIFA";
            this.nombretarifahabitacionDataGridViewTextBoxColumn.Name = "nombretarifahabitacionDataGridViewTextBoxColumn";
            this.nombretarifahabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombretarifahabitacionDataGridViewTextBoxColumn.Width = 69;
            // 
            // preciotarifahabitacionDataGridViewTextBoxColumn
            // 
            this.preciotarifahabitacionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.preciotarifahabitacionDataGridViewTextBoxColumn.DataPropertyName = "precio_tarifa_habitacion";
            this.preciotarifahabitacionDataGridViewTextBoxColumn.HeaderText = "PRECIO";
            this.preciotarifahabitacionDataGridViewTextBoxColumn.Name = "preciotarifahabitacionDataGridViewTextBoxColumn";
            this.preciotarifahabitacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.preciotarifahabitacionDataGridViewTextBoxColumn.Width = 74;
            // 
            // loginusuarioDataGridViewTextBoxColumn
            // 
            this.loginusuarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loginusuarioDataGridViewTextBoxColumn.DataPropertyName = "login_usuario";
            this.loginusuarioDataGridViewTextBoxColumn.HeaderText = "USUARIO";
            this.loginusuarioDataGridViewTextBoxColumn.Name = "loginusuarioDataGridViewTextBoxColumn";
            this.loginusuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vistaBusquedaReservasBindingSource
            // 
            this.vistaBusquedaReservasBindingSource.DataSource = typeof(CapaEntidades.vistaBusquedaReservas);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.ForeColor = System.Drawing.Color.Black;
            this.lblTexto.Location = new System.Drawing.Point(92, 63);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(71, 21);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "Señor(a):";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(414, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Listado de Reservas por Cliente";
            // 
            // FrmConsultaBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 355);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fLabelMedium1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmConsultaBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaBusqueda_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaBusquedaReservasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelMedium fLabelMedium1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FDataGridView fDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn completohuespedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoreservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechahoteleraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombretarifahabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciotarifahabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vistaBusquedaReservasBindingSource;
        private Controles_Standar.FLabelMedium lblTexto;
        private Controles_Standar.FLabelBig fLabelBig1;
    }
}