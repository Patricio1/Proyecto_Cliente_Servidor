namespace SMC.PresentationLayer.BusquedasPersonalizadas
{
    partial class FormaBuscarProducto
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDescendente = new System.Windows.Forms.RadioButton();
            this.rdbAscendente = new System.Windows.Forms.RadioButton();
            this.lstCampoParaOrdenar = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPrecioProd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescPro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoPro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDescendente);
            this.groupBox2.Controls.Add(this.rdbAscendente);
            this.groupBox2.Controls.Add(this.lstCampoParaOrdenar);
            this.groupBox2.Location = new System.Drawing.Point(396, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 139);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenar por:";
            this.groupBox2.Visible = false;
            // 
            // rdbDescendente
            // 
            this.rdbDescendente.AutoSize = true;
            this.rdbDescendente.Location = new System.Drawing.Point(183, 63);
            this.rdbDescendente.Name = "rdbDescendente";
            this.rdbDescendente.Size = new System.Drawing.Size(89, 17);
            this.rdbDescendente.TabIndex = 2;
            this.rdbDescendente.TabStop = true;
            this.rdbDescendente.Text = "Descendente";
            this.rdbDescendente.UseVisualStyleBackColor = true;
            this.rdbDescendente.CheckedChanged += new System.EventHandler(this.rdbDescendente_CheckedChanged);
            // 
            // rdbAscendente
            // 
            this.rdbAscendente.AutoSize = true;
            this.rdbAscendente.Location = new System.Drawing.Point(183, 31);
            this.rdbAscendente.Name = "rdbAscendente";
            this.rdbAscendente.Size = new System.Drawing.Size(82, 17);
            this.rdbAscendente.TabIndex = 1;
            this.rdbAscendente.TabStop = true;
            this.rdbAscendente.Text = "Ascendente";
            this.rdbAscendente.UseVisualStyleBackColor = true;
            this.rdbAscendente.CheckedChanged += new System.EventHandler(this.rdbAscendente_CheckedChanged);
            // 
            // lstCampoParaOrdenar
            // 
            this.lstCampoParaOrdenar.FormattingEnabled = true;
            this.lstCampoParaOrdenar.Location = new System.Drawing.Point(20, 23);
            this.lstCampoParaOrdenar.Name = "lstCampoParaOrdenar";
            this.lstCampoParaOrdenar.Size = new System.Drawing.Size(157, 95);
            this.lstCampoParaOrdenar.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboPrecioProd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescPro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigoPro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // cboPrecioProd
            // 
            this.cboPrecioProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrecioProd.FormattingEnabled = true;
            this.cboPrecioProd.Location = new System.Drawing.Point(80, 97);
            this.cboPrecioProd.Name = "cboPrecioProd";
            this.cboPrecioProd.Size = new System.Drawing.Size(162, 21);
            this.cboPrecioProd.TabIndex = 5;
            this.cboPrecioProd.Visible = false;
            this.cboPrecioProd.SelectedIndexChanged += new System.EventHandler(this.cboPrecioProd_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio:";
            this.label3.Visible = false;
            // 
            // txtDescPro
            // 
            this.txtDescPro.Location = new System.Drawing.Point(80, 66);
            this.txtDescPro.MaxLength = 20;
            this.txtDescPro.Name = "txtDescPro";
            this.txtDescPro.Size = new System.Drawing.Size(162, 20);
            this.txtDescPro.TabIndex = 3;
            this.txtDescPro.TextChanged += new System.EventHandler(this.txtDescPro_TextChanged);
            this.txtDescPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescPro_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion:";
            // 
            // txtCodigoPro
            // 
            this.txtCodigoPro.Location = new System.Drawing.Point(80, 40);
            this.txtCodigoPro.MaxLength = 9;
            this.txtCodigoPro.Name = "txtCodigoPro";
            this.txtCodigoPro.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPro.TabIndex = 1;
            this.txtCodigoPro.TextChanged += new System.EventHandler(this.txtCodigoPro_TextChanged);
            this.txtCodigoPro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPro_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(143, 205);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(462, 150);
            this.dgvDatos.TabIndex = 5;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentDoubleClick);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMensaje.Location = new System.Drawing.Point(143, 187);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "label4";
            // 
            // FormaBuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(705, 384);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormaBuscarProducto";
            this.Text = "Formulario Buscar Producto";
            this.Load += new System.EventHandler(this.FormaBuscarProducto_Load);
            this.LocationChanged += new System.EventHandler(this.FormaBuscarProducto_LocationChanged);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbDescendente;
        private System.Windows.Forms.RadioButton rdbAscendente;
        private System.Windows.Forms.ListBox lstCampoParaOrdenar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboPrecioProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescPro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoPro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblMensaje;
    }
}
