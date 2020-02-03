using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaJM
{
    public partial class FM_Lectores : BibliotecaJM.FM_Modelo
    {
        private UsuarioActual usuarioActual;

        public FM_Lectores()
        {
            InitializeComponent();
        }

        public FM_Lectores(UsuarioActual usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
        }

        private void lectoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lectoresBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dS_Lectores);

        }

        private void FM_Lectores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dS_Lectores.lectores' Puede moverla o quitarla según sea necesario.
            this.lectoresTableAdapter.Fill(this.dS_Lectores.lectores);
            ModoBusqueda();

        }

        private void ModoBusqueda()
        {
            gbBusqueda.Enabled = true;
            gbEdicion.Enabled = false;
        }

        private void ModoEdicion()
        {
            gbBusqueda.Enabled = false;
            gbEdicion.Enabled = true;
        }

        private void bBuscarId_Click(object sender, EventArgs e)
        {
            if (tbBuscarId.Text == string.Empty)
            {
                this.lectoresTableAdapter.Fill(this.dS_Lectores.lectores);
                return;

            }

            lectoresTableAdapter.FillByID(
                dS_Lectores.lectores,
                int.Parse(tbBuscarId.Text));
        
    
    }

        private void BBuscarNombre_Click(object sender, EventArgs e)
        {
            lectoresTableAdapter.FillByNombre(
                dS_Lectores.lectores,
                tbBuscarNombre.Text);
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            ModoEdicion();
            nombre_lecTextBox.Focus();
            lectoresBindingSource.AddNew();
        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            ModoEdicion();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultadoDialogoConfirmacion = MessageBox.Show(
                "¿Desea eliminar el registro seleccionado?",
                "Confirmacion",
                MessageBoxButtons.YesNo);

            if (resultadoDialogoConfirmacion == DialogResult.Yes)
            {
                try
                {
                    lectoresBindingSource.RemoveCurrent();
                    lectoresTableAdapter.Update(dS_Lectores.lectores);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            lectoresBindingSource.CancelEdit();
            ModoBusqueda();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                lectoresBindingSource.EndEdit();
                lectoresTableAdapter.Update(dS_Lectores.lectores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ModoBusqueda();
        }

        
    }
}
