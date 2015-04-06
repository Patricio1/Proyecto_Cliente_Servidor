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
    public partial class OrderOptionsAgregar : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        public OrderOptionsAgregar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();
            try
            {
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();

                OracleCommand commandInsert = new OracleCommand();
                commandInsert.CommandText = "INSERT INTO OrderOptions (SalesTaxRate, FirstBookShipCharge, AdditionalBookShipCharge) "
                                 + " VALUES(:SalesTaxRate, :FirstBookShipCharge, :AdditionalBookShipCharge)";
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                OracleDataAdapter adapter = new OracleDataAdapter();
                commandInsert.Parameters.Add(":SalesTaxRate", OracleDbType.Int32, 38).Value=txtTasa.Text;
                commandInsert.Parameters.Add(":FirstBookShipCharge", OracleDbType.Int32, 38).Value=txtPrime.Text;
                commandInsert.Parameters.Add(":AdditionalBookShipCharge", OracleDbType.Int32,38).Value=txtAdicional.Text;
                
                
                int filasActualizadas = commandInsert.ExecuteNonQuery();//filasActualizadas = 1

                if (filasActualizadas > 0)
                {
                    MessageBox.Show("Registro Insertado Correctamente",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se puedo insertar el registro",
                        "Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                
            }
            catch
            {

                MessageBox.Show("Error de Oracle Server No Se Puede Conectar");
                      
            }
       }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtTasa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrime_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderOptionsAgregar_Load(object sender, EventArgs e)
        {
            this.Location = new Point(645, 90);
        }
  }
}
