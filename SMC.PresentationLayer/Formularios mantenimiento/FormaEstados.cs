using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DataSet
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;//Proveedor nativo para: SQL Server.

namespace SMC.PresentationLayer
{
     public partial class FormaEstados : SMC.PresentationLayer.FormaPlantillaAgregarModificar
     {
         private DataSet _datos;

        public FormaEstados()
        {
            InitializeComponent();

            //Inicializar el DataSet
            _datos = new DataSet();
        }

        private void FormaEstados_Load(object sender, EventArgs e)
        {
            Recuperar();
        }

        private void Recuperar()
        {
            //Recuperar los datos de la tabla: States y mostrarlos 
            //en el DataGridView.

            //1.-Crear-instanciar y configurar un objeto: Connection.
            SqlConnection connection = new SqlConnection();

            try
            {
                //connection.ConnectionString = "Data Source=(local);Initial Catalog=MMABooks;User ID=sa;Password=sa";
                connection.ConnectionString = Conexion.CadenaConexion;//get

                //Abrir la conexion.
                //connection.Open();//ConnectionString

                //2.-Crear y configurar un DataAdapter
                //tiene 4 objecto de tipo: Comand. SELECT, INSERT, DELETE, UPDATE
                SqlDataAdapter adapter = new SqlDataAdapter();

                //Crear y un configurar: Command
                SqlCommand command = new SqlCommand();
                //command.CommandText = "SELECT * FROM States";
                command.CommandText = "SELECT StateCode, StateName FROM States";
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                //Configurar el DataAdapter
                adapter.SelectCommand = command;//SELECT

                //adapter.InsertCommand = command;//INSERT
                //adapter.DeleteCommand = command;//DELETE
                //adapter.UpdateCommand = command;//UPDATE

                //3.- Crear y configurar un objeto: DataSet
                //DataSet datos = new DataSet();//base de datos.
                //_datos = new DataSet();               

                adapter.Fill(_datos, "States");//(0)

                //adapter.Fill(temporal, "States");//(0)
                //if (_datos.Tables["States"].Rows.Count == 0)

                //adapter.Fill(_datos, "Products");//(1)

                //Fill:
                //1.- Abrir la conexion (open)
                //2.- Utilizar la propiedad: SelectCommand del adapter para hacer el SELECT
                //3.- Crear un clase (DataTable) con estructura del tabla segun el SELECT
                //4.- Recupera los datos y llena el Datable.
                //5.- Cierra la conexion.

                //4.- Vincular-enlazar (MOSTRAR) los datos del DataSet a un control.
                dgvDatos.DataSource = _datos;//DataSet, DataTable, DataView, Collectins, Generics
                dgvDatos.DataMember = "States";//mostrar la tabla: States

            }//errores de BD.
            catch (SqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Recuperar los datos de la tabla: States y mostrarlos 
            //en el DataGridView.

            //1.-Crear-instanciar y configurar un objeto: Connection.
            SqlConnection connection = new SqlConnection();

            try
            {
                //connection.ConnectionString = "Data Source=(local);Initial Catalog=MMABooks;User ID=sa;Password=sa";
                connection.ConnectionString = Conexion.CadenaConexion;//get

                //Abrir la conexion.
                connection.Open();//ConnectionString

                //2.-Crear y configurar un DataAdapter
                //tiene 4 objecto de tipo: Comand. SELECT, INSERT, DELETE, UPDATE
                SqlDataAdapter adapter = new SqlDataAdapter();

                #region Insert 
                //Crear y un configurar los Command
                //INSERT
                SqlCommand commandInsert = new SqlCommand();

                string codigo = "XA";
                string nombre = "Tungurahua";

                //Preparar INSERT   
                //INSERT DIRECTO
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES ('1', 'Tungurahua')";
                //INSERT CON PARAMETROS. SQL Inyection
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES ('"+codigo+"', '"+nombre+"')";

                //INSERT CON PARAMETROS. 
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (?, ?)";//Oledb
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (:x, :y)";//Oracle
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (:x, :y)";//Posgresql
                //commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (?x,?y)";//Oracle

                //INSERT CON PARAMETROS EN SQL SERVER
                commandInsert.CommandText = "INSERT INTO States (StateCode, StateName) VALUES (@StateCode, @StateName)";//Sql Server.
                commandInsert.CommandType = CommandType.Text;
                commandInsert.Connection = connection;

                //Cuando el SQL tiene parametros hay que hacer lo siguiente:
                //1.- Crear el o los parametros.
                //2.- Hay que agregar los parametros a la coleccion de parametros
                //    (Parameters) del Command.
                //3.- Enviar los valores para cada parametro
                //    ANTES DE EJECUTAR EL SQL.

                //1.- Crear el o los parametros.
                SqlParameter parametro1 = new SqlParameter();
                parametro1.ParameterName = "@StateCode";
                parametro1.SqlDbType = SqlDbType.Char;
                parametro1.Size = 2;                
                //solo para el caso en el que valor del parametro se tome 
                //de una celda del DataGridView
                parametro1.SourceColumn = "StateCode";

                SqlParameter parametro2 = new SqlParameter("@StateName", SqlDbType.VarChar, 20, "StateName");

                //2.- Hay que agregar el o los parametros a la coleccion de parametros
                //    (Parameters) del Command.
                commandInsert.Parameters.Add(parametro1);//posicion (0)
                commandInsert.Parameters.Add(parametro2);//posicion (1)

                //3.- Enviar los valores para cada parametro
                //commandInsert.Parameters[0].Value = "TU";
                //commandInsert.Parameters["@StateCode"].Value = "TU";
                //commandInsert.Parameters[1].Value = "Tungurahua";
                //commandInsert.Parameters["@StateName"].Value = "Tungurahua";

                //    NOTA: En el caso del DataGridView que esta vinculado al DataSet
                //          no hace falta enviar los valores para los parametros, porque
                //          los toma de las CELDAS del DataGridView AUTOMATICAMENTE.

                #endregion

                #region Delete

                //Crear y configuar los Command para el DELETE y el UPDATE
                SqlCommand commandDelete = new SqlCommand();
                //Preparar el SQL
                string delete = "DELETE FROM States " +
                                "WHERE StateCode= @StateCode";
                commandDelete.CommandText = delete;
                commandDelete.CommandType = CommandType.Text;
                commandDelete.Connection = connection;
                //Como tiene parametros el SQL.
                //1, 2 - Crear y agregar el o los parametros.
                commandDelete.Parameters.Add("@StateCode", SqlDbType.Char, 2, "StateCode");//parameter1
                //3.- Enviar los valores para cada parametro
                //commandDelete.Parameters.Add("@StateCode", SqlDbType.Char, 2).Value = "XA";//parameter1

                #endregion

                #region Update

                //Crear un configurar un Command (UPDATE)
                string update = "UPDATE States SET StateName=@StateName WHERE StateCode=@StateCode";
                //SqlCommand commandUpdate = new SqlCommand();
                //commandUpdate.CommandText = update;
                //commandUpdate.CommandType = CommandType.Text;
                //commandUpdate.Connection = connection;

                SqlCommand commandUpdate = new SqlCommand(update, connection);
                //Como tiene parametros el SQL.
                //1, 2 - Crear y agregar el o los parametros al objeto Command
                commandUpdate.Parameters.Add("@StateName", SqlDbType.VarChar, 20, "StateName");
                commandUpdate.Parameters.Add("@StateCode", SqlDbType.Char, 2, "StateCode");

                #endregion

                //Configurar las propiedades del DataAdapter
                //a) InsertCommand
                //b) DeleteCommand
                //c) UpdateCommand
                adapter.InsertCommand = commandInsert;//INSERT
                adapter.DeleteCommand = commandDelete;//DELETE
                adapter.UpdateCommand = commandUpdate;//UPDATE

                //3.- Crear y configurar un objeto: DataSet
                //DataSet datos = new DataSet();//base de datos.
                //_datos = new DataSet();

                DataSet temporal = new DataSet();                

                //temporal = _datos.Copy();
                temporal.Merge(_datos);//copia la estructuras pero solo con los modificados.

                //adapter.Fill(_datos, "States");
                //adapter.Update(_datos, "States");
                adapter.Update(temporal, "States");

                _datos.Clear();
                Recuperar();

                //UPDATE:                
                //1.- Abrir la conexion (open)
                //2.- Utilizar la propiedades: 
                //    InsertCommand(INSERT)
                //    DeleteCommand (DELETE)
                //    UpdateCommand (UPDATE) del adapter
                //    para actualizar la base de datos.               
                //    NOTA: Esto se lo hace usando la propiedad: (RowState) 
                //          de cada objeto DataTable.
                //3.- Cierra la conexion.
                
                MessageBox.Show("Datos actualizados", "states");
            }//errores de BD.
            catch (SqlException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                Excepciones.Gestionar(ex);

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
                //Liberar memoria.
                connection.Dispose();
            }
        }
    }
}
