using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
//using SMC.PresentationLayer;
namespace SMC.DataAccessLayer.Clientes
{
     public class SQLClientes
       
    {
         
          
        // public SQLClientes()
        //{
           
        //}
        //public void InsertarCliente(string nombre, string direccion, string ciudad, string estado, string codigoZip)
        //{
        //    OracleConnection connection = new OracleConnection();

        //    try
        //    {

        //        //connection.ConnectionString = Conexion.CadenaConexion;

        //        //no olvidar borrar estas lineas despues de probar
               
        //        connection.ConnectionString = Conexion.CadenaConexion;
        //        //Verificar si se hace un INSERT o un UPDATE
        //        if (FormaMcliente.BotonPresionado == 1)
        //        {
        //            InsertarSQLEmbebido(connection, nombre, direccion, ciudad, estado, codigoZip);
        //            //insertarStoreProcedure(connection);
        //        }
        //        else//Actualizar el registro correspondiente.
        //            if (FormaMcliente.BotonPresionado == 2)
        //            {
        //                //Se presiono el boton Modificar: 
        //                //Preparar el: UPDATE.
        //                string update = "UPDATE Customers SET  " +
        //                "Name=:Name,Address=:Address,City=:City,State=:State,ZipCode=:ZipCode " +
        //                "WHERE CustomerID=:CustomerID";

        //                OracleCommand command = new OracleCommand(update, connection);
        //                //Como tiene parametros el SQL, hay que crear, agregar y enviar
        //                //los valores para los parametros.
        //                command.Parameters.Add(":Name", OracleDbType.Varchar2, 100).Value = nombre;
        //                command.Parameters.Add(":Address", OracleDbType.Varchar2, 50).Value = direccion;
        //                command.Parameters.Add(":City", OracleDbType.Varchar2, 20).Value = ciudad;

        //                command.Parameters.Add(":State", OracleDbType.Char, 2).Value = estado;
        //                //cboEstado.SelectedValue.ToString()
        //                command.Parameters.Add(":ZipCode", OracleDbType.Char, 15).Value = codigoZip;

        //                //Parametro para el primary key. El para parametro se envia de la ventana anterior.
        //                command.Parameters.Add(":CustomerID", OracleDbType.Int32, 4).Value = FormaMcliente.CustomerID;

        //                //Abrir la conexion.
        //                connection.Open();

        //                //Ejecutar el SQL contra la BD.
        //                int filasActualizadas = command.ExecuteNonQuery();//filasActualizadas = 1

        //                if (filasActualizadas > 0)
        //                {
        //                    MessageBox.Show("Registro actualizado",
        //                        "Clientes",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No se puedo actualizar el cliente",
        //                        "Clientes",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Information);
        //                }

        //            }
        //    }
        //    //errores de BD.
        //    catch (OracleException ex)
        //    {
        //        //Utilizar la clase para gestionar excepciones.
        //        // Excepciones.Gestionar(ex);

        //        //Mostrar el mensaje personalizado.
        //        MessageBox.Show("", "Error de SQL Server",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);

        //    }//errores del cliente.
        //    catch (Exception ex)
        //    {
        //        ////Utilizar la clase para gestionar excepciones.
        //        //Excepciones.Gestionar(ex);

        //        ////Mostrar el mensaje personalizado.
        //        //MessageBox.Show(Excepciones.MensajePersonalizado,
        //        //    "Error de C#",
        //        //    MessageBoxButtons.OK,
        //        //    MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        //Cerrar la conexion
        //        connection.Close();

        //        //Liberar memoria.
        //        connection.Dispose();
        //    }
        //}
        //public void recuperarEstados(ComboBox cboEstado)
        //{
        //    //Se presiono el boton: Modificar.
        //    //if (FormaMcliente.BotonPresionado == 2)
        //    //{
        //    //    //Mostrar el registro en los controles.
        //    //    txtNombre.Text = FormaMcliente.Nombre;
        //    //    txtDireccion.Text = FormaMcliente.Direccion;
        //    //    txtCiudad.Text = FormaMcliente.Ciudad;
        //    //    //txtEstado.Text = FormaMcliente.Estado; //ComboBox.
        //    //    txtCodigoZip.Text = FormaMcliente.CodigoZip;
        //    //}


        //   OracleConnection connection = new OracleConnection();

        //    try
        //    {

                
        //        Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE"; 
        //        connection.ConnectionString = Conexion.CadenaConexion;

        //        //Preparar el SQL para el objeto Command
        //        string select = "SELECT StateCode, StateName " +
        //                        "FROM States";
        //        OracleCommand command = new OracleCommand(select, connection);

        //        //Abrir la conexion
        //        connection.Open();//ConnectionString

        //        //Crear un DataReader para leer los datos (SELECT)
        //        //ejecutar el command.
        //        //SqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
        //        OracleDataReader reader = command.ExecuteReader();

        //        #region Primera forma

