namespace CapaPresentacion.Reserva
{
    partial class FrmTipoPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoPago));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fRadioButton1 = new Controles_Standar.FRadioButton();
            this.rbtBoleta = new Controles_Standar.FRadioButton();
            this.rbtFactura = new Controles_Standar.FRadioButton();
            this.btnReservar = new Controles_Standar.FButtonAceptar();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fRadioButton1);
            this.groupBox1.Controls.Add(this.rbtBoleta);
            this.groupBox1.Controls.Add(this.rbtFactura);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Comprobante";
            // 
            // fRadioButton1
            // 
            this.fRadioButton1.AutoSize = true;
            this.fRadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.fRadioButton1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fRadioButton1.Location = new System.Drawing.Point(201, 22);
            this.fRadioButton1.Name = "fRadioButton1";
            this.fRadioButton1.Size = new System.Drawing.Size(113, 19);
            this.fRadioButton1.TabIndex = 2;
            this.fRadioButton1.TabStop = true;
            this.fRadioButton1.Text = "Sin Comprobante";
            this.fRadioButton1.UseVisualStyleBackColor = false;
            // 
            // rbtBoleta
            // 
            this.rbtBoleta.AutoSize = true;
            this.rbtBoleta.BackColor = System.Drawing.Color.Transparent;
            this.rbtBoleta.Checked = true;
            this.rbtBoleta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtBoleta.Location = new System.Drawing.Point(9, 22);
            this.rbtBoleta.Name = "rbtBoleta";
            this.rbtBoleta.Size = new System.Drawing.Size(88, 19);
            this.rbtBoleta.TabIndex = 0;
            this.rbtBoleta.TabStop = true;
            this.rbtBoleta.Text = "Emitir Boleta";
            this.rbtBoleta.UseVisualStyleBackColor = false;
            // 
            // rbtFactura
            // 
            this.rbtFactura.AutoSize = true;
            this.rbtFactura.BackColor = System.Drawing.Color.Transparent;
            this.rbtFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFactura.Location = new System.Drawing.Point(103, 22);
            this.rbtFactura.Name = "rbtFactura";
            this.rbtFactura.Size = new System.Drawing.Size(92, 19);
            this.rbtFactura.TabIndex = 1;
            this.rbtFactura.TabStop = true;
            this.rbtFactura.Text = "Emitir Factura";
            this.rbtFactura.UseVisualStyleBackColor = false;
            // 
            // btnReservar
            // 
            this.btnReservar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReservar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservar.Image = ((System.Drawing.Image)(resources.GetObject("btnReservar.Image")));
            this.btnReservar.Location = new System.Drawing.Point(83, 79);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(90, 34);
            this.btnReservar.TabIndex = 6;
            this.btnReservar.Text = "Efectuar";
            this.btnReservar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReservar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(179, 79);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmTipoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 131);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmTipoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTipoPago_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FRadioButton fRadioButton1;
        private Controles_Standar.FRadioButton rbtBoleta;
        private Controles_Standar.FRadioButton rbtFactura;
        private Controles_Standar.FButtonAceptar btnReservar;
        private Controles_Standar.FButtonCancelar btnCancelar;
    }
}