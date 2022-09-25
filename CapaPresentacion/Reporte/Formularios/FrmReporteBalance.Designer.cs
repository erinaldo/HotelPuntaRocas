namespace CapaPresentacion.Reporte.Formularios
{
    partial class FrmReporteBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteBalance));
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.btnReporte = new Controles_Standar.FButtonReporte();
            this.btnSalir = new Controles_Standar.FButtonSalir();
            this.rbtConsumo = new Controles_Standar.FRadioButton();
            this.rbtHospedaje = new Controles_Standar.FRadioButton();
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
            this.fLabelBig1.Size = new System.Drawing.Size(223, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Reporte Balance";
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.rbtHospedaje);
            this.fGroupBox1.Controls.Add(this.rbtConsumo);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(19, 63);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(354, 79);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Rango de Fechas";
            // 
            // btnReporte
            // 
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.Location = new System.Drawing.Point(84, 155);
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
            this.btnSalir.Location = new System.Drawing.Point(206, 155);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 34);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // rbtConsumo
            // 
            this.rbtConsumo.AutoSize = true;
            this.rbtConsumo.BackColor = System.Drawing.Color.Transparent;
            this.rbtConsumo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtConsumo.Location = new System.Drawing.Point(37, 31);
            this.rbtConsumo.Name = "rbtConsumo";
            this.rbtConsumo.Size = new System.Drawing.Size(118, 19);
            this.rbtConsumo.TabIndex = 0;
            this.rbtConsumo.TabStop = true;
            this.rbtConsumo.Text = "Reporte Consumo";
            this.rbtConsumo.UseVisualStyleBackColor = false;
            // 
            // rbtHospedaje
            // 
            this.rbtHospedaje.AutoSize = true;
            this.rbtHospedaje.BackColor = System.Drawing.Color.Transparent;
            this.rbtHospedaje.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtHospedaje.Location = new System.Drawing.Point(187, 31);
            this.rbtHospedaje.Name = "rbtHospedaje";
            this.rbtHospedaje.Size = new System.Drawing.Size(124, 19);
            this.rbtHospedaje.TabIndex = 1;
            this.rbtHospedaje.TabStop = true;
            this.rbtHospedaje.Text = "Reporte Hospedaje";
            this.rbtHospedaje.UseVisualStyleBackColor = false;
            // 
            // FrmReporteBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 207);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReporteBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FButtonReporte btnReporte;
        private Controles_Standar.FButtonSalir btnSalir;
        private Controles_Standar.FRadioButton rbtHospedaje;
        private Controles_Standar.FRadioButton rbtConsumo;
    }
}