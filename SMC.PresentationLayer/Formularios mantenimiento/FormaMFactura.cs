using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace SMC.PresentationLayer.Formularios_mantenimiento
{
    public partial class FormaMFactura : SMC.PresentationLayer.FormaPlantillaMantenimiento,SMC.BusinessObjects.IForm
    {
        private static string _numeroFactura;
        private static string _cliente;
        private static string _fecha;
        private static string _totalProductos;
        private static string _impuesto;
        private static string _envio;
        private static string _facturaTotal;
        private static int _botonPresionado;
        private static int _ExisteFactura;

        public FormaMFactura()
        {
            InitializeComponent();
        }
        public bool LoadDataGridView(DataTable dataTableParam)
        {
            DataGridView data = new DataGridView();
            data.DataSource = dataTableParam;

            return true;
        }

        #region Propiedades
        public static string NumeroFactura
        {
            set {
                _numeroFactura = value;
            }
            get {
                return _numeroFactura;
            }
        }

        public static string Cliente
        {
            set
            {
                _cliente = value;
            }
            get
            {
                return _cliente;
            }
        }


        public static string Fecha
        {
            set
            {
                _fecha = value;
            }
            get
            {
                return _fecha;
            }
        }

        public static string TotalProductos
        {
            set
            {
                _totalProductos = value;
            }
            get
            {
                return _totalProductos;
            }
        }

        public static string Impuesto
        {
            set
            {
                _impuesto = value;
            }
            get
            {
                return _impuesto;
            }
        }

        public static string Envio
        {
            set
            {
                _envio = value;
            }
            get
            {
                return _envio;
            }
        }

        public static string FacturaTotal
        {
            set
            {
                _facturaTotal = value;
            }
            get
            {
                return _facturaTotal;
            }
        }

        public static int BotonPresionado
        {
            set
            {
                _botonPresionado = value;
            }
            get
            {
                return _botonPresionado;
            }
        }
        #endregion



        private void FormaMFacturaDetalle_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1, 5);
            txtNumeroFactura.Select();
            //BusquedasPersonalizadas.FormaBuscarProducto.indiceVentanaProducto += 1;
            //FormaBuscarCustomers.indiceVentanaCustomer += 1;

        }

        private void recuperar() {
            OracleConnection connection = new OracleConnection();
            try
            {
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();
                string select = "SELECT InvoiceID,CustomerID,InvoiceDate,ProductTotal,SalesTax, Shipping, InvoiceTotal " +
                                 "FROM INVOICES WHERE InvoiceID =:InvoiceID";

                OracleCommand command = new OracleCommand(select, connection);

                command.Parameters.Add(":InvoiceID", OracleDbType.Int32, 6).Value = Convert.ToInt32(txtNumeroFactura.Text);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtNumeroFactura.Text = reader[0].ToString();
                    txtCliente.Text = reader[1].ToString();
                    txtFecha.Value = Convert.ToDateTime(reader[2]);
                    txtTotalProductos.Text = reader[3].ToString();
                    txtImpuesto.Text = reader[4].ToString();
                    txtEnvio.Text = reader[5].ToString();
                    txtFacturaTotal.Text = reader[6].ToString();
                   
                }
                else {
                    MessageBox.Show("No se encontro el registro",
                                            "Facturas",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    txtNumeroFactura.Clear();
                    txtCliente.Clear();
                    txtTotalProductos.Clear();
                    txtImpuesto.Clear();
                    txtEnvio.Clear();
                    txtFecha.Text = "";
                    txtFacturaTotal.Clear();
                    txtNumeroFactura.Select();
                    btnVerFactura.Enabled = false;
                }
                if (reader.HasRows)
                {
                    _ExisteFactura = 1;
                }
                else _ExisteFactura = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Numero Factura requerido\n para la busqueda", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroFactura.Clear();
                txtCliente.Clear();
                txtTotalProductos.Clear();
                txtImpuesto.Clear();
                txtEnvio.Clear();
                txtFecha.Text = "";
                txtFacturaTotal.Clear();
                txtNumeroFactura.Select();
                btnVerFactura.Enabled = false;
                _ExisteFactura = 0;

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recuperar();
            if(_ExisteFactura==1){
                btnVerFactura.Enabled = true;
            }
            else btnVerFactura.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {

                BotonPresionado = 2;
                FormaMFactura.NumeroFactura = (txtNumeroFactura.Text);
                FormaMFactura.Cliente = txtCliente.Text;
                FormaMFactura.Fecha = txtFecha.Text;
                FormaMFactura.TotalProductos = (txtTotalProductos.Text);
                FormaMFactura.Impuesto = (txtImpuesto.Text);
                FormaMFactura.Envio = (txtEnvio.Text);
                FormaMFactura.FacturaTotal = (txtFacturaTotal.Text);

                SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura FacturaDetalle = new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura();
                FacturaDetalle.Text = "Modificar Factura";
                FacturaDetalle.btnBuscar.Visible = false;
                FacturaDetalle.ShowDialog();
            }
            else MessageBox.Show("Busque datos");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
          

            
           
            BotonPresionado = 1;
            SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura FacturaDetalle = new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura();
            FacturaDetalle.MdiParent = this.MdiParent;
            FacturaDetalle.Opener = this;
           // FacturaDetalle.Text = "Insertar Factura";
            this.Hide();
            
            FacturaDetalle.Show();
          


            //BotonPresionado = 1;
            //SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura FacturaDetalle = new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura();
            //FacturaDetalle.Text = "Insertar Factura";

            //FacturaDetalle.ShowDialog();
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();

            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";

            try
            {
                if (txtNumeroFactura.Text != "")
                {
                    DialogResult confirmar = MessageBox.Show("Eliminar el registro?",
                                             "Factura",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Error);
                    if (confirmar == DialogResult.Yes)
                    {
                        string deleteDetalle = "DELETE FROM InvoiceLineItems WHERE INVOICEID=:INVOICEID";
                       
                        connection.Open();
                        OracleCommand command = new OracleCommand(deleteDetalle, connection);
                        
                        //crear y agregar parametros
                        command.Parameters.Add(":INVOICEID", OracleDbType.Int32, 9).Value = Convert.ToInt32(txtNumeroFactura.Text);

                        int RegistroEliminado = command.ExecuteNonQuery();

                        string delete = "DELETE FROM Invoices WHERE INVOICEID=:INVOICEID";
                        OracleCommand commandDelete = new OracleCommand(delete, connection);
                        commandDelete.Parameters.Add(":INVOICEID", OracleDbType.Int32, 9).Value = Convert.ToInt32(txtNumeroFactura.Text);

                        int RegistroEliminadoDetalle = commandDelete.ExecuteNonQuery();
                        if (RegistroEliminadoDetalle > 0)
                        { 
                        
                        }
                        //MessageBox.Show("Registro eliminado",
                        //                    "Empleados",
                        //                    MessageBoxButtons.OK,
                        //                    MessageBoxIcon.Error);
                        else MessageBox.Show("Registro no eliminado",
                                               "Factura",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Error);

                        txtNumeroFactura.Clear();
                        txtCliente.Clear();
                        txtEnvio.Clear();
                        txtFacturaTotal.Clear();
                        txtFecha.Text = "";
                        txtTotalProductos.Clear();
                        txtImpuesto.Clear();
                        btnVerFactura.Enabled = false;


                    }

                }
                else
                {
                    MessageBox.Show("Ingresar ID Empleado",
                                                  "Empleados",
                                                  MessageBoxButtons.OK,
                                                  MessageBoxIcon.Error);
                    btnVerFactura.Enabled = false;
                }
            }
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            //SE crea una instancia de tipo 'GestionarReporteDetalleFactura' para crear el archivo XML 
            
            SMC.PresentationLayer.Reportes.GestionarReporteDetalleFactura objetoReporte = new SMC.PresentationLayer.Reportes.GestionarReporteDetalleFactura();
            //se invoca este metodo que creara el XML con el resultado de las consultas establecidas
            //para ello requiere de un numero de factura
            objetoReporte.buscarRegistros(Convert.ToInt32(txtNumeroFactura.Text));
            //finalmente instaciamos el objeto que muestra el reporte
            SMC.PresentationLayer.Reportes.verReporteFactura verReporte = new Reportes.verReporteFactura();
            verReporte.Show();
        }
    }
}
