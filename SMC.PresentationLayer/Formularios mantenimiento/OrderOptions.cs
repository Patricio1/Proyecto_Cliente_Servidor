using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace SMC.PresentationLayer.Formularios_mantenimiento
{
    public partial class OrderOptions : SMC.PresentationLayer.FormaPlantillaMantenimiento
    {
        
        public OrderOptions()
        {
            InitializeComponent();
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtAdicional.Enabled = false;
            txtPrime.Enabled = false;
            txtTasa.Focus();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           // _botonPresionado = 1; //agregar
            
            Formularios_modificacion.OrderOptionsAgregar agregar = new Formularios_modificacion.OrderOptionsAgregar();
            agregar.Text = "Agregar";
           // agregar.MdiParent= agregar.MdiChildren;
            agregar.ShowDialog();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {   
            OracleConnection connection = new OracleConnection();
          try
            {
                if (txtTasa.Text.Trim() != "")
                {
                    Conexion.CadenaConexion = "User Id= MMABooks; Password= MMABooks; Data Source=XE";
                    connection.ConnectionString = Conexion.CadenaConexion;
                    connection.Open();

                    //string update = "UPDATE OrderOptions SET FirstBookShipCharge=:FirstBookShipCharge AND AdditionalBookShipCharge=:AdditionalBookShipCharge  WHERE SalesTaxRate=:SalesTaxRate";
                    string update = "UPDATE OrderOptions SET FirstBookShipCharge=:FirstBookShipCharge WHERE SalesTaxRate=:SalesTaxRate";

                    OracleCommand commandUpdate = new OracleCommand(update, connection);

                    
                    commandUpdate.Parameters.Add(":FirstBookShipCharge", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtPrime.Text);
                    commandUpdate.Parameters.Add(":SalesTaxRate", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtTasa.Text);

                    int cantidad = commandUpdate.ExecuteNonQuery();

                    if (cantidad > 0)
                    {
                        MessageBox.Show("Se actualizo el registro");

                        //Limpiar los controles 
                        txtTasa.Clear();
                        txtPrime.Clear();
                        txtAdicional.Clear();

                        //activar y desactivar botones => controles

                        txtTasa.Focus();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el registro por que no existe");
                    }
                }
                else
                {
                    MessageBox.Show("INGRESA EL VALOR DE LA TASA  PARA PODER ELIMINAR EL REGISTRO ");
                    txtTasa.Focus();
                }

            }


            catch(OracleException ex)
            {
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
                MessageBox.Show(ex.Message,"ERROR AL CONECTAR A ORACLE");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection connection = new OracleConnection();
            
            try
            {
                if (txtTasa.Text.Trim() != "")
                {
                    Conexion.CadenaConexion = "User Id= MMABooks; Password= MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();
                    
                        string delete = "DELETE FROM OrderOptions " +
                                         "WHERE SalesTaxRate= :SalesTaxRate";

                       OracleCommand command = new OracleCommand(delete, connection);


                        command.Parameters.Add(":SalesTaxRate", OracleDbType.Int32, 38).Value = txtTasa.Text;
                   
                        int cantidad = command.ExecuteNonQuery();

                        if (cantidad > 0)
                        {
                            MessageBox.Show("Se elimino el registro");

                            //Limpiar los controles 
                            txtTasa.Clear();
                            txtPrime.Clear();
                            txtAdicional.Clear();
                            
                            //activar y desactivar botones => controles

                            txtTasa.Focus();

                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro por que no existe");
                        }
                }
                else
                {
                    MessageBox.Show("INGRESA EL VALOR DE LA TASA  PARA PODER ELIMINAR EL REGISTRO ");
                    txtTasa.Focus();    
                }

            } 
           
             
           catch

            {
                //Cerrar la conexion
                connection.Close();

                //Liberar memoria.
                connection.Dispose();
                MessageBox.Show("ERROR AL CONECTAR A ORACLE");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recuperar();
        }



        private void recuperar()
        {
            OracleConnection connection = new OracleConnection();
            try
            {

                if (txtTasa.Text.Trim() != "")
                {
                    Conexion.CadenaConexion = "User Id= MMABooks; Password= MMABooks; Data Source=XE";
                connection.ConnectionString = Conexion.CadenaConexion;
                connection.Open();
                string select = "SELECT SalesTaxRate, FirstBookShipCharge, AdditionalBookShipCharge " +
                                "FROM OrderOptions " +
                                "WHERE SalesTaxRate= :SalesTaxRate";

                OracleCommand command = new OracleCommand(select, connection);

               // command.Parameters.Add(":SalesTaxRate", OracleDbType.Int32, 38).Value = Convert.ToInt32(txtTasa.Text);
                
                // LANDA EN ESTA PARTE NO SE POR QUE NO ME BUSCA  DARAS VIENDO SEGUN YO ESTA BIEN.
                command.Parameters.Add(":SalesTaxRate", OracleDbType.Int32, 38).Value = txtTasa.Text;

              
                OracleDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtTasa.Text = reader[0].ToString();
                    txtPrime.Text = reader[1].ToString();
                    txtAdicional.Text = reader[2].ToString();
                  
                        btnAgregar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;
                        txtAdicional.Enabled = true;
                        txtPrime.Enabled = true;
                        txtTasa.Enabled = true;
                        txtTasa.Focus();
                    
                   
                }
                else
                {
                    MessageBox.Show("No se encontro el registro",
                                            "Compras",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                    txtTasa.Clear();
                    txtPrime.Clear();
                    txtAdicional.Clear();
                
                }
              }
                else
                
                {

                    MessageBox.Show("INGRESA EL VALOR DE LA TASA  PARA PODER BUSCAR EL REGISTRO ");
                    txtTasa.Focus();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void txtTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == ' ' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPrime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == ' ' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtAdicional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == ' ' || e.KeyChar == '.')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void OrderOptions_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1, 20);
        }
    }
}
