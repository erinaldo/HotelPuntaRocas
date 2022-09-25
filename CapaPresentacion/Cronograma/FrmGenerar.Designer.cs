namespace CapaPresentacion.Cronograma
{
    partial class FrmGenerar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerar));
            this.fGroupBox3 = new Controles_Standar.FGroupBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new Controles_Standar.FButtonCancelar();
            this.fGroupBox1 = new Controles_Standar.FGroupBox();
            this.fComboBox1 = new Controles_Standar.FComboBox();
            this.lblCaja = new Controles_Standar.FLabelMedium();
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.pgbProceso = new System.Windows.Forms.ProgressBar();
            this.fGroupBox3.SuspendLayout();
            this.fGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fGroupBox3
            // 
            this.fGroupBox3.Controls.Add(this.btnGenerar);
            this.fGroupBox3.Controls.Add(this.btnCancelar);
            resources.ApplyResources(this.fGroupBox3, "fGroupBox3");
            this.fGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox3.Name = "fGroupBox3";
            this.fGroupBox3.TabStop = false;
            this.fGroupBox3.Enter += new System.EventHandler(this.fGroupBox3_Enter);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::CapaPresentacion.Properties.Resources.Generar;
            resources.ApplyResources(this.btnGenerar, "btnGenerar");
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // fGroupBox1
            // 
            this.fGroupBox1.Controls.Add(this.fComboBox1);
            this.fGroupBox1.Controls.Add(this.lblCaja);
            resources.ApplyResources(this.fGroupBox1, "fGroupBox1");
            this.fGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fGroupBox1.Name = "fGroupBox1";
            this.fGroupBox1.TabStop = false;
            // 
            // fComboBox1
            // 
            this.fComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.fComboBox1, "fComboBox1");
            this.fComboBox1.FormattingEnabled = true;
            this.fComboBox1.Items.AddRange(new object[] {
            resources.GetString("fComboBox1.Items"),
            resources.GetString("fComboBox1.Items1"),
            resources.GetString("fComboBox1.Items2"),
            resources.GetString("fComboBox1.Items3"),
            resources.GetString("fComboBox1.Items4"),
            resources.GetString("fComboBox1.Items5"),
            resources.GetString("fComboBox1.Items6"),
            resources.GetString("fComboBox1.Items7"),
            resources.GetString("fComboBox1.Items8"),
            resources.GetString("fComboBox1.Items9"),
            resources.GetString("fComboBox1.Items10"),
            resources.GetString("fComboBox1.Items11")});
            this.fComboBox1.Name = "fComboBox1";
            // 
            // lblCaja
            // 
            resources.ApplyResources(this.lblCaja, "lblCaja");
            this.lblCaja.ForeColor = System.Drawing.Color.Black;
            this.lblCaja.Name = "lblCaja";
            // 
            // fLabelBig1
            // 
            resources.ApplyResources(this.fLabelBig1, "fLabelBig1");
            this.fLabelBig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fLabelBig1.Name = "fLabelBig1";
            // 
            // pgbProceso
            // 
            resources.ApplyResources(this.pgbProceso, "pgbProceso");
            this.pgbProceso.Name = "pgbProceso";
            // 
            // FrmGenerar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pgbProceso);
            this.Controls.Add(this.fGroupBox3);
            this.Controls.Add(this.fGroupBox1);
            this.Controls.Add(this.fLabelBig1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenerar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGenerar_KeyDown);
            this.fGroupBox3.ResumeLayout(false);
            this.fGroupBox1.ResumeLayout(false);
            this.fGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private Controles_Standar.FGroupBox fGroupBox1;
        private Controles_Standar.FLabelMedium lblCaja;
        private Controles_Standar.FButtonCancelar btnCancelar;
        private Controles_Standar.FGroupBox fGroupBox3;
        private System.Windows.Forms.Button btnGenerar;
        private Controles_Standar.FComboBox fComboBox1;
        private System.Windows.Forms.ProgressBar pgbProceso;


    }
}