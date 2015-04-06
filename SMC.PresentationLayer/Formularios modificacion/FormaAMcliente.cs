using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DataSet, DataTable
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMC.BusinessObjects;
using SMC.DataAccessLayer;
using Oracle.DataAccess.Client;
namespace SMC.PresentationLayer
{
    public partial class FormaAMcliente : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
       public static Validaciones claseValidar = new Validaciones();

        public FormaAMcliente()
        {
            InitializeComponent();
        }
        public int ConfirmarTransaccion;
        private void RecuperarEstados() {
            OracleConnection connection = new OracleConnection();

            try
            {


               Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;

                //Preparar el SQL para el objeto Command
                string select = "SELECT StateCode, StateName " +
                                "FROM States";
                OracleCommand command = new OracleCommand(select, connection);

                //Abrir la conexion
                connection.Open();//ConnectionString

                //Crear un DataReader para leer los datos (SELECT)
                //ejecutar el command.
                //SqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
                OracleDataReader reader = command.ExecuteReader();

                #region Primera forma

                ////Recuperar fila por fila los datos del SELECT.
                //while (reader.Read())
                //{
                //    //Pasar los datos al ComboBox.
                //    //cboEstado.Items.Add(reader[0] + " " + reader[1]);
                //    cboEstado.Items.Add(reader["StateCode"] + " " + reader["StateName"]);
                //}

                ////Cerrar el cursor.
                //reader.Close();

                #endregion

                #region Segunda Forma

                //Utilizar un objeto: DataTable
                DataTable states = new DataTable();
                states.Load(reader);//Crea la estructura (TABLE) y recupera los datos.

                //Vincular-enlazar los datos del DataTable con el ComboBox.
                cboEstado.DataSource = states;
                cboEstado.DisplayMember = "StateName";//Columna a mostrar.
                cboEstado.ValueMember = "StateCode";//Columna para INSERTAR y ACTUALIZAR.

               

                #endregion
            }
            //errores de BD.
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                //Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de Oracle Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }//errores del cliente.
            catch (Exception ex)
            {
                //Utilizar la clase para gestionar excepciones.
                //Excepciones.Gestionar(ex);

                ////Mostrar el mensaje personalizado.
                //MessageBox.Show(Excepciones.MensajePersonalizado,
                //    "Error de C#",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);
            }
            finally
            {
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }
        }
        private void FormaAMcliente_Load(object sender, EventArgs e)
        {
            this.Location = new Point(530, 130);
            RecuperarEstados();

            //si queremos actualizar los datos mostramos cada uno en los controles
            if (FormaMcliente.BotonPresionado == 2)
            {
                txtNombre.Text = FormaMcliente.Nombre;
                txtDireccion.Text = FormaMcliente.Direccion;
                txtCiudad.Text = FormaMcliente.Ciudad;
                txtCodigoZip.Text = FormaMcliente.CodigoZip;
                
                
                
            }
            
        }

