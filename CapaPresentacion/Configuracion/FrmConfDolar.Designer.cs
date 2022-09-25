namespace CapaPresentacion.Configuracion
{
    partial class FrmConfDolar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfDolar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.txtDolarActual = new Controles_Standar.FTextBoxDoubleRequerido();
            this.dolarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtAnioRegistro = new Controles_Standar.FTextBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.dgv_datos = new Controles_Standar.FDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aniodolarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordolarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadodolarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnNuevo = new Controles_Standar.FButtonNuevo();
            this.btnEditar = new Controles_Standar.FButtonEditar();
            this.fGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dolarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.txtDolarActual);
            this.fGroupBox1.Controls.Add(this.txtAnioRegistro);
            this.fGroupBox1.Controls.Add(this.fLabelMedium2);
            this.fGroupBox1.Controls.Add(this.fLabelMedium1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(20, 59);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(286, 99);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos de la Configuración";
            // 
            // txtDolarActual
            // 
            this.txtDolarActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDolarActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDolarActual.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dolarBindingSource, "valor_dolar", true));
            this.txtDolarActual.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDolarActual.Location = new System.Drawing.Point(135, 52);
            this.txtDolarActual.Name = "txtDolarActual";
            this.txtDolarActual.Size = new System.Drawing.Size(121, 23);
            this.txtDolarActual.TabIndex = 4;
            this.txtDolarActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDolarActual_KeyPress);
            // 
            // dolarBindingSource
            // 
            this.dolarBindingSource.DataSource = typeof(CapaEntidades.Dolar);
            // 
            // txtAnioRegistro
            // 
            this.txtAnioRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnioRegistro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAnioRegistro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dolarBindingSource, "anio_dolar", true));
            this.txtAnioRegistro.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnioRegistro.Location = new System.Drawing.Point(135, 23);
            this.txtAnioRegistro.Name = "txtAnioRegistro";
            this.txtAnioRegistro.Size = new System.Drawing.Size(121, 23);
            this.txtAnioRegistro.TabIndex = 3;
            this.txtAnioRegistro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIGVActual_KeyPress);
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(12, 52);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(92, 21);
            this.fLabelMedium2.TabIndex = 2;
            this.fLabelMedium2.Text = "Dolar Actual";
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(12, 22);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(96, 21);
            this.fLabelMedium1.TabIndex = 0;
            this.fLabelMedium1.Text = "Año Registro";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(294, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Configurando Dolares";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(216, 177);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgv_datos
            // 
            this.dgv_datos.AllowUserToAddRows = false;
            this.dgv_datos.AllowUserToDeleteRows = false;
            this.dgv_datos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_datos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_datos.AutoGenerateColumns = false;
            this.dgv_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_datos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_datos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgv_datos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.aniodolarDataGridViewTextBoxColumn,
            this.valordolarDataGridViewTextBoxColumn,
            this.estadodolarDataGridViewCheckBoxColumn});
            this.dgv_datos.DataSource = this.dolarBindingSource;
            this.dgv_datos.EnableHeadersVisualStyles = false;
            this.dgv_datos.Location = new System.Drawing.Point(334, 59);
            this.dgv_datos.MultiSelect = false;
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.ReadOnly = true;
            this.dgv_datos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_datos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_datos.Size = new System.Drawing.Size(136, 114);
            this.dgv_datos.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 23;
            // 
            // aniodolarDataGridViewTextBoxColumn
            // 
            this.aniodolarDataGridViewTextBoxColumn.DataPropertyName = "anio_dolar";
            this.aniodolarDataGridViewTextBoxColumn.HeaderText = "AÑO";
            this.aniodolarDataGridViewTextBoxColumn.Name = "aniodolarDataGridViewTextBoxColumn";
            this.aniodolarDataGridViewTextBoxColumn.ReadOnly = true;
            this.aniodolarDataGridViewTextBoxColumn.Width = 59;
            // 
            // valordolarDataGridViewTextBoxColumn
            // 
            this.valordolarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valordolarDataGridViewTextBoxColumn.DataPropertyName = "valor_dolar";
            this.valordolarDataGridViewTextBoxColumn.HeaderText = "VALOR";
            this.valordolarDataGridViewTextBoxColumn.Name = "valordolarDataGridViewTextBoxColumn";
            this.valordolarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadodolarDataGridViewCheckBoxColumn
            // 
            this.estadodolarDataGridViewCheckBoxColumn.DataPropertyName = "estado_dolar";
            this.estadodolarDataGridViewCheckBoxColumn.HeaderText = "estado_dolar";
            this.estadodolarDataGridViewCheckBoxColumn.Name = "estadodolarDataGridViewCheckBoxColumn";
            this.estadodolarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.estadodolarDataGridViewCheckBoxColumn.Visible = false;
            this.estadodolarDataGridViewCheckBoxColumn.Width = 81;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(24, 177);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 34);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(120, 177);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 34);
            this.btnEditar.TabIndex = 5;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmConfDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 233);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgv_datos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfDolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmConfDolar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfDolar_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dolarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecategoriaDataGridViewTextBoxColumn;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private Controles_Standar.FTextBox txtAnioRegistro;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FDataGridView dgv_datos;
        private System.Windows.Forms.BindingSource dolarBindingSource;
        private Controles_Standar.FButtonNuevo btnNuevo;
        private Controles_Standar.FButtonEditar btnEditar;
        private Controles_Standar.FTextBoxDoubleRequerido txtDolarActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aniodolarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordolarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estadodolarDataGridViewCheckBoxColumn;


    }
}