using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;//Proveedor SQL Server.

namespace SMC.PresentationLayer
{
    public partial class FormaMcliente : SMC.PresentationLayer.FormaPlantillaMantenimiento
    {
        private static int _botonPresionado;//1=INSERTAR, 2=MODIFICAR

        //Para pasar el registro actual para actualizar.
        public static int _CustomerID;//Clave primaria.
        private static string _nombre;
        private static string _direccion;
        private static string _ciudad;
        private static string _estado;
        private static string _codigoZip;

        
        public string this[int index]
        {
            set
            {
                txtNombre.Text = value;
            }

            get
            {
                return txtNombre.Text;
            }
        }

        public String acer
        {
            set
            {
                txtNombre.Text = value;
            }
            get
            {
                return txtNombre.Text;
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

        public static int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }
        }

        public static string Nombre
        {
            set
            {
                _nombre = value;
            }
            get
            {
                return _nombre;
            }
        }

        public static string Direccion
        {
            set
            {
                _direccion = value;
            }
            get
            {
                return _direccion;
            }
        }

        public static string Ciudad
        {
            set
            {
                _ciudad = value;
            }
            get
            {
                return _ciudad;
            }
        }

        public static string Estado
        {
            set
            {
                _estado = value;
            }
            get
            {
                return _estado;
            }
        }

        public static string CodigoZip
        {
            set
            {
                _codigoZip = value;
            }
            get
            {
                return _codigoZip;
            }
        }

        public FormaMcliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormaAMcliente ventanaAMcliente = new FormaAMcliente();           
            
            //Boton presionado.
            BotonPresionado = 1; //Agregar

            ventanaAMcliente.Text = "Agregar nuevo cliente";

            //Mostrar la ventana como: Modal.
            ventanaAMcliente.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormaAMcliente ventanaAMcliente = new FormaAMcliente();

            //Boton presionado.
            BotonPresionado = 2; //Modificar            

            //Obtener la clave primaria para realizar un UPDATE.
            //CustomerID = Convert.ToInt32(txtIDcliente.Text);
            FormaMcliente.CustomerID = Convert.ToInt32(txtIDcliente.Text);

            FormaMcliente.Nombre = txtNombre.Text;
            FormaMcliente.Direccion = txtDireccion.Text;
            FormaMcliente.Ciudad = txtCiudad.Text;
            FormaMcliente.Estado = txtEstado.Text;
            FormaMcliente.CodigoZip = txtCodigoZip.Text;

            ventanaAMcliente.Text = "Modificar cliente";

