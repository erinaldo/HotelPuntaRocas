namespace CapaPresentacion.Flujo_Caja
{
    partial class FrmApertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApertura));
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.txtMontoApertura = new Controles_Standar.FTextBoxDoubleRequerido();
            this.lblFecha = new Controles_Standar.FLabelMedium();
            this.lblCaja = new Controles_Standar.FLabelMedium();
            this.fLabelSmall3 = new Controles_Standar.FLabelSmall();
            this.fLabelSmall2 = new Controles_Standar.FLabelSmall();
            this.fLabelSmall1 = new Controles_Standar.FLabelSmall();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.btnGuardar = new Controles_Standar.FButtonGuardar();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.fGroupBox1.SuspendLayout();
            this.fGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.txtMontoApertura);
            this.fGroupBox1.Controls.Add(this.lblFecha);
            this.fGroupBox1.Controls.Add(this.lblCaja);
            this.fGroupBox1.Controls.Add(this.fLabelSmall3);
            this.fGroupBox1.Controls.Add(this.fLabelSmall2);
            this.fGroupBox1.Controls.Add(this.fLabelSmall1);
            this.fGroupBox1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Location = new System.Drawing.Point(20, 59);
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.Size = new System.Drawing.Size(332, 183);
            this.fGroupBox1.TabIndex = 1;
            this.fGroupBox1.TabStop = false;
            this.fGroupBox1.Text = "Datos de la Apertura de Caja";
            // 
            // txtMontoApertura
            // 
            this.txtMontoApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoApertura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoApertura.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoApertura.Location = new System.Drawing.Point(18, 141);
            this.txtMontoApertura.Name = "txtMontoApertura";
            this.txtMontoApertura.Size = new System.Drawing.Size(144, 23);
            this.txtMontoApertura.TabIndex = 5;
            this.txtMontoApertura.Text = "00.00";
            this.txtMontoApertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoApertura_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(14, 92);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(243, 21);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Lunes ##/##/#### ##:##:## pm";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.ForeColor = System.Drawing.Color.Black;
            this.lblCaja.Location = new System.Drawing.Point(14, 47);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(164, 21);
            this.lblCaja.TabIndex = 1;
            this.lblCaja.Text = "Número de Caja N° ##";
            // 
            // fLabelSmall3
            // 
            this.fLabelSmall3.AutoSize = true;
            this.fLabelSmall3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall3.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall3.Location = new System.Drawing.Point(15, 123);
            this.fLabelSmall3.Name = "fLabelSmall3";
            this.fLabelSmall3.Size = new System.Drawing.Size(78, 15);
            this.fLabelSmall3.TabIndex = 4;
            this.fLabelSmall3.Text = "Aperturar con";
            // 
            // fLabelSmall2
            // 
            this.fLabelSmall2.AutoSize = true;
            this.fLabelSmall2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall2.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall2.Location = new System.Drawing.Point(15, 77);
            this.fLabelSmall2.Name = "fLabelSmall2";
            this.fLabelSmall2.Size = new System.Drawing.Size(101, 15);
            this.fLabelSmall2.TabIndex = 2;
            this.fLabelSmall2.Text = "Fecha de Apertura";
            // 
            // fLabelSmall1
            // 
            this.fLabelSmall1.AutoSize = true;
            this.fLabelSmall1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall1.ForeColor = System.Drawing.Color.Black;
            this.fLabelSmall1.Location = new System.Drawing.Point(15, 30);
            this.fLabelSmall1.Name = "fLabelSmall1";
            this.fLabelSmall1.Size = new System.Drawing.Size(61, 15);
            this.fLabelSmall1.TabIndex = 0;
            this.fLabelSmall1.Text = "N° de Caja";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(233, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Apertura de Caja";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(124, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(236, 22);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 34);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.btnCancelar);
            this.fGroupBox3.Controls.Add(this.btnGuardar);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(20, 248);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(332, 67);
            this.fGroupBox3.TabIndex = 2;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Acciones del Formulario";
            // 
            // FrmApertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 329);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmApertura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmApertura_KeyDown);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.fGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FTextBoxDoubleRequerido txtMontoApertura;
        private Controles_Standar.FLabelMedium lblFecha;
        private Controles_Standar.FLabelMedium lblCaja;
        private Controles_Standar.FLabelSmall fLabelSmall3;
        private Controles_Standar.FLabelSmall fLabelSmall2;
        private Controles_Standar.FLabelSmall fLabelSmall1;
        private Controles_Standar.FButtonGuardar btnGuardar;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FGroupBox fGroupBox3;


    }
}