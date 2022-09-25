namespace CapaPresentacion.Reporte.Formularios
{
    partial class FrmReporteContador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteContador));
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.dtpFinal = new Controles_Standar.FDateTimePicker();
            this.fLabelSmall2 = new Controles_Standar.FLabelSmall();
            this.dtpInicial = new Controles_Standar.FDateTimePicker();
            this.fLabelSmall1 = new Controles_Standar.FLabelSmall();
            this.btnReporte = new Controles_Standar.FButtonReporte();
            this.btnSalir = new Controles_Standar.FButtonSalir();
            this.fCheckBox1 = new Controles_Standar.FCheckBox();
            this.fGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(247, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Reporte Contador";
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.dtpFinal);
            this.fGroupBox1.Controls.Add(this.fLabelSmall2);
            this.fGroupBox1.Controls.Add(this.dtpInicial);
            this.fGroupBox1.Controls.Add(this.fLabelSmall1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(19, 63);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(354, 79);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Rango de Fechas";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(196, 45);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(128, 23);
            this.dtpFinal.TabIndex = 3;
            // 
            // fLabelSmall2
            // 
            this.fLabelSmall2.AutoSize = true;
            this.fLabelSmall2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall2.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall2.Location = new System.Drawing.Point(193, 27);
            this.fLabelSmall2.Name = "fLabelSmall2";
            this.fLabelSmall2.Size = new System.Drawing.Size(61, 15);
            this.fLabelSmall2.TabIndex = 2;
            this.fLabelSmall2.Text = "Fecha Final";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(19, 45);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(128, 23);
            this.dtpInicial.TabIndex = 1;
            // 
            // fLabelSmall1
            // 
            this.fLabelSmall1.AutoSize = true;
            this.fLabelSmall1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall1.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall1.Location = new System.Drawing.Point(16, 27);
            this.fLabelSmall1.Name = "fLabelSmall1";
            this.fLabelSmall1.Size = new System.Drawing.Size(65, 15);
            this.fLabelSmall1.TabIndex = 0;
            this.fLabelSmall1.Text = "Fecha Inicial";
            // 
            // btnReporte
            // 
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.Location = new System.Drawing.Point(84, 175);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(90, 34);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(206, 175);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 34);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // fCheckBox1
            // 
            this.fCheckBox1.AutoSize = true;
            this.fCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.fCheckBox1.FlatAppearance.BorderSize = 0;
            this.fCheckBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fCheckBox1.ForeColor = System.Drawing.Color.Black;
            this.fCheckBox1.Location = new System.Drawing.Point(262, 148);
            this.fCheckBox1.Name = "fCheckBox1";
            this.fCheckBox1.Size = new System.Drawing.Size(79, 19);
            this.fCheckBox1.TabIndex = 4;
            this.fCheckBox1.Text = "Ver Detalle\r\n";
            this.fCheckBox1.UseVisualStyleBackColor = false;
            this.fCheckBox1.CheckedChanged += new System.EventHandler(this.fCheckBox1_CheckedChanged);
            // 
            // FrmReporteContador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 221);
            this.Controls.Add(this.fCheckBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmReporteContador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmReporteContador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReporteContador_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FDateTimePicker dtpFinal;
        private Controles_Standar.FLabelSmall fLabelSmall2;
        private Controles_Standar.FDateTimePicker dtpInicial;
        private Controles_Standar.FLabelSmall fLabelSmall1;
        private Controles_Standar.FButtonReporte btnReporte;
        private Controles_Standar.FButtonSalir btnSalir;
        private Controles_Standar.FCheckBox fCheckBox1;
    }
}