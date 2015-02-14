using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMC.PresentationLayer
{
    public partial class FormaMenu : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        public FormaMenu()
        {
            InitializeComponent();
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            FormaMcliente ventanaMcliente = new FormaMcliente();

            //Abrir dentro del contenedor.
            ventanaMcliente.MdiParent = this;            
            ventanaMcliente.Show();
        }

        private void tsbClientes_Click(object sender, EventArgs e)
        {
            //Llamar al método que se dispara cuando el evento Click del menu:Clientes, ocurre.
            mnuClientes_Click(sender, e);
        }

        private void FormaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuEstados_Click(object sender, EventArgs e)
        {           
            FormaEstados ventanaEstados = new FormaEstados();

            //Abrir dentro del contenedor.
            ventanaEstados.MdiParent = this;
            ventanaEstados.Show();
        }

        private void FormaMenu_Load(object sender, EventArgs e)
        {
            this.Text = "Esta conectado a la BD: " + 
                        Conexion.BaseDatos + 
                        "     con el usuario: " +
                        Conexion.Usuario;
        }
    }
}
