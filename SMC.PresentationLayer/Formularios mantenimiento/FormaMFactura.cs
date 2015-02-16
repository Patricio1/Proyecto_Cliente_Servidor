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
    public partial class FormaMFactura : SMC.PresentationLayer.FormaPlantillaMantenimiento
    {
        private static string _numeroFactura;
        private static string _cliente;
        private static string _fecha;
        private static string _totalProductos;
        private static string _impuesto;
        private static string _envio;
        private static string _facturaTotal;
        private static int _botonPresionado;

        public FormaMFactura()
        {
            InitializeComponent();
        }

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


        

        private void FormaMFacturaDetalle_Load(object sender, EventArgs e)
        {
            txtNumeroFactura.Select();
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
                }
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

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recuperar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BotonPresionado = 2;
            FormaMFactura.NumeroFactura = (txtNumeroFactura.Text);
            FormaMFactura.Cliente = txtCliente.Text;
            FormaMFactura.Fecha = txtFecha.Text;
            FormaMFactura.TotalProductos = (txtTotalProductos.Text);
            FormaMFactura.Impuesto = (txtImpuesto.Text);
            FormaMFactura.Envio = (txtEnvio.Text);
            FormaMFactura.FacturaTotal = (txtFacturaTotal.Text);

            SMC.PresentationLayer.Formularios_modificacion.FormaAMFacturaDetalle FacturaDetalle = new SMC.PresentationLayer.Formularios_modificacion.FormaAMFacturaDetalle();
            FacturaDetalle.Text = "Modificar Factura";
            FacturaDetalle.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BotonPresionado = 1;
            SMC.PresentationLayer.Formularios_modificacion.FormaAMFacturaDetalle FacturaDetalle = new SMC.PresentationLayer.Formularios_modificacion.FormaAMFacturaDetalle();
            FacturaDetalle.Text = "Insertar Factura";
            FacturaDetalle.ShowDialog();
        }
    }
}
