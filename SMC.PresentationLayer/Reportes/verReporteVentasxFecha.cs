using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using CrystalDecisions.Shared;

namespace SMC.PresentationLayer.Reportes
{
    public partial class verReporteVentasxFecha : SMC.PresentationLayer.FormaPlantillaMaestroDetalle
    {
        OracleConnection connection;
        //esta variable asigna el parametro al reporte
        ParameterFields Parametros = new ParameterFields();

       
       
        
        public verReporteVentasxFecha()
        {
            InitializeComponent();
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            DateTime fechaF = Convert.ToDateTime(dtpFecha.Text).Date;//fecha de la caja  de texto
            DateTime FechAc = DateTime.Now.Date;  //fecha del sistema
            
                //validamos que la fecha no sea mayor que la del sistema
            if (!(fechaF <= FechAc))
            {
                //si la fecha  es mayor que la del sistema le informamos al usuario
                MessageBox.Show("Fecha  no puede ser \n Mayor que la fecha actual");
            }
            else {
                //aqui se obtiene solo la fecha sin la hora, si quisieramos con hora incluido se utiliza la propiedad Value
                string fechaIn = dtpFecha.Text + " 00:00:00";
                string fechaFn = dtpFecha.Text + " 23:59:59";
               
                buscarRegistros(fechaIn, fechaFn);
               
            }
           
        }

        public void buscarRegistros(string fechaIni,string fechaFin)
        {
            connection = new OracleConnection();
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";

            try
            {
    

          string sqlProductosVendidos = "select d.productcode,p.description,nvl(sum(d.quantity),0) as cantidad_productos_vendidos "+
                "from invoicelineitems d,invoices f,products p where f.invoiceid=d.invoiceid and f.invoicedate " +
                "between to_date('" + fechaIni + "', 'dd/mm/yyyy hh24:mi:ss') and " + 
                "to_date('"+fechaFin+"', 'dd/mm/yyyy hh24:mi:ss') and d.productcode = p.productcode "+
                 "group by d.productcode,p.description";

          string sqlTotalFacturasVendidas = "select f.invoiceid,f.invoicetotal from invoices f inner join invoicelineitems d "+
              "on f.invoiceid=d.invoiceid where invoicedate between to_date('" + fechaIni + "', 'dd/mm/yyyy hh24:mi:ss') " +
              "and to_date('" + fechaFin + "', 'dd/mm/yyyy hh24:mi:ss') group by f.invoiceid,invoicetotal";



          connection.Open();
          OracleCommand command = new OracleCommand();
          command.Connection = connection;
          command.CommandText = sqlProductosVendidos;
          OracleDataAdapter da = new OracleDataAdapter();
          da.SelectCommand = command;
          DataSet ds = new DataSet();
          da.Fill(ds, "INVOICELINEITEMS");

          command.CommandText = sqlTotalFacturasVendidas;
          da.SelectCommand = command;

          da.Fill(ds, "INVOICES");
          connection.Close();
          DataTable dt = new DataTable();
          dt = ds.Tables[0];



          connection.Open();

          OracleCommand commando = new OracleCommand();
          commando.CommandText = sqlProductosVendidos;
          commando.CommandType = CommandType.Text;
          commando.Connection = connection;

          OracleDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                       MessageBox.Show("si hay filas");

                       CrearCarpetaXml(@"C:\MSI\XML");

                       string url = @"C:\MSI\XML\ventaProductos.xml";
                       ds.WriteXml(url, XmlWriteMode.WriteSchema);

                       
                }
                else
                {
                    MessageBox.Show("No existe ventas realizadas en esta fecha");
                }
                
            }
           
            catch (OracleException exe)
            {
                MessageBox.Show("error en la conexion" + exe.Message);
               
            }
        }


        public bool CrearCarpetaXml(string Ruta)
        {
            bool Respuesta = false;
            try
            {
                if (Directory.Exists(Ruta))
                {
                    Respuesta = true;
                }
                else
                {
                    Directory.CreateDirectory(Ruta);
                    Respuesta = true;
                }
                return Respuesta;
            }
            catch (Exception ex)
            {
                //logger.Error("Error en CrearCarpetaXml, ClaseXml:" + ex.Message);  
                return Respuesta;
                //No fue posible crear el directorio...  
            }

        }

        private void verReporteVentasxFecha_Load(object sender, EventArgs e)
        {

        }
    }
}
