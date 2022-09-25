namespace CapaPresentacion.Reserva
{
    partial class FrmHCalificacionConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHCalificacionConsulta));
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.dgvCalificacion = new Controles_Standar.FDataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puntoscalificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacalificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaClasificacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.nudPuntaje = new System.Windows.Forms.NumericUpDown();
            this.s10 = new System.Windows.Forms.Button();
            this.s9 = new System.Windows.Forms.Button();
            this.s8 = new System.Windows.Forms.Button();
            this.s7 = new System.Windows.Forms.Button();
            this.s6 = new System.Windows.Forms.Button();
            this.s5 = new System.Windows.Forms.Button();
            this.s4 = new System.Windows.Forms.Button();
            this.s3 = new System.Windows.Forms.Button();
            this.s2 = new System.Windows.Forms.Button();
            this.s1 = new System.Windows.Forms.Button();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.txtComentario = new Controles_Standar.FTextBoxRequerido();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.lblHuesped = new Controles_Standar.FLabelMedium();
            this.fGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaClasificacionBindingSource)).BeginInit();
            this.fGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntaje)).BeginInit();
            this.SuspendLayout();
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.dgvCalificacion);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(434, 58);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(481, 302);
            this.fGroupBox1.TabIndex = 2;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Detalle Calificación";
            // 
            // dgvCalificacion
            // 
            this.dgvCalificacion.AllowUserToAddRows = false;
            this.dgvCalificacion.AllowUserToDeleteRows = false;
            this.dgvCalificacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCalificacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCalificacion.AutoGenerateColumns = false;
            this.dgvCalificacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCalificacion.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCalificacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvCalificacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCalificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.loginusuarioDataGridViewTextBoxColumn,
            this.puntoscalificacionDataGridViewTextBoxColumn,
            this.fechacalificacionDataGridViewTextBoxColumn});
            this.dgvCalificacion.DataSource = this.vistaClasificacionBindingSource;
            this.dgvCalificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalificacion.EnableHeadersVisualStyles = false;
            this.dgvCalificacion.Location = new System.Drawing.Point(3, 19);
            this.dgvCalificacion.MultiSelect = false;
            this.dgvCalificacion.Name = "dgvCalificacion";
            this.dgvCalificacion.ReadOnly = true;
            this.dgvCalificacion.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCalificacion.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCalificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCalificacion.Size = new System.Drawing.Size(475, 280);
            this.dgvCalificacion.TabIndex = 0;
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
            // loginusuarioDataGridViewTextBoxColumn
            // 
            this.loginusuarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loginusuarioDataGridViewTextBoxColumn.DataPropertyName = "login_usuario";
            this.loginusuarioDataGridViewTextBoxColumn.HeaderText = "USUARIO";
            this.loginusuarioDataGridViewTextBoxColumn.Name = "loginusuarioDataGridViewTextBoxColumn";
            this.loginusuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // puntoscalificacionDataGridViewTextBoxColumn
            // 
            this.puntoscalificacionDataGridViewTextBoxColumn.DataPropertyName = "puntos_calificacion";
            this.puntoscalificacionDataGridViewTextBoxColumn.HeaderText = "PUNTOS";
            this.puntoscalificacionDataGridViewTextBoxColumn.Name = "puntoscalificacionDataGridViewTextBoxColumn";
            this.puntoscalificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.puntoscalificacionDataGridViewTextBoxColumn.Width = 75;
            // 
            // fechacalificacionDataGridViewTextBoxColumn
            // 
            this.fechacalificacionDataGridViewTextBoxColumn.DataPropertyName = "fecha_calificacion";
            this.fechacalificacionDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechacalificacionDataGridViewTextBoxColumn.Name = "fechacalificacionDataGridViewTextBoxColumn";
            this.fechacalificacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechacalificacionDataGridViewTextBoxColumn.Width = 66;
            // 
            // vistaClasificacionBindingSource
            // 
            this.vistaClasificacionBindingSource.DataSource = typeof(CapaEntidades.vistaClasificacion);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(344, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Registro de su Calificación";
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.nudPuntaje);
            this.fGroupBox3.Controls.Add(this.s10);
            this.fGroupBox3.Controls.Add(this.s9);
            this.fGroupBox3.Controls.Add(this.s8);
            this.fGroupBox3.Controls.Add(this.s7);
            this.fGroupBox3.Controls.Add(this.s6);
            this.fGroupBox3.Controls.Add(this.s5);
            this.fGroupBox3.Controls.Add(this.s4);
            this.fGroupBox3.Controls.Add(this.s3);
            this.fGroupBox3.Controls.Add(this.s2);
            this.fGroupBox3.Controls.Add(this.s1);
            this.fGroupBox3.Controls.Add(this.fLabelMedium2);
            this.fGroupBox3.Controls.Add(this.txtComentario);
            this.fGroupBox3.Controls.Add(this.fLabelMedium1);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(19, 58);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(391, 259);
            this.fGroupBox3.TabIndex = 1;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Lista de Productos";
            // 
            // nudPuntaje
            // 
            this.nudPuntaje.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vistaClasificacionBindingSource, "puntos_calificacion", true));
            this.nudPuntaje.Location = new System.Drawing.Point(76, 176);
            this.nudPuntaje.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPuntaje.Name = "nudPuntaje";
            this.nudPuntaje.Size = new System.Drawing.Size(62, 23);
            this.nudPuntaje.TabIndex = 13;
            this.nudPuntaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPuntaje.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPuntaje.ValueChanged += new System.EventHandler(this.nudPuntaje_ValueChanged);
            this.nudPuntaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudPuntaje_KeyDown);
            // 
            // s10
            // 
            this.s10.BackColor = System.Drawing.Color.Transparent;
            this.s10.FlatAppearance.BorderSize = 0;
            this.s10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s10.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s10.Location = new System.Drawing.Point(342, 208);
            this.s10.Name = "s10";
            this.s10.Size = new System.Drawing.Size(30, 30);
            this.s10.TabIndex = 12;
            this.s10.UseVisualStyleBackColor = false;
            this.s10.Visible = false;
            // 
            // s9
            // 
            this.s9.BackColor = System.Drawing.Color.Transparent;
            this.s9.FlatAppearance.BorderSize = 0;
            this.s9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s9.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s9.Location = new System.Drawing.Point(306, 208);
            this.s9.Name = "s9";
            this.s9.Size = new System.Drawing.Size(30, 30);
            this.s9.TabIndex = 11;
            this.s9.UseVisualStyleBackColor = false;
            this.s9.Visible = false;
            // 
            // s8
            // 
            this.s8.BackColor = System.Drawing.Color.Transparent;
            this.s8.FlatAppearance.BorderSize = 0;
            this.s8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s8.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s8.Location = new System.Drawing.Point(270, 208);
            this.s8.Name = "s8";
            this.s8.Size = new System.Drawing.Size(30, 30);
            this.s8.TabIndex = 10;
            this.s8.UseVisualStyleBackColor = false;
            this.s8.Visible = false;
            // 
            // s7
            // 
            this.s7.BackColor = System.Drawing.Color.Transparent;
            this.s7.FlatAppearance.BorderSize = 0;
            this.s7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s7.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s7.Location = new System.Drawing.Point(234, 208);
            this.s7.Name = "s7";
            this.s7.Size = new System.Drawing.Size(30, 30);
            this.s7.TabIndex = 9;
            this.s7.UseVisualStyleBackColor = false;
            this.s7.Visible = false;
            // 
            // s6
            // 
            this.s6.BackColor = System.Drawing.Color.Transparent;
            this.s6.FlatAppearance.BorderSize = 0;
            this.s6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s6.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s6.Location = new System.Drawing.Point(198, 208);
            this.s6.Name = "s6";
            this.s6.Size = new System.Drawing.Size(30, 30);
            this.s6.TabIndex = 8;
            this.s6.UseVisualStyleBackColor = false;
            this.s6.Visible = false;
            // 
            // s5
            // 
            this.s5.BackColor = System.Drawing.Color.Transparent;
            this.s5.FlatAppearance.BorderSize = 0;
            this.s5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s5.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s5.Location = new System.Drawing.Point(162, 208);
            this.s5.Name = "s5";
            this.s5.Size = new System.Drawing.Size(30, 30);
            this.s5.TabIndex = 7;
            this.s5.UseVisualStyleBackColor = false;
            this.s5.Visible = false;
            // 
            // s4
            // 
            this.s4.BackColor = System.Drawing.Color.Transparent;
            this.s4.FlatAppearance.BorderSize = 0;
            this.s4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s4.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s4.Location = new System.Drawing.Point(126, 208);
            this.s4.Name = "s4";
            this.s4.Size = new System.Drawing.Size(30, 30);
            this.s4.TabIndex = 6;
            this.s4.UseVisualStyleBackColor = false;
            this.s4.Visible = false;
            // 
            // s3
            // 
            this.s3.BackColor = System.Drawing.Color.Transparent;
            this.s3.FlatAppearance.BorderSize = 0;
            this.s3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s3.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s3.Location = new System.Drawing.Point(90, 208);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(30, 30);
            this.s3.TabIndex = 5;
            this.s3.UseVisualStyleBackColor = false;
            this.s3.Visible = false;
            // 
            // s2
            // 
            this.s2.BackColor = System.Drawing.Color.Transparent;
            this.s2.FlatAppearance.BorderSize = 0;
            this.s2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s2.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s2.Location = new System.Drawing.Point(54, 208);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(30, 30);
            this.s2.TabIndex = 4;
            this.s2.UseVisualStyleBackColor = false;
            this.s2.Visible = false;
            // 
            // s1
            // 
            this.s1.BackColor = System.Drawing.Color.Transparent;
            this.s1.FlatAppearance.BorderSize = 0;
            this.s1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.s1.Image = global::CapaPresentacion.Properties.Resources.Estrella;
            this.s1.Location = new System.Drawing.Point(18, 208);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(30, 30);
            this.s1.TabIndex = 3;
            this.s1.UseVisualStyleBackColor = false;
            this.s1.Visible = false;
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(9, 176);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(61, 21);
            this.fLabelMedium2.TabIndex = 2;
            this.fLabelMedium2.Text = "Puntaje";
            // 
            // txtComentario
            // 
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComentario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vistaClasificacionBindingSource, "comentario_calificacion", true));
            this.txtComentario.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(12, 43);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(354, 119);
            this.txtComentario.TabIndex = 1;
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(8, 19);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(89, 21);
            this.fLabelMedium1.TabIndex = 0;
            this.fLabelMedium1.Text = "Comentario";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(822, 366);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblHuesped
            // 
            this.lblHuesped.AutoSize = true;
            this.lblHuesped.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHuesped.ForeColor = System.Drawing.Color.Black;
            this.lblHuesped.Location = new System.Drawing.Point(15, 339);
            this.lblHuesped.Name = "lblHuesped";
            this.lblHuesped.Size = new System.Drawing.Size(70, 21);
            this.lblHuesped.TabIndex = 14;
            this.lblHuesped.Text = "Huesped";
            // 
            // FrmHCalificacionConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 409);
            this.Controls.Add(this.lblHuesped);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHCalificacionConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Registrar Calificación .::.";
            this.Load += new System.EventHandler(this.FrmReservacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmHCalificacionConsulta_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaClasificacionBindingSource)).EndInit();
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntaje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FDataGridView dgvCalificacion;
        private Controles_Standar.FGroupBox fGroupBox3;
        private System.Windows.Forms.Button s10;
        private System.Windows.Forms.Button s9;
        private System.Windows.Forms.Button s8;
        private System.Windows.Forms.Button s7;
        private System.Windows.Forms.Button s6;
        private System.Windows.Forms.Button s5;
        private System.Windows.Forms.Button s4;
        private System.Windows.Forms.Button s3;
        private System.Windows.Forms.Button s2;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FTextBoxRequerido txtComentario;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private System.Windows.Forms.Button s1;
        private System.Windows.Forms.NumericUpDown nudPuntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn puntoscalificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacalificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vistaClasificacionBindingSource;
        private Controles_Standar.FLabelMedium lblHuesped;
    }
}