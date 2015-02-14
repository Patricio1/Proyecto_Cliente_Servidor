using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SMC.PresentationLayer
{
    public partial class FormaBuscarCustomers : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        private DataView _dataViewCustomes;
        public delegate void enviar(String mensaje);
        public event enviar eventoUno;
        public static FormaBuscarCustomers forma = new FormaBuscarCustomers();
        public FormaBuscarCustomers()
        {
            InitializeComponent();
            _dataViewCustomes = new DataView();
        }

        private void FormaBuscarCustomers_Load(object sender, EventArgs e)
        {
             SqlConnection connection = new SqlConnection();
             //Conexion.CadenaConexion = connection.ConnectionString;
             connection.ConnectionString = "Data Source=ACER-PC;Initial Catalog=MMABOOKS;User ID=sa;Password=sa";
             String select = "SELECT CustomerID,Name,Address,City,State " +
                          "FROM Customers";
            SqlCommand command = new SqlCommand(select,connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataSet dataset = new DataSet();

            adapter.Fill(dataset,"Customers");
            dgvDatos.DataSource = dataset;
            dgvDatos.DataMember = "Customers";
            lblMensaje.Text = "Filas recuperadas: " + dataset.Tables[0].Rows.Count;
               DataView _datViewCustomers= new DataView() ;

               _dataViewCustomes = dataset.Tables["Customers"].DefaultView;
               dgvDatos.DataSource = _dataViewCustomes;
            //---------------------------------------------------------------------
            //Recuperar datos de la tabla:States y mostrarlos en el combo box
            select = "SELECT StateCode,StateName " +
                    "FROM States";
            command.CommandText = select;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            connection.Open();
            // usar un DataReader para recuperar los datos
            SqlDataReader reader = command.ExecuteReader(); //sqlDataReader no tiene contructor
            DataTable table = new DataTable();
            table.Load(reader); //leer los datos

            //vincular-enlazar los datos del dataTable
            //al comboBox.
            cboEstado.DataSource = table;
            cboEstado.DisplayMember = "StateName";

            cboEstado.ValueMember = "StateCode";

            //
            for (int i = 0; i < _dataViewCustomes.Table.Columns.Count; i++)
            {
                lstCampoParaOrdenar.Items.Add(_dataViewCustomes.Table.Columns[i].ColumnName);
            }
        }


        private void btnAceptarIdCliente_Click(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "CustomerID=" + txtIdCliente.Text.Trim() + "";
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;//

            //MOstrar los datos una vez filtrados.
            dgvDatos.DataSource =_dataViewCustomes;
            lblMensaje.Text ="Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnAceptarNombre_Click(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: CustomerID
            //__dataViewCustomes.RowFilter : SELECT* FROM Customers WHERE CustomerID......
            _dataViewCustomes.RowFilter = "Name LIKE '"+txtNombre.Text.Trim()+"%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "Name LIKE '" + txtNombre.Text.Trim() + "%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: State
            //__dataViewCustomes.RowFilter : SELECT* FROM Customers WHERE CustomerID......
            _dataViewCustomes.RowFilter = "State = '"+cboEstado.SelectedValue+"' "; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                //FormaMcliente form = (FormaMcliente)Application.OpenForms[0];
                //form. acer= "hola";

                //FormaMcliente f = new FormaMcliente();
                //f.acer = "hola";
                this.eventoUno("hola mundo");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "CUSTOMER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAscendente_CheckedChanged(object sender, EventArgs e)
        {
           if(lstCampoParaOrdenar.SelectedIndex>=0)
           {
               _dataViewCustomes.Sort = lstCampoParaOrdenar.SelectedItem+" ASC";
               //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
               dgvDatos.DataSource = _dataViewCustomes;

               //MOSTRAR el criterio de ordenamiento
               lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                   "ascendentemente";
           }
        }

        private void rdbDescendente_CheckedChanged(object sender, EventArgs e)
        {
            if (lstCampoParaOrdenar.SelectedIndex >= 0)
            {
                _dataViewCustomes.Sort = lstCampoParaOrdenar.SelectedItem + " DESC";
                //MOSTRAR LOS DATOS UNA VEZ ORDENADOS
                dgvDatos.DataSource = _dataViewCustomes;

                //MOSTRAR el criterio de ordenamiento
                lblMensaje.Text = "Ordenado por : " + lstCampoParaOrdenar.SelectedItem +
                                    "descendentemente";
            }
        }

        private void rdbAscendente_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FormaMcliente form = new FormaMcliente();
            //form.txtIDcliente.Text="gol";
            //MessageBox.Show("no!!!!!!");
            
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            

            MessageBox.Show("no!!!!!!");
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String IDValor = (dgvDatos.Rows[e.RowIndex].Cells["Name"].Value.ToString());


                
            }
            catch(Exception ex){
                MessageBox.Show("ERROR","CUSTOMER",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
