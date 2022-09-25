namespace CapaPresentacion.Flujo_Caja
{
    partial class FrmCierre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierre));
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.lblAdelantos = new Controles_Standar.FLabelMedium();
            this.lblTotalDia = new Controles_Standar.FLabelMedium();
            this.fLabelSmall4 = new Controles_Standar.FLabelSmall();
            this.fLabelMedium11 = new Controles_Standar.FLabelMedium();
            this.fLabelSmall10 = new Controles_Standar.FLabelSmall();
            this.lblAdicional = new Controles_Standar.FLabelMedium();
            this.lblTarjeta = new Controles_Standar.FLabelMedium();
            this.fLabelSmall5 = new Controles_Standar.FLabelSmall();
            this.lblEfectivo = new Controles_Standar.FLabelMedium();
            this.fLabelSmall7 = new Controles_Standar.FLabelSmall();
            this.fLabelSmall8 = new Controles_Standar.FLabelSmall();
            this.fGroupBox4 = new Controles_Standar.FGroupBox();
            this.lblDescuentos = new Controles_Standar.FLabelMedium();
            this.fLabelSmall11 = new Controles_Standar.FLabelSmall();
            this.lblEgresos = new Controles_Standar.FLabelMedium();
            this.fLabelSmall3 = new Controles_Standar.FLabelSmall();
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.txtCierre = new Controles_Standar.FTextBoxDoubleRequerido();
            this.fLabelSmall1 = new Controles_Standar.FLabelSmall();
            this.txtApertura = new Controles_Standar.FTextBoxDoubleRequerido();
            this.fLabelSmall2 = new Controles_Standar.FLabelSmall();
            this.fGroupBox6 = new Controles_Standar.FGroupBox();
            this.lblConsumo = new Controles_Standar.FLabelMedium();
            this.lblHospedaje = new Controles_Standar.FLabelMedium();
            this.fLabelSmall6 = new Controles_Standar.FLabelSmall();
            this.fLabelSmall9 = new Controles_Standar.FLabelSmall();
            this.fGroupBox1.SuspendLayout();
            this.fGroupBox4.SuspendLayout();
            this.fGroupBox2.SuspendLayout();
            this.fGroupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 5);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(195, 41);
            this.fLabelBig1.TabIndex = 1;
            this.fLabelBig1.Text = "Cierre de Caja";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(586, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(472, 150);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Cerrar Caja";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.lblAdelantos);
            this.fGroupBox1.Controls.Add(this.lblTotalDia);
            this.fGroupBox1.Controls.Add(this.fLabelSmall4);
            this.fGroupBox1.Controls.Add(this.fLabelMedium11);
            this.fGroupBox1.Controls.Add(this.fLabelSmall10);
            this.fGroupBox1.Controls.Add(this.lblAdicional);
            this.fGroupBox1.Controls.Add(this.lblTarjeta);
            this.fGroupBox1.Controls.Add(this.fLabelSmall5);
            this.fGroupBox1.Controls.Add(this.lblEfectivo);
            this.fGroupBox1.Controls.Add(this.fLabelSmall7);
            this.fGroupBox1.Controls.Add(this.fLabelSmall8);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(19, 60);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(214, 168);
            this.fGroupBox1.TabIndex = 8;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Detallado de Ingresos";
            // 
            // lblAdelantos
            // 
            this.lblAdelantos.AutoSize = true;
            this.lblAdelantos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdelantos.ForeColor = System.Drawing.Color.Black;
            this.lblAdelantos.Location = new System.Drawing.Point(120, 90);
            this.lblAdelantos.Name = "lblAdelantos";
            this.lblAdelantos.Size = new System.Drawing.Size(80, 21);
            this.lblAdelantos.TabIndex = 14;
            this.lblAdelantos.Text = "S/. XXX.00";
            // 
            // lblTotalDia
            // 
            this.lblTotalDia.AutoSize = true;
            this.lblTotalDia.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDia.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDia.Location = new System.Drawing.Point(120, 132);
            this.lblTotalDia.Name = "lblTotalDia";
            this.lblTotalDia.Size = new System.Drawing.Size(80, 21);
            this.lblTotalDia.TabIndex = 16;
            this.lblTotalDia.Text = "S/. XXX.00";
            // 
            // fLabelSmall4
            // 
            this.fLabelSmall4.AutoSize = true;
            this.fLabelSmall4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall4.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall4.Location = new System.Drawing.Point(15, 94);
            this.fLabelSmall4.Name = "fLabelSmall4";
            this.fLabelSmall4.Size = new System.Drawing.Size(93, 15);
            this.fLabelSmall4.TabIndex = 13;
            this.fLabelSmall4.Text = "Montos a Cuenta";
            // 
            // fLabelMedium11
            // 
            this.fLabelMedium11.AutoSize = true;
            this.fLabelMedium11.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium11.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium11.Location = new System.Drawing.Point(108, 111);
            this.fLabelMedium11.Name = "fLabelMedium11";
            this.fLabelMedium11.Size = new System.Drawing.Size(100, 21);
            this.fLabelMedium11.TabIndex = 15;
            this.fLabelMedium11.Text = "=========";
            // 
            // fLabelSmall10
            // 
            this.fLabelSmall10.AutoSize = true;
            this.fLabelSmall10.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall10.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall10.Location = new System.Drawing.Point(15, 137);
            this.fLabelSmall10.Name = "fLabelSmall10";
            this.fLabelSmall10.Size = new System.Drawing.Size(49, 15);
            this.fLabelSmall10.TabIndex = 14;
            this.fLabelSmall10.Text = "Total Día";
            // 
            // lblAdicional
            // 
            this.lblAdicional.AutoSize = true;
            this.lblAdicional.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdicional.ForeColor = System.Drawing.Color.Black;
            this.lblAdicional.Location = new System.Drawing.Point(120, 66);
            this.lblAdicional.Name = "lblAdicional";
            this.lblAdicional.Size = new System.Drawing.Size(80, 21);
            this.lblAdicional.TabIndex = 13;
            this.lblAdicional.Text = "S/. XXX.00";
            this.lblAdicional.Click += new System.EventHandler(this.lblAdicional_Click);
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarjeta.ForeColor = System.Drawing.Color.Black;
            this.lblTarjeta.Location = new System.Drawing.Point(120, 43);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(80, 21);
            this.lblTarjeta.TabIndex = 12;
            this.lblTarjeta.Text = "S/. XXX.00";
            // 
            // fLabelSmall5
            // 
            this.fLabelSmall5.AutoSize = true;
            this.fLabelSmall5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall5.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall5.Location = new System.Drawing.Point(15, 72);
            this.fLabelSmall5.Name = "fLabelSmall5";
            this.fLabelSmall5.Size = new System.Drawing.Size(63, 15);
            this.fLabelSmall5.TabIndex = 12;
            this.fLabelSmall5.Text = "Adicionales";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivo.ForeColor = System.Drawing.Color.Black;
            this.lblEfectivo.Location = new System.Drawing.Point(120, 19);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(80, 21);
            this.lblEfectivo.TabIndex = 11;
            this.lblEfectivo.Text = "S/. XXX.00";
            // 
            // fLabelSmall7
            // 
            this.fLabelSmall7.AutoSize = true;
            this.fLabelSmall7.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall7.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall7.Location = new System.Drawing.Point(15, 47);
            this.fLabelSmall7.Name = "fLabelSmall7";
            this.fLabelSmall7.Size = new System.Drawing.Size(89, 15);
            this.fLabelSmall7.TabIndex = 2;
            this.fLabelSmall7.Text = "Pago con Tarjeta";
            // 
            // fLabelSmall8
            // 
            this.fLabelSmall8.AutoSize = true;
            this.fLabelSmall8.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall8.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall8.Location = new System.Drawing.Point(15, 22);
            this.fLabelSmall8.Name = "fLabelSmall8";
            this.fLabelSmall8.Size = new System.Drawing.Size(89, 15);
            this.fLabelSmall8.TabIndex = 0;
            this.fLabelSmall8.Text = "Pago en Efectivo";
            // 
            // fGroupBox4
            // 
            this.fGroupBox4.Controls.Add(this.lblDescuentos);
            this.fGroupBox4.Controls.Add(this.fLabelSmall11);
            this.fGroupBox4.Controls.Add(this.lblEgresos);
            this.fGroupBox4.Controls.Add(this.fLabelSmall3);
            this.fGroupBox4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox4.Location = new System.Drawing.Point(239, 141);
            this.fGroupBox4.Name = "fGroupBox4";
            this.fGroupBox4.Size = new System.Drawing.Size(214, 87);
            this.fGroupBox4.TabIndex = 9;
            this.fGroupBox4.TabStop = false;
            this.fGroupBox4.Text = "Detallado de Egresos";
            // 
            // lblDescuentos
            // 
            this.lblDescuentos.AutoSize = true;
            this.lblDescuentos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentos.ForeColor = System.Drawing.Color.Black;
            this.lblDescuentos.Location = new System.Drawing.Point(124, 45);
            this.lblDescuentos.Name = "lblDescuentos";
            this.lblDescuentos.Size = new System.Drawing.Size(80, 21);
            this.lblDescuentos.TabIndex = 17;
            this.lblDescuentos.Text = "S/. XXX.00";
            // 
            // fLabelSmall11
            // 
            this.fLabelSmall11.AutoSize = true;
            this.fLabelSmall11.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall11.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall11.Location = new System.Drawing.Point(12, 47);
            this.fLabelSmall11.Name = "fLabelSmall11";
            this.fLabelSmall11.Size = new System.Drawing.Size(65, 15);
            this.fLabelSmall11.TabIndex = 16;
            this.fLabelSmall11.Text = "Descuentos";
            // 
            // lblEgresos
            // 
            this.lblEgresos.AutoSize = true;
            this.lblEgresos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEgresos.ForeColor = System.Drawing.Color.Black;
            this.lblEgresos.Location = new System.Drawing.Point(124, 18);
            this.lblEgresos.Name = "lblEgresos";
            this.lblEgresos.Size = new System.Drawing.Size(80, 21);
            this.lblEgresos.TabIndex = 15;
            this.lblEgresos.Text = "S/. XXX.00";
            // 
            // fLabelSmall3
            // 
            this.fLabelSmall3.AutoSize = true;
            this.fLabelSmall3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall3.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall3.Location = new System.Drawing.Point(12, 23);
            this.fLabelSmall3.Name = "fLabelSmall3";
            this.fLabelSmall3.Size = new System.Drawing.Size(80, 15);
            this.fLabelSmall3.TabIndex = 14;
            this.fLabelSmall3.Text = "Egresos Varios";
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.txtCierre);
            this.fGroupBox2.Controls.Add(this.fLabelSmall1);
            this.fGroupBox2.Controls.Add(this.txtApertura);
            this.fGroupBox2.Controls.Add(this.fLabelSmall2);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(462, 60);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(214, 75);
            this.fGroupBox2.TabIndex = 11;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Datos Cierre";
            // 
            // txtCierre
            // 
            this.txtCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCierre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCierre.Enabled = false;
            this.txtCierre.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCierre.Location = new System.Drawing.Point(115, 36);
            this.txtCierre.Name = "txtCierre";
            this.txtCierre.Size = new System.Drawing.Size(75, 23);
            this.txtCierre.TabIndex = 7;
            this.txtCierre.Text = "00.00";
            this.txtCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelSmall1
            // 
            this.fLabelSmall1.AutoSize = true;
            this.fLabelSmall1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall1.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall1.Location = new System.Drawing.Point(131, 18);
            this.fLabelSmall1.Name = "fLabelSmall1";
            this.fLabelSmall1.Size = new System.Drawing.Size(56, 15);
            this.fLabelSmall1.TabIndex = 6;
            this.fLabelSmall1.Text = "Cerró con";
            // 
            // txtApertura
            // 
            this.txtApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApertura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApertura.Enabled = false;
            this.txtApertura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApertura.Location = new System.Drawing.Point(18, 36);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(75, 23);
            this.txtApertura.TabIndex = 9;
            this.txtApertura.Text = "00.00";
            this.txtApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelSmall2
            // 
            this.fLabelSmall2.AutoSize = true;
            this.fLabelSmall2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall2.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall2.Location = new System.Drawing.Point(15, 18);
            this.fLabelSmall2.Name = "fLabelSmall2";
            this.fLabelSmall2.Size = new System.Drawing.Size(75, 15);
            this.fLabelSmall2.TabIndex = 8;
            this.fLabelSmall2.Text = "Aperturó con";
            // 
            // fGroupBox6
            // 
            this.fGroupBox6.Controls.Add(this.lblConsumo);
            this.fGroupBox6.Controls.Add(this.lblHospedaje);
            this.fGroupBox6.Controls.Add(this.fLabelSmall6);
            this.fGroupBox6.Controls.Add(this.fLabelSmall9);
            this.fGroupBox6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox6.Location = new System.Drawing.Point(239, 60);
            this.fGroupBox6.Name = "fGroupBox6";
            this.fGroupBox6.Size = new System.Drawing.Size(214, 75);
            this.fGroupBox6.TabIndex = 13;
            this.fGroupBox6.TabStop = false;
            this.fGroupBox6.Text = "Detallado Efectivo";
            // 
            // lblConsumo
            // 
            this.lblConsumo.AutoSize = true;
            this.lblConsumo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumo.ForeColor = System.Drawing.Color.Black;
            this.lblConsumo.Location = new System.Drawing.Point(128, 45);
            this.lblConsumo.Name = "lblConsumo";
            this.lblConsumo.Size = new System.Drawing.Size(80, 21);
            this.lblConsumo.TabIndex = 12;
            this.lblConsumo.Text = "S/. XXX.00";
            // 
            // lblHospedaje
            // 
            this.lblHospedaje.AutoSize = true;
            this.lblHospedaje.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHospedaje.ForeColor = System.Drawing.Color.Black;
            this.lblHospedaje.Location = new System.Drawing.Point(128, 23);
            this.lblHospedaje.Name = "lblHospedaje";
            this.lblHospedaje.Size = new System.Drawing.Size(80, 21);
            this.lblHospedaje.TabIndex = 11;
            this.lblHospedaje.Text = "S/. XXX.00";
            // 
            // fLabelSmall6
            // 
            this.fLabelSmall6.AutoSize = true;
            this.fLabelSmall6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall6.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall6.Location = new System.Drawing.Point(15, 47);
            this.fLabelSmall6.Name = "fLabelSmall6";
            this.fLabelSmall6.Size = new System.Drawing.Size(99, 15);
            this.fLabelSmall6.TabIndex = 2;
            this.fLabelSmall6.Text = "Pago en Consumo";
            // 
            // fLabelSmall9
            // 
            this.fLabelSmall9.AutoSize = true;
            this.fLabelSmall9.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall9.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall9.Location = new System.Drawing.Point(15, 25);
            this.fLabelSmall9.Name = "fLabelSmall9";
            this.fLabelSmall9.Size = new System.Drawing.Size(105, 15);
            this.fLabelSmall9.TabIndex = 0;
            this.fLabelSmall9.Text = "Pago en Hospedaje";
            // 
            // FrmCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 232);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.fGroupBox6);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.fGroupBox4);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.KeyPreview = true;
            this.Name = "FrmCierre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCierre_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.fGroupBox4.ResumeLayout(false);
            this.fGroupBox4.PerformLayout();
            this.fGroupBox2.ResumeLayout(false);
            this.fGroupBox2.PerformLayout();
            this.fGroupBox6.ResumeLayout(false);
            this.fGroupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FLabelSmall fLabelSmall7;
        private Controles_Standar.FLabelSmall fLabelSmall8;
        private Controles_Standar.FGroupBox fGroupBox4;
        private Controles_Standar.FLabelMedium lblEfectivo;
        private Controles_Standar.FLabelMedium lblTarjeta;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FTextBoxDoubleRequerido txtCierre;
        private Controles_Standar.FLabelSmall fLabelSmall1;
        private Controles_Standar.FTextBoxDoubleRequerido txtApertura;
        private Controles_Standar.FLabelSmall fLabelSmall2;
        private Controles_Standar.FLabelMedium lblAdicional;
        private Controles_Standar.FLabelSmall fLabelSmall5;
        private Controles_Standar.FGroupBox fGroupBox6;
        private Controles_Standar.FLabelMedium lblConsumo;
        private Controles_Standar.FLabelMedium lblHospedaje;
        private Controles_Standar.FLabelSmall fLabelSmall6;
        private Controles_Standar.FLabelSmall fLabelSmall9;
        private Controles_Standar.FLabelSmall fLabelSmall10;
        private Controles_Standar.FLabelMedium lblTotalDia;
        private Controles_Standar.FLabelMedium fLabelMedium11;
        private Controles_Standar.FLabelMedium lblEgresos;
        private Controles_Standar.FLabelSmall fLabelSmall3;
        private Controles_Standar.FLabelMedium lblAdelantos;
        private Controles_Standar.FLabelSmall fLabelSmall4;
        private Controles_Standar.FLabelMedium lblDescuentos;
        private Controles_Standar.FLabelSmall fLabelSmall11;
    }
}