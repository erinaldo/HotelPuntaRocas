namespace CapaPresentacion.Reserva
{
    partial class FrmReservaLiquidar
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
            this.btnBoletear = new System.Windows.Forms.Button();
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.txtComprobante = new Controles_Standar.FTextBox();
            this.fLabelMedium2 = new Controles_Standar.FLabelMedium();
            this.txtSerie = new Controles_Standar.FTextBox();
            this.fLabelMedium1 = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.fGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBoletear
            // 
            this.btnBoletear.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.btnBoletear.Image = global::CapaPresentacion.Properties.Resources.Liquidar;
            this.btnBoletear.Location = new System.Drawing.Point(291, 157);
            this.btnBoletear.Name = "btnBoletear";
            this.btnBoletear.Size = new System.Drawing.Size(90, 34);
            this.btnBoletear.TabIndex = 2;
            this.btnBoletear.Text = "Finalizar";
            this.btnBoletear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBoletear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBoletear.UseVisualStyleBackColor = true;
            this.btnBoletear.Click += new System.EventHandler(this.btnBoletear_Click);
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.txtComprobante);
            this.fGroupBox3.Controls.Add(this.fLabelMedium2);
            this.fGroupBox3.Controls.Add(this.txtSerie);
            this.fGroupBox3.Controls.Add(this.fLabelMedium1);
            this.fGroupBox3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Location = new System.Drawing.Point(19, 58);
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.Size = new System.Drawing.Size(362, 91);
            this.fGroupBox3.TabIndex = 1;
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Text = "Datos del comprobante";
            // 
            // txtComprobante
            // 
            this.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComprobante.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComprobante.Location = new System.Drawing.Point(85, 50);
            this.txtComprobante.MaxLength = 7;
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(144, 23);
            this.txtComprobante.TabIndex = 5;
            // 
            // fLabelMedium2
            // 
            this.fLabelMedium2.AutoSize = true;
            this.fLabelMedium2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium2.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium2.Location = new System.Drawing.Point(81, 26);
            this.fLabelMedium2.Name = "fLabelMedium2";
            this.fLabelMedium2.Size = new System.Drawing.Size(125, 21);
            this.fLabelMedium2.TabIndex = 4;
            this.fLabelMedium2.Text = "N° Comprobante";
            // 
            // txtSerie
            // 
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(23, 50);
            this.txtSerie.MaxLength = 3;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(56, 23);
            this.txtSerie.TabIndex = 3;
            // 
            // fLabelMedium1
            // 
            this.fLabelMedium1.AutoSize = true;
            this.fLabelMedium1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelMedium1.ForeColor = System.Drawing.Color.Black;
            this.fLabelMedium1.Location = new System.Drawing.Point(19, 26);
            this.fLabelMedium1.Name = "fLabelMedium1";
            this.fLabelMedium1.Size = new System.Drawing.Size(42, 21);
            this.fLabelMedium1.TabIndex = 2;
            this.fLabelMedium1.Text = "Serie";
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(346, 41);
            this.fLabelBig1.TabIndex = 0;
            this.fLabelBig1.Text = "Detalles del Comprobante";
            // 
            // FrmReservaLiquidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 203);
            this.Controls.Add(this.btnBoletear);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReservaLiquidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Liquidar Consumo .::.";
            this.Load += new System.EventHandler(this.FrmReservaLiquidar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReservaLiquidar_KeyDown);
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox3;
        private System.Windows.Forms.Button btnBoletear;
        private Controles_Standar.FTextBox txtComprobante;
        private Controles_Standar.FLabelMedium fLabelMedium2;
        private Controles_Standar.FTextBox txtSerie;
        private Controles_Standar.FLabelMedium fLabelMedium1;
    }
}