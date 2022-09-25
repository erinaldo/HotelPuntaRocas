namespace CapaPresentacion.Reserva
{
    partial class FrmReservaFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReservaFacturacion));
            this.btnPagar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fRadioButton1 = new Controles_Standar.FRadioButton();
            this.rbtBoleta = new Controles_Standar.FRadioButton();
            this.rbtFactura = new Controles_Standar.FRadioButton();
            this.fGroupBox5 = new Controles_Standar.FGroupBox();
            this.txtAumento = new Controles_Standar.FTextBoxDouble();
            this.chkAumento = new Controles_Standar.FCheckBox();
            this.btnImprimir = new Controles_Standar.FButtonImprimir();
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.chkConsumo = new Controles_Standar.FCheckBox();
            this.chkSoloFactura = new Controles_Standar.FCheckBox();
            this.txtLavanderia = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium3 = new Controles_Standar.FLabelMedium();
            this.txtReferencia = new Controles_Standar.FTextBox();
            this.txtDescuento = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium10 = new Controles_Standar.FLabelMedium();
            this.chkHospedaje = new Controles_Standar.FCheckBox();
            this.txtNTarjeta = new Controles_Standar.FTextBox();
            this.lblNTarjeta = new Controles_Standar.FLabelMedium();
            this.lblReferencia = new Controles_Standar.FLabelMedium();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtEfectivo = new Controles_Standar.FRadioButton();
            this.rbtTarjeta = new Controles_Standar.FRadioButton();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.lblSaldoPago = new Controles_Standar.FTextBoxDouble();
            this.lblConsumoTotal = new Controles_Standar.FTextBoxDouble();
            this.lblConsumoPago = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium11 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium9 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium13 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium8 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.lblNeto = new Controles_Standar.FTextBoxDouble();
            this.lblACuenta = new Controles_Standar.FTextBoxDouble();
            this.lblTotal = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium19 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium17 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium15 = new Controles_Standar.FLabelMedium();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.lblHospedaje = new Controles_Standar.FTextBoxDouble();
            this.lblDiasDeHospedaje = new Controles_Standar.FTextBoxDouble();
            this.lblMontoTarifa = new Controles_Standar.FTextBoxDouble();
            this.fLabelMedium6 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium4 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.btnMontoACuenta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.fGroupBox5.SuspendLayout();
            this.fGroupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.fGroupBox1.SuspendLayout();
            this.fGroupBox2.SuspendLayout();
            this.fGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnPagar.Image = global::CapaPresentacion.Properties.Resources.facturacion;
            this.btnPagar.Location = new System.Drawing.Point(891, 241);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(103, 34);
            this.btnPagar.TabIndex = 9;
            this.btnPagar.Text = "Pago Parcial";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fRadioButton1);
            this.groupBox1.Controls.Add(this.rbtBoleta);
            this.groupBox1.Controls.Add(this.rbtFactura);
            this.groupBox1.Location = new System.Drawing.Point(870, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Comprobante";
            this.groupBox1.Visible = false;
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
            this.rbtBoleta.CheckedChanged += new System.EventHandler(this.rbtBoleta_CheckedChanged);
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
            // fGroupBox5
            // 
            this.fGroupBox5.Controls.Add(this.txtAumento);
            this.fGroupBox5.Controls.Add(this.chkAumento);
            this.fGroupBox5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox5.Location = new System.Drawing.Point(604, 216);
            this.fGroupBox5.Name = "fGroupBox5";
            this.fGroupBox5.Size = new System.Drawing.Size(254, 72);
            this.fGroupBox5.TabIndex = 7;
            this.fGroupBox5.TabStop = false;
            this.fGroupBox5.Text = "Datos del comprobante";
            this.fGroupBox5.Enter += new System.EventHandler(this.fGroupBox5_Enter);
            // 
            // txtAumento
            // 
            this.txtAumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAumento.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAumento.Location = new System.Drawing.Point(176, 30);
            this.txtAumento.Name = "txtAumento";
            this.txtAumento.Size = new System.Drawing.Size(62, 23);
            this.txtAumento.TabIndex = 1;
            this.txtAumento.Text = "0";
            this.txtAumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAumento.Visible = false;
            this.txtAumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAumento_KeyPress);
            // 
            // chkAumento
            // 
            this.chkAumento.AutoSize = true;
            this.chkAumento.BackColor = System.Drawing.Color.Transparent;
            this.chkAumento.FlatAppearance.BorderSize = 0;
            this.chkAumento.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAumento.ForeColor = System.Drawing.Color.Black;
            this.chkAumento.Location = new System.Drawing.Point(28, 32);
            this.chkAumento.Name = "chkAumento";
            this.chkAumento.Size = new System.Drawing.Size(95, 19);
            this.chkAumento.TabIndex = 0;
            this.chkAumento.Text = "Sobre Factura";
            this.chkAumento.UseVisualStyleBackColor = false;
            this.chkAumento.CheckedChanged += new System.EventHandler(this.fCheckBox1_CheckedChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(1000, 239);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 34);
            this.btnImprimir.TabIndex = 8;
            this.btnImprimir.Tag = "";
            this.btnImprimir.Text = "Liquidar";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.chkConsumo);
            this.fGroupBox4.Controls.Add(this.chkSoloFactura);
            this.fGroupBox4.Controls.Add(this.txtLavanderia);
            this.fGroupBox4.Controls.Add(this.fLabelMedium3);
            this.fGroupBox4.Controls.Add(this.txtReferencia);
            this.fGroupBox4.Controls.Add(this.txtDescuento);
            this.fGroupBox4.Controls.Add(this.fLabelMedium10);
            this.fGroupBox4.Controls.Add(this.chkHospedaje);
            this.fGroupBox4.Controls.Add(this.txtNTarjeta);
            this.fGroupBox4.Controls.Add(this.lblNTarjeta);
            this.fGroupBox4.Controls.Add(this.lblReferencia);
            this.fGroupBox4.Controls.Add(this.groupBox2);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(604, 64);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(588, 146);
            this.fGroupBox4.TabIndex = 5;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Datos del comprobante";
            // 
            // chkConsumo
            // 
            this.chkConsumo.AutoSize = true;
            this.chkConsumo.BackColor = System.Drawing.Color.Transparent;
            this.chkConsumo.FlatAppearance.BorderSize = 0;
            this.chkConsumo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsumo.ForeColor = System.Drawing.Color.Black;
            this.chkConsumo.Location = new System.Drawing.Point(176, 108);
            this.chkConsumo.Name = "chkConsumo";
            this.chkConsumo.Size = new System.Drawing.Size(146, 19);
            this.chkConsumo.TabIndex = 10;
            this.chkConsumo.Text = "¿Cobrar solo Consumo?";
            this.chkConsumo.UseVisualStyleBackColor = false;
            this.chkConsumo.CheckedChanged += new System.EventHandler(this.chkConsumo_CheckedChanged);
            // 
            // chkSoloFactura
            // 
            this.chkSoloFactura.AutoSize = true;
            this.chkSoloFactura.BackColor = System.Drawing.Color.Transparent;
            this.chkSoloFactura.FlatAppearance.BorderSize = 0;
            this.chkSoloFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoloFactura.ForeColor = System.Drawing.Color.Black;
            this.chkSoloFactura.Location = new System.Drawing.Point(23, 84);
            this.chkSoloFactura.Name = "chkSoloFactura";
            this.chkSoloFactura.Size = new System.Drawing.Size(135, 19);
            this.chkSoloFactura.TabIndex = 3;
            this.chkSoloFactura.Text = "Factura sin Hospedaje";
            this.chkSoloFactura.UseVisualStyleBackColor = false;
            this.chkSoloFactura.CheckedChanged += new System.EventHandler(this.chkSoloFactura_CheckedChanged);
            // 
            // txtLavanderia
            // 
            this.txtLavanderia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLavanderia.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLavanderia.Location = new System.Drawing.Point(361, 104);
            this.txtLavanderia.Name = "txtLavanderia";
            this.txtLavanderia.Size = new System.Drawing.Size(90, 23);
            this.txtLavanderia.TabIndex = 7;
            this.txtLavanderia.Text = "0";
            this.txtLavanderia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium3
            // 
            this.fLabelMedium3.AutoSize = true;
            this.fLabelMedium3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium3.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium3.Location = new System.Drawing.Point(357, 78);
            this.fLabelMedium3.Name = "fLabelMedium3";
            this.fLabelMedium3.Size = new System.Drawing.Size(82, 21);
            this.fLabelMedium3.TabIndex = 6;
            this.fLabelMedium3.Text = "Lavanderia";
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(22, 51);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(136, 23);
            this.txtReferencia.TabIndex = 3;
            this.txtReferencia.Visible = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(479, 104);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(90, 23);
            this.txtDescuento.TabIndex = 9;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // fLabelMedium10
            // 
            this.fLabelMedium10.AutoSize = true;
            this.fLabelMedium10.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium10.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium10.Location = new System.Drawing.Point(475, 80);
            this.fLabelMedium10.Name = "fLabelMedium10";
            this.fLabelMedium10.Size = new System.Drawing.Size(82, 21);
            this.fLabelMedium10.TabIndex = 8;
            this.fLabelMedium10.Text = "Descuento";
            // 
            // chkHospedaje
            // 
            this.chkHospedaje.AutoSize = true;
            this.chkHospedaje.BackColor = System.Drawing.Color.Transparent;
            this.chkHospedaje.FlatAppearance.BorderSize = 0;
            this.chkHospedaje.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHospedaje.ForeColor = System.Drawing.Color.Black;
            this.chkHospedaje.Location = new System.Drawing.Point(23, 108);
            this.chkHospedaje.Name = "chkHospedaje";
            this.chkHospedaje.Size = new System.Drawing.Size(152, 19);
            this.chkHospedaje.TabIndex = 4;
            this.chkHospedaje.Text = "¿Cobrar solo Hospedaje?";
            this.chkHospedaje.UseVisualStyleBackColor = false;
            this.chkHospedaje.CheckedChanged += new System.EventHandler(this.chkHuesped_CheckedChanged);
            // 
            // txtNTarjeta
            // 
            this.txtNTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNTarjeta.Location = new System.Drawing.Point(164, 51);
            this.txtNTarjeta.Name = "txtNTarjeta";
            this.txtNTarjeta.Size = new System.Drawing.Size(130, 23);
            this.txtNTarjeta.TabIndex = 5;
            this.txtNTarjeta.Visible = false;
            // 
            // lblNTarjeta
            // 
            this.lblNTarjeta.AutoSize = true;
            this.lblNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTarjeta.ForeColor = System.Drawing.Color.Black;
            this.lblNTarjeta.Location = new System.Drawing.Point(160, 27);
            this.lblNTarjeta.Name = "lblNTarjeta";
            this.lblNTarjeta.Size = new System.Drawing.Size(73, 21);
            this.lblNTarjeta.TabIndex = 4;
            this.lblNTarjeta.Text = "N° Tarjeta";
            this.lblNTarjeta.Visible = false;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.ForeColor = System.Drawing.Color.Black;
            this.lblReferencia.Location = new System.Drawing.Point(18, 27);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(79, 21);
            this.lblReferencia.TabIndex = 2;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtEfectivo);
            this.groupBox2.Controls.Add(this.rbtTarjeta);
            this.groupBox2.Location = new System.Drawing.Point(343, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 48);
            this.groupBox2.TabIndex = 1;
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
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.lblSaldoPago);
            this.fGroupBox1.Controls.Add(this.lblConsumoTotal);
            this.fGroupBox1.Controls.Add(this.lblConsumoPago);
            this.fGroupBox1.Controls.Add(this.fLabelMedium11);
            this.fGroupBox1.Controls.Add(this.fLabelMedium9);
            this.fGroupBox1.Controls.Add(this.fLabelMedium13);
            this.fGroupBox1.Controls.Add(this.fLabelMedium8);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(306, 64);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(274, 146);
            this.fGroupBox1.TabIndex = 2;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Detalle de Consumo";
            // 
            // lblSaldoPago
            // 
            this.lblSaldoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldoPago.Enabled = false;
            this.lblSaldoPago.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoPago.Location = new System.Drawing.Point(163, 100);
            this.lblSaldoPago.Name = "lblSaldoPago";
            this.lblSaldoPago.Size = new System.Drawing.Size(78, 23);
            this.lblSaldoPago.TabIndex = 6;
            this.lblSaldoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblConsumoTotal
            // 
            this.lblConsumoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsumoTotal.Enabled = false;
            this.lblConsumoTotal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumoTotal.Location = new System.Drawing.Point(163, 24);
            this.lblConsumoTotal.Name = "lblConsumoTotal";
            this.lblConsumoTotal.Size = new System.Drawing.Size(78, 23);
            this.lblConsumoTotal.TabIndex = 1;
            this.lblConsumoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblConsumoPago
            // 
            this.lblConsumoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsumoPago.Enabled = false;
            this.lblConsumoPago.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumoPago.Location = new System.Drawing.Point(163, 54);
            this.lblConsumoPago.Name = "lblConsumoPago";
            this.lblConsumoPago.Size = new System.Drawing.Size(78, 23);
            this.lblConsumoPago.TabIndex = 3;
            this.lblConsumoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium11
            // 
            this.fLabelMedium11.AutoSize = true;
            this.fLabelMedium11.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium11.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium11.Location = new System.Drawing.Point(151, 80);
            this.fLabelMedium11.Name = "fLabelMedium11";
            this.fLabelMedium11.Size = new System.Drawing.Size(100, 21);
            this.fLabelMedium11.TabIndex = 4;
            this.fLabelMedium11.Text = "=========";
            // 
            // fLabelMedium9
            // 
            this.fLabelMedium9.AutoSize = true;
            this.fLabelMedium9.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium9.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium9.Location = new System.Drawing.Point(26, 57);
            this.fLabelMedium9.Name = "fLabelMedium9";
            this.fLabelMedium9.Size = new System.Drawing.Size(130, 21);
            this.fLabelMedium9.TabIndex = 2;
            this.fLabelMedium9.Text = "Consumo Pagado";
            // 
            // fLabelMedium13
            // 
            this.fLabelMedium13.AutoSize = true;
            this.fLabelMedium13.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium13.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium13.Location = new System.Drawing.Point(24, 101);
            this.fLabelMedium13.Name = "fLabelMedium13";
            this.fLabelMedium13.Size = new System.Drawing.Size(116, 21);
            this.fLabelMedium13.TabIndex = 5;
            this.fLabelMedium13.Text = "Saldo por Pagar";
            // 
            // fLabelMedium8
            // 
            this.fLabelMedium8.AutoSize = true;
            this.fLabelMedium8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium8.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium8.Location = new System.Drawing.Point(26, 29);
            this.fLabelMedium8.Name = "fLabelMedium8";
            this.fLabelMedium8.Size = new System.Drawing.Size(113, 21);
            this.fLabelMedium8.TabIndex = 0;
            this.fLabelMedium8.Text = "Consumo Total:";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(8, 15);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(316, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Resumen de Habitación";
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.lblNeto);
            this.fGroupBox2.Controls.Add(this.lblACuenta);
            this.fGroupBox2.Controls.Add(this.lblTotal);
            this.fGroupBox2.Controls.Add(this.fLabelMedium19);
            this.fGroupBox2.Controls.Add(this.fLabelMedium17);
            this.fGroupBox2.Controls.Add(this.fLabelMedium15);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(15, 216);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(565, 72);
            this.fGroupBox2.TabIndex = 6;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Detalle de Hospedaje";
            // 
            // lblNeto
            // 
            this.lblNeto.BackColor = System.Drawing.Color.DarkSalmon;
            this.lblNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNeto.Enabled = false;
            this.lblNeto.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeto.ForeColor = System.Drawing.Color.White;
            this.lblNeto.Location = new System.Drawing.Point(379, 39);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(115, 23);
            this.lblNeto.TabIndex = 5;
            this.lblNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblACuenta
            // 
            this.lblACuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblACuenta.Enabled = false;
            this.lblACuenta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACuenta.Location = new System.Drawing.Point(233, 39);
            this.lblACuenta.Name = "lblACuenta";
            this.lblACuenta.Size = new System.Drawing.Size(78, 23);
            this.lblACuenta.TabIndex = 3;
            this.lblACuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblACuenta.TextChanged += new System.EventHandler(this.lblACuenta_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Enabled = false;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(74, 39);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 23);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium19
            // 
            this.fLabelMedium19.AutoSize = true;
            this.fLabelMedium19.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium19.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium19.Location = new System.Drawing.Point(377, 17);
            this.fLabelMedium19.Name = "fLabelMedium19";
            this.fLabelMedium19.Size = new System.Drawing.Size(119, 21);
            this.fLabelMedium19.TabIndex = 4;
            this.fLabelMedium19.Text = "Total a Cancelar:";
            // 
            // fLabelMedium17
            // 
            this.fLabelMedium17.AutoSize = true;
            this.fLabelMedium17.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium17.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium17.Location = new System.Drawing.Point(236, 17);
            this.fLabelMedium17.Name = "fLabelMedium17";
            this.fLabelMedium17.Size = new System.Drawing.Size(77, 21);
            this.fLabelMedium17.TabIndex = 2;
            this.fLabelMedium17.Text = "A Cuenta:";
            // 
            // fLabelMedium15
            // 
            this.fLabelMedium15.AutoSize = true;
            this.fLabelMedium15.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium15.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium15.Location = new System.Drawing.Point(72, 17);
            this.fLabelMedium15.Name = "fLabelMedium15";
            this.fLabelMedium15.Size = new System.Drawing.Size(94, 21);
            this.fLabelMedium15.TabIndex = 0;
            this.fLabelMedium15.Text = "Total a Pagar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1096, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.lblHospedaje);
            this.fGroupBox3.Controls.Add(this.lblDiasDeHospedaje);
            this.fGroupBox3.Controls.Add(this.lblMontoTarifa);
            this.fGroupBox3.Controls.Add(this.fLabelMedium6);
            this.fGroupBox3.Controls.Add(this.fLabelMedium4);
            this.fGroupBox3.Controls.Add(this.fLabelMedium2);
            this.fGroupBox3.Controls.Add(this.fLabelMedium1);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(16, 65);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(284, 145);
            this.fGroupBox3.TabIndex = 1;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Datos de Hospedaje";
            // 
            // lblHospedaje
            // 
            this.lblHospedaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHospedaje.Enabled = false;
            this.lblHospedaje.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHospedaje.Location = new System.Drawing.Point(173, 99);
            this.lblHospedaje.Name = "lblHospedaje";
            this.lblHospedaje.Size = new System.Drawing.Size(78, 23);
            this.lblHospedaje.TabIndex = 6;
            this.lblHospedaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDiasDeHospedaje
            // 
            this.lblDiasDeHospedaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDiasDeHospedaje.Enabled = false;
            this.lblDiasDeHospedaje.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasDeHospedaje.Location = new System.Drawing.Point(173, 23);
            this.lblDiasDeHospedaje.Name = "lblDiasDeHospedaje";
            this.lblDiasDeHospedaje.Size = new System.Drawing.Size(78, 23);
            this.lblDiasDeHospedaje.TabIndex = 1;
            this.lblDiasDeHospedaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMontoTarifa
            // 
            this.lblMontoTarifa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMontoTarifa.Enabled = false;
            this.lblMontoTarifa.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoTarifa.Location = new System.Drawing.Point(173, 53);
            this.lblMontoTarifa.Name = "lblMontoTarifa";
            this.lblMontoTarifa.Size = new System.Drawing.Size(78, 23);
            this.lblMontoTarifa.TabIndex = 3;
            this.lblMontoTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium6
            // 
            this.fLabelMedium6.AutoSize = true;
            this.fLabelMedium6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium6.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium6.Location = new System.Drawing.Point(166, 77);
            this.fLabelMedium6.Name = "fLabelMedium6";
            this.fLabelMedium6.Size = new System.Drawing.Size(90, 21);
            this.fLabelMedium6.TabIndex = 4;
            this.fLabelMedium6.Text = "========";
            // 
            // fLabelMedium4
            // 
            this.fLabelMedium4.AutoSize = true;
            this.fLabelMedium4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium4.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium4.Location = new System.Drawing.Point(31, 96);
            this.fLabelMedium4.Name = "fLabelMedium4";
            this.fLabelMedium4.Size = new System.Drawing.Size(115, 21);
            this.fLabelMedium4.TabIndex = 5;
            this.fLabelMedium4.Text = "Total Hospedaje";
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(29, 52);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(136, 21);
            this.fLabelMedium2.TabIndex = 2;
            this.fLabelMedium2.Text = "Tarifa seleccionada:";
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(29, 24);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(138, 21);
            this.fLabelMedium1.TabIndex = 0;
            this.fLabelMedium1.Text = "Dias de Hospedaje:";
            // 
            // btnMontoACuenta
            // 
            this.btnMontoACuenta.BackColor = System.Drawing.Color.LightGray;
            this.btnMontoACuenta.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnMontoACuenta.ForeColor = System.Drawing.Color.Black;
            this.btnMontoACuenta.Image = global::CapaPresentacion.Properties.Resources.facturacion;
            this.btnMontoACuenta.Location = new System.Drawing.Point(870, 241);
            this.btnMontoACuenta.Name = "btnMontoACuenta";
            this.btnMontoACuenta.Size = new System.Drawing.Size(124, 34);
            this.btnMontoACuenta.TabIndex = 27;
            this.btnMontoACuenta.Text = "Monto a Cuenta";
            this.btnMontoACuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMontoACuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMontoACuenta.UseVisualStyleBackColor = false;
            this.btnMontoACuenta.Visible = false;
            this.btnMontoACuenta.Click += new System.EventHandler(this.btnMontoACuenta_Click);
            // 
            // FrmReservaFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 300);
            this.Controls.Add(this.btnMontoACuenta);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.fGroupBox5);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.fGroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReservaFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Sistema Hotel -Resumen .::.";
            this.Load += new System.EventHandler(this.FrmReservaFacturacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReservaFacturacion_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.fGroupBox5.ResumeLayout(false);
            this.fGroupBox5.PerformLayout();
            this.fGroupBox4.ResumeLayout(false);
            this.fGroupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.fGroupBox2.ResumeLayout(false);
            this.fGroupBox2.PerformLayout();
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FTextBoxDouble txtAumento;
        private Controles_Standar.FTextBox txtReferencia;
        private Controles_Standar.FRadioButton rbtEfectivo;
        private Controles_Standar.FRadioButton rbtTarjeta;
        private Controles_Standar.FButtonImprimir btnImprimir;
        private Controles_Standar.FCheckBox chkAumento;
        private Controles_Standar.FGroupBox fGroupBox4;
        private Controles_Standar.FTextBoxDouble txtDescuento;
        private Controles_Standar.FLabelMedium fLabelMedium10;
        private Controles_Standar.FTextBox txtNTarjeta;
        private Controles_Standar.FLabelMedium lblNTarjeta;
        private Controles_Standar.FLabelMedium lblReferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controles_Standar.FCheckBox chkHospedaje;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FLabelMedium fLabelMedium11;
        private Controles_Standar.FLabelMedium fLabelMedium9;
        private Controles_Standar.FLabelMedium fLabelMedium13;
        private Controles_Standar.FLabelMedium fLabelMedium8;
        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FLabelMedium fLabelMedium19;
        private Controles_Standar.FLabelMedium fLabelMedium17;
        private Controles_Standar.FLabelMedium fLabelMedium15;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FGroupBox fGroupBox3;
        private Controles_Standar.FLabelMedium fLabelMedium6;
        private Controles_Standar.FLabelMedium fLabelMedium4;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FTextBoxDouble lblMontoTarifa;
        private Controles_Standar.FTextBoxDouble lblHospedaje;
        private Controles_Standar.FTextBoxDouble lblDiasDeHospedaje;
        private Controles_Standar.FTextBoxDouble lblSaldoPago;
        private Controles_Standar.FTextBoxDouble lblConsumoTotal;
        private Controles_Standar.FTextBoxDouble lblConsumoPago;
        private Controles_Standar.FTextBoxDouble lblNeto;
        private Controles_Standar.FTextBoxDouble lblACuenta;
        private Controles_Standar.FTextBoxDouble lblTotal;
        private Controles_Standar.FLabelMedium fLabelMedium3;
        private Controles_Standar.FGroupBox fGroupBox5;
        private Controles_Standar.FTextBoxDouble txtLavanderia;
        private Controles_Standar.FCheckBox chkSoloFactura;
        private System.Windows.Forms.Button btnPagar;
        private Controles_Standar.FRadioButton rbtFactura;
        private Controles_Standar.FRadioButton rbtBoleta;
        private Controles_Standar.FRadioButton fRadioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FCheckBox chkConsumo;
        private System.Windows.Forms.Button btnMontoACuenta;

    }
}