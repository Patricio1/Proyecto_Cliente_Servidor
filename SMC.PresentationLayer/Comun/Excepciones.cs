using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;//SQL Server.

namespace SMC.PresentationLayer
{
    /// <summary>
    /// Permite administrar las excepciones producidas
    /// tanto por SQL Server como por el cliente C#.
    /// </summary>
    public static class Excepciones
    {
        private static string _mensajePersonalizado;

        public static string MensajePersonalizado
        {
            get
            {
                return _mensajePersonalizado;
            }
        }

        /// <summary>
        /// Permite gestinar las excepciones producidas
        /// en SQL Server.
        /// </summary>
        /// <param name="ex">Excepcion de SQL Server</param>
        public static void Gestionar(SqlException ex)
        {
            string saltoLinea = "\n";
            string problema = "EL PROBLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
            string solucion = "POR FAVOR PRUEBE LA SIGUIENTE SOLUCION:";
            string mensajeFinal = "NOTA: En caso de persistir el problema, llame Soporte tecnico," +
                                  saltoLinea +
                                  "o consulte con el Administrador del sistema.";

            string mensaje = null;

            //Verificar el numero de error generado en la BD.
            switch (ex.Number)
            {
                //case 53:
                //    //Personalizar el error.
                //    break;

                //case 4060:
                //    //Personalizar el error.
                //    break;

                case 18456:
                    //Personalizar el error.
                    mensaje = problema +
                             saltoLinea +
                             "1.-El nombre del usuario y/o la contraseña no son validas." +
                             saltoLinea +
                              "2.-El nombre de usuario y/o la contraseña son requeridos." +
                             saltoLinea +
                             saltoLinea +
                             solucion +
                             saltoLinea +
                             "1.-Verifique que el nombre de usuario y/o la contraseña sean correctos." +
                             saltoLinea +
                             "2.-Ingrese un nombre de usuario y/o la contraseña." +
                             saltoLinea +
                             saltoLinea +
                             mensajeFinal;
                    break;

                //errores no personalizados (desconocidos).
                default:
                    mensaje = "ERROR DESCONOCIDO:" +
                              saltoLinea +
                              saltoLinea +
                              "TEXT: " + ex.Message +
                              saltoLinea +
                              "FUENTE: " + ex.Source +
                              saltoLinea +
                              "LINEA: " + ex.StackTrace +
                              saltoLinea +
                              "NUMERO: " + ex.Number;
                    break;
            }

            //Retornar el mensaje personalizado.
            _mensajePersonalizado = mensaje;
        }

        /// <summary>
        /// Permite gestinar las excepciones producidas
        /// en C#r.
        /// </summary>
        /// <param name="ex">Excepcion de C#</param>
        public static void Gestionar(Exception ex)
        {
            string saltoLinea = "\n";
            string problema = "EL PROBLEMA GENERADO PUEDE DEBERSE A LOS SIGUIENTES FACTORES";
            string solucion = "POR FAVOR PRUEBE LA SIGUIENTE SOLUCION:";
            string mensajeFinal = "NOTA: En caso de persistir el problema, llame Soporte tecnico," +
                                  saltoLinea +
                                  "o consulte con el Administrador del sistema.";

            string mensaje = null;

            //Obtener el tipo de excepcion genarada por C#.
            string tipoExcepcion = ex.GetType().ToString();

            //Verificar el numero de error generado en la BD.
            switch (tipoExcepcion)
            {       
                case "System.ArgumentException":
                    //Personalizar el error. 
                    mensaje = "ArgumentException";
                    //.....
                    break;

                //errores no personalizados (desconocidos).
                default:
                    mensaje = "ERROR DESCONOCIDO:" +
                              saltoLinea +
                              saltoLinea +
                              "TEXT: " + ex.Message +
                              saltoLinea +
                              "FUENTE: " + ex.Source +
                              saltoLinea +
                              "LINEA: " + ex.StackTrace +
                              saltoLinea +
                              "TIPO: " + ex.GetType();
                    break;
            }

            //Retornar el mensaje personalizado.
            _mensajePersonalizado = mensaje;
        }


    }
}
