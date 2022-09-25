namespace CapaPresentacion.Consulta
{
    partial class FrmConsultaReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaReserva));
            this.fLabelBig1 = new Controles_Standar.FLabelBig();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbxDisponible = new System.Windows.Forms.PictureBox();
            this.fLabelSmall3 = new Controles_Standar.FLabelSmall();
            this.pbxMantenimiento = new System.Windows.Forms.PictureBox();
            this.fLabelSmall6 = new Controles_Standar.FLabelSmall();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paListaHabitacionesPorEstadoResultBindingSource_2 = new System.Windows.Forms.BindingSource(this.components);
            this.paListaHabitacionesPorEstadoResultBindingSource_1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConsultar = new Controles_Standar.FButtonBuscar();
            this.dtpConsulta = new System.Windows.Forms.DateTimePicker();
            this.fLabelSmall1 = new Controles_Standar.FLabelSmall();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBuscar = new Controles_Standar.FButtonBuscar();
            this.txtHuesped = new Controles_Standar.FTextBox();
            this.fLabelSmall9 = new Controles_Standar.FLabelSmall();
            this.panelListaHabitaciones = new System.Windows.Forms.Panel();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMantenimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaHabitacionesPorEstadoResultBindingSource_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaHabitacionesPorEstadoResultBindingSource_1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLabelBig1
            // 
            this.fLabelBig1.AutoSize = true;
            this.fLabelBig1.BackColor = System.Drawing.Color.Transparent;
            this.fLabelBig1.Font = new System.Drawing.Font("Segoe UI Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelBig1.ForeColor = System.Drawing.Color.White;
            this.fLabelBig1.Location = new System.Drawing.Point(12, 9);
            this.fLabelBig1.Name = "fLabelBig1";
            this.fLabelBig1.Size = new System.Drawing.Size(288, 41);
            this.fLabelBig1.TabIndex = 12;
            this.fLabelBig1.Text = "Consulta de Reservas";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.pbxDisponible);
            this.groupBox3.Controls.Add(this.fLabelSmall3);
            this.groupBox3.Controls.Add(this.pbxMantenimiento);
            this.groupBox3.Controls.Add(this.fLabelSmall6);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 510);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 57);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Leyenda de Estados";
            // 
            // pbxDisponible
            // 
            this.pbxDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxDisponible.BackColor = System.Drawing.Color.Green;
            this.pbxDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxDisponible.Location = new System.Drawing.Point(212, 26);
            this.pbxDisponible.Name = "pbxDisponible";
            this.pbxDisponible.Padding = new System.Windows.Forms.Padding(2);
            this.pbxDisponible.Size = new System.Drawing.Size(20, 20);
            this.pbxDisponible.TabIndex = 19;
            this.pbxDisponible.TabStop = false;
            // 
            // fLabelSmall3
            // 
            this.fLabelSmall3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fLabelSmall3.AutoSize = true;
            this.fLabelSmall3.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall3.ForeColor = System.Drawing.Color.White;
            this.fLabelSmall3.Location = new System.Drawing.Point(147, 29);
            this.fLabelSmall3.Name = "fLabelSmall3";
            this.fLabelSmall3.Size = new System.Drawing.Size(59, 15);
            this.fLabelSmall3.TabIndex = 20;
            this.fLabelSmall3.Text = "Disponible";
            // 
            // pbxMantenimiento
            // 
            this.pbxMantenimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxMantenimiento.BackColor = System.Drawing.Color.Black;
            this.pbxMantenimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxMantenimiento.Location = new System.Drawing.Point(111, 26);
            this.pbxMantenimiento.Name = "pbxMantenimiento";
            this.pbxMantenimiento.Padding = new System.Windows.Forms.Padding(2);
            this.pbxMantenimiento.Size = new System.Drawing.Size(20, 20);
            this.pbxMantenimiento.TabIndex = 17;
            this.pbxMantenimiento.TabStop = false;
            // 
            // fLabelSmall6
            // 
            this.fLabelSmall6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fLabelSmall6.AutoSize = true;
            this.fLabelSmall6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall6.ForeColor = System.Drawing.Color.White;
            this.fLabelSmall6.Location = new System.Drawing.Point(23, 29);
            this.fLabelSmall6.Name = "fLabelSmall6";
            this.fLabelSmall6.Size = new System.Drawing.Size(80, 15);
            this.fLabelSmall6.TabIndex = 18;
            this.fLabelSmall6.Text = "Hab. Ocupada";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 38);
            this.panel4.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(801, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 72);
            this.panel1.TabIndex = 19;
            // 
            // paListaHabitacionesPorEstadoResultBindingSource_2
            // 
            this.paListaHabitacionesPorEstadoResultBindingSource_2.DataSource = typeof(CapaEntidades.pa_ListaHabitacionesPorEstado_Result);
            // 
            // paListaHabitacionesPorEstadoResultBindingSource_1
            // 
            this.paListaHabitacionesPorEstadoResultBindingSource_1.DataSource = typeof(CapaEntidades.pa_ListaHabitacionesPorEstado_Result);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 72);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta de Reservas";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.btnConsultar);
            this.panel3.Controls.Add(this.dtpConsulta);
            this.panel3.Controls.Add(this.fLabelSmall1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 53);
            this.panel3.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.Black;
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(237, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(90, 34);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpConsulta
            // 
            this.dtpConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConsulta.Location = new System.Drawing.Point(19, 21);
            this.dtpConsulta.Name = "dtpConsulta";
            this.dtpConsulta.Size = new System.Drawing.Size(200, 20);
            this.dtpConsulta.TabIndex = 2;
            this.dtpConsulta.ValueChanged += new System.EventHandler(this.dtpConsulta_ValueChanged);
            // 
            // fLabelSmall1
            // 
            this.fLabelSmall1.AutoSize = true;
            this.fLabelSmall1.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall1.ForeColor = System.Drawing.Color.White;
            this.fLabelSmall1.Location = new System.Drawing.Point(6, 4);
            this.fLabelSmall1.Name = "fLabelSmall1";
            this.fLabelSmall1.Size = new System.Drawing.Size(95, 15);
            this.fLabelSmall1.TabIndex = 1;
            this.fLabelSmall1.Text = "Fecha de Reserva";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(362, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 72);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Búqueda Reservas";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.btnBuscar);
            this.panel5.Controls.Add(this.txtHuesped);
            this.panel5.Controls.Add(this.fLabelSmall9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 53);
            this.panel5.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(293, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 34);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Consultar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtHuesped
            // 
            this.txtHuesped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHuesped.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHuesped.Location = new System.Drawing.Point(9, 20);
            this.txtHuesped.Name = "txtHuesped";
            this.txtHuesped.Size = new System.Drawing.Size(267, 23);
            this.txtHuesped.TabIndex = 1;
            // 
            // fLabelSmall9
            // 
            this.fLabelSmall9.AutoSize = true;
            this.fLabelSmall9.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fLabelSmall9.ForeColor = System.Drawing.Color.White;
            this.fLabelSmall9.Location = new System.Drawing.Point(6, 4);
            this.fLabelSmall9.Name = "fLabelSmall9";
            this.fLabelSmall9.Size = new System.Drawing.Size(98, 15);
            this.fLabelSmall9.TabIndex = 0;
            this.fLabelSmall9.Text = "Nombre Huesped";
            // 
            // panelListaHabitaciones
            // 
            this.panelListaHabitaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListaHabitaciones.Location = new System.Drawing.Point(0, 0);
            this.panelListaHabitaciones.Name = "panelListaHabitaciones";
            this.panelListaHabitaciones.Size = new System.Drawing.Size(1020, 570);
            this.panelListaHabitaciones.TabIndex = 27;
            // 
            // FrmConsultaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1020, 570);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fLabelBig1);
            this.Controls.Add(this.panelListaHabitaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaReserva";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::. Panel de Habitaciones .::.";
            this.Load += new System.EventHandler(this.FrmReservaPanel_Load);
            this.SizeChanged += new System.EventHandler(this.FrmReservaPanel_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaReserva_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMantenimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaHabitacionesPorEstadoResultBindingSource_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paListaHabitacionesPorEstadoResultBindingSource_1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles_Standar.FLabelBig fLabelBig1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.BindingSource paListaHabitacionesPorEstadoResultBindingSource_1;
        private System.Windows.Forms.BindingSource paListaHabitacionesPorEstadoResultBindingSource_2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private Controles_Standar.FButtonBuscar btnConsultar;
        private System.Windows.Forms.DateTimePicker dtpConsulta;
        private Controles_Standar.FLabelSmall fLabelSmall1;
        private System.Windows.Forms.PictureBox pbxDisponible;
        private Controles_Standar.FLabelSmall fLabelSmall3;
        private System.Windows.Forms.PictureBox pbxMantenimiento;
        private Controles_Standar.FLabelSmall fLabelSmall6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel5;
        private Controles_Standar.FButtonBuscar btnBuscar;
        private Controles_Standar.FTextBox txtHuesped;
        private Controles_Standar.FLabelSmall fLabelSmall9;
        private System.Windows.Forms.Panel panelListaHabitaciones;







    }
}