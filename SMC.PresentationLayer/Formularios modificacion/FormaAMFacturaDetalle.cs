using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class FormaAMFacturaDetalle : SMC.PresentationLayer.FormaPlantillaMaestroDetalle
    {
        private DataSet _datos;
        public FormaAMFacturaDetalle()
        {
            InitializeComponent();
            _datos = new DataSet();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void RecuperarDetalle() {
            OracleConnection connection = new OracleConnection();
            try
            {
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();

                string select = "SELECT InvoiceID as FACTURA,ProductCode as PRODUCTO,UnitPrice as PRECIO,Quantity as CANTIDAD,ItemTotal as TOTAL "+
                                "FROM InvoiceLineItems WHERE InvoiceID = :InvoiceID";

                OracleCommand command = new OracleCommand();
                command.CommandText = select;
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add(":InvoiceID", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtNumeroFactura.Text);

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;

                adapter.Fill(_datos, "InvoiceLineItems");
                dgvDetalle.DataSource = _datos;
                dgvDetalle.DataMember = "InvoiceLineItems";

                //crear y agregar parametro

            }
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de Oracle Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }//errores del cliente.
            catch (Exception ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de C#",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }
        
        }
        private void FormaAMFacturaDetalle_Load(object sender, EventArgs e)
        {

            #region inicializar campos
            SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura factura = new Formularios_mantenimiento.FormaMFactura();
            txtNumeroFactura.Text= SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.NumeroFactura;
            txtCliente.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Cliente;
            txtFecha.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Fecha;
            txtTotalProductos.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.TotalProductos;
            txtImpuesto.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Impuesto;
            txtEnvio.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Envio;
            txtFacturaTotal.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.FacturaTotal;
            #endregion
            RecuperarDetalle();
        }

        private void InsertarFactura() { 
        
        
        }
    }
}
