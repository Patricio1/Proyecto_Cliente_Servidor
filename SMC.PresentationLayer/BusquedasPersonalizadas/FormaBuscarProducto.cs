using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using SMC.BusinessObjects;

namespace SMC.PresentationLayer.BusquedasPersonalizadas
{
    public partial class FormaBuscarProducto : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        private DataView _dataViewProducts;
        int valor;
        public static int indiceVentanaProducto=0;
        Validaciones ClaseValidar;
        DataTable table;
        public FormaBuscarProducto()
        {
            InitializeComponent();
            ClaseValidar = new Validaciones();
            
        }

        private void Recuperar() {
            OracleConnection connection = new OracleConnection();
            //Conexion.CadenaConexion = connection.ConnectionString;

            //Conexion.CadenaConexion = 
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";


            String select = "SELECT PRODUCTCODE,DESCRIPTION,UNITPRICE,ONHANDQUANTITY " +
                        "FROM PRODUCTS WHERE ONHANDQUANTITY>0 ";
            OracleCommand command = new OracleCommand(select, connection);

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = command;

            DataSet dataset = new DataSet();

            adapter.Fill(dataset, "PRODUCTS");
            dgvDatos.DataSource = dataset;
            dgvDatos.DataMember = "PRODUCTS";
            lblMensaje.Text = "Filas recuperadas: " + dataset.Tables[0].Rows.Count;
            DataView _datViewCustomers = new DataView();

            _dataViewProducts = dataset.Tables["PRODUCTS"].DefaultView;
            dgvDatos.DataSource = _dataViewProducts;

            //---------------------------------------------------------------------
            //Recuperar datos de la tabla:PRODUCTS y mostrarlos en el combo box (PRECIOS no repetidos)
            select = "select distinct UNITPRICE FROM PRODUCTS"; 
                //"select distinct UNITPRICE from PRODUCTS";
            command.CommandText = select;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            connection.Open();
            // usar un DataReader para recuperar los datos
            OracleDataReader reader = command.ExecuteReader(); //sqlDataReader no tiene contructor
            table = new DataTable();
            table.Load(reader); //leer los datos

            //vincular-enlazar los datos del dataTable
            //al comboBox.
            cboPrecioProd.DataSource = table;
            cboPrecioProd.DisplayMember = "UNITPRICE";
            cboPrecioProd.ValueMember = "UNITPRICE";

            for (int i = 0; i < _dataViewProducts.Table.Columns.Count; i++)
            {
                lstCampoParaOrdenar.Items.Add(_dataViewProducts.Table.Columns[i].ColumnName);
            }
        }

     
        private void FormaBuscarProducto_Load(object sender, EventArgs e)
        {
         //   llenarCombo();
            this.Location = new Point(628, 100);
            Recuperar();
        }

        private void btnAceptarCodProd_Click(object sender, EventArgs e)
        {
            _dataViewProducts.RowFilter = "PRODUCTCODE=" + txtCodigoPro.Text.Trim() + "";
            _dataViewProducts.RowStateFilter = DataViewRowState.OriginalRows;//

            //MOstrar los datos una vez filtrados.
            dgvDatos.DataSource = _dataViewProducts;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewProducts.Count;
        }

        private void btnAceptarDescripcion_Click(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: EmployeeID
            //__dataViewCustomes.RowFilter : SELECT* FROM Employees WHERE EmployeeID......
            _dataViewProducts.RowFilter = "DESCRIPTION LIKE '" + txtDescPro.Text.Trim() + "%'"; //patron de busqueda
            _dataViewProducts.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewProducts;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewProducts.Count;
        }

        private void txtDescPro_TextChanged(object sender, EventArgs e)
        {
            
            _dataViewProducts.RowFilter = "DESCRIPTION LIKE '" + txtDescPro.Text.Trim() + "%'"; //patron de busqueda
            _dataViewProducts.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewProducts;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewProducts.Count;
        }

        private void cboPrecioProd_SelectedIndexChanged(object sender, EventArgs e)
        {
           // establecer la busqueda por campo: Title
            //__dataViewCustomes.RowFilter : SELECT* FROM Employees WHERE EmployeeID......
         //  double precio = Convert.ToDouble(cboPrecioProd.SelectedValue.ToString());
            //_dataViewProducts.RowFilter = "UNITPRICE='" + Convert.ToDouble(cboPrecioProd.SelectedValue) + "'"; //patron de busqueda
            //_dataViewProducts.RowStateFilter = DataViewRowState.OriginalRows;

            //dgvDatos.DataSource = _dataViewProducts;
            //lblMensaje.Text = "Filas recuperadas: " + _dataViewProducts.Count;
        }

        private void txtCodigoPro_TextChanged(object sender, EventArgs e)
        {
            //table.Clear();
           // Recuperar();
            _dataViewProducts.RowFilter = "PRODUCTCODE LIKE '" + txtCodigoPro.Text.Trim() + "%'"; //patron de busqueda
            _dataViewProducts.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewProducts;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewProducts.Count;
           // table.Clear();
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {

        }

        private void rdbAscendente_CheckedChanged(object sender, EventArgs e)
        {
            if (lstCampoParaOrdenar.SelectedIndex >= 0)
            {
                _dataViewProducts.Sort = lstCampoParaOrdenar.SelectedItem + " ASC";
                //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
                dgvDatos.DataSource = _dataViewProducts;

                //MOSTRAR el criterio de ordenamiento
                lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                    "ascendentemente";
            }
        }

        private void rdbDescendente_CheckedChanged(object sender, EventArgs e)
        {
            if (lstCampoParaOrdenar.SelectedIndex >= 0)
            {
                _dataViewProducts.Sort = lstCampoParaOrdenar.SelectedItem + " DESC";
                //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
                dgvDatos.DataSource = _dataViewProducts;

                //MOSTRAR el criterio de ordenamiento
                lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                    "descendentemente";
            }
        }

        private void txtCodigoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClaseValidar.validar(sender,e,5,txtCodigoPro);
        }

        private void txtDescPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClaseValidar.validar(sender, e, 5, txtDescPro);
        }

      
        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = (SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura)Application.OpenForms[indiceVentanaProducto];
                String producto = (dgvDatos.Rows[e.RowIndex].Cells["PRODUCTCODE"].Value.ToString());
                String precio = (dgvDatos.Rows[e.RowIndex].Cells["UNITPRICE"].Value.ToString());
                detalle.Cantidad = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells["ONHANDQUANTITY"].Value.ToString());

               
                detalle.txtProducto.Text = producto;
                detalle.Precio = Convert.ToDouble(precio);
                //ubicamos el cursor en el txtCantidad
                detalle.txtCantidad.Select();
                detalle.txtCantidad.Clear();
                //#region crear boton
                //foreach (DataGridViewRow row in detalle.dgvDetalle.Rows)
                //{

                //    if (!string.IsNullOrEmpty(row.Cells["PRODUCTO"].FormattedValue.ToString()))
                //    {
                        
                //    }
                //}

                //#endregion
               

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ventanas innecesarias estan abiertas \n Cerrar ventanas que estan demas", "Error al pasar datos");
            }
        }

        private void FormaBuscarProducto_LocationChanged(object sender, EventArgs e)
        {
            //this.Location = new Point(20, 60);
        }
    }
}
