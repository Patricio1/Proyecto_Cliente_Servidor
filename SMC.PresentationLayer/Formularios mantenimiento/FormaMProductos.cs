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
        int boton;
        private int parametro;
        public FormaMProductos()
        {
            InitializeComponent();
            _datos = new DataSet();
        }

        public FormaMProductos(int botonPresionado)
        {
            InitializeComponent();
            _datos = new DataSet();
            this.boton = botonPresionado;
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
            if(boton==1){
                this.Location = new Point(830, 200);
                //cuando instaciamos desde el formulario factura detalle
                //no necesitamos los botones de guardar y cancelar
                //por lo tanto los desabilitamos
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
                recuperar();
            }
            else {
                this.Location = new Point(1, 20);
                recuperar();
            }
            
        }

      

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Control de celdas vacias
            bool bandera = false; //variable que nos notifica si existe alguna celda vacia
            int filas = dgvProductos.RowCount-1; //contamos numero de filas y restamos 1 porque cuenta tambien la ultima celda en blanco
            int columnas = dgvProductos.ColumnCount;
            //ciclo para recorrer todas las filas
            for (int i = 0; i <= filas-1; i++)
            {
                //ciclo para recorrer todas las columnas
                for (int j = 0; j <= columnas-1; j++)
                {
                    //verificamos si el valor de la celda esta vacio
                    if (Convert.ToString(dgvProductos[j, i].Value) == "")
                    {                    
                       bandera = true;
                    }
                }
            }
            #endregion
            //si existe celdas vacias notificamos al usuario
            if (bandera==true)MessageBox.Show("Hay campos que se encuentran vacíos");

            //en caso contrario procedemos a insertar o actualizar
            else 
            {
                #region Insertar en DataGridview
                OracleConnection connection = new OracleConnection();
                try
                {

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
                #endregion

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _datos.Clear();
            recuperar();
           
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dgvProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dgvProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region validar Numeros Enteros
            if (parametro == 1)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            #endregion

            #region validar Letras
            else if (parametro == 2)
            { //si el parametro es 2 validamos letras
                if (Char.IsLetter(e.KeyChar)) //verificamos si es un caracter
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar)) //verificamos si se trata de la tecla backspace
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar)) //verificamos si es la tecla de separador
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            #endregion

            #region Validar Decimales
            else if (parametro == 3)
            {
                //if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
                //{
                //    e.Handled = true;
                //}
                ////if (e.KeyChar == '.')
                ////    e.KeyChar = ',';
                //////Permitir comas y puntos (si es punto )
                ////if (e.KeyChar == ',' || e.KeyChar == '.')
                ////    //si ya hay una coma no permite un nuevo ingreso de esta
                ////    if (tBox1.Text.Contains(",") || tBox1.Text.Contains("."))
                ////        e.Handled = true;
                //    else
                //        e.Handled = false;

                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                
                else if(e.KeyChar.ToString() ==","){
                    e.Handled = false;
                }
                else 
                {
                    e.Handled = true;
                }
            }
            #endregion

            #region Validar alfanumericos
            else if (parametro == 4)
            {
                if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)
                    || Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = !true;
                }

                else
                    e.Handled = !false;
            }
            #endregion
        }

        private void dgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox txt = e.Control as TextBox;

               

                // Si la columna es numerica
                if (object.ReferenceEquals(dgvProductos.CurrentCell.ValueType, typeof(System.Int32)))
                { 
                    // Asignar el evento de solo numeros a las columnas numericas
                    parametro = 1;
                    txt.KeyPress += dgvProductos_KeyPress;
                    
                }
                // Si la columna es tipo caracter
                else if (object.ReferenceEquals(dgvProductos.CurrentCell.ValueType, typeof(System.String))) 
                {
                    // Asignar el evento de valores alfanumericos a las columnas tipo caracter
                    parametro = 4;
                    txt.KeyPress += dgvProductos_KeyPress;
                }
                // Si la columna es tipo decimal
                else if (object.ReferenceEquals(dgvProductos.CurrentCell.ValueType, typeof(System.Double)))
                {
                   // Asignar el evento de valores decimales a la columna precio
                    parametro = 3;
                    txt.KeyPress += dgvProductos_KeyPress;
                }
                else {
                    //por defecto numerico
                    parametro = 1;
                    txt.KeyPress += dgvProductos_KeyPress;
                }
            }
        }

        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Hay una celda con demasiados valores","Productos",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
