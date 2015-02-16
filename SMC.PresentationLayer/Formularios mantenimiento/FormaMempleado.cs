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
    public partial class FormaMempleado : SMC.PresentationLayer.FormaPlantillaMantenimiento
    {

        private static string _apellido;
        private static int _idEmpleado;
        private static string _nombre;
        private static string _titulo;
        private static string _codigoPostal;
        private static DateTime _fecha;
        public static int _botonPresionado;
        //OdbcDataAdapter adapter;
        public FormaMempleado()
        {
            InitializeComponent();
        }

        public static int IDEmployee
        {
            set
            {
                _idEmpleado = value;
            }
            get
            {
                return _idEmpleado;
            }
        }
        public static int BotonPresionado
        {
            set {
                _botonPresionado = value;
            }
            get {
                return _botonPresionado;
            }
        }
        public static string Apellido 
        {
            set {
                _apellido = value;
            }
            get {
                return _apellido;
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

        public static string Titulo
        {
            set
            {
                _titulo = value;
            }
            get
            {
                return _titulo;
            }
        }

        public static DateTime Fecha
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

        public static string CodigoPostal
        {
            set
            {
                _codigoPostal = value;
            }
            get
            {
                return _codigoPostal;
            }
        }

        private void FormaMempleado_Load(object sender, EventArgs e)
        {
            this.txtIDempleado.Select();
        }
        
       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            BotonPresionado = 1;
            SMC.PresentationLayer.Formularios_modificacion.FormaAMempleado empleado = new Formularios_modificacion.FormaAMempleado();
            empleado.Text = "Agregar nuevo empleado";
            empleado.ShowDialog();
            
          
            
        

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BotonPresionado = 2;
            SMC.PresentationLayer.Formularios_modificacion.FormaAMempleado VentanaEmpleado = new Formularios_modificacion.FormaAMempleado();

            //pasar dato a la otra ventana
            FormaMempleado.Apellido = txtApellido.Text;
            FormaMempleado.Nombre = txtNombre.Text;
            FormaMempleado.Titulo = txtTitulo.Text;
            FormaMempleado.CodigoPostal = txtCodigoPostal.Text;
            FormaMempleado.Fecha = txtFecha.Value;
            FormaMempleado.IDEmployee = Convert.ToInt32(txtIDempleado.Text);

            VentanaEmpleado.Text = "Modificar Empleado";
            VentanaEmpleado.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
            try {
                String ora_connect = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                OracleConnection con = new OracleConnection();
                con.ConnectionString = ora_connect;
                
                con.Open();
              
                string select = ("SELECT EmployeeID,LastName,FirstName,Title,HireDate,PostalCode " +
                                                "FROM Employees WHERE EmployeeID =:EmployeeID");

                OracleCommand command = new OracleCommand(select, con);
                command.Parameters.Add(":EmployeeID", OracleDbType.Int32).Value =
                                                      Convert.ToInt32(txtIDempleado.Text);

                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtApellido.Text = reader[1].ToString();
                    txtNombre.Text = reader[2].ToString();
                    txtTitulo.Text = reader[3].ToString();
                    txtFecha.Text = reader[4].ToString();
                    txtCodigoPostal.Text = reader[5].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro el empleado",
                                        "Empleados",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    txtIDempleado.Clear();
                    txtIDempleado.Select();
                }
            }
            catch(Exception ex){
                MessageBox.Show("ERROR: ID Empleado requerido\n para la busqueda","EMPLEADO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtIDempleado.Clear();
                txtApellido.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtCodigoPostal.Clear();
                txtFecha.Text = "";
                txtIDempleado.Select();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();

            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
           
            try { 
            if(txtIDempleado.Text !=""){
                DialogResult confirmar = MessageBox.Show("Eliminar el registro?",
                                         "Empleados",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Error);
                if(confirmar == DialogResult.Yes){
                   string delete = "DELETE FROM EMPLOYEES WHERE EMPLOYEEID=:EMPLOYEEID";
                   connection.Open();
                   OracleCommand command = new OracleCommand(delete, connection);
                    //crear y agregar parametros
                   command.Parameters.Add(":EMPLOYEEID", OracleDbType.Int32, 9).Value = Convert.ToInt32(txtIDempleado.Text);

                   int RegistroEliminado = command.ExecuteNonQuery();
                   if (RegistroEliminado > 0) { }
                   //MessageBox.Show("Registro eliminado",
                   //                    "Empleados",
                   //                    MessageBoxButtons.OK,
                   //                    MessageBoxIcon.Error);
                   else MessageBox.Show("Registro no eliminado",
                                          "Empleados",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);

                   txtIDempleado.Clear();
                   txtApellido.Clear();
                   txtNombre.Clear();
                   txtTitulo.Clear();
                   txtFecha.Text = "";
                   txtCodigoPostal.Clear();

                }
                
            }
            else{
                MessageBox.Show("Ingresar ID Empleado",
                                              "Empleados",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);
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
    }
}
