using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


namespace SMC.PresentationLayer.Reportes
{
    public partial class Form1 : Form
    {
        OracleConnection connection;
        OracleDataAdapter adaptador;
       
        
        public Form1()
        {
            InitializeComponent();
          
            adaptador = new OracleDataAdapter();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            
            

            connection = new OracleConnection();
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            try
            {

               // if (buscarRegistros()) { 
               //MessageBox.Show("proceso exitoso");
             //    CrearCarpetaXml(@"C:\MSI\XML");
               

             //    CrearXmlTransacciones();
             //    tablas.ReadXml(@"C:\MSI\XML\ventas.xml");

                //System.IO.StreamReader xmlStream = new System.IO.StreamReader(@"C:\MSI\XML\ventas.xml");
                //tablas = new DataSet();
                //tablas.ReadXmlSchema(xmlStream);
                //xmlStream.Close();
                //}
                //else MessageBox.Show("proceso no realizado");
                generarProductos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error"+ex.Message+ex);
                
            }

        }

        private void generarProductos() {
            connection = new OracleConnection();
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
            string sql = "SELECT* FROM PRODUCTS";

            connection.Open();
            OracleCommand command = new OracleCommand();
            //command.Connection = connection;
            //command.CommandText = sql;
            OracleDataAdapter da = new OracleDataAdapter(sql,connection);
            //da.TableMappings.Add("PRODUCTOS","PRODUCTS");
            DataSet tabla = new DataSet("PRODUCTOS");
            da.Fill(tabla, "PRODUCTS");

            string url = @"C:\MSI\XML\products.xml";
            tabla.WriteXml(url, XmlWriteMode.WriteSchema);
        }
        private Boolean buscarRegistros()
        {
            connection = new OracleConnection();
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";
           
            try
            {

                
string sql="SELECT* FROM INVOICES F INNER JOIN CUSTOMERS C ON F.CUSTOMERID= C.CUSTOMERID WHERE F.INVOICEID=126";
string sql1="SELECT* FROM INVOICELINEITEMS D INNER JOIN PRODUCTS P ON D.PRODUCTCODE=P.PRODUCTCODE WHERE D.INVOICEID=126";
                
 
connection.Open();
OracleCommand command = new OracleCommand();
command.Connection = connection;
command.CommandText = sql;
OracleDataAdapter da = new OracleDataAdapter();
da.SelectCommand = command;
DataSet ds = new DataSet();
da.Fill(ds, "INVOICES");
command.CommandText = sql1;
da.SelectCommand = command;
da.Fill(ds, "INVOICELINEITEMS");
connection.Close();
DataTable dt = new DataTable();
dt = ds.Tables[0];



//Cómo agregar dos o más tablas de bases de datos de SQL Server en el conjunto de datos en ASP.NET 
//MAS DETALLES EN ESTE LINK:
//www.devasp.net/net/articles/display/1355.html
//TAMBIEN UN RECURSO DE GOOGLE
//hhttps://books.google.com.ec/books?id=DjtSAS2T5EMC&pg=PA120&lpg=PA120&dq=tablemappings+add+c%23&source=bl&ots=PkWfsba-ck&sig=XHUcMlyeLWWAXU9lhUfGHjQrKUI&hl=es-419&sa=X&ei=2O8QVbCFMIHXgwTxyIDoDA&ved=0CDIQ6AEwAzgK#v=onepage&q=tablemappings%20add%20c%23&f=false

string url = @"C:\MSI\XML\ventas.xml";
ds.WriteXml(url, XmlWriteMode.WriteSchema);
              

                
                //MessageBox.Show("proceso realizado");
                return true;
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error en la conexion"+ex.Message);
            //    return false;
            //}
            catch(OracleException exe){
                MessageBox.Show("error en la conexion" + exe.Message);
                  return false;
            }
        }


        public  bool CrearCarpetaXml(string Ruta)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
