using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMC.PresentationLayer
{
    static class Conexion
    {
        private static string _cadenaConexion;

        private static string _baseDatos;
        private static string _servidor;
        private static string _usuario;
        private static string _contraseña;

        public static String CadenaConexion
        {
            set
            {
                _cadenaConexion = value;
            }
            get
            {
                return _cadenaConexion;
            }
        }

        public static string BaseDatos
        {
            set
            {
                _baseDatos = value;
            }
            get
            {
                return _baseDatos;
            }
        }

        public static string Servidor
        {
            set
            {
                _servidor = value;
            }
            get
            {
                return _servidor;
            }
        }

        public static string Usuario
        {
            set
            {
                _usuario = value;
            }
            get
            {
                return _usuario;
            }
        }

        public static string Contraseña
        {
            set
            {
                _contraseña = value;
            }
            get
            {
                return _contraseña;
            }
        }
    }
}