        //        ////Recuperar fila por fila los datos del SELECT.
        //        //while (reader.Read())
        //        //{
        //        //    //Pasar los datos al ComboBox.
        //        //    //cboEstado.Items.Add(reader[0] + " " + reader[1]);
        //        //    cboEstado.Items.Add(reader["StateCode"] + " " + reader["StateName"]);
        //        //}

        //        ////Cerrar el cursor.
        //        //reader.Close();

        //        #endregion

        //        #region Segunda Forma

        //        //Utilizar un objeto: DataTable
        //        DataTable states = new DataTable();
        //        states.Load(reader);//Crea la estructura (TABLE) y recupera los datos.

        //        //Vincular-enlazar los datos del DataTable con el ComboBox.
        //        cboEstado.DataSource = states;
        //        cboEstado.DisplayMember = "StateName";//Columna a mostrar.
        //        cboEstado.ValueMember = "StateCode";//Columna para INSERTAR y ACTUALIZAR.

        //        //if (reader.IsClosed)
        //        //{
        //        //    MessageBox.Show("Cursor cerrado");
        //        //    reader.Close();
        //        //}

        //        #endregion
        //    }
        //    //errores de BD.
        //    catch (OracleException ex)
        //    {
        //        //Utilizar la clase para gestionar excepciones.
        //        //Excepciones.Gestionar(ex);

        //        //Mostrar el mensaje personalizado.
        //        MessageBox.Show(Excepciones.MensajePersonalizado,
        //            "Error de Oracle Server",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);

        //    }//errores del cliente.
        //    catch (Exception ex)
        //    {
        //        //Utilizar la clase para gestionar excepciones.
        //        //Excepciones.Gestionar(ex);

        //        ////Mostrar el mensaje personalizado.
        //        //MessageBox.Show(Excepciones.MensajePersonalizado,
        //        //    "Error de C#",
        //        //    MessageBoxButtons.OK,
        //        //    MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        //Cerrar la conexion
        //        connection.Close();

        //        //Liberar memoria.
        //        connection.Dispose();
        //    }
        //}

        //private void InsertarSQLEmbebido(OracleConnection connection, string nombre, string direccion, string ciudad, string estado, string codigoZip)
        //{

        //    //Se presiono el boton Insertar: 
        //    //Preparar el: INSERT.
        //    string insert = "INSERT INTO Customers (Name, Address, City, State, ZipCode) " +
        //                    "VALUES (:Name, :Address, :City, :State, :ZipCode)";

        //    OracleCommand command = new OracleCommand(insert, connection);

        //    //Como tiene parametros el SQL, hay que crear, agregar y enviar
        //    //los valores para los parametros.
        //    command.Parameters.Add(":Name", OracleDbType.Varchar2, 100).Value = nombre;
        //    command.Parameters.Add(":Address", OracleDbType.Varchar2, 50).Value = direccion;
        //    command.Parameters.Add(":City", OracleDbType.Varchar2, 20).Value = ciudad;

        //    command.Parameters.Add(":State", OracleDbType.Char, 2).Value = estado;

        //    command.Parameters.Add(":ZipCode", OracleDbType.Char, 15).Value = codigoZip;

        //    //Abrir la conexion.
        //    connection.Open();

        //    //Ejecutar el SQL contra la BD.
        //    int filasInsertadas = command.ExecuteNonQuery();//filasInsertadas = 1

        //    if (filasInsertadas > 0)
        //    {
        //        MessageBox.Show("Registro insertado",
        //            "Clientes",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);
        //    }

        //}
        //private void insertarStoreProcedure(OracleConnection connection)
        //{
        //    //Se presiono el boton Insertar: 

        //    //SqlCommand command = new SqlCommand();
        //    //command.CommandText = "P_inssertar_Customers";
        //    //command.CommandType = CommandType.StoredProcedure;
        //    //command.Connection = connection;

        //    ////Como el store procedure tiene parametros hay que crear,agregar y enviar valores para los parametros
        //    ////los valores para los parametros.
        //    //command.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = txtNombre.Text;
        //    //command.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = txtDireccion.Text;
        //    //command.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = txtCiudad.Text;

        //    //command.Parameters.Add("@State", SqlDbType.Char, 2).Value = cboEstado.SelectedValue.ToString();

        //    //command.Parameters.Add("@ZipCode", SqlDbType.Char, 15).Value = txtCodigoZip.Text;

        //    ////Abrir la conexion.
        //    //connection.Open();

        //    ////Ejecutar el Store procedure de la BD.
        //    //int filasInsertadas = command.ExecuteNonQuery();//filasInsertadas = 1

        //    //if (filasInsertadas > 0)
        //    //{
        //    //    MessageBox.Show("Registro insertado",
        //    //        "Clientes",
        //    //        MessageBoxButtons.OK,
        //    //        MessageBoxIcon.Information);
        //    //    txtNombre.Text = "";
        //    //    txtDireccion.Text = "";
        //    //    txtCodigoZip.Text = "";
        //    //    txtCiudad.Text = "";
        //    //}
        //}
    }

}
