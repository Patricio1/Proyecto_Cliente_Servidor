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
    public partial class FormaMProductos : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        DataSet _datos;
        public FormaMProductos()
        {
            InitializeComponent();
            _datos = new DataSet();
        }

        private void recuperar() {
            OracleConnection connection = new OracleConnection();
            string cadena = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            Conexion.CadenaConexion = cadena;
            connection.ConnectionString = Conexion.CadenaConexion;
             

            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter();
                OracleCommand command = new OracleCommand();
                command.CommandText = "SELECT PRODUCTCODE,DESCRIPTION,UNITPRICE,ONHANDQUANTITY FROM PRODUCTS";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                
                adapter.SelectCommand = command;



                adapter.Fill(_datos, "PRODUCTS");
                dgvProductos.DataSource = _datos;
                dgvProductos.DataMember = "PRODUCTS";

            }
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de SQL Server",
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
                //if (connection.State == ConnectionState.Open)
                //{
                //    //Cerrar la conexion.
                //    connection.Close();
                //}

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void FormaMProductos_Load(object sender, EventArgs e)
        {
            recuperar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();
            


            try{

                connection.ConnectionString = Conexion.CadenaConexion;
                
                connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter();
                OracleCommand commandInsert = new OracleCommand();

                #region insertar
                commandInsert.CommandText = "INSERT INTO PRODUCTS(PRODUCTCODE,DESCRIPTION,UNITPRICE,ONHANDQUANTITY) " +
                                        "VALUES(:PRODUCTCODE,:DESCRIPTION,:UNITPRICE,:ONHANDQUANTITY)";
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                //crear y agregar parametros
                commandInsert.Parameters.Add(":PRODUCTCODE", OracleDbType.Char, 10, "PRODUCTCODE");
                commandInsert.Parameters.Add(":DESCRIPTION", OracleDbType.Varchar2, 50, "DESCRIPTION");
                commandInsert.Parameters.Add(":UNITPRICE", OracleDbType.Double, 8, "UNITPRICE");
                commandInsert.Parameters.Add(":ONHANDQUANTITY", OracleDbType.Double, 38, "ONHANDQUANTITY");
                #endregion
                #region eliminar
                OracleCommand commandDelete = new OracleCommand();
                //Preparar el SQL
                string delete = "DELETE FROM PRODUCTS " +
                                "WHERE PRODUCTCODE= :PRODUCTCODE";
                commandDelete.CommandText = delete;
                commandDelete.CommandType = CommandType.Text;
                commandDelete.Connection = connection;

                commandDelete.Parameters.Add(":PRODUCTCODE", OracleDbType.Char, 10, "PRODUCTCODE");
                #endregion
                #region actualizar
                string update = "UPDATE PRODUCTS SET DESCRIPTION=:DESCRIPTION,UNITPRICE=:UNITPRICE," +
                                "ONHANDQUANTITY=:ONHANDQUANTITY WHERE PRODUCTCODE=:PRODUCTCODE";

                OracleCommand commandUpdate = new OracleCommand(update, connection);

                // crear y agregar parametros
                commandUpdate.Parameters.Add(":DESCRIPTION", OracleDbType.Varchar2, 50, "DESCRIPTION");
                commandUpdate.Parameters.Add(":UNITPRICE", OracleDbType.Double, 8, "UNITPRICE");
                commandUpdate.Parameters.Add(":ONHANDQUANTITY", OracleDbType.Double, 38, "ONHANDQUANTITY");
              commandUpdate.Parameters.Add(":PRODUCTCODE", OracleDbType.Char, 10, "PRODUCTCODE");

                #endregion
               adapter.InsertCommand = commandInsert;
               adapter.DeleteCommand = commandDelete;
               adapter.UpdateCommand = commandUpdate;

                DataSet temporal = new DataSet();
                temporal.Merge(_datos);
                adapter.Update(temporal, "PRODUCTS");
                _datos.Clear();
                recuperar();
            

        }
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
               // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show("No se puede actualizar la PK",
                    "Error de Oracle Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }//errores del cliente.
            catch (Exception ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show("No se puede actualizar la PK",
                    "Error de C#",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                //if (connection.State == ConnectionState.Open)
                //{
                //    //Cerrar la conexion.
                //    connection.Close();
                //}

                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _datos.Clear();
            recuperar();
        }
    }
}
