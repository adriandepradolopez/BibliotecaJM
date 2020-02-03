using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaJM
{
    public partial class FM_Listados : BibliotecaJM.FM_Modelo
    {
        private UsuarioActual usuarioActual;

        public FM_Listados()
        {
            InitializeComponent();
        }

        public FM_Listados(UsuarioActual usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
        }
    }
}
