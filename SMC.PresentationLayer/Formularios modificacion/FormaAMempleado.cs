using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using SMC.BusinessObjects;

namespace SMC.PresentationLayer.Formularios_modificacion
{
    public partial class FormaAMempleado : SMC.PresentationLayer.FormaPlantillaAgregarModificar
    {
        Validaciones ClaseValidar;
       
        private int ConfirmarUpdate;
        public FormaAMempleado()
        {
            InitializeComponent();
            ClaseValidar = new Validaciones();
            
        }

        private void InsertarEmpleado() {

            DateTime fechaF = Convert.ToDateTime(txtFecha.Text).Date;//fecha de la caja de la caja de texto
            DateTime FechAc = DateTime.Now.Date;  //fecha del sistema
            #region Controlar campos vacios y fecha
            if (txtApellido.Text == "" || txtNombre.Text == "" || txtTitulo.Text == "" || txtCodigoPostal.Text == "")
            {
                MessageBox.Show("Los campos estan vacios \n Ingrese informacion", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //verificamos cual de los textbox estan vacios y ubicamos el foco ahi
                if (txtApellido.Text == "") txtApellido.Select();
                else if (txtNombre.Text == "") txtNombre.Select();
                else if (txtTitulo.Text == "") txtTitulo.Select();
                else if (txtCodigoPostal.Text == "") txtCodigoPostal.Select();
            }

                //validamos que la fecha no sea mayor que la del sistema
            else if (fechaF <= FechAc)
            {

                OracleConnection connection = new OracleConnection();
                Conexion.CadenaConexion = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                try
                {
                    if (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado == 1)
                    {
                        #region insertar
                        //preparar el insert
                        string insert = "INSERT INTO EMPLOYEES(LASTNAME,FIRSTNAME,TITLE,HIREDATE,POSTALCODE) " +
                                         "VALUES(:LASTNAME,:FIRSTNAME,:TITLE,:HIREDATE,:POSTALCODE)";

                        OracleCommand command = new OracleCommand(insert, connection);

                        //creamos y añadimos parametros

                        command.Parameters.Add(":LASTNAME", OracleDbType.Varchar2, 20).Value = txtApellido.Text;
                        command.Parameters.Add(":FIRSTNAME", OracleDbType.Varchar2, 10).Value = txtNombre.Text;
                        command.Parameters.Add(":TITLE", OracleDbType.Varchar2, 30).Value = txtTitulo.Text;
                        command.Parameters.Add(":HIREDATE", OracleDbType.Date, 5).Value = txtFecha.Value;
                        command.Parameters.Add(":POSTALCODE", OracleDbType.Varchar2, 10).Value = txtCodigoPostal.Text;

                        connection.Open();

                        int filasInsertadas = command.ExecuteNonQuery();
                        if (filasInsertadas > 0)
                        {
                            txtApellido.Clear();
                            txtCodigoPostal.Clear();
                            txtNombre.Clear();
                            txtTitulo.Clear();
                            txtFecha.Text = "";
                            txtApellido.Select();
                        }
                        else

                            MessageBox.Show("Registro no insertado",
                                        "Clientes",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);


                        #endregion
                    }

                    else if (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado == 2)
                    {
                        #region actualizar
                        string update = "UPDATE EMPLOYEES SET LASTNAME=:LASTNAME,FIRSTNAME=:FIRSTNAME," +
                                        "TITLE=:TITLE,HIREDATE=:HIREDATE,POSTALCODE=:POSTALCODE" +
                                        " WHERE EMPLOYEEID=:EMPLOYEEID";

                        OracleCommand commandUpdate = new OracleCommand(update, connection);

                        //crear y agregar parametros
                        commandUpdate.Parameters.Add(":LASTNAME", OracleDbType.Varchar2, 20).Value = txtApellido.Text;
                        commandUpdate.Parameters.Add(":FIRSTNAME", OracleDbType.Varchar2, 10).Value = txtNombre.Text;
                        commandUpdate.Parameters.Add(":TITLE", OracleDbType.Varchar2, 30).Value = txtTitulo.Text;
                        commandUpdate.Parameters.Add(":HIREDATE", OracleDbType.Date, 5).Value = txtFecha.Value;
                        commandUpdate.Parameters.Add(":POSTALCODE", OracleDbType.Varchar2, 10).Value = txtCodigoPostal.Text;
                        commandUpdate.Parameters.Add(":EMPLOYEEID", OracleDbType.Int32, 9).Value = (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.IDEmployee);

                        connection.Open();
                        int filasActualizadas = commandUpdate.ExecuteNonQuery();
                        if (filasActualizadas > 0)
                        {

                            MessageBox.Show("Registro actualizado",
                                     "Clientes",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                            ConfirmarUpdate = 1;
                        }
                        else
                        {
                            MessageBox.Show("Registro no actualizado",
                                        "Clientes",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                            ConfirmarUpdate = 0;
                        }
                        #endregion
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
            #endregion
            else
            {
                //si la fecha de contratacion es mayor que la del sistema le informamos al usuario
                MessageBox.Show("Fecha de Contratacion no puede ser \n Mayor que la fecha actual","Empleados",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFecha.Select();
                
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            InsertarEmpleado();
            //si se ha hecho el update correctamente
            if(ConfirmarUpdate==1){
                SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado employ = (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado)Application.OpenForms[0];

                employ.txtApellido.Text = txtApellido.Text;
                employ.txtNombre.Text = txtNombre.Text;
                employ.txtTitulo.Text = txtTitulo.Text;
                employ.txtFecha.Text = txtFecha.Text;
                employ.txtCodigoPostal.Text = txtCodigoPostal.Text;
            }
            }
            
        

       
        private void FormaAMempleado_Load(object sender, EventArgs e)
        {
            this.Location = new Point(630, 130);
            this.txtApellido.Select();
            if (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.BotonPresionado == 2)
            {
                txtApellido.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Apellido;
                txtNombre.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Nombre;
                txtTitulo.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Titulo;
                txtCodigoPostal.Text = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.CodigoPostal;
                txtFecha.Value = SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Fecha;
            }
            else {
                txtApellido.Clear();
                txtNombre.Clear();
                txtTitulo.Clear();
                txtCodigoPostal.Clear();
            }
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {
            
        }

        #region Validar cajas de texto
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            //llamamos al metodo validar y enviamos el parametro 2 
            //para validar solo letras
            ClaseValidar.validar(sender,e,2,txtApellido);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //llamamos al metodo validar y enviamos el parametro 2 
            //para validar solo letras
            ClaseValidar.validar(sender, e, 2, txtNombre);
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //llamamos al metodo validar y enviamos el parametro 2 
            //para validar solo letras
            ClaseValidar.validar(sender, e, 2, txtTitulo);
        }

        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //llamamos al metodo validar y enviamos el parametro 5 
            //para validar solo alfanumericos
            ClaseValidar.validar(sender, e, 5, txtCodigoPostal);
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
