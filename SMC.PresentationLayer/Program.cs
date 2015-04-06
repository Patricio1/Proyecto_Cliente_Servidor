using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SMC.DataAccessLayer;
using SMC.PresentationLayer;

namespace SMC.PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         // Application.Run(new SMC.PresentationLayer.Reportes.Form1());
        //Application.Run(new SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura());
            //Application.Run(new SMC.PresentationLayer.Resources.FormaBuscarProductos());
           //Application.Run(new SMC.PresentationLayer.Formularios_mantenimiento.OrderOptions());
          Application.Run(new FormaIngreso());
            //Application.Run(new FormaMenu());
         // Application.Run(new BusquedasPersonalizadas.FormaBuscarProducto());
      //  Application.Run(new Reportes.verReporteProductos());
          //Application.Run(new SMC.PresentationLayer.Formularios_mantenimiento.FormaMFactura());
            
            
        }
    }
}
