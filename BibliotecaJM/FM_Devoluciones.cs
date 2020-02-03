﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaJM
{
    public partial class FM_Devoluciones : BibliotecaJM.FM_Modelo
    {
        private UsuarioActual usuarioActual;

        public FM_Devoluciones()
        {
            InitializeComponent();
        }

        public FM_Devoluciones(UsuarioActual usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
        }

        private void FM_Devoluciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dS_LibrosPrestados.LibrosPrestados' Puede moverla o quitarla según sea necesario.
            this.librosPrestadosTableAdapter.Fill(this.dS_LibrosPrestados.LibrosPrestados);

        }

        private void bBuscarLibro_Click(object sender, EventArgs e)
        {
            if (idLibDev.Text == string.Empty)
            {
                this.librosPrestadosTableAdapter.Fill(this.dS_LibrosPrestados.LibrosPrestados);
                return;

            }

            librosPrestadosTableAdapter.FillByIDLIB(
                dS_LibrosPrestados.LibrosPrestados,
                int.Parse(idLibDev.Text));


        }
    }
}
