using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using InputKey;
using SMC.BusinessObjects;


namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class FormaDetalleFactura : Form
         
    {
        public IForm Opener { get; set; }

        #region Declaraccion de variables
        private Validaciones ClaseValidar;
        private LeerCantidad leer_Cantidad;
        private DataTable dt = new DataTable();
        //instanciamos un objeto para poder escoger los productos
        SMC.PresentationLayer.BusquedasPersonalizadas.FormaBuscarProducto productos;
        private DataSet _datos;
        private int boton;
        private int parametro;
        private int datosInsertados;
        //Boolean verificarCamposNumericos;
        private double totalProductos = 0;
        private int confirmarCalculoFactura;
        private int maximoCaracteresNumericos = 0;
        private int _cantidadProducto;
        private double _precio;
        private int filasConDatos = 0;
        private int numerofilas = 0;
        private int indiceFilaRepetida = 0;
        private double _valorIva = 0;
        private double totalApagar = 0;
        private double impuesto = 0;
        private static string _IDCliente;
        private string producto;
        private double precio;
        private int cantidad;
        private double total;
        private int existeDatos = 0;
        #endregion

        #region Propiedades
        public string this[int indice]
        {
            set
            {
                txtCliente.Text = value;
            }
            get
            {
                return txtCliente.Text;
            }

        }

        public String cliente
        {
            set
            {
                txtCliente.Text = value;
            }
            get
            {
                return txtCliente.Text;
            }

        }
        public String ID_Cliente {
            set {
                _IDCliente = value;
            }
            get {
                return _IDCliente;
            }        
        }

        public int Cantidad {
            set {
                _cantidadProducto = value;
            }
            get {
                return _cantidadProducto;
            }
        }

        public double Precio
        {
            set
            {
                _precio = value;
            }
            get
            {
                return _precio;
            }
        }

        public double Iva {
            set {
                _valorIva = value;
            }
            get {
                return _valorIva;
            }
        }
        #endregion



        
     public FormaDetalleFactura()
        {
            InitializeComponent();
            _datos = new DataSet();
         //en esta variable almacenamos el valor que tiene Boton Presionado
            boton = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.BotonPresionado;
            ClaseValidar = new Validaciones();
            leer_Cantidad = new LeerCantidad();
        }
      
        
       
        private void RecuperarDetalle() {
            OracleConnection connection = new OracleConnection();
            try
            {
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();

                string select = "SELECT ProductCode as PRODUCTO,UnitPrice as PRECIO,Quantity as CANTIDAD,ItemTotal as TOTAL "+
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

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //se instancia un objeto del tipo FormaBuscarCliente, y se muestra
            SMC.PresentationLayer.FormaBuscarCustomers buscarCliente = new SMC.PresentationLayer.FormaBuscarCustomers(1);
            buscarCliente.MdiParent = this.MdiParent;
           // buscarCliente.ShowDialog();
            buscarCliente.Show();
        }

       

        private void FormaDetalleFactura_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1, 5);
            //se llama a este metodo para setear el numero de Factura en su respectivo control
            NumeroFactura();

            //si se ha pulsado sobre actualizar (boton=2) de la ventana anterior FormaMFactura
            if (boton == 2)
            {

                #region inicializar campos
                //instanciamos un objeto del formulario FormaMFactura
                SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura factura = new Formularios_mantenimiento.FormaMFactura();
                //seteamos las cajas de texto con los valores traidos desde el formulario 
                //que se instancia anteriormente
                txtNumeroFactura.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.NumeroFactura;
                txtCliente.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Cliente;
                txtFecha.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Fecha;
                txtTotalProductos.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.TotalProductos;
                txtIva.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Impuesto;
                txtEnvio.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.Envio;
                txtFacturaTotal.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura.FacturaTotal;

                //creamos las columnas para la tabla que contendra el detalle
                dt.Columns.Add("PRODUCTO");  
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("CANTIDAD");
                dt.Columns.Add("TOTAL");
                
                //añadimos la tabla al datagrid
                dgvDetalle.DataSource = dt;
                #endregion
               
                //recuperamos el detalle de una determinada factura
                RecuperarDetalle();
                

            }
                //si se ha pulsado sobre el boton Agregar del formulario FormaMFactura
            else if(boton==1){
                txtCliente.Visible = true;
                //creas una tabla 
                dt.Columns.Add("PRODUCTO"); //le creas las columnas 
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("CANTIDAD");
                dt.Columns.Add("TOTAL");

                dgvDetalle.DataSource = dt; //añades la tabla al datagrid 

               //se crea una columna tipo boton para  dar la funcionalidad de quitar filas de la tabla
                DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
                //se asigna un nombre a la columna 
                colBotones.Name = "colBotones";
                //se asigna un nombre el cual sera visible en la cabecera de la tabla
                colBotones.HeaderText = "ELIMINAR";
                //se añade la columna creada al datagrid
                dgvDetalle.Columns.Add(colBotones);
            }
        }


      

        private void insertarFactura() {

         try
         {
             OracleConnection connection = new OracleConnection();
             Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
             connection.ConnectionString = Conexion.CadenaConexion;

             string insert = "INSERT INTO INVOICES(InvoiceID,CustomerID,InvoiceDate,ProductTotal,SalesTax,Shipping,InvoiceTotal) " +
                              "VALUES(:InvoiceID,:CustomerID,SYSDATE,:ProductTotal,:SalesTax,:Shipping,:InvoiceTotal)";
            
             OracleCommand command = new OracleCommand(insert, connection);

             //creamos y añadimos parametros

             command.Parameters.Add(":InvoiceID", OracleDbType.Int32, 6).Value = Convert.ToInt32(txtNumeroFactura.Text);
             command.Parameters.Add(":CustomerID", OracleDbType.Int32, 38).Value = Convert.ToInt32(ID_Cliente);
             //command.Parameters.Add(":InvoiceDate", OracleDbType.Date, 5).Value = txtFecha.Value;
             command.Parameters.Add(":ProductTotal", OracleDbType.Double, 8).Value = Convert.ToDouble(txtTotalProductos.Text);
             command.Parameters.Add(":SalesTax", OracleDbType.Double, 8).Value = Convert.ToDouble(txtIva.Text);
             command.Parameters.Add(":Shipping", OracleDbType.Double, 8).Value = Convert.ToDouble(txtEnvio.Text);
             command.Parameters.Add(":InvoiceTotal", OracleDbType.Double, 8).Value = Convert.ToDouble(txtFacturaTotal.Text);

             connection.Open();

             int filasInsertadas = command.ExecuteNonQuery();
             if (filasInsertadas > 0)
             {
                 MessageBox.Show("Registro insertado",
                         "Facturas",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                
             }
             else

                 MessageBox.Show("Registro no insertado",
                             "Facturas",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);

             #region seccion catch
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

                //Liberar memoria.
                //connection.Dispose();
            }
             #endregion

        }

        private int recuperarCantidadProducto(string codigoProducto) {

            try
            {
                OracleConnection connection = new OracleConnection();
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;

                string select = "SELECT ONHANDQUANTITY FROM PRODUCTS WHERE PRODUCTCODE=:PRODUCTCODE";

                OracleCommand command = new OracleCommand();

                //creamos y añadimos parametros
                command.CommandText = select;
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                command.Parameters.Add(":PRODUCTCODE", OracleDbType.Char,10).Value = codigoProducto;

                connection.Open();

                //ejecutamos el sql con executeScalar ya que solo devuelve un valor
                Object reader = command.ExecuteScalar();
                int cantidad = Convert.ToInt32(reader.ToString());
                

                connection.Clone();
                connection.Dispose();

                return cantidad;
              
                

                

                #region seccion catch
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
                return 0;

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
                return 0;
            }
            finally
            {

                //Liberar memoria.
                //connection.Dispose();
                
            }
                #endregion
        }
        private void CalcularDetalle() { 
         numerofilas = 0;

        foreach (DataGridViewRow row in dgvDetalle.Rows)
        {

            if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
            {
                //esta variable servira de banderin para determinar si la tabla tiene datos
                existeDatos = 1;
                try
                {
                    // se obtiene los valores que tiene las celdas especificadas
                    producto = (row.Cells["PRODUCTO"].Value.ToString());
                    precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                    cantidad = Convert.ToInt32((row.Cells["CANTIDAD"].Value.ToString()));

                    //mientras recorre cada fila, se va almacenando en un acumulador
                    //la cantidad de productos
                    totalProductos += cantidad;
                    //se obtiene y almacena en una variable el total de cada fila
                    total = precio * cantidad;
                    //en otro acumulador se va almacenado el total de todas las filas que hay en la tabla
                    totalApagar += total;

                    //se setea en la celda total de cada fila el total calculado anteriormente
                    row.Cells["TOTAL"].Value = Convert.ToString(total);

                    //se setea en la caja de texto correspondiete el total de productos
                    txtTotalProductos.Text = totalProductos.ToString();
                    // se  setea en la caja de texto correspondiente el subtotal
                    txtSubtotal.Text = Convert.ToString(totalApagar);
                    
                    confirmarCalculoFactura = 1;//1 significara que los calculos se han realizado con exito
                    //el numero de filas va aumentando de 1 en 1
                    numerofilas++;

                   
                }
                catch (Exception ex)
                {

                }
                

            }
            else
            {
                existeDatos = 0;
                
            }
           
        }
        
 
        }

        private void insertarDetalle()
        {

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                //verificamos que las filas no esten vacias
                if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
                {
                    //obtenemos los valores de cada celda y los almacenamos en variables
                    double factura = Convert.ToDouble(txtNumeroFactura.Text);
                    producto = Convert.ToString((row.Cells["PRODUCTO"].Value.ToString()));
                    precio = Convert.ToDouble(row.Cells["PRECIO"].Value.ToString());
                    cantidad = Convert.ToInt32((row.Cells["CANTIDAD"].Value.ToString()));
                    double total = Convert.ToDouble((row.Cells["TOTAL"].Value.ToString()));

                    //llamamos al metodo que se encarga de ejecutar la inserccion en la tabla detalles de factura
                    recorrerDetalleparaInsertar(factura, producto, precio, cantidad, total);
                    //luego de cada inserccion se va restando el stock de cada producto insertado en la tabla mencionada
                    RestarCantidadProducto(producto,cantidad);


                   
                    
                }
            }
        }
        private void recorrerDetalleparaInsertar(double factura,string producto,double precio,double cantidad,double total) { 
         OracleConnection connection = new OracleConnection();
            Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            connection.ConnectionString = Conexion.CadenaConexion;
            try { 
                
           
            //preparar el insert
            string insert = "INSERT INTO InvoiceLineItems(InvoiceID,ProductCode,UnitPrice,Quantity,ItemTotal) " +
                                       "VALUES(:InvoiceID,:ProductCode,:UnitPrice,:Quantity,:ItemTotal)";

            OracleCommand command = new OracleCommand(insert, connection);

            //creamos y añadimos parametros

             //crear y agregar parametros
                command.Parameters.Add(":InvoiceID", OracleDbType.Double, 38).Value = factura;
                command.Parameters.Add(":ProductCode", OracleDbType.Char, 10).Value= producto;
                command.Parameters.Add(":UnitPrice", OracleDbType.Double, 8).Value = precio;
                command.Parameters.Add(":Quantity", OracleDbType.Double, 38).Value = cantidad;
                command.Parameters.Add(":ItemTotal", OracleDbType.Double, 8).Value= total;

            connection.Open();

            int filasInsertadas = command.ExecuteNonQuery();
            if (filasInsertadas > 0)
            {
                //MessageBox.Show("Registro insertado",
                //        "Detalle",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                
                //dgvDetalle.DataMember = null;
                //dt = (DataTable)dgvDetalle.DataSource;
                //dt.Clear();
            }
            else
            
                MessageBox.Show("Registro no insertado",
                            "Detalle",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                     } catch (OracleException ex)
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           //verificamos que el campo de cliente no este vacio
            if(txtCliente.Text==""){
               MessageBox.Show("Falta ingresar cliente","Factura",MessageBoxButtons.OK,MessageBoxIcon.Information);
               txtCliente.Select();
           }
            //verificamos que el campo de envio no este vacio
            else if(txtEnvio.Text==""){
                MessageBox.Show("Ingrese valor de envio \n y vuelva a calcular la factura ", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEnvio.Select();
            }
            //verificamos que el campo de totalProductos y subtotal no esten vacios
            else if(txtTotalProductos.Text=="" || txtSubtotal.Text=="" ){
                MessageBox.Show("La factura esta incompleta \n Posibles causas: \n 1.- Factura sin detalle \n 2.- No se ha realizado los calculos respectivos \n Antes de guardar realice lo sugerido ", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else { //si todos los campos  estan con datos y la tabla detalle no este vacia
               //llamamos al metodo para insertar la factura
               insertarFactura();
                //llamamos al metodo para insertar el detalle de la factura
               insertarDetalle();
                //ponemos los controles vacios
               //borrarDatos();
                //como la cantidad de filas en el ultimo recorrido queda con
                //un valor diferente de 0 lo seteamos a cero, para poder aplicarlo
                //en otros controles
               filasConDatos = 0;

               datosInsertados = 1;

               btnVerFactura.Enabled = true;

               btnNuevo.Enabled = true;

               btnGuardar.Enabled = false;

               productos.Close();
           }
            

        }

    
        

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                //recuperamos los campos producto y cantidad de la fila donde se haga click
                String producto = (dgvDetalle.Rows[e.RowIndex].Cells["PRODUCTO"].Value.ToString());
                String cantidad = (dgvDetalle.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString());

                //pasamos los datos recuperados a los controles respectivos
                txtProducto.Text = producto;
                txtCantidad.Text = cantidad;
                
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            

            

            productos = new SMC.PresentationLayer.BusquedasPersonalizadas.FormaBuscarProducto();
            productos.MdiParent = this.MdiParent;
           // productos.Opener = this;
            productos.Show();
        }

        private void NumeroFactura() {
            OracleConnection conecction = new OracleConnection();
            try
            {
                
                Conexion.CadenaConexion = "User Id=MMABOOKS; Password=MMABOOKS; Data Source=XE";
                conecction.ConnectionString = Conexion.CadenaConexion;
                //la sentencia sql nos devolvera un solo valor, el proximo numero de factura
                string sqlSelect = " SELECT NVL((MAX(INVOICEID)+1),1) FROM INVOICES";

                //se abre la coneccion
                conecction.Open();
                OracleCommand command = new OracleCommand();
                command.CommandText = sqlSelect;
                command.CommandType = CommandType.Text;
                command.Connection = conecction;

                //ejecutamos el sql con executeScalar ya que solo devuelve un valor
                Object reader = command.ExecuteScalar();
                //es necesario transformalo de formatos
                string maximo = reader.ToString();
                //seteamos en el control correspondiente el valor obtenido anteriormente
                txtNumeroFactura.Text = maximo;
            }
            catch (OracleException ex)
            {
                //Utilizar la clase para gestionar excepciones.
                // Excepciones.Gestionar(ex);

                //Mostrar el mensaje personalizado.
                MessageBox.Show(Excepciones.MensajePersonalizado,
                    "Error de Oracle ",
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
                conecction.Close();

                //Liberar memoria.
                conecction.Dispose();
            }
           
        }

        private Boolean VerificarControlesVacios() {
            int filas = ContarFilasConDatos();
            if (!(filas == 0 && txtCliente.Text == "" && txtTotalProductos.Text == ""
                && txtEnvio.Text == "" && txtFacturaTotal.Text == "" && txtIva.Text == ""
                && txtSubtotal.Text == ""))
            {
                return true;
            }
            else return false;
        
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
         
            //si el usuario confirma que desea borrar todos los datos se prodece a borrar
            //if(VerificarControlesVacios()){
            //    DialogResult result = MessageBox.Show("Esta seguro de borrar todos los datos?", "Factura", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    if(result == DialogResult.OK){
                borrarDatos();
                datosInsertados = 0;
                    //seteamos a cero esta variable ya que en el ultimo recorrido queda con un 
                    //valor direfente de cero
                filasConDatos = 0;
                lblNumeroEnLetras.Text = "";
                lblNumeroEnLetras.Visible = false;

                btnVerFactura.Enabled = false;

                txtEnvio.Text = "0,00";
            //    }
            //}
            

        }

        private void txtEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
           //parametro 3= validar decimales
            ClaseValidar.validar(sender,e,3,txtEnvio);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //CalcularDetalle();
            //nos aseguramos de que haya filas en la tabla
            if(ContarFilasConDatos()!=0) {
            
            //calculamos el detalle
            CalcularDetalle();
            
                //verificamos si se han realizado correctamente los calculos
            if (confirmarCalculoFactura !=1)
            {
                // MessageBox.Show("no hay que calcular");
            }
            else
            {
                //seteamos las variables para obtener valores logicos y no valores
                //muy superiores a lo esperado
                totalApagar = 0;
                totalProductos = 0;
                double iva = 0.0;
                double totalFactura = 0.0;
                CalcularDetalle();
                if ((!rd12.Checked && !rd0.Checked)||txtEnvio.Text=="") //en caso de que ninguno de los radioButton tenga el foco
                {
                    MessageBox.Show("Falta escoger valor para impuesto \n y/o establecer valor de envio", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEnvio.Select();
                }
                else
                {
                    //con este metodo determinamos el valor de iva 12% o 0% dependiendo de donde este el foco
                    DeterminarValorImpuesto();
                    // se realizan los calculos respectivos y se setean valores en los controles
                    iva = totalApagar * Iva;
                    txtIva.Text = Convert.ToString(iva);
                    totalFactura = totalApagar + iva + Convert.ToDouble(txtEnvio.Text);
                    txtFacturaTotal.Text = Convert.ToString(totalFactura);

                    string numeroEnLetras=leer_Cantidad.Convertir(txtFacturaTotal.Text, 1);
                    int largo = numeroEnLetras.Length;
                   // lblNumeroEnLetras.Size = new System.Drawing.Size(largo, 13);
                    lblNumeroEnLetras.Visible = true;
                    lblNumeroEnLetras.Text = numeroEnLetras;
                    //ClaseValidar.LeerN

                }

                if (txtFacturaTotal.Text != "")
                {
                    btnGuardar.Enabled = true;

                }
                if(datosInsertados==1){
                    btnGuardar.Enabled = false;
                }
            }
            }
        }

        

        private void dgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //para controlar al momento de editar la tabla, pero en este 
            //proyecto como se establecio no editar la tabla se comenta

            //if (e.Control is TextBox)
            //{
            //    TextBox txt = e.Control as TextBox;
            //    // Si la columna es numerica
            //    if (object.ReferenceEquals(dgvDetalle.CurrentCell.ValueType, typeof(System.Int32)))
            //    {
            //        // Asignar el evento de solo numeros a las columnas numericas
            //        parametro = 1;
            //        txt.KeyPress += dgvDetalle_KeyPress;

            //    }
            //    // Si la columna es tipo caracter
            //    else if (object.ReferenceEquals(dgvDetalle.CurrentCell.ValueType, typeof(System.String)))
            //    {
            //        // Asignar el evento de valores alfanumericos a las columnas tipo caracter
            //        parametro = 4;
            //        txt.KeyPress += dgvDetalle_KeyPress;
            //    }
            //    // Si la columna es tipo decimal
            //    else if (object.ReferenceEquals(dgvDetalle.CurrentCell.ValueType, typeof(System.Double)))
            //    {
            //        // Asignar el evento de valores decimales a la columna precio
            //        parametro = 3;
            //        txt.KeyPress += dgvDetalle_KeyPress;
            //    }
            //    else
            //    {
            //        //por defecto numerico
            //        parametro = 1;
            //        txt.KeyPress += dgvDetalle_KeyPress;
            //    }
            //}
        }

        private void dgvDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //tambien sirven para controlar la tabla al momento de editarla

            //#region validar Numeros Enteros
            //if (parametro == 1)
            //{
            //    if (Char.IsDigit(e.KeyChar))
            //    {
            //        e.Handled = false;
            //    }
            //    else if (Char.IsControl(e.KeyChar))
            //    {
            //        e.Handled = false;
            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
            //#endregion

            //#region validar Letras
            //else if (parametro == 2)
            //{ //si el parametro es 2 validamos letras
            //    if (Char.IsLetter(e.KeyChar)) //verificamos si es un caracter
            //    {
            //        e.Handled = false;
            //    }
            //    else if (Char.IsControl(e.KeyChar)) //verificamos si se trata de la tecla backspace
            //    {
            //        e.Handled = false;
            //    }
            //    else if (Char.IsSeparator(e.KeyChar)) //verificamos si es la tecla de separador
            //    {
            //        e.Handled = false;
            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }

            //}
            //#endregion

            //#region Validar Decimales
            //else if (parametro == 3)
            //{
            //    //if (((e.KeyChar) < 48) && ((e.KeyChar) != 8) || ((e.KeyChar) > 57))
            //    //{
            //    //    e.Handled = true;
            //    //}
            //    ////if (e.KeyChar == '.')
            //    ////    e.KeyChar = ',';
            //    //////Permitir comas y puntos (si es punto )
            //    ////if (e.KeyChar == ',' || e.KeyChar == '.')
            //    ////    //si ya hay una coma no permite un nuevo ingreso de esta
            //    ////    if (tBox1.Text.Contains(",") || tBox1.Text.Contains("."))
            //    ////        e.Handled = true;
            //    //    else
            //    //        e.Handled = false;

            //    if (Char.IsDigit(e.KeyChar))
            //    {
            //        e.Handled = false;
            //    }
            //    else if (Char.IsControl(e.KeyChar))
            //    {
            //        e.Handled = false;
            //    }

            //    else if (e.KeyChar.ToString() == ",")
            //    {
            //        e.Handled = false;
            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
            //#endregion

            //#region Validar alfanumericos
            //else if (parametro == 4)
            //{
            //    if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)
            //        || Char.IsSeparator(e.KeyChar))
            //    {
            //        e.Handled = !true;
            //    }

            //    else
            //        e.Handled = !false;
            //}
            //#endregion
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClaseValidar.validar(sender, e, 1, txtCantidad);
        }
        private void RestarCantidadProducto(string codigoProducto,int cantidad) {

            //restamos del total disponible la cantidad pedida y almacenamos en una variable
            int NuevaCantidadEnStock= recuperarCantidadProducto(codigoProducto)-cantidad;
            OracleConnection conecction = new OracleConnection();
            Conexion.CadenaConexion = "User Id=MMABOOKS; Password=MMABOOKS; Data Source=XE";
            conecction.ConnectionString = Conexion.CadenaConexion;
            string sqlUpdate = "UPDATE PRODUCTS SET ONHANDQUANTITY =:CANTIDADPEDIDA WHERE PRODUCTCODE=:CODIGOPRODUCTO";

            OracleCommand command = new OracleCommand();
            conecction.Open();
            command.CommandText = sqlUpdate;
            command.CommandType = CommandType.Text;
            command.Connection = conecction;
            command.Parameters.Add(":CANTIDADPEDIDA",OracleDbType.Int32,38).Value = NuevaCantidadEnStock;
            command.Parameters.Add(":CODIGOPRODUCTO", OracleDbType.Char, 10).Value = codigoProducto;

            command.ExecuteNonQuery();

        }
        private int VerificarRepetidos() {
            string productoAverificar;
            filasConDatos = 0;
            int ExisteRepetido=0;
            //con este ciclo recorremos todas las filas de la tabla
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                //esta condicion sirve para determinar si la fila a recorrer no este vacia
                if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
                {
                    //se va contabilizando el numero de filas que estan con datos
                    filasConDatos++;
                    try
                    {
                       //tomamos el codigo del producto de cada una de las filas que se va recorriendo
                        productoAverificar = (row.Cells["PRODUCTO"].Value.ToString());
                        //comparamos si el codigo recuperado anteriormente coincide con el que
                        //el usuario pretende ingresar
                        if(productoAverificar==txtProducto.Text){
                            //con esta variable alertamos que se ha encontrado una incidencia en tabla
                            //del producto que se pretende ingresar
                            ExisteRepetido = 1;
                            //almacenamos el indice donde se ha encontrado dicha incidencia
                            indiceFilaRepetida = filasConDatos;
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    //  factura= Convert.ToDouble(txtNumeroFactura.Text);

                    //inserttar(factura,producto,precio,cantidad,total);

                }

            }
            if (ExisteRepetido == 1)
            {
                //MessageBox.Show("Hay 1 Producto repetido  " + txtProducto.Text);
                txtCantidad.Clear();
                txtProducto.Select();
                return ExisteRepetido;
            }
            else return ExisteRepetido;
        }

        private int ContarFilasConDatos() {
            filasConDatos = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {

                if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
                {
                    filasConDatos++;
                }

            }
            return filasConDatos;
        }

        private void borrarDatos() {
            //borramos el contenido de la tabla detalle
            dt.Clear();

            //borramos el contenido de todas las cajas de texto
            txtCliente.Text = "";
            txtCantidad.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";
            txtEnvio.Text = "";
            txtIva.Text = "";
            txtSubtotal.Text = "";
            txtTotalProductos.Text = "";
            txtFacturaTotal.Text = "";

            //obtenemos y seteamos el numero de factura
            NumeroFactura();

            //desabilitamos en boton de guardar con el proposito de que el usuario llene todos los campos
            btnGuardar.Enabled = false;

            
          
            
        }
        private int VerificarSiEsNumero(string dato) {
            //int cantidad=0;
            int banderin = 0;
            maximoCaracteresNumericos = 0;
            //recorremos toda la cadena 
            for (int i = 0; i <= dato.Length-1;i++ )
            {
                //convertimos en un array de caracteres la cadena que recibimos como parametro
                //con el proposito de ir comparando y verificando si son caracteres o numeros
                char []caracteres = dato.ToCharArray();
                //con esta condicion; decimos si la cadena no tiene ningun digito numericio
                if ( !(caracteres[i] == '1' || caracteres[i] == '2' || caracteres[i] == '3' || caracteres[i] == '4'
                    || caracteres[i] == '5' || caracteres[i] == '6' || caracteres[i] == '7' || caracteres[i] == '8'
                    || caracteres[i] == '9' || caracteres[i] == '0')){
                    //alertamos que la cadena tiene letras u otro caracter
                    banderin = 1;
                                    
                
                }
                    //en caso que la cadena tenga solo caracteres que corresponden a numeros
                    //contabilizamos el numero de digitos para posteriormente controlarlo tambien
                else maximoCaracteresNumericos++;
            }
            return banderin;
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //verificamos que se haya ingresado producto
            if (txtProducto.Text == "" )
            {
                MessageBox.Show("Ingrese un producto", "Productos", MessageBoxButtons.OK);
                //ubicamos el cursor en la caja de texto para Producto
                txtProducto.Select();
   
            }
            //verificamos que se haya ingresado  cantidad
            else if(txtCantidad.Text == ""){
                MessageBox.Show("Ingrese la cantidad del producto seleccionado", "Productos", MessageBoxButtons.OK);
                //ubicamos el cursor en la caja de texto para Cantidad
                txtCantidad.Select();
            }
                //con esta condicion verificamos si se ha ingresado una cantidad de cero 
            else if(Convert.ToInt16(txtCantidad.Text)==0){
                MessageBox.Show("La cantidad del producto \n deber ser mayor a cero", "Productos", MessageBoxButtons.OK);
                //ubicamos el cursor en la caja de texto para Cantidad
                txtCantidad.Select();
            }
            else {

                //recuperamos la cantidad de producto, de la caja de texto txtCantidad 
                int CantidadApedir= Convert.ToInt32(txtCantidad.Text);

                //esta condicion permite determinar si la cantidad ingresada
                //es mayor que la disponible en stock
                if (CantidadApedir > Cantidad)
                {
                    MessageBox.Show("No puede comprar más de lo que tiene en Stock \n Cantidad Disponible: "+Cantidad,
                        "Productos", MessageBoxButtons.OK);
                }
                else {
                  //  RestarCantidadProducto(txtProducto.Text);

                    //mediante el metodo VerificarRepetidos==> este se encarga de recorrer todas las filas de la tabla
                    //e ir comparando con el producto que se pretende ingresar, de encontrar alguna incidencia
                    // retorna uno de los valores             
                    //0=no hay repetidos en la tabla; 1= si hay elementos repetidos
                   
                    if (VerificarRepetidos() == 0) //con esta condicion nos aseguramos que no hay repetidos en tabla
                    {
                        DataRow row = dt.NewRow();//creas un registro 

                        //con el nombre de la columna le añades un valor 
                        row["PRODUCTO"] = txtProducto.Text;
                        row["PRECIO"] = Precio;  
                        row["CANTIDAD"] = txtCantidad.Text;  

                        dt.Rows.Add(row); //añades el registro a la tabla 
                        dgvDetalle.DataSource = dt; //añades la tabla al datagrid 
                        dgvDetalle.Update(); //actualizas el datagrid, para ver los cambios

                        //txtCantidad.Clear();
                    }

                    else //si el producto a ingresar ya esta en lista
                    {
                     
                        //con la ayuda de un cuadro de mensajes que permite ingresar valores
                        //solicitamos que solo modifique la cantidad de dicho producto
                      string cantidadNuevaProducto= InputDialog.mostrar("El producto seleccionado ya esta en lista \n Modifique la cantidad", "Producto Repetido");

                      //determinamos si el valor ingresado a traves del mensaje de dialogo
                      //es un numero; este metodo retorna los siguientes valores:
                      // 0 = se trata de un numero
                      // 1= se trata de una cadena de caracteres
                       int n=VerificarSiEsNumero(cantidadNuevaProducto);

                      if (n == 1) //en el caso de que sea letras, ingresada por parte del usuario
                      {
                          MessageBox.Show("Debe ingresar solo numeros enteros", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                          
                      }
                          //determinamos si la cantidad es mayor a 4 digitos
                          else if(maximoCaracteresNumericos>4){
                              MessageBox.Show("Debe ingresar cantidad numerica máximo de 4 digitos", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          }
                      else if(cantidadNuevaProducto==""){
                      
                      }
                      else {
                          try
                          {
                              //se hace una conversion de formatos
                              Int64 cantidadProductoDesdeInput = Convert.ToInt64(cantidadNuevaProducto);
                              //preguntamos si la cantidad disponible es menor a la nueva cantidad pedida
                              if (Cantidad < cantidadProductoDesdeInput)
                              {
                                  MessageBox.Show("No puede comprar más de lo que tiene en Stock \n Cantidad Disponible: " + Cantidad,
                                    "Productos", MessageBoxButtons.OK);
                              }
                               
                                //controlamos que la cantidad ingresada no sea cero
                              else if(cantidadProductoDesdeInput==0){
                                  MessageBox.Show("La cantidad del producto \n deber ser mayor a cero", "Productos", MessageBoxButtons.OK);
                                  //ubicamos el cursor en la caja de texto para Cantidad
                                  txtCantidad.Select();
                              }

                               //Cuando hay  suficiente cantidad para vender 
                              else {
                                  
                                  //Con un objeto DataRow establecemos una fila especifica entre todas
                                  //para ello pasamos el indice donde se encuentra la fila repetida
                                  //y restamos uno ya que los indices empiezan desde 0
                                 DataRow rowDelete = dt.Rows[indiceFilaRepetida - 1];

                                 //removemos el registro que vamos a modificar
                                  dt.Rows.Remove(rowDelete);

                                  DataRow row = dt.NewRow();//creas un registro 
                                  //Le añades un valor 
                                  row["PRODUCTO"] = txtProducto.Text; 
                                  row["PRECIO"] = Precio;
                                  row["CANTIDAD"] = cantidadNuevaProducto;


                                  dt.Rows.Add(row); //añades el registro a la tabla 
                                  dgvDetalle.DataSource = dt; //añades la tabla al datagrid 
                                  dgvDetalle.Update(); //actualizas para ver el cambio
                              }
                          }
                              catch(Exception ex){
                                  //en caso que el numero ingresado sea demasiado grande
                                  MessageBox.Show("Debe ingresar cantidad numerica máximo de 4 digitos", "Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                              }

                      }
                      //MessageBox.Show("la cantidad es "+n);
                        //_datos.Tables[0].Rows[1][0] = "Updated Company Name";
                        //DataRow row = dt.NewRow();//creas un registro
                        //dt.Rows.Remove(row);la cantidad es " + 


                      

                        


                        //txtCantidad.Clear();




                       // dt.Rows.RemoveAt(5);
                        //dt.Rows.Add(row);

                    }
                }
            }
        }

        private void dgvDetalle_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvDetalle.Columns[e.ColumnIndex].Name == "colBotones" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                //Convierte a la celda donde pondremos nuestra imagen en una celda tipo Boton
                DataGridViewButtonCell celBoton = this.dgvDetalle.Rows[e.RowIndex].Cells["colBotones"] as DataGridViewButtonCell;

                //intanciamos un objeto de tipo Icon pasando como parametro el path y nombre del archivo icono
                //el archivo de imagen debe ser de tipo .ico ya que otro tipo de imagen no acepta
                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\Delete.ico");

                //dibujamos nuestra imagen para ello pasamos el objeto de tipo Icon
                //y parametros como espacio desde la izquierda, asi como espacio desde la parte superior de la celda
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left+25 , e.CellBounds.Top+1);

                //especificamos el ancho de toda la fila
                this.dgvDetalle.Rows[e.RowIndex].Height = icoAtomico.Height+4;
                //especificamos el largo de toda la fila
                this.dgvDetalle.Columns[e.ColumnIndex].Width = icoAtomico.Width+49;

                e.Handled = true;
            }
        }

        private void DeterminarValorImpuesto() {
           
            //determinamos si el foco esta sobre el radioButton  12%
            if (rd12.Checked)
            {
                Iva = 0.12; //asignamos a IVA el valor 0.12           
                
            }
            else if (rd0.Checked) //si el foco esta sobre el radioButton 0%
            {
                Iva = 0;   //asignamos a IVA el valor 0         
            }
           
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //se determina si se ha hecho click sobre el boton de eliminar dentro de la tabla
            if (this.dgvDetalle.Columns[e.ColumnIndex].Name == "colBotones")
            {         
                try {
                    //declaramos una variable tipo DataRow donde cogeremos el indice de fila donde
                    //se hace click
                    
                   
                    DataRow rowDelete = dt.Rows[e.RowIndex];
                    //eliminamos la fila especificando su indice
                    dt.Rows.Remove(rowDelete);
                    
                    //bloqueamos el boton guardar, posteriormente se lo habilita cuando se pulsa sobre
                    //el boton Calcular Factura
                    btnGuardar.Enabled = false;
                    //borramos los valores de las siguientes cajas de texto
                    //con el proposito de hacer que el usuario vuelva a calcular la factura
                    //cuando se haya eliminado una fila de la tabla detalle
                    txtTotalProductos.Text = "";
                    //txtImpuesto.Text = "";
                    txtSubtotal.Text = "";
                    txtFacturaTotal.Text = "";
                    txtIva.Text = "";
                    
                
                } 
                catch(Exception ex){
                    
                 //recuperamos el numero de filas que tiene la tabla
                    int dat = ContarFilasConDatos();
                    //esta condicion es en el caso que la tabla tenga datos y se pulse sobre
                    //el boton eliminar de la fila vacia
                   
                 if (dat > 0)
                 {
                     //MessageBox.Show("Esta fila vacía no es posible eliminar", "Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 //en el caso que no haya elementos dentro de la tabla
                 else {
                     //MessageBox.Show("No hay elementos que eliminar", "Detalle Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

                }
                
            }
        }

        private void rd12_Click(object sender, EventArgs e)
        {
            if(rd12.Checked){
               
           }
            else btnGuardar.Enabled = false;
            
        }

        private void rd0_Click(object sender, EventArgs e)
        {
            if(rd0.Checked){
            
            }
            else btnGuardar.Enabled = false;
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            SMC.PresentationLayer.Reportes.GestionarReporteDetalleFactura objetoReporte = new SMC.PresentationLayer.Reportes.GestionarReporteDetalleFactura();
            objetoReporte.buscarRegistros(Convert.ToInt32(txtNumeroFactura.Text));
            SMC.PresentationLayer.Reportes.verReporteFactura verReporte = new Reportes.verReporteFactura();
            verReporte.Show();
        }

        private void FormaDetalleFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (datosInsertados == 0)
            {

                if (MessageBox.Show("¿Seguro que desea cerrar el formulario?",
                           "Consulta",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true; //Cancela el cerrado del formulario
                }

            }
            else {
                e.Cancel = false;
            }
        }

        
    }

  
}
