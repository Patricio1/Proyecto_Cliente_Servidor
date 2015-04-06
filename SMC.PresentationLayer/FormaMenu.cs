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
            BusquedasPersonalizadas.FormaBuscarProducto.indiceVentanaProducto += 1;
            FormaBuscarCustomers.indiceVentanaCustomer += 1;
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado empleado = new SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado();
            empleado.MdiParent = this;
            empleado.Show();
        }

        private void mnuProductos_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos productos = new SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void tsbProductos_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos productos = new SMC.PresentationLayer.Formularios_mantenimiento.FormaMProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura factura = new SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura();
            factura.MdiParent = this;
            factura.Show();
        }

        private void mnuOpcionesOrdenes_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions ordenes = new SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions();
            ordenes.MdiParent = this;
            ordenes.Show();
        }

        private void tsbOpcionesOrdenes_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions ordenes = new SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions();
            ordenes.MdiParent = this;
            ordenes.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void tsBarraHerramientas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuProcesos_Click(object sender, EventArgs e)
        {

        }
    }
}
