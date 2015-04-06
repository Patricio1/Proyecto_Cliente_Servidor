using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using SMC.BusinessObjects;



namespace SMC.PresentationLayer
{
    public partial class FormaBuscarEmployees : SMC.PresentationLayer.FormaPlantillaPrincipal
    {
        private DataView _dataViewCustomes;
        public delegate void enviar(String mensaje);
       
        
        int valor;
        Validaciones ClaseValidar;
        public FormaBuscarEmployees()
        {
            InitializeComponent();
            _dataViewCustomes = new DataView();
            ClaseValidar = new Validaciones();
        }

        public FormaBuscarEmployees(int identificador)
        {
            this.valor = identificador;
            InitializeComponent();
            _dataViewCustomes = new DataView();
            ClaseValidar = new Validaciones();
        }
        private void FormaBuscarEmployees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(628, 100);

            OracleConnection connection = new OracleConnection();
             //Conexion.CadenaConexion = connection.ConnectionString;

            //Conexion.CadenaConexion = 
            connection.ConnectionString = "User Id= MMABooks; Password=MMABooks; Data Source=XE";


            String select = "SELECT EMPLOYEEID,LASTNAME,FIRSTNAME,TITLE,HIREDATE,POSTALCODE " +
                        "FROM EMPLOYEES"; 
             OracleCommand command = new OracleCommand(select, connection);

             OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = command;

            DataSet dataset = new DataSet();

            adapter.Fill(dataset, "EMPLOYEES");
            dgvDatos.DataSource = dataset;
            dgvDatos.DataMember = "EMPLOYEES";
            lblMensaje.Text = "Filas recuperadas: " + dataset.Tables[0].Rows.Count;
               DataView _datViewCustomers= new DataView() ;

               _dataViewCustomes = dataset.Tables["EMPLOYEES"].DefaultView;
               dgvDatos.DataSource = _dataViewCustomes;
            //---------------------------------------------------------------------
            //Recuperar datos de la tabla:employees y mostrarlos en el combo box (titulo no repetidos)
               select = "select distinct title from employees";
            command.CommandText = select;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            connection.Open();
            // usar un DataReader para recuperar los datos
            OracleDataReader reader = command.ExecuteReader(); //sqlDataReader no tiene contructor
            DataTable table = new DataTable();
            table.Load(reader); //leer los datos

            //vincular-enlazar los datos del dataTable
            //al comboBox.
            cboEstado.DataSource = table;
            cboEstado.DisplayMember = "title";

            cboEstado.ValueMember = "title";

            //
            for (int i = 0; i < _dataViewCustomes.Table.Columns.Count; i++)
            {
                lstCampoParaOrdenar.Items.Add(_dataViewCustomes.Table.Columns[i].ColumnName);
            }
        }


        private void btnAceptarIdCliente_Click(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "EMPLOYEEID=" + txtIdCliente.Text.Trim() + "";
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;//

            //MOstrar los datos una vez filtrados.
            dgvDatos.DataSource =_dataViewCustomes;
            lblMensaje.Text ="Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnAceptarNombre_Click(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: EmployeeID
            //__dataViewCustomes.RowFilter : SELECT* FROM Employees WHERE EmployeeID......
            _dataViewCustomes.RowFilter = "LastName LIKE '"+txtNombre.Text.Trim()+"%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            _dataViewCustomes.RowFilter = "LastName LIKE '" + txtNombre.Text.Trim() + "%'"; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //establecer la busqueda por campo: Title
            //__dataViewCustomes.RowFilter : SELECT* FROM Employees WHERE EmployeeID......
            _dataViewCustomes.RowFilter = "TITLE = '" + cboEstado.SelectedValue + "' "; //patron de busqueda
            _dataViewCustomes.RowStateFilter = DataViewRowState.OriginalRows;

            dgvDatos.DataSource = _dataViewCustomes;
            lblMensaje.Text = "Filas recuperadas: " + _dataViewCustomes.Count;
        }

        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "EMPLOYEE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
           ClaseValidar.validar(sender,e,1,txtIdCliente);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClaseValidar.validar(sender, e, 2, txtNombre);
        }

        private void dgvDatos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (valor == 1)
                {
                    String IDValor = (dgvDatos.Rows[e.RowIndex].Cells["EMPLOYEEID"].Value.ToString());
                    SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura detalle = (SMC.PresentationLayer.Formularios_modificacion.FormaDetalleFactura)Application.OpenForms[3];
                    //  detalle.txtCliente.ReadOnly = false;

                    detalle.cliente = IDValor;
                }
                else if (valor == 2)
                {
                    String nombre = (dgvDatos.Rows[e.RowIndex].Cells["FIRSTNAME"].Value.ToString());
                    String id = (dgvDatos.Rows[e.RowIndex].Cells["EMPLOYEEID"].Value.ToString());
                    String apellido = (dgvDatos.Rows[e.RowIndex].Cells["LASTNAME"].Value.ToString());
                    String titulo = (dgvDatos.Rows[e.RowIndex].Cells["TITLE"].Value.ToString());
                    String fecha = (dgvDatos.Rows[e.RowIndex].Cells["HIREDATE"].Value.ToString());
                    String codePostal = (dgvDatos.Rows[e.RowIndex].Cells["POSTALCODE"].Value.ToString());
                    SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado employ = (SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado)Application.OpenForms[2];

                    SMC.PresentationLayer.Formularios_mantenimiento.FormaMempleado.Nombre = nombre;
                    employ.txtNombre.Text = nombre;
                    employ.txtIDempleado.Text = id;
                    employ.txtApellido.Text = apellido;
                    employ.txtTitulo.Text = titulo;
                    employ.txtFecha.Text = fecha;
                    employ.txtCodigoPostal.Text = codePostal;

                    employ.btnUpdate.Enabled = true;
                    employ.btnDelete.Enabled = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "EMPLOYEE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
