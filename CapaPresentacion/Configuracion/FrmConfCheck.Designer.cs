namespace CapaPresentacion.Configuracion
{
    partial class FrmConfCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfCheck));
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.txtAnio = new Controles_Standar.FTextBoxInt();
            this.fLabelMedium3 = new Controles_Standar.FLabelMedium();
            this.nuMinutoCkO = new System.Windows.Forms.NumericUpDown();
            this.nupHoraCkO = new System.Windows.Forms.NumericUpDown();
            this.nuMinutoCkI = new System.Windows.Forms.NumericUpDown();
            this.nupHoraCkI = new System.Windows.Forms.NumericUpDown();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.fLabelMedium4 = new Controles_Standar.FLabelMedium();
            this.txtHora = new Controles_Standar.FTextBoxInt();
            this.fLabelSmall1 = new Controles_Standar.FLabelSmall();
            this.fGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinutoCkO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHoraCkO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinutoCkI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHoraCkI)).BeginInit();
            this.SuspendLayout();
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.fLabelSmall1);
            this.fGroupBox1.Controls.Add(this.txtHora);
            this.fGroupBox1.Controls.Add(this.fLabelMedium4);
            this.fGroupBox1.Controls.Add(this.txtAnio);
            this.fGroupBox1.Controls.Add(this.fLabelMedium3);
            this.fGroupBox1.Controls.Add(this.nuMinutoCkO);
            this.fGroupBox1.Controls.Add(this.nupHoraCkO);
            this.fGroupBox1.Controls.Add(this.nuMinutoCkI);
            this.fGroupBox1.Controls.Add(this.nupHoraCkI);
            this.fGroupBox1.Controls.Add(this.fLabelMedium2);
            this.fGroupBox1.Controls.Add(this.fLabelMedium1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(20, 59);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(319, 179);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos de la Configuración";
            // 
            // txtAnio
            // 
            this.txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnio.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.Location = new System.Drawing.Point(183, 95);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(96, 23);
            this.txtAnio.TabIndex = 7;
            // 
            // fLabelMedium3
            // 
            this.fLabelMedium3.AutoSize = true;
            this.fLabelMedium3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium3.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium3.Location = new System.Drawing.Point(36, 97);
            this.fLabelMedium3.Name = "fLabelMedium3";
            this.fLabelMedium3.Size = new System.Drawing.Size(102, 21);
            this.fLabelMedium3.TabIndex = 6;
            this.fLabelMedium3.Text = "Año en Curso";
            // 
            // nuMinutoCkO
            // 
            this.nuMinutoCkO.Location = new System.Drawing.Point(234, 63);
            this.nuMinutoCkO.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nuMinutoCkO.Name = "nuMinutoCkO";
            this.nuMinutoCkO.Size = new System.Drawing.Size(45, 23);
            this.nuMinutoCkO.TabIndex = 5;
            // 
            // nupHoraCkO
            // 
            this.nupHoraCkO.Location = new System.Drawing.Point(183, 63);
            this.nupHoraCkO.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupHoraCkO.Name = "nupHoraCkO";
            this.nupHoraCkO.Size = new System.Drawing.Size(45, 23);
            this.nupHoraCkO.TabIndex = 4;
            // 
            // nuMinutoCkI
            // 
            this.nuMinutoCkI.Location = new System.Drawing.Point(234, 34);
            this.nuMinutoCkI.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nuMinutoCkI.Name = "nuMinutoCkI";
            this.nuMinutoCkI.Size = new System.Drawing.Size(45, 23);
            this.nuMinutoCkI.TabIndex = 3;
            // 
            // nupHoraCkI
            // 
            this.nupHoraCkI.Location = new System.Drawing.Point(183, 34);
            this.nupHoraCkI.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nupHoraCkI.Name = "nupHoraCkI";
            this.nupHoraCkI.Size = new System.Drawing.Size(45, 23);
            this.nupHoraCkI.TabIndex = 2;
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(36, 63);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(135, 21);
            this.fLabelMedium2.TabIndex = 1;
            this.fLabelMedium2.Text = "Horario Check Out";
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(36, 31);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(122, 21);
            this.fLabelMedium1.TabIndex = 0;
            this.fLabelMedium1.Text = "Horario Check In";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(307, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Configurando Horarios";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(249, 257);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // fLabelMedium4
            // 
            this.fLabelMedium4.AutoSize = true;
            this.fLabelMedium4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium4.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium4.Location = new System.Drawing.Point(36, 124);
            this.fLabelMedium4.Name = "fLabelMedium4";
            this.fLabelMedium4.Size = new System.Drawing.Size(133, 21);
            this.fLabelMedium4.TabIndex = 8;
            this.fLabelMedium4.Text = "Hora Dia siguiente";
            // 
            // txtHora
            // 
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHora.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(183, 124);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(96, 23);
            this.txtHora.TabIndex = 9;
            // 
            // fLabelSmall1
            // 
            this.fLabelSmall1.AutoSize = true;
            this.fLabelSmall1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall1.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall1.Location = new System.Drawing.Point(177, 150);
            this.fLabelSmall1.Name = "fLabelSmall1";
            this.fLabelSmall1.Size = new System.Drawing.Size(114, 15);
            this.fLabelSmall1.TabIndex = 3;
            this.fLabelSmall1.Text = "Ejemplo: 04:59:59 am";
            // 
            // FrmConfCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 303);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfCheck_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinutoCkO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHoraCkO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuMinutoCkI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHoraCkI)).EndInit();
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
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private System.Windows.Forms.NumericUpDown nuMinutoCkO;
        private System.Windows.Forms.NumericUpDown nupHoraCkO;
        private System.Windows.Forms.NumericUpDown nuMinutoCkI;
        private System.Windows.Forms.NumericUpDown nupHoraCkI;
        private Controles_Standar.FTextBoxInt txtAnio;
        private Controles_Standar.FLabelMedium fLabelMedium3;
        private Controles_Standar.FTextBoxInt txtHora;
        private Controles_Standar.FLabelMedium fLabelMedium4;
        private Controles_Standar.FLabelSmall fLabelSmall1;
    }
}