namespace CapaPresentacion.Configuracion
{
    partial class FrmConfReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfReservas));
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.txtSobreFactura = new Controles_Standar.FTextBoxDoubleRequerido();
            this.configuracionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fLabelMedium3 = new Controles_Standar.FLabelMedium();
            this.txtIGVActual = new Controles_Standar.FTextBoxDoubleRequerido();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.txtPrecioDelivery = new Controles_Standar.FTextBoxDoubleRequerido();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.fGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configuracionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.txtSobreFactura);
            this.fGroupBox1.Controls.Add(this.fLabelMedium3);
            this.fGroupBox1.Controls.Add(this.txtIGVActual);
            this.fGroupBox1.Controls.Add(this.fLabelMedium2);
            this.fGroupBox1.Controls.Add(this.txtPrecioDelivery);
            this.fGroupBox1.Controls.Add(this.fLabelMedium1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(20, 59);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(302, 183);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos de la Configuración";
            // 
            // txtSobreFactura
            // 
            this.txtSobreFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSobreFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSobreFactura.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configuracionBindingSource, "porcentaje_sobre_factura", true));
            this.txtSobreFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSobreFactura.Location = new System.Drawing.Point(19, 143);
            this.txtSobreFactura.Name = "txtSobreFactura";
            this.txtSobreFactura.Size = new System.Drawing.Size(255, 23);
            this.txtSobreFactura.TabIndex = 5;
            this.txtSobreFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSobreFactura_KeyPress);
            // 
            // configuracionBindingSource
            // 
            this.configuracionBindingSource.DataSource = typeof(CapaEntidades.Configuracion);
            // 
            // fLabelMedium3
            // 
            this.fLabelMedium3.AutoSize = true;
            this.fLabelMedium3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium3.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium3.Location = new System.Drawing.Point(15, 119);
            this.fLabelMedium3.Name = "fLabelMedium3";
            this.fLabelMedium3.Size = new System.Drawing.Size(175, 21);
            this.fLabelMedium3.TabIndex = 4;
            this.fLabelMedium3.Text = "Porcentaje Sobre Factura";
            // 
            // txtIGVActual
            // 
            this.txtIGVActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGVActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIGVActual.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configuracionBindingSource, "igv_actual", true));
            this.txtIGVActual.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGVActual.Location = new System.Drawing.Point(19, 93);
            this.txtIGVActual.Name = "txtIGVActual";
            this.txtIGVActual.Size = new System.Drawing.Size(255, 23);
            this.txtIGVActual.TabIndex = 3;
            this.txtIGVActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIGVActual_KeyPress);
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(15, 69);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(81, 21);
            this.fLabelMedium2.TabIndex = 2;
            this.fLabelMedium2.Text = "IGV Actual";
            // 
            // txtPrecioDelivery
            // 
            this.txtPrecioDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioDelivery.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrecioDelivery.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configuracionBindingSource, "precio_delivery", true));
            this.txtPrecioDelivery.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioDelivery.Location = new System.Drawing.Point(19, 43);
            this.txtPrecioDelivery.Name = "txtPrecioDelivery";
            this.txtPrecioDelivery.Size = new System.Drawing.Size(255, 23);
            this.txtPrecioDelivery.TabIndex = 1;
            this.txtPrecioDelivery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioDelivery_KeyPress);
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(15, 19);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(108, 21);
            this.fLabelMedium1.TabIndex = 0;
            this.fLabelMedium1.Text = "Precio Delivery";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(312, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Configurando Reservas";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(232, 248);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmConfReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 295);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfReservas_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configuracionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FTextBoxDoubleRequerido txtPrecioDelivery;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcategoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecategoriaDataGridViewTextBoxColumn;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private Controles_Standar.FTextBoxDoubleRequerido txtSobreFactura;
        private Controles_Standar.FLabelMedium fLabelMedium3;
        private Controles_Standar.FTextBoxDoubleRequerido txtIGVActual;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private System.Windows.Forms.BindingSource configuracionBindingSource;


    }
}