        private void InsertarSQLEmbebido(OracleConnection connection, string nombre, string direccion, string ciudad, string estado, string codigoZip)
        {

            //Se presiono el boton Insertar: 
            //Preparar el: INSERT.
            string insert = "INSERT INTO Customers (Name, Address, City, State, ZipCode) " +
                            "VALUES (:Name, :Address, :City, :State, :ZipCode)";

            OracleCommand command = new OracleCommand(insert, connection);

            //Como tiene parametros el SQL, hay que crear, agregar y enviar
            //los valores para los parametros.
            command.Parameters.Add(":Name", OracleDbType.Varchar2, 100).Value = nombre;
            command.Parameters.Add(":Address", OracleDbType.Varchar2, 50).Value = direccion;
            command.Parameters.Add(":City", OracleDbType.Varchar2, 20).Value = ciudad;

            command.Parameters.Add(":State", OracleDbType.Char, 2).Value = estado;

            command.Parameters.Add(":ZipCode", OracleDbType.Char, 15).Value = codigoZip;

            //Abrir la conexion.
            connection.Open();

            //Ejecutar el SQL contra la BD.
            int filasInsertadas = command.ExecuteNonQuery();//filasInsertadas = 1

            if (filasInsertadas > 0)
            {
                //limpiamos los controles para ingresar mas datos
                txtNombre.Clear();
                txtDireccion.Clear();
                txtCiudad.Clear();
                txtCodigoZip.Clear();
                txtNombre.Select();
                ConfirmarTransaccion = 1;
            }
            else {
                MessageBox.Show("Registro no insertado",
                       "Clientes",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

            }

        }

        public void InsertarCliente(string nombre, string direccion, string ciudad, string estado, string codigoZip)
        {
            
            OracleConnection connection = new OracleConnection();
            #region controlar campos vacios
            if (nombre == "" || direccion == "" || ciudad == "" || codigoZip == "")
            {
                MessageBox.Show("Los campos estan vacios \n Ingrese informacion", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //verificamos cual de los textbox estan vacios y ubicamos el foco ahi
                if (nombre == "") txtNombre.Select();
                else if (direccion == "") txtDireccion.Select();
                else if (ciudad == "") txtCiudad.Select();
                else if (codigoZip == "") txtCodigoZip.Select();
            #endregion
            }
            else
            {

                try
                {

                  
                    //no olvidar borrar estas lineas despues de probar

                    connection.ConnectionString = Conexion.CadenaConexion;
                    //Verificar si se hace un INSERT o un UPDATE
                    //1 corresponde a insertar nuevo registro
                    if (FormaMcliente.BotonPresionado == 1)
                    {
                        //lamamos al metodo y enviamos los parametros correspondientes
                        InsertarSQLEmbebido(connection, nombre, direccion, ciudad, estado, codigoZip);

                        

                    }
                    else//Actualizar el registro correspondiente.
                        if (FormaMcliente.BotonPresionado == 2)
                        {
                            //Se presiono el boton Modificar: 
                            //Preparar el: UPDATE.


                            string update = "UPDATE Customers SET  " +
                            "Name=:Name,Address=:Address,City=:City,State=:State,ZipCode=:ZipCode " +
                            "WHERE CustomerID=:CustomerID";

                            OracleCommand command = new OracleCommand(update, connection);
                            //Como tiene parametros el SQL, hay que crear, agregar y enviar
                            //los valores para los parametros.
                            command.Parameters.Add(":Name", OracleDbType.Varchar2, 100).Value = nombre;
                            command.Parameters.Add(":Address", OracleDbType.Varchar2, 50).Value = direccion;
                            command.Parameters.Add(":City", OracleDbType.Varchar2, 20).Value = ciudad;

                            command.Parameters.Add(":State", OracleDbType.Char, 2).Value = estado;
                            //cboEstado.SelectedValue.ToString()
                            command.Parameters.Add(":ZipCode", OracleDbType.Char, 15).Value = codigoZip;

                            //Parametro para el primary key. El para parametro se envia de la ventana anterior.
                            command.Parameters.Add(":CustomerID", OracleDbType.Int32, 4).Value = FormaMcliente.CustomerID;

                            //Abrir la conexion.
                            connection.Open();

                            //Ejecutar el SQL contra la BD.
                            int filasActualizadas = command.ExecuteNonQuery();//filasActualizadas = 1

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Registro actualizado",
                                    "Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                    ConfirmarTransaccion=2;
                               
                            }
                            else
                            {
                                MessageBox.Show("No se puedo actualizar el cliente",
                                    "Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }


                        }
                }
                //errores de BD.
                catch (OracleException ex)
                {
                    //Utilizar la clase para gestionar excepciones.
                    // Excepciones.Gestionar(ex);

                    //Mostrar el mensaje personalizado.
                    MessageBox.Show("", "Error de SQL Server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }//errores del cliente.
                catch (Exception ex)
                {
                    ////Utilizar la clase para gestionar excepciones.
                    //Excepciones.Gestionar(ex);

                    ////Mostrar el mensaje personalizado.
                    //MessageBox.Show(Excepciones.MensajePersonalizado,
                    //    "Error de C#",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Error);
                }
                finally
                {
                    //Cerrar la conexion
                    connection.Close();

                    //Liberar memoria.
                    connection.Dispose();
                }
            }
        
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //si estan vacias las cajas de texto avisar al usuario que deben llenarse
            
             InsertarCliente(txtNombre.Text,txtDireccion.Text,txtCiudad.Text, cboEstado.SelectedValue.ToString(),txtCodigoZip.Text);
             
            //despues de insertar refrescamos los datos
             if (ConfirmarTransaccion == 2)
             {
                 FormaMcliente cliente = (FormaMcliente)Application.OpenForms[0];
                 cliente.txtNombre.Text = txtNombre.Text;
                 cliente.txtDireccion.Text = txtDireccion.Text;
                 cliente.txtCiudad.Text = txtCiudad.Text;
                 cliente.txtCodigoZip.Text = txtCodigoZip.Text;
             }
           
           
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //parametros mas importantes 2= validar solo texto y nombre de textbox
            claseValidar.validar(sender,e,2,txtNombre);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //parametros mas importantes 2= validar solo texto y nombre de textbox
            claseValidar.validar(sender, e, 5, txtDireccion);
        }

        private void txtCodigoZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            claseValidar.validar(sender, e, 1, txtCodigoZip);
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            claseValidar.validar(sender, e, 2, txtCiudad);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
