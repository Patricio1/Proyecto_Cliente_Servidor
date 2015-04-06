namespace SMC.PresentationLayer.Formularios_mantenimiento
{
    partial class OrderOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.txtPrime = new System.Windows.Forms.TextBox();
            this.txtAdicional = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(375, 84);
            this.btnBuscar.Size = new System.Drawing.Size(99, 39);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(126, 268);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(258, 268);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(547, 46);
            this.lblTitulo.Text = "Opciones De Compra";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(406, 268);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tasa de Impuesto a las Ventas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Primer Libro de buques de carga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Adicional Reserve Buque de carga";
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(318, 93);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(45, 20);
            this.txtTasa.TabIndex = 20;
            this.txtTasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTasa_KeyPress);
            // 
            // txtPrime
            // 
            this.txtPrime.Location = new System.Drawing.Point(318, 129);
            this.txtPrime.Name = "txtPrime";
            this.txtPrime.Size = new System.Drawing.Size(156, 20);
            this.txtPrime.TabIndex = 21;
            this.txtPrime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrime_KeyPress);
            // 
            // txtAdicional
            // 
            this.txtAdicional.Location = new System.Drawing.Point(318, 164);
            this.txtAdicional.Name = "txtAdicional";
            this.txtAdicional.Size = new System.Drawing.Size(156, 20);
            this.txtAdicional.TabIndex = 22;
            this.txtAdicional.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdicional_KeyPress);
            // 
            // OrderOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(547, 309);
            this.Controls.Add(this.txtAdicional);
            this.Controls.Add(this.txtPrime);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OrderOptions";
            this.Load += new System.EventHandler(this.OrderOptions_Load);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnModificar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTasa, 0);
            this.Controls.SetChildIndex(this.txtPrime, 0);
            this.Controls.SetChildIndex(this.txtAdicional, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.TextBox txtPrime;
        private System.Windows.Forms.TextBox txtAdicional;
    }
}
