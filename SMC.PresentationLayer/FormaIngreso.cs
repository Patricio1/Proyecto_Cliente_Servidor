using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace SMC.PresentationLayer
{
    public partial class FormaIngreso : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        public FormaIngreso()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Crear un objeto para la conexion entre cliente/servidor.
            OracleConnection connection = new OracleConnection();
            //OdbcConnection connection = new OdbcConnection();
            //OleDbConnection connection2 = new OleDbConnection();
            try
            {

                //connection2.ConnectionString = "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI";

                //Establecer las principales propiedades del Connection.

                connection.ConnectionString = "User Id="+txtUsuario.Text+"; Password="+txtContraseña.Text+"; Data Source=XE";
                //"Data Source="+txtServidor.Text+";Initial Catalog="+txtBaseDatos.Text+";User ID="+txtUsuario.Text+";Password="+txtContraseña.Text+"";
                
                //Almacenar el ConnectionString  en un campo estatico
                Conexion.CadenaConexion = connection.ConnectionString;//set
                Conexion.BaseDatos = txtBaseDatos.Text;
                Conexion.Servidor = txtServidor.Text;
                Conexion.Usuario = txtUsuario.Text;
                Conexion.Contraseña = txtContraseña.Text;

                //Establecer la conexion entre c/s.
                connection.Open();//ConnectionString

                //Cerrar la forma actual.
                this.Hide();

                //Crear un objeto FormaMenu
                FormaMenu forma = new FormaMenu();
                forma.ShowDialog();
            }//errores de BD.
            catch (OracleException ex)
            {
                //string saltoLinea = "\n";
                //string problema = "EL PROBLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
                //string solucion = "POR FAVOR PRUEBE LA SIGUIENTE SOLUCION:";
                //string mensajeFinal = "NOTA: En caso de persistir el problema, llame Soporte tecnico," +
                //                       saltoLinea +
                //                       "o consulte con el Administrador del sistema.";

                //string mensaje = null;

                ////Verificar el numero de error generado en la BD.

                //switch (ex.Number)
                //{
                //    //case 53:
                //    //    //Personalizar el error.
                //    //    break;

                //    //case 4060:
                //    //    //Personalizar el error.
                //    //    break;

                //    case 18456:
                //        //Personalizar el error.
                //        mensaje = problema +
                //                 saltoLinea +
                //                 "1.-El nombre del usuario y/o la contraseña no son validas." +
                //                 saltoLinea +
                //                  "2.-El nombre de usuario y/o la contraseña son requeridos." + 
                //                 saltoLinea +
                //                 saltoLinea +
                //                 solucion +
                //                 saltoLinea +
                //                 "1.-Verifique que el nombre de usuario y/o la contraseña sean correctos." +
                //                 saltoLinea +
                //                 "2.-Ingrese un nombre de usuario y/o la contraseña." + 
                //                 saltoLinea +
                //                 saltoLinea +
                //                 mensajeFinal;                                
                //        break;

                //        //errores no personalizados (desconocidos).
                //    default:
                //        mensaje = "ERROR DESCONOCIDO:" +
                //                  saltoLinea +
                //                  saltoLinea +
                //                  "TEXT: " + ex.Message + 
                //                  saltoLinea +
                //                  "FUENTE: " + ex.Source +
                //                  saltoLinea +
                //                  "LINEA: " + ex.StackTrace +
                //                  saltoLinea +
                //                  "NUMERO: " + ex.Number;
                //        break;
                //}
                
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
                //Cerrar la conexion.
                connection.Close();
                //Liberar memoria.
                connection.Dispose();
            }
        }

        private void txtServidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormaIngreso_Load(object sender, EventArgs e)
        {
            BusquedasPersonalizadas.FormaBuscarProducto.indiceVentanaProducto += 1;
            FormaBuscarCustomers.indiceVentanaCustomer += 1;
        }
    }
}