            //Mostrar la ventana como: Modal.
            ventanaAMcliente.ShowDialog();
        }
        private void BuscarSqlEmbebido() {
            OracleConnection connection = new OracleConnection();

            try
            {
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;

                //Abrir la conexion.
                connection.Open();

                //Preparar el SELECT para recuperar un cliente.
                string select = "SELECT CustomerID, Name, Address, City, State, ZipCode " +
                                "FROM Customers " +
                                "WHERE CustomerID= :CustomerID";

                OracleCommand command = new OracleCommand(select, connection);

                #region primer metodo

                ////Crear, agregar el/los parametros el command (Parameters)
                //command.Parameters.Add("@CustomerID", SqlDbType.Int, 4);//posicion (0)
                ////command.Parameters.Add("@CustomerID", SqlDbType.Int, 4, "CustomerID");//DataSet con un DataGridView
                ////Enviar el valor para el parametro.
                //command.Parameters["@CustomerID"].Value = Convert.ToInt32(txtIDcliente.Text);
                //command.Parameters[0].Value = Convert.ToInt32(txtIDcliente.Text);

                #endregion

                #region segundo metodo

                //Crear, agregar el/los y envio el valor el parametro del command (Parameters)
                command.Parameters.Add(":CustomerID", OracleDbType.Int32, 4).Value =
                                                        Convert.ToInt32(txtIDcliente.Text);//posicion (0)

                #endregion

                //Crear un DataReader para recupera los datos del SELECT.
                OracleDataReader reader = command.ExecuteReader();//SELECT

                //Verificar si el reader tiene un registro recuperado.
                //Read: abre el cursor.
                if (reader.Read())
                {
                    //Mostrar el registro recuperado.
                    txtIDcliente.Text = reader[0].ToString();
                    txtNombre.Text = reader[1].ToString();
                    txtDireccion.Text = reader[2].ToString();
                    txtCiudad.Text = reader[3].ToString();
                    txtEstado.Text = reader[4].ToString();
                    txtCodigoZip.Text = reader[5].ToString();


                    //txtIDcliente.Text = reader["CustomerID"].ToString();
                    //txtNombre.Text = reader["Name"].ToString();
                    //txtDireccion.Text = reader["Address"].ToString();
                    //txtCiudad.Text = reader["City"].ToString();
                    //txtEstado.Text = reader["State"].ToString();
                    //txtCodigoZip.Text = reader["ZipCode"].ToString();  

                    //txtCodigoZip.Text = reader.GetInt32(0).ToString();
                    //txtCodigoZip.Text = reader.GetString(1).ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro el cliente",
                                    "Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtIDcliente.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtCiudad.Clear();
                    txtEstado.Clear();
                    txtCodigoZip.Clear();

                    txtIDcliente.Focus();
                }

                //Cerrar el cursor.
                reader.Close();
            }
            //errores de BD.
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
        private void BuscarStoreprocedure() {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = Conexion.CadenaConexion;

                //Abrir la conexion.
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "P_Select_Customers_por_primarykey"; //nombre de STORE PROCEDURE
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;


                #region primer metodo

                ////Crear, agregar el/los parametros el command (Parameters)
                //command.Parameters.Add("@CustomerID", SqlDbType.Int, 4);//posicion (0)
                ////command.Parameters.Add("@CustomerID", SqlDbType.Int, 4, "CustomerID");//DataSet con un DataGridView
                ////Enviar el valor para el parametro.
                //command.Parameters["@CustomerID"].Value = Convert.ToInt32(txtIDcliente.Text);
                //command.Parameters[0].Value = Convert.ToInt32(txtIDcliente.Text);

                #endregion

                #region segundo metodo

                //Crear, agregar el/los y envio el valor el parametro del command (Parameters)
                command.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value =
                                                        Convert.ToInt32(txtIDcliente.Text);//posicion (0)

                #endregion

                //Crear un DataReader para recupera los datos del SELECT.
                SqlDataReader reader = command.ExecuteReader();//SELECT

                //Verificar si el reader tiene un registro recuperado.
                //Read: abre el cursor.
                if (reader.Read())
                {
                    //Mostrar el registro recuperado.
                    txtIDcliente.Text = reader[0].ToString();
                    txtNombre.Text = reader[1].ToString();
                    txtDireccion.Text = reader[2].ToString();
                    txtCiudad.Text = reader[3].ToString();
                    txtEstado.Text = reader[4].ToString();
                    txtCodigoZip.Text = reader[5].ToString();


                    //txtIDcliente.Text = reader["CustomerID"].ToString();
                    //txtNombre.Text = reader["Name"].ToString();
                    //txtDireccion.Text = reader["Address"].ToString();
                    //txtCiudad.Text = reader["City"].ToString();
                    //txtEstado.Text = reader["State"].ToString();
                    //txtCodigoZip.Text = reader["ZipCode"].ToString();  

                    //txtCodigoZip.Text = reader.GetInt32(0).ToString();
                    //txtCodigoZip.Text = reader.GetString(1).ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro el cliente",
                                    "Clientes",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtIDcliente.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtCiudad.Clear();
                    txtEstado.Clear();
                    txtCodigoZip.Clear();

                    txtIDcliente.Focus();
                }

                //Cerrar el cursor.
                reader.Close();
            }
            //errores de BD.
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
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           BuscarSqlEmbebido();
           // //BuscarStoreprocedure();
           // FormaBuscarCustomers buscar = new FormaBuscarCustomers();
           //buscar.MdiParent = this.MdiParent;
           //buscar.Show();

        }

        private void FormaMcliente_Load(object sender, EventArgs e)
        {
            //FormaBuscarCustomers.forma.eventoUno += new FormaBuscarCustomers.enviar(delegate(string t) { txtNombre.Text = t; });
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           OracleConnection connection = new OracleConnection();

            try
            {
                

                //Abrir la conexion.
               
                //Validar que haya un codigo ingresado.
                if (txtIDcliente.Text != "")
                {
                    //Confirmar la eliminacion
                   DialogResult resultado = MessageBox.Show("Eliminar el registro?",
                                       "Clientes",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Error);
                    
                   if (resultado == DialogResult.Yes) {
                       connection.ConnectionString = Conexion.CadenaConexion;
                       //Eliminar el registro indicado
                       //Preparar el SQL para eliminar cliente
                       string delete = "DELETE FROM Customers " +
                                        "WHERE CustomerID= :CustomerID";

                       //Preparar el command
                       OracleCommand command = new OracleCommand(delete,connection);

                       //Crear, agregar, ennviar el valor´para el parametro
                       command.Parameters.Add(":CustomerID", OracleDbType.Int32, 4).Value = Convert.ToInt32(txtIDcliente.Text);
                       connection.Open();
                       //ejecutar el sql
                       int cantidad = command.ExecuteNonQuery();

                       if (cantidad > 0)
                       {
                           MessageBox.Show("Se elimino el registro",
                                           "Clientes",
                                           MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                           //Limpiar los controles 
                           txtIDcliente.Text = "";
                           txtNombre.Clear();
                           txtCiudad.Clear();
                           txtDireccion.Clear();
                           txtEstado.Clear();
                           txtCodigoZip.Clear();

                           //activar y desactivar botones => controles

                           txtIDcliente.Focus();

                       }
                       else {
                           MessageBox.Show("No se pudo eliminar el registro",
                                          "Clientes",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                       }
                   }                   
                }
                else {
                    MessageBox.Show("Ingrese el codigo a eliminar",
                                       "Clientes",
                                       MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                }
                
            }
            //errores de BD.
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
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
            }


        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }        
    }
}
