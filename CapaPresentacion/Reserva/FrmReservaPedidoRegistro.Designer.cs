namespace CapaPresentacion.Reserva
{
    partial class FrmReservaPedidoRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReservaPedidoRegistro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pagarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtSinComprobante = new Controles_Standar.FRadioButton();
            this.rbtFactura = new Controles_Standar.FRadioButton();
            this.rbtBoleta = new Controles_Standar.FRadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtEfectivo = new Controles_Standar.FRadioButton();
            this.rbtTarjeta = new Controles_Standar.FRadioButton();
            this.btnPagar = new System.Windows.Forms.Button();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.dtpFecha = new Controles_Standar.FDateTimePicker();
            this.chkConsolidado = new Controles_Standar.FCheckBox();
            this.chkCaja = new Controles_Standar.FCheckBox();
            this.lblDireccion = new Controles_Standar.FLabelMedium();
            this.txtRUC = new Controles_Standar.FTextBox();
            this.lblRuc = new Controles_Standar.FLabelMedium();
            this.txtDNI = new Controles_Standar.FTextBox();
            this.lblDNI = new Controles_Standar.FLabelMedium();
            this.txtRazonSocial = new Controles_Standar.FTextBox();
            this.fLabelMedium6 = new Controles_Standar.FLabelMedium();
            this.txtReferencia = new Controles_Standar.FTextBox();
            this.txtNTarjeta = new Controles_Standar.FTextBox();
            this.lblNTarjeta = new Controles_Standar.FLabelMedium();
            this.lblReferencia = new Controles_Standar.FLabelMedium();
            this.txtCliente = new Controles_Standar.FTextBox();
            this.fLabelMedium5 = new Controles_Standar.FLabelMedium();
            this.txtComprobante = new Controles_Standar.FTextBox();
            this.fLabelMedium3 = new Controles_Standar.FLabelMedium();
            this.txtSerie = new Controles_Standar.FTextBox();
            this.fLabelMedium4 = new Controles_Standar.FLabelMedium();
            this.vistaProductoListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.vistaConsumoLiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEliminarConcepto = new Controles_Standar.FButtonEliminar();
            this.btnAgregaConcepto = new Controles_Standar.FButtonAceptar();
            this.txtMonto = new Controles_Standar.FTextBox();
            this.txtConcepto = new Controles_Standar.FTextBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.fGroupBox2 = new Controles_Standar.FGroupBox();
            this.dgvConceptoFacturacion = new Controles_Standar.FDataGridView();
            this.codigoConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fLabelMedium7 = new Controles_Standar.FLabelMedium();
            this.chkSobreFacturar = new Controles_Standar.FCheckBox();
            this.txtCantidad = new Controles_Standar.FTextBox();
            this.fLabelMedium8 = new Controles_Standar.FLabelMedium();
            this.txtDireccion = new Controles_Standar.FTextBox();
            this.lblTotalMonto = new Controles_Standar.FLabelMedium();
            this.lblTotalPedidos = new Controles_Standar.FLabelMedium();
            this.lblTotal = new Controles_Standar.FLabelMedium();
            this.chkAutomatica = new Controles_Standar.FCheckBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.cboArchivo = new System.Windows.Forms.ComboBox();
            this.lblEnvio = new System.Windows.Forms.Label();
            this.cboEnvio = new System.Windows.Forms.ComboBox();
            this.txtOrdenCompra = new Controles_Standar.FTextBox();
            this.fLabelMedium9 = new Controles_Standar.FLabelMedium();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vistaProductoListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaConsumoLiquidacionBindingSource)).BeginInit();
            this.fGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagarProductoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // pagarProductoToolStripMenuItem
            // 
            this.pagarProductoToolStripMenuItem.Name = "pagarProductoToolStripMenuItem";
            this.pagarProductoToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pagarProductoToolStripMenuItem.Text = "Pagar Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtSinComprobante);
            this.groupBox1.Controls.Add(this.rbtFactura);
            this.groupBox1.Controls.Add(this.rbtBoleta);
            this.groupBox1.Location = new System.Drawing.Point(28, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Comprobante";
            // 
            // rbtSinComprobante
            // 
            this.rbtSinComprobante.AutoSize = true;
            this.rbtSinComprobante.BackColor = System.Drawing.Color.Transparent;
            this.rbtSinComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtSinComprobante.Location = new System.Drawing.Point(205, 24);
            this.rbtSinComprobante.Name = "rbtSinComprobante";
            this.rbtSinComprobante.Size = new System.Drawing.Size(113, 19);
            this.rbtSinComprobante.TabIndex = 3;
            this.rbtSinComprobante.TabStop = true;
            this.rbtSinComprobante.Text = "Sin Comprobante";
            this.rbtSinComprobante.UseVisualStyleBackColor = false;
            this.rbtSinComprobante.CheckedChanged += new System.EventHandler(this.rbtSinComprobante_CheckedChanged);
            // 
            // rbtFactura
            // 
            this.rbtFactura.AutoSize = true;
            this.rbtFactura.BackColor = System.Drawing.Color.Transparent;
            this.rbtFactura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtFactura.Location = new System.Drawing.Point(13, 24);
            this.rbtFactura.Name = "rbtFactura";
            this.rbtFactura.Size = new System.Drawing.Size(92, 19);
            this.rbtFactura.TabIndex = 0;
            this.rbtFactura.TabStop = true;
            this.rbtFactura.Text = "Emitir Factura";
            this.rbtFactura.UseVisualStyleBackColor = false;
            this.rbtFactura.CheckedChanged += new System.EventHandler(this.fRadioButton1_CheckedChanged);
            // 
            // rbtBoleta
            // 
            this.rbtBoleta.AutoSize = true;
            this.rbtBoleta.BackColor = System.Drawing.Color.Transparent;
            this.rbtBoleta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtBoleta.Location = new System.Drawing.Point(111, 24);
            this.rbtBoleta.Name = "rbtBoleta";
            this.rbtBoleta.Size = new System.Drawing.Size(88, 19);
            this.rbtBoleta.TabIndex = 1;
            this.rbtBoleta.TabStop = true;
            this.rbtBoleta.Text = "Emitir Boleta";
            this.rbtBoleta.UseVisualStyleBackColor = false;
            this.rbtBoleta.CheckedChanged += new System.EventHandler(this.rbtBoleta_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtEfectivo);
            this.groupBox2.Controls.Add(this.rbtTarjeta);
            this.groupBox2.Location = new System.Drawing.Point(421, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Pago";
            // 
            // rbtEfectivo
            // 
            this.rbtEfectivo.AutoSize = true;
            this.rbtEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.rbtEfectivo.Checked = true;
            this.rbtEfectivo.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtEfectivo.Image = global::CapaPresentacion.Properties.Resources.cash_01;
            this.rbtEfectivo.Location = new System.Drawing.Point(11, 19);
            this.rbtEfectivo.Name = "rbtEfectivo";
            this.rbtEfectivo.Size = new System.Drawing.Size(66, 28);
            this.rbtEfectivo.TabIndex = 0;
            this.rbtEfectivo.TabStop = true;
            this.rbtEfectivo.UseVisualStyleBackColor = false;
            this.rbtEfectivo.CheckedChanged += new System.EventHandler(this.rbtEfectivo_CheckedChanged);
            // 
            // rbtTarjeta
            // 
            this.rbtTarjeta.AutoSize = true;
            this.rbtTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.rbtTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTarjeta.Image = global::CapaPresentacion.Properties.Resources.visa;
            this.rbtTarjeta.Location = new System.Drawing.Point(89, 12);
            this.rbtTarjeta.Name = "rbtTarjeta";
            this.rbtTarjeta.Size = new System.Drawing.Size(65, 42);
            this.rbtTarjeta.TabIndex = 1;
            this.rbtTarjeta.TabStop = true;
            this.rbtTarjeta.UseVisualStyleBackColor = false;
            this.rbtTarjeta.CheckedChanged += new System.EventHandler(this.rbtTarjeta_CheckedChanged);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnPagar.Image = global::CapaPresentacion.Properties.Resources.facturacion;
            this.btnPagar.Location = new System.Drawing.Point(954, 406);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(127, 34);
            this.btnPagar.TabIndex = 25;
            this.btnPagar.Text = "Registrar Pago";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(552, 190);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(56, 21);
            this.fLabelMedium1.TabIndex = 33;
            this.fLabelMedium1.Text = "FECHA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(552, 214);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(112, 23);
            this.dtpFecha.TabIndex = 32;
            // 
            // chkConsolidado
            // 
            this.chkConsolidado.AutoSize = true;
            this.chkConsolidado.BackColor = System.Drawing.Color.Transparent;
            this.chkConsolidado.Checked = true;
            this.chkConsolidado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsolidado.FlatAppearance.BorderSize = 0;
            this.chkConsolidado.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsolidado.ForeColor = System.Drawing.Color.Black;
            this.chkConsolidado.Location = new System.Drawing.Point(30, 331);
            this.chkConsolidado.Name = "chkConsolidado";
            this.chkConsolidado.Size = new System.Drawing.Size(130, 19);
            this.chkConsolidado.TabIndex = 31;
            this.chkConsolidado.Text = "Enviar a Consolidado";
            this.chkConsolidado.UseVisualStyleBackColor = false;
            // 
            // chkCaja
            // 
            this.chkCaja.AutoSize = true;
            this.chkCaja.BackColor = System.Drawing.Color.Transparent;
            this.chkCaja.Checked = true;
            this.chkCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaja.FlatAppearance.BorderSize = 0;
            this.chkCaja.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaja.ForeColor = System.Drawing.Color.Black;
            this.chkCaja.Location = new System.Drawing.Point(30, 381);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(88, 19);
            this.chkCaja.TabIndex = 30;
            this.chkCaja.Text = "Enviar a Caja";
            this.chkCaja.UseVisualStyleBackColor = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblDireccion.Location = new System.Drawing.Point(24, 244);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(72, 21);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtRUC
            // 
            this.txtRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRUC.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRUC.Location = new System.Drawing.Point(421, 214);
            this.txtRUC.MaxLength = 11;
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(125, 23);
            this.txtRUC.TabIndex = 11;
            this.txtRUC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRUC_KeyPress);
            // 
            // lblRuc
            // 
            this.lblRuc.AutoSize = true;
            this.lblRuc.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuc.ForeColor = System.Drawing.Color.Black;
            this.lblRuc.Location = new System.Drawing.Point(417, 190);
            this.lblRuc.Name = "lblRuc";
            this.lblRuc.Size = new System.Drawing.Size(39, 21);
            this.lblRuc.TabIndex = 10;
            this.lblRuc.Text = "RUC";
            // 
            // txtDNI
            // 
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(421, 159);
            this.txtDNI.MaxLength = 8;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(84, 23);
            this.txtDNI.TabIndex = 7;
            this.txtDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDNI_KeyDown);
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.ForeColor = System.Drawing.Color.Black;
            this.lblDNI.Location = new System.Drawing.Point(417, 135);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(36, 21);
            this.lblDNI.TabIndex = 6;
            this.lblDNI.Text = "DNI";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(28, 214);
            this.txtRazonSocial.MaxLength = 150;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(387, 23);
            this.txtRazonSocial.TabIndex = 9;
            // 
            // fLabelMedium6
            // 
            this.fLabelMedium6.AutoSize = true;
            this.fLabelMedium6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium6.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium6.Location = new System.Drawing.Point(24, 190);
            this.fLabelMedium6.Name = "fLabelMedium6";
            this.fLabelMedium6.Size = new System.Drawing.Size(94, 21);
            this.fLabelMedium6.TabIndex = 8;
            this.fLabelMedium6.Text = "Razón Social";
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(425, 268);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(121, 23);
            this.txtReferencia.TabIndex = 15;
            this.txtReferencia.Visible = false;
            // 
            // txtNTarjeta
            // 
            this.txtNTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNTarjeta.Location = new System.Drawing.Point(552, 268);
            this.txtNTarjeta.Name = "txtNTarjeta";
            this.txtNTarjeta.Size = new System.Drawing.Size(112, 23);
            this.txtNTarjeta.TabIndex = 17;
            this.txtNTarjeta.Visible = false;
            // 
            // lblNTarjeta
            // 
            this.lblNTarjeta.AutoSize = true;
            this.lblNTarjeta.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTarjeta.ForeColor = System.Drawing.Color.Black;
            this.lblNTarjeta.Location = new System.Drawing.Point(548, 244);
            this.lblNTarjeta.Name = "lblNTarjeta";
            this.lblNTarjeta.Size = new System.Drawing.Size(73, 21);
            this.lblNTarjeta.TabIndex = 16;
            this.lblNTarjeta.Text = "N° Tarjeta";
            this.lblNTarjeta.Visible = false;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencia.ForeColor = System.Drawing.Color.Black;
            this.lblReferencia.Location = new System.Drawing.Point(421, 244);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(79, 21);
            this.lblReferencia.TabIndex = 14;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(28, 161);
            this.txtCliente.MaxLength = 150;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(387, 23);
            this.txtCliente.TabIndex = 5;
            // 
            // fLabelMedium5
            // 
            this.fLabelMedium5.AutoSize = true;
            this.fLabelMedium5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium5.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium5.Location = new System.Drawing.Point(24, 137);
            this.fLabelMedium5.Name = "fLabelMedium5";
            this.fLabelMedium5.Size = new System.Drawing.Size(56, 21);
            this.fLabelMedium5.TabIndex = 4;
            this.fLabelMedium5.Text = "Cliente";
            // 
            // txtComprobante
            // 
            this.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComprobante.Enabled = false;
            this.txtComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComprobante.Location = new System.Drawing.Point(583, 160);
            this.txtComprobante.MaxLength = 8;
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(81, 23);
            this.txtComprobante.TabIndex = 22;
            // 
            // fLabelMedium3
            // 
            this.fLabelMedium3.AutoSize = true;
            this.fLabelMedium3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium3.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium3.Location = new System.Drawing.Point(579, 136);
            this.fLabelMedium3.Name = "fLabelMedium3";
            this.fLabelMedium3.Size = new System.Drawing.Size(76, 21);
            this.fLabelMedium3.TabIndex = 21;
            this.fLabelMedium3.Text = "N° Comp.";
            // 
            // txtSerie
            // 
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Enabled = false;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(511, 159);
            this.txtSerie.MaxLength = 3;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(66, 23);
            this.txtSerie.TabIndex = 20;
            // 
            // fLabelMedium4
            // 
            this.fLabelMedium4.AutoSize = true;
            this.fLabelMedium4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium4.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium4.Location = new System.Drawing.Point(507, 137);
            this.fLabelMedium4.Name = "fLabelMedium4";
            this.fLabelMedium4.Size = new System.Drawing.Size(42, 21);
            this.fLabelMedium4.TabIndex = 19;
            this.fLabelMedium4.Text = "Serie";
            // 
            // vistaProductoListBindingSource
            // 
            this.vistaProductoListBindingSource.DataSource = typeof(CapaEntidades.vistaProductoList);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1087, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(21, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(356, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Registro de Comprobantes";
            // 
            // vistaConsumoLiquidacionBindingSource
            // 
            this.vistaConsumoLiquidacionBindingSource.DataSource = typeof(CapaEntidades.vistaConsumoLiquidacion);
            // 
            // btnEliminarConcepto
            // 
            this.btnEliminarConcepto.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarConcepto.Image")));
            this.btnEliminarConcepto.Location = new System.Drawing.Point(1128, 137);
            this.btnEliminarConcepto.Name = "btnEliminarConcepto";
            this.btnEliminarConcepto.Size = new System.Drawing.Size(43, 34);
            this.btnEliminarConcepto.TabIndex = 82;
            this.btnEliminarConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarConcepto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEliminarConcepto.UseVisualStyleBackColor = true;
            this.btnEliminarConcepto.Click += new System.EventHandler(this.btnEliminarConcepto_Click);
            // 
            // btnAgregaConcepto
            // 
            this.btnAgregaConcepto.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregaConcepto.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregaConcepto.Image")));
            this.btnAgregaConcepto.Location = new System.Drawing.Point(1069, 137);
            this.btnAgregaConcepto.Name = "btnAgregaConcepto";
            this.btnAgregaConcepto.Size = new System.Drawing.Size(43, 34);
            this.btnAgregaConcepto.TabIndex = 81;
            this.btnAgregaConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregaConcepto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgregaConcepto.UseVisualStyleBackColor = true;
            this.btnAgregaConcepto.Click += new System.EventHandler(this.btnAgregaConcepto_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(958, 148);
            this.txtMonto.MaxLength = 8;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(104, 23);
            this.txtMonto.TabIndex = 80;
            this.txtMonto.Text = "0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtConcepto
            // 
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.Location = new System.Drawing.Point(677, 99);
            this.txtConcepto.MaxLength = 150;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(275, 72);
            this.txtConcepto.TabIndex = 78;
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(676, 73);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(108, 21);
            this.fLabelMedium2.TabIndex = 77;
            this.fLabelMedium2.Text = "Definir Servicio";
            // 
            // fGroupBox2
            // 
            this.fGroupBox2.Controls.Add(this.dgvConceptoFacturacion);
            this.fGroupBox2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox2.Location = new System.Drawing.Point(677, 184);
            this.fGroupBox2.Name = "fGroupBox2";
            this.fGroupBox2.Size = new System.Drawing.Size(500, 219);
            this.fGroupBox2.TabIndex = 76;
            this.fGroupBox2.TabStop = false;
            this.fGroupBox2.Text = "Detalle de Conceptos";
            // 
            // dgvConceptoFacturacion
            // 
            this.dgvConceptoFacturacion.AllowUserToAddRows = false;
            this.dgvConceptoFacturacion.AllowUserToDeleteRows = false;
            this.dgvConceptoFacturacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvConceptoFacturacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConceptoFacturacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConceptoFacturacion.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvConceptoFacturacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            this.dgvConceptoFacturacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConceptoFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptoFacturacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoConcepto,
            this.descripcionConcepto,
            this.cantidadConcepto,
            this.precioConcepto,
            this.totalConcepto});
            this.dgvConceptoFacturacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConceptoFacturacion.EnableHeadersVisualStyles = false;
            this.dgvConceptoFacturacion.Location = new System.Drawing.Point(3, 19);
            this.dgvConceptoFacturacion.MultiSelect = false;
            this.dgvConceptoFacturacion.Name = "dgvConceptoFacturacion";
            this.dgvConceptoFacturacion.ReadOnly = true;
            this.dgvConceptoFacturacion.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvConceptoFacturacion.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConceptoFacturacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptoFacturacion.Size = new System.Drawing.Size(494, 197);
            this.dgvConceptoFacturacion.TabIndex = 0;
            // 
            // codigoConcepto
            // 
            this.codigoConcepto.HeaderText = "ID";
            this.codigoConcepto.Name = "codigoConcepto";
            this.codigoConcepto.ReadOnly = true;
            this.codigoConcepto.Visible = false;
            this.codigoConcepto.Width = 23;
            // 
            // descripcionConcepto
            // 
            this.descripcionConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcionConcepto.HeaderText = "CONCEPTO";
            this.descripcionConcepto.Name = "descripcionConcepto";
            this.descripcionConcepto.ReadOnly = true;
            // 
            // cantidadConcepto
            // 
            this.cantidadConcepto.HeaderText = "CANT";
            this.cantidadConcepto.Name = "cantidadConcepto";
            this.cantidadConcepto.ReadOnly = true;
            this.cantidadConcepto.Width = 61;
            // 
            // precioConcepto
            // 
            this.precioConcepto.HeaderText = "PRECIO";
            this.precioConcepto.Name = "precioConcepto";
            this.precioConcepto.ReadOnly = true;
            this.precioConcepto.Width = 70;
            // 
            // totalConcepto
            // 
            this.totalConcepto.HeaderText = "TOTAL";
            this.totalConcepto.Name = "totalConcepto";
            this.totalConcepto.ReadOnly = true;
            this.totalConcepto.Width = 62;
            // 
            // fLabelMedium7
            // 
            this.fLabelMedium7.AutoSize = true;
            this.fLabelMedium7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium7.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium7.Location = new System.Drawing.Point(954, 124);
            this.fLabelMedium7.Name = "fLabelMedium7";
            this.fLabelMedium7.Size = new System.Drawing.Size(55, 21);
            this.fLabelMedium7.TabIndex = 79;
            this.fLabelMedium7.Text = "Monto";
            // 
            // chkSobreFacturar
            // 
            this.chkSobreFacturar.AutoSize = true;
            this.chkSobreFacturar.BackColor = System.Drawing.Color.Transparent;
            this.chkSobreFacturar.Checked = true;
            this.chkSobreFacturar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSobreFacturar.FlatAppearance.BorderSize = 0;
            this.chkSobreFacturar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSobreFacturar.ForeColor = System.Drawing.Color.Black;
            this.chkSobreFacturar.Location = new System.Drawing.Point(30, 356);
            this.chkSobreFacturar.Name = "chkSobreFacturar";
            this.chkSobreFacturar.Size = new System.Drawing.Size(135, 19);
            this.chkSobreFacturar.TabIndex = 83;
            this.chkSobreFacturar.Text = "Factura sin Hospedaje";
            this.chkSobreFacturar.UseVisualStyleBackColor = false;
            this.chkSobreFacturar.CheckedChanged += new System.EventHandler(this.chkSobreFacturar_CheckedChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(958, 99);
            this.txtCantidad.MaxLength = 8;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(104, 23);
            this.txtCantidad.TabIndex = 85;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fLabelMedium8
            // 
            this.fLabelMedium8.AutoSize = true;
            this.fLabelMedium8.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium8.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium8.Location = new System.Drawing.Point(954, 75);
            this.fLabelMedium8.Name = "fLabelMedium8";
            this.fLabelMedium8.Size = new System.Drawing.Size(71, 21);
            this.fLabelMedium8.TabIndex = 84;
            this.fLabelMedium8.Text = "Cantidad";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(28, 268);
            this.txtDireccion.MaxLength = 150;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(387, 23);
            this.txtDireccion.TabIndex = 13;
            // 
            // lblTotalMonto
            // 
            this.lblTotalMonto.AutoSize = true;
            this.lblTotalMonto.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMonto.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMonto.Location = new System.Drawing.Point(421, 382);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Size = new System.Drawing.Size(93, 21);
            this.lblTotalMonto.TabIndex = 87;
            this.lblTotalMonto.Text = "Monto Total:";
            // 
            // lblTotalPedidos
            // 
            this.lblTotalPedidos.AutoSize = true;
            this.lblTotalPedidos.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPedidos.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPedidos.Location = new System.Drawing.Point(421, 352);
            this.lblTotalPedidos.Name = "lblTotalPedidos";
            this.lblTotalPedidos.Size = new System.Drawing.Size(100, 21);
            this.lblTotalPedidos.TabIndex = 86;
            this.lblTotalPedidos.Text = "Total Detalles:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(428, 406);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(18, 21);
            this.lblTotal.TabIndex = 89;
            this.lblTotal.Text = "0";
            this.lblTotal.Visible = false;
            // 
            // chkAutomatica
            // 
            this.chkAutomatica.AutoSize = true;
            this.chkAutomatica.BackColor = System.Drawing.Color.Transparent;
            this.chkAutomatica.Checked = true;
            this.chkAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutomatica.FlatAppearance.BorderSize = 0;
            this.chkAutomatica.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutomatica.ForeColor = System.Drawing.Color.Black;
            this.chkAutomatica.Location = new System.Drawing.Point(425, 297);
            this.chkAutomatica.Name = "chkAutomatica";
            this.chkAutomatica.Size = new System.Drawing.Size(111, 19);
            this.chkAutomatica.TabIndex = 90;
            this.chkAutomatica.Text = "Serie Automática";
            this.chkAutomatica.UseVisualStyleBackColor = false;
            this.chkAutomatica.CheckedChanged += new System.EventHandler(this.chkAutomatica_CheckedChanged);
            // 
            // lblArchivo
            // 
            this.lblArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchivo.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.lblArchivo.ForeColor = System.Drawing.Color.Navy;
            this.lblArchivo.Location = new System.Drawing.Point(965, 32);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(45, 13);
            this.lblArchivo.TabIndex = 569;
            this.lblArchivo.Text = "Archivo";
            this.lblArchivo.Visible = false;
            // 
            // cboArchivo
            // 
            this.cboArchivo.AccessibleDescription = "";
            this.cboArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArchivo.Enabled = false;
            this.cboArchivo.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.cboArchivo.FormattingEnabled = true;
            this.cboArchivo.Location = new System.Drawing.Point(1016, 29);
            this.cboArchivo.Name = "cboArchivo";
            this.cboArchivo.Size = new System.Drawing.Size(0, 21);
            this.cboArchivo.TabIndex = 568;
            // 
            // lblEnvio
            // 
            this.lblEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEnvio.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.lblEnvio.ForeColor = System.Drawing.Color.Navy;
            this.lblEnvio.Location = new System.Drawing.Point(674, 31);
            this.lblEnvio.Name = "lblEnvio";
            this.lblEnvio.Size = new System.Drawing.Size(40, 13);
            this.lblEnvio.TabIndex = 567;
            this.lblEnvio.Text = "Envío";
            this.lblEnvio.Visible = false;
            // 
            // cboEnvio
            // 
            this.cboEnvio.AccessibleDescription = "";
            this.cboEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnvio.Enabled = false;
            this.cboEnvio.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.cboEnvio.FormattingEnabled = true;
            this.cboEnvio.Location = new System.Drawing.Point(741, 28);
            this.cboEnvio.Name = "cboEnvio";
            this.cboEnvio.Size = new System.Drawing.Size(0, 21);
            this.cboEnvio.TabIndex = 566;
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdenCompra.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenCompra.Location = new System.Drawing.Point(556, 321);
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.Size = new System.Drawing.Size(112, 23);
            this.txtOrdenCompra.TabIndex = 571;
            // 
            // fLabelMedium9
            // 
            this.fLabelMedium9.AutoSize = true;
            this.fLabelMedium9.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium9.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium9.Location = new System.Drawing.Point(552, 297);
            this.fLabelMedium9.Name = "fLabelMedium9";
            this.fLabelMedium9.Size = new System.Drawing.Size(111, 21);
            this.fLabelMedium9.TabIndex = 570;
            this.fLabelMedium9.Text = "Orden Compra";
            // 
            // FrmReservaPedidoRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 448);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.txtOrdenCompra);
            this.Controls.Add(this.fLabelMedium9);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.cboArchivo);
            this.Controls.Add(this.lblEnvio);
            this.Controls.Add(this.cboEnvio);
            this.Controls.Add(this.chkAutomatica);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalMonto);
            this.Controls.Add(this.lblTotalPedidos);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.fLabelMedium8);
            this.Controls.Add(this.chkSobreFacturar);
            this.Controls.Add(this.btnEliminarConcepto);
            this.Controls.Add(this.btnAgregaConcepto);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.fLabelMedium7);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.fLabelMedium2);
            this.Controls.Add(this.fGroupBox2);
            this.Controls.Add(this.fLabelMedium1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.chkConsolidado);
            this.Controls.Add(this.chkCaja);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtRUC);
            this.Controls.Add(this.lblRuc);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.fLabelMedium6);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.txtNTarjeta);
            this.Controls.Add(this.lblNTarjeta);
            this.Controls.Add(this.lblReferencia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.fLabelMedium5);
            this.Controls.Add(this.txtComprobante);
            this.Controls.Add(this.fLabelMedium3);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.fLabelMedium4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReservaPedidoRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Generar Pedido .::.";
            this.Load += new System.EventHandler(this.FrmReservacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReservaPedidoRegistro_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vistaProductoListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaConsumoLiquidacionBindingSource)).EndInit();
            this.fGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptoFacturacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private System.Windows.Forms.BindingSource vistaProductoListBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pagarProductoToolStripMenuItem;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controles_Standar.FRadioButton rbtBoleta;
        private Controles_Standar.FTextBox txtComprobante;
        private Controles_Standar.FLabelMedium fLabelMedium3;
        private Controles_Standar.FTextBox txtSerie;
        private Controles_Standar.FLabelMedium fLabelMedium4;
        private Controles_Standar.FTextBox txtCliente;
        private Controles_Standar.FLabelMedium fLabelMedium5;
        private Controles_Standar.FTextBox txtReferencia;
        private Controles_Standar.FTextBox txtNTarjeta;
        private Controles_Standar.FLabelMedium lblNTarjeta;
        private Controles_Standar.FLabelMedium lblReferencia;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controles_Standar.FRadioButton rbtEfectivo;
        private Controles_Standar.FRadioButton rbtTarjeta;
        private System.Windows.Forms.BindingSource vistaConsumoLiquidacionBindingSource;
        private Controles_Standar.FTextBox txtRazonSocial;
        private Controles_Standar.FLabelMedium fLabelMedium6;
        private Controles_Standar.FRadioButton rbtFactura;
        private Controles_Standar.FTextBox txtDNI;
        private Controles_Standar.FLabelMedium lblDNI;
        private Controles_Standar.FTextBox txtRUC;
        private Controles_Standar.FLabelMedium lblRuc;
        private Controles_Standar.FLabelMedium lblDireccion;
        private Controles_Standar.FCheckBox chkConsolidado;
        private Controles_Standar.FCheckBox chkCaja;
        private Controles_Standar.FRadioButton rbtSinComprobante;
        private Controles_Standar.FDateTimePicker dtpFecha;
        private Controles_Standar.FLabelMedium fLabelMedium1;
        private Controles_Standar.FButtonEliminar btnEliminarConcepto;
        private Controles_Standar.FButtonAceptar btnAgregaConcepto;
        private Controles_Standar.FTextBox txtMonto;
        private Controles_Standar.FTextBox txtConcepto;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FGroupBox fGroupBox2;
        private Controles_Standar.FDataGridView dgvConceptoFacturacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalConcepto;
        private Controles_Standar.FLabelMedium fLabelMedium7;
        private Controles_Standar.FCheckBox chkSobreFacturar;
        private Controles_Standar.FTextBox txtCantidad;
        private Controles_Standar.FLabelMedium fLabelMedium8;
        private Controles_Standar.FTextBox txtDireccion;
        private Controles_Standar.FLabelMedium lblTotalMonto;
        private Controles_Standar.FLabelMedium lblTotalPedidos;
        private Controles_Standar.FLabelMedium lblTotal;
        private Controles_Standar.FCheckBox chkAutomatica;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.ComboBox cboArchivo;
        private System.Windows.Forms.Label lblEnvio;
        private System.Windows.Forms.ComboBox cboEnvio;
        private Controles_Standar.FTextBox txtOrdenCompra;
        private Controles_Standar.FLabelMedium fLabelMedium9;
    }
}