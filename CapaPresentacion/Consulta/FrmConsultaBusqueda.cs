﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Consulta
{
    public partial class FrmConsultaBusqueda : Form
    {
        private ReservaNegocio oNegocio;
        public FrmConsultaBusqueda(string texto)
        {
            InitializeComponent();
            lblTexto.Text = texto;
            CargarDatos();
        }

        private void CargarDatos()
        {
            oNegocio = new ReservaNegocio();
            vistaBusquedaReservasBindingSource.DataSource = oNegocio.SelectViewBusquedaReservas(q=>q.completo_huesped.Contains(lblTexto.Text));
        }

        private void FrmConsultaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
