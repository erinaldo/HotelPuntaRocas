namespace CapaPresentacion.Ediciones
{
    partial class FrmEditarLiquidacionBoleta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarLiquidacionBoleta));
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.txtNombre = new Controles_Standar.FTextBox();
            this.fLabelMedium5 = new Controles_Standar.FLabelMedium();
            this.lblTotal = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium4 = new Controles_Standar.FLabelMedium();
            this.lblIGV = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium3 = new Controles_Standar.FLabelMedium();
            this.lblSubTotal = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium15 = new Controles_Standar.FLabelMedium();
            this.txtReferencia = new Controles_Standar.FTextBox();
            this.txtNTarjeta = new Controles_Standar.FTextBox();
            this.lblNTarjeta = new Controles_Standar.FLabelMedium();
            this.lblReferencia = new Controles_Standar.FLabelMedium();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtEfectivo = new Controles_Standar.FRadioButton();
            this.rbtTarjeta = new Controles_Standar.FRadioButton();
            this.txtComprobante = new Controles_Standar.FTextBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.txtSerie = new Controles_Standar.FTextBox();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.fGroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(275, 295);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.txtNombre);
            this.fGroupBox1.Controls.Add(this.fLabelMedium5);
            this.fGroupBox1.Controls.Add(this.lblTotal);
            this.fGroupBox1.Controls.Add(this.fLabelMedium4);
            this.fGroupBox1.Controls.Add(this.lblIGV);
            this.fGroupBox1.Controls.Add(this.fLabelMedium3);
            this.fGroupBox1.Controls.Add(this.lblSubTotal);
            this.fGroupBox1.Controls.Add(this.fLabelMedium15);
            this.fGroupBox1.Controls.Add(this.txtReferencia);
            this.fGroupBox1.Controls.Add(this.txtNTarjeta);
            this.fGroupBox1.Controls.Add(this.lblNTarjeta);
            this.fGroupBox1.Controls.Add(this.lblReferencia);
            this.fGroupBox1.Controls.Add(this.groupBox2);
            this.fGroupBox1.Controls.Add(this.txtComprobante);
            this.fGroupBox1.Controls.Add(this.fLabelMedium2);
            this.fGroupBox1.Controls.Add(this.txtSerie);
            this.fGroupBox1.Controls.Add(this.fLabelMedium1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(20, 59);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(441, 230);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos Edición";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(8, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(404, 23);
            this.txtNombre.TabIndex = 22;
            // 
            // fLabelMedium5
            // 
            this.fLabelMedium5.AutoSize = true;
            this.fLabelMedium5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium5.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium5.Location = new System.Drawing.Point(4, 19);
            this.fLabelMedium5.Name = "fLabelMedium5";
            this.fLabelMedium5.Size = new System.Drawing.Size(65, 21);
            this.fLabelMedium5.TabIndex = 21;
            this.fLabelMedium5.Text = "Nombre";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(10, 194);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 23);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblTotal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lblTotal_KeyDown);
            // 
            // fLabelMedium4
            // 
            this.fLabelMedium4.AutoSize = true;
            this.fLabelMedium4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium4.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium4.Location = new System.Drawing.Point(6, 173);
            this.fLabelMedium4.Name = "fLabelMedium4";
            this.fLabelMedium4.Size = new System.Drawing.Size(40, 21);
            this.fLabelMedium4.TabIndex = 19;
            this.fLabelMedium4.Text = "Total";
            // 
            // lblIGV
            // 
            this.lblIGV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIGV.Enabled = false;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIGV.Location = new System.Drawing.Point(8, 147);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(90, 23);
            this.lblIGV.TabIndex = 18;
            this.lblIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium3
            // 
            this.fLabelMedium3.AutoSize = true;
            this.fLabelMedium3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium3.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium3.Location = new System.Drawing.Point(6, 123);
            this.fLabelMedium3.Name = "fLabelMedium3";
            this.fLabelMedium3.Size = new System.Drawing.Size(35, 21);
            this.fLabelMedium3.TabIndex = 17;
            this.fLabelMedium3.Text = "IGV";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Enabled = false;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(10, 93);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(90, 23);
            this.lblSubTotal.TabIndex = 16;
            this.lblSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium15
            // 
            this.fLabelMedium15.AutoSize = true;
            this.fLabelMedium15.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium15.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium15.Location = new System.Drawing.Point(6, 69);
            this.fLabelMedium15.Name = "fLabelMedium15";
            this.fLabelMedium15.Size = new System.Drawing.Size(66, 21);
            this.fLabelMedium15.TabIndex = 15;
            this.fLabelMedium15.Text = "SubTotal";
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(140, 147);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(136, 23);
            this.txtReferencia.TabIndex = 12;
            this.txtReferencia.Visible = false;
            // 
            // txtNTarjeta
            // 
            this.txtNTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNTarjeta.Location = new System.Drawing.Point(282, 147);
            this.txtNTarjeta.Name = "txtNTarjeta";
            this.txtNTarjeta.Size = new System.Drawing.Size(130, 23);
            this.txtNTarjeta.TabIndex = 14;
            this.txtNTarjeta.Visible = false;
            // 
            // lblNTarjeta
            // 
            this.lblNTarjeta.AutoSize = true;
            this.lblNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTarjeta.ForeColor = System.Drawing.Color.Black;
            this.lblNTarjeta.Location = new System.Drawing.Point(278, 123);
            this.lblNTarjeta.Name = "lblNTarjeta";
            this.lblNTarjeta.Size = new System.Drawing.Size(73, 21);
            this.lblNTarjeta.TabIndex = 13;
            this.lblNTarjeta.Text = "N° Tarjeta";
            this.lblNTarjeta.Visible = false;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.ForeColor = System.Drawing.Color.Black;
            this.lblReferencia.Location = new System.Drawing.Point(136, 123);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(79, 21);
            this.lblReferencia.TabIndex = 11;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtEfectivo);
            this.groupBox2.Controls.Add(this.rbtTarjeta);
            this.groupBox2.Location = new System.Drawing.Point(140, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 43);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Pago";
            // 
            // rbtEfectivo
            // 
            this.rbtEfectivo.AutoSize = true;
            this.rbtEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.rbtEfectivo.Checked = true;
            this.rbtEfectivo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtEfectivo.Location = new System.Drawing.Point(30, 22);
            this.rbtEfectivo.Name = "rbtEfectivo";
            this.rbtEfectivo.Size = new System.Drawing.Size(92, 19);
            this.rbtEfectivo.TabIndex = 0;
            this.rbtEfectivo.TabStop = true;
            this.rbtEfectivo.Text = "Pago Efectivo";
            this.rbtEfectivo.UseVisualStyleBackColor = false;
            this.rbtEfectivo.CheckedChanged += new System.EventHandler(this.rbtEfectivo_CheckedChanged);
            // 
            // rbtTarjeta
            // 
            this.rbtTarjeta.AutoSize = true;
            this.rbtTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.rbtTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTarjeta.Location = new System.Drawing.Point(128, 22);
            this.rbtTarjeta.Name = "rbtTarjeta";
            this.rbtTarjeta.Size = new System.Drawing.Size(86, 19);
            this.rbtTarjeta.TabIndex = 1;
            this.rbtTarjeta.TabStop = true;
            this.rbtTarjeta.Text = "Pago Tarjeta";
            this.rbtTarjeta.UseVisualStyleBackColor = false;
            this.rbtTarjeta.CheckedChanged += new System.EventHandler(this.rbtTarjeta_CheckedChanged);
            // 
            // txtComprobante
            // 
            this.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComprobante.Location = new System.Drawing.Point(202, 93);
            this.txtComprobante.MaxLength = 8;
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(144, 23);
            this.txtComprobante.TabIndex = 9;
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(198, 69);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(125, 21);
            this.fLabelMedium2.TabIndex = 8;
            this.fLabelMedium2.Text = "N° Comprobante";
            // 
            // txtSerie
            // 
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(140, 93);
            this.txtSerie.MaxLength = 4;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(56, 23);
            this.txtSerie.TabIndex = 7;
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(136, 69);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(42, 21);
            this.fLabelMedium1.TabIndex = 6;
            this.fLabelMedium1.Text = "Serie";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(274, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Editar Comprobante";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(371, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmEditarLiquidacionBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 339);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarLiquidacionBoleta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmEditarLiquidacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConcepto_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecategoriaDataGridViewTextBoxColumn;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FTextBox txtComprobante;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FTextBox txtSerie;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FTextBox txtReferencia;
        private Controles_Standar.FTextBox txtNTarjeta;
        private Controles_Standar.FLabelMedium lblNTarjeta;
        private Controles_Standar.FLabelMedium lblReferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controles_Standar.FRadioButton rbtEfectivo;
        private Controles_Standar.FRadioButton rbtTarjeta;
        private Controles_Standar.FTextBoxDouble lblTotal;
        private Controles_Standar.FLabelMedium fLabelMedium4;
        private Controles_Standar.FTextBoxDouble lblIGV;
        private Controles_Standar.FLabelMedium fLabelMedium3;
        private Controles_Standar.FTextBoxDouble lblSubTotal;
        private Controles_Standar.FLabelMedium fLabelMedium15;
        private Controles_Standar.FTextBox txtNombre;
        private Controles_Standar.FLabelMedium fLabelMedium5;
    }
}