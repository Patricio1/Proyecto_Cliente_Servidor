namespace SMC.PresentationLayer.Formularios_modificacion
{
    partial class OrderOptionsAgregar
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
            this.txtAdicional = new System.Windows.Forms.TextBox();
            this.txtPrime = new System.Windows.Forms.TextBox();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = " Opcion De Compra";
            // 
            // txtAdicional
            // 
            this.txtAdicional.Location = new System.Drawing.Point(296, 151);
            this.txtAdicional.Name = "txtAdicional";
            this.txtAdicional.Size = new System.Drawing.Size(156, 20);
            this.txtAdicional.TabIndex = 28;
            // 
            // txtPrime
            // 
            this.txtPrime.Location = new System.Drawing.Point(296, 116);
            this.txtPrime.Name = "txtPrime";
            this.txtPrime.Size = new System.Drawing.Size(156, 20);
            this.txtPrime.TabIndex = 27;
            this.txtPrime.TextChanged += new System.EventHandler(this.txtPrime_TextChanged);
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(296, 80);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(156, 20);
            this.txtTasa.TabIndex = 26;
            this.txtTasa.TextChanged += new System.EventHandler(this.txtTasa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Adicional Reserve Buque de carga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Primer Libro de buques de carga";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tasa de Impuesto a las Ventas";
            // 
            // OrderOptionsAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(521, 287);
            this.Controls.Add(this.txtAdicional);
            this.Controls.Add(this.txtPrime);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OrderOptionsAgregar";
            this.Load += new System.EventHandler(this.OrderOptionsAgregar_Load);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
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

        private System.Windows.Forms.TextBox txtAdicional;
        private System.Windows.Forms.TextBox txtPrime;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
