using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using SMC.BusinessObjects;

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
        Validaciones ClaseValidar;
        private int ConfirmarSelect;
        
        //OdbcDataAdapter adapter;
        public FormaMempleado()
        {
            InitializeComponent();
            ClaseValidar = new Validaciones();
        }

        #region Propiedades
        public string this[int indice]{
            set {
                Nombre = value;
            }
            get {
               return Nombre;
            }
        
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

        #endregion

        private void FormaMempleado_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1, 5);
            this.txtIDempleado.Select();
        }




        private void buscarEmpleadoPorID() {
            try
            {
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
                    ConfirmarSelect = 1; //en caso de haber encontrado el registro
                }
                else
                {
                    MessageBox.Show("No se encontro el empleado",
                                        "Empleados",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    txtIDempleado.Clear();
                    txtIDempleado.Select();
                    txtCodigoPostal.Clear();
                    txtApellido.Clear();
                    txtNombre.Clear();
                    txtTitulo.Clear();
                    ConfirmarSelect = 0; //en caso de no haber encontrado ningun registro
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: ID Empleado requerido\n para la busqueda", "EMPLEADO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIDempleado.Clear();
                txtApellido.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtCodigoPostal.Clear();
                txtFecha.Text = "";
                txtIDempleado.Select();
            }
        }
       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //si tenemos id de empleado buscamos directamente
            if (txtIDempleado.Text != "")
            {
                buscarEmpleadoPorID();
                if (ConfirmarSelect == 1)
                {
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else {
                    btnUpdate.Enabled = !true;
                    btnDelete.Enabled = !true;
                } 
            }
                //si la caja de texto permanece en blanco llamamos a la busqueda personalizada
            else {
                FormaBuscarEmployees buscarEmpleado = new FormaBuscarEmployees(2);
                buscarEmpleado.MdiParent = this.MdiParent;
                buscarEmpleado.Show();
                txtIDempleado.Clear();
                txtApellido.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtFecha.Text = "";
                txtCodigoPostal.Clear();
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtIDempleado.Text != "")
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
            else {
                MessageBox.Show("Debe ingresar ID de empleado \n para poder modificar","Empleado",
                                MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtIDempleado.Select();
            }
        }

        private void eliminarEmpleado() {
            OracleConnection connection = new OracleConnection();

            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";

            try
            {
                if (txtIDempleado.Text != "")
                {
                    DialogResult confirmar = MessageBox.Show("Eliminar el registro?",
                                             "Empleados",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Error);
                    if (confirmar == DialogResult.Yes)
                    {
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
                else
                {
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
          if(txtIDempleado.Text!=""){
              eliminarEmpleado();
              txtIDempleado.Select();
          }
          else{
              MessageBox.Show("Debe ingresar ID de empleado \n para poder eliminar","Empleado",
                                MessageBoxButtons.OK,MessageBoxIcon.Information);
              txtIDempleado.Select();
          }
        }

       

        private void txtIDempleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClaseValidar.validar(sender,e,1,txtIDempleado);
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            BotonPresionado = 1;
            SMC.PresentationLayer.Formularios_modificacion.FormaAMempleado empleado = new Formularios_modificacion.FormaAMempleado();
            empleado.Text = "Agregar nuevo empleado";
            empleado.ShowDialog();
        }
    }
}
